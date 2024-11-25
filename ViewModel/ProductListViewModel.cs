using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entity;

namespace StoreApp.ViewModel
{
    public class ProductListViewModel
    {
        public List<Post>? Products { get; set; }
        public List<Category>? Categories { get; set; }
         public PageInfo PageInfo { get; set; } = new();
    }

        public class PageInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }



}