using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Step_010_CollectionAndObject
{
    class Program
    {
        static void Main(string[] args)
        {
            const string customTemplate = "Will be logged, This is a message {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            ILogger log = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File(
                                    path: "./Logs/LogFile.txt",
                                    outputTemplate: customTemplate,
                                    fileSizeLimitBytes: null,
                                    rollingInterval: RollingInterval.Day,
                                    retainedFileCountLimit: 2)
                                .CreateLogger();

            Log.Logger = log;

            string name = "Foo";
            int age = 2021;
            DateTime created = DateTime.Now;
            Guid guid = Guid.NewGuid();
            Log.Information("User {Name}, Age {Age}. Created on {Created} - {ID}", name, age, created, guid);

            // IEnumerable
            //
            // [12:09:06 INF] Favorites : ["red", "orange", "black"]
            IEnumerable faveColors = new List<string>
            {
                "red",
                "orange",
                "black"
            };
            Log.Information("Favorites : {Colors}", faveColors);

            // Dictionary
            //
            // [13:06:25 INF] Counteries : {"England": 5, "India": 2, "France": 1}
            Dictionary<string, int> visited = new Dictionary<string, int>
            {
                { "England", 5 },
                { "India", 2 },
                { "France", 1 }
            };
            Log.Information("Counteries : {VisitedCounteries}", visited);

            // Object : .ToString
            //
            // [13:08:56 INF] Favorites : Step_010_CollectionAndObject.Color
            // [13:10:10 INF] Favorites : R : 122, G : 24, B : 19
            Color faveColor = new Color
            {
                Red = 122,
                Green = 24,
                Blue = 19
            };
            Log.Information("Favorites : {Color}", faveColor);
        }
    }

    public class Color
    {
        public int Red { get; set; }
        public int Green { get; set; }
        public int Blue { get; set; }

        public override string ToString()
        {
            return $"R : {Red}, G : {Green}, B : {Blue}";
        }
    }
}
