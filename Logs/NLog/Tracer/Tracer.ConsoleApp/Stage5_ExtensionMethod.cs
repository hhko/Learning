using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib;
using Tracer.Lib.ExtensionMethod;

namespace Tracer.ConsoleApp
{
    public class Stage5_ExtensionMethod
    {
        public static void Execute()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("           5. 확장 메서드 추적 로그");
            Console.WriteLine("==============================================");

            //
            // int 
            //
            2019.Do(1);
            Console.WriteLine();
            //TRACE Tracer.Lib.ExtensionMethod.Extension1_Int Entered into Do(Int32, Int32) (self = 2019, value = 1).
            //TRACE Tracer.Lib.ExtensionMethod.Extension1_Int Returned from Do(Int32, Int32)($return= 2020). Time taken: 0.00 ms.

            //
            // string
            //
            "2019".Do("1");
            Console.WriteLine();
            //TRACE Tracer.Lib.ExtensionMethod.Extension2_String Entered into Do(String, String) (self = 2019, value = 1).
            //TRACE Tracer.Lib.ExtensionMethod.Extension2_String Returned from Do(String, String)($return= 2020). Time taken: 0.00 ms.

            //
            // struct
            //
            MyStruct myStruct = new MyStruct { IntVal = 2019 };
            myStruct.Do(1);
            Console.WriteLine();
            //TRACE Tracer.Lib.ExtensionMethod.Extension3_Struct Entered into Do(MyStruct, Int32) (self = Tracer.Lib.MyStruct, value = 1).
            //TRACE Tracer.Lib.ExtensionMethod.Extension3_Struct Returned from Do(MyStruct, Int32)($return= 2). Time taken: 0.00 ms.


            //
            // class
            //
            MyClass myClass = new MyClass { IntVal = 2019 };
            myClass.Do(1);
            Console.WriteLine();
            //TRACE Tracer.Lib.ExtensionMethod.Extension4_Class Entered into Do(MyClass, Int32) (self = Tracer.Lib.MyClass, value = 1).
            //TRACE Tracer.Lib.ExtensionMethod.Extension4_Class Returned from Do(MyClass, Int32)($return= 2). Time taken: 0.00 ms.

            //
            // T - struct
            //
            2019.10.DoStruct(1);
            Console.WriteLine();
            //TRACE Tracer.Lib.ExtensionMethod.Extension5_Generic Entered into DoStruct(T, Int32) (self = 2019.1, value = 1).
            //TRACE Tracer.Lib.ExtensionMethod.Extension5_Generic Returned from DoStruct(T, Int32)($return= 2). Time taken: 0.00 ms.

            //
            // T - class
            //
            myClass.DoClass(1);
            Console.WriteLine();
            //TRACE Tracer.Lib.ExtensionMethod.Extension5_Generic Entered into DoClass(T, Int32) (self = Tracer.Lib.MyClass, value = 1).
            //TRACE Tracer.Lib.ExtensionMethod.Extension5_Generic Returned from DoClass(T, Int32)($return= 2). Time taken: 0.00 ms.
        }
    }
}
