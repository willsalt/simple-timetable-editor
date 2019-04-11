using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.CoreData.Helpers;

namespace Timetabler.CoreData.Tests.Unit.Helpers
{
    [TestClass]
    public class CoordinateHelperUnitTests
    {
        Random rnd = new Random();

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsZeroIfMinAndMaxAreZero()
        {
            double min = 0d;
            double max = 0d;
            double prop = rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(0d, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsMinIfMinAndMaxAreSame()
        {
            double min = rnd.NextDouble() * int.MaxValue;
            double max = min;
            double prop = rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsMinIfPropIsZero()
        {
            double min = rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (rnd.NextDouble() * int.MaxValue / 2);
            double prop = 0d;

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsMaxIfPropIsOne()
        {
            double min = rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (rnd.NextDouble() * int.MaxValue / 2);
            double prop = 1d;

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(max, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsAverageOfMinAndMaxIfPropIsOneHalf()
        {
            double min = rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (rnd.NextDouble() * int.MaxValue / 2);
            double prop = 0.5d;

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual((min + max) / 2, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithDoubleParametersReturnsCorrectProportionalValueForAnyReasonableInput()
        {
            double min = rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (rnd.NextDouble() * int.MaxValue / 2);
            double prop = rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.IsTrue(Math.Abs(prop - (result - min) / (max - min)) < 0.0000001d);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsZeroIfMinAndMaxAreZero()
        {
            float min = 0f;
            float max = 0f;
            float prop = (float)rnd.NextDouble();

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(0f, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsMinIfMinAndMaxAreSame()
        {
            float min = (float)(rnd.NextDouble() * int.MaxValue);
            float max = min;
            float prop = (float)rnd.NextDouble();

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsMinIfPropIsZero()
        {
            float min = (float)(rnd.NextDouble() * int.MaxValue / 2);
            float max = min + (float)(rnd.NextDouble() * int.MaxValue / 2);
            float prop = 0f;

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(min, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsMaxIfPropIsOne()
        {
            float min = (float) (rnd.NextDouble() * int.MaxValue / 2);
            float max = min + (float)(rnd.NextDouble() * int.MaxValue / 2);
            float prop = 1f;

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual(max, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsAverageOfMinAndMaxIfPropIsOneHalf()
        {
            float min = (float)(rnd.NextDouble() * int.MaxValue / 2);
            float max = min + (float)(rnd.NextDouble() * int.MaxValue / 2);
            float prop = 0.5f;

            float result = CoordinateHelper.Stretch(min, max, prop);

            Assert.AreEqual((min + max) / 2, result);
        }

        [TestMethod]
        public void CoordinateHelperClassStretchMethodWithFloatParametersReturnsCorrectProportionalValueForAnyReasonableInput()
        {
            double min = rnd.NextDouble() * int.MaxValue / 2;
            double max = min + (rnd.NextDouble() * int.MaxValue / 2);
            double prop = rnd.NextDouble();

            double result = CoordinateHelper.Stretch(min, max, prop);

            Assert.IsTrue(Math.Abs(prop - (result - min) / (max - min)) < 0.0000001d);
        }
    }
}
