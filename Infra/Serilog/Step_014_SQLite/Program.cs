using Serilog;
using System;

namespace Step_014_SQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            const string customTemplate = "Will be logged, This is a message {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            // CompactJsonFormatter 
            // RenderedCompactJsonFormatter
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File(
                                    path: "./Logs/LogFile.txt",
                                    outputTemplate: customTemplate,
                                    fileSizeLimitBytes: null,
                                    rollingInterval: RollingInterval.Day,
                                    retainedFileCountLimit: 2)
                                //.Destructure.ByTransforming<Color>(x => new { x.Red, x.Green })
                                .WriteTo.SQLite(@"./Logs/log.db")
                                .CreateLogger();

            Color faveColor = new Color
            {
                Red = 121,
                Green = 24,
                Blue = 19,
                Name = "Hi"
            };

            // {@Color:l}
            // Will be logged, This is a message 2021 - 02 - 04 14:19:09.501 + 09:00[INF] Favorites: Color { Red: 121, Green: 24, Blue: 19, Name: "Hi" }
            //
            // {@Color}
            // Will be logged, This is a message 2021 - 02 - 04 14:19:37.258 + 09:00[INF] Favorites: { "Red":121,"Green":24,"Blue":19,"Name":"Hi","$type":"Color"}

            Log.Information("Favorites : {@Color}", faveColor);
        }
    }

    public class Color
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }
        public string Name { get; set; }

        //public override string ToString()
        //{
        //    return $"R : {Red}, G : {Green}, B : {Blue}";
        //}
    }
}
