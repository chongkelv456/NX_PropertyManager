using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NXOpen;
using PropertiesManager.Control;
using PropertiesManager.Model;
using PropertiesManager.Services;
using PropertiesManager.Constants;
using PropertiesManager.Validations;

namespace PropertiesManager.View
{
    public partial class UserForm : Form
    {
        private readonly FormValidator _validator;
        private readonly PartTypeConfigService _partTypeService = new PartTypeConfigService();
        private Controller control;
        bool showDebugMessage = false; // Set to true to show debug messages
        public string GetPath => txtPath.Text.Trim();
        public string TextModel { get => txtModel.Text.Trim(); set => txtModel.Text = value; }
        public string TextPart { get => txtPart.Text.Trim(); set => txtPart.Text = value; }
        public string TextCodePrefix { get => txtCodePrefix.Text.Trim(); set => txtCodePrefix.Text = value; }
        public string TextDesginer { get => cboDesign.Text.Trim(); set => cboDesign.Text = value; }
        public string TextDwgCode { get => txtDwgCode.Text.Trim(); set => txtDwgCode.Text = value; }
        public string TextStaNo { get => numericStnNo.Value.ToString(); }
        public string TextItemName { get => cboItemName.Text.Trim(); }
        public string TextPartType { get => cboPartType.Text.Trim(); }
        public string TextMaterial { get => cboMaterial.Text.Trim(); }
        public string TextHRC { get => cboHRC.Text.Trim(); }
        public string TextThk { get => txtThk.Text.Trim(); set => txtThk.Text = value; }
        public string TextWidth { get => txtWidth.Text.Trim(); set => txtWidth.Text = value; }
        public string TextLength { get => txtLength.Text.Trim(); set => txtLength.Text = value; }
        public string TextQuantity { get => txtQuantity.Text.Trim(); }
        public string TextStandardPartItemName { get => cboStdItemName.Text.Trim(); }
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
            this.control = control;

            InitializeComponent();
            InitialLoadComboContents();

            _validator = new FormValidator();
        }

        private void InitializeCboHRC()
        {
            cboHRC.DataSource = Hardness.Get;
        }

        private void InitializeCboMaterial()
        {
            cboMaterial.DataSource = Model.Material.Get;
        }

        private void InitializeCboItemName()
        {
            cboItemName.DataSource = ShoeItems.Get;
        }

        private void InitializeCboPartType()
        {
            cboPartType.DataSource = PartType.Get;
        }

        private void InitializeCboDesign()
        {
            cboDesign.DataSource = Designer.Get;
        }

        public void InitialLoadComboContents()
        {
            InitializeCboDesign();
            InitializeCboPartType();
            InitializeCboItemName();
            InitializeCboMaterial();
            InitializeCboHRC();
            InitializeCboStdItemName();
        }

        private void InitializeCboStdItemName()
        {
            cboStdItemName.DataSource = StandardPart.Get;
        }

        public void FillProjectInfo()
        {
            if (projInfo == null)
            {
                return;
            }

            TextModel = projInfo[Const.ProjectInfo.MODEL];
            TextPart = projInfo[Const.ProjectInfo.PART];
            TextCodePrefix = projInfo[Const.ProjectInfo.CODE_PREFIX];
            TextDesginer = projInfo[Const.ProjectInfo.DESIGNER];
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
            UpdateBtnSaveProjetInfoState();
            CheckInputAndEnableApply();
        }

        private void UpdateBtnSaveProjetInfoState()
        {
            if (IsProjectInfoFilled())
            {
                btnSaveProjInfo.Enabled = true;
            }
            else
            {
                btnSaveProjInfo.Enabled = false;
            }
        }

        private void textPart_TextChanged(object sender, EventArgs e)
        {
            UpdateBtnSaveProjetInfoState();
            CheckInputAndEnableApply();
        }

        private void textCodePrefix_TextChanged(object sender, EventArgs e)
        {
            UpdateBtnSaveProjetInfoState();
            CheckInputAndEnableApply();
            txtDwgCode_UpdateChange();
        }

        private void cboDesign_TextChanged(object sender, EventArgs e)
        {
            UpdateBtnSaveProjetInfoState();
            CheckInputAndEnableApply();
        }

        private void cboPartType_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
            string selectedPartType = cboPartType.SelectedItem.ToString();
            switch (selectedPartType)
            {
                case Const.PartType.SHOE:
                    PopulateItemNameDataSource(cboItemName, ShoeItems.Get);
                    cboMaterial.SelectedItem = Const.Material.S50C;
                    numericStnNo.Value = 0;
                    pictureBox1.Image = Resource1.Shoe;
                    ClearMaterialTextBox();
                    break;
                case Const.PartType.PLATE:
                    PopulateItemNameDataSource(cboItemName, Plate.Get);
                    cboMaterial.SelectedItem = Const.Material.GOA;
                    numericStnNo.Value = 1;
                    pictureBox1.Image = Resource1.Plate;
                    ClearMaterialTextBox();
                    break;
                case Const.PartType.INSERT:
                    PopulateItemNameDataSource(cboItemName, Insert.Get);
                    cboMaterial.SelectedItem = Const.Material.DC53;
                    numericStnNo.Value = 1;
                    pictureBox1.Image = Resource1.Insert;
                    ClearMaterialTextBox();
                    break;
                case Const.PartType.WCBLK:
                    PopulateItemNameDataSource(cboItemName, WCblk.Get);
                    cboMaterial.SelectedItem = Const.Material.DC53;
                    numericStnNo.Value = 1;
                    pictureBox1.Image = Resource1.WCBlk;
                    ClearMaterialTextBox();
                    break;
                case Const.PartType.OTHERS:
                    PopulateItemNameDataSource(cboItemName, Other.Get);
                    cboMaterial.SelectedItem = Const.Material.EG2;
                    numericStnNo.Value = 0;
                    pictureBox1.Image = Resource1.Other;
                    SetMaterialTextBoxHyphen();
                    break;
                case Const.PartType.ASM:
                    PopulateItemNameDataSource(cboItemName, Assembly.Get);
                    cboMaterial.SelectedItem = Const.AsmType.MAIN_ASSEMBLY;
                    numericStnNo.Value = 0;
                    pictureBox1.Image = Resource1.Shoe;
                    cboMaterial.Text = Const.HRC.HYPHEN;
                    SetMaterialTextBoxHyphen();
                    break;
                default:
                    break;
            }
        }

        private void SetMaterialTextBoxHyphen()
        {
            txtThk.Text = Const.HRC.HYPHEN;
            txtWidth.Text = Const.HRC.HYPHEN;
            txtLength.Text = Const.HRC.HYPHEN;
        }

        private void ClearMaterialTextBox()
        {
            txtThk.Text = string.Empty;
            txtWidth.Text = string.Empty;
            txtLength.Text = string.Empty;
        }

        private void PopulateItemNameDataSource(ComboBox cboItemName, List<string> list)
        {
            cboItemName.DataSource = list;
        }        

        private void cboItemName_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
            txtDwgCode_UpdateChange();
        }

        private void txtDwgCode_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
        }        

        private void txtThk_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
        }

        private void txtWidth_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
        }

        private void txtLength_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
        }

        private void numericStnNo_ValueChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
            txtDwgCode_UpdateChange();
        }

        public void txtDwgCode_UpdateChange()
        {
            string prefix = TextCodePrefix;
            string runningNumber = GetRunningNumber();
            string stnNo = numericStnNo.Value >= 10 ? TextStaNo : "0" + TextStaNo;
            TextDwgCode = prefix + runningNumber;
        }

        private string GetRunningNumber()
        {
            const string THREE_THOUSAND_ONE = "3001";
            const string FOUR_ZERO = "0000";
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
            if (TextPartType.Equals(Const.PartType.WCBLK))
            {
                return THREE_THOUSAND_ONE;
            }
            else if (TextPartType.Equals(Const.PartType.INSERT))
            {
                return stnNo + ELEVEN;
            }
            else if (TextPartType.Equals(Const.PartType.SHOE))
            {
                switch (TextItemName)
                {
                    case Const.ShoeType.UPPER_SHOE:
                        return stnNo + ONE;
                    case Const.ShoeType.LOWER_SHOE:
                        return stnNo + TWO;
                    case Const.ShoeType.LOWER_COMMON_PLATE:
                        return stnNo + THREE;
                    case Const.ShoeType.PARALLEL_BAR:
                        return stnNo + FOUR;
                    default:
                        break;
                }

            }
            else if (TextPartType.Equals(Const.PartType.OTHERS))
            {
                return stnNo + TWENTYONE;
            }
            else if (TextPartType.Equals(Const.PartType.ASM))
            {
                return FOUR_ZERO;
            }
            // Remaining the PLATE clause
            switch (TextItemName)
            {
                case Const.PlateType.UPPER_PAD_SPACER:
                    return stnNo + ONE;
                case Const.PlateType.UPPER_PAD:
                    return stnNo + TWO;
                case Const.PlateType.PUNCH_HOLDER:
                    return stnNo + THREE;
                case Const.PlateType.BOTTOMING_PLATE:
                    return stnNo + FOUR;
                case Const.PlateType.STRIPPER_PLATE:
                    return stnNo + FIVE;
                case Const.PlateType.DIE_PLATE_R:
                case Const.PlateType.DIE_PLATE_F:
                case Const.PlateType.DIE_PLATE:
                    return stnNo + SIX;
                case Const.PlateType.LOWER_PAD:
                    return stnNo + SEVEN;
                case Const.PlateType.LOWER_PAD_SPACER:
                    return stnNo + EIGHT;
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

        private void cboMaterial_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();

            string selectedMaterial = cboMaterial.Text;
            switch (selectedMaterial)
            {
                case Const.Material.MILD_STELL:
                case Const.Material.S50C:
                case Const.Material.EG2:
                    cboHRC.SelectedItem = Const.HRC.HYPHEN;
                    break;
                case Const.Material.NAK80:
                    cboHRC.SelectedItem = Const.HRC.THIRTYFIVE_FOURTY;
                    break;
                case Const.Material.GOA:
                    cboHRC.SelectedItem = Const.HRC.FIFTYTWO_FIFTYFOUR;
                    break;
                case Const.Material.DC53:
                    cboHRC.SelectedItem = Const.HRC.FIFTYEIGHT_SIXTY;
                    break;
                case Const.Material.SKD11:
                    cboHRC.SelectedItem = Const.HRC.SIXTY_SIXTYTHREE;
                    break;
                case Const.Material.YXR3:
                    cboHRC.SelectedItem = Const.HRC.FIFTYEIGHT_SIXTY;
                    break;
                case Const.Material.YXM1:
                    cboHRC.SelectedItem = Const.HRC.FIFTYEIGHT_SIXTY;
                    break;
                case Const.Material.DEX20:
                    cboHRC.SelectedItem = Const.HRC.SIXTYTWO_SIXTYFIVE;
                    break;
                default:
                    break;

            }
        }

        private void cboHRC_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnStdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStdApply_Click(object sender, EventArgs e)
        {
            control.StdApply();
            this.Close();
        }

        private void chkRetriveProjInfo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRetriveProjInfo.Checked)
            {
                UpdateProjectInfo();
            }
            else
            {
                ClearProjectInfo();
            }
        }

        private void UpdateProjectInfo()
        {
            var projInfo = ProjectInfoService.ReadFromFile();
            TextModel = projInfo.Model;
            TextPart = projInfo.Part;
            TextCodePrefix = projInfo.CodePrefix;
            TextDesginer = projInfo.Designer;
        }

        private void ClearProjectInfo()
        {
            TextModel = string.Empty;
            TextPart = string.Empty;
            TextCodePrefix = string.Empty;
            TextDesginer = string.Empty;
        }

        private void btnSaveProjInfo_Click(object sender, EventArgs e)
        {
            UpdateProjectInfoToFile();
        }

        private void UpdateProjectInfoToFile()
        {
            if (!IsProjectInfoFilled())
            {
                string message = "Please fill in all project information fields before saving.";
                string title = "Incomplete Information";
                NxDrawing.ShowMessageBox(message, title, NXMessageBox.DialogType.Error);
                return;
            }

            List<string> info = new List<string>()
            {
                TextModel,
                TextPart,
                TextCodePrefix,
                TextDesginer
            };

            ProjectInfoService.WriteToFile(info);
        }

        private bool IsProjectInfoFilled()
        {
            return !string.IsNullOrEmpty(TextModel) &&
                   !string.IsNullOrEmpty(TextPart) &&
                   !string.IsNullOrEmpty(TextCodePrefix) &&
                   !string.IsNullOrEmpty(TextDesginer);
        }
        private void CheckInputAndEnableApply()
        {
            var validationData = new FormValidationData
            {
                Path = GetPath,
                PartType = TextPartType,
                StationNumber = TextStaNo,
                ItemName = TextItemName,
                DrawingCode = TextDwgCode,
                Material = TextMaterial,
                Hardness = TextHRC,
                Thickness = TextThk,
                Width = TextWidth,
                Length = TextLength,
                Model = TextModel,
                Part = TextPart,
                CodePrefix = TextCodePrefix,
                Designer = TextDesginer
            };

            var validationResult = _validator.ValidateForApply(validationData);
            btnApply.Enabled = validationResult.IsValid;

            if(showDebugMessage && !validationResult.IsValid)
            {
                string message = string.Join(Environment.NewLine, validationResult.Errors);
                string title = "Validation Errors";
                NxDrawing.ShowMessageBox(message, title, NXMessageBox.DialogType.Error);
            }
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
        }
    }
}
