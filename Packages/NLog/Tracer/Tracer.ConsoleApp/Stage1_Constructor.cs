using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib;
using Tracer.Lib.Constructor;

namespace Tracer.ConsoleApp
{
    public class Stage1_Constructor
    {
        public static void Execute()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("           1. 생성자 추적 로그");
            Console.WriteLine("==============================================");

            //
            // 암시적 기본 생성자
            //
            SimpleType1_Implicit simpleType1_Implicit = new SimpleType1_Implicit();
            Console.WriteLine();
            //TRACE Tracer.Lib.Constructor.SimpleType1_Implicit Entered into .ctor().
            //TRACE Tracer.Lib.Constructor.SimpleType1_Implicit Returned from .ctor() (). Time taken: 0.00 ms.

            //
            // 명시적 기본 생성자
            //
            SimpleType2_Explicit simpleType2_Explicit = new SimpleType2_Explicit();
            Console.WriteLine();
            //TRACE Tracer.Lib.Constructor.SimpleType2_Explicit Entered into .ctor().
            //TRACE Tracer.Lib.Constructor.SimpleType2_Explicit Returned from .ctor() (). Time taken: 0.00 ms.

            //
            // 인자 추적
            //
            SimpleType3_Args simpleType3_Args = new SimpleType3_Args(2020, new List<int> { 1, 2, 3 });
            Console.WriteLine();
            //TRACE Tracer.Lib.Constructor.SimpleType3_Args Entered into .ctor(Int32, List`1)(x = 2020, values = System.Collections.Generic.List`1[System.Int32]).
            //TRACE Tracer.Lib.Constructor.SimpleType3_Args Returned from .ctor(Int32, List`1)().Time taken: 0.00 ms.

            //
            // 인자 추적 제외
            //
            SimpleType4_NoTraceArgs simpleType4_NoTraceArgs = new SimpleType4_NoTraceArgs(2020, new List<int> { 1, 2, 3 });
            Console.WriteLine();
            //TRACE Tracer.Lib.Constructor.SimpleType4_NoTraceArgs Entered into .ctor(Int32, List`1).
            //TRACE Tracer.Lib.Constructor.SimpleType4_NoTraceArgs Returned from .ctor(Int32, List`1)().Time taken: 0.00 ms.

            //
            // 생성자 추적 제외
            //
            SimpleType5_NoTraceCtor simpleType5_NoTraceCtor = new SimpleType5_NoTraceCtor(2020, new List<int> { 1, 2, 3 });
            // 추적 로그가 없다.

            //
            // 클래스 추적 제외
            //
            SimpleType6_NoTrace simpleType6_NoTrace = new SimpleType6_NoTrace(2020, new List<int> { 1, 2, 3 });
            // 추적 로그가 없다.

            //
            // 중첩
            //
            FirstLevel.SecondLevel.DeeplyNested deeplyNested = new FirstLevel.SecondLevel.DeeplyNested();
            Console.WriteLine();
            //TRACE Tracer.Lib.Constructor.FirstLevel + SecondLevel + DeeplyNested Entered into .ctor().
            //TRACE Tracer.Lib.Constructor.FirstLevel + SecondLevel + DeeplyNested Returned from .ctor() (). Time taken: 0.00 ms.

            //
            // T 
            //
            GenericType<Foo> genericType = new GenericType<Foo>();
            Console.WriteLine();
            //TRACE Tracer.Lib.Constructor.GenericType`1[Tracer.Lib.Foo] Entered into .ctor().
            //TRACE Tracer.Lib.Constructor.GenericType`1[Tracer.Lib.Foo] Returned from .ctor() (). Time taken: 0.00 ms.

            //
            // 생성자 추적 제외
            //
            // FodyWeavers.xml 파일에서 traceConstructors="false"으로 지정한다.

            Console.WriteLine();
        }
    }
}
