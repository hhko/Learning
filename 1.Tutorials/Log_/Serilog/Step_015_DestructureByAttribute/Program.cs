using Destructurama;
using Destructurama.Attributed;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Step_015_DestructureByAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()

                                //
                                // Destructure Attribute 사용 : `@`에만 적용된다.
                                // 예. [NotLogged]
                                //
                                .Destructure.UsingAttributes()

                                .WriteTo.Console()
                                .WriteTo.File(path: "./Logs/LogFile.txt")
                                .CreateLogger();
            
            Color faveColor = new Color
            {
                Red = 122,
                Green = 24,
                Blue = 19,
                SubColors = new List<SubColor>
                {
                    new SubColor 
                    {
                        Name = "1",
                    },
                    new SubColor
                    {
                        Name = "2",
                    }
                }
            };

            //
            // Object
            //
            //[13:36:11 INF] Favorites: R: 122, G: 24, B: 19
            Log.Information("Favorites : {Color}", faveColor);

            //
            // Object Destructure : `@`
            //
            //[13:36:11 INF] Favorites: { "Red": 122, "Green": 24, "SubColors": [{ "$type": "SubColor"}, { "$type": "SubColor"}], "$type": "Color"}
            Log.Information("Favorites : {@Color}", faveColor);

            Log.CloseAndFlush();
        }
    }

    public class Color
    {
        public int Red { get; set; }
        public int Green { get; set; }

        [NotLogged]
        public int Blue { get; set; }

        public List<SubColor> SubColors { get; set; }

        public override string ToString()
        {
            return $"R : {Red}, G : {Green}, B : {Blue}";
        }
    }

    public class SubColor
    {
        [NotLogged]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"SubColor : {Name}";
        }
    }
}
