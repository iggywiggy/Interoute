using System;
using log4net;

namespace InterouteWebAPI.Interfaces
{
    public interface ILogManager
    {
        ILog GetLog(Type typeAssociatedWithRequestedLog);
    }
}