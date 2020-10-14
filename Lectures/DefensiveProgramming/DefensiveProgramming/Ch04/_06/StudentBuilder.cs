using Ch02._06.Implementation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ch02._06
{
    public class StudentBuilder
    {
        public bool CanBuild()
        {
            // 복잡한 유효성 검사 조건

            return true;
        }

        public IStudent Build()
        {
            return null; 
        }
    }
}
