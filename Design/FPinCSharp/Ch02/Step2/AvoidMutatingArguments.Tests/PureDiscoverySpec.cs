using AvoidMutatingArguments.Stage2;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AvoidMutatingArguments.Tests
{
    public class PureDiscoverySpec
    {
        [Fact]
        public void Calc()
        {
            // Arrange
            PureDiscovery sut = new PureDiscovery();

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

            // Act
            (var result, var linesToDelete) = sut.RecomputeTotal(order);

            // Assert
            result.Should().Be(5);
            linesToDelete.Count().Should().Be(1);
        }
    }
}
