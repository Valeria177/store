using Store.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    public class OrderItem
    {

        private readonly OrderItemDTO dto;

        public int DetailId => dto.DetailId;
      
        public int Count
        {
            get  { return dto.Count; }
            set
            {
                ThrowIfInvalidCount(value);

                dto.Count = value;
            }
        }

        public decimal Price
        {
            get => dto.Price;
            set => dto.Price = value;
        }

        internal OrderItem(OrderItemDTO dto)
        {
            this.dto = dto;
        }

        private static void ThrowIfInvalidCount(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException("Count не может быть меньше 0 ");
        }

        public static class DtoFactory
        {
            public static OrderItemDTO Create(OrderDTO order, int detailId, decimal price, int count)
            {
                if (order == null)
                    throw new ArgumentNullException(nameof(order));

                ThrowIfInvalidCount(count);

                return new OrderItemDTO
                {
                    DetailId = detailId,
                    Price = price,
                    Count = count,
                    Order = order,
                };
            }
        }

        public static class Mapper
        {
            public static OrderItem Map(OrderItemDTO dto) => new OrderItem(dto);

            public static OrderItemDTO Map(OrderItem domain) => domain.dto;
        }
    }
}
