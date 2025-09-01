using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;
using PropertiesManager.Constants;

namespace PropertiesManager.Model
{
    public class Material
    {
        private List<string> lists = new List<string>();
        
        public Material()
        {
            lists.Add(Const.Material.S50C);
            lists.Add(Const.Material.DC53);
            lists.Add(Const.Material.GOA);
            lists.Add(Const.Material.MILD_STELL);
            lists.Add(Const.Material.NAK80);
            lists.Add(Const.Material.SKD11);
            lists.Add(Const.Material.YXR3);
            lists.Add(Const.Material.YXM1);
            lists.Add(Const.Material.DEX20);
            lists.Add(Const.Material.EG2);
        }
        public static List<string> Get 
        { 
            get
            {
                Material material = new Material();
                return material.lists;
            }
        }
    }
}
