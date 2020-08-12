using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.API.Tests
{
    internal class SqliteLoggerProvider : ILoggerProvider
    {
        private readonly Action<string> _action;
        private readonly LogLevel _logLevel;

        public SqliteLoggerProvider(
            Action<string> action,
            LogLevel logLevel = LogLevel.Information)
        {
            _action = action;
            _logLevel = logLevel;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new SqliteLogger(_action, _logLevel);
        }

        public void Dispose()
        {
            
        }
    }
}
