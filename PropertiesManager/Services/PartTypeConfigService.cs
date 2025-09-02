using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertiesManager.Model;
using PropertiesManager.Constants;

namespace PropertiesManager.Services
{
    public class PartTypeConfigService
    {
        private readonly Dictionary<string, Model.PartTypeConfig> _configs;

        public PartTypeConfigService()
        {
            _configs = new Dictionary<string, PartTypeConfig>
            {
                [Const.PartType.SHOE] = new PartTypeConfig()
                {
                    GetItems = () => ShoeItems.Get,
                    Material = Const.Material.S50C,
                    StationNumber = 0,
                    Image = Resource1.Shoe
                },
                [Const.PartType.PLATE] = new PartTypeConfig()
                {
                    GetItems = () => Plate.Get,
                    Material = Const.Material.GOA,
                    StationNumber = 1,
                    Image = Resource1.Plate
                },
                [Const.PartType.INSERT] = new PartTypeConfig()
                {
                    GetItems = () => Insert.Get,
                    Material = Const.Material.DC53,
                    StationNumber = 1,
                    Image = Resource1.Insert
                },
                [Const.PartType.WCBLK] = new PartTypeConfig()
                {
                    GetItems = () => WCblk.Get,
                    Material = Const.Material.S50C,
                    StationNumber = 1,
                    Image = Resource1.WCBlk
                },
                [Const.PartType.OTHERS] = new PartTypeConfig()
                {
                    GetItems = () => Other.Get,
                    Material = Const.Material.EG2,
                    StationNumber = 0,
                    Image = Resource1.Other,
                    UseHyphen = true
                },
                [Const.PartType.ASM] = new PartTypeConfig()
                {
                    GetItems = () => Assembly.Get,
                    Material = Const.Material.MILD_STELL,
                    StationNumber = 0,
                    Image = Resource1.Shoe,
                    OverrideMaterialText = true,
                    UseHyphen = true
                }
            };
        }

        public PartTypeConfig GetConfig(string partType)
        {
            return _configs.TryGetValue(partType, out var config) ? config : null;
        }
    }
}
