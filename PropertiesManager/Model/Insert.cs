using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Insert
    {
        private List<string> inserts = new List<string>();

        public Insert()
        {
            inserts.Add("DIE INSERT");
            inserts.Add("FORMING INSERT");
            inserts.Add("BURRING INSERT");
            inserts.Add("DEBURR INSERT");
            inserts.Add("CHAMFER INSERT");
            inserts.Add("BENDING INSERT");
            inserts.Add("SIDE PIERCE INSERT");
            inserts.Add("RIVETING INSERT");
            inserts.Add("PUNHLD INSERT");
            inserts.Add("STR INSERT");
            inserts.Add("MARKING INSERT");
            inserts.Add("CUTTING PUNCH");
            inserts.Add("PROFILE PUNCH");
            inserts.Add("FORMING PUNCH");
            inserts.Add("PILOT");
            inserts.Add("MATERIAL GUIDE-F/R");
            inserts.Add("MATERIAL GUIDE-F");
            inserts.Add("MATERIAL GUIDE-R");
            inserts.Add("MISFEED SENSOR LEVER");
            inserts.Add("MISFEED SENSOR PLT");
            inserts.Add("MISFEED SENSOR STAND");
            inserts.Add("MISFEED SENSOR GUIDE");

            inserts.Sort();
        }

        public List<string> Get { get => inserts; }
    }
}
