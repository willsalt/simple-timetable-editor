using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.Writer.Primitives;

namespace Unicorn.Writer.Tests.Unit.Primitives
{
    [TestClass]
    public class PdfNameUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void PdfNameClass_Constructor_CreatesObjectWithValuePropertyEqualToParameter()
        {
            string testParam = _rnd.NextString(_rnd.Next(10) + 1);

            PdfName testOutput = new PdfName(testParam);

            Assert.AreEqual(testParam, testOutput.Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfNameClass_Constructor_ThrowsArgumentNullException_WhenParameterIsNull()
        {
            string testParam = null;

            _ = new PdfName(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PdfNameClass_Constructor_ThrowsArgumentOutOfRangeException_WhenParameterContainsWhiteSpaceCharacters()
        {
            string testParam;
            do
            {
                testParam = _rnd.NextString(RandomExtensions.AlphabeticalCharacters + RandomExtensions.WhiteSpaceCharacters, _rnd.Next(10) + 1);
            } while (!testParam.Any(c => RandomExtensions.WhiteSpaceCharacters.Contains(c, StringComparison.InvariantCulture)));

            _ = new PdfName(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PdfNameClass_Constructor_ThrowsArgumentOutOfRangeException_WhenParameterContainsDelimiterCharacters()
        {
            string testParam;
            do
            {
                testParam = _rnd.NextString(RandomExtensions.AlphabeticalCharacters + RandomExtensions.DelimiterCharacters, _rnd.Next(10) + 1);
            } while (!testParam.Any(c => RandomExtensions.DelimiterCharacters.Contains(c, StringComparison.InvariantCulture)));

            _ = new PdfName(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfNameClass_ByteLengthProperty_EqualsLengthOfConstructorParameterPlusTwo()
        {
            string testParam = _rnd.NextString(_rnd.Next(20));
            PdfName testObject = new PdfName(testParam);

            int testOutput = testObject.ByteLength;

            Assert.AreEqual(testParam.Length + 2, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfNameClass_WriteToMethodWithListParameter_ThrowsExceptionIfParameterIsNull()
        {
            string inputString = _rnd.NextString(_rnd.Next(20));
            PdfName testObject = new PdfName(inputString);
            List<byte> testParam = null;

            testObject.WriteTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfNameClass_WriteToMethodWithListParameter_WritesCorrectValueToList()
        {
            string inputString = _rnd.NextString(_rnd.Next(20));
            PdfName testObject = new PdfName(inputString);
            List<byte> testParam = new List<byte>();

            testObject.WriteTo(testParam);

            string testOutput = Encoding.ASCII.GetString(testParam.ToArray());
            Assert.AreEqual("/" + inputString + " ", testOutput);
        }
    }
}
