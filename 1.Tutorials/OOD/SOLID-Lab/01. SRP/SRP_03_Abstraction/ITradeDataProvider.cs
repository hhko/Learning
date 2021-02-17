using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRP_03_Abstraction
{
    public interface ITradeDataProvider
    {
        IEnumerable<string> ReadTradeData(Stream stream);
    }
}
