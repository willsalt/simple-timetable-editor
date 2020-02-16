using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.DataLoader.Tests.Unit.TestHelpers;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class TimeOfDayModelExtensionsUnitTests
    {
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
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NullValue);
            TimeOfDayModel testParam = testParamSpec.Model;

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsFormatException_IfParameterHasTimePropertyThatIsEmptyString()
        {
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.EmptyValue);
            TimeOfDayModel testParam = testParamSpec.Model;

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsFormatException_IfParameterHasTimePropertyThatIsSolelyWhitespace()
        {
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.WhitespaceValue);
            TimeOfDayModel testParam = testParamSpec.Model;

            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TimeofDayModelExtensionsClass_ToTimeOfDayMethod_ThrowsFormatException_IfParameterConsistsOfNonNumericString()
        {
            TimeOfDaySpecification timeOfDaySpecification = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NonNumericValue);
            TimeOfDayModel testParam = timeOfDaySpecification.Model;
            _ = testParam.ToTimeOfDay();

            Assert.Fail();
        }

        [TestMethod]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ReturnsObjectWithCorrectValue_IfParameterConsistsOfNumberInRangeWithNoColons()
        {
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursOnly);
            TimeOfDayModel testParam = testParamSpec.Model;

            TimeOfDay testOutput = testParam.ToTimeOfDay();

            Assert.AreEqual(testParamSpec.Hours.Value * 3600, testOutput.AbsoluteSeconds);
            Assert.AreEqual(testParamSpec.Hours.Value, testOutput.Hours24);
            Assert.AreEqual(0, testOutput.Minutes);
            Assert.AreEqual(0, testOutput.Seconds);
        }

        [TestMethod]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ReturnsObjectWithCorrectValue_IfParameterConsistsOfTwoNumbersInRangeSeparatedByColon()
        {
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursAndMinutes);
            int expectedSeconds = testParamSpec.Hours.Value * 3600 + testParamSpec.Minutes.Value * 60;
            TimeOfDayModel testParam = testParamSpec.Model;

            TimeOfDay testOutput = testParam.ToTimeOfDay();

            Assert.AreEqual(expectedSeconds, testOutput.AbsoluteSeconds);
            Assert.AreEqual(testParamSpec.Hours.Value % 24, testOutput.Hours24);
            Assert.AreEqual(testParamSpec.Minutes.Value % 60, testOutput.Minutes);
            Assert.AreEqual(0, testOutput.Seconds);
        }

        [TestMethod]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ReturnsObjectWithCorrectValue_IfParameterConsistsOfThreeNumbersInRangeSeparatedByColons()
        {
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds);
            int expectedSeconds = testParamSpec.Hours.Value * 3600 + testParamSpec.Minutes.Value * 60 + testParamSpec.Seconds.Value;
            TimeOfDayModel testParam = testParamSpec.Model;

            TimeOfDay testOutput = testParam.ToTimeOfDay();

            Assert.AreEqual(expectedSeconds, testOutput.AbsoluteSeconds);
            Assert.AreEqual(testParamSpec.Hours.Value % 24, testOutput.Hours24);
            Assert.AreEqual(testParamSpec.Minutes.Value % 60, testOutput.Minutes);
            Assert.AreEqual(testParamSpec.Seconds.Value, testOutput.Seconds);
        }

        [TestMethod]
        public void TimeOfDayModelExtensionsClass_ToTimeOfDayMethod_ReturnsObjectWithCorrectValue_IfParameterConsistsOfMoreThanThreeNumbersInRangeSeparatedByColons()
        {
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSecondsAndMore);
            int expectedSeconds = testParamSpec.Hours.Value * 3600 + testParamSpec.Minutes.Value * 60 + testParamSpec.Seconds.Value;
            TimeOfDayModel testParam = testParamSpec.Model;

            TimeOfDay testOutput = testParam.ToTimeOfDay();

            Assert.AreEqual(expectedSeconds, testOutput.AbsoluteSeconds);
            Assert.AreEqual(testParamSpec.Hours.Value % 24, testOutput.Hours24);
            Assert.AreEqual(testParamSpec.Minutes.Value % 60, testOutput.Minutes);
            Assert.AreEqual(testParamSpec.Seconds.Value, testOutput.Seconds);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
