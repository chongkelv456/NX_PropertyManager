using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;
using PropertiesManager.Constants;

namespace PropertiesManager.Model
{
    public class ShoeItems
    {
        private List<string> lists = new List<string>();
        
        public ShoeItems()
        {
            lists.Add(Const.ShoeType.UPPER_SHOE);
            lists.Add(Const.ShoeType.LOWER_SHOE);
            lists.Add(Const.ShoeType.PARALLEL_BAR);
            lists.Add(Const.ShoeType.LOWER_COMMON_PLATE);
        }

        public static List<string> Get 
        {
            get
            {
                ShoeItems items = new ShoeItems();
                return items.lists;
            }
        
        }
    }
}
