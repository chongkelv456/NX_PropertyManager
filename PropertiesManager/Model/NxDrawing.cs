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
        private UFSession uf;
        private UI ui;
        private Part workPart;

        public const string CATEGORY_TITLE = "TITLEBLOCK";
        public const string CATEGORY_TOOL = "Tool";

        const string PART = "PART";
        const string DRAWING_CODE = "DRAWING CODE";
        const string MODEL_NAME = "MODEL NAME";
        const string ITEM_NAME = "ITEM NAME";
        const string QUANTITY = "QUANTITY";
        const string MATERIAL = "MATL";
        const string HRC = "HRC";
        const string THICKNESS = "Thk";
        const string LENGTH = "Length/Diameter";
        const string WIDTH = "Width";
        const string DESIGNBY = "DesignBy";
        const string PART_TYPE = "PartType";
        const string DESIGN_DATE = "Design Date";
        const string IS_STANDARD_PART = "isStandardPart";
        const string STDPART_ITEM = "StdPartItem";
        const string STD_PART = "STD PART";

        public NxDrawing(Controller control)
        {
            this.control = control;
            session = Session.GetSession();
            uf = UFSession.GetUFSession();
            ui = UI.GetUI();
            workPart = session.Parts.Work;
        }

        public void NXMessage(string message, string title, NXMessageBox.DialogType dialogType)
        {
            ui.NXMessageBox.Show(title, dialogType, message);
        }

        public void SetAttributes(List<NXObject.AttributeInformation> infos)
        {
            try
            {
                infos.ForEach(x => workPart.SetUserAttribute(x, Update.Option.Now));
            }
            catch (Exception e)
            {
                string message = $"I don't know what error: {e.Message}";
                NXMessage(message, "Error", NXMessageBox.DialogType.Error);
            }            
        }

        public List<NXObject.AttributeInformation> GetAttributesInfos(string category, Dictionary<string, string> keyValue_titles)
        {
            List<NXObject.AttributeInformation> result = new List<NXObject.AttributeInformation>();

            Dictionary<string, string> keyValue_tools = new Dictionary<string, string>();
            keyValue_tools.Add(PART_TYPE, control.GetUserForm().TextPartType);
            //System.Diagnostics.Debugger.Launch();
            foreach (var title in keyValue_titles)
            {
                NXObject.AttributeInformation info = new NXObject.AttributeInformation();

                if (title.Value.Equals("True"))
                {
                    info.Type = NXObject.AttributeType.Boolean;
                    info.BooleanValue = true;
                }
                else
                {
                    info.Type = NXObject.AttributeType.String;
                    info.StringValue = title.Value;                    
                }
                info.Category = category;
                info.Title = title.Key;

                result.Add(info);
            }

            return result;
        }

        public Dictionary<string, string> GetTitle_KeyValue()
        {
            Dictionary<string, string> keyValue_titles = new Dictionary<string, string>();
            keyValue_titles.Add(MODEL_NAME, control.GetUserForm().TextModel);
            keyValue_titles.Add(PART, control.GetUserForm().TextPart);
            keyValue_titles.Add(ITEM_NAME, control.GetUserForm().TextItemName);
            keyValue_titles.Add(DRAWING_CODE, control.GetUserForm().TextDwgCode);
            keyValue_titles.Add(MATERIAL, control.GetUserForm().TextMaterial);
            keyValue_titles.Add(HRC, control.GetUserForm().TextHRC);
            keyValue_titles.Add(QUANTITY, control.GetUserForm().TextQuantity);
            keyValue_titles.Add(DESIGNBY, control.GetUserForm().TextDesginer);
            keyValue_titles.Add(THICKNESS, control.GetUserForm().TextThk);
            keyValue_titles.Add(WIDTH, control.GetUserForm().TextWidth);
            keyValue_titles.Add(LENGTH, control.GetUserForm().TextLength);
            keyValue_titles.Add(DESIGN_DATE, DateTime.Now.ToString("dd MMM yyyy"));

            return keyValue_titles;
        }

        public void DeleteStdPartAttribute()
        {
            workPart.DeleteUserAttribute(NXObject.AttributeType.String, STDPART_ITEM, false, Update.Option.Now);
            workPart.DeleteUserAttribute(NXObject.AttributeType.Boolean, IS_STANDARD_PART, false, Update.Option.Now);
        }

        public Dictionary<string, string> GetTool_KeyValue()
        {
            Dictionary<string, string> keyvaluePairs = new Dictionary<string, string>();
            keyvaluePairs.Add(PART_TYPE, control.GetUserForm().TextPartType);

            return keyvaluePairs;
        }

        public Dictionary<string, string> GetStandardPart_KeyValue()
        {
            Dictionary<string, string> keyvaluePairs = new Dictionary<string, string>();
            keyvaluePairs.Add(PART_TYPE, STD_PART);
            keyvaluePairs.Add(IS_STANDARD_PART, "True");
            keyvaluePairs.Add(STDPART_ITEM, control.GetUserForm().TextStandardPartItemName);

            return keyvaluePairs;
        }

        public string GetTextFromDimension()
        {
            Selection selManager = ui.SelectionManager;
            TaggedObject selectedObject;
            Point3d cursor;
            string message = "Please select a curve to be hidden";
            string title = "Selection";
            var scope = NXOpen.Selection.SelectionScope.WorkPartAndWorkPartOccurrence;
            var action = NXOpen.Selection.SelectionAction.ClearAndEnableSpecific;
            bool keepHighlighted = false;
            bool includeFeature = false;

            string result = null;

            var dimMask = new Selection.MaskTriple(NXOpen.UF.UFConstants.UF_dimension_type, UFConstants.UF_dim_horizontal_subtype, UFConstants.UF_all_subtype);
            Selection.MaskTriple[] maskArray = new Selection.MaskTriple[] { dimMask };


            var response = selManager.SelectTaggedObject(message, title, scope, action, includeFeature, keepHighlighted, maskArray, out selectedObject, out cursor);

            if (response != NXOpen.Selection.Response.Cancel && response != NXOpen.Selection.Response.Back)
            {
                //System.Diagnostics.Debugger.Launch();  
                string[] texts;
                string[] dual_texts;
                int num_main_text;
                int num_dual_text;
                uf.Drf.AskDimensionText(selectedObject.Tag, out num_main_text, out texts, out num_dual_text, out dual_texts);
                result = texts[0];
            }

            return result;
        }
    }
}
