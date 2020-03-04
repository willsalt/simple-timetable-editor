using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;

namespace Unicorn.Interfaces.Tests.Unit
{
    [TestClass]
    public class UniSizeUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static UniSize GetUniSize()
        {
            return new UniSize(_rnd.NextDouble() * 1000, _rnd.NextDouble() * 1000);
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void UniSizeClass_Constructor_SetsWidthPropertyToEqualFirstParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;

            UniSize testOutput = new UniSize(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.Width);
        }

        [TestMethod]
        public void UniSizeClass_Constructor_SetsHeightPropertyToEqualSecondParameter()
        {
            double testParam0 = _rnd.NextDouble() * 1000;
            double testParam1 = _rnd.NextDouble() * 1000;

            UniSize testOutput = new UniSize(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Height);
        }

        [TestMethod]
        public void UniSizeClass_AdditionOperator_ReturnsObjectEqualToSecondOperand_IfFirstOperandIsNull()
        {
            UniSize testOp0 = null;
            UniSize testOp1 = GetUniSize();

            UniSize testOutput = testOp0 + testOp1;

            Assert.AreEqual(testOp1.Width, testOutput.Width);
            Assert.AreEqual(testOp1.Height, testOutput.Height);
        }

        [TestMethod]
        public void UniSizeClass_AdditionOperator_ReturnsObjectEqualToFirstOperand_IfSecondOperandIsNull()
        {
            UniSize testOp0 = GetUniSize();
            UniSize testOp1 = null;

            UniSize testOutput = testOp0 + testOp1;

            Assert.AreEqual(testOp0.Width, testOutput.Width);
            Assert.AreEqual(testOp0.Height, testOutput.Height);
        }

        [TestMethod]
        public void UniSizeClass_AdditionOperator_ReturnsNull_IfBothOperandsAreNull()
        {
            UniSize testOp0 = null;
            UniSize testOp1 = null;

            UniSize testOutput = testOp0 + testOp1;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_AdditionOperator_ReturnsObjectWithWidthPropertyEqualToSumOfWidthPropertiesOfOperands_IfNeitherOperandIsNull()
        {
            UniSize testOp0 = GetUniSize();
            UniSize testOp1 = GetUniSize();

            UniSize testOutput = testOp0 + testOp1;

            Assert.AreEqual(testOp0.Width + testOp1.Width, testOutput.Width);
        }

        [TestMethod]
        public void UniSizeClass_AdditionOperator_ReturnsObjectWithHeightPropertyEqualToSumOfHeightPropertiesOfOperands_IfNeitherOperandIsNull()
        {
            UniSize testOp0 = GetUniSize();
            UniSize testOp1 = GetUniSize();

            UniSize testOutput = testOp0 + testOp1;

            Assert.AreEqual(testOp0.Height + testOp1.Height, testOutput.Height);
        }

        [TestMethod]
        public void UniSizeClass_AddMethod_ReturnsObjectEqualToSecondOperand_IfFirstOperandIsNull()
        {
            UniSize testParam0 = null;
            UniSize testParam1 = GetUniSize();

            UniSize testOutput = UniSize.Add(testParam0, testParam1);

            Assert.AreEqual(testParam1.Width, testOutput.Width);
            Assert.AreEqual(testParam1.Height, testOutput.Height);
        }

        [TestMethod]
        public void UniSizeClass_AddMethod_ReturnsObjectEqualToFirstOperand_IfSecondOperandIsNull()
        {
            UniSize testParam0 = GetUniSize();
            UniSize testParam1 = null;

            UniSize testOutput = UniSize.Add(testParam0, testParam1);

            Assert.AreEqual(testParam0.Width, testOutput.Width);
            Assert.AreEqual(testParam0.Height, testOutput.Height);
        }

        [TestMethod]
        public void UniSizeClass_AddMethod_ReturnsNull_IfBothOperandsAreNull()
        {
            UniSize testParam0 = null;
            UniSize testParam1 = null;

            UniSize testOutput = UniSize.Add(testParam0, testParam1);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_AddMethod_ReturnsObjectWithWidthPropertyEqualToSumOfWidthPropertiesOfOperands_IfNeitherOperandIsNull()
        {
            UniSize testParam0 = GetUniSize();
            UniSize testParam1 = GetUniSize();

            UniSize testOutput = UniSize.Add(testParam0, testParam1);

            Assert.AreEqual(testParam0.Width + testParam1.Width, testOutput.Width);
        }

        [TestMethod]
        public void UniSizeClass_AddMethod_ReturnsObjectWithHeightPropertyEqualToSumOfHeightPropertiesOfOperands_IfNeitherOperandIsNull()
        {
            UniSize testParam0 = GetUniSize();
            UniSize testParam1 = GetUniSize();

            UniSize testOutput = UniSize.Add(testParam0, testParam1);

            Assert.AreEqual(testParam0.Height + testParam1.Height, testOutput.Height);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
