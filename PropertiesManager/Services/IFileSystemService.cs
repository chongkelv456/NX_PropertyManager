using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Abstraction for file system operation to enbable testability
    /// </summary>
    public interface IFileSystemService
    {
        /// <summary>
        /// Gets all files in a directory matching the search pattern
        /// </summary>
        /// <param name="path">Directory path</param>
        /// <param name="searchPattern">File search pattern (e.g., "*.prt")</param>
        /// <returns>Array of file paths</returns>
        string[] GetFiles(string path, string searchPattern);

        /// <summary>
        /// Gets the file name without extension from a file path
        /// </summary>
        // <param name="path">File path</param>
        /// <returns>File name without extension</returns>
        string GetFileNameWithoutExtension(string path);

        /// <summary>
        /// Checks if a directory exists
        /// </summary>
        /// <param name="path">Directory path</param>
        /// <returns>True if directory exists</returns>
        bool DirectoryExists(string path);
    }
}
