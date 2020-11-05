using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class DistanceUnitTests
    {
        private readonly static Random _rnd = RandomProvider.Default;

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
        public void DistanceStruct_ConstructorWithIntAndDoubleParameters_SetsMileagePropertyToFirstParameter_WhenParametersAreNotNormalised()
        {
            int testParam0 = _rnd.Next(200);
            double testParam1 = 80 + _rnd.NextDouble() * 8000;
            int expectedResult = testParam0 + (int)(testParam1 / 80);

            Distance testOutput = new Distance(testParam0, testParam1);

            Assert.AreEqual(expectedResult, testOutput.Mileage);
        }

        [TestMethod]
        public void DistanceStruct_ConstructorWithIntAndDoubleParameters_SetsChainagePropertyToFirstParameter_WhenParametersAreNotNormalised()
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

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
