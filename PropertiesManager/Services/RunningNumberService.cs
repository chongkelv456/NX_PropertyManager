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
    public class RunningNumberService : IRunningNumberService
    {
        private readonly IFileSystemService _fileSystemService;
        private readonly IDrawingCodeService _drawingCodeService;

        public RunningNumberService(IFileSystemService fileSystemService, IDrawingCodeService drawingCodeService)
        {
            _fileSystemService = fileSystemService ?? throw new ArgumentNullException(nameof(fileSystemService));
            _drawingCodeService = drawingCodeService ?? throw new ArgumentNullException(nameof(drawingCodeService));
        }

        public List<int> AnalyzeExistingRunningNumbers(string[] files, string codePrefix, string stationPart,
            ToolingStructureType type, int defaultTypeCode)
        {
            if (files == null)
                throw new ArgumentNullException(nameof(files));

            if (string.IsNullOrEmpty(codePrefix))
                throw new ArgumentException("Code prefix cannot be null or empty", nameof(codePrefix));

            if (string.IsNullOrEmpty(stationPart))
                throw new ArgumentException("Station part cannot be null or empty", nameof(stationPart));

            var runningNumbers = new List<int>();

            foreach (string file in files)
            {
                string fileName = _fileSystemService.GetFileNameWithoutExtension(file);

                bool isSkippStationCheckType = type == ToolingStructureType.WCBLK;
                if (!isSkippStationCheckType && !DoesFileMatchPrefix(fileName, codePrefix, stationPart))
                    continue;

                if (!TryExtractRunningNumber(fileName, stationPart, out int runningNumber))
                    continue;

                if (!ShouldIncludeFile(type, runningNumber, defaultTypeCode))
                    continue;

                runningNumbers.Add(runningNumber);
            }

            return runningNumbers;
        }

        public bool ShouldIncludeFile(ToolingStructureType type, int runningNumber, int defaultTypeCode)
        {
            // Apply ACCESSORIES and INSERT filter
            if (type == ToolingStructureType.ACCESSORIES || type == ToolingStructureType.INSERT)
            {
                if (runningNumber < defaultTypeCode)
                    return false;
            }

            // Exclude specific types
            if (IsExcludedType(type))
            {
                return false;
            }

            return true;
        }

        public string GetNextRunningNumber(List<int> existingNumbers, ToolingStructureType type, int stationNumber)
        {
            if (existingNumbers == null)
                throw new ArgumentNullException(nameof(existingNumbers));

            string stationPart = type == ToolingStructureType.WCBLK
                ? "30"
                : FormatStationNumber(stationNumber);

            if (existingNumbers.Count > 0)
            {
                int nextRunningNo = existingNumbers.Max() + 1;
                return stationPart + nextRunningNo.ToString("D2");
            }

            return _drawingCodeService.GetDrawingCodeFromType(type, stationNumber);
        }

        public string FormatStationNumber(int stationNumber)
        {
            if (stationNumber < 0)
                throw new ArgumentException("Station number cannot be negative", nameof(stationNumber));

            return stationNumber.ToString("D2");
        }

        private bool DoesFileMatchPrefix(string fileName, string codePrefix, string stationPart)
        {
            return !string.IsNullOrEmpty(fileName) && fileName.StartsWith(codePrefix + stationPart);
        }

        private bool TryExtractRunningNumber(string fileName, string stationPart, out int runningNumber)
        {
            runningNumber = -1;

            try
            {
                string codePart = _drawingCodeService.GetDrawingCode(fileName);

                if (codePart.Length != 4)
                    return false;

                return int.TryParse(codePart.Substring(2), out runningNumber);
            }
            catch
            {
                return false;
            }
        }

        private bool IsExcludedType(ToolingStructureType type)
        {
            var excludedTypes = new[]
            {
                ToolingStructureType.ASSEMBLY,
                ToolingStructureType.UPPER_PAD_SPACER,
                ToolingStructureType.UPPER_PAD,
                ToolingStructureType.PUNCH_HOLDER,
                ToolingStructureType.BOTTOMING_PLATE,
                ToolingStructureType.STRIPPER_PLATE,
                ToolingStructureType.DIE_PLATE,
                ToolingStructureType.LOWER_PAD,
                ToolingStructureType.LOWER_PAD_SPACER
            };

            return excludedTypes.Contains(type);
        }
    }
}
