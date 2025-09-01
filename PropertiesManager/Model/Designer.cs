using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Designer
    {
        private List<string> lists = new List<string>();

        public Designer()
        {
            lists.Add("Kelvin");
            lists.Add("Ong TK");
            lists.Add("Ian");
            lists.Add("Liew SF");
            lists.Add("Lim KC");
        }

        public static List<string> Get
        {
            get
            {
                Designer designer = new Designer();
                return designer.lists;
            }
        }
    }
}
