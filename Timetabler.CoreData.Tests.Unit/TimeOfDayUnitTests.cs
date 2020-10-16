using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.CoreData.Tests.Unit
{
    [TestClass]
    public class TimeOfDayUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TimeOfDayClass_ParameterlessConstructor_ReturnsTimeOfDayEqualToMidnight()
        {
            TimeOfDay testOutput = new TimeOfDay();

            Assert.AreEqual(0, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithDoubleParameter_ReturnsTimeOfDayWithCorrectValue()
        {
            int testValue = _rnd.Next();
            double testParam = testValue + _rnd.NextDouble() - 0.5;

            TimeOfDay testOutput = new TimeOfDay(testParam);

            Assert.AreEqual(testValue, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithThreeIntParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersAreNormalisedWithinRanges()
        {
            int testParam0 = _rnd.Next(24);
            int testParam1 = _rnd.Next(60);
            int testParam2 = _rnd.Next(60);

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam2 + testParam1 * 60 + testParam0 * 3600, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithThreeIntParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersAreNotNormalised()
        {
            int testParam0 = _rnd.Next(int.MaxValue / 16384);
            int testParam1 = _rnd.Next(int.MaxValue / 16384);
            int testParam2 = _rnd.Next(int.MaxValue / 16384);

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2);

            Assert.AreEqual((testParam2 + testParam1 * 60 + testParam0 * 3600) % 86400, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithTwoIntParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersAreNormalisedWithinRanges()
        {
            int testParam0 = _rnd.Next(24);
            int testParam1 = _rnd.Next(60);

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1);

            Assert.AreEqual(testParam1 * 60 + testParam0 * 3600, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithTwoIntParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersAreNotNormalised()
        {
            int testParam0 = _rnd.Next(int.MaxValue / 16384);
            int testParam1 = _rnd.Next(int.MaxValue / 16384);

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1);

            Assert.AreEqual((testParam1 * 60 + testParam0 * 3600) % 86400, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithThreeIntAndOneHalfOfDayParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersAreNormalisedAndFourthParameterIsAm()
        {
            int testParam0 = _rnd.Next(12);
            int testParam1 = _rnd.Next(60);
            int testParam2 = _rnd.Next(60);
            HalfOfDay testParam3 = HalfOfDay.AM;

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2 + testParam1 * 60 + testParam0 * 3600, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithThreeIntAndOneHalfOfDayParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersAreNormalisedAndFourthParameterIsPm()
        {
            int testParam0 = _rnd.Next(12);
            int testParam1 = _rnd.Next(60);
            int testParam2 = _rnd.Next(60);
            HalfOfDay testParam3 = HalfOfDay.PM;

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2 + testParam1 * 60 + testParam0 * 3600 + 43200, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithThreeIntAndOneHalfOfDayParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersRepresentMidnightExpressedAs12Am()
        {
            int testParam0 = 12;
            int testParam1 = _rnd.Next(60);
            int testParam2 = _rnd.Next(60);
            HalfOfDay testParam3 = HalfOfDay.AM;

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2 + testParam1 * 60, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithThreeIntAndOneHalfOfDayParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersRepresentNoonExpressedAs12Pm()
        {
            int testParam0 = 12;
            int testParam1 = _rnd.Next(60);
            int testParam2 = _rnd.Next(60);
            HalfOfDay testParam3 = HalfOfDay.PM;

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2 + testParam1 * 60 + 43200, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithThreeIntAndOneHalfOfDayParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersRepresentNoonExpressedAs12Noon()
        {
            int testParam0 = 12;
            int testParam1 = 0;
            int testParam2 = 0;
            HalfOfDay testParam3 = HalfOfDay.Noon;

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(43200, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithTwoIntAndOneHalfOfDayParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersAreNormalisedAndThirdParameterIsAm()
        {
            int testParam0 = _rnd.Next(12);
            int testParam1 = _rnd.Next(60);
            HalfOfDay testParam2 = HalfOfDay.AM;

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1 * 60 + testParam0 * 3600, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithTwoIntAndOneHalfOfDayParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersAreNormalisedAndThirdParameterIsPm()
        {
            int testParam0 = _rnd.Next(12);
            int testParam1 = _rnd.Next(60);
            HalfOfDay testParam2 = HalfOfDay.PM;

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1 * 60 + testParam0 * 3600 + 43200, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithTwoIntAndOneHalfOfDayParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersRepresentMidnightExpressedAs12Am()
        {
            int testParam0 = 12;
            int testParam1 = _rnd.Next(60);
            HalfOfDay testParam2 = HalfOfDay.AM;

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1 * 60, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithTwoIntAndOneHalfOfDayParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersRepresentNoonExpressedAs12Pm()
        {
            int testParam0 = 12;
            int testParam1 = _rnd.Next(60);
            HalfOfDay testParam2 = HalfOfDay.PM;

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2);

            Assert.AreEqual(testParam1 * 60 + 43200, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_ConstructorWithTwoIntAndOneHalfOfDayParameters_ReturnsTimeOfDayWithCorrectValue_IfParametersRepresentNoonExpressedAs12Noon()
        {
            int testParam0 = 12;
            int testParam1 = 0;
            HalfOfDay testParam2 = HalfOfDay.Noon;

            TimeOfDay testOutput = new TimeOfDay(testParam0, testParam1, testParam2);

            Assert.AreEqual(43200, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_Hours24Property_GetMethod_ReturnsCorrectValue()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            int testOutput = testObject.Hours24;

            Assert.AreEqual(constrParam0, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_Hours24Property_SetMethod_SetsCorrectValue_IfObjectValueEqualsMidnight()
        {
            TimeOfDay testObject = new TimeOfDay();
            int testParam0 = _rnd.Next(24);

            testObject.Hours24 = testParam0;

            Assert.AreEqual(testParam0 * 3600, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_Hours24Property_SetMethod_SetsCorrectValue_IfObjectValueDoesNotEqualMidnight()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);
            int testParam0 = _rnd.Next(24);

            testObject.Hours24 = testParam0;

            Assert.AreEqual(constrParam2 + constrParam1 * 60 + testParam0 * 3600, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_Hours12Property_GetMethod_ReturnsCorrectValueIfTimeIsBetweenMidnightAnd1Am()
        {
            int constrParam0 = _rnd.Next(3600);
            TimeOfDay testObject = new TimeOfDay(constrParam0);
            int expectedResult = 12;

            int testOutput = testObject.Hours12;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_Hours12Property_GetMethod_ReturnsCorrectValue_IfTimeIsBetween1AmAndNoon()
        {
            int constrParam0 = _rnd.Next(3600, 43200);
            TimeOfDay testObject = new TimeOfDay(constrParam0);
            int expectedResult = constrParam0 / 3600;

            int testOutput = testObject.Hours12;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_Hours12Property_GetMethod_ReturnsCorrectValueIfTimeIsBetweenNoonAnd1Pm()
        {
            int constrParam0 = _rnd.Next(43200, 46800);
            TimeOfDay testObject = new TimeOfDay(constrParam0);
            int expectedResult = 12;

            int testOutput = testObject.Hours12;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_Hours12Property_GetMethod_ReturnsCorrectValue_IfTimeIsBetween1PmAndMidnight()
        {
            int constrParam0 = _rnd.Next(46800, 86400);
            TimeOfDay testObject = new TimeOfDay(constrParam0);
            int expectedResult = constrParam0 / 3600 - 12;

            int testOutput = testObject.Hours12;

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_Hours12Property_SetMethod_SetsCorrectValue_IfPreviousTimeIsBeforeNoonAndNewHours12PropertyValueIs12()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            HalfOfDay constrParam3 = HalfOfDay.AM;
            int testParam0 = 12;
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2, constrParam3);

            testObject.Hours12 = testParam0;

            Assert.AreEqual(constrParam2 + constrParam1 * 60, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_Hours12Property_SetMethod_SetsCorrectValue_IfPreviousTimeIsBeforeNoonAndNewHours12PropertyValueIsNot12()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            HalfOfDay constrParam3 = HalfOfDay.AM;
            int testParam0 = _rnd.Next(1, 12);
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2, constrParam3);

            testObject.Hours12 = testParam0;

            Assert.AreEqual(constrParam2 + constrParam1 * 60 + testParam0 * 3600, testObject.AbsoluteSeconds);
        }
        [TestMethod]
        public void TimeOfDayClass_Hours12Property_SetMethod_SetsCorrectValue_IfPreviousTimeIsAfterNoonAndNewHours12PropertyValueIs12()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            HalfOfDay constrParam3 = HalfOfDay.PM;
            int testParam0 = 12;
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2, constrParam3);

            testObject.Hours12 = testParam0;

            Assert.AreEqual(constrParam2 + constrParam1 * 60 + 43200, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_Hours12Property_SetMethod_SetsCorrectValue_IfPreviousTimeIsAfterNoonAndNewHours12PropertyValueIsNot12()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            HalfOfDay constrParam3 = HalfOfDay.PM;
            int testParam0 = _rnd.Next(1, 12);
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2, constrParam3);

            testObject.Hours12 = testParam0;

            Assert.AreEqual(constrParam2 + constrParam1 * 60 + testParam0 * 3600 + 43200, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_MinutesProperty_ReturnsCorrectValue()
        {
            int constrParam0 = _rnd.Next(23);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            int testOutput = testObject.Minutes;

            Assert.AreEqual(constrParam1, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_MinutesProperty_SetsCorrectValue()
        {
            int constrParam0 = _rnd.Next(23);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);
            int testParam0 = _rnd.Next(60);

            testObject.Minutes = testParam0;

            Assert.AreEqual(constrParam2 + testParam0 * 60 + constrParam0 * 3600, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_SecondsProperty_ReturnsCorrectValue()
        {
            int constrParam0 = _rnd.Next(23);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            int testOutput = testObject.Seconds;

            Assert.AreEqual(constrParam2, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_SecondsProperty_SetsCorrectValue()
        {
            int constrParam0 = _rnd.Next(23);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);
            int testParam0 = _rnd.Next(60);

            testObject.Seconds = testParam0;

            Assert.AreEqual(testParam0 + constrParam1 * 60 + constrParam0 * 3600, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_HalfOfDayProperty_ReturnsNoon_IfTimeIsMidday()
        {
            TimeOfDay testObject = new TimeOfDay(43200);

            HalfOfDay testOutput = testObject.HalfOfDay;

            Assert.AreEqual(HalfOfDay.Noon, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_HalfOfDayProperty_ReturnsAm_IfTimeIsBeforeMidday()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(43200));

            HalfOfDay testOutput = testObject.HalfOfDay;

            Assert.AreEqual(HalfOfDay.AM, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_HalfOfDayProperty_ReturnsPm_IfTimeIsMidday()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(43201, 86400));

            HalfOfDay testOutput = testObject.HalfOfDay;

            Assert.AreEqual(HalfOfDay.PM, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_HalfOfDayProperty_SetsTimeToMidday_IfSetToNoon()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86400));
            HalfOfDay testParam0 = HalfOfDay.Noon;

            testObject.HalfOfDay = testParam0;

            Assert.AreEqual(43200, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_HalfOfDayProperty_DoesNotChangeTime_IfTimeIsInMorningAndPropertyIsSetToAm()
        {
            int originalSeconds = _rnd.Next(43200);
            TimeOfDay testObject = new TimeOfDay(originalSeconds);
            HalfOfDay testParam0 = HalfOfDay.AM;

            testObject.HalfOfDay = testParam0;

            Assert.AreEqual(originalSeconds, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_HalfOfDayProperty_ChangesTimeCorrectly_IfTimeIsInMorningAndPropertyIsSetToPm()
        {
            int originalSeconds = _rnd.Next(43200);
            TimeOfDay testObject = new TimeOfDay(originalSeconds);
            HalfOfDay testParam0 = HalfOfDay.PM;

            testObject.HalfOfDay = testParam0;

            Assert.AreEqual(originalSeconds + 43200, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_HalfOfDayProperty_DoesNotChangeTime_IfTimeIsAfterMiddayAndPropertyIsSetToPm()
        {
            int originalSeconds = _rnd.Next(43200, 86400);
            TimeOfDay testObject = new TimeOfDay(originalSeconds);
            HalfOfDay testParam0 = HalfOfDay.PM;

            testObject.HalfOfDay = testParam0;

            Assert.AreEqual(originalSeconds, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_HalfOfDayProperty_ChangesTimeCorrectly_IfTimeIsAfterMiddayAndPropertyIsSetToPm()
        {
            int originalSeconds = _rnd.Next(43200, 86400);
            TimeOfDay testObject = new TimeOfDay(originalSeconds);
            HalfOfDay testParam0 = HalfOfDay.AM;

            testObject.HalfOfDay = testParam0;

            Assert.AreEqual(originalSeconds - 43200, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_EqualsMethodWithTimeOfDayParameter_ReturnsTrue_IfParameterIsEqualToThis()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86400));
            TimeOfDay testParam = new TimeOfDay(testObject.AbsoluteSeconds);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_EqualsMethodWithTimeOfDayParameter_ReturnsFalse_IfParameterIsNotEqualToThis()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86400));
            int paramSeconds;
            do
            {
                paramSeconds = _rnd.Next(86400);
            } while (paramSeconds == testObject.AbsoluteSeconds);
            TimeOfDay testParam = new TimeOfDay(paramSeconds);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_EqualsMethodWithObjectParameter_ReturnsTrue_IfParameterIsEqualToThis()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86400));
            object testParam = new TimeOfDay(testObject.AbsoluteSeconds);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsTrue(testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsNotEqualToThis()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86400));
            int paramSeconds;
            do
            {
                paramSeconds = _rnd.Next(86400);
            } while (paramSeconds == testObject.AbsoluteSeconds);
            object testParam = new TimeOfDay(paramSeconds);

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_EqualsMethodWithObjectParameter_ReturnsFalse_IfParameterIsString()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86400));
            object testParam = _rnd.NextString(_rnd.Next(100));

            bool testOutput = testObject.Equals(testParam);

            Assert.IsFalse(testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_GetHashCodeMethod_ReturnsSameValueIfTwoInstancesAreEqual()
        {
            TimeOfDay testObject0 = new TimeOfDay(_rnd.Next(86400));
            TimeOfDay testObject1 = new TimeOfDay(testObject0.AbsoluteSeconds);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        public void TimeOfDayClass_GetHashCodeMethod_ReturnsDifferentValueIfTwoInstancesAreNotEqual()
        {
            TimeOfDay testObject0 = new TimeOfDay(_rnd.Next(86400));
            int testObject1Seconds;
            do
            {
                testObject1Seconds = _rnd.Next(86400);
            } while (testObject1Seconds == testObject0.AbsoluteSeconds);
            TimeOfDay testObject1 = new TimeOfDay(testObject1Seconds);

            int testOutput0 = testObject0.GetHashCode();
            int testOutput1 = testObject1.GetHashCode();

            Assert.AreNotEqual(testOutput0, testOutput1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TimeOfDayClass_CompareToMethodWithObjectParameter_ThrowsArgumentException_IfParameterIsString()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86400));
            string testParam = _rnd.NextString(_rnd.Next(100));

            testObject.CompareTo(testParam);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_CompareToMethodWithObjectParameter_ReturnsZero_IfParameterIsTimeOfDayObjectEqualToThis()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86400));
            object testParam = new TimeOfDay(testObject.AbsoluteSeconds);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_CompareToMethodWithObjectParameter_ReturnsOne_IfParameterIsTimeOfDayObjectLessThanThis()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(1, 86400));
            object testParam = new TimeOfDay(_rnd.Next(0, testObject.AbsoluteSeconds));

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_CompareToMethodWithObjectParameter_ReturnsMinusOne_IfParameterIsTimeOfDayObjectGreaterThanThis()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86399));
            object testParam = new TimeOfDay(_rnd.Next(testObject.AbsoluteSeconds + 1, 86400));

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_CompareToMethodWithTimeOfDayParameter_ReturnsZero_IfParameterIsTimeOfDayObjectEqualToThis()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86400));
            TimeOfDay testParam = new TimeOfDay(testObject.AbsoluteSeconds);

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_CompareToMethodWithTimeOfDayParameter_ReturnsOne_IfParameterIsTimeOfDayObjectLessThanThis()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(1, 86400));
            TimeOfDay testParam = new TimeOfDay(_rnd.Next(0, testObject.AbsoluteSeconds));

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(1, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_CompareToMethodWithTimeOfDayParameter_ReturnsMinusOne_IfParameterIsTimeOfDayObjectGreaterThanThis()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86399));
            TimeOfDay testParam = new TimeOfDay(_rnd.Next(testObject.AbsoluteSeconds + 1, 86400));

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_CompareToMethodWithTimeOfDayParameter_ReturnsMinusOne_IfParameterIsNull()
        {
            TimeOfDay testObject = new TimeOfDay(_rnd.Next(86399));
            TimeOfDay testParam = null;

            int testOutput = testObject.CompareTo(testParam);

            Assert.AreEqual(-1, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithNoParameters_ReturnsExpectedResult()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string expectedResult = $"{constrParam0:d2}:{constrParam1:d2}" + (constrParam2 > 30 ? "½" : "");
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString();

            Assert.AreEqual(expectedResult, testOutput);
        }

#pragma warning disable CA1305 // Specify IFormatProvider

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainshhToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "hh";
            int hours12 = (constrParam0 % 12 == 0) ? 12 : constrParam0 % 12;
            string expectedResult = $"{hours12:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainshToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "h";
            int hours12 = (constrParam0 % 12 == 0) ? 12 : constrParam0 % 12;
            string expectedResult = $"{hours12}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainshAndhhTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "hhh";
            int hours12 = (constrParam0 % 12 == 0) ? 12 : constrParam0 % 12;
            string expectedResult = $"{hours12:d2}{hours12}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainshhAndhhTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "hhhh";
            int hours12 = (constrParam0 % 12 == 0) ? 12 : constrParam0 % 12;
            string expectedResult = $"{hours12:d2}{hours12:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsHHToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "HH";
            string expectedResult = $"{constrParam0:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsHToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "H";
            string expectedResult = $"{constrParam0}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsHAndHHTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "HHH";
            string expectedResult = $"{constrParam0:d2}{constrParam0}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsHHAndHHTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "HHHH";
            string expectedResult = $"{constrParam0:d2}{constrParam0:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsmmToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "mm";
            string expectedResult = $"{constrParam1:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsmToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "m";
            string expectedResult = $"{constrParam1}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsmAndmmTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "mmm";
            string expectedResult = $"{constrParam1:d2}{constrParam1}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsmmAndmmTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "mmmm";
            string expectedResult = $"{constrParam1:d2}{constrParam1:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsssToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "ss";
            string expectedResult = $"{constrParam2:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainssToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "s";
            string expectedResult = $"{constrParam2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainssAndssTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "sss";
            string expectedResult = $"{constrParam2:d2}{constrParam2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsssAndssTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "ssss";
            string expectedResult = $"{constrParam2:d2}{constrParam2:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsfTokenAndSecondsPropertyOfObjectIsLessThan30()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(30);
            string testParam = "f";
            string expectedResult = "";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsfTokenAndSecondsPropertyOfObjectIsGreaterThanOrEqualTo30()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(30, 60);
            string testParam = "f";
            string expectedResult = "½";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsttTokenAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "tt";
            string expectedResult = "am";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainstTokenAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "t";
            string expectedResult = "a";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainstAndttTokensAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "ttt";
            string expectedResult = "ama";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsttAndsttTokensAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "tttt";
            string expectedResult = "amam";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsttTokenAndTimeIsInAternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "tt";
            string expectedResult = "pm";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainstTokenAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "t";
            string expectedResult = "p";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainstAndttTokensAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "ttt";
            string expectedResult = "pmp";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsttAndsttTokensAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "tttt";
            string expectedResult = "pmpm";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsTTTokenAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TT";
            string expectedResult = "AM";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsTTokenAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "T";
            string expectedResult = "A";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsTTAndTTokensAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TTT";
            string expectedResult = "AMA";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsTTAndsTTTokensAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TTTT";
            string expectedResult = "AMAM";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsTTTokenAndTimeIsInAternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TT";
            string expectedResult = "PM";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsTTokenAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "T";
            string expectedResult = "P";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsTTAndTTokensAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TTT";
            string expectedResult = "PMP";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsTTAndsTTTokensAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TTTT";
            string expectedResult = "PMPM";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsgToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "g";
            string expectedResult = $"{(constrParam2 + constrParam1 * 60 + constrParam0 * 3600)}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringParameter_ReturnsExpectedResult_IfParameterContainsGToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "G";
            string expectedResult = $"{(constrParam2 + constrParam1 * 60 + constrParam0 * 3600)}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam);

            Assert.AreEqual(expectedResult, testOutput);
        }

#pragma warning restore CA1305 // Specify IFormatProvider

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainshhToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "hh";
            int hours12 = (constrParam0 % 12 == 0) ? 12 : constrParam0 % 12;
            string expectedResult = $"{hours12:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainshToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "h";
            int hours12 = (constrParam0 % 12 == 0) ? 12 : constrParam0 % 12;
            string expectedResult = $"{hours12}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainshAndhhTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "hhh";
            int hours12 = (constrParam0 % 12 == 0) ? 12 : constrParam0 % 12;
            string expectedResult = $"{hours12:d2}{hours12}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainshhAndhhTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "hhhh";
            int hours12 = (constrParam0 % 12 == 0) ? 12 : constrParam0 % 12;
            string expectedResult = $"{hours12:d2}{hours12:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsHHToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "HH";
            string expectedResult = $"{constrParam0:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsHToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "H";
            string expectedResult = $"{constrParam0}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsHAndHHTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "HHH";
            string expectedResult = $"{constrParam0:d2}{constrParam0}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsHHAndHHTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "HHHH";
            string expectedResult = $"{constrParam0:d2}{constrParam0:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsmmToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "mm";
            string expectedResult = $"{constrParam1:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsmToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "m";
            string expectedResult = $"{constrParam1}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsmAndmmTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "mmm";
            string expectedResult = $"{constrParam1:d2}{constrParam1}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsmmAndmmTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "mmmm";
            string expectedResult = $"{constrParam1:d2}{constrParam1:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsssToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "ss";
            string expectedResult = $"{constrParam2:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainssToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "s";
            string expectedResult = $"{constrParam2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainssAndssTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "sss";
            string expectedResult = $"{constrParam2:d2}{constrParam2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsssAndssTokens()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "ssss";
            string expectedResult = $"{constrParam2:d2}{constrParam2:d2}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsfTokenAndSecondsPropertyOfObjectIsLessThan30()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(30);
            string testParam = "f";
            string expectedResult = "";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsfTokenAndSecondsPropertyOfObjectIsGreaterThanOrEqualTo30()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(30, 60);
            string testParam = "f";
            string expectedResult = "½";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsttTokenAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "tt";
            string expectedResult = "am";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainstTokenAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "t";
            string expectedResult = "a";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainstAndttTokensAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "ttt";
            string expectedResult = "ama";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsttAndsttTokensAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "tttt";
            string expectedResult = "amam";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsttTokenAndTimeIsInAternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "tt";
            string expectedResult = "pm";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainstTokenAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "t";
            string expectedResult = "p";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainstAndttTokensAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "ttt";
            string expectedResult = "pmp";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsttAndsttTokensAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "tttt";
            string expectedResult = "pmpm";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsTTTokenAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TT";
            string expectedResult = "AM";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsTTokenAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "T";
            string expectedResult = "A";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsTTAndTTokensAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TTT";
            string expectedResult = "AMA";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsTTAndsTTTokensAndTimeIsInMorning()
        {
            int constrParam0 = _rnd.Next(12);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TTTT";
            string expectedResult = "AMAM";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsTTTokenAndTimeIsInAternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TT";
            string expectedResult = "PM";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsTTokenAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "T";
            string expectedResult = "P";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsTTAndTTokensAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TTT";
            string expectedResult = "PMP";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsTTAndsTTTokensAndTimeIsInAfternoon()
        {
            int constrParam0 = _rnd.Next(12, 24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "TTTT";
            string expectedResult = "PMPM";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsgToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "g";
            string expectedResult = $"{(constrParam2 + constrParam1 * 60 + constrParam0 * 3600)}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ReturnsExpectedResult_IfParameterContainsGToken()
        {
            int constrParam0 = _rnd.Next(24);
            int constrParam1 = _rnd.Next(60);
            int constrParam2 = _rnd.Next(60);
            string testParam = "G";
            string expectedResult = $"{(constrParam2 + constrParam1 * 60 + constrParam0 * 3600)}";
            TimeOfDay testObject = new TimeOfDay(constrParam0, constrParam1, constrParam2);

            string testOutput = testObject.ToString(testParam, CultureInfo.InvariantCulture);

            Assert.AreEqual(expectedResult, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractOperatorWithTimeOfDayAndTimeOfDayParameter_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsBeforeSecondParameter()
        {
            int testSeconds0 = _rnd.Next(86399);
            int testSeconds1 = _rnd.Next(86400 - testSeconds0) + testSeconds0 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractOperatorWithTimeOfDayAndTimeOfDayParameter_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsAfterSecondParameter()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_SubtractOperatorWithTimeOfDayAndTimeOfDayOperands_ThrowsArgumentNullExceptionIfSecondOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            TimeOfDay testValue0 = null;
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            _ = testValue1 - testValue0;

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractOperatorWithTimeOfDayAndTimeOfDayOperands_ThrowsArgumentNullExceptionWithParamNameEqualToT2IfSecondOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            TimeOfDay testValue0 = null;
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            try
            {
                _ = testValue1 - testValue0;
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t2", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_SubtractOperatorWithTimeOfDayAndTimeOfDayOperands_ThrowsArgumentNullExceptionIfFirstOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeOfDay testValue1 = null;

            _ = testValue1 - testValue0;

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractOperatorWithTimeOfDayAndTimeOfDayOperands_ThrowsArgumentNullExceptionWithParamNameEqualToT1IfFirstOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeOfDay testValue1 = null;

            try
            {
                _ = testValue1 - testValue0;
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t1", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractMethodWithTimeOfDayAndTimeOfDayParameter_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsBeforeSecondParameter()
        {
            int testSeconds0 = _rnd.Next(86399);
            int testSeconds1 = _rnd.Next(86400 - testSeconds0) + testSeconds0 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = TimeOfDay.Subtract(testValue1, testValue0);

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractMethodWithTimeOfDayAndTimeOfDayParameters_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsAfterSecondParameter()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = TimeOfDay.Subtract(testValue1, testValue0);

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_SubtractMethodWithTimeOfDayAndTimeOfDayParameters_ThrowsArgumentNullExceptionIfSecondOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            TimeOfDay testValue0 = null;
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            _ = TimeOfDay.Subtract(testValue1, testValue0);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractMethodWithTimeOfDayAndTimeOfDayParameters_ThrowsArgumentNullExceptionWithParamNameEqualToT2IfSecondOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            TimeOfDay testValue0 = null;
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            try
            {
                _ = TimeOfDay.Subtract(testValue1, testValue0);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t2", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_SubtractMethodWithTimeOfDayAndTimeOfDayOperands_ThrowsArgumentNullExceptionIfFirstOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeOfDay testValue1 = null;

            _ = TimeOfDay.Subtract(testValue1, testValue0);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractMethodWithTimeOfDayAndTimeOfDayOperands_ThrowsArgumentNullExceptionWithParamNameEqualToT1IfFirstOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeOfDay testValue1 = null;

            try
            {
                _ = TimeOfDay.Subtract(testValue1, testValue0);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t1", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractOperatorWithTimeOfDayAndTimeSpanOperands_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsBeforeSecondParameter()
        {
            int testSeconds0 = _rnd.Next(86399);
            int testSeconds1 = _rnd.Next(86400 - testSeconds0) + testSeconds0 + 1;
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractOperatorWithTimeOfDayAndTimeSpanOperands_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsAfterSecondParameter()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_SubtractOperatorWithTimeOfDayAndTimeSpanOperands_ThrowsArgumentNullExceptionIfFirstOperandIsNull()
        {
            int testSeconds0 = _rnd.Next(86399);
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = null;

            _ = testValue1 - testValue0;

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractOperatorWithTimeOfDayAndTimeSpanOperands_ThrowsArgumentNullExceptionWithParamNameEqualToT1IfFirstOperandIsNull()
        {
            int testSeconds0 = _rnd.Next(86399);
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = null;

            try
            {
                _ = testValue1 - testValue0;
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t1", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractMethodWithTimeOfDayAndTimeSpanParameters_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsBeforeSecondParameter()
        {
            int testSeconds0 = _rnd.Next(86399);
            int testSeconds1 = _rnd.Next(86400 - testSeconds0) + testSeconds0 + 1;
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = TimeOfDay.Subtract(testValue1, testValue0);

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractMethodWithTimeOfDayAndTimeSpanParameters_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsAfterSecondParameter()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeSpan testOutput = TimeOfDay.Subtract(testValue1, testValue0);

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_SubtractMethodWithTimeOfDayAndTimeSpanParameters_ThrowsArgumentNullExceptionIfFirstOperandIsNull()
        {
            int testSeconds0 = _rnd.Next(86399);
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = null;

            _ = TimeOfDay.Subtract(testValue1, testValue0);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractMethodWithTimeOfDayAndTimeSpanParameters_ThrowsArgumentNullExceptionWithParamNameEqualToT1IfFirstOperandIsNull()
        {
            int testSeconds0 = _rnd.Next(86399);
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = null;

            try
            {
                _ = TimeOfDay.Subtract(testValue1, testValue0);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t1", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractOperatorWithTimeSpanAndTimeOfDayOperands_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsBeforeSecondParameter()
        {
            int testSeconds0 = _rnd.Next(86399);
            int testSeconds1 = _rnd.Next(86400 - testSeconds0) + testSeconds0 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractOperatorWithTimeSpanAndTimeOfDayOperands_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsAfterSecondParameter()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            TimeSpan testOutput = testValue1 - testValue0;

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_SubtractOperatorWithTimeSpanAndTimeOfDayOperands_ThrowsArgumentNullExceptionIfSecondOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            TimeOfDay testValue0 = null;
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            _ = testValue1 - testValue0;

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractOperatorWithTimeSpanAndTimeOfDayOperands_ThrowsArgumentNullExceptionWithParamNameEqualToT2IfSecondOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            TimeOfDay testValue0 = null;
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            try
            {
                _ = testValue1 - testValue0;
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t2", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractMethodWithTimeSpanAndTimeOfDayParameters_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsBeforeSecondParameter()
        {
            int testSeconds0 = _rnd.Next(86399);
            int testSeconds1 = _rnd.Next(86400 - testSeconds0) + testSeconds0 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            TimeSpan testOutput = TimeOfDay.Subtract(testValue1, testValue0);

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractMethodWithTimeSpanAndTimeOfDayParameters_ReturnsTimeSpanWithCorrectValueIfFirstParameterIsAfterSecondParameter()
        {
            int testSeconds1 = _rnd.Next(86399);
            int testSeconds0 = _rnd.Next(86400 - testSeconds1) + testSeconds1 + 1;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            TimeSpan testOutput = TimeOfDay.Subtract(testValue1, testValue0);

            Assert.AreEqual(testSeconds1 - testSeconds0, (int)testOutput.TotalSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_SubtractMethodWithTimeSpanAndTimeOfDayParameters_ThrowsArgumentNullExceptionIfSecondOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            TimeOfDay testValue0 = null;
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            _ = TimeOfDay.Subtract(testValue1, testValue0);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_SubtractMethodWithTimeSpanAndTimeOfDayParameters_ThrowsArgumentNullExceptionWithParamNameEqualToT2IfSecondOperandIsNull()
        {
            int testSeconds1 = _rnd.Next(86399);
            TimeOfDay testValue0 = null;
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            try
            {
                _ = TimeOfDay.Subtract(testValue1, testValue0);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t2", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_AddOperatorWithTimeOfDayAndTimeSpanOperands_ReturnsTimeOfDayWithCorrectValueIfResultDoesNotCrossMidnight()
        {
            int testSeconds0 = _rnd.Next(86398);
            int testSeconds1 = _rnd.Next(86399 - testSeconds0) + testSeconds0;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            TimeOfDay testOutput = testValue0 + testValue1;

            Assert.AreEqual(testSeconds0 + testSeconds1, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_AddOperatorWithTimeOfDayAndTimeSpanOperands_ThrowsArgumentNullExceptionIfFirstOperandIsNull()
        {
            int testSeconds0 = _rnd.Next(86398);
            int testSeconds1 = _rnd.Next(86399 - testSeconds0) + testSeconds0;
            TimeOfDay testValue0 = null;
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            _ = testValue0 + testValue1;

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_AddOperatorWithTimeOfDayAndTimeSpanOperands_ThrowsArgumentNullExceptionWithCorrectParamNamePropertyIfFirstOperandIsNull()
        {
            int testSeconds0 = _rnd.Next(86398);
            int testSeconds1 = _rnd.Next(86399 - testSeconds0) + testSeconds0;
            TimeOfDay testValue0 = null;
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            try 
            {
                _ = testValue0 + testValue1;
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t1", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_AddMethodWithTimeOfDayAndTimeSpanParameters_ReturnsTimeOfDayWithCorrectValueIfResultDoesNotCrossMidnight()
        {
            int testSeconds0 = _rnd.Next(86398);
            int testSeconds1 = _rnd.Next(86399 - testSeconds0) + testSeconds0;
            TimeOfDay testValue0 = new TimeOfDay(testSeconds0);
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            TimeOfDay testOutput = TimeOfDay.Add(testValue0, testValue1);

            Assert.AreEqual(testSeconds0 + testSeconds1, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_AddMethodWithTimeOfDayAndTimeSpanParameters_ThrowsArgumentNullExceptionIfFirstParameterIsNull()
        {
            int testSeconds0 = _rnd.Next(86398);
            int testSeconds1 = _rnd.Next(86399 - testSeconds0) + testSeconds0;
            TimeOfDay testValue0 = null;
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            _ = TimeOfDay.Add(testValue0, testValue1);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_AddMethodWithTimeOfDayAndTimeSpanParameters_ThrowsArgumentNullExceptionWithCorrectParamNamePropertyIfFirstParameterIsNull()
        {
            int testSeconds0 = _rnd.Next(86398);
            int testSeconds1 = _rnd.Next(86399 - testSeconds0) + testSeconds0;
            TimeOfDay testValue0 = null;
            TimeSpan testValue1 = TimeSpan.FromSeconds(testSeconds1);

            try
            {
                _ = TimeOfDay.Add(testValue0, testValue1);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t1", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_AddOperatorWithTimeSpanAndTimeOfDayOperands_ReturnsTimeOfDayWithCorrectValueIfResultDoesNotCrossMidnight()
        {
            int testSeconds0 = _rnd.Next(86398);
            int testSeconds1 = _rnd.Next(86399 - testSeconds0) + testSeconds0;
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeOfDay testOutput = testValue0 + testValue1;

            Assert.AreEqual(testSeconds0 + testSeconds1, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_AddOperatorWithTimeSpanAndTimeOfDayOperands_ThrowsArgumentNullExceptionIfSecondOperandIsNull()
        {
            int testSeconds0 = _rnd.Next(86398);
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = null;

            _ = testValue0 + testValue1;

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_AddOperatorWithTimeSpanAndTimeOfDayOperands_ThrowsArgumentNullExceptionWithCorrectParamNamePropertyIfSecondOperandIsNull()
        {
            int testSeconds0 = _rnd.Next(86398);
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = null;

            try
            {
                _ = testValue0 + testValue1;
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t2", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_AddMethodWithTimeSpanAndTimeOfDayParameters_ReturnsTimeOfDayWithCorrectValueIfResultDoesNotCrossMidnight()
        {
            int testSeconds0 = _rnd.Next(86398);
            int testSeconds1 = _rnd.Next(86399 - testSeconds0) + testSeconds0;
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = new TimeOfDay(testSeconds1);

            TimeOfDay testOutput = TimeOfDay.Add(testValue0, testValue1);

            Assert.AreEqual(testSeconds0 + testSeconds1, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_AddMethodWithTimeSpanAndTimeOfDayParameters_ThrowsArgumentNullExceptionIfSecondParameterIsNull()
        {
            int testSeconds0 = _rnd.Next(86398);
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = null;

            _ = TimeOfDay.Add(testValue0, testValue1);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_AddMethodWithTimeSpanAndTimeOfDayParameters_ThrowsArgumentNullExceptionWithCorrectParamNamePropertyIfSecondParameterIsNull()
        {
            int testSeconds0 = _rnd.Next(86398);
            TimeSpan testValue0 = TimeSpan.FromSeconds(testSeconds0);
            TimeOfDay testValue1 = null;

            try
            {
                _ = TimeOfDay.Add(testValue0, testValue1);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("t2", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_FromTimeSpanMethod_ReturnsObjectWithCorrectAbsoluteSecondsProperty()
        {
            int testPeriod = _rnd.Next(86400);
            TimeSpan span = new TimeSpan(0, 0, testPeriod);

            TimeOfDay testOutput = TimeOfDay.FromTimeSpan(span);

            Assert.AreEqual(testPeriod, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_CopyAndReflectMethod_ThrowsArgumentNullExceptionIfParameterIsNull()
        {
            int origTime = _rnd.Next(86380) + 10;
            TimeOfDay testObject = new TimeOfDay(origTime);

            testObject.CopyAndReflect(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_CopyAndReflectMethod_ThrowsArgumentNullExceptionWithCorrectParamNamePropertyIfParameterIsNull()
        {
            int origTime = _rnd.Next(86380) + 10;
            TimeOfDay testObject = new TimeOfDay(origTime);

            try
            {
                testObject.CopyAndReflect(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("aroundTime", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimeOfDayClass_CopyAndReflectMethod_ReturnsDifferentObject()
        {
            int origTime = _rnd.Next(86380) + 10;
            TimeOfDay testObject = new TimeOfDay(origTime);
            int reflectAroundSecs = _rnd.Next((86400 - origTime) / 2 + origTime / 2) + (origTime / 2);
            TimeOfDay testParam = new TimeOfDay(reflectAroundSecs);

            TimeOfDay testOutput = testObject.CopyAndReflect(testParam);

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TimeOfDayClass_CopyAndReflectMethod_DoesNotChangeOriginalObject()
        {
            int origTime = _rnd.Next(86380) + 10;
            TimeOfDay testObject = new TimeOfDay(origTime);
            int reflectAroundSecs = _rnd.Next((86400 - origTime) / 2 + origTime / 2) + (origTime / 2);
            TimeOfDay testParam = new TimeOfDay(reflectAroundSecs);

            _ = testObject.CopyAndReflect(testParam);

            Assert.AreEqual(origTime, testObject.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_CopyAndReflectMethod_ReturnsObjectWithCorrectTimeIfReflectedInFutureObject()
        {
            int origTime = _rnd.Next(86380);
            TimeOfDay testObject = new TimeOfDay(origTime);
            int reflectAroundSecs = _rnd.Next((86400 - origTime) / 2) + origTime;
            TimeOfDay testParam = new TimeOfDay(reflectAroundSecs);

            TimeOfDay testOutput = testObject.CopyAndReflect(testParam);

            Assert.AreEqual(reflectAroundSecs * 2 - origTime, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        public void TimeOfDayClass_CopyAndReflectMethod_ReturnsObjectWithCorrectTimeIfReflectedInPriorObject()
        {
            int origTime = _rnd.Next(86380);
            TimeOfDay testObject = new TimeOfDay(origTime);
            int reflectAroundSecs = _rnd.Next(origTime / 2) + origTime / 2;
            TimeOfDay testParam = new TimeOfDay(reflectAroundSecs);

            TimeOfDay testOutput = testObject.CopyAndReflect(testParam);

            Assert.AreEqual(reflectAroundSecs * 2 - origTime, testOutput.AbsoluteSeconds);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ThrowsArgumentNullExceptionIfFirstParameterIsNull()
        {
            string testParam0 = null;
            int origTime = _rnd.Next(86380);
            TimeOfDay testObject = new TimeOfDay(origTime);

            testObject.ToString(testParam0, CultureInfo.CurrentCulture);

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayClass_ToStringMethodWithStringAndIFormatProviderParameters_ThrowsArgumentNullExceptionWithCorrectParamNamePropertyIfFirstParameterIsNull()
        {
            string testParam0 = null;
            int origTime = _rnd.Next(86380);
            TimeOfDay testObject = new TimeOfDay(origTime);

            try
            {
                testObject.ToString(testParam0, CultureInfo.CurrentCulture);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("format", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
