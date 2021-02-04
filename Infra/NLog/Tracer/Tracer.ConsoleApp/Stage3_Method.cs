using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib;
using Tracer.Lib.Method;

namespace Tracer.ConsoleApp
{
    public class Stage3_Method
    {
        public static void Execute()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("           3. 메서드 추적 로그");
            Console.WriteLine("==============================================");

            #region 입/출력
            //
            // 입출력 모두가 없을 때
            // 
            ArgsNoReturnNo argsNoReturnNo = new ArgsNoReturnNo();
            argsNoReturnNo.CallMe();
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsNoReturnNo Entered into CallMe().
            //TRACE Tracer.Lib.Method.ArgsNoReturnNo Returned from CallMe() (). Time taken: 0.00 ms.

            //
            // 입출력이 모두 있을 때
            //
            ArgsReturn argsReturn = new ArgsReturn();
            argsReturn.CallMe(2019);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsReturn Entered into CallMe(Int32) (value=2019).
            //TRACE Tracer.Lib.Method.ArgsReturn Returned from CallMe(Int32) ($return=2020). Time taken: 0.00 ms.

            //
            // 입력 추적 제외
            //
            argsReturn.CallMeNoTraceArgs(2019);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsReturn Entered into CallMeNoTraceArgs(Int32).
            //TRACE Tracer.Lib.Method.ArgsReturn Returned from CallMeNoTraceArgs(Int32) ($return=2020). Time taken: 0.00 ms.

            //
            // 출력 추적 제외
            //
            argsReturn.CallMeNoTraceReturn(2019);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsReturn Entered into CallMeNoTraceReturn(Int32) (value=2019).
            //TRACE Tracer.Lib.Method.ArgsReturn Returned from CallMeNoTraceReturn(Int32) (). Time taken: 0.00 ms.

            //
            // 입/출력 추적 제외
            //
            argsReturn.CallMeNoTraceArgsAndReturn(2019);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsReturn Entered into CallMeNoTraceArgsAndReturn(Int32).
            //TRACE Tracer.Lib.Method.ArgsReturn Returned from CallMeNoTraceArgsAndReturn(Int32) (). Time taken: 0.00 ms.
            #endregion

            #region 출력
            //
            // 출력 - string
            // 
            ArgsNoReturn argsNoReturn = new ArgsNoReturn();
            string value1 = argsNoReturn.CallMe();
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsNoReturn Entered into CallMe().
            //TRACE Tracer.Lib.Method.ArgsNoReturn Returned from CallMe() ($return=response). Time taken: 0.00 ms.

            //
            // 출력 - struct
            // 
            MyStruct value2 = argsNoReturn.CallMeStruct();
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsNoReturn Entered into CallMeStruct().
            //TRACE Tracer.Lib.Method.ArgsNoReturn Returned from CallMeStruct() ($return=Tracer.Lib.MyStruct). Time taken: 0.06 ms.

            //
            // 출력 - class
            // 
            MyClass value3 = argsNoReturn.CallMeClass();
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsNoReturn Entered into CallMeClass().
            //TRACE Tracer.Lib.Method.ArgsNoReturn Returned from CallMeClass() ($return=Tracer.Lib.MyClass). Time taken: 0.10 ms.

            //
            // 출력 - T
            // 
            Foo value4 = argsNoReturn.CallaMeGeneric<Foo>();
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsNoReturn Entered into CallaMeGeneric().
            //TRACE Tracer.Lib.Method.ArgsNoReturn Returned from CallaMeGeneric() ($return=Tracer.Lib.Foo). Time taken: 0.08 ms.

            //
            // 출력 추적 제외
            //
            MyClass value5 = argsNoReturn.CallMeClassNoTrace();
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsNoReturn Entered into CallMeClassNoTrace().
            //TRACE Tracer.Lib.Method.ArgsNoReturn Returned from CallMeClassNoTrace() (). Time taken: 0.00 ms.
            #endregion

            #region 입력 - ref
            ArgsRef argsRef = new ArgsRef();

            //
            // ref 인자 - int
            //
            int inp2 = 42;
            argsRef.CallMe(ref inp2);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsRef Entered into CallMe(Int32&) (param=42).
            //TRACE Tracer.Lib.Method.ArgsRef Returned from CallMe(Int32&) (param=24). Time taken: 0.00 ms.

            //
            // ref 인자 - string
            //
            string inp1 = "goinIn";
            argsRef.CallMe(ref inp1);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsRef Entered into CallMe(String&) (param=goinIn).
            //TRACE Tracer.Lib.Method.ArgsRef Returned from CallMe(String&) (param=goinOut). Time taken: 0.00 ms.

            //
            // ref 인자 - struct
            //
            MyStruct inp3 = new MyStruct() { IntVal = 42 };
            argsRef.CallMe(ref inp3);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsRef Entered into CallMe(MyStruct&) (param=Tracer.Lib.MyStruct).
            //TRACE Tracer.Lib.Method.ArgsRef Returned from CallMe(MyStruct&) (param=Tracer.Lib.MyStruct). Time taken: 0.00 ms.

            //
            // ref 인자 - class
            //
            MyClass inp4 = new MyClass() { IntVal = 42 };
            argsRef.CallMe(ref inp4);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsRef Entered into CallMe(MyClass&) (param=Tracer.Lib.MyClass).
            //TRACE Tracer.Lib.Method.ArgsRef Returned from CallMe(MyClass&) (param=Tracer.Lib.MyClass). Time taken: 0.00 ms.
            #endregion

            #region 입력 - out
            ArgsOut argsOut = new ArgsOut();

            //
            // out 인자 - int
            // 
            int outInt;
            argsOut.CallMe(out outInt);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsOut Entered into CallMe(out Int32&).
            //TRACE Tracer.Lib.Method.ArgsOut Returned from CallMe(out Int32&) ($return=response, param=42). Time taken: 0.00 ms.

            //
            // out 인자 - string
            // 
            string outString;
            argsOut.CallMe(out outString);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsOut Entered into CallMe(out String&).
            //TRACE Tracer.Lib.Method.ArgsOut Returned from CallMe(out String&) ($return=response, param=rv). Time taken: 0.00 ms.

            //
            // out 인자 - struct
            // 
            MyStruct outStruct;
            argsOut.CallMe(out outStruct);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsOut Entered into CallMe(out MyStruct&).
            //TRACE Tracer.Lib.Method.ArgsOut Returned from CallMe(out MyStruct&) (param=Tracer.Lib.MyStruct). Time taken: 0.00 ms.

            //
            // out 인자 - class
            // 
            MyClass outClass;
            argsOut.CallMe(out outClass);
            Console.WriteLine();
            //TRACE Tracer.Lib.Method.ArgsOut Entered into CallMe(out MyClass&).
            //TRACE Tracer.Lib.Method.ArgsOut Returned from CallMe(out MyClass&) (param=Tracer.Lib.MyClass). Time taken: 0.00 ms.
            #endregion
        }
    }
}
