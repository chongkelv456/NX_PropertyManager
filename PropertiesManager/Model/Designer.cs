using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Designer
    {
        private List<string> designers = new List<string>();        

        public Designer ()
        {
            designers.Add("Kelvin");
            designers.Add("Ong TK");
            designers.Add("Ian");
            designers.Add("Liew SF");
            designers.Add("Lim KC");
        }

        public List<string> GetDesingers { get => designers; }

        // Todo: Append the name list by external data
    }
}
