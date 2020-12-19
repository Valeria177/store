using Store.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Store
{
    public class OrderItemCollection : IReadOnlyCollection<OrderItem>
    {

        private readonly OrderDTO orderDTO;
        public readonly List<OrderItem> items;

        public OrderItemCollection(OrderDTO orderDTO)
        {
            if (orderDTO == null)
                throw new ArgumentNullException(nameof(orderDTO));

            this.orderDTO = orderDTO;

            items = orderDTO.Items
                            .Select(OrderItem.Mapper.Map)
                            .ToList();
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
                throw new InvalidOperationException("Detail already exists.");
            var orderItemDTO = OrderItem.DtoFactory.Create(orderDTO, detailId, price, count);
            orderDTO.Items.Add(orderItemDTO);

            orderItem = OrderItem.Mapper.Map(orderItemDTO);
            items.Add(orderItem);

            return orderItem;
        }

        public void Remove(int detailId)
        {
            var index = items.FindIndex(item => item.DetailId == detailId);
            if (index == -1)
                throw new InvalidOperationException("Can't find book to remove from order.");

            orderDTO.Items.RemoveAt(index);
            items.RemoveAt(index);
        }
    }
}
