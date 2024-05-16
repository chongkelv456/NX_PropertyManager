using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Other
    {
        private List<string> others = new List<string>();

        public Other()
        {
            others.Add("CHUTE");
            others.Add("CHUTE FOR PRODUCT");
        }

        public List<string> Get { get => others; }
    }
}
