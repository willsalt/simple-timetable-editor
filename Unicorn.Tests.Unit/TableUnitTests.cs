using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using Tests.Utility.Providers;
using Unicorn.Interfaces;
using Unicorn.Tests.Unit.TestHelpers;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class TableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private class TableDefinition
        {
            internal Table Table { get; } = new Table();

            internal List<double> ColumnWidths { get; } = new List<double>();

            internal List<double> RowHeights { get; } = new List<double>();
        }

        private TableDefinition GetTestObject()
        {
            int columns = _rnd.Next(1, 6);
            int rows = _rnd.Next(1, 10);
            TableDefinition def = new TableDefinition();
            for (int i = 0; i < columns; ++i)
            {
                def.ColumnWidths.Add((_rnd.NextDouble() + 0.001) * 10);
            }
            for (int y = 0; y < rows; ++y)
            {
                def.RowHeights.Add((_rnd.NextDouble() + 0.001) * 10);
                List<TableCell> currentRow = new List<TableCell>();
                for (int x = 0; x < columns; ++x)
                {
                    currentRow.Add(new FixedSizeTableCell(def.ColumnWidths[x], def.RowHeights[y]));
                }
                def.Table.AddRow(currentRow);
            }
            return def;
        }

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

        [TestMethod]
        public void TableClass_DrawAtMethod_CallsIGraphicsContextImplementationDrawLineMethodCorrectNumberOfTimes_IfTableRuleStyleIsLinesMeet()
        {
            TableDefinition testObjectDetails = GetTestObject();
            Table testObject = testObjectDetails.Table;
            testObject.RuleStyle = TableRuleStyle.LinesMeet;
            Mock<IGraphicsContext> testParam0Details = new Mock<IGraphicsContext>();
            double testParam1 = _rnd.NextDouble() * 100;
            double testParam2 = _rnd.NextDouble() * 100;

            testObject.DrawAt(testParam0Details.Object, testParam1, testParam2);

            testParam0Details.Verify(x => x.DrawLine(It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>(), It.IsAny<double>()),
                Times.Exactly(testObjectDetails.ColumnWidths.Count + testObjectDetails.RowHeights.Count + 2));
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
