using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.IO;
using PropertiesManager.Model;
using System.Windows.Media;

namespace PropertiesManager.Services
{
    public static class ProjectInfoService
    {
        const string DIRECTORY = "D:/NXCUSTOM/temp";
        const string PROJ_INFO_FILENAME = "project_info.data";
        public static ProjectInfoModel ReadFromFile()
        {
            string fullPathFileName = Path.Combine(DIRECTORY, PROJ_INFO_FILENAME);
            if(!File.Exists(fullPathFileName))
            {
                string message = $"File not found: {fullPathFileName}";
                throw new FileNotFoundException(message);
            }

            Dictionary<string, string> result = new Dictionary<string, string>();
            string[] keys = new string[] { "Model", "Part", "CodePrefix", "Designer" };

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
                NxDrawing.ShowMessageBox(title, message, NXOpen.NXMessageBox.DialogType.Error);
            }

            return new ProjectInfoModel
            {
                Model = result["Model"],
                Part = result["Part"],
                CodePrefix = result["CodePrefix"],
                Designer = result["Designer"]
            };
        }

        public static void WriteToFile(List<string> projectInfoToText)
        {
            try
            {
                Directory.CreateDirectory(DIRECTORY);
                string fullPathFileName = Path.Combine(DIRECTORY, PROJ_INFO_FILENAME);

                File.WriteAllLines(fullPathFileName, projectInfoToText);

                NxDrawing.ShowMessageBox(
                    "✅Project info successfully saved.", 
                    "Success", 
                    NXOpen.NXMessageBox.DialogType.Information);
            }
            catch (IOException ex)
            {
                string message = $"Error writing to file: {ex.Message}";
                string title = "Error writing file";
                NxDrawing.ShowMessageBox(title, message, NXOpen.NXMessageBox.DialogType.Error);                
            }
        }
    }
}
