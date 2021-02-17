
using FluentBuilder_02_RecursiveGenerics.Solved;
using System;

namespace FluentBuilder_02_RecursiveGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // Problem with Fluent Builder Inheritance
            //
            //EmployeeInfoBuilder employeeBuilder = new EmployeeInfoBuilder();
            //
            //employeeBuilder
            //    .SetName("Nick")
            //    .AtPosition("Software Developer");    // <- Compile-Time Error
            //


            //
            // Fluent Builder Interface With Recursive Generics
            //
            Employee employee = EmployeeBuilderDirector
                .NewEmployee
                .SetName("Maks")    // 리턴 타입: 자신 + 자식(T) 
                .AtPosition("Software Programmer")
                .WithSalary(3500)
                .Build();

            Console.WriteLine(employee);
        }
    }
}
