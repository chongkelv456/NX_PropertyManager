using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class Hardness
    {
        private List<string> hardnesses = new List<string>();

        public Hardness()
        {
            hardnesses.Add("-");
            hardnesses.Add("35~40");
            hardnesses.Add("52~54");
            hardnesses.Add("57~59");
            hardnesses.Add("58~60");
            hardnesses.Add("60~63");
            hardnesses.Add("62~65");
        }
        public List<string> GetHardnesses { get => hardnesses; }
    }
}
