using PropertiesManager.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Service for drawing code operations and validation
    /// </summary>
    public interface IDrawingCodeService
    {
        /// <summary>
        /// Extracts drawing code from input string
        /// </summary>
        /// <param name="input">Input string containing drawing code</param>
        /// <returns>Extracted drawing code</returns>
        string GetDrawingCode(string input);

        /// <summary>
        /// Validates if a drawing code is in correct format
        /// </summary>
        /// <param name="code">Drawing code to validate</param>
        /// <returns>True if valid</returns>
        bool IsValidDrawingCode(string code);

        /// <summary>
        /// Gets drawing code from tooling structure type
        /// </summary>
        /// <param name="type">Tooling structure type</param>
        /// <param name="stationNumber">Station number</param>
        /// <returns>Generated drawing code</returns>
        string GetDrawingCodeFromType(ToolingStructureType type, int stationNumber = 0);

        /// <summary>
        /// Gets station number from drawing code
        /// </summary>
        /// <param name="drawingCode">Drawing code</param>
        /// <returns>Station number</returns>
        int GetStationNumber(string drawingCode);

        /// <summary>
        /// Normalizes drawing code parts
        /// </summary>
        /// <param name="input">Raw input string</param>
        /// <returns>Tuple of normalized prefix and suffix</returns>
        Tuple<string, string> NormalizeDrawingCodeParts(string input);

        /// <summary>
        /// Gets code prefix from raw code prefix
        /// </summary>
        /// <param name="rawCodePrefix">Raw code prefix</param>
        /// <returns>Formatted code prefix</returns>
        string GetCodePrefix(string rawCodePrefix);
    }
}
