using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_02_RecursiveGenerics.Problem_with_Inheritance
{
    public class EmployeeInfoBuilder
    {
        protected Employee employee = new Employee();

        public EmployeeInfoBuilder SetName(string name)
        {
            employee.Name = name;
            return this;
        }
    }
}
