using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.CoreData;
using Timetabler.Data.Display;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class TrainLocationTimeUnitTests
    {
        private static Random _rnd = new Random();

        private Location GetLocation()
        {
            return new Location
            {
                Id = _rnd.NextString("0123456789abcdef", 8),
            };
        }

        private TimeDisplayFormattingStrings GetTimeDisplayFormattingStrings()
        {
            return new TimeDisplayFormattingStrings
            {
                Complete = "h{0}mmf",
                Hours = "h",
                Minutes = "mmf",
                TimeWithoutFootnotes = "h mmf",
            };
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyIsNullIfArrivalTimePropertyIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = null, FormattingStrings = GetTimeDisplayFormattingStrings(), Location = GetLocation(), Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyIsNullIfFormattingStringsPropertyIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = TrainTimeHelpers.GetTrainTime(), FormattingStrings = null, Location = GetLocation(), Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyIsNullIfLocationPropertyIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                FormattingStrings = new TimeDisplayFormattingStrings(),
                Location = null, Pass = _rnd.NextBoolean()
            };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectLocationIdPropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testLocation.Id, testOutput.LocationId);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectLocationKeyPropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testLocation.Id + LocationIdSuffixes.Arrival, testOutput.LocationKey);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectEntryTypePropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(TrainLocationTimeEntryType.Time, testOutput.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectIsPassingTimePropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testObject.Pass, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectActualTimePropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.Time, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectDisplayedTextPropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(string.Format(testTime.Time.ToString(formattingStrings.Complete), testTime.FootnoteSymbols), testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectDisplayedTextHoursPropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Hours), testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectDisplayedTextMinutesPropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Minutes), testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectDisplayedTextFootnotePropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.FootnoteSymbols, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyIsNullIfDepartureTimePropertyIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = null, FormattingStrings = GetTimeDisplayFormattingStrings(), Location = GetLocation(), Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyIsNullIfFormattingStringsPropertyIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = TrainTimeHelpers.GetTrainTime(), FormattingStrings = null, Location = GetLocation(), Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyIsNullIfLocationPropertyIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                DepartureTime = TrainTimeHelpers.GetTrainTime(),
                FormattingStrings = new TimeDisplayFormattingStrings(),
                Location = null,
                Pass = _rnd.NextBoolean()
            };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectLocationIdPropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testLocation.Id, testOutput.LocationId);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectLocationKeyPropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testLocation.Id + LocationIdSuffixes.Departure, testOutput.LocationKey);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectEntryTypePropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(TrainLocationTimeEntryType.Time, testOutput.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectIsPassingTimePropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testObject.Pass, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectActualTimePropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.Time, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectDisplayedTextPropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(string.Format(testTime.Time.ToString(formattingStrings.Complete), testTime.FootnoteSymbols), testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectDisplayedTextHoursPropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Hours), testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectDisplayedTextMinutesPropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Minutes), testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectDisplayedTextFootnotePropertyIfNotNull()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.FootnoteSymbols, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesArrivalTimeModelPropertyIsPassingTimeProperty()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.Pass = !testObject.Pass;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testObject.Pass, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesArrivalTimeModelPropertyActualTimeProperty()
        {
            TrainTime testTime0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime0, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.ArrivalTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.Time, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesArrivalTimeModelPropertyDisplayedTextProperty()
        {
            TrainTime testTime0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime0, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.ArrivalTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(string.Format(testTime1.Time.ToString(formattingStrings.Complete), testTime1.FootnoteSymbols), testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesArrivalTimeModelPropertyDisplayedTextHoursProperty()
        {
            TrainTime testTime0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime0, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.ArrivalTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.Time.ToString(formattingStrings.Hours), testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesArrivalTimeModelPropertyDisplayedTextMinutesProperty()
        {
            TrainTime testTime0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime0, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.ArrivalTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.Time.ToString(formattingStrings.Minutes), testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesArrivalTimeModelPropertyDisplayedTextFootnoteProperty()
        {
            TrainTime testTime0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime0, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;
            testObject.ArrivalTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.FootnoteSymbols, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesDepartureTimeModelPropertyIsPassingTimeProperty()
        {
            TrainTime testTime = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.Pass = !testObject.Pass;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testObject.Pass, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesDepartureTimeModelPropertyActualTimeProperty()
        {
            TrainTime testTime0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime0, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.DepartureTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.Time, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesDepartureTimeModelPropertyDisplayedTextProperty()
        {
            TrainTime testTime0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime0, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.DepartureTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(string.Format(testTime1.Time.ToString(formattingStrings.Complete), testTime1.FootnoteSymbols), testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesDepartureTimeModelPropertyDisplayedTextHoursProperty()
        {
            TrainTime testTime0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime0, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.DepartureTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.Time.ToString(formattingStrings.Hours), testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesDepartureTimeModelPropertyDisplayedTextMinutesProperty()
        {
            TrainTime testTime0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime0, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.DepartureTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.Time.ToString(formattingStrings.Minutes), testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesDepartureTimeModelPropertyDisplayedTextFootnoteProperty()
        {
            TrainTime testTime0 = TrainTimeHelpers.GetTrainTime();
            TrainTime testTime1 = TrainTimeHelpers.GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime0, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;
            testObject.DepartureTime = testTime1;
            testObject.RefreshTimeModels();

            Assert.AreEqual(testTime1.FootnoteSymbols, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeClassCopyMethodReturnsDifferentObject()
        {
            TrainLocationTime testObject = new TrainLocationTime
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

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassCopyMethodReturnsObjectWithEquivalentArrivalTime()
        {
            TrainLocationTime testObject = new TrainLocationTime
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

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ArrivalTime.Time, testOutput.ArrivalTime.Time);
            Assert.AreEqual(testObject.ArrivalTime.FootnoteSymbols, testOutput.ArrivalTime.FootnoteSymbols);
        }

        [TestMethod]
        public void TrainLocationTimeClassCopyMethodReturnsObjectWithEquivalentDepartureTime()
        {
            TrainLocationTime testObject = new TrainLocationTime
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

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DepartureTime.Time, testOutput.DepartureTime.Time);
            Assert.AreEqual(testObject.DepartureTime.FootnoteSymbols, testOutput.DepartureTime.FootnoteSymbols);
        }

        [TestMethod]
        public void TrainLocationTimeClassCopyMethodReturnsObjectWithSameLocation()
        {
            TrainLocationTime testObject = new TrainLocationTime
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

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreSame(testObject.Location, testOutput.Location);
        }

        [TestMethod]
        public void TrainLocationTimeClassCopyMethodReturnsObjectWithSameFormattingStrings()
        {
            TrainLocationTime testObject = new TrainLocationTime
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

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreSame(testObject.FormattingStrings, testOutput.FormattingStrings);
        }

        [TestMethod]
        public void TrainLocationTimeClassCopyMethodReturnsObjectWithSamePassProperty()
        {
            TrainLocationTime testObject = new TrainLocationTime
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

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Pass, testOutput.Pass);
        }

        [TestMethod]
        public void TrainLocationTimeClassCopyMethodReturnsObjectWithSamePathProperty()
        {
            TrainLocationTime testObject = new TrainLocationTime
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

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Path, testOutput.Path);
        }

        [TestMethod]
        public void TrainLocationTimeClassCopyMethodReturnsObjectWithSamePlatformProperty()
        {
            TrainLocationTime testObject = new TrainLocationTime
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

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Platform, testOutput.Platform);
        }

        [TestMethod]
        public void TrainLocationTimeClassCopyMethodReturnsObjectWithSameLineProperty()
        {
            TrainLocationTime testObject = new TrainLocationTime
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

            TrainLocationTime testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Line, testOutput.Line);
        }

        [TestMethod]
        public void TrainLocationTimeClassOffsetTimesMethodReturnsObjectWithSameArrivalTimePropertyIfArrivalTimeIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = null,
                DepartureTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            int offsetAmount = _rnd.Next(320) - 160;

            testObject.OffsetTimes(offsetAmount);

            Assert.IsNull(testObject.ArrivalTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassOffsetTimesMethodReturnsObjectWithSameArrivalTimePropertyIfArrivalTimePropertyTimePropertyIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime
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
            testObject.ArrivalTime.Time = null;
            int offsetAmount = _rnd.Next(320) - 160;

            testObject.OffsetTimes(offsetAmount);

            Assert.IsNull(testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClassOffsetTimesMethodReturnsObjectWithSameDepartureTimePropertyIfDepartureTimeIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                DepartureTime = null,
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            int offsetAmount = _rnd.Next(320) - 160;

            testObject.OffsetTimes(offsetAmount);

            Assert.IsNull(testObject.DepartureTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassOffsetTimesMethodReturnsObjectWithSameDepartureTimePropertyIfDepartureTimePropertyTimePropertyIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime
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
            testObject.DepartureTime.Time = null;
            int offsetAmount = _rnd.Next(320) - 160;

            testObject.OffsetTimes(offsetAmount);

            Assert.IsNull(testObject.DepartureTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClassOffsetTimesMethodDoesNotModifyTimePropertyOfArrivalTimePropertyIfOffsetIsZero()
        {
            TrainLocationTime testObject = new TrainLocationTime
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
            TimeOfDay originalArrivalTime = testObject.ArrivalTime.Time.Copy();

            testObject.OffsetTimes(0);

            Assert.AreEqual(originalArrivalTime, testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClassOffsetTimesMethodDoesNotModifyTimePropertyOfDepartureTimePropertyIfOffsetIsZero()
        {
            TrainLocationTime testObject = new TrainLocationTime
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
            TimeOfDay originalDepartureTime = testObject.DepartureTime.Time.Copy();

            testObject.OffsetTimes(0);

            Assert.AreEqual(originalDepartureTime, testObject.DepartureTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClassOffsetTimesMethodModifiesArrivalTimeCorrectlyIfOffsetIsPositive()
        {
            int offset = _rnd.Next(23 * 60);
            TimeOfDay timeLimit = TimeOfDay.FromTimeSpan(new TimeOfDay(86399) - new TimeSpan(0, offset, 0));
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTimeBefore(timeLimit),
                DepartureTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            TimeOfDay originalArrivalTime = testObject.ArrivalTime.Time.Copy();

            testObject.OffsetTimes(offset);

            Assert.AreEqual(originalArrivalTime + new TimeSpan(0, offset, 0), testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClassOffsetTimesMethodModifiesDepartureTimeCorrectlyIfOffsetIsPositive()
        {
            int offset = _rnd.Next(23 * 60);
            TimeOfDay timeLimit = TimeOfDay.FromTimeSpan(new TimeOfDay(86399) - new TimeSpan(0, offset, 0));
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                DepartureTime = TrainTimeHelpers.GetTrainTimeBefore(timeLimit),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            TimeOfDay originalDepartureTime = testObject.DepartureTime.Time.Copy();

            testObject.OffsetTimes(offset);

            Assert.AreEqual(originalDepartureTime + new TimeSpan(0, offset, 0), testObject.DepartureTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClassOffsetTimesMethodModifiesArrivalTimeCorrectlyIfOffsetIsNegative()
        {
            int offset = -_rnd.Next(23 * 60);
            TimeOfDay timeLimit = TimeOfDay.FromTimeSpan(new TimeSpan(0, -offset, 0));
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTimeAfter(timeLimit),
                DepartureTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            TimeOfDay originalArrivalTime = testObject.ArrivalTime.Time.Copy();

            testObject.OffsetTimes(offset);

            Assert.AreEqual(TimeOfDay.FromTimeSpan(originalArrivalTime - new TimeSpan(0, -offset, 0)), testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClassOffsetTimesMethodModifiesDepartureTimeCorrectlyIfOffsetIsNegative()
        {
            int offset = -_rnd.Next(23 * 60);
            TimeOfDay timeLimit = TimeOfDay.FromTimeSpan(new TimeSpan(0, -offset, 0));
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                DepartureTime = TrainTimeHelpers.GetTrainTimeAfter(timeLimit),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            TimeOfDay originalDepartureTime = testObject.DepartureTime.Time.Copy();

            testObject.OffsetTimes(offset);

            Assert.AreEqual(TimeOfDay.FromTimeSpan(originalDepartureTime - new TimeSpan(0, -offset, 0)), testObject.DepartureTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClassLastTimePropertyIsNullIfBothArrivalTimeAndDepartureTimePropertiesAreNull()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = null,
                DepartureTime = null,
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };

            TrainTime testOutput = testObject.LastTime;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassLastTimePropertyEqualsArrivalTimeIfDepartureTimeIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                DepartureTime = null,
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };

            TrainTime testOutput = testObject.LastTime;

            Assert.AreEqual(testObject.ArrivalTime, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassLastTimePropertyEqualsDepartureTimeIfArrivalTimeIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = null,
                DepartureTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };

            TrainTime testOutput = testObject.LastTime;

            Assert.AreEqual(testObject.DepartureTime, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassLastTimePropertyEqualsArrivalTimeIfArrivalTimeIsAfterDepartureTime()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            testObject.DepartureTime = TrainTimeHelpers.GetTrainTimeBefore(testObject.ArrivalTime.Time);

            TrainTime testOutput = testObject.LastTime;

            Assert.AreEqual(testObject.ArrivalTime, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassLastTimePropertyEqualsDepartureTimeIfArrivalTimeIsBeforeDepartureTime()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            testObject.DepartureTime = TrainTimeHelpers.GetTrainTimeAfter(testObject.ArrivalTime.Time);

            TrainTime testOutput = testObject.LastTime;

            Assert.AreEqual(testObject.DepartureTime, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassLastTimePropertyEqualsDepartureTimeIArrivalTimeAndDepartureTimeAreAtSameTime()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            testObject.DepartureTime = TrainTimeHelpers.GetTrainTimeAt(testObject.ArrivalTime.Time);

            TrainTime testOutput = testObject.LastTime;

            Assert.AreEqual(testObject.DepartureTime, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassReflectMethodSwapsArrivalTimeAndDepartureTimeFootnotesIfBothArePopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = new TrainLocationTime
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
        public void TrainLocationTimeClassReflectMethodModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayWhilstSwappingIfBothArePopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = new TrainLocationTime
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
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, true);

            Assert.AreEqual(originalArrivalTime.Time.CopyAndReflect(testParam0), testObject.DepartureTime.Time);
            Assert.AreEqual(originalDepartureTime.Time.CopyAndReflect(testParam0), testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClassReflectMethodSwapsArrivalTimeAndDepartureTimeFootnotesIfBothArePopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = new TrainLocationTime
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
        public void TrainLocationTimeClassReflectMethodModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayWhilstSwappingIfBothArePopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = new TrainLocationTime
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
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, false);

            Assert.AreEqual(originalArrivalTime.Time.CopyAndReflect(testParam0), testObject.DepartureTime.Time);
            Assert.AreEqual(originalDepartureTime.Time.CopyAndReflect(testParam0), testObject.ArrivalTime.Time);
        }

        [TestMethod]
        public void TrainLocationTimeClassReflectMethodSwapsArrivalTimeAndDepartureTimeFootnotesIfArrivalTimeOnlyIsPopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                DepartureTime = null,
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
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
        public void TrainLocationTimeClassReflectMethodModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayWhilstSwappingIfArrivalTimeOnlyPopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                DepartureTime = null,
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, true);

            Assert.AreEqual(originalArrivalTime.Time.CopyAndReflect(testParam0), testObject.DepartureTime.Time);
            Assert.IsNull(testObject.ArrivalTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassReflectMethodSwapsArrivalTimeAndDepartureTimeFootnotesIfArrivalTimeOnlyIsPopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                DepartureTime = null,
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
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
        public void TrainLocationTimeClassReflectMethodModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayWhilstSwappingIfArrivalTimeOnlyPopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = TrainTimeHelpers.GetTrainTime(),
                DepartureTime = null,
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            TrainTime originalArrivalTime = testObject.ArrivalTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, false);

            Assert.AreEqual(originalArrivalTime.Time.CopyAndReflect(testParam0), testObject.DepartureTime.Time);
            Assert.IsNull(testObject.ArrivalTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassReflectMethodSwapsArrivalTimeAndDepartureTimeFootnotesIfDepartureTimeOnlyIsPopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = null,
                DepartureTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
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
        public void TrainLocationTimeClassReflectMethodModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayWhilstSwappingIfDepartureTimeOnlyPopulatedAndSecondParameterIsTrue()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = null,
                DepartureTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, true);

            Assert.AreEqual(originalDepartureTime.Time.CopyAndReflect(testParam0), testObject.ArrivalTime.Time);
            Assert.IsNull(testObject.DepartureTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassReflectMethodDoesNotSwapArrivalTimeAndDepartureTimeFootnotesIfDepartureTimeOnlyIsPopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = null,
                DepartureTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
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
        public void TrainLocationTimeClassReflectMethodModifiesArrivalTimeAndDepartureTimeTimesInExpectedWayButDoesNotSwapIfDepartureTimeOnlyPopulatedAndSecondParameterIsFalse()
        {
            TrainLocationTime testObject = new TrainLocationTime
            {
                ArrivalTime = null,
                DepartureTime = TrainTimeHelpers.GetTrainTime(),
                Location = GetLocation(),
                Pass = _rnd.NextBoolean(),
                Path = _rnd.NextString(_rnd.Next(2)),
                Platform = _rnd.NextString(_rnd.Next(2)),
                Line = _rnd.NextString(_rnd.Next(2)),
                FormattingStrings = GetTimeDisplayFormattingStrings(),
            };
            TrainTime originalDepartureTime = testObject.DepartureTime;
            TimeOfDay testParam0 = _rnd.NextTimeOfDay();

            testObject.Reflect(testParam0, false);

            Assert.AreEqual(originalDepartureTime.Time.CopyAndReflect(testParam0), testObject.DepartureTime.Time);
            Assert.IsNull(testObject.ArrivalTime);
        }
    }
}
