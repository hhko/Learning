using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Json;
using System;

namespace Step_019_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()

                                //
                                // 출력 형식을 Json 형식으로 지정한다.
                                //
                                .Enrich.WithExceptionDetails()

                                .WriteTo.Console(formatter: new JsonFormatter())
                                .WriteTo.File(path: "./Logs/LogFile.json", formatter: new JsonFormatter())
                                .CreateLogger();

            try
            {
                throw new DivideByZeroException("예외 로그 발생하기");
            }
            catch (Exception exception)
            {
                //
                // 적용 전
                // {
                //     "Timestamp": "2021-02-23T15:00:27.8833067+09:00",
                //     "Level": "Error",
                //     "MessageTemplate": "Hello World",
                //     "Exception": "System.DivideByZeroException: 예외 로그 발생하기\r\n   at ...(네임스페이스)... .Program.Main(String[] args) in C:\\ ... \\Program.cs:line 25"
                // }
                //
                //   vs.
                //
                // 적용 후 : ExceptionDetail Key을 만든다.
                // {
                //     "Timestamp": "2021-02-23T14:53:57.3270065+09:00",
                //     "Level": "Error",                                    <-- 로그 수준
                //     "MessageTemplate": "Hello World",                    <-- 로그 메시지 템플릿
                //     "Exception": "System.DivideByZeroException: 예외 로그 발생하기\r\n   at ...(네임스페이스)... .Program.Main(String[] args) in C:\\ ... \\Program.cs:line 25",
                //     "Properties": {
                //         "ExceptionDetail": {
                //             "Type": "System.DivideByZeroException",       <-- 예외 타입
                //             "HResult": -2147352558,
                //             "Message": "예외 로그 발생하기",               <-- 예외 메시지
                //             "Source": "Step_018_Exception"                <-- 프로세스 이름
                //         }
                //     }
                // }
                Log.Error(exception, "Hello World");
            }

            Log.CloseAndFlush();
        }
    }
}



