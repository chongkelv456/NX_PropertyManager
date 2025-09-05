using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Static utility for easy API usage tracking
    /// </summary>
    public class UsageTracker
    {
        private static readonly Lazy<IUsageTrackingService> _service 
            = new Lazy<IUsageTrackingService>(() => new CsvUsageTrackingService());

        /// <summary>
        /// Logs API usage with minimal effort
        /// </summary>
        /// <param name="apiName">Name of the API</param>
        public static void LogUsage(string apiName)
        {
            try
            {
                _service.Value.LogUsage(apiName);
            }
            catch
            {
                // Silent fail - never disrupt main functionality
            }

        }

        /// <summary>
        /// For testing or custom service injection
        /// </summary>
        internal static IUsageTrackingService Service => _service.Value;
    }
}
