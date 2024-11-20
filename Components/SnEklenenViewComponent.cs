using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;

namespace StoreApp.Components
{
    public class SnEklenenViewComponent:ViewComponent
    {
        private IPostRepository _postRepository;
        public SnEklenenViewComponent(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }



        public IViewComponentResult Invoke()
        {
            return View(_postRepository.Posts.OrderByDescending(p => p.PublishedOn).Take(8).ToList());
        }
    }
}