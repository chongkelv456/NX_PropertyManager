using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;

namespace PropertiesManager.Model
{
    public class Hardness
    {
        private List<string> hardnesses = new List<string>();

        public Hardness()
        {
            hardnesses.Add(Controller.HYPHEN);
            hardnesses.Add(Controller.THIRTYFIVE_FOURTY);
            hardnesses.Add(Controller.FIFTYTWO_FIFTYFOUR);
            hardnesses.Add(Controller.FIFTYSEVEN_FIFTYNINE);
            hardnesses.Add(Controller.FIFTYEIGHT_SIXTY);
            hardnesses.Add(Controller.SIXTY_SIXTYTHREE);
            hardnesses.Add(Controller.SIXTYTWO_SIXTYFIVE);
        }
        public List<string> Get { get => hardnesses; }
    }
}
