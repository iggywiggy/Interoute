using System;
using InterouteWebAPI.Interfaces;
using log4net;

namespace InterouteWebAPI.Infastructure
{
    public class LogManagerAdapter : ILogManager
    {
        public ILog GetLog(Type typeAssociatedWithRequestedLog)
        {
            if (typeAssociatedWithRequestedLog == null)
                throw new ArgumentNullException(nameof(typeAssociatedWithRequestedLog));

            return LogManager.GetLogger(typeAssociatedWithRequestedLog);
        }
    }
}