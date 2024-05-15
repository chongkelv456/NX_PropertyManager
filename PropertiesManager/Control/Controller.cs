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
        private PartType partType;
        private Plate plate;
        private Shoe shoe;
        private Material material;
        private Hardness hardness;

        public Controller()
        {
            //System.Diagnostics.Debugger.Launch();
            designer = new Designer();
            partType = new PartType();
            plate = new Plate();
            shoe = new Shoe();
            material = new Material();
            hardness = new Hardness();
            uf = new UserForm(this);
            drawing = new NxDrawing(this);                        
            uf.ShowDialog();
        }

        public void Apply()
        {
            var message = "Yeay, you have pressed APPLY!\n";
            var title = "Information";
            List<string> info = new List<string>();
            info.Add(uf.TextModel);
            info.Add(uf.TextPart);
            info.Add(uf.TextCodePrefix);
            info.Add(uf.TextDesginer);
            info.ForEach(x => message += x + "\n");
            NXOpen.NXMessageBox.DialogType dialogType = NXOpen.NXMessageBox.DialogType.Information;
            drawing.NXMessage(message, title, dialogType);
        }

        public List<string> GetDesigners()
        {
            return designer.GetDesingers;
        }

        public List<string> GetPartTypes()
        {
            return partType.GetPartTypes;
        }

        public List<string> GetPlates()
        {
            return plate.GetPlates;
        }

        public List<string> GetShoes()
        {
            return shoe.GetShoes;
        }
        public List<string> GetMaterials()
        {
            return material.GetMaterials;
        }
        public List<string> GetHardness()
        {
            return hardness.GetHardnesses;
        }

        public void ValidateApplyButton()
        {
            //System.Diagnostics.Debugger.Launch();
            uf.SetApplyButtonEnable(uf.IsFilledTxtModel &&
                 uf.IsFilledTextPart &&
                 uf.IsFilledCodePrefix &&
                 uf.IsFilledDesigner);
        }
    }
}
