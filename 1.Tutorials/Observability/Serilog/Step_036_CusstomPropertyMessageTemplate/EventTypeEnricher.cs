using Murmur;
using Serilog.Core;
using Serilog.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Step_036_CusstomPropertyMessageTemplate
{
    public class EventTypeEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            /*
             * Case 1. UInt32 타입
            var murmur = MurmurHash.Create32();
            var bytes = Encoding.UTF8.GetBytes(logEvent.MessageTemplate.Text);
            var hash = murmur.ComputeHash(bytes);
            var numericHash = BitConverter.ToUInt32(hash, 0);
            var eventType = propertyFactory.CreateProperty("EventType", numericHash);
            logEvent.AddPropertyIfAbsent(eventType);
            */

            //
            // Case 2. string 타입
            //
            if (logEvent is null)
                throw new ArgumentNullException(nameof(logEvent));

            if (propertyFactory is null)
                throw new ArgumentNullException(nameof(propertyFactory));

            Murmur32 murmur = MurmurHash.Create32();
            byte[] bytes = Encoding.UTF8.GetBytes(logEvent.MessageTemplate.Text);
            byte[] hash = murmur.ComputeHash(bytes);

            //
            // 타임 : string           vs. UInt32
            // 값   : 2B048590(8자리)  vs. 2424636459(10자리)
            //
            string hexadecimalHash = BitConverter.ToString(hash).Replace("-", "");
            LogEventProperty eventId = propertyFactory.CreateProperty("EventType", hexadecimalHash);
            logEvent.AddPropertyIfAbsent(eventId);
        }
    }
}
