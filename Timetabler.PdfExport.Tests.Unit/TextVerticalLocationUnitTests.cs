using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;

namespace Timetabler.PdfExport.Tests.Unit
{
    [TestClass]
    public class TextVerticalLocationUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TextVerticalLocationClass_Constructor_SetsClearanceTopPropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            TextVerticalLocation testOutput = new TextVerticalLocation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam0, testOutput.ClearanceTop);
        }

        [TestMethod]
        public void TextVerticalLocationClass_Constructor_SetsTopPropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            TextVerticalLocation testOutput = new TextVerticalLocation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam1, testOutput.Top);
        }

        [TestMethod]
        public void TextVerticalLocationClass_Constructor_SetsBaselinePropertyToValueOfThirdParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            TextVerticalLocation testOutput = new TextVerticalLocation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam2, testOutput.Baseline);
        }

        [TestMethod]
        public void TextVerticalLocationClass_Constructor_SetsBottomPropertyToValueOfFourthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            TextVerticalLocation testOutput = new TextVerticalLocation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam3, testOutput.Bottom);
        }

        [TestMethod]
        public void TextVerticalLocationClass_Constructor_SetsClearanceBottomPropertyToValueOfFifthParameter()
        {
            double testParam0 = _rnd.NextDouble() * 500;
            double testParam1 = _rnd.NextDouble() * 500;
            double testParam2 = _rnd.NextDouble() * 500;
            double testParam3 = _rnd.NextDouble() * 500;
            double testParam4 = _rnd.NextDouble() * 500;

            TextVerticalLocation testOutput = new TextVerticalLocation(testParam0, testParam1, testParam2, testParam3, testParam4);

            Assert.AreEqual(testParam4, testOutput.ClearanceBottom);
        }

        [TestMethod]
        public void TextVerticalLocationClass_ClearanceHeightProperty_EqualsDifferenceBetweenClearanceBottomAndClearanceTopProperties()
        {
            double constrParam0 = _rnd.NextDouble() * 500;
            double constrParam1 = _rnd.NextDouble() * 500;
            double constrParam2 = _rnd.NextDouble() * 500;
            double constrParam3 = _rnd.NextDouble() * 500;
            double constrParam4 = _rnd.NextDouble() * 500;
            TextVerticalLocation testObject = new TextVerticalLocation(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            double expectedResult = constrParam4 - constrParam0;

            double testOutput = testObject.ClearanceHeight;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TextVerticalLocationClass_TextMidLineProperty_EqualsMeanOfTopAndBottomProperties()
        {
            double constrParam0 = _rnd.NextDouble() * 500;
            double constrParam1 = _rnd.NextDouble() * 500;
            double constrParam2 = _rnd.NextDouble() * 500;
            double constrParam3 = _rnd.NextDouble() * 500;
            double constrParam4 = _rnd.NextDouble() * 500;
            TextVerticalLocation testObject = new TextVerticalLocation(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            double expectedResult = (constrParam1 + constrParam3) / 2;

            double testOutput = testObject.TextMidLine;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TextVerticalLocationClass_TextBodyMidLineProperty_EqualsMeanOfTopAndBaselineProperties()
        {
            double constrParam0 = _rnd.NextDouble() * 500;
            double constrParam1 = _rnd.NextDouble() * 500;
            double constrParam2 = _rnd.NextDouble() * 500;
            double constrParam3 = _rnd.NextDouble() * 500;
            double constrParam4 = _rnd.NextDouble() * 500;
            TextVerticalLocation testObject = new TextVerticalLocation(constrParam0, constrParam1, constrParam2, constrParam3, constrParam4);
            double expectedResult = (constrParam1 + constrParam2) / 2;

            double testOutput = testObject.TextBodyMidLine;

            Assert.AreEqual(expectedResult, testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
