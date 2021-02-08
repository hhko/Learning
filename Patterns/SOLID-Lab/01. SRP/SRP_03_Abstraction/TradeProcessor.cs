using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_03_Abstraction
{
    public class TradeProcessor
    {
        //private static float LotSize = 100000f;

        private ITradeDataProvider _tradeDataProvider;
        private ITradeParser _tradeParser;
        private ITradeStorage _tradeStorage;

        public TradeProcessor(ITradeDataProvider tradeDataProvider, ITradeParser tradeParser, ITradeStorage tradeStorage)
        {
            _tradeDataProvider = tradeDataProvider;
            _tradeParser = tradeParser;
            _tradeStorage = tradeStorage;
        }

        public void ProcessTradesForClarity(Stream stream)
        {
            var lines = _tradeDataProvider.ReadTradeData(stream);
            var trades = _tradeParser.ParseTrades(lines);
            _tradeStorage.StoreTrades(trades);
        }

        //private IEnumerable<string> ReadTradeData(Stream stream)
        //{
        //    var lines = new List<string>();
        //    using (var reader = new StreamReader(stream))
        //    {
        //        string line;
        //        while ((line = reader.ReadLine()) != null)
        //        {
        //            lines.Add(line);
        //        }
        //    }

        //    return lines;
        //}

        //private IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines)
        //{
        //    var trades = new List<TradeRecord>();
        //    var lineCount = 1;
        //    foreach (var line in lines)
        //    {
        //        var fields = line.Split(new char[] { ',' });

        //        if (!VailidateTradeData(fields, lineCount))
        //        {
        //            continue;
        //        }
                
        //        var trade = MapTradeDataToTradeRecord(fields);
        //        trades.Add(trade);

        //        lineCount++;
        //    }

        //    return trades;
        //}

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

        //private void StoreTrades(IEnumerable<TradeRecord> trades)
        //{
        //    using (var connection = new System.Data.SqlClient.SqlConnection("Data Source=(local);Initial Catalog=TradeDatabase;Integrated Security=True;"))
        //    {
        //        connection.Open();
        //        using (var transaction = connection.BeginTransaction())
        //        {
        //            foreach (var trade in trades)
        //            {
        //                var command = connection.CreateCommand();
        //                command.Transaction = transaction;
        //                command.CommandType = System.Data.CommandType.StoredProcedure;
        //                command.CommandText = "dbo.insert_trade";
        //                command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
        //                command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
        //                command.Parameters.AddWithValue("@lots", trade.Lots);
        //                command.Parameters.AddWithValue("@price", trade.Price);

        //                command.ExecuteNonQuery();
        //            }

        //            transaction.Commit();
        //        }
        //        connection.Close();
        //    }

        //    Console.WriteLine("INFO: {0} trades processed", trades.Count());
        //}
    }
}
