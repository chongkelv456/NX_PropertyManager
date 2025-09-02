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
       
        private bool debugMode = false;                                                       

        // FileIO
        const string DIRECTORY = @"D:\NXCUSTOM\temp";
        const string INFO_FILENAME = "project_info.data";

        public Controller()
        {                        
            if(debugMode)
                System.Diagnostics.Debugger.Launch();

            uf = new UserForm(this);
            drawing = new NxDrawing(this);
            
            //uf.FillProjectInfo();
            //uf.txtDwgCode_UpdateChange();

            uf.Show();
        }

        public void Apply()
        {         
            var title_infos = drawing.GetAttributesInfos(
                NxDrawing.CATEGORY_TITLE, 
                drawing.GetTitle_KeyValue());
            drawing.SetAttributes(title_infos);

            var tool_infos = drawing.GetAttributesInfos(NxDrawing.CATEGORY_TOOL, drawing.GetTool_KeyValue());
            drawing.SetAttributes(tool_infos);

            drawing.DeleteStdPartAttribute();
        }                   

        public UserForm GetUserForm()
        {
            return uf;
        }

        public NxDrawing GetDrawing()
        {
            return drawing;
        }

        public void StdApply()
        {
            var tool_infos = drawing.GetAttributesInfos(
                NxDrawing.CATEGORY_TOOL, 
                drawing.GetStandardPart_KeyValue());
            drawing.SetAttributes(tool_infos);
        }
    }
}
