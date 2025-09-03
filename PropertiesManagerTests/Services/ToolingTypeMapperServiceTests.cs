using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertiesManager.Constants;
using PropertiesManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services.Tests
{
    [TestClass()]
    public class ToolingTypeMapperServiceTests
    {
        private ToolingTypeMapperService _mapperService;

        [TestInitialize]
        public void Setup()
        {
            _mapperService = new ToolingTypeMapperService();
        }

        #region GetToolingStructureType Tests

        [TestMethod]
        public void GetToolingStructureType_SHOE_UPPER_SHOE_ReturnsSHOE()
        {
            // Act
            var result = _mapperService.GetToolingStructureType("SHOE", "UPPER SHOE");

            // Assert
            Assert.AreEqual(ToolingStructureType.SHOE, result);
        }

        [TestMethod]
        public void GetToolingStructureType_SHOE_LOWER_SHOE_ReturnsSHOE()
        {
            // Act
            var result = _mapperService.GetToolingStructureType("SHOE", "LOWER SHOE");

            // Assert
            Assert.AreEqual(ToolingStructureType.SHOE, result);
        }

        [TestMethod]
        public void GetToolingStructureType_PLATE_UPPER_PAD_ReturnsUPPER_PAD()
        {
            // Act
            var result = _mapperService.GetToolingStructureType("PLATE", "UPPER PAD");

            // Assert
            Assert.AreEqual(ToolingStructureType.UPPER_PAD, result);
        }

        [TestMethod]
        public void GetToolingStructureType_PLATE_DIE_PLATE_ReturnsDIE_PLATE()
        {
            // Act
            var result = _mapperService.GetToolingStructureType("PLATE", "DIE PLATE");

            // Assert
            Assert.AreEqual(ToolingStructureType.DIE_PLATE, result);
        }

        [TestMethod]
        public void GetToolingStructureType_PLATE_DIE_PLATE_R_ReturnsDIE_PLATE()
        {
            // Act - Both DIE PLATE-R and DIE PLATE-F should map to DIE_PLATE
            var result = _mapperService.GetToolingStructureType("PLATE", "DIE PLATE-R");

            // Assert
            Assert.AreEqual(ToolingStructureType.DIE_PLATE, result);
        }

        [TestMethod]
        public void GetToolingStructureType_PLATE_DIE_PLATE_F_ReturnsDIE_PLATE()
        {
            // Act
            var result = _mapperService.GetToolingStructureType("PLATE", "DIE PLATE-F");

            // Assert
            Assert.AreEqual(ToolingStructureType.DIE_PLATE, result);
        }

        [TestMethod]
        public void GetToolingStructureType_INSERT_AnyItem_ReturnsINSERT()
        {
            // Arrange - Test various INSERT items
            var insertItems = new[]
            {
                "DIE INSERT",
                "FORMING INSERT",
                "CUTTING PUNCH",
                "PILOT"
            };

            foreach (var item in insertItems)
            {
                // Act
                var result = _mapperService.GetToolingStructureType("INSERT", item);

                // Assert
                Assert.AreEqual(ToolingStructureType.INSERT, result, $"Failed for INSERT item: {item}");
            }
        }

        [TestMethod]
        public void GetToolingStructureType_WCBLK_WC_BLOCK_ReturnsWCBLK()
        {
            // Act
            var result = _mapperService.GetToolingStructureType("W/C BLK", "WC BLOCK");

            // Assert
            Assert.AreEqual(ToolingStructureType.WCBLK, result);
        }

        [TestMethod]
        public void GetToolingStructureType_OTHERS_CHUTE_ReturnsACCESSORIES()
        {
            // Act
            var result = _mapperService.GetToolingStructureType("OTHERS", "CHUTE");

            // Assert
            Assert.AreEqual(ToolingStructureType.ACCESSORIES, result);
        }

        [TestMethod]
        public void GetToolingStructureType_ASM_AnyItem_ReturnsASSEMBLY()
        {
            // Arrange - Test various ASSEMBLY items
            var assemblyItems = new[]
            {
                "MAIN ASSEMBLY",
                "TOP ASSEMBLY",
                "BOTTOM ASSEMBLY"
            };

            foreach (var item in assemblyItems)
            {
                // Act
                var result = _mapperService.GetToolingStructureType("ASM", item);

                // Assert
                Assert.AreEqual(ToolingStructureType.ASSEMBLY, result, $"Failed for ASM item: {item}");
            }
        }

        [TestMethod]
        public void GetToolingStructureType_AllPlateTypes_ReturnCorrectTypes()
        {
            // Arrange - Test all PLATE subtypes
            var plateTestCases = new[]
            {
                new { ItemName = "UPPER PAD SPACER", Expected = ToolingStructureType.UPPER_PAD_SPACER },
                new { ItemName = "UPPER PAD", Expected = ToolingStructureType.UPPER_PAD },
                new { ItemName = "PUNCH HOLDER", Expected = ToolingStructureType.PUNCH_HOLDER },
                new { ItemName = "BOTTOMING PLATE", Expected = ToolingStructureType.BOTTOMING_PLATE },
                new { ItemName = "STRIPPER PLATE", Expected = ToolingStructureType.STRIPPER_PLATE },
                new { ItemName = "DIE PLATE", Expected = ToolingStructureType.DIE_PLATE },
                new { ItemName = "LOWER PAD", Expected = ToolingStructureType.LOWER_PAD },
                new { ItemName = "LOWER PAD SPACER", Expected = ToolingStructureType.LOWER_PAD_SPACER }
            };

            foreach (var testCase in plateTestCases)
            {
                // Act
                var result = _mapperService.GetToolingStructureType("PLATE", testCase.ItemName);

                // Assert
                Assert.AreEqual(testCase.Expected, result, $"Failed for PLATE item: {testCase.ItemName}");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetToolingStructureType_InvalidPartType_ThrowsException()
        {
            // Act & Assert
            _mapperService.GetToolingStructureType("INVALID_PART_TYPE", "SOME_ITEM");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetToolingStructureType_InvalidItemName_ThrowsException()
        {
            // Act & Assert
            _mapperService.GetToolingStructureType("PLATE", "INVALID_ITEM_NAME");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetToolingStructureType_EmptyPartType_ThrowsException()
        {
            // Act & Assert
            _mapperService.GetToolingStructureType("", "UPPER PAD");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetToolingStructureType_EmptyItemName_ThrowsException()
        {
            // Act & Assert
            _mapperService.GetToolingStructureType("PLATE", "");
        }

        #endregion

        #region IsValidCombination Tests

        [TestMethod]
        public void IsValidCombination_ValidShoeCombination_ReturnsTrue()
        {
            // Act & Assert
            Assert.IsTrue(_mapperService.IsValidCombination("SHOE", "UPPER SHOE"));
            Assert.IsTrue(_mapperService.IsValidCombination("SHOE", "LOWER SHOE"));
            Assert.IsTrue(_mapperService.IsValidCombination("SHOE", "PARALLEL BAR"));
        }

        [TestMethod]
        public void IsValidCombination_ValidPlateCombination_ReturnsTrue()
        {
            // Act & Assert
            Assert.IsTrue(_mapperService.IsValidCombination("PLATE", "UPPER PAD"));
            Assert.IsTrue(_mapperService.IsValidCombination("PLATE", "DIE PLATE"));
            Assert.IsTrue(_mapperService.IsValidCombination("PLATE", "STRIPPER PLATE"));
        }

        [TestMethod]
        public void IsValidCombination_InvalidCombination_ReturnsFalse()
        {
            // Act & Assert - SHOE items shouldn't work with PLATE part type
            Assert.IsFalse(_mapperService.IsValidCombination("PLATE", "UPPER SHOE"));
            Assert.IsFalse(_mapperService.IsValidCombination("SHOE", "UPPER PAD"));
            Assert.IsFalse(_mapperService.IsValidCombination("INSERT", "DIE PLATE"));
        }

        [TestMethod]
        public void IsValidCombination_EmptyInputs_ReturnsFalse()
        {
            // Act & Assert
            Assert.IsFalse(_mapperService.IsValidCombination("", "UPPER PAD"));
            Assert.IsFalse(_mapperService.IsValidCombination("PLATE", ""));
            Assert.IsFalse(_mapperService.IsValidCombination("", ""));
        }

        [TestMethod]
        public void IsValidCombination_UnknownPartType_ReturnsFalse()
        {
            // Act & Assert
            Assert.IsFalse(_mapperService.IsValidCombination("UNKNOWN_TYPE", "UPPER PAD"));
        }

        #endregion

        #region GetValidItemNames Tests

        [TestMethod]
        public void GetValidItemNames_SHOE_ReturnsShoeItems()
        {
            // Act
            var result = _mapperService.GetValidItemNames("SHOE");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            CollectionAssert.Contains(result, "UPPER SHOE");
            CollectionAssert.Contains(result, "LOWER SHOE");
            CollectionAssert.Contains(result, "PARALLEL BAR");
        }

        [TestMethod]
        public void GetValidItemNames_PLATE_ReturnsPlateItems()
        {
            // Act
            var result = _mapperService.GetValidItemNames("PLATE");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            CollectionAssert.Contains(result, "UPPER PAD");
            CollectionAssert.Contains(result, "DIE PLATE");
            CollectionAssert.Contains(result, "STRIPPER PLATE");
        }

        [TestMethod]
        public void GetValidItemNames_INSERT_ReturnsInsertItems()
        {
            // Act
            var result = _mapperService.GetValidItemNames("INSERT");

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            // Check for some common INSERT items
            CollectionAssert.Contains(result, "DIE INSERT");
        }

        [TestMethod]
        public void GetValidItemNames_UnknownPartType_ReturnsEmptyList()
        {
            // Act
            var result = _mapperService.GetValidItemNames("UNKNOWN_TYPE");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetValidItemNames_EmptyPartType_ReturnsEmptyList()
        {
            // Act
            var result = _mapperService.GetValidItemNames("");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        #endregion

        #region Static Method Tests

        [TestMethod]
        public void StaticGetToolingType_SHOE_UPPER_SHOE_ReturnsSHOE()
        {
            // Act
            var result = ToolingTypeMapperService.GetToolingType("SHOE", "UPPER SHOE");

            // Assert
            Assert.AreEqual(ToolingStructureType.SHOE, result);
        }

        [TestMethod]
        public void StaticGetToolingType_PLATE_DIE_PLATE_ReturnsDIE_PLATE()
        {
            // Act
            var result = ToolingTypeMapperService.GetToolingType("PLATE", "DIE PLATE");

            // Assert
            Assert.AreEqual(ToolingStructureType.DIE_PLATE, result);
        }

        #endregion
    }
}