using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Data.Abstract;
using StoreApp.Entity;
using StoreApp.Models;

namespace StoreApp.Data.Concrete.EfCore
{
    public class EfOrderRepository : IOrderRepository
    {
          private IdentityContext _context;

        public EfOrderRepository(IdentityContext context)
        {
            _context = context;
        }
        public IQueryable<Order> Categories => _context.Orders;

        public void AddOrder(Order order)
        {
           _context.Orders.Add(order);
            _context.SaveChanges();
        
        }
    }
}