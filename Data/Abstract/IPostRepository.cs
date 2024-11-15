using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entity;

namespace StoreApp.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post>  Posts { get; }

        void AddPost(Post post);
    }
}