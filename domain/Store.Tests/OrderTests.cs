﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Store.Tests
{
    public class OrderTests
    {

        [Fact]
        public void TotalCount_WithEmptyItems_ReturnZero()
        {
            var order = new Order(1, new OrderItem[0]);
            Assert.Equal(0, order.TotalCount);

        }

        [Fact]
        public void TotalPrice_WithEmptyItems_ReturnZero()
        {
            var order = new Order(1, new OrderItem[0]);
            Assert.Equal(0m, order.TotalCount);

        }

        [Fact]
        public void TotalCount_WithNonEmptyItems_CalcualtesTotalCount()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),

            });
            Assert.Equal(3 + 5, order.TotalCount);
        }


        [Fact]
        public void TotalPrice_WithNonEmptyItems_CalcualtesTotalPrice()
        {
            var order = new Order(1, new[]
            {
                new OrderItem(1, 10m, 3),
                new OrderItem(2, 100m, 5),

            });
            Assert.Equal(3 * 10m + 5*100m, order.TotalPrice);
        }

    }
}
