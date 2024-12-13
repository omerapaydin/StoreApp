using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Data.Abstract;
using StoreApp.Helpers;
using StoreApp.Models;

namespace StoreApp.Pages
{
    public class CartPageModel : PageModel
    {
        private readonly IPostRepository _postRepository;

        public CartPageModel(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public Cart? Carts { get; set; }

       public void OnGet()
        {
            Carts = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int PostId)
        {
            var post = _postRepository.Posts.FirstOrDefault(i => i.PostId == PostId);

            if (post != null)
            {
                Carts = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Carts.AddItem(post, 1);
                HttpContext.Session.SetJson("cart", Carts);
            }
            return RedirectToPage("/Cart");
        }


       public IActionResult OnPostRemove(int PostId)
{
    Carts = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

    var itemToRemove = Carts.Items.FirstOrDefault(p => p.Post.PostId == PostId);

    if (itemToRemove != null)
    {
        Carts.RemoveItem(itemToRemove.Post);
        HttpContext.Session.SetJson("cart", Carts);
    }

    return RedirectToPage("/Cart");
}

        }
    }