using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Unicorn.Interfaces.Tests.Unit
{
    [TestClass]
    public class UniRangeUnitTests
    {
        private static Random _rnd = new Random();

        [TestMethod]
        public void UniRangeIsPublic()
        {
            Assert.IsTrue(typeof(UniRange).IsPublic);
        }

        [TestMethod]
        public void UniRangeConstructorWithDoubleAndDoubleParametersIsPublic()
        {
            ConstructorInfo cInfo = typeof(UniRange).GetConstructor(new[] { typeof(double), typeof(double) });
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void UniRangeConstructorSetsStartPropertyToValueOfFirstParameter()
        {
            double testValue = _rnd.NextDouble();
            UniRange testObject = new UniRange(testValue, _rnd.NextDouble());

            Assert.AreEqual(testValue, testObject.Start);
        }

        [TestMethod]
        public void UniRangeConstructorSetsEndPropertyToValueOfSecondParameter()
        {
            double testValue = _rnd.NextDouble();
            UniRange testObject = new UniRange(_rnd.NextDouble(), testValue);

            Assert.AreEqual(testValue, testObject.End);
        }

        [TestMethod]
        public void UniRangeSizePropertyReturnsCorrectValue()
        {
            double testValue = _rnd.NextDouble();
            double startValue = _rnd.NextDouble();
            UniRange testObject = new UniRange(startValue, startValue + testValue);

            double testOutput = testObject.Size;

            Assert.IsTrue(Math.Abs(testValue - testOutput) < 0.00000001);
        }
    }
}
