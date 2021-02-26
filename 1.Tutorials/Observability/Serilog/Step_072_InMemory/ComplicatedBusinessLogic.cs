using Serilog;
using System;

namespace Step_072_InMemory
{
    public class ComplicatedBusinessLogic
    {
        private readonly ILogger _logger;

        public ComplicatedBusinessLogic(ILogger logger)
        {
            _logger = logger;
        }

        public string FirstTenCharacters(string input)
        {
            _logger.Information("Input is {Count} characters long {Foo}", input.Length, 1);

            return input.Substring(0, 3);
        }
    }
}
