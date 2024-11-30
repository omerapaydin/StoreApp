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

        public Cart Carts { get; set; }

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

    if (Carts == null)
    {
        Carts = new Cart();
    }

    if (Carts.Items == null || !Carts.Items.Any())
    {
        return RedirectToPage("/Cart");
    }

    var cartItem = Carts.Items.FirstOrDefault(p => p.Post.PostId == PostId);

    if (cartItem == null)
    {
        return RedirectToPage("/Cart");
    }

    var post = cartItem.Post;
    Carts.RemoveItem(post); // Silme işlemi

    // Sepeti güncelle
    HttpContext.Session.SetJson("cart", Carts);

    return RedirectToPage("/Cart");
}
    }
}