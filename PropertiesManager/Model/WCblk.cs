using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class WCblk
    {
        private List<string> lists = new List<string>();

        public WCblk()
        {
            lists.Add("WC BLOCK");
        }

        public static List<string> Get 
        {
            get
            {
                WCblk wCblk = new WCblk();
                return wCblk.lists;
            }
        }
    }
}
