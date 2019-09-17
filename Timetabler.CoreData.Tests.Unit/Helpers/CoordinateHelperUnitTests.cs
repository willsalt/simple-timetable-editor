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

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsZeroIfMinAndMaxAreZero()
        {
            double min = 0d;
            double max = 0d;
            double prop = _rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(0d, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsMinIfMinAndMaxAreSame()
        {
            double min = _rnd.NextDouble() * int.MaxValue;
            double max = min;
            double prop = _rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsMinIfPropIsZero()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double prop = 0d;

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsMaxIfPropIsOne()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double prop = 1d;

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(max, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsAverageOfMinAndMaxIfPropIsOneHalf()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double prop = 0.5d;

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual((min + max) / 2, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsCorrectProportionalValueForAnyReasonableInput()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double prop = _rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.IsTrue(Math.Abs(prop - (result - min) / (max - min)) < 0.0000001d);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsZeroIfMinAndMaxAreZero()
        {
            float min = 0f;
            float max = 0f;
            float prop = (float)_rnd.NextDouble();

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(0f, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsMinIfMinAndMaxAreSame()
        {
            float min = (float)(_rnd.NextDouble() * int.MaxValue);
            float max = min;
            float prop = (float)_rnd.NextDouble();

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsMinIfPropIsZero()
        {
            float min = (float)(_rnd.NextDouble() * int.MaxValue / 2);
            float max = min + (float)(_rnd.NextDouble() * int.MaxValue / 2);
            float prop = 0f;

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsMaxIfPropIsOne()
        {
            float min = (float) (_rnd.NextDouble() * int.MaxValue / 2);
            float max = min + (float)(_rnd.NextDouble() * int.MaxValue / 2);
            float prop = 1f;

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(max, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsAverageOfMinAndMaxIfPropIsOneHalf()
        {
            float min = (float)(_rnd.NextDouble() * int.MaxValue / 2);
            float max = min + (float)(_rnd.NextDouble() * int.MaxValue / 2);
            float prop = 0.5f;

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual((min + max) / 2, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsCorrectProportionalValueForAnyReasonableInput()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double prop = _rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.IsTrue(Math.Abs(prop - (result - min) / (max - min)) < 0.0000001d);
        }

        [TestMethod]
        public void CoordinateHelperClassUnstretchMethodWithDoubleParamtersReturns0IfMinAndMaxAreEqual()
        {
            double minMax = _rnd.NextDouble() * int.MaxValue / 2;
            double amt = _rnd.NextDouble() * int.MaxValue / 2;

            double result = CoordinateHelper.Unstretch(minMax, minMax, amt);

            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CoordinateHelperClassUnstretchMethodWithDoubleParametersReturns0IfAmtParameterEqualsMinParameter()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);

            double result = CoordinateHelper.Unstretch(min, max, min);

            Assert.AreEqual(0.0, result);
        }

        [TestMethod]
        public void CoordinateHelperClassUnstretchMethodWithDoubleParametersReturns1IfAmtParameterEqualsMaxParameter()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);

            double result = CoordinateHelper.Unstretch(min, max, max);

            Assert.AreEqual(1.0, result);
        }

        [TestMethod]
        public void CoordinateHelperClassUnstretchMethodWithDoubleParametersReturnsCorrectResultForReasonableInput()
        {
            double min = _rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (_rnd.NextDouble() * int.MaxValue / 2);
            double testValue = _rnd.NextDouble();
            double amt = (max - min) * testValue + min;

            double result = CoordinateHelper.Unstretch(min, max, amt);

            Assert.IsTrue(Math.Abs(testValue - result) < 0.0000001d);
        }
    }
}
