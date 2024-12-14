using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using StoreApp.Data.Abstract;
using StoreApp.Entity;
using StoreApp.Helpers;
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
            var cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            return View(new OrderModel() { Cart = cart });
        }
        [HttpPost]
        public IActionResult Checkout(OrderModel model)
        {
            var cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            if (!cart.Items.Any())
            {
                ModelState.AddModelError("", "Sepetinizde ürün yok.");
            }

            if (ModelState.IsValid)
            {
                var order = new Order
                {
                    Name = model.Name,
                    Email = model.Email,
                    City = model.City,
                    Phone = model.Phone,
                    AddressLine = model.AddressLine,
                    OrderDate = DateTime.Now,
                    OrderItems = cart.Items.Select(i => new OrderItem
                    {
                        PostId = i.Post.PostId,
                        Price = (double)i.Post.Price,
                        Quantity = i.Quantity
                    }).ToList()
                };

                _orderRepository.AddOrder(order);
                cart.Clear();
                HttpContext.Session.SetJson("cart", cart);
                return RedirectToAction("Completed", new { orderId = order.Id });
            }

            model.Cart = cart;
            return View(model);
        }
         public IActionResult Completed(int orderId)
        {
            ViewBag.OrderId = orderId;
            return View();
        }

    }
}