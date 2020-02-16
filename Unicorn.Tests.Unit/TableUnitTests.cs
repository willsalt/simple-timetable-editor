using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class TableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TableClass_AddRowMethodWithTableRowParameter_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Table testObject = new Table();
            TableRow testParam = null;

            testObject.AddRow(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void TableClass_AddRowMethodWithTableRowParameter_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Table testObject = new Table();
            TableRow testParam = null;

            try
            {
                testObject.AddRow(testParam);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("row", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TableClass_AddColumnMethodWithTableColumnParameter_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Table testObject = new Table();
            TableColumn testParam = null;

            testObject.AddColumn(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void TableClass_AddColumnMethodWithTableColumnParameter_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Table testObject = new Table();
            TableColumn testParam = null;

            try
            {
                testObject.AddColumn(testParam);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("col", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TableClass_DrawAtMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            Table testObject = new Table();

            testObject.DrawAt(null, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000);

            Assert.Fail();
        }

        [TestMethod]
        public void TableClass_DrawAtMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            Table testObject = new Table();

            try
            {
                testObject.DrawAt(null, _rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("graphicsContext", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
