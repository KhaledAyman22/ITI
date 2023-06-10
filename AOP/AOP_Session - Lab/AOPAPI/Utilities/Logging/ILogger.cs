using System;

namespace AOPAPI.Utilities
{
    public interface ILogger
    {
        void LogError(Exception exception);
        void LogDebug(string message);
    }
}