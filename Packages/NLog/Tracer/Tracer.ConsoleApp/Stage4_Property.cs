using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Property;

namespace Tracer.ConsoleApp
{
    public class Stage4_Property
    {
        public static void Execute()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("           4. 속성 추적 로그");
            Console.WriteLine("==============================================");

            //
            // Property - get
            //
            PropertyMethod propertyMethod = new PropertyMethod();
            int x1 = propertyMethod.IntValueGet;
            Console.WriteLine();
            //TRACE Tracer.Lib.Property.PropertyMethod Entered into get_IntValueGet().
            //TRACE Tracer.Lib.Property.PropertyMethod Returned from get_IntValueGet()($return= 1). Time taken: 0.00 ms.

            //
            // Property - set
            //
            propertyMethod.IntValueSet = 2020;
            Console.WriteLine();
            //TRACE Tracer.Lib.Property.PropertyMethod Entered into set_IntValueSet(Int32) (value = 2020).
            //TRACE Tracer.Lib.Property.PropertyMethod Returned from set_IntValueSet(Int32)().Time taken: 0.00 ms.

            //
            // Property 추적 제외
            //
            // FodyWeavers.xml 파일에서 traceProperties="false"으로 지정한다.
        }
    }
}
