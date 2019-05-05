using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class TimeOfDayUnitTests
    {
        private static Random _rnd = new Random();

        [TestMethod]
        public void TimeOfDayClassConstructorWithDoubleParameterReturnsTimeOfDayWithCorrectValue()
        {
            int testValue = _rnd.Next();
            double testParam = testValue + _rnd.NextDouble() - 0.5;

            TimeOfDay testOutput = new TimeOfDay(testParam);

            Assert.AreEqual(testValue, testOutput.AbsoluteSeconds);
        }
    }
}
