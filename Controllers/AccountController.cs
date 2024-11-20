using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Entity;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace StoreApp.Controllers
{
    public class AccountController:Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
          
        }
        
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
         public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await _signInManager.SignOutAsync();



                    var result = await _signInManager.PasswordSignInAsync(user,model.Password,model.RememberMe,false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }else{
                         ModelState.AddModelError("", "hatalı parola ya da password");
                    }
                }else
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı.");
                }


            }else {
                ModelState.AddModelError("", "hatalı eposta ya da password");
            }

            return View(model);
        }

         public IActionResult Create()
        {
            return View();
        }
   [HttpPost]
public async Task<IActionResult> Create(CreateViewModel model, IFormFile? imageFile)
{
    if (imageFile == null)
    {
        ModelState.AddModelError("", "Lütfen bir resim dosyası seçiniz");
        return View(model);
    }

    var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };
    var extension = Path.GetExtension(imageFile.FileName);

    if (!allowedExtensions.Contains(extension))
    {
        ModelState.AddModelError("", "Geçerli bir resim seçiniz");
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

        var user = new ApplicationUser
        {
            UserName = model.UserName,
            Email = model.Email,
            ImageFile = randomFileName
        };

        var hasher = new PasswordHasher<ApplicationUser>();
        user.PasswordHash = hasher.HashPassword(user, model.Password);

        IdentityResult result = await _userManager.CreateAsync(user);

        if (result.Succeeded)
        {
            return RedirectToAction("Login", "Account");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
    }

    return View(model);
}
          
          public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }



        public async Task<IActionResult> Profile()
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);

            if(user == null)
            {
                return NotFound(); 
            }

            return View(user);
        }



         



    }
}