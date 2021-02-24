using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Step_012_DestructureByTransforming
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File(path: "./Logs/LogFile.txt")

                                //
                                // Destructuring operator을 재정의한다.
                                //
                                .Destructure.ByTransforming<Color>(x => new { x.Red, x.Green })
                                .CreateLogger();

            string name = "Foo";
            int age = 2021;
            DateTime created = DateTime.Now;
            Guid guid = Guid.NewGuid();
            Log.Information("User {Name}, Age {Age}. Created on {Created} - {ID}", name, age, created, guid);

            IEnumerable faveColors = new List<string>
            {
                "red-1",
                "red-2",
                "red-3"
            };
            Log.Information("Favorites : {Colors}", faveColors);

            Dictionary<string, int> visited = new Dictionary<string, int>
            {
                { "red-1", 5 },
                { "red-2", 2 },
                { "red-3", 1 }
            };
            Log.Information("Counteries : {VisitedCounteries}", visited);

            Color faveColor = new Color
            {
                Red = 122,
                Green = 24,
                Blue = 19
            };
            Log.Information("Favorites : {Color}", faveColor);

            // Destructuring operator : @
            // [13:11:33 INF] Favorites : {"Red": 122, "Green": 24, "Blue": 19, "$type": "Color"}
            //
            // .Destructure.ByTransforming<Color>
            // [13:26:24 INF] Favorites : {"Red": 122, "Green": 24}
            Log.Information("Favorites : {@Color}", faveColor);

            Log.CloseAndFlush();
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
