using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_02_RecursiveGenerics.Solved
{
    public class EmployeeInfoBuilder<T> :
        EmployeeBuilder 
        where T : EmployeeInfoBuilder<T>
    {
        public T SetName(string name)
        {
            employee.Name = name;
            return (T)this;
        }
    }
}
