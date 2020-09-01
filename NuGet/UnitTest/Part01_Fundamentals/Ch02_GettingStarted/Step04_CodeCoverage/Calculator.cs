using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Step04_CodeCoverage
{
    public class Calculator
    {
        [ExcludeFromCodeCoverage]
        public Calculator()
        {

        }

        public int Add(int x, int y)
        {
            //// 단위 테스트 성공
            return x + y;

            //// 단위 테스트 실패
            //return x - y;
        }

        [ExcludeFromCodeCoverage]
        public int Divide(int x, int y)
        {
            return x / y;
        }
    }
}
