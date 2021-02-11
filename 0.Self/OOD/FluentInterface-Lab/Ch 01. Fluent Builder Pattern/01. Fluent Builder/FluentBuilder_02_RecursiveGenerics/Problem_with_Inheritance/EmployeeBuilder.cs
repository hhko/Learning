using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_02_RecursiveGenerics.Problem_with_Inheritance
{
    public class EmployeeBuilder
    {
        protected Employee employee;

        public EmployeeBuilder()
            => employee = new Employee();

        public Employee Build()
            => employee;
    }
}
