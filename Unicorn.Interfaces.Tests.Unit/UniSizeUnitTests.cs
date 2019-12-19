using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Unicorn.Interfaces.Tests.Unit
{
    [TestClass]
    public class UniSizeUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private UniSize GetUniSize(double? width = null, double? height = null)
        {
            return new UniSize(width ?? _rnd.NextDouble() * 1000, height ?? _rnd.NextDouble() * 1000);
        }

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
        public void UniSizeClass_EqualsMethodWithUniSizeParameter_ReturnsFalse_IfParameterIsNull()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam = null;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithUniSizeParameter_ReturnsFalse_IfParameterHasDifferentWidthAndHeightPropertiesToObject()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam;
            do
            {
                testParam = GetUniSize();
            } while (testParam.Width == testObject.Width || testParam.Height == testObject.Height);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithUniSizeParameter_ReturnsFalse_IfParameterHasSameWidthAndDifferentHeightPropertiesToObject()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam;
            do
            {
                testParam = GetUniSize(testObject.Width);
            } while (testParam.Height == testObject.Height);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithUniSizeParameter_ReturnsFalse_IfParameterHasDifferentWidthAndSameHeightPropertiesToObject()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam;
            do
            {
                testParam = GetUniSize(null, testObject.Height);
            } while (testParam.Width == testObject.Width);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithUniSizeParameter_ReturnsTrue_IfParameterIsSameObject()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam = testObject;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithUniSizeParameter_ReturnsTrue_IfParameterIsDifferentObjectWithSameWidthAndSameHeightProperties()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam = GetUniSize(testObject.Width, testObject.Height);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNull()
        {
            UniSize testObject = GetUniSize();
            object testParam = null;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsUniSizeObjectWithDifferentWidthAndHeightPropertiesToObject()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam;
            do
            {
                testParam = GetUniSize();
            } while (testParam.Width == testObject.Width || testParam.Height == testObject.Height);
            object testParam0 = testParam;

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsUniSizeObjectWithSameWidthAndDifferentHeightPropertiesToObject()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam;
            do
            {
                testParam = GetUniSize(testObject.Width);
            } while (testParam.Height == testObject.Height);
            object testParam0 = testParam;

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsUniSizeObjectWithDifferentWidthAndSameHeightPropertiesToObject()
        {
            UniSize testObject = GetUniSize();
            UniSize testParam;
            do
            {
                testParam = GetUniSize(null, testObject.Height);
            } while (testParam.Width == testObject.Width);
            object testParam0 = testParam;

            bool testOutput = testObject.Equals(testParam0);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsSameObject()
        {
            UniSize testObject = GetUniSize();
            object testParam = testObject;

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsDifferentUniSizeObjectWithSameWidthAndSameHeightProperties()
        {
            UniSize testObject = GetUniSize();
            object testParam = GetUniSize(testObject.Width, testObject.Height);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNotAUniSizeObject()
        {
            UniSize testObject = GetUniSize();
            object testParam = _rnd.NextString(_rnd.Next(50));

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void UniSizeClass_GetHashCodeMethod_ReturnsSameValueWhenCalledTwice()
        {
            UniSize testObject = GetUniSize();

            int testOutput0 = testObject.GetHashCode();
            int testOutput1 = testObject.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniSizeClass_GetHashCodeMethod_ReturnsSameValueWhenCalledOnTwoObjectsWithSameWidthAndHeightProperties()
        {
            UniSize testObject0 = GetUniSize();
            UniSize testObject1 = GetUniSize(testObject0.Width, testObject0.Height);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniSizeClass_GetHashCodeMethod_ReturnsDifferentValueWhenCalledOnTwoObjectsWithDifferentWidthAndHeightProperties()
        {
            UniSize testObject0 = GetUniSize();
            UniSize testObject1 = GetUniSize(testObject0.Width + 100, testObject0.Height + 100);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniSizeClass_GetHashCodeMethod_ReturnsDifferentValueWhenCalledOnTwoObjectsWithDifferentWidthAndSameHeightProperties()
        {
            UniSize testObject0 = GetUniSize();
            UniSize testObject1 = GetUniSize(testObject0.Width + 100, testObject0.Height);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void UniSizeClass_GetHashCodeMethod_ReturnsDifferentValueWhenCalledOnTwoObjectsWithSameWidthAndDifferentHeightProperties()
        {
            UniSize testObject0 = GetUniSize();
            UniSize testObject1 = GetUniSize(testObject0.Width, testObject0.Height + 100);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }
    }
}
