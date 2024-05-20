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
        public string TextModel { get => txtModel.Text; set => txtModel.Text = value; }
        public string TextPart { get => txtPart.Text; set => txtPart.Text = value; }
        public string TextCodePrefix { get => txtCodePrefix.Text; set => txtCodePrefix.Text = value; }
        public string TextDesginer { get => cboDesign.SelectedItem.ToString(); set => cboDesign.SelectedItem = value; }
        public string TextDwgCode { get => txtDwgCode.Text; set => txtDwgCode.Text = value; }
        public string TextStaNo { get => numericStnNo.Value.ToString(); }
        public string TextItemName { get => cboItemName.Text; }
        public string TextPartType { get => cboPartType.Text; }
        public string TextMaterial { get => cboMaterial.Text; }
        public string TextHRC { get => cboHRC.Text; }
        public string TextThk { get => txtThk.Text; set => txtThk.Text = value; }
        public string TextWidth { get => txtWidth.Text; set => txtWidth.Text = value; }
        public string TextLength { get => txtLength.Text; set => txtLength.Text = value; }
        public string TextQuantity { get => txtQuantity.Text; }
        public bool IsFilledTxtModel { get => !String.IsNullOrEmpty(txtModel.Text); }
        public bool IsFilledTextPart { get => !String.IsNullOrEmpty(txtPart.Text); }
        public bool IsFilledCodePrefix { get => !String.IsNullOrEmpty(txtCodePrefix.Text); }
        public bool IsFilledDesigner { get => !String.IsNullOrEmpty(cboDesign.Text); }
        public bool IsFilledPartType { get => !String.IsNullOrEmpty(cboPartType.Text); }
        public bool IsFilledStnNo { get => !String.IsNullOrEmpty(numericStnNo.Value.ToString()); }
        public bool IsFilledItemName { get => !String.IsNullOrEmpty(cboItemName.Text); }
        public bool IsFilledDwgCode { get => !String.IsNullOrEmpty(txtDwgCode.Text); }
        public bool IsFilledMaterial { get => !String.IsNullOrEmpty(cboMaterial.Text); }
        public bool IsFilledHRC { get => !String.IsNullOrEmpty(cboHRC.Text); }
        public bool IsFilledThk { get => !String.IsNullOrEmpty(txtThk.Text); }
        public bool IsFilledWidth { get => !String.IsNullOrEmpty(txtWidth.Text); }
        public bool IsFilledLength { get => !String.IsNullOrEmpty(txtLength.Text); }
        public bool IsFilledQty { get => !String.IsNullOrEmpty(txtQuantity.Text); }
        public void SetApplyButtonEnable(bool isEnable)
        {
            btnApply.Enabled = isEnable;
        }
        public UserForm(Controller control)
        {
            InitializeComponent();
            this.control = control;
        }

        public UserForm()
        {

        }

        public void InitialLoadComboContents()
        {
            cboDesign.DataSource = control.GetDesigners();
            cboPartType.DataSource = control.GetPartTypes();
            cboItemName.DataSource = control.GetShoes();
            cboMaterial.DataSource = control.GetMaterials();
            cboHRC.DataSource = control.GetHardness();
        }

        public void FillProjectInfo()
        {
            Dictionary<string, string> projInfo = control.ReadFromFile();
            if (projInfo == null)
            {
                return;
            }

            TextModel = projInfo[Controller.MODEL];
            TextPart = projInfo[Controller.PART];
            TextCodePrefix = projInfo[Controller.CODE_PREFIX];
            TextDesginer = projInfo[Controller.DESIGNER];
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
            txtDwgCode_UpdateChange();
        }

        private void cboDesign_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void cboPartType_TextChanged(object sender, EventArgs e)
        {

            control.ValidateApplyButton();

            string selectedPartType = cboPartType.SelectedItem.ToString();
            switch (selectedPartType)
            {
                case Controller.SHOE:
                    PopulateItemNameDataSource(cboItemName, control.GetShoes());
                    cboMaterial.SelectedItem = Controller.S50C;
                    numericStnNo.Value = 0;
                    break;
                case Controller.PLATE:
                    PopulateItemNameDataSource(cboItemName, control.GetPlates());
                    cboMaterial.SelectedItem = Controller.GOA;
                    numericStnNo.Value = 1;
                    break;
                case Controller.INSERT:
                    PopulateItemNameDataSource(cboItemName, control.GetInserts());
                    cboMaterial.SelectedItem = Controller.DC53;
                    numericStnNo.Value = 1;
                    break;
                case Controller.WCBLK:
                    PopulateItemNameDataSource(cboItemName, control.GetWCblks());
                    cboMaterial.SelectedItem = Controller.DC53;
                    numericStnNo.Value = 1;
                    break;
                case Controller.OTHERS:
                    PopulateItemNameDataSource(cboItemName, control.GetOthers());
                    cboMaterial.SelectedItem = Controller.EG2;
                    numericStnNo.Value = 0;
                    break;
                default:
                    break;
            }
        }

        private void PopulateItemNameDataSource(ComboBox cboItemName, List<string> list)
        {
            cboItemName.DataSource = list;
        }

        private void txtStnNo_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
        }

        private void cboItemName_TextChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();

            string selectedMaterial = cboMaterial.Text;
            switch (selectedMaterial)
            {
                case Controller.MILD_STELL:
                case Controller.S50C:
                case Controller.EG2:
                    cboHRC.SelectedItem = Controller.HYPHEN;
                    break;
                case Controller.NAK80:
                    cboHRC.SelectedItem = Controller.THIRTYFIVE_FOURTY;
                    break;
                case Controller.GOA:
                    cboHRC.SelectedItem = Controller.FIFTYTWO_FIFTYFOUR;
                    break;
                case Controller.DC53:
                    cboHRC.SelectedItem = Controller.FIFTYEIGHT_SIXTY;
                    break;
                case Controller.SKD11:
                    cboHRC.SelectedItem = Controller.SIXTY_SIXTYTHREE;
                    break;
                case Controller.YXR3:
                    cboHRC.SelectedItem = Controller.FIFTYEIGHT_SIXTY;
                    break;
                case Controller.YXM1:
                    cboHRC.SelectedItem = Controller.FIFTYEIGHT_SIXTY;
                    break;
                case Controller.DEX20:
                    cboHRC.SelectedItem = Controller.SIXTYTWO_SIXTYFIVE;
                    break;
                default:
                    break;

            }
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

        private void numericStnNo_ValueChanged(object sender, EventArgs e)
        {
            control.ValidateApplyButton();
            txtDwgCode_UpdateChange();
        }

        public void txtDwgCode_UpdateChange()
        {
            //System.Diagnostics.Debugger.Launch();
            string prefix = TextCodePrefix;
            string stnNo = numericStnNo.Value >= 10 ? TextStaNo : "0"+TextStaNo;
            TextDwgCode = prefix + stnNo;
        }

        private void btnThkPick_Click(object sender, EventArgs e)
        {
            TextThk = control.GetDrawing().GetTextFromDimension();
        }

        private void btnWidthPick_Click(object sender, EventArgs e)
        {
            TextWidth = control.GetDrawing().GetTextFromDimension();
        }

        private void btnLengthPick_Click(object sender, EventArgs e)
        {
            TextLength = control.GetDrawing().GetTextFromDimension();
        }
    }
}
