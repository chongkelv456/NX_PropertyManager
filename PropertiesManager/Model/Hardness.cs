using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;
using PropertiesManager.Constants;

namespace PropertiesManager.Model
{
    public class Hardness
    {
        private List<string> lists = new List<string>();

        public Hardness()
        {
            lists.Add(Const.HRC.HYPHEN);
            lists.Add(Const.HRC.THIRTYFIVE_FOURTY);
            lists.Add(Const.HRC.FIFTYTWO_FIFTYFOUR);
            lists.Add(Const.HRC.FIFTYSEVEN_FIFTYNINE);
            lists.Add(Const.HRC.FIFTYEIGHT_SIXTY);
            lists.Add(Const.HRC.SIXTY_SIXTYTHREE);
            lists.Add(Const.HRC.SIXTYTWO_SIXTYFIVE);
        }
        public static List<string> Get 
        {
            get
            {
                Hardness hardness = new Hardness();
                return hardness.lists;
            }
        }
    }
}
