using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.ViewModel
{
    public class AddPostViewModel
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Price { get; set; }
        public DateTime PublishedOn { get; set; }
       public string? UserId { get; set; }
  

        
    }
}