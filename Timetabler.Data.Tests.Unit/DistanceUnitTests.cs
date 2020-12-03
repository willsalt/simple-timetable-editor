using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Tests.Utility.Extensions;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class DistanceUnitTests
    {
        private readonly static Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DistanceStruct_MajorLabelProperty_HasCorrectValue()
        {
            Assert.AreEqual(Resources.Distance_MileageLabel, Distance.MajorLabel);
        }

        [TestMethod]
        public void DistanceStruct_MinorLabelProperty_HasCorrectValue()
        {
            Assert.AreEqual(Resources.Distance_ChainageLabel, Distance.MinorLabel);
        }

        [TestMethod]
        public void DistanceStruct_ConstructorWithNoParameters_SetsMileagePropertyToZero()
        {
            Distance testOutput = new Distance();

            Assert.AreEqual(0, testOutput.Mileage);
        }

        [TestMethod]
        public void DistanceStruct_ConstructorWithNoParameters_SetsChainagePropertyToZero()
        {
            Distance testOutput = new Distance();

            Assert.AreEqual(0d, testOutput.Chainage);
        }

        [TestMethod]
        public void DistanceStruct_ConstructorWithNoParameters_SetsAbsoluteDistancePropertyToZero()
        {
            Distance testOutput = new Distance();

            Assert.AreEqual(0d, testOutput.AbsoluteDistance);
        }

        [TestMethod]
        public void DistanceStruct_ConstructorWithIntAndDoubleParameters_SetsMileagePropertyToFirstParameter_WhenParametersAreNormalised()
        {
            int testParam0 = _rnd.Next(200);
            double testParam1 = _rnd.NextDouble() * 80;

            Distance testOutput = new Distance(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Mileage);
        }

        [TestMethod]
        public void DistanceStruct_ConstructorWithIntAndDoubleParameters_SetsChainagePropertyToFirstParameter_WhenParametersAreNormalised()
        {
            int testParam0 = _rnd.Next(200);
            double testParam1 = _rnd.NextDouble() * 80;

            Distance testOutput = new Distance(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Chainage);
        }

        [TestMethod]
        public void DistanceStruct_ConstructorWithIntAndDoubleParameters_SetsAbsoluteDistancePropertyToCorrectValue_WhenParametersAreNormalised()
        {
            int testParam0 = _rnd.Next(200);
            double testParam1 = _rnd.NextDouble() * 80;
            double expectedOutput = testParam0 + testParam1 / 80;

            Distance testOutput = new Distance(testParam0, testParam1);

            Assert.AreEqual(expectedOutput, testOutput.AbsoluteDistance);
        }

        [TestMethod]
        public void DistanceStruct_ConstructorWithIntAndDoubleParameters_SetsMileagePropertyToCorrectValue_WhenParametersAreNotNormalised()
        {
            int testParam0 = _rnd.Next(200);
            double testParam1 = 80 + _rnd.NextDouble() * 8000;
            int expectedResult = testParam0 + (int)(testParam1 / 80);

            Distance testOutput = new Distance(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput.Mileage);
        }

        [TestMethod]
        public void DistanceStruct_ConstructorWithIntAndDoubleParameters_SetsChainagePropertyToCorrectValue_WhenParametersAreNotNormalised()
        {
            int testParam0 = _rnd.Next(200);
            double testParam1 = 80 + _rnd.NextDouble() * 8000;
            double expectedResult = testParam1 - ((int)(testParam1 / 80)) * 80;

            Distance testOutput = new Distance(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput.Chainage);
        }

        [TestMethod]
        public void DistanceStruct_ConstructorWithIntAndDoubleParameters_SetsAbsoluteDistancePropertyToCorrectValue_WhenParametersAreNotNormalised()
        {
            int testParam0 = _rnd.Next(200);
            double testParam1 = 80 + _rnd.NextDouble() * 8000;
            double expectedOutput = testParam0 + testParam1 / 80;

            Distance testOutput = new Distance(testParam0, testParam1);

            Assert.AreEqual(expectedOutput, testOutput.AbsoluteDistance, 0.00000001);
        }

        [TestMethod]
        public void DistanceStruct_LessThanOperator_ReturnsTrue_IfMileagePropertyOfFirstOperandIsLessThanMileagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0 + _rnd.Next(1, 200);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 < testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_LessThanOperator_ReturnsTrue_IfMileagePropertyOfFirstOperandIsEqualToMileagePropertyOfSecondOperandAndChainagePropertyOfFirstOperandIsLessThanChainagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1 + _rnd.NextDouble() * (80 - testValue0Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 < testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_LessThanOperator_ReturnsFalse_IfOperandsAreEqual()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 < testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_LessThanOperator_ReturnsFalse_IfMileagePropertyOfFirstOperandIsEqualToMileagePropertyofSecondOperandAndChainagePropertyOfFirstOperandIsGreaterThanChainagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = _rnd.NextDouble() * testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 < testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_LessThanOperator_ReturnsFalse_IfMileagePropertyOfFirstOperandIsGreaterThanMileagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(testValue0Param0);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 < testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_LessThanOrEqualToOperator_ReturnsTrue_IfMileagePropertyOfFirstOperandIsLessThanMileagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0 + _rnd.Next(1, 200);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 <= testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_LessThanOrEqualToOperator_ReturnsTrue_IfMileagePropertyOfFirstOperandIsEqualToMileagePropertyOfSecondOperandAndChainagePropertyOfFirstOperandIsLessThanChainagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1 + _rnd.NextDouble() * (80 - testValue0Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 <= testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_LessThanOrEqualToOperator_ReturnsTrue_IfOperandsAreEqual()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 <= testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_LessThanOrEqualToOperator_ReturnsFalse_IfMileagePropertyOfFirstOperandIsEqualToMileagePropertyofSecondOperandAndChainagePropertyOfFirstOperandIsGreaterThanChainagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = _rnd.NextDouble() * testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 <= testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_LessThanOrEqualToOperator_ReturnsFalse_IfMileagePropertyOfFirstOperandIsGreaterThanMileagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(testValue0Param0);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 <= testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_GreaterThanOperator_ReturnsFalse_IfMileagePropertyOfFirstOperandIsLessThanMileagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0 + _rnd.Next(1, 200);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 > testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_GreaterThanOperator_ReturnsFalse_IfMileagePropertyOfFirstOperandIsEqualToMileagePropertyOfSecondOperandAndChainagePropertyOfFirstOperandIsLessThanChainagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1 + _rnd.NextDouble() * (80 - testValue0Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 > testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_GreaterThanOperator_ReturnsFalse_IfOperandsAreEqual()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 > testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_GreaterThanOperator_ReturnsTrue_IfMileagePropertyOfFirstOperandIsEqualToMileagePropertyofSecondOperandAndChainagePropertyOfFirstOperandIsGreaterThanChainagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = _rnd.NextDouble() * testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 > testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_GreaterThanOperator_ReturnsTrue_IfMileagePropertyOfFirstOperandIsGreaterThanMileagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(testValue0Param0);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 > testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_GreaterThanOrEqualToOperator_ReturnsFalse_IfMileagePropertyOfFirstOperandIsLessThanMileagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0 + _rnd.Next(1, 200);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 >= testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_GreaterThanOrEqualToOperator_ReturnsFalse_IfMileagePropertyOfFirstOperandIsEqualToMileagePropertyOfSecondOperandAndChainagePropertyOfFirstOperandIsLessThanChainagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1 + _rnd.NextDouble() * (80 - testValue0Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 >= testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_GreaterThanOrEqualToOperator_ReturnsTrue_IfOperandsAreEqual()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 >= testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_GreaterThanOrEqualToOperator_ReturnsTrue_IfMileagePropertyOfFirstOperandIsEqualToMileagePropertyofSecondOperandAndChainagePropertyOfFirstOperandIsGreaterThanChainagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = _rnd.NextDouble() * testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 >= testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_GreaterThanOrEqualToOperator_ReturnsTrue_IfMileagePropertyOfFirstOperandIsGreaterThanMileagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(testValue0Param0);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 >= testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualityOperator_ReturnsTrue_IfOperandsAreEqual()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 == testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualityOperator_ReturnsFalse_IfMileagePropertyOfFirstOperandEqualsMileagePropertyOfSecondOperandAndChainagePropertyOfFirstOperandDoesNotEqualChainagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1;
            do
            {
                testValue1Param1 = _rnd.NextDouble() * 80;
            } while (testValue0Param1 == testValue1Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 == testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualityOperator_ReturnsFalse_IfMileagePropertyOfFirstOperandDoesNotEqualMileagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0;
            do
            {
                testValue1Param0 = _rnd.Next(200);
            } while (testValue1Param0 == testValue0Param0);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 == testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualsMethodWithDistanceParameter_ReturnsTrue_IfParameterHasPropertiesEqualToValue()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0.Equals(testValue1);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualsMethodWithDistanceParameter_ReturnsFalse_IfMileagePropertyOfValueEqualsMileagePropertyOfParameterAndChainagePropertyOfValueDoesNotEqualChainagePropertyOfParameter()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1;
            do
            {
                testValue1Param1 = _rnd.NextDouble() * 80;
            } while (testValue0Param1 == testValue1Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0.Equals(testValue1);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualsMethodWithDistanceParameter_ReturnsFalse_IfMileagePropertyOfValueDoesNotEqualMileagePropertyOfParameter()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0;
            do
            {
                testValue1Param0 = _rnd.Next(200);
            } while (testValue1Param0 == testValue0Param0);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0.Equals(testValue1);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterHasPropertiesEqualToValue()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1;
            object testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0.Equals(testValue1);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfMileagePropertyOfValueEqualsMileagePropertyOfParameterAndChainagePropertyOfValueDoesNotEqualChainagePropertyOfParameter()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1;
            do
            {
                testValue1Param1 = _rnd.NextDouble() * 80;
            } while (testValue0Param1 == testValue1Param1);
            object testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0.Equals(testValue1);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfMileagePropertyOfValueDoesNotEqualMileagePropertyOfParameter()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0;
            do
            {
                testValue1Param0 = _rnd.Next(200);
            } while (testValue1Param0 == testValue0Param0);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            object testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0.Equals(testValue1);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCastException))]
        public void DistanceStruct_EqualsMethodWithObjectParameter_ThrowsInvalidCastException_IfParameterIsString()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            object testValue1 = _rnd.NextString(_rnd.Next(10));

            bool testOutput = testValue0.Equals(testValue1);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsDoubleEqualToAbsoluteDistancePropertyOfValue()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            object testValue1 = testValue0.AbsoluteDistance;

            bool testOutput = testValue0.Equals(testValue1);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsDoubleNotEqualToAbsoluteDistancePropertyOfValue()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            double testValue1Amount;
            do
            {
                testValue1Amount = _rnd.NextDouble() * 20;
            } while (testValue1Amount == testValue0.AbsoluteDistance);
            object testValue1 = testValue1Amount;

            bool testOutput = testValue0.Equals(testValue1);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_InequalityOperator_ReturnsFalse_IfOperandsAreEqual()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1 = testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 != testValue1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_InequalityOperator_ReturnsTrue_IfMileagePropertyOfFirstOperandEqualsMileagePropertyOfSecondOperandAndChainagePropertyOfFirstOperandDoesNotEqualChainagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(1, 200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = testValue0Param0;
            double testValue1Param1;
            do
            {
                testValue1Param1 = _rnd.NextDouble() * 80;
            } while (testValue0Param1 == testValue1Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 != testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_InequalityOperator_ReturnsTrue_IfMileagePropertyOfFirstOperandDoesNotEqualMileagePropertyOfSecondOperand()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0;
            do
            {
                testValue1Param0 = _rnd.Next(200);
            } while (testValue1Param0 == testValue0Param0);
            double testValue1Param1 = _rnd.NextDouble() * 80;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            bool testOutput = testValue0 != testValue1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void DistanceStruct_AddOperator_ReturnsValueWithMileagePropertyEqualToSumOfMileagePropertiesOfOperands_IfSumOfChainagePropertiesOfOperandsIsLessThan80()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(200);
            double testValue1Param1 = _rnd.NextDouble() * (80 - testValue0Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);
            int expectedResult = testValue0Param0 + testValue1Param0;

            Distance testOutput = testValue0 + testValue1;

            Assert.AreEqual(expectedResult, testOutput.Mileage);
        }

        [TestMethod]
        public void DistanceStruct_AddOperator_ReturnsValueWithChainagePropertyEqualToSumOfChainagePropertiesOfOperands_IfSumOfChainagePropertiesOfOperandsIsLessThan80()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(200);
            double testValue1Param1 = _rnd.NextDouble() * (80 - testValue0Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);
            double expectedResult = testValue0Param1 + testValue1Param1;

            Distance testOutput = testValue0 + testValue1;

            Assert.AreEqual(expectedResult, testOutput.Chainage);
        }

        [TestMethod]
        public void DistanceStruct_AddOperator_ReturnsValueWithMileagePropertyEqualToSumOfMileagePropertiesOfOperandsPlus1_IfSumOfChainagePropertiesOfOperandsIsGreaterThan80()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(200);
            double testValue1Param1 = (80 - testValue0Param1) + _rnd.NextDouble() * testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);
            int expectedResult = testValue0Param0 + testValue1Param0 + 1;

            Distance testOutput = testValue0 + testValue1;

            Assert.AreEqual(expectedResult, testOutput.Mileage);
        }

        [TestMethod]
        public void DistanceStruct_AddOperator_ReturnsValueWithChainagePropertyEqualToSumOfChainagePropertiesOfOperandsMinus80_IfSumOfChainagePropertiesOfOperandsIsGreaterThan80()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(200);
            double testValue1Param1 = (80 - testValue0Param1) + _rnd.NextDouble() * testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);
            double expectedResult = testValue0Param1 + testValue1Param1 - 80;

            Distance testOutput = testValue0 + testValue1;

            Assert.AreEqual(expectedResult, testOutput.Chainage);
        }

        [TestMethod]
        public void DistanceStruct_AddMethod_ReturnsValueWithMileagePropertyEqualToSumOfMileagePropertiesOfParameters_IfSumOfChainagePropertiesOfParametersIsLessThan80()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(200);
            double testValue1Param1 = _rnd.NextDouble() * (80 - testValue0Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);
            int expectedResult = testValue0Param0 + testValue1Param0;

            Distance testOutput = Distance.Add(testValue0, testValue1);

            Assert.AreEqual(expectedResult, testOutput.Mileage);
        }

        [TestMethod]
        public void DistanceStruct_AddMethod_ReturnsValueWithChainagePropertyEqualToSumOfChainagePropertiesOfParameters_IfSumOfChainagePropertiesOfParametersIsLessThan80()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(200);
            double testValue1Param1 = _rnd.NextDouble() * (80 - testValue0Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);
            double expectedResult = testValue0Param1 + testValue1Param1;

            Distance testOutput = Distance.Add(testValue0, testValue1);

            Assert.AreEqual(expectedResult, testOutput.Chainage);
        }

        [TestMethod]
        public void DistanceStruct_AddMethod_ReturnsValueWithMileagePropertyEqualToSumOfMileagePropertiesOfParametersPlus1_IfSumOfChainagePropertiesOfParametersIsGreaterThan80()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(200);
            double testValue1Param1 = (80 - testValue0Param1) + _rnd.NextDouble() * testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);
            int expectedResult = testValue0Param0 + testValue1Param0 + 1;

            Distance testOutput = Distance.Add(testValue0, testValue1);

            Assert.AreEqual(expectedResult, testOutput.Mileage);
        }

        [TestMethod]
        public void DistanceStruct_AddMethod_ReturnsValueWithChainagePropertyEqualToSumOfChainagePropertiesOfParametersMinus80_IfSumOfChainagePropertiesOfParametersIsGreaterThan80()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            int testValue1Param0 = _rnd.Next(200);
            double testValue1Param1 = (80 - testValue0Param1) + _rnd.NextDouble() * testValue0Param1;
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);
            double expectedResult = testValue0Param1 + testValue1Param1 - 80;

            Distance testOutput = Distance.Add(testValue0, testValue1);

            Assert.AreEqual(expectedResult, testOutput.Chainage);
        }

        [TestMethod]
        public void DistanceStruct_DifferenceMethod_ReturnsValueWithPropertiesEqualToZero_IfParametersAreEqual()
        {
            int testValue0Param0 = _rnd.Next(200);
            double testValue0Param1 = _rnd.NextDouble() * 80;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            Distance testValue1 = new Distance(testValue0Param0, testValue0Param1);

            Distance testOutput = Distance.Difference(testValue0, testValue1);

            Assert.AreEqual(0, testOutput.Mileage);
            Assert.AreEqual(0d, testOutput.Chainage);
        }

        [TestMethod]
        public void DistanceStruct_DifferenceMethod_ReturnsValueEqualToFirstParameterMinusSecondParameter_IfFirstParameterIsGreaterThanSecondParameter()
        {
            Distance testValue1 = _rnd.NextDistance();
            Distance testValue0 = _rnd.NextDistance(testValue1);

            Distance testOutput = Distance.Difference(testValue0, testValue1);

            Assert.AreEqual(testValue0.AbsoluteDistance - testValue1.AbsoluteDistance, testOutput.AbsoluteDistance, 0.000_000_000_1);
        }

        [TestMethod]
        public void DistanceStruct_DifferenceMethod_ReturnsValueEqualToSecondParameterMinusFirstParameter_IfSecondParameterIsGreaterThanFirstParameter()
        {
            Distance testValue0 = _rnd.NextDistance();
            Distance testValue1 = _rnd.NextDistance(testValue0);

            Distance testOutput = Distance.Difference(testValue0, testValue1);

            Assert.AreEqual(testValue1.AbsoluteDistance - testValue0.AbsoluteDistance, testOutput.AbsoluteDistance, 0.000_000_000_1);
        }

        [TestMethod]
        public void DistanceStruct_DifferenceMethod_ReturnsCorrectValue_IfMileagePropertyOfFirstParameterIsGreaterThanOrEqualToMileagePropertyOfSecondParameterAndChainagePropertyOfFirstParameterIsGreaterThanOrEqualToChainagePropertyOfSecondParameter()
        {
            int testValue1Param0 = _rnd.Next(200);
            int testValue0Param0 = _rnd.Next(testValue1Param0, testValue1Param0 + 200);
            double testValue0Param1;
            do
            {
                testValue0Param1 = _rnd.NextDouble() * 80;
            } while (testValue0Param1 == 0);
            double testValue1Param1 = _rnd.NextDouble() * testValue0Param1;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            Distance testOutput = Distance.Difference(testValue0, testValue1);

            Assert.AreEqual(testValue0.AbsoluteDistance - testValue1.AbsoluteDistance, testOutput.AbsoluteDistance, 0.000_000_000_1);
        }

        [TestMethod]
        public void DistanceStruct_DifferenceMethod_ReturnsCorrectValue_IfMileagePropertyOfFirstParameterIsGreaterThanOrEqualToMileagePropertyOfSecondParameterAndChainagePropertyOfSecondParameterIsGreaterThanOrEqualToChainagePropertyOfFirstParameter()
        {
            int testValue1Param0 = _rnd.Next(200);
            int testValue0Param0 = _rnd.Next(testValue1Param0, testValue1Param0 + 200);
            double testValue1Param1;
            do
            {
                testValue1Param1 = _rnd.NextDouble() * 80;
            } while (testValue1Param1 == 0);
            double testValue0Param1 = _rnd.NextDouble() * testValue1Param1;
            Distance testValue0 = new Distance(testValue0Param0, testValue0Param1);
            Distance testValue1 = new Distance(testValue1Param0, testValue1Param1);

            Distance testOutput = Distance.Difference(testValue0, testValue1);

            Assert.AreEqual(testValue0.AbsoluteDistance - testValue1.AbsoluteDistance, testOutput.AbsoluteDistance, 0.000_000_000_1);
        }

        [TestMethod]
        public void DistanceStruct_CompareToMethodWithDistanceParameter_Returns0_IfParameterIsEqualToValue()
        {
            Distance testObject = _rnd.NextDistance();
            Distance testParam = new Distance(testObject.Mileage, testObject.Chainage);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_CompareToMethodWithDistanceParameter_ReturnsMinus1_IfParameterIsGreaterThanValue()
        {
            Distance testObject = _rnd.NextDistance();
            Distance testParam = _rnd.NextDistance(testObject);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_CompareToMethodWithDistanceParameter_Returns1_IfParameterIsLessThanValue()
        {
            Distance testParam = _rnd.NextDistance();
            Distance testObject = _rnd.NextDistance(testParam);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_CompareToMethodWithObjectParameter_Returns0_IfParameterIsEqualToValue()
        {
            Distance testObject = _rnd.NextDistance();
            object testParam = new Distance(testObject.Mileage, testObject.Chainage);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_CompareToMethodWithObjectParameter_ReturnsMinus1_IfParameterIsGreaterThanValue()
        {
            Distance testObject = _rnd.NextDistance();
            object testParam = _rnd.NextDistance(testObject);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_CompareToMethodWithObjectParameter_Returns1_IfParameterIsLessThanValue()
        {
            Distance testParamValue = _rnd.NextDistance();
            Distance testObject = _rnd.NextDistance(testParamValue);
            object testParam = testParamValue;

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DistanceStruct_CompareToMethodWithObjectParameter_ThrowsArgumentException_IfParameterIsNull()
        {
            Distance testObject = _rnd.NextDistance();
            object testParam = null;

            _ = testObject.CompareTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DistanceStruct_CompareToMethodWithObjectParameter_ThrowsArgumentException_IfParameterIsString()
        {
            Distance testObject = _rnd.NextDistance();
            object testParam = _rnd.NextString(_rnd.Next(10));

            _ = testObject.CompareTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void DistanceStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledWithEqualValue()
        {
            Distance testValue0 = _rnd.NextDistance();
            Distance testValue1 = new Distance(testValue0.Mileage, testValue0.Chainage);

            int testOutput0 = testValue0.GetHashCode();
            int testOutput1 = testValue1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsCorrectOutput_IfFirstParameterIsNull()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = $"{testValue.Mileage}m {(int)testValue.Chainage}ch";
            string testParam0 = null;
            IFormatProvider testParam1 = CultureInfo.InvariantCulture;

            string testOutput = testValue.ToString(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsCorrectOutput_IfFirstParameterIsWhitespace()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = $"{testValue.Mileage}m {(int)testValue.Chainage}ch";
            string testParam0 = _rnd.NextString(" ", _rnd.Next(5));
            IFormatProvider testParam1 = CultureInfo.InvariantCulture;

            string testOutput = testValue.ToString(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsCorrectOutput_IfFirstParameterIsLowercaseG()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = $"{testValue.Mileage}m {(int)testValue.Chainage}ch";
            string testParam0 = "g";
            IFormatProvider testParam1 = CultureInfo.InvariantCulture;

            string testOutput = testValue.ToString(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsCorrectOutput_IfFirstParameterIsUppercaseG()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = $"{testValue.Mileage}m {(int)testValue.Chainage}ch";
            string testParam0 = "G";
            IFormatProvider testParam1 = CultureInfo.InvariantCulture;

            string testOutput = testValue.ToString(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsCorrectOutput_IfFirstParameterIsLowercaseF()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = $"{testValue.Mileage}m {testValue.Chainage}ch";
            string testParam0 = "f";
            IFormatProvider testParam1 = CultureInfo.InvariantCulture;

            string testOutput = testValue.ToString(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsCorrectOutput_IfFirstParameterIsUppercaseF()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = $"{testValue.Mileage}m {testValue.Chainage}ch";
            string testParam0 = "F";
            IFormatProvider testParam1 = CultureInfo.InvariantCulture;

            string testOutput = testValue.ToString(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsCorrectOutput_IfFirstParameterIsLowercaseD()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = $"{testValue.AbsoluteDistance}";
            string testParam0 = "d";
            IFormatProvider testParam1 = CultureInfo.InvariantCulture;

            string testOutput = testValue.ToString(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsCorrectOutput_IfFirstParameterIsUppercaseD()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = $"{testValue.AbsoluteDistance}";
            string testParam0 = "D";
            IFormatProvider testParam1 = CultureInfo.InvariantCulture;

            string testOutput = testValue.ToString(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DistanceStruct_ToStringMethodWithStringAndIFormatProviderParameters_ThrowsFormatException_IfFirstParameterIsNotEmptyAndIsNotGFOrD()
        {
            Distance testValue = _rnd.NextDistance();
            string testParam0;
            string[] validFormats = new[] { "g", "G", "f", "F", "d", "D" };
            do
            {
                testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            } while (validFormats.Any(f => f == testParam0));
            IFormatProvider testParam1 = CultureInfo.InvariantCulture;

            _ = testValue.ToString(testParam0, testParam1);

            Assert.Fail();
        }

#pragma warning disable CA1305 // Specify IFormatProvider

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringParameter_ReturnsCorrectOutput_IfFirstParameterIsNull()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = string.Format(CultureInfo.CurrentCulture, "{0}m {1}ch", testValue.Mileage, (int)testValue.Chainage);
            string testParam0 = null;

            string testOutput = testValue.ToString(testParam0);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringParameter_ReturnsCorrectOutput_IfFirstParameterIsWhitespace()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = string.Format(CultureInfo.CurrentCulture, "{0}m {1}ch", testValue.Mileage, (int)testValue.Chainage);
            string testParam0 = _rnd.NextString(" ", _rnd.Next(5));

            string testOutput = testValue.ToString(testParam0);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringParameter_ReturnsCorrectOutput_IfFirstParameterIsLowercaseG()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = string.Format(CultureInfo.CurrentCulture, "{0}m {1}ch", testValue.Mileage, (int)testValue.Chainage);
            string testParam0 = "g";

            string testOutput = testValue.ToString(testParam0);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringParameter_ReturnsCorrectOutput_IfFirstParameterIsUppercaseG()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = string.Format(CultureInfo.CurrentCulture, "{0}m {1}ch", testValue.Mileage, (int)testValue.Chainage);
            string testParam0 = "G";

            string testOutput = testValue.ToString(testParam0);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringParameter_ReturnsCorrectOutput_IfFirstParameterIsLowercaseF()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = string.Format(CultureInfo.CurrentCulture, "{0}m {1}ch", testValue.Mileage, testValue.Chainage);
            string testParam0 = "f";

            string testOutput = testValue.ToString(testParam0);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringParameter_ReturnsCorrectOutput_IfFirstParameterIsUppercaseF()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = string.Format(CultureInfo.CurrentCulture, "{0}m {1}ch", testValue.Mileage, testValue.Chainage);
            string testParam0 = "F";

            string testOutput = testValue.ToString(testParam0);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringParameter_ReturnsCorrectOutput_IfFirstParameterIsLowercaseD()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = testValue.AbsoluteDistance.ToString(CultureInfo.CurrentCulture);
            string testParam0 = "d";

            string testOutput = testValue.ToString(testParam0);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithStringParameter_ReturnsCorrectOutput_IfFirstParameterIsUppercaseD()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = testValue.AbsoluteDistance.ToString(CultureInfo.CurrentCulture);
            string testParam0 = "D";

            string testOutput = testValue.ToString(testParam0);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void DistanceStruct_ToStringMethodWithStringParameter_ThrowsFormatException_IfFirstParameterIsNotEmptyAndIsNotGFOrD()
        {
            Distance testValue = _rnd.NextDistance();
            string testParam0;
            string[] validFormats = new[] { "g", "G", "f", "F", "d", "D" };
            do
            {
                testParam0 = _rnd.NextString(_rnd.Next(1, 10));
            } while (validFormats.Any(f => f == testParam0));

            _ = testValue.ToString(testParam0);

            Assert.Fail();
        }

#pragma warning restore CA1305 // Specify IFormatProvider

        [TestMethod]
        public void DistanceStruct_ToStringMethodWithNoParameters_ReturnsCorrectOutput_IfFirstParameterIsNull()
        {
            Distance testValue = _rnd.NextDistance();
            string expectedResult = string.Format(CultureInfo.CurrentCulture, "{0}m {1}ch", testValue.Mileage, (int)testValue.Chainage);

            string testOutput = testValue.ToString();

            Assert.AreEqual(expectedResult, testOutput);
        }


#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
