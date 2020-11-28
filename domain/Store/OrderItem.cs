using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class OrderItem
    {
        public int DetailId { get; }

        public int Count { get; }

        public decimal Price { get; }

        public OrderItem(int detailId, int count, decimal price)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count не может быть меньше 0 ");

            DetailId = detailId;
            Count = count;
            Price = price;
        }
    }
}
