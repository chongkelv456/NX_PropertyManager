using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PropertiesManager.View;
using PropertiesManager.Model;

namespace PropertiesManager.Control
{
    public class Controller
    {
        private UserForm uf;
        private NxDrawing drawing;
        private Designer designer;
        private PartType partType;
        private Plate plate;
        private Shoe shoe;
        private Material material;
        private Hardness hardness;
        private Insert insert;
        private WCblk wcblk;
        private Other other;

        public const string SHOE = "SHOE";
        public const string PLATE = "PLATE";
        public const string INSERT = "INSERT";
        public const string WCBLK = "W/C BLK";
        public const string OTHERS = "OTHERS";
        public const string MODEL = "MODEL";
        public const string PART = "PART";
        public const string CODE_PREFIX = "CODE_PREFIX";
        public const string DESIGNER = "DESIGNER";

        const string DIRECTORY = @"D:\NXCUSTOM\temp";
        const string INFO_FILENAME = "project_info.data";

        public Controller()
        {
            //System.Diagnostics.Debugger.Launch();
            designer = new Designer();
            partType = new PartType();
            plate = new Plate();
            shoe = new Shoe();
            material = new Material();
            hardness = new Hardness();
            insert = new Insert();
            wcblk = new WCblk();
            other = new Other();

            uf = new UserForm(this);
            drawing = new NxDrawing(this);
            uf.FillProjectInfo();
            uf.ShowDialog();

        }

        public void Apply()
        {
            var message = "Yeay, you have pressed APPLY!\n";
            var title = "Information";
            List<string> info = new List<string>();
            info.Add(uf.TextModel);
            info.Add(uf.TextPart);
            info.Add(uf.TextCodePrefix);
            info.Add(uf.TextDesginer);
            info.ForEach(x => message += x + "\n");
            NXOpen.NXMessageBox.DialogType dialogType = NXOpen.NXMessageBox.DialogType.Information;
            drawing.NXMessage(message, title, dialogType);
        }

        public List<string> GetDesigners()
        {
            return designer.Get;
        }

        public List<string> GetPartTypes()
        {
            return partType.Get;
        }

        public List<string> GetPlates()
        {
            return plate.Get;
        }

        public List<string> GetShoes()
        {
            return shoe.Get;
        }
        public List<string> GetMaterials()
        {
            return material.Get;
        }
        public List<string> GetHardness()
        {
            return hardness.Get;
        }
        public List<string> GetInserts()
        {
            return insert.Get;
        }
        public List<string> GetWCblks()
        {
            return wcblk.Get;
        }
        public List<string> GetOthers()
        {
            return other.Get;
        }

        public void ValidateApplyButton()
        {
            //System.Diagnostics.Debugger.Launch();
            bool isProjectInfoFilled = uf.IsFilledTxtModel &&
                 uf.IsFilledTextPart &&
                 uf.IsFilledCodePrefix &&
                 uf.IsFilledDesigner;

            bool isDrawingInfoFilled = uf.IsFilledPartType &&
                uf.IsFilledStnNo &&
                uf.IsFilledItemName &&
                uf.IsFilledDwgCode &&
                uf.IsFilledMaterial &&
                uf.IsFilledHRC &&
                uf.IsFilledThk &&
                uf.IsFilledWidth &&
                uf.IsFilledLength &&
                uf.IsFilledQty;

            uf.SetApplyButtonEnable(isProjectInfoFilled && isDrawingInfoFilled);

            if (isProjectInfoFilled)
            {
                List<string> info = new List<string>();
                info.Add(uf.TextModel);
                info.Add(uf.TextPart);
                info.Add(uf.TextCodePrefix);
                info.Add(uf.TextDesginer);
                WriteToFile(info);
            }
        }

        public void WriteToFile(List<string> projectInfoToText)
        {
            if (!Directory.Exists(DIRECTORY))
            {
                Directory.CreateDirectory(DIRECTORY);
            }
            string fullPathFileName = Path.Combine(DIRECTORY, INFO_FILENAME);
            TextWriter tw = null;
            try
            {
                tw = new StreamWriter(fullPathFileName);
                foreach (string line in projectInfoToText)
                {
                    tw.WriteLine(line);
                }
            }
            catch (IOException ex)
            {
                string message = $"Error writing to file: {ex.Message}";
                string title = "Error writing file";
                drawing.NXMessage(message, title, NXOpen.NXMessageBox.DialogType.Error);
            }
            finally
            {
                tw?.Close();
            }
        }

        public Dictionary<string, string> ReadFromFile()
        {
            string fullPathFileName = Path.Combine(DIRECTORY, INFO_FILENAME);
            if (!File.Exists(fullPathFileName))
            {
                return null;
            }

            Dictionary<string, string> result = new Dictionary<string, string>();
            string[] keys = new string[] { MODEL, PART, CODE_PREFIX, DESIGNER };

            try
            {
                using (StreamReader reader = new StreamReader(fullPathFileName))
                {
                    string value;
                    foreach (string key in keys)
                    {
                        value = reader.ReadLine();
                        result.Add(key, value);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                string message = $"File not found: {ex.Message}";
                string title = "Error file not found";
                drawing.NXMessage(message, title, NXOpen.NXMessageBox.DialogType.Error);
            }

            return result;
        }
    }
}
