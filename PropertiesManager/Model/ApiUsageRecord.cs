using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class ApiUsageRecord
    {
        public string ApiName { get; set; }
        public string EnginnerName { get; set; }
        public string Version { get; set; }
        public DateTime UsedTime { get; set; }
        public string ComputerName { get; set; }

        public string ToCsvLine()
        {
            return $"{ApiName},{EnginnerName},{Version},{UsedTime:yyyy-MM-dd HH:mm:ss},{ComputerName}";
        }

        public static string CsvHeader()
        {
            return "ApiName,EnginnerName,Version,UsedTime,ComputerName";
        }
    }
}
