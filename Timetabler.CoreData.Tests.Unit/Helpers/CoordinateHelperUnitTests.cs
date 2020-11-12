using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Timetabler.CoreData.Helpers;

namespace Timetabler.CoreData.Tests.Unit.Helpers
{
    [TestClass]
    public class CoordinateHelperUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithDoubleParameters_ReturnsZero_IfMinAndMaxAreZero()
        {
            double min = 0d;
            double max = 0d;
            double prop = _rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(0d, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithDoubleParameters_ReturnsMin_IfMinAndMaxAreSame()
        {
            double min = _rnd.NextDouble() * int.MaxValue;
            double max = min;
            double prop = _rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithDoubleParameters_ReturnsMin_IfPropIsZero()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double prop = 0d;

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithDoubleParameters_ReturnsMax_IfPropIsOne()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double prop = 1d;

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(max, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithDoubleParameters_ReturnsAverageOfMinAndMax_IfPropIsOneHalf()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double prop = 0.5d;

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual((min + max) / 2, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithDoubleParameters_ReturnsCorrectProportionalValueForAnyReasonableInput()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double prop = _rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.IsTrue(Math.Abs(prop - (result - min) / (max - min)) < 0.0000001d);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithFloatParameters_ReturnsZero_IfMinAndMaxAreZero()
        {
            float min = 0f;
            float max = 0f;
            float prop = (float)_rnd.NextDouble();

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(0f, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithFloatParameters_ReturnsMin_IfMinAndMaxAreSame()
        {
            float min = (float)(_rnd.NextDouble() * int.MaxValue);
            float max = min;
            float prop = (float)_rnd.NextDouble();

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithFloatParameters_ReturnsMin_IfPropIsZero()
        {
            float min = (float)(_rnd.NextDouble() * int.MaxValue / 2);
            float max = min + (float)(_rnd.NextDouble() * int.MaxValue / 2);
            float prop = 0f;

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithFloatParameters_ReturnsMax_IfPropIsOne()
        {
            float min = (float) (_rnd.NextDouble() * int.MaxValue / 2);
            float max = min + (float)(_rnd.NextDouble() * int.MaxValue / 2);
            float prop = 1f;

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(max, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithFloatParameters_ReturnsAverageOfMinAndMax_IfPropIsOneHalf()
        {
            float min = (float)(_rnd.NextDouble() * int.MaxValue / 2);
            float max = min + (float)(_rnd.NextDouble() * int.MaxValue / 2);
            float prop = 0.5f;

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual((min + max) / 2, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_StretchMethodWithFloatParameters_ReturnsCorrectProportionalValueForAnyReasonableInput()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double prop = _rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.IsTrue(Math.Abs(prop - (result - min) / (max - min)) < 0.0000001d);
        }

        [TestMethod]
        public void CoordinateHelperClass_UnstretchMethodWithDoubleParamters_Returns0_IfMinAndMaxAreEqual()
        {
            double minMax = _rnd.NextDouble() * int.MaxValue / 2;
            double amt = _rnd.NextDouble() * int.MaxValue / 2;

            double result = CoordinateHelper.Unstretch(minMax, minMax, amt);

            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_UnstretchMethodWithDoubleParameters_Returns0_IfAmtParameterEqualsMinParameter()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);

            double result = CoordinateHelper.Unstretch(min, max, min);

            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_UnstretchMethodWithDoubleParameters_Returns1_IfAmtParameterEqualsMaxParameter()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);

            double result = CoordinateHelper.Unstretch(min, max, max);

            Assert.AreEqual(1.0, result);
        }

        [TestMethod]
        public void CoordinateHelperClass_UnstretchMethodWithDoubleParameters_ReturnsCorrectResultForReasonableInput()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double testValue = _rnd.NextDouble();
            double amt = (max - min) * testValue + min;

            double result = CoordinateHelper.Unstretch(min, max, amt);

            Assert.IsTrue(Math.Abs(testValue - result) < 0.0000001d);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
