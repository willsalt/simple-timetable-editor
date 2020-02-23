using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class ToWorkModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static ToWorkModel GetModel()
        {
            return new ToWorkModel
            {
                Text = _rnd.NextString(_rnd.Next(20)),
                At = new TimeOfDayModel
                {
                    Time = _rnd.Next(24).ToString(CultureInfo.InvariantCulture) + ":" + _rnd.Next(60).ToString(CultureInfo.InvariantCulture) + ":" +
                        _rnd.Next(60).ToString(CultureInfo.InvariantCulture),
                },
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            ToWorkModel testParam = null;

            _ = testParam.ToToWork();

            Assert.Fail();
        }

        [TestMethod]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ReturnsObjectWithCorrectTextProperty_IfTextPropertyOfParameterIsNotNull()
        {
            ToWorkModel testParam = GetModel();

            ToWork testOutput = testParam.ToToWork();

            Assert.AreEqual(testParam.Text, testOutput.Text);
        }

        [TestMethod]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ReturnsObjectWithNullTextProperty_IfTextPropertyOfParameterIsNull()
        {
            ToWorkModel testParam = GetModel();
            testParam.Text = null;

            ToWork testOutput = testParam.ToToWork();

            Assert.IsNull(testOutput.Text);
        }

        [TestMethod]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ReturnsObjectWithAtTimePropertyEqualToNull_IfAtPropertyOfParameterIsNull()
        {
            ToWorkModel testParam = GetModel();
            testParam.At = null;

            ToWork testOutput = testParam.ToToWork();

            Assert.IsNull(testOutput.AtTime);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ThrowsFormatException_IfParameterHasAtPropertyWithTimePropertyThatIsNull()
        {
            ToWorkModel testParam = GetModel();
            testParam.At = new TimeOfDayModel { Time = null };

            _ = testParam.ToToWork();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ThrowsFormatException_IfParameterHasAtPropertyWithTimePropertyThatIsEmptyString()
        {
            ToWorkModel testParam = GetModel();
            testParam.At = new TimeOfDayModel { Time = "" };

            _ = testParam.ToToWork();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ThrowsFormatException_IfParameterHasAtPropertyWithTimePropertyThatIsSolelyWhitespace()
        {
            ToWorkModel testParam = GetModel();
            testParam.At = new TimeOfDayModel { Time = _rnd.NextString(" \t\f\n", _rnd.Next(1, 10)) };

            _ = testParam.ToToWork();

            Assert.Fail();
        }

        [TestMethod]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ReturnsObjectWithCorrectAtTimeProperty_IfParameterHasAtPropertyWithTimePropertyThatConsistsOfNumberInRangeWithNoColons()
        {
            int hoursValue = _rnd.Next(24);
            ToWorkModel testParam = GetModel();
            testParam.At = new TimeOfDayModel { Time = hoursValue.ToString(CultureInfo.InvariantCulture) };

            ToWork testOutput = testParam.ToToWork();

            Assert.AreEqual(hoursValue * 3600, testOutput.AtTime.AbsoluteSeconds);
            Assert.AreEqual(hoursValue, testOutput.AtTime.Hours24);
            Assert.AreEqual(0, testOutput.AtTime.Minutes);
            Assert.AreEqual(0, testOutput.AtTime.Seconds);
        }

        [TestMethod]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ReturnsObjectWithCorrectAtTimeProperty_IfParameterHasAtPropertyWithTimePropertyThatConsistsOfTwoNumbersInRangeSeparatedByColon()
        {
            int hoursValue = _rnd.Next(24);
            int minutesValue = _rnd.Next(60);
            int expectedSeconds = hoursValue * 3600 + minutesValue * 60;
            ToWorkModel testParam = GetModel();
            testParam.At =
                new TimeOfDayModel { Time = hoursValue.ToString(CultureInfo.InvariantCulture) + ":" + minutesValue.ToString(CultureInfo.InvariantCulture) };

            ToWork testOutput = testParam.ToToWork();

            Assert.AreEqual(expectedSeconds, testOutput.AtTime.AbsoluteSeconds);
            Assert.AreEqual(hoursValue % 24, testOutput.AtTime.Hours24);
            Assert.AreEqual(minutesValue % 60, testOutput.AtTime.Minutes);
            Assert.AreEqual(0, testOutput.AtTime.Seconds);
        }

        [TestMethod]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ReturnsObjectWithCorrectAtTimeProperty_IfParameterHasAtPropertyWithTimePropertyThatConsistsOfThreeNumbersInRangeSeparatedByColons()
        {
            int hoursValue = _rnd.Next(24);
            int minutesValue = _rnd.Next(60);
            int secondValue = _rnd.Next(60);
            int expectedSeconds = hoursValue * 3600 + minutesValue * 60 + secondValue;
            ToWorkModel testParam = GetModel();
            testParam.At =
                new TimeOfDayModel
                {
                    Time = hoursValue.ToString(CultureInfo.InvariantCulture) + ":" + minutesValue.ToString(CultureInfo.InvariantCulture) + ":" +
                        secondValue.ToString(CultureInfo.InvariantCulture),
                };

            ToWork testOutput = testParam.ToToWork();

            Assert.AreEqual(expectedSeconds, testOutput.AtTime.AbsoluteSeconds);
            Assert.AreEqual(hoursValue % 24, testOutput.AtTime.Hours24);
            Assert.AreEqual(minutesValue % 60, testOutput.AtTime.Minutes);
            Assert.AreEqual(secondValue, testOutput.AtTime.Seconds);
        }

        [TestMethod]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ReturnsObjectWithCorrectAtTimeProperty_IfParameterHasAtPropertyWithTimePropertyConsistsOfMoreThanThreeNumbersInRangeSeparatedByColons()
        {
            int hoursValue = _rnd.Next(24);
            int minutesValue = _rnd.Next(60);
            int secondValue = _rnd.Next(60);
            int expectedSeconds = hoursValue * 3600 + minutesValue * 60 + secondValue;
            ToWorkModel testParam = GetModel();
            testParam.At =
                new TimeOfDayModel
                {
                    Time = hoursValue.ToString(CultureInfo.InvariantCulture) + ":" + minutesValue.ToString(CultureInfo.InvariantCulture) + ":" +
                        secondValue.ToString(CultureInfo.InvariantCulture) + ":" + _rnd.NextString(":0123456789", _rnd.Next(1, 50)),
                };

            ToWork testOutput = testParam.ToToWork();

            Assert.AreEqual(expectedSeconds, testOutput.AtTime.AbsoluteSeconds);
            Assert.AreEqual(hoursValue % 24, testOutput.AtTime.Hours24);
            Assert.AreEqual(minutesValue % 60, testOutput.AtTime.Minutes);
            Assert.AreEqual(secondValue, testOutput.AtTime.Seconds);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ThrowsFormatException_IfParameterHasAtPropertyWithTimePropertyThatConsistsOfNonNumericString()
        {
            string notATime = _rnd.NextString("abcdefghijklmnopqrstuvwxzy:", _rnd.Next(1, 50));
            ToWorkModel testParam = GetModel();
            testParam.At = new TimeOfDayModel { Time = notATime };

            _ = testParam.ToToWork();

            Assert.Fail();
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
