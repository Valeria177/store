using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Store.Web.Models;

namespace Store.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly IDetailRepository detailRepository;
        private readonly IOrderRepository orderRepository;

        public OrderController(IDetailRepository detailRepository, IOrderRepository orderRepository)
        {
            this.detailRepository = detailRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {

            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
               var order = orderRepository.GetById(cart.OrderId);
               OrderModel model = Map(order);

                return View(model);

            }
            return View("Empty");
        }

        private OrderModel Map(Order order)
        {
            var detailIds = order.Items.Select(item => item.DetailId);
            var details = detailRepository.GetAllByIds(detailIds);
            var itemModels = from item in order.Items
                             join detail in details on item.DetailId equals detail.Id
                             select new OrderItemModel
                             {
                                 DetailId = detail.Id,
                                 Title = detail.Title,
                                 Company = detail.Company,
                                 Price = item.Price,
                                 Count = item.Count,
                             };

            return new OrderModel
            {
                Id = order.Id,
                Items = itemModels.ToArray(),
                TotalCount = order.TotalCount,
                TotalPrice = order.TotalPrice,
            };
        }

        public IActionResult AddItem(int detailId, int count = 1)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            var detail = detailRepository.GetById(detailId);

            order.AddOrUpdateItem(detail, count);

            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Detail", new {id = detailId });
        }
        [HttpPost]
        public IActionResult UpdateItem(int detailId, int count)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            order.GetItem(detailId).Count =count;

            SaveOrderAndCart(order, cart);

            return RedirectToAction("Index", "Detail", new { detailId });
        }

       

        private (Order order, Cart cart) GetOrCreateOrderAndCart()
        {
            Order order;
            if (HttpContext.Session.TryGetCart(out Cart cart))
            {
                order = orderRepository.GetById(cart.OrderId);
            }
            else
            {
                order = orderRepository.Create();
                cart = new Cart(order.Id);
            }

            return (order, cart);
        }
        private void SaveOrderAndCart(Order order, Cart cart)
        {
            orderRepository.Update(order);

            cart.TotalCount = order.TotalCount;
            cart.TotalPrice = order.TotalPrice;

            HttpContext.Session.Set(cart);
        }

        public IActionResult RemoveItem(int id)
        {
            (Order order, Cart cart) = GetOrCreateOrderAndCart();

            order.RemoveItem(id);

            SaveOrderAndCart(order, cart);


            return RedirectToAction("Index", "Detail", new { id });
        }
    }
}