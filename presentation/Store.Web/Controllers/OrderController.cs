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


        public IActionResult AddItem(int id)
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