using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.CoreData;
using Timetabler.Data.Display;

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

        private TrainTime GetTrainTime()
        {
            TrainTime tt = new TrainTime
            {
                Time = _rnd.NextTimeOfDay(),
            };
            int footnoteCount = _rnd.Next(3);
            for (int i = 0; i < footnoteCount; ++i)
            {
                tt.Footnotes.Add(new Note { Symbol = _rnd.NextString(1) });
            }
            return tt;
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
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = GetTrainTime(), FormattingStrings = null, Location = GetLocation(), Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyIsNullIfLocationPropertyIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = GetTrainTime(), FormattingStrings = new TimeDisplayFormattingStrings(), Location = null, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectLocationIdPropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testLocation.Id, testOutput.LocationId);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectLocationKeyPropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testLocation.Id + LocationIdSuffixes.Arrival, testOutput.LocationKey);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectEntryTypePropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(TrainLocationTimeEntryType.Time, testOutput.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectIsPassingTimePropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testObject.Pass, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectActualTimePropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.Time, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectDisplayedTextPropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(string.Format(testTime.Time.ToString(formattingStrings.Complete), testTime.FootnoteSymbols), testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectDisplayedTextHoursPropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Hours), testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectDisplayedTextMinutesPropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { ArrivalTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Minutes), testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeClassArrivalTimeModelPropertyHasCorrectDisplayedTextFootnotePropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
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
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = GetTrainTime(), FormattingStrings = null, Location = GetLocation(), Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyIsNullIfLocationPropertyIsNull()
        {
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = GetTrainTime(), FormattingStrings = new TimeDisplayFormattingStrings(), Location = null, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.ArrivalTimeModel;

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectLocationIdPropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testLocation.Id, testOutput.LocationId);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectLocationKeyPropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testLocation.Id + LocationIdSuffixes.Departure, testOutput.LocationKey);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectEntryTypePropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(TrainLocationTimeEntryType.Time, testOutput.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectIsPassingTimePropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testObject.Pass, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectActualTimePropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.Time, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectDisplayedTextPropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(string.Format(testTime.Time.ToString(formattingStrings.Complete), testTime.FootnoteSymbols), testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectDisplayedTextHoursPropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Hours), testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectDisplayedTextMinutesPropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.Time.ToString(formattingStrings.Minutes), testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeClassDepartureTimeModelPropertyHasCorrectDisplayedTextFootnotePropertyIfNotNull()
        {
            TrainTime testTime = GetTrainTime();
            TimeDisplayFormattingStrings formattingStrings = GetTimeDisplayFormattingStrings();
            Location testLocation = GetLocation();
            TrainLocationTime testObject = new TrainLocationTime { DepartureTime = testTime, FormattingStrings = formattingStrings, Location = testLocation, Pass = _rnd.NextBoolean() };

            TrainLocationTimeModel testOutput = testObject.DepartureTimeModel;

            Assert.AreEqual(testTime.FootnoteSymbols, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeClassRefreshTimeModelsMethodUpdatesArrivalTimeModelPropertyIsPassingTimeProperty()
        {
            TrainTime testTime = GetTrainTime();
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
            TrainTime testTime0 = GetTrainTime();
            TrainTime testTime1 = GetTrainTime();
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
            TrainTime testTime0 = GetTrainTime();
            TrainTime testTime1 = GetTrainTime();
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
            TrainTime testTime0 = GetTrainTime();
            TrainTime testTime1 = GetTrainTime();
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
            TrainTime testTime0 = GetTrainTime();
            TrainTime testTime1 = GetTrainTime();
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
            TrainTime testTime0 = GetTrainTime();
            TrainTime testTime1 = GetTrainTime();
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
            TrainTime testTime = GetTrainTime();
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
            TrainTime testTime0 = GetTrainTime();
            TrainTime testTime1 = GetTrainTime();
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
            TrainTime testTime0 = GetTrainTime();
            TrainTime testTime1 = GetTrainTime();
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
            TrainTime testTime0 = GetTrainTime();
            TrainTime testTime1 = GetTrainTime();
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
            TrainTime testTime0 = GetTrainTime();
            TrainTime testTime1 = GetTrainTime();
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
            TrainTime testTime0 = GetTrainTime();
            TrainTime testTime1 = GetTrainTime();
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
                ArrivalTime = GetTrainTime(),
                DepartureTime = GetTrainTime(),
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
                ArrivalTime = GetTrainTime(),
                DepartureTime = GetTrainTime(),
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
                ArrivalTime = GetTrainTime(),
                DepartureTime = GetTrainTime(),
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
                ArrivalTime = GetTrainTime(),
                DepartureTime = GetTrainTime(),
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
                ArrivalTime = GetTrainTime(),
                DepartureTime = GetTrainTime(),
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
                ArrivalTime = GetTrainTime(),
                DepartureTime = GetTrainTime(),
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
                ArrivalTime = GetTrainTime(),
                DepartureTime = GetTrainTime(),
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
                ArrivalTime = GetTrainTime(),
                DepartureTime = GetTrainTime(),
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
                ArrivalTime = GetTrainTime(),
                DepartureTime = GetTrainTime(),
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
    }
}
