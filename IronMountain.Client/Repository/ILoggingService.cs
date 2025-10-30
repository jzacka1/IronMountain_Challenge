using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iron_Mountain_Coding_Challenge.Repository
{
    public interface ILoggingService
    {
        void Info(string message);
        void Error(string message, Exception ex = null);
        void Warn(string message);
        void Debug(string message);
    }
}
