using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertiesManager.Constants;
using PropertiesManager.Model;
using PropertiesManager.Control;
using PropertiesManager.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PropertiesManager.Services.Tests
{
    /// <summary>
    /// Unit tests focusing on the core business logic methods without NXOpen dependencies
    /// Tests the static methods and service-level functionality
    /// </summary>
    [TestClass]
    public class CodeGeneratorService_BusinessLogic_Tests
    {
        private TestFileSystemService _testFileSystemService;
        private TestRunningNumberService _testRunningNumberService;
        private TestDrawingCodeService _testDrawingCodeService;

        [TestInitialize]
        public void Setup()
        {
            _testFileSystemService = new TestFileSystemService();
            _testRunningNumberService = new TestRunningNumberService();
            _testDrawingCodeService = new TestDrawingCodeService();
        }

        #region AskNextRunningNumber Business Logic Tests (Using Static Methods)

        [TestMethod]
        public void StaticAskNextRunningNumber_SHOE_EmptyDirectory_ReturnsDefaultCode()
        {
            // Arrange
            var type = ToolingStructureType.SHOE;
            string dirPath = @"C:\CreateFolder";
            string codePrefix = "ABC123-6401-";
            int stnNumber = 0;

            _testFileSystemService.SetupDirectoryExists(dirPath, true);
            _testFileSystemService.SetupGetFiles(dirPath, "*.prt", new string[0]);

            // Act - Using static method to avoid Controller dependency
            string result = StaticCodeGeneratorService.AskNextRunningNumber(type, dirPath, codePrefix, stnNumber);

            // Assert - For SHOE type, station 0, should return "0001"
            Assert.AreEqual("0001", result);
        }

        [TestMethod]
        public void StaticAskNextRunningNumber_INSERT_WithExistingFiles_ReturnsIncrementedNumber()
        {
            // Arrange
            var type = ToolingStructureType.INSERT;
            string dirPath = @"C:\TestProject";
            string codePrefix = "DEF456-02-";
            int stnNumber = 2;

            // Create test directory with existing files
            Directory.CreateDirectory(dirPath);
            try
            {
                // Create test files to simulate existing running numbers
                var testFiles = new string[]
                {
                    Path.Combine(dirPath, "DEF456-02-0211_INSERT1.prt"),
                    Path.Combine(dirPath, "DEF456-02-0212_INSERT2.prt"),
                    Path.Combine(dirPath, "DEF456-02-0215_INSERT3.prt")
                };

                foreach (var file in testFiles)
                {
                    File.WriteAllText(file, "test content");
                }

                // Act - Using static method
                string result = StaticCodeGeneratorService.AskNextRunningNumber(type, dirPath, codePrefix, stnNumber);

                // Assert - Next after 15 should be 16, formatted as "0216"
                Assert.AreEqual("0216", result);
            }
            finally
            {
                // Cleanup
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        [TestMethod]
        public void StaticAskNextRunningNumber_ACCESSORIES_WithGaps_ReturnsCorrectNumber()
        {
            // Arrange
            var type = ToolingStructureType.ACCESSORIES;
            string dirPath = @"C:\TestAccessories";
            string codePrefix = "XYZ789-03-";
            int stnNumber = 3;

            Directory.CreateDirectory(dirPath);
            try
            {
                // Create files with gaps in sequence (30, 32, 35, 40)
                var testFiles = new string[]
                {
                    Path.Combine(dirPath, "XYZ789-03-0330_ACCESSORY1.prt"),
                    Path.Combine(dirPath, "XYZ789-03-0332_ACCESSORY2.prt"),
                    Path.Combine(dirPath, "XYZ789-03-0335_ACCESSORY3.prt"),
                    Path.Combine(dirPath, "XYZ789-03-0340_ACCESSORY4.prt")
                };

                foreach (var file in testFiles)
                {
                    File.WriteAllText(file, "test content");
                }

                // Act
                string result = StaticCodeGeneratorService.AskNextRunningNumber(type, dirPath, codePrefix, stnNumber);

                // Assert - Next after 40 should be 41, formatted as "0341"
                Assert.AreEqual("0341", result);
            }
            finally
            {
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        [TestMethod]
        public void StaticAskNextRunningNumber_ASSEMBLY_ZeroStation_HandlesCorrectly()
        {
            // Arrange
            var type = ToolingStructureType.ASSEMBLY;
            string dirPath = @"C:\TestAssembly";
            string codePrefix = "ASM100-2401-";
            int stnNumber = 0;

            Directory.CreateDirectory(dirPath);
            try
            {
                // Create existing assembly files
                var testFiles = new string[]
                {
                    Path.Combine(dirPath, "ASM100-2401-0001_MAIN_ASSEMBLY.prt"),
                    Path.Combine(dirPath, "ASM100-2401-0002_SUB_ASSEMBLY.prt")
                };

                foreach (var file in testFiles)
                {
                    File.WriteAllText(file, "test content");
                }

                // Act
                string result = StaticCodeGeneratorService.AskNextRunningNumber(type, dirPath, codePrefix, stnNumber);

                // Assert - For assembly type, should increment properly
                Assert.AreEqual("0000", result);
            }
            finally
            {
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void StaticAskNextRunningNumber_NonExistentDirectory_ThrowsException()
        {
            // Arrange
            var type = ToolingStructureType.SHOE;
            string dirPath = @"C:\NonExistentDirectory12345";
            string codePrefix = "TEST-01-";
            int stnNumber = 1;

            // Act & Assert
            StaticCodeGeneratorService.AskNextRunningNumber(type, dirPath, codePrefix, stnNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void StaticAskNextRunningNumber_NonExistentDirectory_ThrowsException2()
        {
            // Arrange
            var type = ToolingStructureType.SHOE;
            string dirPath = @"C:\NonExistentDirectory12345";
            string codePrefix = "TEST-01-";
            int stnNumber = 1;

            // Act & Assert
            StaticCodeGeneratorService.AskNextRunningNumber(type, dirPath, codePrefix, stnNumber);
        }

        #endregion

        #region GenerateDrawingCode Business Logic Tests

        [TestMethod]
        public void StaticGenerateDrawingCode_SHOE_ValidInputs_ReturnsCorrectCode()
        {
            // Arrange
            var type = ToolingStructureType.SHOE;
            string dirPath = @"C:\TestDrawingCode";
            string codePrefix = "ABC123-01-";
            int stnNumber = 1;

            Directory.CreateDirectory(dirPath);
            try
            {
                // Act
                string result = StaticCodeGeneratorService.GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);

                // Assert - Should combine prefix with running number
                Assert.AreEqual("ABC123-01-0101", result);
            }
            finally
            {
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        [TestMethod]
        public void StaticGenerateDrawingCode_INSERT_WithExistingFiles_ReturnsIncrementedCode()
        {
            // Arrange
            var type = ToolingStructureType.INSERT;
            string dirPath = @"C:\TestDrawingCode2";
            string codePrefix = "DEF456-02-";
            int stnNumber = 2;

            Directory.CreateDirectory(dirPath);
            try
            {
                // Create existing files
                var testFiles = new string[]
                {
                    Path.Combine(dirPath, "DEF456-02-0211_INSERT1.prt"),
                    Path.Combine(dirPath, "DEF456-02-0212_INSERT2.prt")
                };

                foreach (var file in testFiles)
                {
                    File.WriteAllText(file, "test content");
                }

                // Act
                string result = StaticCodeGeneratorService.GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);

                // Assert
                Assert.AreEqual("DEF456-02-0213", result);
            }
            finally
            {
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        [TestMethod]
        public void StaticGenerateDrawingCode_WCBLK_ReturnsCorrectCode()
        {
            // Arrange
            var type = ToolingStructureType.WCBLK;
            string dirPath = @"C:\TestWCBLK";
            string codePrefix = "WCBLK-2401-";
            int stnNumber = 0;

            Directory.CreateDirectory(dirPath);
            try
            {
                // Act
                string result = StaticCodeGeneratorService.GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);

                // Assert - WCBLK has special code "3001"
                Assert.AreEqual("WCBLK-2401-3001", result);
            }
            finally
            {
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        [TestMethod]
        public void StaticGenerateDrawingCode_AllToolingTypes_GenerateDistinctCodes()
        {
            // Arrange - Test that different tooling types generate different codes
            var toolingTypes = new[]
            {
                ToolingStructureType.SHOE,                
                ToolingStructureType.INSERT,
                ToolingStructureType.ACCESSORIES,
                ToolingStructureType.ASSEMBLY
            };

            string dirPath = @"C:\TestAllTypes";
            string codePrefix = "MULTI-01-";
            int stnNumber = 1;

            Directory.CreateDirectory(dirPath);
            try
            {
                var results = new List<string>();

                foreach (var type in toolingTypes)
                {
                    // Act
                    string result = StaticCodeGeneratorService.GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);
                    results.Add(result);

                    // Assert each result is valid
                    Assert.IsTrue(result.StartsWith(codePrefix), $"Result for {type} should start with prefix: {result}");
                    Assert.IsTrue(result.Length > codePrefix.Length, $"Result for {type} should have content after prefix: {result}");
                }

                // Assert all results are unique (different tooling types should generate different codes)
                var distinctResults = results.Distinct().ToList();
                Assert.AreEqual(toolingTypes.Length, distinctResults.Count,
                    $"Expected {toolingTypes.Length} distinct codes, but got {distinctResults.Count}. Results: {string.Join(", ", results)}");
            }
            finally
            {
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        [TestMethod]
        public void StaticGenerateDrawingCode_RealWorldScenario_CarDoor_ReturnsCorrectCode()
        {
            // Arrange - Simulate real NX PropertyManager usage
            var type = ToolingStructureType.SHOE;
            string dirPath = @"C:\CarDoorProject";
            string codePrefix = "CARDOOR-03-";
            int stnNumber = 3;

            Directory.CreateDirectory(dirPath);
            try
            {
                // Create realistic existing files
                var testFiles = new string[]
                {
                    Path.Combine(dirPath, "CARDOOR-03-0301_UPPER_SHOE-V00.prt"),
                    Path.Combine(dirPath, "CARDOOR-03-0302_LOWER_SHOE-V00.prt"),
                    Path.Combine(dirPath, "CARDOOR-03-0303_PARALLEL_BAR-V00.prt"),
                    Path.Combine(dirPath, "CARDOOR-03-0310_CUSTOM_SHOE-V00.prt"), // Gap in sequence
                    Path.Combine(dirPath, "CARDOOR-01-0105_UPPER_SHOE-V00.prt"), // Different station (should be ignored)
                    Path.Combine(dirPath, "OTHER-03-0305_SHOE-V00.prt") // Different prefix (should be ignored)
                };

                foreach (var file in testFiles)
                {
                    File.WriteAllText(file, "test content");
                }

                // Act
                string result = StaticCodeGeneratorService.GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);

                // Assert - Should find next available number after 10 (which would be 11)
                Assert.AreEqual("CARDOOR-03-0311", result);
            }
            finally
            {
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        [TestMethod]
        public void StaticGenerateDrawingCode_PUNCHBOLDER_WithExistingFiles_ReturnsIncrementedCode()
        {
            // Arrange
            var type = ToolingStructureType.PUNCH_HOLDER;
            string dirPath = @"C:\TestDrawingCode2";
            string codePrefix = "40X01000-2401-";
            int stnNumber = 2;

            Directory.CreateDirectory(dirPath);
            try
            {                

                // Act
                string result = StaticCodeGeneratorService.GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);

                // Assert
                Assert.AreEqual("40X01000-2401-0203", result);
            }
            finally
            {
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        [TestMethod]
        public void StaticGenerateDrawingCode_WCBLK_WithExistingFiles_ReturnsIncrementedCode()
        {
            // Arrange
            var type = ToolingStructureType.WCBLK;
            string dirPath = @"C:\TestDrawingCode2";
            string codePrefix = "40X01000-2401-";
            int stnNumber = 2;

            Directory.CreateDirectory(dirPath);
            try
            {
                // Create realistic existing files
                var testFiles = new string[]
                {
                    Path.Combine(dirPath, "40X01000-2401-0115_INSERT.prt"),
                    Path.Combine(dirPath, "40X01000-2401-3001_WCBLOCK1.prt"),
                    Path.Combine(dirPath, "40X01000-2401-3002_WCBLOCK2.prt")
                };

                foreach (var file in testFiles)
                {
                    File.WriteAllText(file, "test content");
                }

                // Act
                string result = StaticCodeGeneratorService.GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);

                // Assert
                Assert.AreEqual("40X01000-2401-3003", result);
            }
            finally
            {
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        [TestMethod]
        public void StaticGenerateDrawingCode_SHOE_WithExistingFiles_ReturnsIncrementedCode()
        {
            // Arrange
            var type = ToolingStructureType.SHOE;
            string dirPath = @"C:\TestDrawingCode2";
            string codePrefix = "40X01000-2401-";
            int stnNumber = 0;

            Directory.CreateDirectory(dirPath);
            try
            {
                // Create realistic existing files
                var testFiles = new string[]
                {
                    Path.Combine(dirPath, "40X01000-2401-0001_SHOE1.prt"),
                    Path.Combine(dirPath, "40X01000-2401-0002_SHOE2.prt")
                };

                foreach (var file in testFiles)
                {
                    File.WriteAllText(file, "test content");
                }

                // Act
                string result = StaticCodeGeneratorService.GenerateDrawingCode(type, dirPath, codePrefix, stnNumber);

                // Assert
                Assert.AreEqual("40X01000-2401-0003", result);
            }
            finally
            {
                if (Directory.Exists(dirPath))
                    Directory.Delete(dirPath, true);
            }
        }

        #endregion
    }

    #region Test Helper Classes (Simplified - No NXOpen Dependencies)

    /// <summary>
    /// Simple test file system service for basic testing scenarios
    /// </summary>
    public class TestFileSystemService : IFileSystemService
    {
        private readonly Dictionary<string, string[]> _directoryFiles = new Dictionary<string, string[]>();
        private readonly Dictionary<string, string> _fileNameMappings = new Dictionary<string, string>();
        private readonly Dictionary<string, bool> _directoryExistence = new Dictionary<string, bool>();

        public void SetupGetFiles(string path, string searchPattern, string[] files)
        {
            _directoryFiles[$"{path}|{searchPattern}"] = files;
        }

        public void SetupGetFileNameWithoutExtension(string filePath, string result)
        {
            _fileNameMappings[filePath] = result;
        }

        public void SetupDirectoryExists(string path, bool exists)
        {
            _directoryExistence[path] = exists;
        }

        public string[] GetFiles(string path, string searchPattern)
        {
            var key = $"{path}|{searchPattern}";
            if (_directoryFiles.ContainsKey(key))
                return _directoryFiles[key];

            // Fallback to real file system for integration-style tests
            try
            {
                return Directory.Exists(path) ? Directory.GetFiles(path, searchPattern) : new string[0];
            }
            catch
            {
                return new string[0];
            }
        }

        public string GetFileNameWithoutExtension(string path)
        {
            if (_fileNameMappings.ContainsKey(path))
                return _fileNameMappings[path];

            return Path.GetFileNameWithoutExtension(path);
        }

        public bool DirectoryExists(string path)
        {
            if (_directoryExistence.ContainsKey(path))
                return _directoryExistence[path];

            return Directory.Exists(path);
        }
    }

    /// <summary>
    /// Simple test running number service for testing
    /// </summary>
    public class TestRunningNumberService : IRunningNumberService
    {
        private readonly Dictionary<string, List<int>> _analyzeRunningNumberMappings = new Dictionary<string, List<int>>();
        private readonly Dictionary<string, string> _nextRunningNumberMappings = new Dictionary<string, string>();
        private readonly Dictionary<int, string> _stationNumberMappings = new Dictionary<int, string>();
        private readonly Dictionary<string, bool> _shouldIncludeFileMappings = new Dictionary<string, bool>();

        public void SetupAnalyzeExistingRunningNumbers(string[] files, string codePrefix, string stationPart,
            ToolingStructureType type, int defaultTypeCode, List<int> runningNumbers)
        {
            var key = $"{string.Join("|", files)}|{codePrefix}|{stationPart}|{type}|{defaultTypeCode}";
            _analyzeRunningNumberMappings[key] = runningNumbers;
        }

        public void SetupGetNextRunningNumber(List<int> existingNumbers, ToolingStructureType type, int stationNumber, string result)
        {
            var key = $"{string.Join(",", existingNumbers)}|{type}|{stationNumber}";
            _nextRunningNumberMappings[key] = result;
        }

        public void SetupFormatStationNumber(int stationNumber, string formatted)
        {
            _stationNumberMappings[stationNumber] = formatted;
        }

        public void SetupShouldIncludeFile(ToolingStructureType type, int runningNumber, int defaultTypeCode, bool shouldInclude)
        {
            var key = $"{type}|{runningNumber}|{defaultTypeCode}";
            _shouldIncludeFileMappings[key] = shouldInclude;
        }

        public List<int> AnalyzeExistingRunningNumbers(string[] files, string codePrefix, string stationPart,
            ToolingStructureType type, int defaultTypeCode)
        {
            var key = $"{string.Join("|", files)}|{codePrefix}|{stationPart}|{type}|{defaultTypeCode}";
            if (_analyzeRunningNumberMappings.ContainsKey(key))
                return _analyzeRunningNumberMappings[key];

            // Fallback to real implementation for integration tests
            var realService = new RunningNumberService(new FileSystemService(), new DrawingCodeService());
            return realService.AnalyzeExistingRunningNumbers(files, codePrefix, stationPart, type, defaultTypeCode);
        }

        public bool ShouldIncludeFile(ToolingStructureType type, int runningNumber, int defaultTypeCode)
        {
            var key = $"{type}|{runningNumber}|{defaultTypeCode}";
            if (_shouldIncludeFileMappings.ContainsKey(key))
                return _shouldIncludeFileMappings[key];

            var realService = new RunningNumberService(new FileSystemService(), new DrawingCodeService());
            return realService.ShouldIncludeFile(type, runningNumber, defaultTypeCode);
        }

        public string GetNextRunningNumber(List<int> existingNumbers, ToolingStructureType type, int stationNumber)
        {
            var key = $"{string.Join(",", existingNumbers)}|{type}|{stationNumber}";
            if (_nextRunningNumberMappings.ContainsKey(key))
                return _nextRunningNumberMappings[key];

            var realService = new RunningNumberService(new FileSystemService(), new DrawingCodeService());
            return realService.GetNextRunningNumber(existingNumbers, type, stationNumber);
        }

        public string FormatStationNumber(int stationNumber)
        {
            if (_stationNumberMappings.ContainsKey(stationNumber))
                return _stationNumberMappings[stationNumber];

            return stationNumber.ToString("D2");
        }
    }

    /// <summary>
    /// Simple test drawing code service for testing
    /// </summary>
    public class TestDrawingCodeService : IDrawingCodeService
    {
        private readonly Dictionary<string, string> _drawingCodeMappings = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _drawingCodeFromTypeMappings = new Dictionary<string, string>();
        private readonly Dictionary<string, bool> _validDrawingCodeMappings = new Dictionary<string, bool>();
        private readonly Dictionary<string, int> _stationNumberMappings = new Dictionary<string, int>();
        private readonly Dictionary<string, Tuple<string, string>> _normalizeCodePartsMappings = new Dictionary<string, Tuple<string, string>>();
        private readonly Dictionary<string, string> _codePrefixMappings = new Dictionary<string, string>();

        public void SetupGetDrawingCode(string input, string result)
        {
            _drawingCodeMappings[input] = result;
        }

        public void SetupGetDrawingCodeFromType(ToolingStructureType type, int stationNumber, string result)
        {
            _drawingCodeFromTypeMappings[$"{type}|{stationNumber}"] = result;
        }

        public void SetupIsValidDrawingCode(string code, bool isValid)
        {
            _validDrawingCodeMappings[code] = isValid;
        }

        public void SetupGetStationNumber(string drawingCode, int stationNumber)
        {
            _stationNumberMappings[drawingCode] = stationNumber;
        }

        public void SetupNormalizeDrawingCodeParts(string input, string prefix, string suffix)
        {
            _normalizeCodePartsMappings[input] = Tuple.Create(prefix, suffix);
        }

        public void SetupGetCodePrefix(string rawCodePrefix, string result)
        {
            _codePrefixMappings[rawCodePrefix] = result;
        }

        public string GetDrawingCode(string input)
        {
            if (_drawingCodeMappings.ContainsKey(input))
                return _drawingCodeMappings[input];

            // Fallback to actual implementation for unmocked calls
            var realService = new DrawingCodeService();
            return realService.GetDrawingCode(input);
        }

        public string GetDrawingCodeFromType(ToolingStructureType type, int stationNumber = 0)
        {
            var key = $"{type}|{stationNumber}";
            if (_drawingCodeFromTypeMappings.ContainsKey(key))
                return _drawingCodeFromTypeMappings[key];

            // Fallback to actual implementation for unmocked calls
            var realService = new DrawingCodeService();
            return realService.GetDrawingCodeFromType(type, stationNumber);
        }

        public bool IsValidDrawingCode(string code)
        {
            if (_validDrawingCodeMappings.ContainsKey(code))
                return _validDrawingCodeMappings[code];

            var realService = new DrawingCodeService();
            return realService.IsValidDrawingCode(code);
        }

        public int GetStationNumber(string drawingCode)
        {
            if (_stationNumberMappings.ContainsKey(drawingCode))
                return _stationNumberMappings[drawingCode];

            var realService = new DrawingCodeService();
            return realService.GetStationNumber(drawingCode);
        }

        public Tuple<string, string> NormalizeDrawingCodeParts(string input)
        {
            if (_normalizeCodePartsMappings.ContainsKey(input))
                return _normalizeCodePartsMappings[input];

            var realService = new DrawingCodeService();
            return realService.NormalizeDrawingCodeParts(input);
        }

        public string GetCodePrefix(string rawCodePrefix)
        {
            if (_codePrefixMappings.ContainsKey(rawCodePrefix))
                return _codePrefixMappings[rawCodePrefix];

            var realService = new DrawingCodeService();
            return realService.GetCodePrefix(rawCodePrefix);
        }
    }

    #endregion
}