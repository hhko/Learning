using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracer.Lib.Excpetion
{
    public class ExceptionMethod
    {
        public static void Static()
        {
            throw new ApplicationException("failed");
        }

        public void NonStatic()
        {
            throw new ApplicationException("failed");
        }

        public void FirstLevel()
        {
            SecondLevel();
        }

        private void SecondLevel()
        {
            DeeplyNested();
        }

        private void DeeplyNested()
        {
            throw new ApplicationException("failed");
        }

        public void DifferentExecutionPaths()
        {
            var myClass = new MyExceptionClass();
            myClass.Run(1);
            myClass.Run(0);
        }

        public void NoRethrow()
        {
            try
            {
                int y = 0;
                int x = 2020 / y;
            }
            catch
            {

            }
        }
    }

    public class MyExceptionClass
    { 
        public void Run(int inp)
        {
            int resp = 1 / inp;
        }
    }
}
