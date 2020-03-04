using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Providers;
using Unicorn.Tests.Unit.TestHelpers;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class TableRowUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TableRowClass_ComputedWidthProperty_ReturnsSumOfComputedWidthPropertiesOfContents_IfParentPropertyIsNull()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            TableRow testObject = new TableRow { Parent = null };
            testObject.AddRange(testContents);

            double testOutput = testObject.ComputedWidth;

            Assert.AreEqual(testContents.Sum(c => c.ComputedWidth), testOutput);
        }

        [TestMethod]
        public void TableRowClass_ComputedWidthProperty_ReturnsSumOfComputedWidthPropertiesOfContentsPlusCalculatedGridlineWidths_IfParentPropertyIsNotNull()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            Table testParentProperty = new Table { RuleWidth = _rnd.NextDouble() * 3 };
            TableRow testObject = new TableRow { Parent = testParentProperty };
            testObject.AddRange(testContents);

            double testOutput = testObject.ComputedWidth;

            double cellWidths = testContents.Sum(c => c.ComputedWidth);
            double ruleWidths = (testContents.Count + 1) * testParentProperty.RuleWidth;
            Assert.AreEqual(cellWidths + ruleWidths, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
