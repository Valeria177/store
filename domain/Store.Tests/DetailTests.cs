using System;
using Xunit;

namespace Store.Tests
{
    public class DetailTests
    {
        [Fact]
        public void IsPart_number_WithNull_ReturnFalse()
        {
            bool actual = Detail.IsPart_number(null);

            Assert.False(actual);
        }

        [Fact]
        public void IsPart_number_WithBlankString_ReturnFalse()
        {
            bool actual = Detail.IsPart_number("   ");

            Assert.False(actual);
        }

        [Fact]
        public void IsPart_number_WithInvalidPart_number_ReturnFalse()
        {
            bool actual = Detail.IsPart_number("133");

            Assert.False(actual);
        }
        
        [Fact]
        public void IsPart_number_WithInvalidPart_number9_ReturnTrue()
        {
            bool actual = Detail.IsPart_number("058133843");

            Assert.True(actual);
        }

      
    }
}
