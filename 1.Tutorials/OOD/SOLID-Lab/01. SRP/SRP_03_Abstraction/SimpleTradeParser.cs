using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_03_Abstraction
{
    public class SimpleTradeParser : ITradeParser
    {
        //private static float LotSize = 100000f;

        private ITradeValidator _tradeValidator;
        private ITradeMapper _tradeMapper;

        public SimpleTradeParser(ITradeValidator tradeValidator, ITradeMapper tradeMapper)
        {
            _tradeValidator = tradeValidator;
            _tradeMapper = tradeMapper;
        }

        public IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines)
        {
            var trades = new List<TradeRecord>();
            var lineCount = 1;
            foreach (var line in lines)
            {
                var fields = line.Split(new char[] { ',' });

                if (!_tradeValidator.VailidateTradeData(fields, lineCount))
                {
                    continue;
                }

                var trade = _tradeMapper.MapTradeDataToTradeRecord(fields);
                trades.Add(trade);

                lineCount++;
            }

            return trades;
        }

        //private bool VailidateTradeData(string[] fields, int lineCount)
        //{
        //    if (fields.Length != 3)
        //    {
        //        Console.WriteLine("WARN: Line {0} malformed. Only {1} field(s) found.", lineCount, fields.Length);
        //        return false;
        //    }

        //    if (fields[0].Length != 6)
        //    {
        //        Console.WriteLine("WARN: Trade currencies on line {0} malformed: '{1}'", lineCount, fields[0]);
        //        return false;
        //    }

        //    int tradeAmount;
        //    if (!int.TryParse(fields[1], out tradeAmount))
        //    {
        //        Console.WriteLine("WARN: Trade amount on line {0} not a valid integer: '{1}'", lineCount, fields[1]);
        //        return false;
        //    }

        //    decimal tradePrice;
        //    if (!decimal.TryParse(fields[2], out tradePrice))
        //    {
        //        Console.WriteLine("WARN: Trade price on line {0} not a valid decimal: '{1}'", lineCount, fields[2]);
        //        return false;
        //    }

        //    return true;
        //}

        //private TradeRecord MapTradeDataToTradeRecord(string[] fields)
        //{
        //    var sourceCurrencyCode = fields[0].Substring(0, 3);
        //    var destinationCurrencyCode = fields[0].Substring(3, 3);

        //    var tradeAmount = int.Parse(fields[1]);
        //    var tradePrice = decimal.Parse(fields[2]);

        //    var trade = new TradeRecord
        //    {
        //        SourceCurrency = sourceCurrencyCode,
        //        DestinationCurrency = destinationCurrencyCode,
        //        Lots = tradeAmount / LotSize,
        //        Price = tradePrice
        //    };

        //    return trade;
        //}
    }
}
