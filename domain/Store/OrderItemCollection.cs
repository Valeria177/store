using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class OrderItemCollection : IReadOnlyCollection<OrderItem>
    {
        public readonly List<OrderItem> items;

        public OrderItemCollection(IEnumerable<OrderItem> items)
        {
            if (items == null)
                throw new ArgumentException(nameof(items));
            this.items = new List<OrderItem>(items);

        }

        public int Count => items.Count;


        public IEnumerator<OrderItem> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (items as IEnumerable).GetEnumerator();
        }

        public OrderItem Get(int detailId)
        {
            if (TryGet(detailId, out OrderItem orderItem))
                return orderItem;

            throw new InvalidOperationException("Detail not found");

        }
        
        public bool TryGet(int detailId, out OrderItem orderItem)
        {
            var index = items.FindIndex(item => item.DetailId == detailId);
            if (index == -1)
            {
                orderItem = null;
                return false;
            }

            orderItem = items[index];
            return true;
        }

        public OrderItem Add(int detailId, decimal price, int count)
        {
            if (TryGet(detailId, out OrderItem orderItem))
                throw new InvalidOperationException("Detail already exists");

            orderItem = new OrderItem(detailId, price, count);
            items.Add(orderItem);

            return orderItem;
        }

        public void Remove(int detailId)
        {
            items.Remove(Get(detailId));
        }
    }

}
