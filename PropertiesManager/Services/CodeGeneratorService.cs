using PropertiesManager.Constants;
using PropertiesManager.Control;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PropertiesManager.Constants.Const;
using PropertiesManager.Model;

namespace PropertiesManager.Services
{
    /// <summary>
    /// Service for generating codes, file names, and managing tooling structure creation
    /// </summary>
    public class CodeGeneratorService
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IVersionAnalysisService _versionAnalysisService;
        private readonly IRunningNumberService _runningNumberService;
        private readonly IDrawingCodeService _drawingCodeService;
        private readonly Controller _control;
        private readonly ProjectInfoModel _projectInfo;

        // Constructor for dependency injection
        public CodeGeneratorService(
            Controller control,
            ProjectInfoModel projectInfo,
            IFileSystemService fileSystemService = null,
            IVersionAnalysisService versionAnalysisService = null,
            IRunningNumberService runningNumberService = null,
            IDrawingCodeService drawingCodeService = null)
        {
            _control = control ?? throw new ArgumentNullException(nameof(control));
            _projectInfo = projectInfo ?? throw new ArgumentNullException(nameof(projectInfo));
            _fileSystemService = fileSystemService ?? new FileSystemService();
            _drawingCodeService = drawingCodeService ?? new DrawingCodeService();
            _versionAnalysisService = versionAnalysisService ?? new VersionAnalysisService(_fileSystemService);
            _runningNumberService = runningNumberService ?? new RunningNumberService(_fileSystemService, _drawingCodeService);
        }

        // Factory method for easy instance creation
        public static CodeGeneratorService Create(Controller control, ProjectInfoModel projectInfo)
        {
            return CodeGeneratorServiceBuilder.CreateDefault(control, projectInfo);
        }

        // Factory method for testing with mocks
        public static CodeGeneratorService CreateForTesting(
            Controller control,
            ProjectInfoModel projectInfo,
            IFileSystemService mockFileSystem = null,
            IVersionAnalysisService mockVersionAnalysis = null,
            IRunningNumberService mockRunningNumber = null,
            IDrawingCodeService mockDrawingCode = null)
        {
            return CodeGeneratorServiceBuilder.CreateForTesting(
                control,
                projectInfo,
                mockFileSystem,
                mockVersionAnalysis,
                mockRunningNumber,
                mockDrawingCode);
        }

        // Instance methods that use injected dependencies
        public string AskVersion(string baseName, string dirPath)
        {
            ValidateVersionInputs(baseName, dirPath);

            string[] files = _fileSystemService.GetFiles(dirPath, "*.prt");
            List<int> existingVersions = _versionAnalysisService.ExtractVersionNumbers(files, baseName);
            int nextVersion = _versionAnalysisService.GetNextVersionNumber(existingVersions);

            return _versionAnalysisService.FormatVersionSuffix(nextVersion);
        }

        public string AskNextRunningNumber(ToolingStructureType type, string dirPath, string codePrefix, int stnNumber = 0)
        {
            ValidateRunningNumberInputs(dirPath, codePrefix);

            string[] files = _fileSystemService.GetFiles(dirPath, "*.prt");
            string stationPart = _runningNumberService.FormatStationNumber(type, stnNumber);
            int defaultTypeCode = int.Parse(_drawingCodeService.GetDrawingCodeFromType(type, stnNumber).Substring(2));

            List<int> runningNumbers = _runningNumberService.AnalyzeExistingRunningNumbers(
                files, codePrefix, stationPart, type, defaultTypeCode);

            return _runningNumberService.GetNextRunningNumber(runningNumbers, type, stnNumber);
        }

        // High-level generation methods
        public string GenerateDrawingCode(ToolingStructureType type, string dirPath, string codePrefix, int stnNumber = 0)
        {
            return $"{codePrefix}{AskNextRunningNumber(type, dirPath, codePrefix, stnNumber)}";
        }

        public string GenerateFolderCode(ToolingStructureType type, string dirPath, string codePrefix, string itemName, int stnNumber = 0)
        {
            ValidateItemName(itemName);
            string drawingCode = GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);
            return $"{drawingCode}_{itemName}";
        }

        public string GenerateFileName(ToolingStructureType type, string dirPath, string codePrefix, string itemName, int stnNumber = 0)
        {
            string folderCode = GenerateFolderCode(type, dirPath, codePrefix, itemName, stnNumber);
            string baseName = $"{folderCode}-V00";
            string version = AskVersion(baseName, dirPath);
            return $"{folderCode}{version}";
        }

        // Validation methods
        private void ValidateVersionInputs(string baseName, string dirPath)
        {
            if (string.IsNullOrEmpty(baseName))
                throw new ArgumentException("Base name cannot be null or empty", nameof(baseName));

            if (string.IsNullOrEmpty(dirPath))
                throw new ArgumentException("Directory path cannot be null or empty", nameof(dirPath));

            if (!_fileSystemService.DirectoryExists(dirPath))
                throw new DirectoryNotFoundException($"Directory does not exist: {dirPath}");
        }

        private void ValidateRunningNumberInputs(string dirPath, string codePrefix)
        {
            if (string.IsNullOrEmpty(dirPath))
                throw new ArgumentException("Directory path cannot be null or empty", nameof(dirPath));

            if (string.IsNullOrEmpty(codePrefix))
                throw new ArgumentException("Code prefix cannot be null or empty", nameof(codePrefix));

            if (!_fileSystemService.DirectoryExists(dirPath))
                throw new DirectoryNotFoundException($"Directory does not exist: {dirPath}");
        }

        private void ValidateItemName(string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
                throw new ArgumentException("Item name cannot be null or empty", nameof(itemName));
        }

        // Static utility methods (no dependencies required)
        public static string ReplaceSpacesWithUnderscore(string input)
        {
            return input?.Trim().Replace(" ", "_") ?? string.Empty;
        }

        public static int GenerateNextNumber(int currentNumber, int increment = 1)
        {
            return currentNumber + increment;
        }

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

        // Delegate methods to services (maintaining backward compatibility)
        public Tuple<string, string> NormalizeDrawingCodeParts(string input)
        {
            return _drawingCodeService.NormalizeDrawingCodeParts(input);
        }

        public string GetDrawingCode(string input)
        {
            return _drawingCodeService.GetDrawingCode(input);
        }

        public string GetDrawingCodeFromType(ToolingStructureType type, int stnNumber = 0)
        {
            return _drawingCodeService.GetDrawingCodeFromType(type, stnNumber);
        }

        public string GetCodePrefix(string rawCodePrefix)
        {
            return _drawingCodeService.GetCodePrefix(rawCodePrefix);
        }

        public int GetStationNumber(string drawingCode)
        {
            return _drawingCodeService.GetStationNumber(drawingCode);
        }

        // Properties for accessing dependencies (useful for testing)
        internal IFileSystemService FileSystemService => _fileSystemService;
        internal IVersionAnalysisService VersionAnalysisService => _versionAnalysisService;
        internal IRunningNumberService RunningNumberService => _runningNumberService;
        internal IDrawingCodeService DrawingCodeService => _drawingCodeService;
        internal Controller Control => _control;
        internal ProjectInfoModel ProjectInfo => _projectInfo;
    }
}
