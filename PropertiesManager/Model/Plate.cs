using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;

namespace PropertiesManager.Model
{
    public class Plate
    {
        private List<string> plates = new List<string>();

        public Plate()
        {
            plates.Add(Controller.UPPER_PAD_SPACER);
            plates.Add(Controller.UPPER_PAD);
            plates.Add(Controller.PUNCH_HOLDER);
            plates.Add(Controller.BOTTOMING_PLATE);
            plates.Add(Controller.STRIPPER_PLATE);
            plates.Add(Controller.DIE_PLATE);
            plates.Add(Controller.DIE_PLATE_R);
            plates.Add(Controller.DIE_PLATE_F);
            plates.Add(Controller.LOWER_PAD);
            plates.Add(Controller.LOWER_PAD_SPACER);
        }

        public List<string> Get { get => plates; }
    }
}
