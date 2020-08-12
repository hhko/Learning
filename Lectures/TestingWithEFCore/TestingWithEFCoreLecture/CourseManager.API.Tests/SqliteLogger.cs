using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace CourseManager.API.Tests
{
    internal class SqliteLogger : ILogger
    {
        private readonly Action<string> _action;
        private readonly LogLevel _logLevel;

        public SqliteLogger(Action<string> aAction, LogLevel logLevel)
        {
            _action = aAction;
            _logLevel = logLevel;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel >= _logLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            _action($"LogLevel: {logLevel}, {state}");
        }
    }
}
