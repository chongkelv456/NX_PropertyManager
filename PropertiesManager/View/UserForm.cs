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
        private readonly IToolingTypeMapperService _toolingTypeMapper;
        private readonly PartTypeConfigService _partTypeService = new PartTypeConfigService();
        private readonly RetrieveTitleBlkInfoService _titleBlkService = new RetrieveTitleBlkInfoService();
        private Controller control;
        bool showDebugMessage = false; // Set to true to show debug messages
        bool debugMode = false;
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
            _toolingTypeMapper = new ToolingTypeMapperService();
        }

        /// <summary>
        /// Gets the ToolingStructureType based on current ComboBox selections
        /// </summary>
        /// <returns>ToolingStructureType corresponding to current selections</returns>
        public ToolingStructureType GetSelectedToolingType()
        {
            try
            {
                string partType = TextPartType;
                string itemName = TextItemName;

                return _toolingTypeMapper.GetToolingStructureType(partType, itemName);
            }
            catch (ArgumentException ex)
            {
                // Handle invalid selections
                string message = $"Invalid selection combination: {ex.Message}";
                string title = "Invalid Selection";
                NxDrawing.ShowMessageBox(message, title, NXMessageBox.DialogType.Warning);

                // Return default or throw based on your preference
                return ToolingStructureType.SHOE; // Default fallback
            }
        }

        /// <summary>
        /// Validates if the current selection combination is valid
        /// </summary>
        /// <returns>True if current selections are valid</returns>
        public bool IsCurrentSelectionValid()
        {
            string partType = TextPartType;
            string itemName = TextItemName;

            return _toolingTypeMapper.IsValidCombination(partType, itemName);
        }

        /// <summary>
        /// Gets the drawing code for current selections (convenience method)
        /// </summary>
        /// <param name="stationNumber">Station number</param>
        /// <returns>Generated drawing code</returns>
        public string GetDrawingCodeForCurrentSelection(int stationNumber = 1)
        {
            try
            {
                ToolingStructureType toolingType = GetSelectedToolingType();
                string codePrefix = TextCodePrefix;
                string dirPath = GetPath;

                // Use your CodeGeneratorService
                return StaticCodeGeneratorService.GenerateDrawingCode(toolingType, dirPath, codePrefix, stationNumber);
            }
            catch (Exception ex)
            {
                string message = $"Error generating drawing code: {ex.Message}";
                string title = "Drawing Code Error";
                NxDrawing.ShowMessageBox(message, title, NXMessageBox.DialogType.Error);
                return string.Empty;
            }
        }

        /// <summary>
        /// Refreshes drawing code if current selections are valid
        /// </summary>
        private void RefreshDrawingCodeIfValid()
        {
            if (IsCurrentSelectionValid() && !string.IsNullOrEmpty(TextCodePrefix) && !string.IsNullOrEmpty(GetPath))
            {
                try
                {
                    int stationNumber = (int)numericStnNo.Value;
                    string newDrawingCode = GetDrawingCodeForCurrentSelection(stationNumber);

                    TextDwgCode = newDrawingCode;
                }
                catch
                {
                    // Silently ignore errors during auto-refresh
                }
            }
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
            RefreshDrawingCodeIfValid();
        }

        private void cboDesign_TextChanged(object sender, EventArgs e)
        {
            UpdateBtnSaveProjetInfoState();
            CheckInputAndEnableApply();
        }

        private void cboPartType_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();

            if (cboPartType.SelectedItem is not string selectedPartType)
                return;

            var config = _partTypeService.GetConfig(selectedPartType);
            if (config == null)
                return;

            PopulateItemNameDataSource(cboItemName, config.GetItems());

            cboMaterial.SelectedItem = config.Material;
            numericStnNo.Value = config.StationNumber;
            pictureBox1.Image = config.Image;

            if (config.OverrideMaterialText)
                cboMaterial.SelectedItem = Const.HRC.HYPHEN;

            if (config.UseHyphen)
                SetMaterialTextBoxHyphen();
            else
                ClearMaterialTextBox();

            // Auto-refresh drawing code when selection changes (optional)
            RefreshDrawingCodeIfValid();
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

        private void PopulateItemNameDataSource(ComboBox cboItemName, IEnumerable<string> list)
        {
            cboItemName.DataSource = list;
        }

        private void cboItemName_TextChanged(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();

            // Auto-refresh drawing code when selection changes (optional)
            RefreshDrawingCodeIfValid();
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
                Designer = TextDesginer,
                Quantity = TextQuantity
            };

            if (debugMode)
                System.Diagnostics.Debugger.Launch();

            var validationResult = _validator.ValidateForApply(validationData);
            btnApply.Enabled = validationResult.IsValid;

            var refreshValidationResult = _validator.ValidateForRefresh(validationData);
            btnDwgCodeRefresh.Enabled = refreshValidationResult.IsValid;

            if (showDebugMessage && !validationResult.IsValid)
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

        private void btnDwgCodeRefresh_Click(object sender, EventArgs e)
        {
            if (int.TryParse(TextStaNo, out int stationNumber) && IsCurrentSelectionValid())
                TextDwgCode = GetDrawingCodeForCurrentSelection(stationNumber);
        }

        private void numericStnNo_ValueChanged_1(object sender, EventArgs e)
        {
            CheckInputAndEnableApply();
            RefreshDrawingCodeIfValid();
        }

        private void btnRetrieveTitleInfo_Click(object sender, EventArgs e)
        {
            var titleInfo = _titleBlkService.Get();
            // Drawing Informatiob
            cboPartType.Text = titleInfo.PartType;
            numericStnNo.Value = titleInfo.StationNumber;
            cboItemName.Text = titleInfo.ItemName;
            txtDwgCode.Text = titleInfo.DrawingCode;
            cboMaterial.Text = titleInfo.Material;
            cboHRC.Text = titleInfo.HRC;
            txtThk.Text = titleInfo.Thickness;
            txtWidth.Text = titleInfo.Width;
            txtLength.Text = titleInfo.Length;
            txtQuantity.Text = titleInfo.Quantity;            

            // Project Information
            txtModel.Text = titleInfo.Model;
            txtPart.Text = titleInfo.Part;
            cboDesign.Text = titleInfo.DesignBy;
            txtCodePrefix.Text = titleInfo.CodePrefix;

            // File Path
            txtPath.Text = titleInfo.DirectoryPath;
        }
    }
}
