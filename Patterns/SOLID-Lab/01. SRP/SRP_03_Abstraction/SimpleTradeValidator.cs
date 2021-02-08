using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_03_Abstraction
{
    public class SimpleTradeValidator : ITradeValidator
    {
        private ILogger _logger;

        public SimpleTradeValidator(ILogger logger)
        {
            _logger = logger;
        }

        public bool VailidateTradeData(string[] fields, int lineCount)
        {
            if (fields.Length != 3)
            {
                // Case 1.
                //Console.WriteLine("WARN: Line {0} malformed. Only {1} field(s) found.", lineCount, fields.Length);
                _logger.LogWarning("WARN: Line {0} malformed. Only {1} field(s) found.", lineCount, fields.Length);
                return false;
            }

            if (fields[0].Length != 6)
            {
                //Console.WriteLine("WARN: Trade currencies on line {0} malformed: '{1}'", lineCount, fields[0]);
                _logger.LogWarning("WARN: Trade currencies on line {0} malformed: '{1}'", lineCount, fields[0]);
                return false;
            }

            int tradeAmount;
            if (!int.TryParse(fields[1], out tradeAmount))
            {
                //Console.WriteLine("WARN: Trade amount on line {0} not a valid integer: '{1}'", lineCount, fields[1]);
                _logger.LogWarning("WARN: Trade amount on line {0} not a valid integer: '{1}'", lineCount, fields[1]);
                return false;
            }

            decimal tradePrice;
            if (!decimal.TryParse(fields[2], out tradePrice))
            {
                //Console.WriteLine("WARN: Trade price on line {0} not a valid decimal: '{1}'", lineCount, fields[2]);
                _logger.LogWarning("WARN: Trade price on line {0} not a valid decimal: '{1}'", lineCount, fields[2]);
                return false;
            }

            return true;
        }
    }
}
