using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;

namespace PropertiesManager.Model
{
    public class Shoe
    {
        private List<string> shoes = new List<string>();
        
        public Shoe()
        {
            shoes.Add(Controller.UPPER_SHOE);
            shoes.Add(Controller.LOWER_SHOE);
            shoes.Add(Controller.PARALLEL_BAR);
            shoes.Add(Controller.LOWER_COMMON_PLATE);
        }

        public List<string> Get { get => shoes;}
    }
}
