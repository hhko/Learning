using NLog;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracer.Lib;
using Tracer.Lib.Constructor;
//using Tracer.Lib;

namespace Tracer.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            LogManager.Configuration = new XmlLoggingConfiguration(@"Configurations\App.NLog.config");

            // 생성자
            Stage1_Constructor.Execute();

            // 상속
            Stage2_Inheritance.Execute();

            // 메서드
            Stage3_Method.Execute();

            // 속성
            Stage4_Property.Execute();

            // 확장 메서드
            Stage5_ExtensionMethod.Execute();

            // 비동기 메서드
            Stage6_AsyncMethod.Execute();

            // 예외
            Stage7_Exception.Execute();

            LogManager.Shutdown();
        }
    }
}
