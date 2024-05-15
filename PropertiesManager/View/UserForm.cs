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
        public bool IsFilledPartType { get => !String.IsNullOrEmpty(cboPartType.SelectedItem.ToString()); }
        public bool IsFilledStnNo { get => !String.IsNullOrEmpty(txtStnNo.Text); }
        public bool IsFilledItemName { get => !String.IsNullOrEmpty(cboItemName.SelectedItem.ToString()); }
        public bool IsFilledDwgCode { get => !String.IsNullOrEmpty(txtDwgCode.Text); }
        public bool IsFilledMaaterial { get => !String.IsNullOrEmpty(cboMaterial.SelectedItem.ToString()); }
        public bool IsFilledHRC { get => !String.IsNullOrEmpty(cboHRC.SelectedItem.ToString()); }
        public bool IsFilledThk { get => !String.IsNullOrEmpty(txtThk.Text); }
        public bool IsFilledWidth { get => !String.IsNullOrEmpty(txtWidth.Text); }
        public bool IsFilledLength { get => !String.IsNullOrEmpty(txtLength.Text); }
        public bool IsFilledQtty { get => !String.IsNullOrEmpty(txtQuantity.Text); }
        public void SetApplyButtonEnable(bool isEnable)
        {
            btnApply.Enabled = isEnable;
        }
        public UserForm(Controller control)
        {
            InitializeComponent();
            this.control = control;
            cboDesign.DataSource = control.GetDesigners();
            cboPartType.DataSource = control.GetPartTypes();
            cboItemName.DataSource = control.GetShoes();
            cboMaterial.DataSource = control.GetMaterials();
            cboHRC.DataSource = control.GetHardness();
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

        private void cboPartType_TextChanged(object sender, EventArgs e)
        {
            const string SHOE = "Shoe";
            control.ValidateApplyButton();

            if (cboPartType.SelectedItem.ToString().Equals(SHOE, StringComparison.OrdinalIgnoreCase))
            {
                txtStnNo.Text = "0";
            }
            else
            {
                txtStnNo.Text = "1";
            }
        }

        private void txtStnNo_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void cboItemName_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void txtDwgCode_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void txtHRC_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void txtThk_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }
    }
}
