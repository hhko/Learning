using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Excpetion;

namespace Tracer.ConsoleApp
{
    public class Stage7_Exception
    {
        public static void Execute()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("           7. 예외 추적 로그");
            Console.WriteLine("==============================================");

            //
            // Exception - 메서드
            //
            ExceptionMethod exceptionMethod = new ExceptionMethod();
            try
            {
                exceptionMethod.NonStatic();
            }
            catch { }
            Console.WriteLine();
            //TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into NonStatic().
            //TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from NonStatic() ($exception=System.ApplicationException: failed
            //   위치: Tracer.Lib.Excpetion.ExceptionMethod.NonStatic() 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Excpetion\ExceptionMethod.cs:줄 18). Time taken: 0.11 ms.

            //
            // Exception - 중첩 메서드 호출
            //
            try
            {
                exceptionMethod.FirstLevel();
            }
            catch { }
            Console.WriteLine();
            //TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into FirstLevel().
            //TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from FirstLevel() ($exception=System.ApplicationException: failed
            //   위치: Tracer.Lib.Excpetion.ExceptionMethod.DeeplyNested() 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Excpetion\ExceptionMethod.cs:줄 33
            //   위치: Tracer.Lib.Excpetion.ExceptionMethod.SecondLevel() 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Excpetion\ExceptionMethod.cs:줄 28
            //   위치: Tracer.Lib.Excpetion.ExceptionMethod.FirstLevel() 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Excpetion\ExceptionMethod.cs:줄 23). Time taken: 0.21 ms.

            //
            // Exception - 다른 객체의 메서드 호출
            //
            try
            {
                exceptionMethod.DifferentExecutionPaths();
            }
            catch { }
            Console.WriteLine();
            //TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into DifferentExecutionPaths().
            //TRACE Tracer.Lib.Excpetion.MyClass Entered into Run(Int32) (inp=1).
            //TRACE Tracer.Lib.Excpetion.MyClass Returned from Run(Int32) (). Time taken: 0.00 ms.
            //TRACE Tracer.Lib.Excpetion.MyClass Entered into Run(Int32) (inp=0).
            //TRACE Tracer.Lib.Excpetion.MyClass Returned from Run(Int32) ($exception=System.DivideByZeroException: 0으로 나누려 했습니다.
            //   위치: Tracer.Lib.Excpetion.MyClass.Run(Int32 inp) 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Excpetion\ExceptionMethod.cs:줄 61). Time taken: 0.09 ms.
            //TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from DifferentExecutionPaths() ($exception=System.DivideByZeroException: 0으로 나누려 했습니다.
            //   위치: Tracer.Lib.Excpetion.MyClass.Run(Int32 inp) 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Excpetion\ExceptionMethod.cs:줄 62
            //   위치: Tracer.Lib.Excpetion.ExceptionMethod.DifferentExecutionPaths() 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Excpetion\ExceptionMethod.cs:줄 40). Time taken: 1.98 ms.

            //
            // Exception - 명시적 catch에서 throw;하지 않을 때
            //
            //try
            //{
            exceptionMethod.NoRethrow();
            //}
            //catch { }
            Console.WriteLine();
            //TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into NoRethrow().
            //TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from NoRethrow() (). Time taken: 0.43 ms.

            //
            // Exception - 정적 메서드
            //
            try
            {
                ExceptionMethod.Static();
            }
            catch { }
            Console.WriteLine();
            //TRACE Tracer.Lib.Excpetion.ExceptionMethod Entered into Static().
            //TRACE Tracer.Lib.Excpetion.ExceptionMethod Returned from Static() ($exception=System.ApplicationException: failed
            //   위치: Tracer.Lib.Excpetion.ExceptionMethod.Static() 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Excpetion\ExceptionMethod.cs:줄 13). Time taken: 0.04 ms.
        }
    }
}
