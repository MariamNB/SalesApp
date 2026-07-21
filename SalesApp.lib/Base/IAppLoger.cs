using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesApp.lib.Base
{
    public interface IAppLoger<T>
    {
        void LogInformation(string message);
        void LogError(Exception ex, string message);
        void LogWarning(string message);
    }
}