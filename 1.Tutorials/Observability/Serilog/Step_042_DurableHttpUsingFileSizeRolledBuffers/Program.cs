using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Http;
using Serilog.Sinks.Http.BatchFormatters;
using System;
using System.Threading;

namespace Step_042_DurableHttpUsingFileSizeRolledBuffers
{
    class Program
    {
        static void Main(string[] args)
        {
            SelfLog.Enable(Console.Error);

            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()

                            //
                            // 무조건 파일에 기록한다.
                            // Buffer-20210224.json         // 데이터 파일
                            // Buffer.bookmark              // 부가 정보 파일
                            //   3603:::C:\ ... \Buffer-20210224.json
                            //   nextLineBeginsAtOffset ::: currentFile
                            //
                            // @timestamp           : 2021-02-24 @ 11:25:26   <- Elsticsearh에 기록된 시간?
                            // @timestamp_collect   : 2021-02-24 @ 11:25:26
                            // Timestamp            : 2021-02-24 @ 11:23:06   <- 로컬에 기록된 시간
                            // @version             : 1
                            //
                            .WriteTo.DurableHttpUsingFileSizeRolledBuffers(
                                requestUri: "http://192.168.70.23:7701",
                                batchFormatter: new ArrayBatchFormatter(ByteSize.GB))
                            .WriteTo.Console()
                            .CreateLogger();

            for (int i = 0; i < 3; i++)
            {
                Log.Information("Hello World {Number}", i);

                Thread.Sleep(1000);
            }

            Log.CloseAndFlush();
        }
    }
}



