using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture;

namespace Ch2.CreatingFixture.Tests
{
    public class ObjectGraphTests
    {
        [Fact]
        public void Create_ManualAnonymousTestData()
        {
            // Arrange
            var customer = new Customer()
            {
                CustomerName = "Eugene"
            };

            var order = new Order(customer)
            {
                Id = 42,
                OrderDate = DateTime.Now,
                Items =
                {
                    new OrderItem
                    {
                        ProductName = "Notebook",
                        Quantity = 2
                    }
                }
            };

            // Act

            // Assert
        }

        [Fact]
        public void Create_AutomaticalAnonymousTestData()
        {
            // Assert
            var fixture = new Fixture();

            // 생성자의 기본타입과 사용자 정의타입 매개변수는 자동으로 주입한다.
            // public Order(Customer customer)
            var order = fixture.Create<Order>();

            // Act

            // Assert
        }
    }
}
