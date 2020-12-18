using Store.Data;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class OrderItemTests
    {
        [Fact]
        public void OrderItem_WithZeroCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = 0;
                OrderItem.DtoFactory.Create(new OrderDTO(), 1, 10m, count);
            });
        }

        [Fact]
        public void OrderItem_WithNegativCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                int count = -1;
                OrderItem.DtoFactory.Create(new OrderDTO(), 1, 10m, count);
            });
        }

        [Fact]
        public void OrderItem_WithPositiveCount_SetCount()
        {
           var orderItem =  OrderItem.DtoFactory.Create(new OrderDTO(), 1, 10m, 2);

            Assert.Equal(1, orderItem.DetailId);
            Assert.Equal(10m, orderItem.Price);
            Assert.Equal(2, orderItem.Count);
            
        }

        [Fact]
        public void Count_WithNegativeValue_ThrowsArgumentOfRangeException()
        {
            var orderItemDTO = OrderItem.DtoFactory.Create(new OrderDTO(), 1, 10m, 30);
            var orderItem = OrderItem.Mapper.Map(orderItemDTO);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = -1;
            });

        }

        [Fact]
        public void Count_WithZeroValue_ThrowsArgumentOfRangeException()
        {
            var orderItemDTO = OrderItem.DtoFactory.Create(new OrderDTO(), 1, 10m, 30);
            var orderItem = OrderItem.Mapper.Map(orderItemDTO);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                orderItem.Count = 0;
            });

        }

        [Fact]
        public void Count_WithPositiveValue_SetValue()
        {
            var orderItemDTO = OrderItem.DtoFactory.Create(new OrderDTO(), 1, 10m, 30);
            var orderItem = OrderItem.Mapper.Map(orderItemDTO);

            orderItem.Count = 10;

            Assert.Equal(10, orderItem.Count);

  

        }
    }
}