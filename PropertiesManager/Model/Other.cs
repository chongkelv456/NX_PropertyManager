using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Other
    {
        private List<string> lists = new List<string>();

        public Other()
        {
            lists.Add("CHUTE");
            lists.Add("CHUTE FOR PRODUCT");
        }

        public static List<string> Get 
        {
            get
            {
                Other other = new Other();
                return other.lists;
            }
        }
    }
}
