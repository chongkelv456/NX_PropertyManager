using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Insert
    {
        private List<string> lists = new List<string>();

        public Insert()
        {
            lists.Add("DIE INSERT");
            lists.Add("FORMING INSERT");
            lists.Add("BURRING INSERT");
            lists.Add("DEBURR INSERT");
            lists.Add("CHAMFER INSERT");
            lists.Add("BENDING INSERT");
            lists.Add("SIDE PIERCE INSERT");
            lists.Add("RIVETING INSERT");
            lists.Add("PUNHLD INSERT");
            lists.Add("STR INSERT");
            lists.Add("MARKING INSERT");
            lists.Add("CUTTING PUNCH");
            lists.Add("PROFILE PUNCH");
            lists.Add("FORMING PUNCH");
            lists.Add("PILOT");
            lists.Add("MATERIAL GUIDE-F/R");
            lists.Add("MATERIAL GUIDE-F");
            lists.Add("MATERIAL GUIDE-R");
            lists.Add("MISFEED SENSOR LEVER");
            lists.Add("MISFEED SENSOR PLT");
            lists.Add("MISFEED SENSOR STAND");
            lists.Add("MISFEED SENSOR GUIDE");

            lists.Sort();
        }

        public static List<string> Get 
        {
            get
            {
                Insert insert = new Insert();
                return insert.lists;
            }
        }
    }
}
