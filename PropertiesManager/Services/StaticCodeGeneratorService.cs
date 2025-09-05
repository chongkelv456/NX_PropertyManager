using NXOpen.Utilities;
using PropertiesManager.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Static wrapper to maintain backward compatibility with existing code
    /// This allows existing callers to continue using static methods while internally using instance-based services
    /// </summary>
    public class StaticCodeGeneratorService
    {
        private static readonly Lazy<IDrawingCodeService> _drawingCodeService =
            new Lazy<IDrawingCodeService>(() => new DrawingCodeService());

        private static readonly Lazy<IFileSystemService> _fileSystemService =
            new Lazy<IFileSystemService>(() => new FileSystemService());

        /// <summary>
        /// Creates a version string for file naming (backward compatible)
        /// </summary>
        /// <param name="baseName">Base name for version analysis</param>
        /// <param name="dirPath">Directory path</param>
        /// <returns>Version suffix string</returns>
        public static string AskVersion(string baseName, string dirPath)
        {
            var versionService = new VersionAnalysisService(_fileSystemService.Value);

            if (!_fileSystemService.Value.DirectoryExists(dirPath))
                throw new DirectoryNotFoundException($"Directory does not exist: {dirPath}");

            string[] files = _fileSystemService.Value.GetFiles(dirPath, "*.prt");
            var versions = versionService.ExtractVersionNumbers(files, baseName);
            int nextVersion = versionService.GetNextVersionNumber(versions);

            return versionService.FormatVersionSuffix(nextVersion);
        }

        /// <summary>
        /// Replaces spaces with underscores (pure utility function)
        /// </summary>
        public static string ReplaceSpacesWithUnderscore(string input)
        {
            return input?.Trim().Replace(" ", "_") ?? string.Empty;
        }

        /// <summary>
        /// Generates next number with increment (pure utility function)
        /// </summary>
        public static int GenerateNextNumber(int currentNumber, int increment = 1)
        {
            return currentNumber + increment;
        }

        /// <summary>
        /// Normalizes drawing code parts (backward compatible)
        /// </summary>
        public static Tuple<string, string> NormalizeDrawingCodeParts(string input)
        {
            return _drawingCodeService.Value.NormalizeDrawingCodeParts(input);
        }

        /// <summary>
        /// Gets drawing code from input string (backward compatible)
        /// </summary>
        public static string GetDrawingCode(string input)
        {
            return _drawingCodeService.Value.GetDrawingCode(input);
        }

        /// <summary>
        /// Gets drawing code from tooling type (backward compatible)
        /// </summary>
        public static string GetDrawingCodeFromType(string drawingCode)
        {
            return _drawingCodeService.Value.GetCodePrefixFromDrawingCode(drawingCode);
        }

        /// <summary>
        /// Gets formatted code prefix (backward compatible)
        /// </summary>
        public static string GetCodePrefix(string rawCodePrefix)
        {
            return _drawingCodeService.Value.GetCodePrefix(rawCodePrefix);
        }

        public static string GetCodePrefixFromDrawingCode(string drawingCode)
        {
            return _drawingCodeService.Value.GetCodePrefixFromDrawingCode(drawingCode);
        }

        /// <summary>
        /// Converts string to ToolingStructureType enum (backward compatible)
        /// </summary>
        public static ToolingStructureType GetToolingType(string type)
        {
            if (string.IsNullOrEmpty(type))
                throw new ArgumentException("Type cannot be null or empty", nameof(type));

            if (Enum.TryParse<ToolingStructureType>(type, out ToolingStructureType result))
            {
                return result;
            }

            throw new ArgumentException($"Unsupported ToolingStructureType: {type}");
        }

        /// <summary>
        /// Gets station number from drawing code (backward compatible)
        /// </summary>
        public static int GetStationNumber(string drawingCode)
        {
            return _drawingCodeService.Value.GetStationNumber(drawingCode);
        }

        /// <summary>
        /// Gets next running number (simplified version for backward compatibility)
        /// </summary>
        public static string AskNextRunningNumber(ToolingStructureType type, string dirPath, string codePrefix, int stnNumber = 0)
        {
            var runningNumberService = new RunningNumberService(_fileSystemService.Value, _drawingCodeService.Value);

            if (!_fileSystemService.Value.DirectoryExists(dirPath))
                throw new DirectoryNotFoundException($"Directory does not exist: {dirPath}");

            string[] files = _fileSystemService.Value.GetFiles(dirPath, "*.prt");
            string stationPart = runningNumberService.FormatStationNumber(type, stnNumber);
            int defaultTypeCode = int.Parse(_drawingCodeService.Value.GetDrawingCodeFromType(type, stnNumber).Substring(2));

            var runningNumbers = runningNumberService.AnalyzeExistingRunningNumbers(
                files, codePrefix, stationPart, type, defaultTypeCode);

            return runningNumberService.GetNextRunningNumber(runningNumbers, type, stnNumber);
        }

        /// <summary>
        /// Generates drawing code (backward compatible)
        /// </summary>
        public static string GenerateDrawingCode(ToolingStructureType type, string dirPath, string codePrefix, int stnNumber = 0)
        {
            return $"{codePrefix}{AskNextRunningNumber(type, dirPath, codePrefix, stnNumber)}";
        }

        /// <summary>
        /// Generates folder code (backward compatible)
        /// </summary>
        public static string GenerateFolderCode(ToolingStructureType type, string dirPath, string codePrefix, string itemName, int stnNumber = 0)
        {
            if (string.IsNullOrEmpty(itemName))
                throw new ArgumentException("Item name cannot be null or empty", nameof(itemName));

            string drawingCode = GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);
            return $"{drawingCode}_{itemName}";
        }

        /// <summary>
        /// Generates file name (backward compatible)
        /// </summary>
        public static string GenerateFileName(ToolingStructureType type, string dirPath, string codePrefix, string itemName, int stnNumber = 0)
        {
            string folderCode = GenerateFolderCode(type, dirPath, codePrefix, itemName, stnNumber);
            string baseName = $"{folderCode}-V00";
            string version = AskVersion(baseName, dirPath);
            return $"{folderCode}{version}";
        }
    }
}
