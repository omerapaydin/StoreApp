using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entity;

namespace StoreApp.Data.Abstract
{
    public interface IOrderRepository
    {
       IQueryable<Order>  Orders { get; }

        void AddOrder(Order Order);
    }
}