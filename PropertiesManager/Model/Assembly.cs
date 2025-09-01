using PropertiesManager.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Constants;

namespace PropertiesManager.Model
{
    public class Assembly
    {
        private List<string> lists = new List<string>();

        public Assembly() {
            lists.Add(Const.AsmType.MAIN_ASSEMBLY);
            lists.Add(Const.AsmType.TOP_ASSEMBLY);
            lists.Add(Const.AsmType.BOTTOM_ASSEMBLY);
            lists.Add(Const.AsmType.LEFT_ASSEMBLY);
            lists.Add(Const.AsmType.RIGHT_ASSEMBLY);
            lists.Add(Const.AsmType.ASSEMBLY_FOR);
        }

        public static List<string> Get 
        {
            get
            {
                Assembly assembly = new Assembly();
                return assembly.lists;
            }
        }
    }
}
