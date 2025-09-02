using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class PartTypeConfig
    {
        public Func<IEnumerable<string>> GetItems { get; set; }
        public object Material { get; set; }
        public int StationNumber { get; set; }
        public Image Image { get; set; }
        public bool UseHyphen { get; set; }
        public bool OverrideMaterialText { get; set; }
    }
}
