using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Http;
using Serilog.Sinks.Http.BatchFormatters;
using System;
using System.IO;
using System.Threading;

namespace Step_041_HttpDiagnostics
{
    class Program
    {
        static void Main(string[] args)
        {
            //
            // 예외 타입 : System.Net.Http.HttpRequestException
            //
            // 2021 - 02 - 24T02: 06:36.8133610Z Exception while emitting periodic batch from Serilog.Sinks.Http.Private.Sinks.HttpSink: System.Net.Http.HttpRequestException: 연결된 구성원으로부터 응답이 없어 연결하지 못했거나, 호스트로부터 응답이 없어 연결이 끊어졌습니다.
            //  ---> System.Net.Sockets.SocketException (10060): 연결된 구성원으로부터 응답이 없어 연결하지 못했거나, 호스트로부터 응답이 없어 연결이 끊어졌습니다.
            //    at System.Net.Http.ConnectHelper.ConnectAsync(String host, Int32 port, CancellationToken cancellationToken)
            //    ---End of inner exception stack trace ---
            //    at System.Net.Http.ConnectHelper.ConnectAsync(String host, Int32 port, CancellationToken cancellationToken)
            //    at System.Net.Http.HttpConnectionPool.ConnectAsync(HttpRequestMessage request, Boolean allowHttp2, CancellationToken cancellationToken)
            //    at System.Net.Http.HttpConnectionPool.CreateHttp11ConnectionAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            //    at System.Net.Http.HttpConnectionPool.GetHttpConnectionAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            //    at System.Net.Http.HttpConnectionPool.SendWithRetryAsync(HttpRequestMessage request, Boolean doRequestAuth, CancellationToken cancellationToken)
            //    at System.Net.Http.RedirectHandler.SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            //    at System.Net.Http.HttpClient.FinishSendAsyncBuffered(Task`1 sendTask, HttpRequestMessage request, CancellationTokenSource cts, Boolean disposeCts)
            //    at Serilog.Sinks.Http.Private.Sinks.HttpSink.EmitBatchAsync(IEnumerable`1 logEvents)
            //    at Serilog.Sinks.PeriodicBatching.PeriodicBatchingSink.OnTick()
            //

            //
            // SelfLog.Enable을 여러번 호출하면 마지막 호출만 적용된다.
            //

            // Serilog 내부 예외 발생을 파일에 출력한다.
            // "./Logs/" 폴더는 미리 생성되어 있어야 한다(폴더가 존재하지 않으면 예외가 발생한다).
            Directory.CreateDirectory("./Logs");
            SelfLog.Enable(
                TextWriter.Synchronized(
                    File.CreateText("./Logs/Serilog.log")));

            // Serilog 내부 예외 발생을 콘솔에 출력한다.
            SelfLog.Enable(Console.Error);

            Log.Logger = new LoggerConfiguration()
                            .MinimumLevel.Verbose()
                            .WriteTo.Http(
                
                                //
                                // Logstash URL
                                //
                                requestUri: "http://192.168.70.99:7701",
                                batchFormatter: new ArrayBatchFormatter(ByteSize.GB))
                            .WriteTo.Console()
                            .CreateLogger();

            for (int i = 0; i < 10; i++)
            {
                Log.Information("Hello World > {Number}", i);

                Thread.Sleep(1000);
            }

            Log.CloseAndFlush();
        }
    }
}


