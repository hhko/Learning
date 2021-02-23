using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.Http;
using Serilog.Sinks.Http.BatchFormatters;
using Serilog.Sinks.Http.TextFormatters;
using System;
using System.Threading;

namespace Step_038_SendLogstash
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .WriteTo.Http(
                                
                                //
                                // Logstash URL
                                //
                                requestUri: "http://192.168.70.23:7701",

                                //
                                // 형식 :  Properties. ...(사용자 정의 속성)...
                                //
                                // 전송 크기 : 기본 262144byte(256KB) Batch 크기
                                //   > 생성자에서 기본 크기를 변경할 수 있다.
                                //      예. new ArrayBatchFormatter(ByteSize.GB)
                                //   > Batch 크기 이상을 전달하면 해당 데이터는 전송하지 않는다.
                                //   > Serilog Internal 로그로 확인할 수 있다.
                                //      SelfLog.WriteLine(
                                //          "Event JSON representation exceeds the byte size limit of {0} set for this sink and will be dropped; data: {1}",
                                //          eventBodyLimitBytes,
                                //          json);
                                //   > ByteSize.B : 1
                                //   > ByteSize.KB : 1024
                                //   > ByteSize.MB : 1048576
                                //   > ByteSize.GB : 1073741824
                                batchFormatter: new ArrayBatchFormatter(ByteSize.GB))
                            .WriteTo.Console()
                            .CreateLogger();

            for (int i = 0; i < 10; i++)
            {
                // 
                // Properties.Number
                //
                Log.Information("Hello World > {Number}", i);

                //
                // Properties.Customer.FirstName
                // Properties.Customer.SocialSecurityNumber
                // Properties.Customer.Surname
                // Properties.Customer._typeTag
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
