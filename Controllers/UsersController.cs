using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Entity;
using StoreApp.ViewModel;

namespace StoreApp.Controllers
{
    public class UsersController:Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
       

        public UsersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
          
        }
        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
       [Authorize]
     public async Task<IActionResult> Edit(string id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }

            var user = await _userManager.FindByIdAsync(id);

            if(user != null)
            {
                return View(new EditViewModel {
                    Id = user.Id,
                    UserName= user.UserName,
                    Email= user.Email
                });

            }

                return RedirectToAction("Index");

        }
       [HttpPost]
public async Task<IActionResult> Edit(string id, EditViewModel model)
{
    if (ModelState.IsValid)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user != null)
        {
            user.Email = model.Email;
            user.UserName = model.UserName;

            var result = await _userManager.UpdateAsync(user);  

          
            if (result.Succeeded && !string.IsNullOrEmpty(model.Password))
            {
                var hasher = new PasswordHasher<ApplicationUser>();
                user.PasswordHash = hasher.HashPassword(user, model.Password);
                result = await _userManager.UpdateAsync(user);  
                
            }

            
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
         }

     
            return View(model);
            }

            
         return View(model);
        }




    }
}