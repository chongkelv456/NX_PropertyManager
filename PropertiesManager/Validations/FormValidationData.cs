using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Validations
{
    /// <summary>
    /// Form Validation Data
    /// </summary>
    public class FormValidationData
    {
        // Path
        public string Path { get; set; }

        // Drawing Information
        public string PartType { get; set; }
        public string StationNumber { get; set; }
        public string ItemName { get; set; }
        public string DrawingCode { get; set; }
        public string Material { get; set; }
        public string Hardness { get; set; }
        public string Thickness { get; set; }
        public string Width { get; set; }
        public string Length { get; set; }

        // Project Information
        public string Model { get; set; }
        public string Part { get; set; }
        public string CodePrefix { get; set; }
        public string Designer { get; set; }
    }
}
