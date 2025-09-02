using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Concrete implementation of file system operations
    /// </summary>
    public class FileSystemService : IFileSystemService
    {
        public string[] GetFiles(string path, string searchPattern)
        {
            if(string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentException("Path cannot be null or empty", nameof(path));
            }

            if(string.IsNullOrWhiteSpace(searchPattern))
            {
                throw new ArgumentException("Search pattern cannot be null or empty", nameof(searchPattern));
            }

            try
            {
                return Directory.GetFiles(path, searchPattern);
            }
            catch (DirectoryNotFoundException ex)
            {
                throw new DirectoryNotFoundException($"Directory not found: {path}", ex);
            }
            catch (UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException($"Access denied to directory: {path}", ex);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Error accessing directory: {path}", ex);
            }
        }

        public string GetFileNameWithoutExtension(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                return string.Empty;
            }

            return Path.GetFileNameWithoutExtension(path);
        }

        public bool DirectoryExists(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                return false;
            }

            return Directory.Exists(path);
        }
    }
}
