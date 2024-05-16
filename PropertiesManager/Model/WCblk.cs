using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class WCblk
    {
        private List<string> wcBlks = new List<string>();

        public WCblk()
        {
            wcBlks.Add("WC BLOCK");
        }

        public List<string> Get { get => wcBlks; }
    }
}
