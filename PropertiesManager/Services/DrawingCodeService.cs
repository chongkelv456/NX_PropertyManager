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
    public class DrawingCodeService : IDrawingCodeService
    {
        private static readonly Dictionary<ToolingStructureType, int> TypeCodeMap = new Dictionary<ToolingStructureType, int>
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
            { ToolingStructureType.ASSEMBLY, 0},
            {ToolingStructureType.WCBLK, 1}
        };

        public string GetDrawingCode(string input)
        {
            if (string.IsNullOrEmpty(input))
                throw new ArgumentException("Input string cannot be null or empty", nameof(input));

            string[] segments = SplitInputString(input);
            ValidateSegmentCount(segments, input);

            string drawingCodeCandidate = ExtractDrawingCodeCandidate(segments);
            string drawingCode = ParseDrawingCode(drawingCodeCandidate);

            ValidateDrawingCode(drawingCode, input);

            return drawingCode;
        }

        public bool IsValidDrawingCode(string code)
        {
            return !string.IsNullOrEmpty(code) && code.Length == 4 && code.All(char.IsDigit);
        }

        public string GetDrawingCodeFromType(ToolingStructureType type, int stationNumber = 0)
        {
            if (!TypeCodeMap.TryGetValue(type, out int typeCode))
            {
                throw new ArgumentException($"Unsupported ToolingStructureType: {type}");
            }

            string stationPart = type == ToolingStructureType.WCBLK
                ? "30"
                : FormatStationNumber(stationNumber);
            string typePart = FormatTypeCode(typeCode);

            return stationPart + typePart;
        }

        public int GetStationNumber(string drawingCode)
        {
            string fourDigitCode = GetDrawingCode(drawingCode);
            string stationPart = ExtractStationPart(fourDigitCode);

            if (int.TryParse(stationPart, out int stationNumber))
            {
                return stationNumber;
            }

            throw new ArgumentException($"Invalid drawing code: {drawingCode}. Cannot extract station number.");
        }

        public Tuple<string, string> NormalizeDrawingCodeParts(string input)
        {
            if (string.IsNullOrEmpty(input))
                return new Tuple<string, string>("Invalid", "Invalid");

            // Trim trailing hyphens
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
            string prefix = NormalizePrefix(prefixRaw);

            return Tuple.Create(prefix, suffix);
        }

        public string GetCodePrefix(string rawCodePrefix)
        {
            if (string.IsNullOrEmpty(rawCodePrefix))
                throw new ArgumentException("Raw code prefix cannot be null or empty", nameof(rawCodePrefix));

            var codeParts = NormalizeDrawingCodeParts(rawCodePrefix);
            string prefix = codeParts.Item1;
            string suffix = codeParts.Item2;

            return $"{prefix}-{suffix}-";
        }

        // Private helper methods
        private string[] SplitInputString(string input)
        {
            return input.Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private void ValidateSegmentCount(string[] segments, string input)
        {
            if (segments.Length < 3)
                throw new ArgumentException("Input string is not in a valid drawing code format.", nameof(input));
        }

        private string ExtractDrawingCodeCandidate(string[] segments)
        {
            return segments[2];
        }

        private string ParseDrawingCode(string drawingCodeCandidate)
        {
            int delimiterIndex = drawingCodeCandidate.IndexOfAny(new[] { '_', '-' });

            return delimiterIndex > 0
                ? drawingCodeCandidate.Substring(0, delimiterIndex)
                : drawingCodeCandidate;
        }

        private void ValidateDrawingCode(string drawingCode, string originalInput)
        {
            if (!IsValidDrawingCode(drawingCode))
                throw new ArgumentException("Extracted drawing code is invalid. Expected a 4-digit number.", nameof(originalInput));
        }

        private string FormatStationNumber(int stationNumber)
        {
            return stationNumber.ToString("D2");
        }

        private string FormatTypeCode(int typeCode)
        {
            return typeCode.ToString("D2");
        }

        private string ExtractStationPart(string fourDigitCode)
        {
            return fourDigitCode.Substring(0, 2);
        }

        private string NormalizePrefix(string prefixRaw)
        {
            return (prefixRaw.Length >= 6)
                ? prefixRaw.Substring(0, 6)
                : prefixRaw.PadRight(6, 'x');
        }
    }
}
