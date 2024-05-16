using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Shoe
    {
        private List<string> shoes = new List<string>();

        public Shoe()
        {
            shoes.Add("UPPER SHOE");
            shoes.Add("LOWER SHOE");
            shoes.Add("PARALLEL BAR");
            shoes.Add("LOWER COMMON PLATE");
        }

        public List<string> Get { get => shoes;}
    }
}
