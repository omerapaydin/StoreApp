using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Data.Abstract;
using StoreApp.Entity;

namespace StoreApp.Components
{
    public class YourProductsViewComponent:ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private IPostRepository _postRepository;
        public YourProductsViewComponent(IPostRepository postRepository,UserManager<ApplicationUser> userManager)
        {
            _postRepository = postRepository;
            _userManager = userManager;

        }



        public IViewComponentResult Invoke()
        {

          var userId = _userManager.GetUserId(HttpContext.User);
         

            return View( _postRepository.Posts.Where(p=>p.UserId == userId).OrderByDescending(p => p.PublishedOn).ToList());
        }
    }
}