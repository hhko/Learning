using System;
using System.Collections.Generic;
using System.Text;

namespace Ch2.CreatingFixture
{
    public class LogMessageCreator
    {
        public static LogMessage Creaste(string message, DateTime when)
        {
            return new LogMessage
            {
                Year = when.Year,
                Message = message
            };
        }
    }
}
