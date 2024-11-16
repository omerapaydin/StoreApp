using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Entity;
using StoreApp.ViewModel;

namespace StoreApp.Controllers
{

    public class HomeController:Controller
    {

        private IPostRepository _postRepository;
        private ICategoryRepository _categoryRepository;
         
        private UserManager<ApplicationUser> _userManager;
        public HomeController(IPostRepository postRepository,UserManager<ApplicationUser> userManager,ICategoryRepository categoryRepository)
        {
            _postRepository = postRepository;
            _userManager = userManager;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            return View(_categoryRepository.Categories.ToList());
        }
        public IActionResult List(string search,int? id)
        {
            var products = _postRepository.Posts;
             var categories = _categoryRepository.Categories;

             if (id != null)
            {
               products = products.Where(p => p.CategoryId == id);
            }

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Description.ToLower().Contains(search.ToLower()));
            }

            var viewModel = new ProductListViewModel
            {
                Products = products.ToList(),
                Categories = categories.ToList()
                
            };

            return View(viewModel);
        }
        public async Task<IActionResult> Details(int id)
        {
           var post = await _postRepository.Posts.FirstOrDefaultAsync(p => p.PostId == id);

            return View(post);
        }
         [Authorize]
           public IActionResult AddProduct()
        {
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
                
                var product = new AddPostViewModel {
                        Title = model.Title,
                        Description = model.Description,
                        Price = model.Price,
                        Image = randomFileName,
                        PublishedOn = DateTime.Now,
                        UserId = userId
                    };


                return RedirectToAction("List","Users");
   
            }
            // else
            // {
            //     return RedirectToAction("Login");
            // }



            }

                 return View(model);


        }





    }
}