using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOPAPI.Utilities
{
    public class Logger : ILogger
    {

        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public Logger()
        {
            XmlConfigurator.Configure();
        }

        public void LogDebug(string message)
        {
            _log.Debug(message);
        }

        public void LogError(Exception exception)
        {
            _log.Error(exception.Message, exception);
        }
    }
}