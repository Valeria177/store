using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class OrderItem
    {
        public int DetailId { get; }


        private int count;
        public int Count
        { 
            get { return count; }
            set 
            {
                ThrowIFInvalidCount(value);

                count = value;
            }
        }

        public decimal Price { get; }

        public OrderItem(int detailId, decimal price, int count)
        {
            ThrowIFInvalidCount(count);

            DetailId = detailId;
            Count = count;
            Price = price;
        }

        private static void ThrowIFInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count не может быть меньше 0 ");
        }
    }
}
