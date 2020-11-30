using System;
using System.Collections.Generic;
using System.Linq;
namespace Store
{
    public class Order
    {
        public int Id { get; }

        private List<OrderItem> items;


        public IReadOnlyCollection<OrderItem> Items
        {
            get { return items; }
        }

        public string CellPhone { get; set; }

        public OrderDelivery Delivery { get; set; }

        public OrderPayment Payment { get; set; }

        public int TotalCount => items.Sum(item => item.Count); 

        public decimal TotalPrice => items.Sum(item => item.Price * item.Count) + (Delivery?.Amount ?? 0m);
       

        public Order(int id, IEnumerable<OrderItem> items)
        {

            if (items == null)
                throw new ArgumentNullException(nameof(items));


            Id = id;

            this.items = new List<OrderItem>(items);
        }

        public OrderItem GetItem(int detailId)
        {
            int index = items.FindIndex(item => item.DetailId == detailId);

            if (index == -1)
               ThrowDetailException ("Деталь не найдена", detailId);
            return items[index];

        }


        public void AddOrUpdateItem(Detail detail, int count)
        {
            if (detail == null)
                throw new ArgumentNullException(nameof(detail));

            int index = items.FindIndex(item => item.DetailId == detail.Id);
            if (index == -1)
            {
                items.Add(new OrderItem(detail.Id, count, detail.Price));
            }
            else
                items[index].Count += count;
        }

        public void RemoveItem(int detailId)
        {
            int index = items.FindIndex(item => item.DetailId == detailId);

            if (index == -1)
                ThrowDetailException("Order does not contain specified item", detailId);


            items.RemoveAt(index);
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
