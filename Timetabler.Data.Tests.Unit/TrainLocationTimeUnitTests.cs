using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Display;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class TrainLocationTimeUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static Location GetLocation()
        {
            return new Location
            {
                Id = _rnd.NextString("0123456789abcdef", 8),
            };
        }

        private static TimeDisplayFormattingStrings GetTimeDisplayFormattingStrings()
        {
            return new TimeDisplayFormattingStrings
            {
                Complete = "h{0}mmf",
                Hours = "h",
                Minutes = "mmf",
                TimeWithoutFootnotes = "h mmf",
            };
        }

#pragma warning disable CA5394 // Do not use insecure randomness

        private static TrainLocationTime GetTestObject()
        {
            return new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                DepartureTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_IsNull_IfArrivalTimePropertyIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = null;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_IsNull_IfFormattingStringsPropertyIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.FormattingStrings = null;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_IsNull_IfLocationPropertyIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.Location = null;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_HasCorrectLocationIdProperty_IfNotNull()
        {
            Location testLocation = GetLocation();
            TrainLocationTime testObject = GetTestObject();
            testObject.Location = testLocation;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testLocation.Id, testOutput.LocationId);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_HasCorrectLocationKeyProperty_IfNotNull()
        {
            Location testLocation = GetLocation();
            TrainLocationTime testObject = GetTestObject();
            testObject.Location = testLocation;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testLocation.Id + LocationIdSuffixes.Arrival, testOutput.LocationKey);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_HasCorrectEntryTypeProperty_IfNotNull()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(TrainLocationTimeEntryType.Time, testOutput.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_HasCorrectIsPassingTimeProperty_IfNotNull()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testObject.Pass, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_HasCorrectActualTimeProperty_IfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = testTime;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.Time, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_HasCorrectDisplayedTextProperty_IfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = testTime;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(string.Format(CultureInfo.CurrentCulture, testTime.Time.ToString(testObject.FormattingStrings.Complete, CultureInfo.CurrentCulture), 
                testTime.FootnoteSymbols), testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_HasCorrectDisplayedTextHoursProperty_IfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = testTime;
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Hours, CultureInfo.CurrentCulture), testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_HasCorrectDisplayedTextMinutesProperty_IfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = testTime;
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Minutes, CultureInfo.CurrentCulture), testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ArrivalTimeModelProperty_HasCorrectDisplayedTextFootnoteProperty_IfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = testTime;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.FootnoteSymbols, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_IsNull_IfDepartureTimePropertyIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = null;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_IsNull_IfFormattingStringsPropertyIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.FormattingStrings = null;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_IsNull_IfLocationPropertyIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.Location = null;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_HasCorrectLocationIdProperty_IfNotNull()
        {
            Location testLocation = GetLocation();
            TrainLocationTime testObject = GetTestObject();
            testObject.Location = testLocation;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testLocation.Id, testOutput.LocationId);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_HasCorrectLocationKeyProperty_IfNotNull()
        {
            Location testLocation = GetLocation();
            TrainLocationTime testObject = GetTestObject();
            testObject.Location = testLocation;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testLocation.Id + LocationIdSuffixes.Departure, testOutput.LocationKey);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_HasCorrectEntryTypeProperty_IfNotNull()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(TrainLocationTimeEntryType.Time, testOutput.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_HasCorrectIsPassingTimeProperty_IfNotNull()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testObject.Pass, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_HasCorrectActualTimeProperty_IfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = testTime;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.Time, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_HasCorrectDisplayedTextProperty_IfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = testTime;
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(string.Format(CultureInfo.CurrentCulture, testTime.Time.ToString(formattingStrings.Complete, CultureInfo.CurrentCulture), testTime.FootnoteSymbols), 
                testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_HasCorrectDisplayedTextHoursProperty_IfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = testTime;
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Hours, CultureInfo.CurrentCulture), testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_HasCorrectDisplayedTextMinutesProperty_IfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = testTime;
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Minutes, CultureInfo.CurrentCulture), testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeClass_DepartureTimeModelProperty_HasCorrectDisplayedTextFootnoteProperty_IfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = testTime;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.FootnoteSymbols, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesArrivalTimeModelPropertyIsPassingTimeProperty()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.Pass = !testObject.Pass;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testObject.Pass, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesArrivalTimeModelPropertyActualTimeProperty()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.ArrivalTime = testTime;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime.Time, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesArrivalTimeModelPropertyDisplayedTextProperty()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.ArrivalTime = testTime;
            testObject.RefreshTimeModels();

            Assert.AreEqual(string.Format(CultureInfo.CurrentCulture, testTime.Time.ToString(formattingStrings.Complete, CultureInfo.CurrentCulture), 
                testTime.FootnoteSymbols), testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesArrivalTimeModelPropertyDisplayedTextHoursProperty()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.ArrivalTime = testTime;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Hours, CultureInfo.CurrentCulture), testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesArrivalTimeModelPropertyDisplayedTextMinutesProperty()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.ArrivalTime = testTime;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Minutes, CultureInfo.CurrentCulture), testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesArrivalTimeModelPropertyDisplayedTextFootnoteProperty()
        {
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.ArrivalTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.FootnoteSymbols, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesDepartureTimeModelPropertyIsPassingTimeProperty()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.Pass = !testObject.Pass;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testObject.Pass, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesDepartureTimeModelPropertyActualTimeProperty()
        {
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.DepartureTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.Time, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesDepartureTimeModelPropertyDisplayedTextProperty()
        {
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.DepartureTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(string.Format(CultureInfo.CurrentCulture, testTime1.Time.ToString(formattingStrings.Complete, CultureInfo.CurrentCulture), testTime1.FootnoteSymbols), 
                testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesDepartureTimeModelPropertyDisplayedTextHoursProperty()
        {
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.DepartureTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.Time.ToString(formattingStrings.Hours, CultureInfo.CurrentCulture), testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesDepartureTimeModelPropertyDisplayedTextMinutesProperty()
        {
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            TrainLocationTime testObject = GetTestObject();
            testObject.FormattingStrings = formattingStrings;

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.DepartureTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.Time.ToString(formattingStrings.Minutes, CultureInfo.CurrentCulture), testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeClass_RefreshTimeModelsMethod_UpdatesDepartureTimeModelPropertyDisplayedTextFootnoteProperty()
        {
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.DepartureTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.FootnoteSymbols, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeClass_CopyMethod_ReturnsDifferentObject()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_CopyMethod_ReturnsObjectWithEquivalentArrivalTime()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ArrivalTime.Time, testOutput.ArrivalTime.Time);
            Assert.AreEqual(testObject.ArrivalTime.FootnoteSymbols, testOutput.ArrivalTime.FootnoteSymbols);
        }

        [TestMethod]
        public void TrainLocationTimeClass_CopyMethod_ReturnsObjectWithEquivalentDepartureTime()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DepartureTime.Time, testOutput.DepartureTime.Time);
            Assert.AreEqual(testObject.DepartureTime.FootnoteSymbols, testOutput.DepartureTime.FootnoteSymbols);
        }

        [TestMethod]
        public void TrainLocationTimeClass_CopyMethod_ReturnsObjectWithSameLocation()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreSame(testObject.Location, testOutput.Location);
        }

        [TestMethod]
        public void TrainLocationTimeClass_CopyMethod_ReturnsObjectWithSameFormattingStrings()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreSame(testObject.FormattingStrings, testOutput.FormattingStrings);
        }

        [TestMethod]
        public void TrainLocationTimeClass_CopyMethod_ReturnsObjectWithSamePassProperty()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Pass, testOutput.Pass);
        }

        [TestMethod]
        public void TrainLocationTimeClass_CopyMethod_ReturnsObjectWithSamePathProperty()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Path, testOutput.Path);
        }

        [TestMethod]
        public void TrainLocationTimeClass_CopyMethod_ReturnsObjectWithSamePlatformProperty()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Platform, testOutput.Platform);
        }

        [TestMethod]
        public void TrainLocationTimeClass_CopyMethod_ReturnsObjectWithSameLineProperty()
        {
            TrainLocationTime testObject = GetTestObject();

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Line, testOutput.Line);
        }

        [TestMethod]
        public void TrainLocationTimeClass_OffsetTimesMethod_ReturnsObjectWithSameArrivalTimeProperty_IfArrivalTimeIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = null;
            int offsetAmount = _rnd.Next(320) - 160;

            testObject.OffsetTimes(offsetAmount);

            Assert.IsNull(testObject.ArrivalTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_OffsetTimesMethod_ReturnsObjectWithSameArrivalTimeProperty_IfArrivalTimePropertyTimePropertyIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime.Time = null;
            int offsetAmount = _rnd.Next(320) - 160;

            testObject.OffsetTimes(offsetAmount);

            Assert.IsNull(testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClass_OffsetTimesMethod_ReturnsObjectWithSameDepartureTimeProperty_IfDepartureTimeIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = null;
            int offsetAmount = _rnd.Next(320) - 160;

            testObject.OffsetTimes(offsetAmount);

            Assert.IsNull(testObject.DepartureTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_OffsetTimesMethod_ReturnsObjectWithSameDepartureTimeProperty_IfDepartureTimePropertyTimePropertyIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime.Time = null;
            int offsetAmount = _rnd.Next(320) - 160;

            testObject.OffsetTimes(offsetAmount);

            Assert.IsNull(testObject.DepartureTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClass_OffsetTimesMethod_DoesNotModifyTimePropertyOfArrivalTimeProperty_IfOffsetIsZero()
        {
            TrainLocationTime testObject = GetTestObject();
            TimeOfDay originalArrivalTime = testObject.ArrivalTime.Time.Copy();

            testObject.OffsetTimes(0);

            Assert.AreEqual(originalArrivalTime, testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClass_OffsetTimesMethod_DoesNotModifyTimePropertyOfDepartureTimeProperty_IfOffsetIsZero()
        {
            TrainLocationTime testObject = GetTestObject();
            TimeOfDay originalDepartureTime = testObject.DepartureTime.Time.Copy();

            testObject.OffsetTimes(0);

            Assert.AreEqual(originalDepartureTime, testObject.DepartureTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClass_OffsetTimesMethod_ModifiesArrivalTimeCorrectly_IfOffsetIsPositive()
        {
            int offset = _rnd.Next(23 * 60);
            TimeOfDay timeLimit = TimeOfDay.FromTimeSpan(new TimeOfDay(86399) - new TimeSpan(0, offset, 0));
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = TrainTimeHelpers.GetTrainTimeBefore(timeLimit);
            TimeOfDay originalArrivalTime = testObject.ArrivalTime.Time.Copy();

            testObject.OffsetTimes(offset);

            Assert.AreEqual(originalArrivalTime + new TimeSpan(0, offset, 0), testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClass_OffsetTimesMethod_ModifiesDepartureTimeCorrectly_IfOffsetIsPositive()
        {
            int offset = _rnd.Next(23 * 60);
            TimeOfDay timeLimit = TimeOfDay.FromTimeSpan(new TimeOfDay(86399) - new TimeSpan(0, offset, 0));
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = TrainTimeHelpers.GetTrainTimeBefore(timeLimit);
            TimeOfDay originalDepartureTime = testObject.DepartureTime.Time.Copy();

            testObject.OffsetTimes(offset);

            Assert.AreEqual(originalDepartureTime + new TimeSpan(0, offset, 0), testObject.DepartureTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClass_OffsetTimesMethod_ModifiesArrivalTimeCorrectly_IfOffsetIsNegative()
        {
            int offset = -_rnd.Next(23 * 60);
            TimeOfDay timeLimit = TimeOfDay.FromTimeSpan(new TimeSpan(0, -offset, 0));
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = TrainTimeHelpers.GetTrainTimeAfter(timeLimit);
            TimeOfDay originalArrivalTime = testObject.ArrivalTime.Time.Copy();

            testObject.OffsetTimes(offset);

            Assert.AreEqual(TimeOfDay.FromTimeSpan(originalArrivalTime - new TimeSpan(0, -offset, 0)), testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClass_OffsetTimesMethod_ModifiesDepartureTimeCorrectly_IfOffsetIsNegative()
        {
            int offset = -_rnd.Next(23 * 60);
            TimeOfDay timeLimit = TimeOfDay.FromTimeSpan(new TimeSpan(0, -offset, 0));
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = TrainTimeHelpers.GetTrainTimeAfter(timeLimit);
            TimeOfDay originalDepartureTime = testObject.DepartureTime.Time.Copy();

            testObject.OffsetTimes(offset);

            Assert.AreEqual(TimeOfDay.FromTimeSpan(originalDepartureTime - new TimeSpan(0, -offset, 0)), testObject.DepartureTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClass_LastTimeProperty_IsNull_IfBothArrivalTimeAndDepartureTimePropertiesAreNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = null;
            testObject.DepartureTime = null;

            TrainTime testOutput = testObject.LastTime;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_LastTimeProperty_EqualsArrivalTime_IfDepartureTimeIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = null;

            TrainTime testOutput = testObject.LastTime;

            Assert.AreEqual(testObject.ArrivalTime, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_LastTimeProperty_EqualsDepartureTime_IfArrivalTimeIsNull()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = null;

            TrainTime testOutput = testObject.LastTime;

            Assert.AreEqual(testObject.DepartureTime, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_LastTimeProperty_EqualsArrivalTime_IfArrivalTimeIsAfterDepartureTime()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = TrainTimeHelpers.GetTrainTimeBefore(testObject.ArrivalTime.Time);

            TrainTime testOutput = testObject.LastTime;

            Assert.AreEqual(testObject.ArrivalTime, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_LastTimeProperty_EqualsDepartureTime_IfArrivalTimeIsBeforeDepartureTime()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = TrainTimeHelpers.GetTrainTimeAfter(testObject.ArrivalTime.Time);

            TrainTime testOutput = testObject.LastTime;

            Assert.AreEqual(testObject.DepartureTime, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_LastTimeProperty_EqualsDepartureTime_IfArrivalTimeAndDepartureTimeAreAtSameTime()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = TrainTimeHelpers.GetTrainTimeAt(testObject.ArrivalTime.Time);

            TrainTime testOutput = testObject.LastTime;

            Assert.AreEqual(testObject.DepartureTime, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_SwapsArrivalTimeAndDepartureTimeFootnotes_IfBothArePopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = GetTestObject();
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, true);

            Assert.AreEqual(originalArrivalTime.Footnotes.Count, testObject.DepartureTime.Footnotes.Count);
            for (int i = 0; i < originalArrivalTime.Footnotes.Count; ++i)
            {
                Assert.AreSame(originalArrivalTime.Footnotes[i], testObject.DepartureTime.Footnotes[i]);
            }
            Assert.AreEqual(originalDepartureTime.Footnotes.Count, testObject.ArrivalTime.Footnotes.Count);
            for (int i = 0; i < originalDepartureTime.Footnotes.Count; ++i)
            {
                Assert.AreSame(originalDepartureTime.Footnotes[i], testObject.ArrivalTime.Footnotes[i]);
            }
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_ModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayWhilstSwapping_IfBothArePopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = GetTestObject();
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, true);

            Assert.AreEqual(originalArrivalTime.Time.CopyAndReflect(testParam0), testObject.DepartureTime.Time);
            Assert.AreEqual(originalDepartureTime.Time.CopyAndReflect(testParam0), testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_SwapsArrivalTimeAndDepartureTimeFootnotes_IfBothArePopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = GetTestObject();
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, false);

            Assert.AreEqual(originalArrivalTime.Footnotes.Count, testObject.DepartureTime.Footnotes.Count);
            for (int i = 0; i < originalArrivalTime.Footnotes.Count; ++i)
            {
                Assert.AreSame(originalArrivalTime.Footnotes[i], testObject.DepartureTime.Footnotes[i]);
            }
            Assert.AreEqual(originalDepartureTime.Footnotes.Count, testObject.ArrivalTime.Footnotes.Count);
            for (int i = 0; i < originalDepartureTime.Footnotes.Count; ++i)
            {
                Assert.AreSame(originalDepartureTime.Footnotes[i], testObject.ArrivalTime.Footnotes[i]);
            }
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_ModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayWhilstSwapping_IfBothArePopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = GetTestObject();
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, false);

            Assert.AreEqual(originalArrivalTime.Time.CopyAndReflect(testParam0), testObject.DepartureTime.Time);
            Assert.AreEqual(originalDepartureTime.Time.CopyAndReflect(testParam0), testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_SwapsArrivalTimeAndDepartureTimeFootnotes_IfArrivalTimeOnlyIsPopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = null;
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, true);

            Assert.AreEqual(originalArrivalTime.Footnotes.Count, testObject.DepartureTime.Footnotes.Count);
            for (int i = 0; i < originalArrivalTime.Footnotes.Count; ++i)
            {
                Assert.AreSame(originalArrivalTime.Footnotes[i], testObject.DepartureTime.Footnotes[i]);
            }
            Assert.IsNull(testObject.ArrivalTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_ModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayWhilstSwapping_IfArrivalTimeOnlyPopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = null;
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, true);

            Assert.AreEqual(originalArrivalTime.Time.CopyAndReflect(testParam0), testObject.DepartureTime.Time);
            Assert.IsNull(testObject.ArrivalTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_SwapsArrivalTimeAndDepartureTimeFootnotes_IfArrivalTimeOnlyIsPopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = null;
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, false);

            Assert.AreEqual(originalArrivalTime.Footnotes.Count, testObject.DepartureTime.Footnotes.Count);
            for (int i = 0; i < originalArrivalTime.Footnotes.Count; ++i)
            {
                Assert.AreSame(originalArrivalTime.Footnotes[i], testObject.DepartureTime.Footnotes[i]);
            }
            Assert.IsNull(testObject.ArrivalTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_ModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayWhilstSwapping_IfArrivalTimeOnlyPopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.DepartureTime = null;
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, false);

            Assert.AreEqual(originalArrivalTime.Time.CopyAndReflect(testParam0), testObject.DepartureTime.Time);
            Assert.IsNull(testObject.ArrivalTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_SwapsArrivalTimeAndDepartureTimeFootnotes_IfDepartureTimeOnlyIsPopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = null;
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, true);

            Assert.AreEqual(originalDepartureTime.Footnotes.Count, testObject.ArrivalTime.Footnotes.Count);
            for (int i = 0; i < originalDepartureTime.Footnotes.Count; ++i)
            {
                Assert.AreSame(originalDepartureTime.Footnotes[i], testObject.ArrivalTime.Footnotes[i]);
            }
            Assert.IsNull(testObject.DepartureTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_ModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayWhilstSwapping_IfDepartureTimeOnlyPopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = null;
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, true);

            Assert.AreEqual(originalDepartureTime.Time.CopyAndReflect(testParam0), testObject.ArrivalTime.Time);
            Assert.IsNull(testObject.DepartureTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_DoesNotSwapArrivalTimeAndDepartureTimeFootnotes_IfDepartureTimeOnlyIsPopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = null;
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, false);

            Assert.AreEqual(originalDepartureTime.Footnotes.Count, testObject.DepartureTime.Footnotes.Count);
            for (int i = 0; i < originalDepartureTime.Footnotes.Count; ++i)
            {
                Assert.AreSame(originalDepartureTime.Footnotes[i], testObject.DepartureTime.Footnotes[i]);
            }
            Assert.IsNull(testObject.ArrivalTime);
        }

        [TestMethod]
        public void TrainLocationTimeClass_ReflectMethod_ModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayButDoesNotSwap_IfDepartureTimeOnlyPopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = GetTestObject();
            testObject.ArrivalTime = null;
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, false);

            Assert.AreEqual(originalDepartureTime.Time.CopyAndReflect(testParam0), testObject.DepartureTime.Time);
            Assert.IsNull(testObject.ArrivalTime);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainLocationTimeClass_ResolveLocationMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TrainLocationTime testObject = GetTestObject();

            testObject.ResolveLocation(null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainLocationTimeClass_ResolveLocationMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TrainLocationTime testObject = GetTestObject();

            try
            {
                testObject.ResolveLocation(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("map", ex.ParamName);
            }
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
