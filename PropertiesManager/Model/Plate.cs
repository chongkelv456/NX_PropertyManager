using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;
using PropertiesManager.Constants;

namespace PropertiesManager.Model
{
    public class Plate
    {
        private List<string> lists = new List<string>();

        public Plate()
        {
            lists.Add(Const.PlateType.UPPER_PAD_SPACER);
            lists.Add(Const.PlateType.UPPER_PAD);
            lists.Add(Const.PlateType.PUNCH_HOLDER);
            lists.Add(Const.PlateType.BOTTOMING_PLATE);
            lists.Add(Const.PlateType.STRIPPER_PLATE);
            lists.Add(Const.PlateType.DIE_PLATE);
            lists.Add(Const.PlateType.DIE_PLATE_R);
            lists.Add(Const.PlateType.DIE_PLATE_F);
            lists.Add(Const.PlateType.LOWER_PAD);
            lists.Add(Const.PlateType.LOWER_PAD_SPACER);
        }

        public static List<string> Get 
        {
            get
            {
                Plate plate = new Plate();
                return plate.lists;
            }
        }
    }
}
