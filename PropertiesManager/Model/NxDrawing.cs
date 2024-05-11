using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Control;
using NXOpen;
using NXOpen.UF;
using NXOpenUI;

namespace PropertiesManager.Model
{    
    public class NxDrawing
    {
        private Controller control;
        private Session session;
        private UI ui;

        public NxDrawing(Controller control)
        {
            this.control = control;
            session = Session.GetSession();
            ui = UI.GetUI();
        }

        public void NXMessage(string message, string title, NXMessageBox.DialogType dialogType)
        {
            ui.NXMessageBox.Show(title, dialogType, message);
        }
    }
}
