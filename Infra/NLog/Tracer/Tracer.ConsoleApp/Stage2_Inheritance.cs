using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib.Inheritance;

namespace Tracer.ConsoleApp
{
    public class Stage2_Inheritance
    {
        public static void Execute()
        {
            Console.WriteLine("==============================================");
            Console.WriteLine("           2. 상속 생성자 추적 로그");
            Console.WriteLine("==============================================");

            //
            // 클래스 상속
            //
            ClassType classDerivedType = new DerivedType1_Class();
            Console.WriteLine();
            //TRACE Tracer.Lib.Inheritance.DerivedType1_Class Entered into .ctor().
            //TRACE Tracer.Lib.Inheritance.ClassType Entered into .ctor().
            //TRACE Tracer.Lib.Inheritance.ClassType Returned from .ctor() (). Time taken: 0.00 ms.
            //TRACE Tracer.Lib.Inheritance.DerivedType1_Class Returned from .ctor() (). Time taken: 0.52 ms.

            //
            // 추상 클래스 상속
            //
            AbstractType abstractDerivedType = new DerivedType2_Abstract();
            Console.WriteLine();
            //TRACE Tracer.Lib.Inheritance.DerivedType2_Abstract Entered into .ctor().
            //TRACE Tracer.Lib.Inheritance.DerivedType2_Abstract Returned from .ctor() (). Time taken: 0.08 ms.

            //
            // 인터페이스 상속
            //
            InterfaceType interfaceDerivedType = new DerivedType3_Interface();
            Console.WriteLine();
            //TRACE Tracer.Lib.Inheritance.DerivedType3_Interface Entered into .ctor().
            //TRACE Tracer.Lib.Inheritance.DerivedType3_Interface Returned from .ctor() (). Time taken: 0.00 ms.

            Console.WriteLine();
        }
    }
}
