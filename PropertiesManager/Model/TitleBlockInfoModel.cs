using NXOpen.Layout2d;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Model
{
    public class TitleBlockInfoModel
    {
        public string Model { get; set; }
        public string Part { get; set; }
        public string ItemName { get; set; }
        public string DrawingCode { get; set; }
        public string Material { get; set; }
        public string HRC { get; set; }
        public string Quantity { get; set; }
        public string DesignBy { get; set; }
        public string Thickness { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }
        public string DesignDate { get; set; }
        public string PartType { get; set; }
        public int StationNumber { get; set; }
        public string CodePrefix { get; set; }
        public string DirectoryPath { get; set; }
    }
}
