using PropertiesManager.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Assembly
    {
        private List<string> assemblys = new List<string>();

        public Assembly() {
            assemblys.Add(Controller.MAIN_ASSEMBLY);
            assemblys.Add(Controller.TOP_ASSEMBLY);
            assemblys.Add(Controller.BOTTOM_ASSEMBLY);
            assemblys.Add(Controller.LEFT_ASSEMBLY);
            assemblys.Add(Controller.RIGHT_ASSEMBLY);
            assemblys.Add(Controller.ASSEMBLY_FOR);
        }

        public List<string> Get { get => assemblys; }
    }
}
