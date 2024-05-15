using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Plate
    {
        private List<string> plates = new List<string>();

        public Plate()
        {
            plates.Add("UPPER PAD SPACER");
            plates.Add("UPPER PAD");
            plates.Add("PUNCH HOLDER");
            plates.Add("BOTTOMING PLATE");
            plates.Add("STRIPPER PLATE");
            plates.Add("MATERIAL GUIDE-F/R");
            plates.Add("MATERIAL GUIDE-F");
            plates.Add("MATERIAL GUIDE-R");
            plates.Add("DIE PLATE");
            plates.Add("DIE PLATE-R");
            plates.Add("DIE PLATE-F");
            plates.Add("LOWER PAD");
            plates.Add("LOWER PAD SPACER");
        }
    }
}
