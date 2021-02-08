using System;
using System.Collections.Generic;
using System.Text;

namespace FluentBuilder_02_RecursiveGenerics.Solved
{
    // 
    // 최하위 자식 클래스 : xxxDirector
    //
    public class EmployeeBuilderDirector : EmployeeSalaryBuilder<EmployeeBuilderDirector>
    {
        public static EmployeeBuilderDirector NewEmployee => new EmployeeBuilderDirector();
    }
}
