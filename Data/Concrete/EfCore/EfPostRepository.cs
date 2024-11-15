using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Data.Abstract;
using StoreApp.Entity;
using StoreApp.Models;

namespace StoreApp.Data.Concrete.EfCore
{
    public class EfPostRepository : IPostRepository
    {
        private IdentityContext _context;

        public EfPostRepository(IdentityContext context)
        {
            _context = context;
        }
        public IQueryable<Post> Posts => _context.Posts;

        public void AddPost(Post post)
        {
             _context.Posts.Add(post);
            _context.SaveChanges();
        }
    }
}