using System;
using System.Collections.Generic;
using System.Text;

namespace Step03_RunWithoutVS
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            //// 단위 테스트 성공
            return a + b;

            //// 단위 테스트 실패
            //return a - b;
        }
    }
}
