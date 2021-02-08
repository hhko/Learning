using System;
using System.Collections.Generic;
using System.Text;

namespace Null_03_Tutorials
{
    public class AddressNull : IAddress
    {
        public string Country
        {
            get
            {
                //
                // 해결: Null일 때 기본값을 직접 지정할 수 있다(Null Object Pattern).
                //    (string 기본값은 null이다.)
                //
                return "Korean";
            }
        }
    }
}
