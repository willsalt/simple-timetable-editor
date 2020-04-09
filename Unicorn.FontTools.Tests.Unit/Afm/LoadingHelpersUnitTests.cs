using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class LoadingHelpersUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static string WhiteSpace(int minLength = 1) => _rnd.NextString(" ", _rnd.Next(minLength, 10));

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = null;

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsAfmFormatException_IfFirstParameterIsShorterThanSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(_rnd.Next(testParam0.Length + 1, testParam0.Length + 11));

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsAfmFormatException_IfFirstParameterIsSameLengthAsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(testParam0.Length);

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsAfmFormatException_IfFirstParameterConsistsOfSecondParameterPlusWhiteSpace()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace();

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ThrowsAfmFormatException_IfFirstParameterDataIsNotValidNumber()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedDecimalMethod_ReturnsExpectedValue_IfDataIsValid()
        {
            decimal expectedValue = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + expectedValue.ToString(CultureInfo.InvariantCulture);

            decimal testOutput = LoadingHelpers.LoadKeyedDecimal(testParam0, testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = null;

            _ = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ThrowsAfmFormatException_IfFirstParameterIsShorterThanSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(_rnd.Next(testParam0.Length + 1, testParam0.Length + 11));

            _ = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ThrowsAfmFormatException_IfFirstParameterIsSameLengthAsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(testParam0.Length);

            _ = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ThrowsAfmFormatException_IfFirstParameterConsistsOfSecondParameterPlusWhiteSpace()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace();

            _ = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedStringMethod_ReturnsExpectedValue_IfDataIsValid()
        {
            string expectedValue = _rnd.NextString(_rnd.Next(1, 20));
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + expectedValue;

            string testOutput = LoadingHelpers.LoadKeyedString(testParam0, testParam1);

            Assert.AreEqual(expectedValue, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = null;

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterIsShorterThanSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(_rnd.Next(testParam0.Length + 1, testParam0.Length + 11));

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterIsSameLengthAsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(testParam0.Length);

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterConsistsOfSecondParameterPlusWhiteSpace()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace();

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterContainsSingleNumber()
        {
            decimal xVector = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + xVector.ToString(CultureInfo.InvariantCulture);

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterContainsDataWhereFirstPartOfVectorIsNotANumber()
        {
            decimal yVector = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10)) + WhiteSpace() + 
                yVector.ToString(CultureInfo.InvariantCulture);

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ThrowsAfmFormatException_IfFirstParameterContainsDataWhereSecondPartOfVectorIsNotANumber()
        {
            decimal xVector = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + xVector.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + 
                _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ReturnsValueWithCorrectXProperty_IfDataIsValid()
        {
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + xVector.ToString(CultureInfo.InvariantCulture) + WhiteSpace() + 
                yVector.ToString(CultureInfo.InvariantCulture);

            Vector testOutput = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.AreEqual(xVector, testOutput.X);
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedVectorMethod_ReturnsValueWithCorrectYProperty_IfDataIsValid()
        {
            decimal xVector = _rnd.NextDecimal();
            decimal yVector = _rnd.NextDecimal();
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + xVector.ToString(CultureInfo.InvariantCulture) + WhiteSpace() +
                yVector.ToString(CultureInfo.InvariantCulture);

            Vector testOutput = LoadingHelpers.LoadKeyedVector(testParam0, testParam1);

            Assert.AreEqual(yVector, testOutput.Y);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            string testParam0 = null;
            string testParam1 = _rnd.NextString(_rnd.Next(1, 10));

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = null;

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsAfmFormatException_IfFirstParameterIsShorterThanSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(_rnd.Next(testParam0.Length + 1, testParam0.Length + 11));

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsAfmFormatException_IfFirstParameterIsSameLengthAsSecondParameter()
        {
            string testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            string testParam1 = _rnd.NextString(testParam0.Length);

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsAfmFormatException_IfFirstParameterConsistsOfSecondParameterPlusWhiteSpace()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace();

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(AfmFormatException))]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ThrowsAfmFormatException_IfFirstParameterDoesNotContainTrueOrFalse()
        {
            string badData;
            do
            {
                badData = _rnd.NextString(_rnd.Next(1, 10));
            } while (badData == "true" || badData == "false");
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + badData;

            _ = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ReturnsTrue_IfFirstParameterEndsInTrue()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + "true" + WhiteSpace(0);

            bool testOutput = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void LoadingHelpersClass_LoadKeyedBoolMethod_ReturnsFalse_IfFirstParameterEndsInFalse()
        {
            string testParam1 = _rnd.NextString(RandomExtensions.AlphabeticalCharacters, _rnd.Next(1, 10));
            string testParam0 = testParam1 + WhiteSpace() + "false" + WhiteSpace(0);

            bool testOutput = LoadingHelpers.LoadKeyedBool(testParam0, testParam1);

            Assert.IsFalse(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
