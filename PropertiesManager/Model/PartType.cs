using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;

namespace PropertiesManager.Model
{
    public class PartType
    {
        private List<string> partTypes = new List<string>();

        public PartType()
        {
            partTypes.Add(Controller.SHOE);
            partTypes.Add(Controller.PLATE);
            partTypes.Add(Controller.INSERT);
            partTypes.Add(Controller.WCBLK);
            partTypes.Add(Controller.OTHERS);
            partTypes.Add(Controller.ASM);
        }

        public List<string> Get { get => partTypes; }
    }
}
