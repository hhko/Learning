using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootNamespace
{
    public class MyRepository
    {
        // 추적 대상이다.
        public int GetBy(string name)
        {
            return 2020;
        }

        // 추적 제외 대상이다.
        public int GetByUserId(int id)
        {
            return 2020;
        }
    }
}
