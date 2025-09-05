using PropertiesManager.Control;
using PropertiesManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NXOpen;

namespace PropertiesManager.Services
{
    public class RetrieveTitleBlkInfoService : IRetrieveTitleBlkInfoService
    {
        bool debugMode = false;

        public TitleBlockInfoModel Get()
        {
            string[] infos = new string[]
            {
                NxDrawing.PART,
                NxDrawing.DRAWING_CODE,
                NxDrawing.MODEL_NAME,
                NxDrawing.ITEM_NAME,
                NxDrawing.QUANTITY,
                NxDrawing.MATERIAL,
                NxDrawing.HRC,
                NxDrawing.THICKNESS,
                NxDrawing.LENGTH,
                NxDrawing.WIDTH,
                NxDrawing.DESIGNBY,
                NxDrawing.PART_TYPE,
                NxDrawing.DESIGN_DATE
            };

            if (debugMode)
                System.Diagnostics.Debugger.Launch();

            var workPart = Session.GetSession().Parts.Work;

            AttributeIterator itrTitleBlock = workPart.CreateAttributeIterator();
            itrTitleBlock.SetIncludeOnlyCategory(NxDrawing.CATEGORY_TITLE);
            var titleAttributes = workPart.GetUserAttributes(itrTitleBlock);

            AttributeIterator itrTool = workPart.CreateAttributeIterator();
            itrTool.SetIncludeOnlyCategory(NxDrawing.CATEGORY_TOOL);
            var toolAttributes = workPart.GetUserAttributes(itrTool);

            TitleBlockInfoModel infoModel = new TitleBlockInfoModel();

            foreach (NXObject.AttributeInformation att in titleAttributes)
            {
                //System.Diagnostics.Debug.WriteLine($"Name: {att.Title}, Value: {att.StringValue}");
                switch (att.Title)
                {
                    case NxDrawing.PART:
                        infoModel.Part = att.StringValue;
                        break;
                    case NxDrawing.DRAWING_CODE:
                        infoModel.DrawingCode = att.StringValue;
                        break;
                    case NxDrawing.MODEL_NAME:
                        infoModel.Model = att.StringValue;
                        break;
                    case NxDrawing.ITEM_NAME:
                        infoModel.ItemName = att.StringValue;
                        break;
                    case NxDrawing.QUANTITY:
                        infoModel.Quantity = att.StringValue;
                        break;
                    case NxDrawing.MATERIAL:
                        infoModel.Material = att.StringValue;
                        break;
                    case NxDrawing.HRC:
                        infoModel.HRC = att.StringValue;
                        break;
                    case NxDrawing.THICKNESS:
                        infoModel.Thickness = att.StringValue;
                        break;
                    case NxDrawing.LENGTH:
                        infoModel.Length = att.StringValue;
                        break;
                    case NxDrawing.WIDTH:
                        infoModel.Width = att.StringValue;
                        break;
                    case NxDrawing.DESIGNBY:
                        infoModel.DesignBy = att.StringValue;
                        break;
                    case NxDrawing.DESIGN_DATE:
                        infoModel.DesignDate = att.StringValue;
                        break;
                    default:
                        break;
                }                
            }

            foreach (var att in toolAttributes)
            {
                if (att.Title == NxDrawing.PART_TYPE)
                    infoModel.PartType = att.StringValue;
            }

            infoModel.StationNumber = StaticCodeGeneratorService.GetStationNumber(infoModel.DrawingCode);
            infoModel.CodePrefix = StaticCodeGeneratorService.GetCodePrefixFromDrawingCode(infoModel.DrawingCode);

            var fullPath = workPart.FullPath;            
            infoModel.DirectoryPath = Path.GetDirectoryName(fullPath);

            return infoModel;
        }
    }
}
