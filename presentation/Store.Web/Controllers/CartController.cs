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

        public CartController(IDetailRepository detailRepository)
        {
            this.detailRepository = detailRepository;
        }

        public IActionResult Add(int id)
        {
            var detail = detailRepository.GetById(id);
            Cart cart;
            if (!HttpContext.Session.TryGetCart(out cart))
                cart = new Cart();

            if (cart.Items.ContainsKey(id))

                cart.Items[id]++;

            else

                cart.Items[id] = 1;

            cart.Amount += detail.Price;

            HttpContext.Session.Set(cart);

            return RedirectToAction("Index", "Detail", new { id });
            
        }
    }
}