using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.Interfaces.Tests.Unit
{
    [TestClass]
    public class UniPointUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static UniPoint GetTestValue() => new UniPoint(_rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000);

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniPointStruct_ParameterlessConstructor_SetsXPropertyToZero()
        {
            UniPoint testOutput = new UniPoint();

            Assert.AreEqual(0d, testOutput.X);
        }

        [TestMethod]
        public void UniPointStruct_ParameterlessConstructor_SetsYPropertyToZero()
        {
            UniPoint testOutput = new UniPoint();

            Assert.AreEqual(0d, testOutput.Y);
        }

        [TestMethod]
        public void UniPointStruct_ConstructorWithTwoDoubleParameters_SetsXPropertyToValueOfFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;

            UniPoint testOutput = new UniPoint(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.X);
        }

        [TestMethod]
        public void UniPointStruct_ConstructorWithTwoDoubleParameters_SetsYPropertyToValueOfSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;

            UniPoint testOutput = new UniPoint(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Y);
        }

        [TestMethod]
        public void UniPointStruct_EqualsMethodWithUniPointParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            UniPoint testValue = GetTestValue();

            bool testOutput = testValue.Equals(testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualsMethodWithUniPointParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            UniPoint testValue = GetTestValue();
            UniPoint testParam = new UniPoint(testValue.X, testValue.Y);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualsMethodWithUniPointParameter_ReturnsFalse_IfParameterDiffersByXProperty()
        {
            UniPoint testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.X);
            UniPoint testParam = new UniPoint(constrParam, testValue.Y);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualsMethodWithUniPointParameter_ReturnsFalse_IfParameterDiffersByYProperty()
        {
            UniPoint testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.Y);
            UniPoint testParam = new UniPoint(testValue.X, constrParam);

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameValue()
        {
            UniPoint testValue = GetTestValue();

            bool testOutput = testValue.Equals((object)testValue);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsConstructedFromSameData()
        {
            UniPoint testValue = GetTestValue();
            UniPoint testParam = new UniPoint(testValue.X, testValue.Y);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByXProperty()
        {
            UniPoint testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.X);
            UniPoint testParam = new UniPoint(constrParam, testValue.Y);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterDiffersByYProperty()
        {
            UniPoint testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.Y);
            UniPoint testParam = new UniPoint(testValue.X, constrParam);

            bool testOutput = testValue.Equals((object)testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            UniPoint testValue = GetTestValue();
            string testParam = _rnd.NextString(_rnd.Next(50));

            bool testOutput = testValue.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceOnSameValue()
        {
            UniPoint testValue0 = GetTestValue();
            UniPoint testValue1 = new UniPoint(testValue0.X, testValue0.Y);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniPointStruct_EqualityOperator_ReturnsTrue_IfOperandsAreSameValue()
        {
            UniPoint testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue == testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualityOperator_ReturnsTrue_IfOperandsAreConstructedFromSameData()
        {
            UniPoint testValue = GetTestValue();
            UniPoint testParam = new UniPoint(testValue.X, testValue.Y);

            bool testOutput = testValue == testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByXProperty()
        {
            UniPoint testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.X);
            UniPoint testParam = new UniPoint(constrParam, testValue.Y);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_EqualityOperator_ReturnsFalse_IfOperandsDifferByYProperty()
        {
            UniPoint testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.Y);
            UniPoint testParam = new UniPoint(testValue.X, constrParam);

            bool testOutput = testValue == testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_InequalityOperator_ReturnsFalse_IfOperandsAreSameValue()
        {
            UniPoint testValue = GetTestValue();

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testValue != testValue;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_InequalityOperator_ReturnsFalse_IfOperandsAreConstructedFromSameData()
        {
            UniPoint testValue = GetTestValue();
            UniPoint testParam = new UniPoint(testValue.X, testValue.Y);

            bool testOutput = testValue != testParam;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByXProperty()
        {
            UniPoint testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.X);
            UniPoint testParam = new UniPoint(constrParam, testValue.Y);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniPointStruct_InequalityOperator_ReturnsTrue_IfOperandsDifferByYProperty()
        {
            UniPoint testValue = GetTestValue();
            double constrParam;
            do
            {
                constrParam = _rnd.NextDouble() * 1000;
            } while (constrParam == testValue.Y);
            UniPoint testParam = new UniPoint(testValue.X, constrParam);

            bool testOutput = testValue != testParam;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
