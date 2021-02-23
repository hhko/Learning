using Serilog;
using Serilog.Exceptions;
using Serilog.Sinks.Http;
using Serilog.Sinks.Http.BatchFormatters;
using System;
using System.Threading;

namespace Step_040_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()

                            //
                            // 출력 형식을 Json 형식으로 지정한다.
                            //
                            .Enrich.WithExceptionDetails()
                            .WriteTo.Http(
                                requestUri: "http://192.168.70.23:7701",
                                batchFormatter: new ArrayBatchFormatter(ByteSize.GB))
                            .WriteTo.Console()
                            .CreateLogger();

            try
            {
                throw new DivideByZeroException("예외 로그 발생하기");
            }
            catch (Exception exception)
            {
                //
                // 적용 전
                // Exception : 	System.DivideByZeroException: 예외 로그 발생하기
                //                at ...(프로세스명)... .Program.Main(String[] args) in C:\ ... \Program.cs:line 25
                //  
                //   vs.
                //
                // 적용 후 : ExceptionDetail Key을 만든다.
                // Exception : 	System.DivideByZeroException: 예외 로그 발생하기
                //                at ...(프로세스명)... .Program.Main(String[] args) in C:\ ... \Program.cs:line 25
                // Properties.ExceptionDetail.HResult  : - 2147352558
                // Properties.ExceptionDetail.Message  : 예외 로그 발생하기
                // Properties.ExceptionDetail.Source   : Step_040_Exception
                // Properties.ExceptionDetail.Type     : System.DivideByZeroException
                //
                Log.Error(exception, "Hello World");
            }

            Log.CloseAndFlush();
        }
    }
}


