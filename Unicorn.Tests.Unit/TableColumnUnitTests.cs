using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Providers;
using Unicorn.Tests.Unit.TestHelpers;

namespace Unicorn.Tests.Unit
{
    [TestClass]
    public class TableColumnUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TableColumnClass_ComputedHeightProperty_ReturnsSumOfComputedHeightPropertiesOfContents_IfParentPropertyIsNull()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            TableColumn testObject = new TableColumn { Parent = null };
            testObject.AddRange(testContents);

            double testOutput = testObject.ComputedHeight;

            Assert.AreEqual(testContents.Sum(c => c.ComputedHeight), testOutput);
        }

        [TestMethod]
        public void TableColumnClass_ComputedHeightProperty_ReturnSumOfComputedHeightPropertiesOfContentsPlusCalculatedGridLineWidths_IfParentPropertyIsNotNull()
        {
            List<TableCell> testContents = FixedSizeTableCell.GetCellList();
            Table testParentProperty = new Table { RuleWidth = _rnd.NextDouble() * 3 };
            TableColumn testObject = new TableColumn { Parent = testParentProperty };
            testObject.AddRange(testContents);

            double testOutput = testObject.ComputedHeight;

            double cellHeights = testContents.Sum(c => c.ComputedHeight);
            double ruleWidths = (testContents.Count + 1) * testParentProperty.RuleWidth;
            Assert.AreEqual(cellHeights + ruleWidths, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
