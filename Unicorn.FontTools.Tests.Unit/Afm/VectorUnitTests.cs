using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.Afm;

namespace Unicorn.FontTools.Tests.Unit.Afm
{
    [TestClass]
    public class VectorUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void VectorStruct_ParameterlessConstructor_SetsXPropertyToZero()
        {
            Vector testOutput = new Vector();

            Assert.AreEqual(0m, testOutput.X);
        }

        [TestMethod]
        public void VectorStruct_ParameterlessConstructor_SetsYPropertyToZero()
        {
            Vector testOutput = new Vector();

            Assert.AreEqual(0m, testOutput.Y);
        }

        [TestMethod]
        public void VectorStruct_ConstructorWithTwoDecimalParameters_SetsXPropertyToValueOfFirstParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();

            Vector testOutput = new Vector(testParam0, testParam1);

            Assert.AreEqual(testParam0, testOutput.X);
        }

        [TestMethod]
        public void VectorStruct_ConstructorWithTwoDecimalParameters_SetsYPropertyToValueOfSecondParameter()
        {
            decimal testParam0 = _rnd.NextDecimal();
            decimal testParam1 = _rnd.NextDecimal();

            Vector testOutput = new Vector(testParam0, testParam1);

            Assert.AreEqual(testParam1, testOutput.Y);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithVectorParameter_ReturnsTrue_IfParameterIsThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);

            bool testOutput = testObject.Equals(testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithVectorParameter_ReturnsTrue_IfParameterWasConstructedFromSameData()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            Vector testParam0 = new Vector(testObject.X, testObject.Y);

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithVectorParameter_ReturnsFalse_IfParameterHasXPropertyThatDiffersFromThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject.X);
            Vector testParam0 = new Vector(constrParam2, testObject.Y);

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithVectorParameter_ReturnsFalse_IfParameterHasYPropertyThatDiffersFromThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject.Y);
            Vector testParam0 = new Vector(testObject.X, constrParam2);

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);

            bool testOutput = testObject.Equals((object)testObject);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterWasConstructedFromSameData()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            Vector testParam0 = new Vector(testObject.X, testObject.Y);

            bool testOutput = testObject.Equals((object)testParam0);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasXPropertyThatDiffersFromThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject.X);
            Vector testParam0 = new Vector(constrParam2, testObject.Y);

            bool testOutput = testObject.Equals((object)testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterHasYPropertyThatDiffersFromThis()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject.Y);
            Vector testParam0 = new Vector(testObject.X, constrParam2);

            bool testOutput = testObject.Equals((object)testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);
            string testParam0 = _rnd.NextString(_rnd.Next(0, 20));

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_GetHashCodeMethod_ReturnsSameValue_IfCalledTwiceWithSameValue()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            Vector testObject1 = new Vector(testObject0.X, testObject0.Y);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void VectorStruct_EqualityOperator_ReturnsTrue_IfBothOperandsAreSameValue()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject == testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualityOperator_ReturnsTrue_IfOperandsHaveSameProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            Vector testObject1 = new Vector(testObject0.X, testObject0.Y);

            bool testOutput = testObject0 == testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentXProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject0.X);
            Vector testObject1 = new Vector(constrParam2, testObject0.Y);

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_EqualityOperator_ReturnsFalse_IfOperandsHaveDifferentYProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject0.Y);
            Vector testObject1 = new Vector(testObject0.X, constrParam2);

            bool testOutput = testObject0 == testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_InequalityOperator_ReturnsFalse_IfBothOperandsAreSameValue()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject = new Vector(constrParam0, constrParam1);

#pragma warning disable CS1718 // Comparison made to same variable
            bool testOutput = testObject != testObject;
#pragma warning restore CS1718 // Comparison made to same variable

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_InequalityOperator_ReturnsFalse_IfOperandsHaveSameProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            Vector testObject1 = new Vector(testObject0.X, testObject0.Y);

            bool testOutput = testObject0 != testObject1;

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void VectorStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentXProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject0.X);
            Vector testObject1 = new Vector(constrParam2, testObject0.Y);

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void VectorStruct_InequalityOperator_ReturnsTrue_IfOperandsHaveDifferentYProperties()
        {
            decimal constrParam0 = _rnd.NextDecimal();
            decimal constrParam1 = _rnd.NextDecimal();
            Vector testObject0 = new Vector(constrParam0, constrParam1);
            decimal constrParam2;
            do
            {
                constrParam2 = _rnd.NextDecimal();
            } while (constrParam2 == testObject0.Y);
            Vector testObject1 = new Vector(testObject0.X, constrParam2);

            bool testOutput = testObject0 != testObject1;

            Assert.IsTrue(testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
