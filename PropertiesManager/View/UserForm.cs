using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PropertiesManager.Control;

namespace PropertiesManager.View
{
    public partial class UserForm : Form
    {
        private Controller control;        
        public UserForm(Controller control)
        {            
            InitializeComponent();
            this.control = control;
            cboDesign.DataSource = control.GetDesigners();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            control.Apply();
        }
    }
}
