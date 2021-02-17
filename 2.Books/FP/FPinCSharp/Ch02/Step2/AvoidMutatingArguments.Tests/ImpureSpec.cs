using AvoidMutatingArguments.Stage1;
using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;

namespace AvoidMutatingArguments.Tests
{
    public class ImpureSpec
    {
        [Fact]
        public void Calc()
        {
            // Arrange
            Impure sut = new Impure();

            Order order = new Order();
            order.OrderLines.Add(
                new OrderLine
                {
                    Quantity = 0,
                    Product = new Product
                    {
                        Price = 2019
                    }
                });
            order.OrderLines.Add(
                new OrderLine
                {
                    Quantity = 1,
                    Product = new Product
                    {
                        Price = 1
                    }
                });
            order.OrderLines.Add(
                new OrderLine
                {
                    Quantity = 2,
                    Product = new Product
                    {
                        Price = 2
                    }
                });

            List<OrderLine> linesToDelete = new List<OrderLine>();

            // Act
            decimal result = sut.RecomputeTotal(order, linesToDelete);

            // Assert
            result.Should().Be(5);
            linesToDelete.Count.Should().Be(1);
        }
    }
}
