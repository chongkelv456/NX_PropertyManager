using Microsoft.VisualStudio.TestTools.UnitTesting;
using PropertiesManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertiesManager.Services.Tests
{
    [TestClass()]
    public class DrawingCodeServiceTests
    {
        [TestMethod()]
        public void GetCodePrefixFromDrawingCodeTest()
        {
            // Arrange
            string drawingCode = "40XC00-2401-01036";

            // Act
            string prefix = StaticCodeGeneratorService.GetCodePrefixFromDrawingCode(drawingCode);

            // Assert
            Assert.AreEqual("40XC00-2401-", prefix);
        }
    }
}