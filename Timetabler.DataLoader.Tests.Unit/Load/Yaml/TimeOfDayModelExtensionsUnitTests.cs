using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class TimeOfDayModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            TimeOfDayModel testParam = null;

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsFormatException_IfParameterHasTimePropertyThatIsNull()
        {
            TimeOfDayModel testParam = new TimeOfDayModel { Time = null };

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsFormatException_IfParameterHasTimePropertyThatIsEmptyString()
        {
            TimeOfDayModel testParam = new TimeOfDayModel { Time = "" };

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsFormatException_IfParameterHasTimePropertyThatIsSolelyWhitespace()
        {
            TimeOfDayModel testParam = new TimeOfDayModel { Time = _rnd.NextString(" \t\f\n", _rnd.Next(1, 10)) };

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ReturnsObjectWithCorrectValue_IfParameterConsistsOfNumberInRangeWithNoColons()
        {
            int hoursValue = _rnd.Next(24);
            TimeOfDayModel testParam = new TimeOfDayModel { Time = hoursValue.ToString(CultureInfo.InvariantCulture) };

            TimeOfDay testOutput = testParam.ToTimeOfDay();

            Assert.AreEqual(hoursValue * 3600, testOutput.AbsoluteSeconds);
            Assert.AreEqual(hoursValue, testOutput.Hours24);
            Assert.AreEqual(0, testOutput.Minutes);
            Assert.AreEqual(0, testOutput.Seconds);
        }

        [TestMethod]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ReturnsObjectWithCorrectValue_IfParameterConsistsOfTwoNumbersInRangeSeparatedByColon()
        {
            int hoursValue = _rnd.Next(24);
            int minutesValue = _rnd.Next(60);
            int expectedSeconds = hoursValue * 3600 + minutesValue * 60;
            TimeOfDayModel testParam = 
                new TimeOfDayModel { Time = hoursValue.ToString(CultureInfo.InvariantCulture) + ":" + minutesValue.ToString(CultureInfo.InvariantCulture) };

            TimeOfDay testOutput = testParam.ToTimeOfDay();

            Assert.AreEqual(expectedSeconds, testOutput.AbsoluteSeconds);
            Assert.AreEqual(hoursValue % 24, testOutput.Hours24);
            Assert.AreEqual(minutesValue % 60, testOutput.Minutes);
            Assert.AreEqual(0, testOutput.Seconds);
        }

        [TestMethod]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ReturnsObjectWithCorrectValue_IfParameterConsistsOfThreeNumbersInRangeSeparatedByColons()
        {
            int hoursValue = _rnd.Next(24);
            int minutesValue = _rnd.Next(60);
            int secondValue = _rnd.Next(60);
            int expectedSeconds = hoursValue * 3600 + minutesValue * 60 + secondValue;
            TimeOfDayModel testParam =
                new TimeOfDayModel
                {
                    Time = hoursValue.ToString(CultureInfo.InvariantCulture) + ":" + minutesValue.ToString(CultureInfo.InvariantCulture) + ":" +
                        secondValue.ToString(CultureInfo.InvariantCulture),
                };

            TimeOfDay testOutput = testParam.ToTimeOfDay();

            Assert.AreEqual(expectedSeconds, testOutput.AbsoluteSeconds);
            Assert.AreEqual(hoursValue % 24, testOutput.Hours24);
            Assert.AreEqual(minutesValue % 60, testOutput.Minutes);
            Assert.AreEqual(secondValue, testOutput.Seconds);
        }

        [TestMethod]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ReturnsObjectWithCorrectValue_IfParameterConsistsOfMoreThanThreeNumbersInRangeSeparatedByColons()
        {
            int hoursValue = _rnd.Next(24);
            int minutesValue = _rnd.Next(60);
            int secondValue = _rnd.Next(60);
            int expectedSeconds = hoursValue * 3600 + minutesValue * 60 + secondValue;
            TimeOfDayModel testParam =
                new TimeOfDayModel
                {
                    Time = hoursValue.ToString(CultureInfo.InvariantCulture) + ":" + minutesValue.ToString(CultureInfo.InvariantCulture) + ":" +
                        secondValue.ToString(CultureInfo.InvariantCulture) + ":" + _rnd.NextString(":0123456789", _rnd.Next(1, 50)),
                };

            TimeOfDay testOutput = testParam.ToTimeOfDay();

            Assert.AreEqual(expectedSeconds, testOutput.AbsoluteSeconds);
            Assert.AreEqual(hoursValue % 24, testOutput.Hours24);
            Assert.AreEqual(minutesValue % 60, testOutput.Minutes);
            Assert.AreEqual(secondValue, testOutput.Seconds);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimeofDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsFormatException_IfParameterConsistsOfNonNumericString()
        {
            string notATime = _rnd.NextString("abcdefghijklmnopqrstuvwxzy:", _rnd.Next(1, 50));
            TimeOfDayModel testParam = new TimeOfDayModel { Time = notATime };
            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
