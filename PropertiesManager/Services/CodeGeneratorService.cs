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
    public class CodeGeneratorService
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly Controller _control;
        private readonly ProjectInfoModel _projectInfo;

        // Constructor for dependency injection
        public CodeGeneratorService(IFileSystemService fileSystemService, Controller control, ProjectInfoModel projectInfo)
        {
            _control = control ?? throw new ArgumentNullException(nameof(control));
            _projectInfo = projectInfo ?? throw new ArgumentNullException(nameof(projectInfo));
            _fileSystemService = fileSystemService ?? new FileSystemService();
        }

        // Instance methods that use injected dependencies
        public string AskVersion(string baseName, string dirPath)
        {
            if (string.IsNullOrEmpty(baseName))
            {
                throw new ArgumentException("Base name cannot be null or empty", nameof(baseName));
            }

            if (string.IsNullOrEmpty(dirPath))
            {
                throw new ArgumentException("Directory path cannot be null or empty", nameof(dirPath));
            }

            if (!_fileSystemService.DirectoryExists(dirPath))
            {
                throw new DirectoryNotFoundException($"Directory not found: {dirPath}");
            }

            string searchPattern = "*.prt";
            string[] files = _fileSystemService.GetFiles(dirPath, searchPattern);
            List<int> existingVersions = new List<int>();

            foreach (string file in files)
            {
                string fileNameWidthExtension = _fileSystemService.GetFileNameWithoutExtension(file);
                if (fileNameWidthExtension.StartsWith(baseName + "-V"))
                {
                    string versionPart = fileNameWidthExtension.Substring(baseName.Length + 2); // Skip baseName and "-V"
                    if (int.TryParse(versionPart, out int version))
                    {
                        existingVersions.Add(version);
                    }
                }
            }

            int nextVersion = 0;
            if (existingVersions.Count > 0)
            {
                nextVersion = existingVersions.Max() + 1;
            }

            return $"-V{nextVersion.ToString("D2")}";
        }

        public string AskNextRunningNumber(ToolingStructureType type, string dirPath, string codePrefix, int stnNumber = 0)
        {
            if (string.IsNullOrEmpty(dirPath))
            {
                throw new ArgumentException("Directory path cannot be null or empty", nameof(dirPath));
            }

            if (string.IsNullOrEmpty(codePrefix))
            {
                throw new ArgumentException("Code prefix cannot be null or empty", nameof(codePrefix));
            }

            if (!_fileSystemService.DirectoryExists(dirPath))
            {
                throw new DirectoryNotFoundException($"Directory not found: {dirPath}");
            }

            string searchPattern = "*.prt";
            var files = _fileSystemService.GetFiles(dirPath, searchPattern);
            List<int> runningNumbers = new List<int>();

            string stationPart = stnNumber.ToString("D2");
            int defaultTypeCode = int.Parse(GetDrawingCodeFromType(type, stnNumber).Substring(2));

            foreach (string file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);

                // 1) Must start with prefix + station  
                if (!fileName.StartsWith(codePrefix + stationPart))
                    continue;

                // 2) Extract the 4-digit drawing code  
                string codePart = GetDrawingCode(fileName);
                if (codePart.Length != 4 || !codePart.StartsWith(stationPart))
                    continue;

                // 3) Parse last two digits as runningNo  
                if (!int.TryParse(codePart.Substring(2), out int runningNo))
                    continue;

                // 4) Apply only the ACCESSORIES filter  
                if (type == ToolingStructureType.ACCESSORIES || type == ToolingStructureType.INSERT)
                {
                    if (runningNo < defaultTypeCode)
                        continue;
                }

                if (
                    type == ToolingStructureType.ASSEMBLY ||
                    type == ToolingStructureType.UPPER_PAD_SPACER ||
                    type == ToolingStructureType.UPPER_PAD ||
                    type == ToolingStructureType.PUNCH_HOLDER ||
                    type == ToolingStructureType.BOTTOMING_PLATE ||
                    type == ToolingStructureType.STRIPPER_PLATE ||
                    type == ToolingStructureType.DIE_PLATE ||
                    type == ToolingStructureType.LOWER_PAD ||
                    type == ToolingStructureType.LOWER_PAD_SPACER
                    )
                {
                    continue;
                }

                // Include everything else
                runningNumbers.Add(runningNo);

            }

            if (runningNumbers.Count > 0)
            {
                int nextRunningNo = runningNumbers.Max() + 1;
                return stationPart + nextRunningNo.ToString("D2");
            }

            return GetDrawingCodeFromType(type, stnNumber);
        }

        public string GenerateDrawingCode(ToolingStructureType type, string dirPath, string codePrefix, int stnNumber = 0)
        {
            return $"{codePrefix}{AskNextRunningNumber(type, dirPath, codePrefix, stnNumber)}";
        }

        public string GenerateFolderCode(ToolingStructureType type, string dirPath, string codePrefix, string itemName, int stnNumber = 0)
        {
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

        // Static utility methods (no dependencies required)
        public static string ReplaceSpacesWithUnderscore(string input)
        {
            return input.Trim().Replace(" ", "_") ?? string.Empty;
        }

        public static int GenerateNextNumber(int currentNumber, int increment = 1)
        {
            return currentNumber + increment;
        }

        public static Tuple<string, string> NormalizeDrawingCodeParts(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return new Tuple<string, string>("Invalid", "Invalid");
            }

            // Trim trailling hypens
            input = input.TrimEnd('-');

            // Split the input into parts
            string[] parts = input.Split('-');

            if (parts.Length < 2)
            {
                return new Tuple<string, string>("Invalid", "Invalid");
            }

            string prefixRaw = parts[0];
            string suffix = parts[1];

            // Normalize prefix
            string prefix = (prefixRaw.Length >= 6)
            ? prefixRaw.Substring(0, 6) : prefixRaw.PadRight(6, 'x');

            return Tuple.Create(prefix, suffix);
        }

        public static string GetDrawingCode(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty.");

            string[] segments = input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);

            if (segments.Length < 3)
                throw new ArgumentException("Input string is not in a valid drawing code format.", nameof(input));

            string drawingCodeCandidate = segments[2];
            int delimiterIndex = drawingCodeCandidate.IndexOfAny(new[] { '_', '-' });

            string drawingCode = delimiterIndex > 0
                ? drawingCodeCandidate.Substring(0, delimiterIndex)
                : drawingCodeCandidate;

            if (!IsValidDrawingCode(drawingCode))
                throw new ArgumentException("Extracted drawing code is invalid. Expected a 4-digit number.", nameof(input));

            return drawingCode;
        }
        private static bool IsValidDrawingCode(string code)
        {
            return !string.IsNullOrEmpty(code) && code.Length == 4 && code.All(char.IsDigit);
        }
        public static string GetDrawingCodeFromType(ToolingStructureType type, int stnNumber = 0)
        {
            // Mapping of ToolingStructureType to its fixed type code
            var typeCodeMap = new Dictionary<ToolingStructureType, int>
            {
                { ToolingStructureType.SHOE, 1},
                { ToolingStructureType.ACCESSORIES, 30},
                { ToolingStructureType.UPPER_PAD_SPACER, 1},
                { ToolingStructureType.UPPER_PAD, 2},
                { ToolingStructureType.PUNCH_HOLDER, 3},
                { ToolingStructureType.BOTTOMING_PLATE, 4},
                { ToolingStructureType.STRIPPER_PLATE, 5},
                { ToolingStructureType.DIE_PLATE, 6},
                { ToolingStructureType.LOWER_PAD, 7},
                { ToolingStructureType.LOWER_PAD_SPACER, 8},
                { ToolingStructureType.INSERT, 11},
                { ToolingStructureType.ASSEMBLY, 0}
            };

            if (!typeCodeMap.TryGetValue(type, out int typeCode))
            {
                throw new ArgumentException($"Unsupported ToolingStructureType: {type}");
            }

            string stationPart = stnNumber.ToString("D2");
            string typePart = typeCode.ToString("D2");
            return stationPart + typePart;
        }

        public static string GetCodePrefix(string rawCodePrefix)
        {
            if (string.IsNullOrEmpty(rawCodePrefix))
            {
                throw new ArgumentException("Raw code prefix cannot be null or empty", nameof(rawCodePrefix));
            }

            var codeParts = NormalizeDrawingCodeParts(rawCodePrefix);
            string prefix = codeParts.Item1;
            string suffix = codeParts.Item2;
            return $"{prefix}-{suffix}-";
        }

        public static ToolingStructureType GetToolingType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Type cannot be null or empty", nameof(type));
            }

            if (Enum.TryParse<ToolingStructureType>(type, true, out ToolingStructureType result))
            {
                return result;
            }

            throw new ArgumentException($"Unsupported ToolingStructureType: {type}");
        }

        public static int GetStationNumber(string drawingCode)
        {
            string fourDigitCode = GetDrawingCode(drawingCode);
            string stnPart = fourDigitCode.Substring(0, 2);
            if (int.TryParse(stnPart, out int stnNumber))
            {
                return stnNumber;
            }
            else
            {
                throw new ArgumentException($"Invalid drawing code: {drawingCode}. Cannot extract station number.");
            }
        }
    }
}
