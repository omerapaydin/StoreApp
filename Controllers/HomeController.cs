using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Entity;
using StoreApp.ViewModel;

namespace StoreApp.Controllers
{

    public class HomeController:Controller
    {
        public int pageSize = 3;

        private IPostRepository _postRepository;
        private ICommentRepository _commentRepository;
        private ICategoryRepository _categoryRepository;
         
        private UserManager<ApplicationUser> _userManager;
        public HomeController(IPostRepository postRepository,UserManager<ApplicationUser> userManager,ICategoryRepository categoryRepository,ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _userManager = userManager;
            _categoryRepository = categoryRepository;
            _commentRepository = commentRepository;
        }

        public IActionResult Index()
        {
            return View(_categoryRepository.Categories.ToList());
        }
            public IActionResult List(string search, int? id, int page = 1)
        {
            var products = _postRepository.Posts.AsQueryable();
            var categories = _categoryRepository.Categories.ToList();

            if (id != null)
            {
                products = products.Where(p => p.CategoryId == id);
                ViewBag.CategoryId = id; 
            }

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Description.ToLower().Contains(search.ToLower()));
                ViewBag.Search = search; 
            }

            var viewModel = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Categories = categories,
                PageInfo = new PageInfo
                {
                    ItemsPerPage = pageSize,
                    TotalItems = products.Count(),
                    CurrentPage = page
                }
            };

            return View(viewModel);
        }
        public async Task<IActionResult> Details(int id)
        {
           var post = await _postRepository.Posts.Include(p=>p.User).Include(p=>p.Comments).ThenInclude(p=>p.User).FirstOrDefaultAsync(p => p.PostId == id);

            return View(post);
        }
         [Authorize]
           public IActionResult AddProduct()
        {
             ViewBag.Categories = new SelectList(_categoryRepository.Categories, "CategoryId", "Name");
            return View();
        }


        [HttpPost]

           public async Task<IActionResult> AddProduct(AddPostViewModel model , IFormFile imageFile)
        {

           
             var extension = "";

            if (imageFile != null)
            {
                var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
                extension = Path.GetExtension(imageFile.FileName);

                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("", "Geçerli bir resim seçiniz");
                    return View(model);
                }
            }
                else
                {
                    ModelState.AddModelError("", "Lütfen bir resim dosyası seçiniz");
                    return View(model); 
                }

             if (ModelState.IsValid)
            
            {
                var randomFileName = $"{Guid.NewGuid()}{extension}";
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                  using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }


                if (User.Identity!.IsAuthenticated)
            {
                // Kullanıcı giriş yapmış
                var userId = _userManager.GetUserId(User);
               
               
               var post = new Post
                    {
                        Title = model.Title,
                        Description = model.Description,
                       
                        Image = randomFileName,
                        PublishedOn = DateTime.Now,
                        UserId = userId,
                        CategoryId = model.CategoryId
                    };
                         if (decimal.TryParse(model.Price, out decimal parsedPrice))
                    {
                        post.Price = parsedPrice;
                    }
                    else
                    {
                       
                        post.Price = null;
                       
                    }

                _postRepository.AddPost(post);


                return RedirectToAction("List","Home");
   
            }
            // else
            // {
            //     return RedirectToAction("Login");
            // }



            }

                 return View(model);


        }


       [HttpPost]
public async Task<IActionResult> AddComment(int PostId, string Url, string Text)
{
    if (User.Identity?.IsAuthenticated == true)
    {
        var userId = _userManager.GetUserId(User);

        if (string.IsNullOrEmpty(userId))
        {
            return Unauthorized(); // Kullanıcı kimliği bulunamadıysa yetkisiz erişim.
        }

        var entity = new Comment
        {
            PostId = PostId,
            Text = Text,
            PublishedOn = DateTime.Now,
            UserId = userId
        };

        try
        {
            _commentRepository.AddComment(entity);
            return RedirectToAction("Details", new { id = PostId, url = Url });
        }
        catch (Exception ex)
        {
            // Hata loglama
            ModelState.AddModelError("", "Yorum eklenirken bir hata oluştu.");
        }
    }

    return RedirectToAction("Login", "Account"); // Kullanıcı oturum açmamışsa giriş sayfasına yönlendir.
}


    }
}