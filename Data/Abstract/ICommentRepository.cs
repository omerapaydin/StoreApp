using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entity;

namespace StoreApp.Data.Abstract
{
    public interface ICommentRepository
    {
       IQueryable<Comment>  Comments { get; }

        void AddComment(Comment comment);
    }
}