using Serilog;
using Serilog.Debugging;
using System;

namespace Step_060_WriteToNotepad
{
    class Program
    {
        static void Main(string[] args)
        {
            SelfLog.Enable(s => Console.WriteLine($"Internal Error with Serilog: {s}"));

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()

                //
                // 대상 : 가장 최근에 실행된 Notepad에 로그를 출력한다.
                // 구현 : 
                // private static Process TryFindMostRecentNotepadProcess()
                // {
                //     var mostRecentNotepadProcess = Process.GetProcessesByName("notepad") <-- notepad 프로세스
                //         .Where(p => !p.HasExited)
                //         .OrderByDescending(p => p.StartTime)                             <-- 가장 최근 실행된 프로세스
                //         .FirstOrDefault();
                // 
                //     return mostRecentNotepadProcess;
                // }
                //
                .WriteTo.Notepad()
                .CreateLogger();

            Console.WriteLine("Open a `notepad.exe` instance and press <enter> to continue...");
            Console.ReadLine();

            Log.Information("Hello World");

            try
            {
                throw new DivideByZeroException("예외 발생하기");
            }
            catch (DivideByZeroException exp)
            {
                Log.Error(exp, "Oops... Something went wrong");
            }

            Log.CloseAndFlush();
        }
    }
}


