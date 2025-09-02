using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    // <summary>
    /// Service for analyzing version numbers from file names
    /// </summary>
    public interface IVersionAnalysisService
    {
        // <summary>
        /// Extracts version numbers from files matching a base name pattern
        /// </summary>
        /// <param name="files">Array of file paths</param>
        /// <param name="baseName">Base name to match</param>
        /// <returns>List of version numbers found</returns>
        List<int> ExtractVersionNumbers(string[] files, string baseName);

        /// <summary>
        /// Determines the next version number based on existing versions
        /// </summary>
        /// <param name="existingVersions">List of existing version numbers</param>
        /// <returns>Next version number</returns>
        int GetNextVersionNumber(List<int> existingVersions);

        /// <summary>
        /// Formats version number as version suffix
        /// </summary>
        /// <param name="versionNumber">Version number</param>
        /// <returns>Formatted version suffix (e.g., "-V01")</returns>
        string FormatVersionSuffix(int versionNumber);
    }
}
