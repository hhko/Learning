using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace Step_023_CustomProperty
{
    public class AppEnricher : ILogEventEnricher
    {
        /*
        LogEventProperty _cachedProperty;
        public const string ApplicationName = "ApplicationName";
        public const string ApplicationVersion = "ApplicationVersion";

        public AppEnricher()
        {

        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            // Don't care about thread-safety, in the worst case the field gets overwritten and one property will be GCed
            if (_cachedProperty == null)
                _cachedProperty = CreateProperty(propertyFactory);

            logEvent.AddPropertyIfAbsent(_cachedProperty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static LogEventProperty CreateProperty(ILogEventPropertyFactory propertyFactory)
        {
            //var value = Environment.GetEnvironmentVariable("RELEASE_NUMBER") ?? "local";
            //return propertyFactory.CreateProperty(PropertyName, value);
        
            var app = Assembly.GetEntryAssembly();

            var appName = app.GetName().Name;
            var appVersion = app.GetName().Version;

            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ApplicationName", appName));
            logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty("ApplicationVersion", appVersion));
        }
        */

        LogEventProperty _cachedApplicationNameProperty;
        LogEventProperty _cachedApplicationVersionProperty;

        public const string AppNamePropertyName = "ApplicationName";
        public const string AppVersionPropertyName = "ApplicationVersion";

        private readonly string _appName;
        private readonly Version _appVersion;

        public AppEnricher()
        {
            var appAssembly = Assembly.GetEntryAssembly().GetName();
            _appName = appAssembly.Name;
            _appVersion = appAssembly.Version;
        }

        //
        // 로그 출력할 때마다 매번 호출된다.
        //
        // "Using": [ "Example.Assembly.Name" ],          // DLL 이름
        // "Enrich": [ "FromLogContext", "WithApp" ]      // 확장 메서드 이름
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (_cachedApplicationNameProperty == null)
            {
                _cachedApplicationNameProperty = propertyFactory.CreateProperty(AppNamePropertyName, _appName);
            }

            if (_cachedApplicationVersionProperty == null)
            {
                _cachedApplicationVersionProperty = propertyFactory.CreateProperty(AppVersionPropertyName, _appVersion);
            }

            logEvent.AddPropertyIfAbsent(_cachedApplicationNameProperty);
            logEvent.AddPropertyIfAbsent(_cachedApplicationVersionProperty);
        }
    }
}
