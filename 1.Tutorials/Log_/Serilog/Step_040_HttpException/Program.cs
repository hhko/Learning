using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using Serilog.Sinks.Http;
using Serilog.Sinks.Http.BatchFormatters;
using System;
using System.Threading;
using System.Threading.Tasks;

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
                            .WriteTo.Console(formatter: new JsonFormatter())
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

            try
            {
                Task.WhenAll(
                        Task.Run(() => { throw new DivideByZeroException("Task1 예외 로그 발생하기"); }),
                        Task.Run(() => { throw new NullReferenceException("Task2 예외 로그 발생하기"); }))
                    .Wait();
            }

            //
            // Task 예외는 반드시 AggregateException으로 catch하여 개별 로그를 생성해야 한다.
            //
            catch (AggregateException ae)
            {
                //
                // 적용 전 : 로그 1개
                // Properties.ExceptionDetail.InnerExceptions           : { }, { }, ... N개(InnerExceptions 개수)
                // Properties.ExceptionDetail.InnerExceptions.HResult
                // Properties.ExceptionDetail.InnerExceptions.Message
                // Properties.ExceptionDetail.InnerExceptions.Source 
                // Properties.ExceptionDetail.InnerExceptions.Type   
                //
                //   vs.
                //
                // 적용 후 : 로그 N개(InnerExceptions 개수)
                // 1. Properties.ExceptionDetail.HResult
                //    Properties.ExceptionDetail.Message
                //    Properties.ExceptionDetail.Source 
                //    Properties.ExceptionDetail.Type   
                // 2. Properties.ExceptionDetail.HResult
                //    ...
                //
                foreach (var e in ae.InnerExceptions)
                    Log.Error(e, "Hello World - Task");
            }

            Log.CloseAndFlush();
        }
    }
}


