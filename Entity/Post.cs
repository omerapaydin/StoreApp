using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Entity
{
    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public DateTime PublishedOn { get; set; }
        public string? Price { get; set; }
        public bool IsActive { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int CategoryId { get; set; }  // Foreign Key
        public Category Category { get; set; } 

    }
}