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

        public const string S50C = "S50C";
        public const string DC53 = "DC53";
        public const string GOA = "GOA";
        public const string MILD_STELL = "MILD STELL";
        public const string NAK80 = "NAK80";
        public const string SKD11 = "SKD11";
        public const string YXR3 = "YXR3";
        public const string YXM1 = "YXM1";
        public const string DEX20 = "DEX20";
        public const string EG2 = "E.G. 2.0t";


        public const string HYPHEN = "-";
        public const string THIRTYFIVE_FOURTY = "35~40";
        public const string FIFTYTWO_FIFTYFOUR = "52~54";
        public const string FIFTYSEVEN_FIFTYNINE = "57~59";
        public const string FIFTYEIGHT_SIXTY = "58~60";
        public const string SIXTY_SIXTYTHREE = "60~63";
        public const string SIXTYTWO_SIXTYFIVE = "62~65";

        public const string UPPER_PAD_SPACER = "UPPER PAD SPACER";
        public const string UPPER_PAD = "UPPER PAD";
        public const string PUNCH_HOLDER = "PUNCH HOLDER";
        public const string BOTTOMING_PLATE = "BOTTOMING PLATE";
        public const string STRIPPER_PLATE = "STRIPPER PLATE";
        public const string DIE_PLATE = "DIE PLATE";
        public const string DIE_PLATE_R = "DIE PLATE-R";
        public const string DIE_PLATE_F = "DIE PLATE-F";
        public const string LOWER_PAD = "LOWER PAD";
        public const string LOWER_PAD_SPACER = "LOWER PAD SPACER";

        public const string UPPER_SHOE = "UPPER SHOE";
        public const string LOWER_SHOE = "LOWER SHOE";
        public const string PARALLEL_BAR = "PARALLEL BAR";
        public const string LOWER_COMMON_PLATE = "LOWER COMMON PLATE";

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
            uf.InitialLoadComboContents();
            uf.FillProjectInfo();
            uf.txtDwgCode_UpdateChange();

            uf.Show();
        }

        public void Apply()
        {
            //var message = "Yeay, you have pressed APPLY!\n";
            //var title = "Information";
            //List<string> info = new List<string>();
            //info.Add(uf.TextModel);
            //info.Add(uf.TextPart);
            //info.Add(uf.TextCodePrefix);
            //info.Add(uf.TextDesginer);
            //info.ForEach(x => message += x + "\n");

            var title_infos = drawing.GetAttributesInfos(NxDrawing.CATEGORY_TITLE, drawing.GetTitle_KeyValue());
            drawing.SetAttributes(title_infos);

            var tool_infos = drawing.GetAttributesInfos(NxDrawing.CATEGORY_TOOL, drawing.GetTool_KeyValue());
            drawing.SetAttributes(tool_infos);
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

        private bool isProjectInfoFilled => uf.IsFilledTxtModel &&
                 uf.IsFilledTextPart &&
                 uf.IsFilledCodePrefix &&
                 uf.IsFilledDesigner;

        private bool isDrawingInfoFilled => uf.IsFilledPartType &&
                uf.IsFilledStnNo &&
                uf.IsFilledItemName &&
                uf.IsFilledDwgCode &&
                uf.IsFilledMaterial &&
                uf.IsFilledHRC &&
                uf.IsFilledThk &&
                uf.IsFilledWidth &&
                uf.IsFilledLength &&
                uf.IsFilledQty;

        public void AskTextChangedAction()
        {
            //System.Diagnostics.Debugger.Launch();            
            uf.SetApplyButtonEnable(isProjectInfoFilled && isDrawingInfoFilled);
            uf.txtDwgCode_UpdateChange();
            UpdateProjectInfoToFile();
        }

        private void UpdateProjectInfoToFile()
        {
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

        public UserForm GetUserForm()
        {
            return uf;
        }

        public NxDrawing GetDrawing()
        {
            return drawing;
        }
    }
}
