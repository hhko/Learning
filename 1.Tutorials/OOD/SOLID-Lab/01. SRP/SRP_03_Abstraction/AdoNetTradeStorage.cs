using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_03_Abstraction
{
    public class AdoNetTradeStorage : ITradeStorage
    {
        //
        // Case 1. 
        // Console -> ILogger로 교체한다.
        //
        private ILogger _logger;

        public AdoNetTradeStorage(ILogger logger)
        {
            _logger = logger;
        }

        public void StoreTrades(IEnumerable<TradeRecord> trades)
        {
            using (var connection = new System.Data.SqlClient.SqlConnection("Data Source=(local);Initial Catalog=TradeDatabase;Integrated Security=True;"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    foreach (var trade in trades)
                    {
                        var command = connection.CreateCommand();
                        command.Transaction = transaction;
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.CommandText = "dbo.insert_trade";
                        command.Parameters.AddWithValue("@sourceCurrency", trade.SourceCurrency);
                        command.Parameters.AddWithValue("@destinationCurrency", trade.DestinationCurrency);
                        command.Parameters.AddWithValue("@lots", trade.Lots);
                        command.Parameters.AddWithValue("@price", trade.Price);

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
                connection.Close();
            }

            // Case 1.
            // Console -> ILogger로 교체한다.
            //Console.WriteLine("INFO: {0} trades processed", trades.Count());
            _logger.LogInfo("INFO: {0} trades processed", trades.Count());
        }
    }
}
