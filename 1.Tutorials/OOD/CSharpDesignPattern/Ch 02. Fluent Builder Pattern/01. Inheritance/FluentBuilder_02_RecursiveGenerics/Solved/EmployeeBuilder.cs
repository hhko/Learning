using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_02_RecursiveGenerics.Solved
{
    //
    // 최상위 부모 클래스
    //
    public abstract class EmployeeBuilder
    {
        protected Employee employee;

        public EmployeeBuilder() => employee = new Employee();

        public Employee Build() => employee;
    }
}
