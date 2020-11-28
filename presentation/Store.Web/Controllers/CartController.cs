using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IDetailRepository detailRepository;
        private readonly IOrderRepository orderRepository;

        public CartController(IDetailRepository detailRepository, IOrderRepository orderRepository)
        {
            this.detailRepository = detailRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Add(int id)
        {

            Order order;
            Cart cart;
            if (HttpContext.Session.TryGetCart(out cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }

            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }

            var detail = detailRepository.GetById(id);
            order.AddItem(detail, 1);
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;
            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Detail", new { id });
            
        }
    }
}