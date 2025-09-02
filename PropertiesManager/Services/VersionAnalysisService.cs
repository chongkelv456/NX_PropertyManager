using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Service for analyzing version numbers from file names
    /// </summary>
    public class VersionAnalysisService : IVersionAnalysisService
    {
        private readonly IFileSystemService _fileSystemService;

        public VersionAnalysisService(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService
                ?? throw new ArgumentNullException(nameof(fileSystemService));
        }

        public List<int> ExtractVersionNumbers(string[] files, string baseName)
        {
            if (files == null)
                throw new ArgumentNullException(nameof(files));

            if (string.IsNullOrEmpty(baseName))
                throw new ArgumentException("Base name cannot be null or empty", nameof(baseName));

            var existingVersions = new List<int>();
            string versionPrefix = baseName + "-V";

            foreach (string file in files)
            {
                string fileNameWithoutExtension = _fileSystemService.GetFileNameWithoutExtension(file);

                if (IsVersionFile(fileNameWithoutExtension, versionPrefix))
                {
                    int version = ParseVersionNumber(fileNameWithoutExtension, versionPrefix);
                    if (version >= 0)
                    {
                        existingVersions.Add(version);
                    }
                }
            }

            return existingVersions;
        }

        public int GetNextVersionNumber(List<int> existingVersions)
        {
            if (existingVersions == null)
                throw new ArgumentNullException(nameof(existingVersions));

            return existingVersions.Count > 0 ? existingVersions.Max() + 1 : 0;
        }

        public string FormatVersionSuffix(int versionNumber)
        {
            if (versionNumber < 0)
                throw new ArgumentOutOfRangeException(nameof(versionNumber), "Version number cannot be negative");
            
            return $"-V{versionNumber:D2}";
        }

        private bool IsVersionFile(string fileName, string versionPrefix)
        {
            return !string.IsNullOrEmpty(fileName) && fileName.StartsWith(versionPrefix);
        }

        private int ParseVersionNumber(string fileName, string versionPrefix)
        {
            string versionPart = fileName.Substring(versionPrefix.Length);
            return int.TryParse(versionPart, out int version) ? version : -1;
        }

    }
}
