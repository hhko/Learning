using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_02_RecursiveGenerics.Problem_with_Inheritance
{
    public class EmployeePositionBuilder : EmployeeInfoBuilder
    {
        public EmployeePositionBuilder AtPosition(string position)
        {
            employee.Position = position;
            return this;
        }
    }
}
