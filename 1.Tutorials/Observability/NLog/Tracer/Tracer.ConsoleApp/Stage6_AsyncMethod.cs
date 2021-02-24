using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Async;

namespace Tracer.ConsoleApp
{
    public class Stage6_AsyncMethod
    {
        public static void Execute()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("           6. 비동기 메서드 추적 로그");
            Console.WriteLine("==============================================");

            AsyncMethod asyncMethod = new AsyncMethod();
            int x1 = asyncMethod.CallMeAsync(2019, "Hello2", 10).Result;
            Console.WriteLine();
            //TRACE Tracer.Lib.Async.AsyncMethod Entered into CallMeAsync(Int32, String, Int32) (param=2019, param2=Hello2, paraInt=10).
            //TRACE Tracer.Lib.Async.AsyncMethod Returned from CallMeAsync(Int32, String, Int32) ($return=20). Time taken: 50.60 ms.

            asyncMethod.CallMeReturnNodAsync("Hello1", "Hello2", 10).Wait();
            Console.WriteLine();
            //TRACE Tracer.Lib.Async.AsyncMethod Entered into CallMeReturnNodAsync(String, String, Int32) (param=Hello1, param2=Hello2, paraInt=10).
            //TRACE Tracer.Lib.Async.AsyncMethod Returned from CallMeReturnNodAsync(String, String, Int32) (). Time taken: 1.82 ms.

            int x2 = asyncMethod.CallMeOtherClass("Hello1", "Hello2", 10).Result;
            Console.WriteLine();
            //TRACE Tracer.Lib.Async.AsyncMethod Entered into CallMeOtherClass(String, String, Int32) (param=Hello1, param2=Hello2, paraInt=10).
            //TRACE Tracer.Lib.Async.OtherClass Entered into Double(Int32) (p=10).
            //TRACE Tracer.Lib.Async.OtherClass Returned from Double(Int32) ($return=20). Time taken: 2.05 ms.
            //TRACE Tracer.Lib.Async.AsyncMethod Returned from CallMeOtherClass(String, String, Int32) ($return=40). Time taken: 4.07 ms.

            int x3 = asyncMethod.CallMeGeneric(2019, "Hello", 10).Result;
            Console.WriteLine();
            //TRACE Tracer.Lib.Async.AsyncMethod Entered into CallMeGeneric(T, String, Int32) (param=2019, param2=Hello, paraInt=10).
            //TRACE Tracer.Lib.Async.AsyncMethod Returned from CallMeGeneric(T, String, Int32) ($return=20). Time taken: 0.90 ms.

            try
            {
                int x4 = asyncMethod.Throw(2019).Result;
            }
            catch { }
            Console.WriteLine();
            //TRACE Tracer.Lib.Async.AsyncMethod Entered into Throw(Int32) (p=2019).
            //TRACE Tracer.Lib.Async.AsyncMethod Returned from Throw(Int32) ($exception=System.ApplicationException: Err
            //   위치: Tracer.Lib.Async.AsyncMethod.ThrowException() 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Async\AsyncMethod.cs:줄 57
            //   위치: Tracer.Lib.Async.AsyncMethod.<Throw>b__8_0() 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Async\AsyncMethod.cs:줄 52
            //   위치: System.Threading.Tasks.Task`1.InnerInvoke()
            //   위치: System.Threading.Tasks.Task.Execute()
            //--- 예외가 throw된 이전 위치의 스택 추적 끝 ---
            //   위치: System.Runtime.CompilerServices.TaskAwaiter.ThrowForNonSuccess(Task task)
            //   위치: System.Runtime.CompilerServices.TaskAwaiter.HandleNonSuccessAndDebuggerNotification(Task task)
            //   위치: System.Runtime.CompilerServices.TaskAwaiter`1.GetResult()
            //   위치: Tracer.Lib.Async.AsyncMethod.<Throw>d__8.MoveNext() 파일 C:\Workspace\Repo\BLUE\PoC\Logger\Tracer\Tracer.Lib\Async\AsyncMethod.cs:줄 52). Time taken: 1.30 ms.
        }
    }
}
