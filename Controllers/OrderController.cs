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
        private Cart _cart;
        private IOrderRepository _orderRepository;

            public OrderController(Cart cartService, IOrderRepository orderRepository)
        {
            _cart = cartService;
            _orderRepository = orderRepository;
        }



        public IActionResult Checkout()
        {
            var orderModel = new OrderModel
            {
                Cart = _cart, // Cart bilgilerini doldurun
                Name = "",
                City = "",
                Phone = "",
                Email = "",
                AddressLine = ""
            };
            return View(orderModel);
        }
        
    }
}