using Microsoft.VisualStudio.TestTools.UnitTesting;
using Park_n_Wash.Common;
using System;

namespace Park_n_Wash.CommonTest
{
    [TestClass]
    public class StringHandlerTest
    {
        [TestMethod]
        public void InsertSpacesTest()
        {
            // Arrange
            var source = "NormalSlot";
            var expected = "Normal Slot";

            // Act
            var actual = source.InsertSpaces();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
