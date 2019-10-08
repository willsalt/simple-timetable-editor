using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Tests.Utility.Providers;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Tests.Unit.Primitives
{
    [TestClass]
    public class PdfIntegerUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void PdfIntegerClass_Constructor_CreatesObjectWithValuePropertyEqualToParameter()
        {
            int testParam = _rnd.Next(int.MinValue, int.MaxValue);

            PdfInteger testOutput = new PdfInteger(testParam);

            Assert.AreEqual(testParam, testOutput.Value);
        }

        [TestMethod]
        public void PdfIntegerClass_ByteLengthProperty_EqualsLengthOfValueDisplayedAsStringPlusOne()
        {
            int testObjectValue = _rnd.Next(int.MinValue, int.MaxValue);
            PdfInteger testObject = new PdfInteger(testObjectValue);
            int expectedResult = testObjectValue.ToString("d", CultureInfo.InvariantCulture).Length + 1;

            int testOutput = testObject.ByteLength;

            Assert.AreEqual(expectedResult, testOutput);
        }
    }
}
