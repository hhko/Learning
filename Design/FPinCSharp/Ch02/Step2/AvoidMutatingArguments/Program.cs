using AvoidMutatingArguments.Stage1;
using AvoidMutatingArguments.Stage2;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvoidMutatingArguments
{
    class Program
    {
        static void Main(string[] args)
        {
            Impure impure = new Impure();

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

            // 불순 함수
            List<OrderLine> linesToDelete = new List<OrderLine>();
            decimal result = impure.RecomputeTotal(order, linesToDelete);

            Console.WriteLine("Impure(RecomputeTotal) : Mutating Arguments");
            Console.WriteLine($"\t Result : {result}");
            Console.WriteLine($"\t Lines to Delete : {linesToDelete.Count} count");

            // 순수 함수
            PureDiscovery up1Linq = new PureDiscovery();
            (var up1Result, var up1List) = up1Linq.RecomputeTotal(order);

            Console.WriteLine("Pure(RecomputeTotal) : Avoid Mutating Arguments");
            Console.WriteLine($"\t Result : {up1Result}");
            Console.WriteLine($"\t Lines to Delete : {up1List.Count()} count");
        }
    }
}
