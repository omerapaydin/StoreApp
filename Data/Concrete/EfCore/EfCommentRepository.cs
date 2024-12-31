using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Data.Abstract;
using StoreApp.Entity;
using StoreApp.Models;

namespace StoreApp.Data.Concrete.EfCore
{
    public class EfCommentRepository : ICommentRepository
    {
         private IdentityContext _context;

        public EfCommentRepository(IdentityContext context)
        {
            _context = context;
        }
        public IQueryable<Comment> Comments => _context.Comments;

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}