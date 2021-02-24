using Serilog;
using Serilog.Sinks.Http.BatchFormatters;
using Serilog.Sinks.Http.TextFormatters;
using System;
using System.Threading;

namespace Step_039_NamespacedTextFormatter
{
    public class Formatter : NamespacedTextFormatter
    {
        public Formatter(string component, string subComponent)
            : base(component, subComponent)
        {
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            
                            .WriteTo.Http(
                                requestUri: "http://192.168.70.23:7701",

                                // "component : MainComponent, subCompoent : SubCompoent"일 때
                                //    > Properties.MainComponent.SubCompoent. ...(사용자 정의 속성)...
                                // "component : MainComponent, subCompoent : NULL"일 때(subComponent은 생략(NULL) 가능하다.)
                                //    > Properties.MainComponent. ...(사용자 정의 속성)...
                                textFormatter: new Formatter("MainComponent", "SubCompoent"),
                                batchFormatter: new ArrayBatchFormatter())
                            .WriteTo.Console()
                            .CreateLogger();

            for (int i = 0; i < 10; i++)
            {
                //
                // Properties.MainComponent.SubCompoent.Number
                //
                Log.Information("Hello World > {Number}", i);

                //
                // Properties.MainComponent.SubCompoent.Customer.FirstName
                // Properties.MainComponent.SubCompoent.Customer.SocialSecurityNumber
                // Properties.MainComponent.SubCompoent.Customer.Surname
                // Properties.MainComponent.SubCompoent.Customer._typeTag
                //
                Log.Information("{@Customer}", new Customer
                {
                    FirstName = $"{i} - FirstName",
                    Surname = $"{i} - Surname",
                    SocialSecurityNumber = $"{i} - SocialSecurityNumber",
                });

                Thread.Sleep(1000);
            }

            Log.CloseAndFlush();
        }
    }

    public class Customer
    {
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string SocialSecurityNumber { get; set; }
    }
}
