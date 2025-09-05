using PropertiesManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Service for tracking API usage
    /// </summary>
    public interface IUsageTrackingService
    {
        /// <summary>
        /// Logs API usage to storage
        /// </summary>
        /// <param name="record">Usage record to log</param>
        void LogUsage(ApiUsageRecord record);

        /// <summary>
        /// Logs API usage with minimal parameters
        /// </summary>
        /// <param name="apiName">Name of the API</param>
        void LogUsage(string apiName);

        /// <summary>
        /// Logs API error with exception details
        /// </summary>
        /// <param name="apiName">Name of the API</param>
        /// <param name="exception">Exception that occurred</param>
        void LogError(string apiName, Exception exception);
    }
}
