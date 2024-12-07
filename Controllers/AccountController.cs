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
       private readonly StoreApp.Models.IEmailSender _emailSender;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,StoreApp.Models.IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
          
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


                if(!await _userManager.IsEmailConfirmedAsync(user))
                   {
                    ModelState.AddModelError("", "Hesabınızı onaylayınız.");
                    return View(model);
                   }


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
            ImageFile = randomFileName,
        };

        var hasher = new PasswordHasher<ApplicationUser>();
        user.PasswordHash = hasher.HashPassword(user, model.Password);

        IdentityResult result = await _userManager.CreateAsync(user);

        if (result.Succeeded)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var url = Url.Action("ConfirmEmail", "Account", new{user.Id,token});

                  
                await _emailSender.SendEmailAsync(user.Email, "Hesap Onayı",$"Lütfen email hesabınızı onaylamak için linke <a href='http://localhost:5041{url}'> tıklayınız. <a/>");



                TempData["message"] = "Email hesabınızdaki onay mailine tıkla.";
                return RedirectToAction("Login", "Account");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
    }

    return View(model);
}
          

          public async Task<IActionResult> ConfirmEmail(string Id, string token)
        {
            if(Id == null || token == null)
            {
                TempData["message"] = "Geçersiz token bilgisi";
                return View();
            }

             var user = await _userManager.FindByIdAsync(Id);

            if (user != null)
            {
                var result = await _userManager.ConfirmEmailAsync(user,token);


                if (result.Succeeded)
                {
                    TempData["message"] = "Hesabınız onaylandı";
                    return RedirectToAction("Login","Account");
                }
            }

            TempData["message"] = "Kullanıcı bulunamadı onaylandı";
                    return View();
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



          public IActionResult ForgotPassword()
        {

            return View();
        }
        [HttpPost]
          public async Task<IActionResult> ForgotPassword(string Email)
        {
            if(string.IsNullOrEmpty(Email))
            {
                 TempData["message"] = "Eposta giriniz";
                 return View();

            }

            var user = await _userManager.FindByEmailAsync(Email);
            
            if (user == null)
            {
                 TempData["message"] = "Eposta yok";

                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
             var url = Url.Action("ResetPassword", "Account", new{user.Id,token});

              await _emailSender.SendEmailAsync(user.Email, "Şifre Sıfırlama",$"Lütfen şifre değiştirmek için linke <a href='http://localhost:5041{url}'> tıklayınız. <a/>");

              TempData["message"] = "Epostanıza gönderilen link ile şifrenizi sıfırlayabilirsiniz.";

             return View();

        }


             public IActionResult ResetPassword(string Id,string token)
            {
                if(Id==null || token == null)
                {
                     return RedirectToAction("Login");
                }
                var model = new ResetPasswordModel{Token = token };
                return View(model);
            }

            [HttpPost]
            public async Task<IActionResult> ResetPassword(ResetPasswordModel model)
            {
                if(ModelState.IsValid)
                {
                    var user = await _userManager.FindByEmailAsync(model.Email);

                 if(user == null)
                 {
                     TempData["message"] = "Email adresiyle eşleşen kullanıcı yok.";
                    return RedirectToAction("Login");
                 }

                    var result = await _userManager.ResetPasswordAsync(user,model.Token,model.Password);

                    if(result.Succeeded)

                    {
                          TempData["message"] = "Şifre değiştirildi.";
                        return RedirectToAction("Login");
                        
                    }


                }
                return View(model);

            }




    }
}