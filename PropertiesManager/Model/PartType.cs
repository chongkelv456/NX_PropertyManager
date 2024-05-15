using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class PartType
    {
        private List<string> partTypes = new List<string>();

        public PartType()
        {
            partTypes.Add("SHOE");
            partTypes.Add("PLATE");
            partTypes.Add("INSERT");
            partTypes.Add("W/C BLK");
            partTypes.Add("OTHERS");            
        }

        public List<string> GetPartTypes { get => partTypes; }
    }
}
