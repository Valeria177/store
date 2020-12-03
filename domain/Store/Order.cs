using System;
using System.Collections.Generic;
using System.Linq;
namespace Store
{
    public class Order
    {
        public int Id { get; }

        public OrderItemCollection Items { get; }
        

        public string CellPhone { get; set; }

        public OrderDelivery Delivery { get; set; }

        public OrderPayment Payment { get; set; }

        public int TotalCount => Items.Sum(item => item.Count); 

        public decimal TotalPrice => Items.Sum(item => item.Price * item.Count) + (Delivery?.Amount ?? 0m);
       

        public Order(int id, IEnumerable<OrderItem> items)
        {
            Id = id;
            Items = new OrderItemCollection(items);
        }

        public void AddItem(Detail detail, int v)
        {
            throw new NotImplementedException(); 
        }

        private void ThrowDetailException(string message, int detailId)
        {
            var exception = new InvalidOperationException(message);
            exception.Data["DetailId"] = detailId;

            throw exception;
        }
    }
}
