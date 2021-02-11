using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_03_Abstraction
{
    public interface ITradeStorage
    {
        void StoreTrades(IEnumerable<TradeRecord> trades);
    }
}
