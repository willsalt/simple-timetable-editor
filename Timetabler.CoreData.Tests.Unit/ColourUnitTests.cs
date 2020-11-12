using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.CoreData.Tests.Unit
{
    [TestClass]
    public class ColourUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA5394 // Do not use insecure randomness

        [TestMethod]
        public void ColourStruct_ConstructorWithUintParameter_SetsArgbPropertyToValueOfFirstParameter()
        {
            uint testParam0 = _rnd.NextUInt();

            Colour testOutput = new Colour(testParam0);

            Assert.AreEqual(testParam0, (uint)testOutput.Argb);
        }

        [TestMethod]
        public void ColourStruct_ConstructorWithIntParameter_SetsArgbPropertyToValueOfFirstParameter()
        {
            int testParam0 = _rnd.Next();

            Colour testOutput = new Colour(testParam0);

            Assert.AreEqual(testParam0, testOutput.Argb);
        }

        [TestMethod]
        public void ColourStruct_RProperty_ContainsCorrectBitsOfArgbProperty()
        {
            int expectedResult = _rnd.Next(256);
            uint constrParam0 = (_rnd.NextUInt() & 0xff00ffff) | (uint)(expectedResult << 16);
            Colour testValue = new Colour(constrParam0);

            int testOutput = testValue.R;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void ColourStruct_GProperty_ContainsCorrectBitsOfArgbProperty()
        {
            int expectedResult = _rnd.Next(256);
            uint constrParam0 = (_rnd.NextUInt() & 0xffff00ff) | (uint)(expectedResult << 8);
            Colour testValue = new Colour(constrParam0);

            int testOutput = testValue.G;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void ColourStruct_BProperty_ContainsCorrectBitsOfArgbProperty()
        {
            int expectedResult = _rnd.Next(256);
            uint constrParam0 = (_rnd.NextUInt() & 0xffffff00) | (uint)expectedResult;
            Colour testValue = new Colour(constrParam0);

            int testOutput = testValue.B;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void ColourStruct_BlackProperty_ReturnsValueWithCorrectArgbProperty()
        {
            Colour testValue = Colour.Black;

            uint testOutput = (uint)testValue.Argb;

            Assert.AreEqual(0xff000000, testOutput);
        }

        [TestMethod]
        public void ColourStruct_WhiteProperty_ReturnsValueWithCorrectArgbProperty()
        {
            Colour testValue = Colour.White;

            uint testOutput = (uint)testValue.Argb;

            Assert.AreEqual(0xffffffff, testOutput);
        }

        [TestMethod]
        public void ColourStruct_LightGreyProperty_ReturnsValueWithCorrectArgbProperty()
        {
            Colour testValue = Colour.LightGrey;

            uint testOutput = (uint)testValue.Argb;

            Assert.AreEqual(0xffd3d3d3, testOutput);
        }

        [TestMethod]
        public void ColourStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsColourValueWithSameArgbProperty()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testValue = new Colour(constrParam);
            object testParam = new Colour(testValue.Argb);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void ColourStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsColourValueWithDifferentArgbProperty()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testValue = new Colour(constrParam);
            uint testParamArgb;
            do
            {
                testParamArgb = _rnd.NextUInt();
            } while (testParamArgb == constrParam);
            object testParam = new Colour(testParamArgb);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void ColourStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testValue = new Colour(constrParam);
            object testParam = constrParam.ToString("X8", CultureInfo.InvariantCulture);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void ColourStruct_EqualsMethodWithColourParameter_ReturnsTrue_IfParameterIsColourValueWithSameArgbProperty()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testValue = new Colour(constrParam);
            Colour testParam = new Colour(testValue.Argb);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void ColourStruct_EqualsMethodWithColourParameter_ReturnsFalse_IfParameterIsColourValueWithDifferentArgbProperty()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testValue = new Colour(constrParam);
            uint testParamArgb;
            do
            {
                testParamArgb = _rnd.NextUInt();
            } while (testParamArgb == constrParam);
            Colour testParam = new Colour(testParamArgb);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void ColourStruct_GetHashCodeMethod_ReturnsSameValueForTwoColourValuesWithTheSameArgbProperty()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testValue0 = new Colour(constrParam);
            Colour testValue1 = new Colour(testValue0.Argb);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void ColourStruct_EqualityOperator_ReturnsTrue_IfOperandsHaveSameArgbProperty()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testOp0 = new Colour(constrParam);
            Colour testOp1 = new Colour(testOp0.Argb);

            bool testOutput = testOp0 == testOp1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void ColourStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentArgbProperty()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testOp0 = new Colour(constrParam);
            uint testParamArgb;
            do
            {
                testParamArgb = _rnd.NextUInt();
            } while (testParamArgb == constrParam);
            Colour testOp1 = new Colour(testParamArgb);

            bool testOutput = testOp0 == testOp1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void ColourStruct_InequalityOperator_ReturnsFalse_IfOperandsHaveSameArgbProperty()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testOp0 = new Colour(constrParam);
            Colour testOp1 = new Colour(testOp0.Argb);

            bool testOutput = testOp0 != testOp1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void ColourStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentArgbProperty()
        {
            uint constrParam = _rnd.NextUInt();
            Colour testOp0 = new Colour(constrParam);
            uint testParamArgb;
            do
            {
                testParamArgb = _rnd.NextUInt();
            } while (testParamArgb == constrParam);
            Colour testOp1 = new Colour(testParamArgb);

            bool testOutput = testOp0 != testOp1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
