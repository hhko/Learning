using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_02_RecursiveGenerics.Solved
{
    public class EmployeePositionBuilder<T> :
        EmployeeInfoBuilder<EmployeePositionBuilder<T>>
        where T : EmployeePositionBuilder<T>
    {
        public T AtPosition(string position)
        {
            employee.Position = position;
            return (T)this;
        }
    }
}
