using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Material
    {
        private List<string> materials = new List<string>();
        public Material()
        {
            materials.Add("S50C");
            materials.Add("DC53");
            materials.Add("GOA");
            materials.Add("Mild Steel");
            materials.Add("NAK80");
            materials.Add("SKD11");
            materials.Add("YXR3");
            materials.Add("YXM1");
            materials.Add("DEX20");
        }
        public List<string> Get { get => materials; }
    }
}
