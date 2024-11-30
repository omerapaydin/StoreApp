using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Data.Abstract;
using StoreApp.Models;

namespace StoreApp.Controllers
{
    public class OrderController:Controller
    {
        private Cart cart;
        private IOrderRepository _orderRepository;

            public OrderController(Cart cartService, IOrderRepository orderRepository)
        {
            cart = cartService;
            _orderRepository = orderRepository;
        }



        public IActionResult Checkout()
        {
            return View(new OrderModel() { Cart = cart });
        }
        
    }
}