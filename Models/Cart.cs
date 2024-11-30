using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entity;

namespace StoreApp.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Post post, int quantity)
        {
            var item = Items.FirstOrDefault(p => p.Post.PostId == post.PostId);

            if (item == null)
            {
                Items.Add(new CartItem { Post = post, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public void RemoveItem(Post post)
        {
           var removedItems = Items.Where(i => i.Post.PostId == post.PostId).ToList();

    Items.RemoveAll(i => i.Post.PostId == post.PostId);
        }

        public decimal CalculateTotal()
        {
            return Items.Sum(i => (i.Post.Price ?? 0) * i.Quantity);
        }

        public void Clear()
        {
            Items.Clear();
        }
    }

    public class CartItem
    {
        public int CartItemId { get; set; }
        public Post Post { get; set; } = new();
        public int Quantity { get; set; }
    }
}