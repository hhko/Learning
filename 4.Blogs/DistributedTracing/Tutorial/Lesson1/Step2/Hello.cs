using System.Diagnostics.Contracts;
using Microsoft.Extensions.Logging;

namespace Step2
{
    public class Hello
    {
        private readonly ILogger<Hello> _logger;

        public Hello(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Hello>();
        }

        public void SayHello(string helloTo)
        {
            var msg = GreetingFor(helloTo);
            _logger.LogInformation(msg);
        }

        [Pure]
        private string GreetingFor(string helloTo)
        {
            return $"Hello, {helloTo}!";
        }
    }
}