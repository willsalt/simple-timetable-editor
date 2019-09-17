using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Timetabler.CoreData;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class TimeOfDayUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void TimeOfDayClassConstructorWithDoubleParameterReturnsTimeOfDayWithCorrectValue()
        {
            int testValue = _rnd.Next();
            double testParam = testValue + _rnd.NextDouble() - 0.5;

            TimeOfDay testOutput = new TimeOfDay(testParam);

            Assert.AreEqual(testValue, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassSubtractOperatorWithTimeOfDayAndTimeOfDayParameterReturnsTimeSpanWithCorrectValueIfFirstParameterIsBeforeSecondParameter()
        {
            int testSeconds0 = _rnd.Next(86399);
            int testSeconds1 = _rnd.Next(86400 - testSeconds0) + testSeconds0 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassSubtractOperatorWithTimeOfDayAndTimeOfDayParameterReturnsTimeSpanWithCorrectValueIfFirstParameterIsAfterSecondParameter()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassSubtractOperatorWithTimeOfDayAndTimeSpanParameterReturnsTimeSpanWithCorrectValueIfFirstParameterIsBeforeSecondParameter()
        {
            int testSeconds0 = _rnd.Next(86399);
            int testSeconds1 = _rnd.Next(86400 - testSeconds0) + testSeconds0 + 1;
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassSubtractOperatorWithTimeOfDayAndTimeSpanParameterReturnsTimeSpanWithCorrectValueIfFirstParameterIsAfterSecondParameter()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassSubtractOperatorWithTimeSpanAndTimeOfDayParameterReturnsTimeSpanWithCorrectValueIfFirstParameterIsBeforeSecondParameter()
        {
            int testSeconds0 = _rnd.Next(86399);
            int testSeconds1 = _rnd.Next(86400 - testSeconds0) + testSeconds0 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassSubtractOperatorWithTimeSpanAndTimeOfDayParameterReturnsTimeSpanWithCorrectValueIfFirstParameterIsAfterSecondParameter()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassAddOperatorWithTimeOfDayAndTimeSpanParametersReturnsTimeOfDayWithCorrectValueIfResultDoesNotCrossMidnight()
        {
            int testSeconds0 = _rnd.Next(86398);
            int testSeconds1 = _rnd.Next(86399 - testSeconds0) + testSeconds0;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            TimeOfDay testOutput = testValue0 + testValue1;

            Assert.AreEqual(testSeconds0 + testSeconds1, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassAddOperatorWithTimeSpanAndTimeOfDayParametersReturnsTimeOfDayWithCorrectValueIfResultDoesNotCrossMidnight()
        {
            int testSeconds0 = _rnd.Next(86398);
            int testSeconds1 = _rnd.Next(86399 - testSeconds0) + testSeconds0;
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeOfDay testOutput = testValue0 + testValue1;

            Assert.AreEqual(testSeconds0 + testSeconds1, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassFromTimeSpanMethodReturnsObjectWithCorrectAbsoluteSecondsProperty()
        {
            int testPeriod = _rnd.Next(86400);
            TimeSpan span = new TimeSpan(0, 0, testPeriod);

            TimeOfDay testOutput = TimeOfDay.FromTimeSpan(span);

            Assert.AreEqual(testPeriod, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassCopyAndReflectMethodReturnsDifferentObject()
        {
            int origTime = _rnd.Next(86380) + 10;
            TimeOfDay testObject = new TimeOfDay(origTime);
            int reflectAroundSecs = _rnd.Next((86400 - origTime) / 2 + origTime / 2) + (origTime / 2);
            TimeOfDay testParam = new TimeOfDay(reflectAroundSecs);

            TimeOfDay testOutput = testObject.CopyAndReflect(testParam);

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClassCopyAndReflectMethodDoesNotChangeOriginalObject()
        {
            int origTime = _rnd.Next(86380) + 10;
            TimeOfDay testObject = new TimeOfDay(origTime);
            int reflectAroundSecs = _rnd.Next((86400 - origTime) / 2 + origTime / 2) + (origTime / 2);
            TimeOfDay testParam = new TimeOfDay(reflectAroundSecs);

            _ = testObject.CopyAndReflect(testParam);

            Assert.AreEqual(origTime, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassCopyAndReflectMethodReturnsObjectWithCorrectTimeIfReflectedInFutureObject()
        {
            int origTime = _rnd.Next(86380);
            TimeOfDay testObject = new TimeOfDay(origTime);
            int reflectAroundSecs = _rnd.Next((86400 - origTime) / 2) + origTime;
            TimeOfDay testParam = new TimeOfDay(reflectAroundSecs);

            TimeOfDay testOutput = testObject.CopyAndReflect(testParam);

            Assert.AreEqual(reflectAroundSecs * 2 - origTime, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClassCopyAndReflectMethodReturnsObjectWithCorrectTimeIfReflectedInPriorObject()
        {
            int origTime = _rnd.Next(86380);
            TimeOfDay testObject = new TimeOfDay(origTime);
            int reflectAroundSecs = _rnd.Next(origTime / 2) + origTime / 2;
            TimeOfDay testParam = new TimeOfDay(reflectAroundSecs);

            TimeOfDay testOutput = testObject.CopyAndReflect(testParam);

            Assert.AreEqual(reflectAroundSecs * 2 - origTime, testOutput.AbsoluteSeconds);
        }
    }
}
