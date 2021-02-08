using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNlog
{
    class Program
    {
        static void Main(string[] args)
        {

            //LogManager.Configuration = new NLog.Config
            //    .XmlLoggingConfiguration(@"Configurations\nlog.config");

            LogManager.Configuration = new NLog.Config
                .XmlLoggingConfiguration(@"Configurations\nlog.debug.config");


            Sample sample = new Sample();
            sample.DoSomething1();
            //sample.StructedLog();

            //sample.ThrowException();
            //sample.DoSomething();
            //sample.Test();
        }
    }

    public class Docker
    {
        public string Name { get; set; }
        public string LicenseNumber { get; set; }
    }

    public class Sample
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public void DoSomething1()
        {
            Docker docker = new Docker { Name = "Bob", LicenseNumber = "123" };
            _logger.Info("xyz {@DOCKER}", docker);
        }

        public void StructedLog()
        {
            while(true)
            {
                _logger
                    .WithProperty("{PROP_NAME2}", "Prop Val2")
                    .Info("{PROP_NAME}", "Prop Val");

                Thread.Sleep(2000);
            }
            
        }

        public void ThrowException()
        {
            try
            {
                int y = 0;
                int x = 2019 / y;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "call method - ThrowException");
            }
        }

        public void DoSomething()
        {
            _logger.Trace("Entry - DoSomething");

            _logger.Info("DoSomething is completed");

            //ILogger newlogger = _logger
            //    //.WithProperty("xyz", new { From = "value1", To = "value2" });
            //    .WithProperty("xyz", "From = " + "value1" + " To = " + "value2");

            // .Info("{x1}", o.X);
            //   - 갯수만 일치하면 된다(이름은 일치하지 않아도 된다).
            Order o = new Order();
            _logger
                //.WithProperty("xyz", "value1")
                .Info("{OrderId} {Status}", o.OrderId, o.Status);
            _logger.Info("{OrderId} {Status}", o.OrderId, o.Status);
            _logger.Info("{Status} {OrderId}", o.OrderId, o.Status);
            _logger.Info("{OrderId} {Status} {Z}", o.OrderId, o.Status);
            _logger.Info("{Status} {OrderId} {X} {Z}", o.OrderId, o.Status);
            _logger.Info("{X} {Y}", o.OrderId, o.Status);
            _logger.Info("{@x}", o);

            _logger.Trace("Eixt - DoSomething");

            _logger.Info("{DATE: dddd MMMM, d yyyy}", new DateTime(2020, 1, 6));

            _logger.Info("{SELF}", new { From = "x", To = "y", Detail = 2020 });
            // { From = x, To = y, Detail = 2020 }
            _logger.Info("{@SELF}", new { From = "x", To = "y", Detail = 2020 });
            // { "From":"x", "To":"y", "Detail":2020}
            _logger.Info("{$SELF}", new { From = "x", To = "y", Detail = 2020 });
            // "{ From = x, To = y, Detail = 2020 }"

            _logger.Info("{CUSTOMERS}", new string[] { "x1", "x2" });
            // "x1", "x2"
            _logger.Info("{@CUSTOMERS}", new string[] { "x1", "x2" });
            // ["x1","x2"]
            _logger.Info("{$CUSTOMERS}", new string[] { "x1", "x2" });
            // "System.String[]"
        }

        public void Test()
        {
            Object o = null;

            _logger.Info("Test {value1}", o); 
            // null case. 
            // Result:  Test NULL
            _logger.Info("Test {value1}", new DateTime(2018, 03, 25)); 
            // datetime case. 
            // Result:  Test 25-3-2018 00:00:00 (locale TString)
            _logger.Info("Test {value1}", new List<string> { "a", "b" }); 
            // list of strings. 
            // Result: Test "a", "b"
            _logger.Info("Test {value1}", new[] { "a", "b" }); 
            // array. 
            // Result: Test "a", "b"
            _logger.Info("Test {value1}", new Dictionary<string, int> { { "key1", 1 }, { "key2", 2 } }); 
            // dict. 
            // Result:  Test "key1"=1, "key2"=2

            var order = new Order
            {
                OrderId = 2,
                Status = OrderStatus.Processing
            };

            _logger.Info("Test {value1}", order); 
            // object 
            // Result:  Test MyProgram.Program+Order
            _logger.Info("Test {@value1}", order); 
            // object 
            // Result:  Test {"OrderId":2, "Status":"Processing"}
            _logger.Info("Test {value1}", new { OrderId = 2, Status = "Processing" }); 
            // anomynous object. 
            // Result: Test { OrderId = 2, Status = Processing }
            _logger.Info("Test {@value1}", new { OrderId = 2, Status = "Processing" }); 
            // anomynous object. 
            // Result:Test {"OrderId":2, "Status":"Processing"}
        }
    }

    public enum OrderStatus { Processing };

    public class Order
    {
        public int OrderId { get; set; }

        public OrderStatus Status { get; set; }

        public int X { get; set; }
        public string Y { get; set; }

        public Order()
        {
            X = 2020;
            Y = "Hello";
        }
    }
}
