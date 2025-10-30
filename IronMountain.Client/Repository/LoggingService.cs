using Serilog;
using System;
using System.IO;

namespace Iron_Mountain_Coding_Challenge.Repository
{
    public class LoggingService : ILoggingService
    {
        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Info(string message)
        {
            Log.Information(message);
        }

        public void Warn(string message)
        {
            Log.Warning(message);
        }

        public void Error(string message, Exception ex = null)
        {
            if (ex == null)
                Log.Error(message);
            else
                Log.Error(ex, message);
        }
    }
}
