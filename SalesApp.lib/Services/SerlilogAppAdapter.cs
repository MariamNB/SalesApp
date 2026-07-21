using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SalesApp.lib.Base;

namespace SalesApp.lib.Services
{
    public class SerlilogAppAdapter<T>(ILogger<T> logger) : IAppLoger<T> where T : class
    {
        public void LogError(Exception ex, string message)
        {
            logger.LogError(ex, message);
        }

        public void LogWarning(string message)
        {
            logger.LogWarning(message);
        }

        public void LogInformation(string message)
        {
            logger.LogInformation(message);
        }
    }


}