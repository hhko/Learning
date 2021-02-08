using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_02_RecursiveGenerics.Solved
{
    public class EmployeeSalaryBuilder<T> :
        EmployeePositionBuilder<EmployeeSalaryBuilder<T>>
        where T : EmployeeSalaryBuilder<T>
    {
        public T WithSalary(double salary)
        {
            employee.Salary = salary;
            return (T)this;
        }
    }
}
