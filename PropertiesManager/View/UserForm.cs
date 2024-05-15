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
        public string TextModel { get => txtModel.Text; }
        public string TextPart { get => textPart.Text; }
        public string TextCodePrefix { get => textCodePrefix.Text; }
        public string TextDesginer { get => cboDesign.SelectedItem.ToString(); }
        public bool IsFilledTxtModel { get => !String.IsNullOrEmpty(txtModel.Text); }
        public bool IsFilledTextPart { get => !String.IsNullOrEmpty(textPart.Text); }
        public bool IsFilledCodePrefix { get => !String.IsNullOrEmpty(textCodePrefix.Text); }
        public bool IsFilledDesigner { get => !String.IsNullOrEmpty(cboDesign.SelectedItem.ToString()); }
        public void SetApplyButtonEnable(bool isEnable)
        {
            btnApply.Enabled = isEnable;
        }
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
            this.Close();
        }

        private void txtModel_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void textPart_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void textCodePrefix_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void cboDesign_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }
    }
}
