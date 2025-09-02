using PropertiesManager.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Service for generating running numbers based on tooling structure types
    /// </summary>
    public interface IRunningNumberService
    {
        /// <summary>
        /// Analyzes existing files to extract running numbers
        /// </summary>
        /// <param name="files">Array of file paths</param>
        /// <param name="codePrefix">Code prefix to match</param>
        /// <param name="stationPart">Station part string</param>
        /// <param name="type">Tooling structure type</param>
        /// <param name="defaultTypeCode">Default type code</param>
        /// <returns>List of existing running numbers</returns>
        List<int> AnalyzeExistingRunningNumbers(string[] files, string codePrefix, string stationPart,
            ToolingStructureType type, int defaultTypeCode);

        /// <summary>
        /// Determines if a file should be included based on tooling type filters
        /// </summary>
        /// <param name="type">Tooling structure type</param>
        /// <param name="runningNumber">Running number to check</param>
        /// <param name="defaultTypeCode">Default type code</param>
        /// <returns>True if file should be included</returns>
        bool ShouldIncludeFile(ToolingStructureType type, int runningNumber, int defaultTypeCode);

        /// <summary>
        /// Gets the next available running number
        /// </summary>
        /// <param name="existingNumbers">List of existing running numbers</param>
        /// <param name="type">Tooling structure type</param>
        /// <param name="stationNumber">Station number</param>
        /// <returns>Next running number as formatted string</returns>
        string GetNextRunningNumber(List<int> existingNumbers, ToolingStructureType type, int stationNumber);

        /// <summary>
        /// Formats station number as zero-padded string
        /// </summary>
        /// <param name="stationNumber">Station number</param>
        /// <returns>Formatted station number</returns>
        string FormatStationNumber(int stationNumber);
    }
}
