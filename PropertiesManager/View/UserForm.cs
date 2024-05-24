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
        public string TextDesginer { get => cboDesign.Text; set => cboDesign.SelectedItem = value; }
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
        private Dictionary<string, string> projInfo;
        public void SetApplyButtonEnable(bool isEnable)
        {
            btnApply.Enabled = isEnable;
        }
        public UserForm(Controller control)
        {
            InitializeComponent();
            this.control = control;
            projInfo = control.ReadFromFile();
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
            control.AskTextChangedAction();
        }

        private void textPart_TextChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();
        }

        private void textCodePrefix_TextChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();
            //txtDwgCode_UpdateChange();
        }

        private void cboDesign_TextChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();
        }

        private void cboPartType_TextChanged(object sender, EventArgs e)
        {

            control.AskTextChangedAction();

            string selectedPartType = cboPartType.SelectedItem.ToString();
            switch (selectedPartType)
            {
                case Controller.SHOE:
                    PopulateItemNameDataSource(cboItemName, control.GetShoes());
                    cboMaterial.SelectedItem = Controller.S50C;
                    numericStnNo.Value = 0;
                    pictureBox1.Image = Resource1.Shoe;
                    break;
                case Controller.PLATE:
                    PopulateItemNameDataSource(cboItemName, control.GetPlates());
                    cboMaterial.SelectedItem = Controller.GOA;
                    numericStnNo.Value = 1;
                    pictureBox1.Image = Resource1.Plate;
                    break;
                case Controller.INSERT:
                    PopulateItemNameDataSource(cboItemName, control.GetInserts());
                    cboMaterial.SelectedItem = Controller.DC53;
                    numericStnNo.Value = 1;
                    pictureBox1.Image = Resource1.Insert;
                    break;
                case Controller.WCBLK:
                    PopulateItemNameDataSource(cboItemName, control.GetWCblks());
                    cboMaterial.SelectedItem = Controller.DC53;
                    numericStnNo.Value = 1;
                    pictureBox1.Image = Resource1.WCBlk;
                    break;
                case Controller.OTHERS:
                    PopulateItemNameDataSource(cboItemName, control.GetOthers());
                    cboMaterial.SelectedItem = Controller.EG2;
                    numericStnNo.Value = 0;
                    pictureBox1.Image = Resource1.Other;
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
            control.AskTextChangedAction();
        }

        private void cboItemName_TextChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();

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
            control.AskTextChangedAction(false);
        }

        private void txtMaterial_TextChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();
        }

        private void txtHRC_TextChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();
        }

        private void txtThk_TextChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();
        }

        private void numericStnNo_ValueChanged(object sender, EventArgs e)
        {
            control.AskTextChangedAction();            
        }

        public void txtDwgCode_UpdateChange()
        {
            //System.Diagnostics.Debugger.Launch();
            string prefix = TextCodePrefix;
            string runningNumber = GetRunningNumber();
            string stnNo = numericStnNo.Value >= 10 ? TextStaNo : "0" + TextStaNo;
            TextDwgCode = prefix + runningNumber;
        }

        private string GetRunningNumber()
        {
            const string THREE_THOUSAND_ONE = "3001";
            const string ELEVEN = "11";
            const string TWENTYONE = "21";
            const string ONE = "01";
            const string TWO = "02";
            const string THREE = "03";
            const string FOUR = "04";
            const string FIVE = "05";
            const string SIX = "06";
            const string SEVEN = "07";
            const string EIGHT = "08";

            string stnNo = numericStnNo.Value >= 10 ? TextStaNo : "0" + TextStaNo;
            if (TextPartType.Equals(Controller.WCBLK))
            {
                return THREE_THOUSAND_ONE;
            }else if (TextPartType.Equals(Controller.INSERT))
            {
                return stnNo + TWENTYONE;
            }else if (TextPartType.Equals(Controller.SHOE))
            {
                switch (TextItemName)
                {
                    case Controller.UPPER_SHOE:
                        return stnNo + ONE;
                        break;
                    case Controller.LOWER_SHOE:
                        return stnNo + TWO;
                        break;
                    case Controller.LOWER_COMMON_PLATE:
                        return stnNo + THREE;
                        break;
                    case Controller.PARALLEL_BAR:
                        return stnNo + FOUR;
                        break;
                    default:
                        break;
                }
                
            }else if (TextPartType.Equals(Controller.OTHERS))
            {
                return stnNo + ELEVEN;
            }
            // Remaining the PLATE clause
            switch (TextItemName)
            {
                case Controller.UPPER_PAD_SPACER:
                    return stnNo + ONE;
                    break;
                case Controller.UPPER_PAD:
                    return stnNo + TWO;
                    break;
                case Controller.PUNCH_HOLDER:
                    return stnNo + THREE;
                    break;
                case Controller.BOTTOMING_PLATE:
                    return stnNo + FOUR;
                    break;
                case Controller.STRIPPER_PLATE:
                    return stnNo + FIVE;
                    break;
                case Controller.DIE_PLATE_R:
                case Controller.DIE_PLATE_F:
                case Controller.DIE_PLATE:
                    return stnNo + SIX;
                    break;
                case Controller.LOWER_PAD:
                    return stnNo + SEVEN;
                    break;
                case Controller.LOWER_PAD_SPACER:
                    return stnNo + EIGHT;
                    break;
                default:
                    break;   
            }
            return stnNo;
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
