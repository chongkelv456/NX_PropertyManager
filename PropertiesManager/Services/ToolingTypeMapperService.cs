using PropertiesManager.Constants;
using PropertiesManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Service for mapping UserForm selections to ToolingStructureType
    /// </summary>
    public class ToolingTypeMapperService : IToolingTypeMapperService
    {
        private static readonly Dictionary<string, Dictionary<string, ToolingStructureType>> _mappings;

        static ToolingTypeMapperService()
        {
            _mappings = new Dictionary<string, Dictionary<string, ToolingStructureType>>
            {
                // SHOE mappings - all SHOE items map to SHOE type
                [Const.PartType.SHOE] = new Dictionary<string, ToolingStructureType>
                {
                    [Const.ShoeType.UPPER_SHOE] = ToolingStructureType.SHOE,
                    [Const.ShoeType.LOWER_SHOE] = ToolingStructureType.SHOE,
                    [Const.ShoeType.PARALLEL_BAR] = ToolingStructureType.SHOE,
                    [Const.ShoeType.LOWER_COMMON_PLATE] = ToolingStructureType.SHOE
                },

                // PLATE mappings - each PLATE item maps to specific type
                [Const.PartType.PLATE] = new Dictionary<string, ToolingStructureType>
                {
                    [Const.PlateType.UPPER_PAD_SPACER] = ToolingStructureType.UPPER_PAD_SPACER,
                    [Const.PlateType.UPPER_PAD] = ToolingStructureType.UPPER_PAD,
                    [Const.PlateType.PUNCH_HOLDER] = ToolingStructureType.PUNCH_HOLDER,
                    [Const.PlateType.BOTTOMING_PLATE] = ToolingStructureType.BOTTOMING_PLATE,
                    [Const.PlateType.STRIPPER_PLATE] = ToolingStructureType.STRIPPER_PLATE,
                    [Const.PlateType.DIE_PLATE] = ToolingStructureType.DIE_PLATE,
                    [Const.PlateType.DIE_PLATE_R] = ToolingStructureType.DIE_PLATE,
                    [Const.PlateType.DIE_PLATE_F] = ToolingStructureType.DIE_PLATE,
                    [Const.PlateType.LOWER_PAD] = ToolingStructureType.LOWER_PAD,
                    [Const.PlateType.LOWER_PAD_SPACER] = ToolingStructureType.LOWER_PAD_SPACER
                },

                // INSERT mappings - all INSERT items map to INSERT type  
                [Const.PartType.INSERT] = CreateInsertMappings(),

                // W/C BLK mappings - maps to WCBLK type
                [Const.PartType.WCBLK] = new Dictionary<string, ToolingStructureType>
                {
                    ["WC BLOCK"] = ToolingStructureType.WCBLK
                },

                // OTHERS mappings - maps to ACCESSORIES type
                [Const.PartType.OTHERS] = new Dictionary<string, ToolingStructureType>
                {
                    ["CHUTE"] = ToolingStructureType.ACCESSORIES,
                    ["CHUTE FOR PRODUCT"] = ToolingStructureType.ACCESSORIES
                },

                // ASM mappings - maps to ASSEMBLY type
                [Const.PartType.ASM] = CreateAssemblyMappings()
            };
        }

        public ToolingStructureType GetToolingStructureType(string partType, string itemName)
        {
            // Input validation
            if (string.IsNullOrEmpty(partType))
                throw new ArgumentException("Part type cannot be null or empty", nameof(partType));

            if (string.IsNullOrEmpty(itemName))
                throw new ArgumentException("Item name cannot be null or empty", nameof(itemName));

            // Check if part type exists in mappings
            if (!_mappings.ContainsKey(partType))
                throw new ArgumentException($"Unknown part type: {partType}", nameof(partType));

            var itemMappings = _mappings[partType];

            // Check if item name exists for this part type
            if (!itemMappings.ContainsKey(itemName))
                throw new ArgumentException($"Unknown item name '{itemName}' for part type '{partType}'", nameof(itemName));

            return itemMappings[itemName];
        }

        public List<string> GetValidItemNames(string partType)
        {
            if (string.IsNullOrEmpty(partType))
                return new List<string>();

            if (!_mappings.ContainsKey(partType))
                return new List<string>();

            return _mappings[partType].Keys.ToList();
        }

        public bool IsValidCombination(string partType, string itemName)
        {
            if (string.IsNullOrEmpty(partType) || string.IsNullOrEmpty(itemName))
                return false;

            if (!_mappings.ContainsKey(partType))
                return false;

            return _mappings[partType].ContainsKey(itemName);
        }

        // Helper method to create INSERT mappings
        private static Dictionary<string, ToolingStructureType> CreateInsertMappings()
        {
            var insertItems = Insert.Get;
            var mappings = new Dictionary<string, ToolingStructureType>();

            foreach (var item in insertItems)
            {
                mappings[item] = ToolingStructureType.INSERT;
            }

            return mappings;
        }

        // Helper method to create ASSEMBLY mappings
        private static Dictionary<string, ToolingStructureType> CreateAssemblyMappings()
        {
            var assemblyItems = Assembly.Get;
            var mappings = new Dictionary<string, ToolingStructureType>();

            foreach (var item in assemblyItems)
            {
                mappings[item] = ToolingStructureType.ASSEMBLY;
            }

            return mappings;
        }

        // Static utility method for quick access (backward compatibility)
        public static ToolingStructureType GetToolingType(string partType, string itemName)
        {
            var service = new ToolingTypeMapperService();
            return service.GetToolingStructureType(partType, itemName);
        }
    }
}
