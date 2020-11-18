using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load;
using Timetabler.DataLoader.Tests.Unit.TestHelpers;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Load
{
    [TestClass]
    public class SignalboxHoursModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static SignalboxHoursModel GetTestObject()
        {
            return new SignalboxHoursModel
            {
                SignalboxId = _rnd.NextHexString(8),
                StartTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds).Model,
                FinishTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds).Model,
                TokenBalanceWarning = _rnd.NextNullableBoolean(),
            };
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        private static IDictionary<string, Signalbox> GetSignalboxCollectionWithoutItem(string item)
        {
            int count = _rnd.Next(1, 20);
            Dictionary<string, Signalbox> output = new Dictionary<string, Signalbox>();
            for (int i = 0; i < count; ++i)
            {
                string id;
                do
                {
                    id = _rnd.NextHexString(8);
                } while (id == item || output.ContainsKey(id));
                output.Add(id,
                    new Signalbox { Id = id, Code = _rnd.NextString(_rnd.Next(1, 6)), EditorDisplayName = _rnd.NextString(10), ExportDisplayName = _rnd.NextString(10) });
            }
            return output;
        }

        private static IDictionary<string, Signalbox> GetSignalboxCollectionWithItem(string item)
        {
            IDictionary<string, Signalbox> output = GetSignalboxCollectionWithoutItem(item);
            output.Add(item, 
                new Signalbox { Id = item, Code = _rnd.NextString(_rnd.Next(1, 6)), EditorDisplayName = _rnd.NextString(10), ExportDisplayName = _rnd.NextString(10) });
            return output;
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            SignalboxHoursModel testParam0 = null;
            IDictionary<string, Signalbox> testParam1 = new Dictionary<string, Signalbox>();

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = null;

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithSignalboxPropertySetToNull_IfSecondParameterIsEmptyCollection()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = new Dictionary<string, Signalbox>();

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.IsNull(testOutput.Signalbox);
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithSignalboxPropertySetToNull_IfSecondParameterIsCollectionThatDoesNotContainSignalboxIdPropertyOfFirstParameter()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithoutItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.IsNull(testOutput.Signalbox);
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithCorrectSignalboxProperty_IfSecondParameterIsCollectionThatContainsSignalboxIdPropertyOfFirstParameter()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.AreSame(testParam1[testParam0.SignalboxId], testOutput.Signalbox);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsArgumentNullException_IfParameterHasStartTimePropertyThatIsNull()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.StartTime = null;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsFormatException_IfParameterHasStartTimePropertyThatHasTimePropertyThatIsNull()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.StartTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NullValue).Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsFormatException_IfParameterHasStartTimePropertyThatHasTimePropertyThatIsEmptyString()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.StartTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.EmptyValue).Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsFormatException_IfFirstParameterHasStartTimePropertyThatHasTimePropertyThatIsSolelyWhitespace()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.StartTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.WhitespaceValue).Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithStartTimePropertyWithCorrectValue_IfFirstParameterHasStartTimePropertyThatHasTimePropertyThatConsistsOfNumberInRangeWithNoColons()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            TimeOfDaySpecification startTimeSpecification = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursOnly);
            testParam0.StartTime = startTimeSpecification.Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.AreEqual(startTimeSpecification.Hours.Value, testOutput.StartTime.Hours24);
            Assert.AreEqual(0, testOutput.StartTime.Minutes);
            Assert.AreEqual(0, testOutput.StartTime.Seconds);
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithStartTimePropertyWithCorrectValue_IfFirstParameterHasStartTimePropertyThatHasTimePropertyThatConsistsOfTwoNumbersInRangeSeparatedByAColon()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            TimeOfDaySpecification startTimeSpecification = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursAndMinutes);
            testParam0.StartTime = startTimeSpecification.Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.AreEqual(startTimeSpecification.Hours.Value, testOutput.StartTime.Hours24);
            Assert.AreEqual(startTimeSpecification.Minutes.Value, testOutput.StartTime.Minutes);
            Assert.AreEqual(0, testOutput.StartTime.Seconds);
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithStartTimePropertyWithCorrectValue_IfFirstParameterHasStartTimePropertyThatHasTimePropertyThatConsistsOfThreeNumbersInRangeSeparatedByColons()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            TimeOfDaySpecification startTimeSpecification = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds);
            testParam0.StartTime = startTimeSpecification.Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.AreEqual(startTimeSpecification.Hours.Value, testOutput.StartTime.Hours24);
            Assert.AreEqual(startTimeSpecification.Minutes.Value, testOutput.StartTime.Minutes);
            Assert.AreEqual(startTimeSpecification.Seconds.Value, testOutput.StartTime.Seconds);
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithStartTimePropertyWithCorrectValue_IfFirstParameterHasStartTimePropertyThatHasTimePropertyThatConsistsOfMoreThanThreeNumbersInRangeSeparatedByColons()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            TimeOfDaySpecification startTimeSpecification = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSecondsAndMore);
            testParam0.StartTime = startTimeSpecification.Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.AreEqual(startTimeSpecification.Hours.Value, testOutput.StartTime.Hours24);
            Assert.AreEqual(startTimeSpecification.Minutes.Value, testOutput.StartTime.Minutes);
            Assert.AreEqual(startTimeSpecification.Seconds.Value, testOutput.StartTime.Seconds);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsFormatException_IfFirstParameterHasStartTimePropertyThatHasTimePropertyThatConsistsOfNonNumericString()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.StartTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NonNumericValue).Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsArgumentNullException_IfParameterHasFinishTimePropertyThatIsNull()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.FinishTime = null;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsFormatException_IfParameterHasFinishTimePropertyThatHasTimePropertyThatIsNull()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.FinishTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NullValue).Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsFormatException_IfParameterHasFinishTimePropertyThatHasTimePropertyThatIsEmptyString()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.FinishTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.EmptyValue).Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsFormatException_IfFirstParameterHasFinishTimePropertyThatHasTimePropertyThatIsSolelyWhitespace()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.FinishTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.WhitespaceValue).Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithEndTimePropertyWithCorrectValue_IfFirstParameterHasFinishTimePropertyThatHasTimePropertyThatConsistsOfNumberInRangeWithNoColons()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            TimeOfDaySpecification finishTimeSpecification = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursOnly);
            testParam0.FinishTime = finishTimeSpecification.Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.AreEqual(finishTimeSpecification.Hours.Value, testOutput.EndTime.Hours24);
            Assert.AreEqual(0, testOutput.EndTime.Minutes);
            Assert.AreEqual(0, testOutput.EndTime.Seconds);
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithEndTimePropertyWithCorrectValue_IfFirstParameterHasFInishTimePropertyThatHasTimePropertyThatConsistsOfTwoNumbersInRangeSeparatedByAColon()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            TimeOfDaySpecification finishTimeSpecification = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursAndMinutes);
            testParam0.FinishTime = finishTimeSpecification.Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.AreEqual(finishTimeSpecification.Hours.Value, testOutput.EndTime.Hours24);
            Assert.AreEqual(finishTimeSpecification.Minutes.Value, testOutput.EndTime.Minutes);
            Assert.AreEqual(0, testOutput.EndTime.Seconds);
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithEndTimePropertyWithCorrectValue_IfFirstParameterHasFinishTimePropertyThatHasTimePropertyThatConsistsOfThreeNumbersInRangeSeparatedByColons()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            TimeOfDaySpecification finishTimeSpecification = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds);
            testParam0.FinishTime = finishTimeSpecification.Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.AreEqual(finishTimeSpecification.Hours.Value, testOutput.EndTime.Hours24);
            Assert.AreEqual(finishTimeSpecification.Minutes.Value, testOutput.EndTime.Minutes);
            Assert.AreEqual(finishTimeSpecification.Seconds.Value, testOutput.EndTime.Seconds);
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithEndTimePropertyWithCorrectValue_IfFirstParameterHasFinishTimePropertyThatHasTimePropertyThatConsistsOfMoreThanThreeNumbersInRangeSeparatedByColons()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            TimeOfDaySpecification finishTimeSpecification = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSecondsAndMore);
            testParam0.FinishTime = finishTimeSpecification.Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.AreEqual(finishTimeSpecification.Hours.Value, testOutput.EndTime.Hours24);
            Assert.AreEqual(finishTimeSpecification.Minutes.Value, testOutput.EndTime.Minutes);
            Assert.AreEqual(finishTimeSpecification.Seconds.Value, testOutput.EndTime.Seconds);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsFormatException_IfFirstParameterHasFinishTimePropertyThatHasTimePropertyThatConsistsOfNonNumericString()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.FinishTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NonNumericValue).Model;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            _ = testParam0.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithTokenBalanceWarningPropertyFalse_IfFirstParameterHasTokenBalanceWarningPropertyThatIsNull()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.TokenBalanceWarning = null;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.IsFalse(testOutput.TokenBalanceWarning);
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithTokenBalanceWarningPropertyFalse_IfFirstParameterHasTokenBalanceWarningPropertyThatIsFalse()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.TokenBalanceWarning = false;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.IsFalse(testOutput.TokenBalanceWarning);
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ReturnsObjectWithTokenBalanceWarningPropertyFalse_IfFirstParameterHasTokenBalanceWarningPropertyThatIsTrue()
        {
            SignalboxHoursModel testParam0 = GetTestObject();
            testParam0.TokenBalanceWarning = true;
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItem(testParam0.SignalboxId);

            SignalboxHours testOutput = testParam0.ToSignalboxHours(testParam1);

            Assert.IsTrue(testOutput.TokenBalanceWarning);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
