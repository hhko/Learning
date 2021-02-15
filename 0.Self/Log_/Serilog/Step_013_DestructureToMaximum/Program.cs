using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Step_013_DestructureToMaximum
{
    class Program
    {
        static void Main(string[] args)
        {
            const string customTemplate = "Will be logged, This is a message {Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

            Log.Logger = new LoggerConfiguration()
                                .WriteTo.Console()
                                .WriteTo.File(
                                    path: "./Logs/LogFile.txt",
                                    outputTemplate: customTemplate,
                                    fileSizeLimitBytes: null,
                                    rollingInterval: RollingInterval.Day,
                                    retainedFileCountLimit: 2)

                                //
                                // ToMaximumCollectionCount(2)는 2개까지만 출력한다.
                                //
                                // [17:21:04 INF] Favorites:["red-1", "red-2"]
                                // [17:21:04 INF] Counteries: { "red-1": 5, "red-2": 2}
                                .Destructure.ToMaximumCollectionCount(2)

                                //
                                // ToMaximumStringLength(3) 문자열 2자까지만 출력한다. 그외는 "..."으로 출력한다.
                                //
                                // [17:21:04 INF] Favorites: { "Name": "My…", ... }
                                .Destructure.ToMaximumStringLength(3)

                                //
                                // ToMaximumDepth(2) 1수준까지 값을 출력한다. 2수준 값은 NULL로 출력한다. 그 이상은 출력하지 않는다.
                                // 
                                // [17:22:15 INF] Favorites : {"Red": 122, "Green": 24, "Blue": 19, "Name": "My…", "Items": [null, null], "SubItems": [null], "$type": "Color"}
                                .Destructure.ToMaximumDepth(2)
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
                Blue = 19,
                Name = "My favorite color is red.",
                Items = new List<string> { "1", "2", "3" },
                SubItems = new List<SubItem> 
                { 
                    new SubItem 
                    { 
                        Name = "1", 
                        Items = new List<string> { "1", "2", "3"} 
                    } 
                }
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
        public string Name { get; set; }

        public List<string> Items {get; set; }

        public List<SubItem> SubItems { get; set; }

        public override string ToString()
        {
            return $"R : {Red}, G : {Green}, B : {Blue}";
        }
    }

    public class SubItem
    {
        public string Name { get; set; }
        public List<string> Items { get; set; }

        public override string ToString()
        {
            return $"SubItem : {Name}";
        }
    }
}

