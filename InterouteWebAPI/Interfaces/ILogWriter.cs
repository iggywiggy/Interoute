using System.Web.Http.Tracing;

namespace InterouteWebAPI.Interfaces
{
    public interface ILogWriter
    {
        void WriteToLog(TraceRecord record);
    }
}