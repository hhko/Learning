using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._01
{
    public class Demo
    {
        public static void DoSomething(Grade grade)
        {
            Grade passed = Grade.B;
            Grade failedMiserably = (Grade)(-270);

            // 불필요한 코드이다
            if (!Enum.IsDefined(typeof(Grade), grade))
            {
                throw new ArgumentException();
            }
            else
            {
                // 불필요한 분기문
            }

            if (Grade.A > Grade.B)
            {

            }
        }
    }
}
