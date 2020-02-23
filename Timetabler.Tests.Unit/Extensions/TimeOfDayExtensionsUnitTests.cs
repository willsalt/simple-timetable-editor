using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Extensions;

namespace Timetabler.Tests.Unit.Extensions
{
    [TestClass]
    public class TimeOfDayExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayExtensionsClass_SetTimeMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            TimeOfDay testObject = null;
            using (TextBox testParam1 = new TextBox())
            using (TextBox testParam2 = new TextBox())
            using (ComboBox testParam3 = new ComboBox())
            {
                ClockType testParam4 = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock;

                testObject.SetTime(testParam1, testParam2, testParam3, testParam4);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TimeOfDayExtensionsClass_SetTimeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            TimeOfDay testObject = null;
            using (TextBox testParam1 = new TextBox())
            using (TextBox testParam2 = new TextBox())
            using (ComboBox testParam3 = new ComboBox())
            {
                ClockType testParam4 = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock;

                try
                {
                    testObject.SetTime(testParam1, testParam2, testParam3, testParam4);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("time", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayExtensionsClass_SetTimeMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            TimeOfDay testObject = new TimeOfDay();
            TextBox testParam1 = null;
            using (TextBox testParam2 = new TextBox())
            using (ComboBox testParam3 = new ComboBox())
            {
                ClockType testParam4 = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock;

                testObject.SetTime(testParam1, testParam2, testParam3, testParam4);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TimeOfDayExtensionsClass_SetTimeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfSecondParameterIsNull()
        {
            TimeOfDay testObject = new TimeOfDay();
            TextBox testParam1 = null;
            using (TextBox testParam2 = new TextBox())
            using (ComboBox testParam3 = new ComboBox())
            {
                ClockType testParam4 = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock;

                try
                {
                    testObject.SetTime(testParam1, testParam2, testParam3, testParam4);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("tbHour", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayExtensionsClass_SetTimeMethod_ThrowsArgumentNullException_IfThirdParameterIsNull()
        {
            TimeOfDay testObject = new TimeOfDay();
            TextBox testParam2 = null;
            using (TextBox testParam1 = new TextBox())
            using (ComboBox testParam3 = new ComboBox())
            {
                ClockType testParam4 = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock;

                testObject.SetTime(testParam1, testParam2, testParam3, testParam4);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TimeOfDayExtensionsClass_SetTimeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfThirdParameterIsNull()
        {
            TimeOfDay testObject = new TimeOfDay();
            TextBox testParam2 = null;
            using (TextBox testParam1 = new TextBox())
            using (ComboBox testParam3 = new ComboBox())
            {
                ClockType testParam4 = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock;

                try
                {
                    testObject.SetTime(testParam1, testParam2, testParam3, testParam4);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("tbMinute", ex.ParamName);
                }
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimeOfDayExtensionsClass_SetTimeMethod_ThrowsArgumentNullException_IfFourthParameterIsNull()
        {
            TimeOfDay testObject = new TimeOfDay();
            ComboBox testParam3 = null;
            using (TextBox testParam1 = new TextBox())
            using (TextBox testParam2 = new TextBox())
            {
                ClockType testParam4 = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock;

                testObject.SetTime(testParam1, testParam2, testParam3, testParam4);

                Assert.Fail();
            }
        }

        [TestMethod]
        public void TimeOfDayExtensionsClass_SetTimeMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFourthParameterIsNull()
        {
            TimeOfDay testObject = new TimeOfDay();
            ComboBox testParam3 = null;
            using (TextBox testParam1 = new TextBox())
            using (TextBox testParam2 = new TextBox())
            {
                ClockType testParam4 = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock;

                try
                {
                    testObject.SetTime(testParam1, testParam2, testParam3, testParam4);
                    Assert.Fail();
                }
                catch (ArgumentNullException ex)
                {
                    Assert.AreEqual("cbHalfOfDay", ex.ParamName);
                }
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
