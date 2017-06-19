using System;
using InterouteWebAPI.Interfaces;
using log4net;

namespace InterouteWebAPI.Infastructure
{
    public class LogManagerAdapter : ILogManager
    {
        public ILog GetLog(Type typeAssociatedWithRequestedLog)
        {
            return LogManager.GetLogger(typeAssociatedWithRequestedLog);
        }
    }
}