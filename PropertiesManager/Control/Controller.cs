using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.View;
using PropertiesManager.Model;

namespace PropertiesManager.Control
{
    public class Controller
    {
        private UserForm uf;
        private NxDrawing drawing;
        private Designer designer;

        public Controller()
        {
            //System.Diagnostics.Debugger.Launch();
            designer = new Designer();
            uf = new UserForm(this);
            drawing = new NxDrawing(this);                        
            uf.ShowDialog();
        }

        public void Apply()
        {
            var message = "Yeay, you have pressed APPLY!";
            var title = "Information";
            NXOpen.NXMessageBox.DialogType dialogType = NXOpen.NXMessageBox.DialogType.Information;
            drawing.NXMessage(message, title, dialogType);
        }

        public List<string> GetDesigners()
        {
            return designer.GetDesingers;
        }
    }
}
