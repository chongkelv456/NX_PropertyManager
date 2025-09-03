using PropertiesManager.Constants;
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
    public interface IToolingTypeMapperService
    {
        /// <summary>
        /// Maps Part Type and Item Name selections to ToolingStructureType
        /// </summary>
        /// <param name="partType">Selected part type from cboPartType</param>
        /// <param name="itemName">Selected item name from cboItemName</param>
        /// <returns>Corresponding ToolingStructureType</returns>
        ToolingStructureType GetToolingStructureType(string partType, string itemName);

        /// <summary>
        /// Gets all valid item names for a given part type
        /// </summary>
        /// <param name="partType">Part type to get item names for</param>
        /// <returns>List of valid item names</returns>
        List<string> GetValidItemNames(string partType);

        /// <summary>
        /// Validates if a part type and item name combination is valid
        /// </summary>
        /// <param name="partType">Part type to validate</param>
        /// <param name="itemName">Item name to validate</param>
        /// <returns>True if combination is valid</returns>
        bool IsValidCombination(string partType, string itemName);
    }
}
