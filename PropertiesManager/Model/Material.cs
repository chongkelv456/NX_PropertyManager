using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;

namespace PropertiesManager.Model
{
    public class Material
    {
        private List<string> materials = new List<string>();
        
        public Material()
        {
            materials.Add(Controller.S50C);
            materials.Add(Controller.DC53);
            materials.Add(Controller.GOA);
            materials.Add(Controller.MILD_STELL);
            materials.Add(Controller.NAK80);
            materials.Add(Controller.SKD11);
            materials.Add(Controller.YXR3);
            materials.Add(Controller.YXM1);
            materials.Add(Controller.DEX20);
            materials.Add(Controller.EG2);
        }
        public List<string> Get { get => materials; }
    }
}
