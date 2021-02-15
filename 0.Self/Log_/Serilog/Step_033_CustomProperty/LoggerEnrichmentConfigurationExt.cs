using Serilog;
using Serilog.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Step_023_CustomProperty
{
    public static class LoggerEnrichmentConfigurationExt
    {
        public static LoggerConfiguration WithApp(this LoggerEnrichmentConfiguration enrich)
        {
            if (enrich == null)
                throw new ArgumentNullException(nameof(enrich));

            return enrich.With<AppEnricher>();
        }
    }
}
