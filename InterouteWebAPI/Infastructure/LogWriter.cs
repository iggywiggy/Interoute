using System;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Tracing;
using InterouteWebAPI.Interfaces;
using log4net;

namespace InterouteWebAPI.Infastructure
{
    public class LogWriter : ILogWriter
    {
        private readonly ILog _log;

        public LogWriter(ILogManager logManager)
        {
            _log = logManager.GetLog(typeof(LogWriter));
        }

        public void WriteToLog(TraceRecord record)
        {
            const string traceFormat =
                "RequestId={0}; Kind={1}; Status={2}; Operation={3}; Operator={4}; Category={5} Request={6} Message={7}";

            var args = new object[]
            {
                record.RequestId,
                record.Kind,
                record.Status,
                record.Operation,
                record.Operator,
                record.Category,
                record.Request,
                record.Message
            };

            switch (record.Level)
            {
                case TraceLevel.Debug:
                    _log.DebugFormat(traceFormat, args);
                    break;
                case TraceLevel.Info:
                    _log.InfoFormat($"{DateTime.Now}, {GetStringQueryParameters(record)}, {record.Message}", args);
                    break;
                case TraceLevel.Warn:
                    _log.WarnFormat(traceFormat, args);
                    break;
                case TraceLevel.Error:
                    _log.ErrorFormat(traceFormat, args);
                    break;
                case TraceLevel.Fatal:
                    _log.FatalFormat(traceFormat, args);
                    break;
            }
        }

        public void Trace(HttpRequestMessage request, string category, TraceLevel level,
            Action<TraceRecord> traceAction)
        {
            var record = new TraceRecord(request, category, level);
            traceAction(record);
            WriteToLog(record);
        }

        public string GetStringQueryParameters(TraceRecord record)
        {
            var parameters = HttpUtility.ParseQueryString(record.Request.RequestUri.Query);

            var stringBuilder = new StringBuilder();

            foreach (string key in parameters)
                stringBuilder.Append("" + parameters[key]);

            return stringBuilder.ToString();
        }
    }
}