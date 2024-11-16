using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;

namespace StoreApp.Components
{
    public class CategoriesViewComponent:ViewComponent
    {
        private ICategoryRepository _categoryRepository;
        public CategoriesViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

         public IViewComponentResult Invoke(int? id)
        {
          var categories = _categoryRepository.Categories;

          if (id != null)
          {
              categories = categories.Where(p => p.CategoryId == id);
          }

          return View(categories.ToList());
      }
    }
}