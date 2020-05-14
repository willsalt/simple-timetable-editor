using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class TrainLocationTimeModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static TrainLocationTimeModel GetTestObject()
        {
            TrainLocationTimeModel testObject = new TrainLocationTimeModel
            {
                ActualTime = _rnd.NextTimeOfDay(),
                DisplayedTextFootnote = _rnd.NextString(_rnd.Next(3)),
                EntryType = _rnd.NextBoolean() ? TrainLocationTimeEntryType.Time : TrainLocationTimeEntryType.RoutingCode,
                LocationId = _rnd.NextString("0123456789abcdef", 8),
                LocationKey = _rnd.NextString("0123456789abcdef", 10),
                IsPassingTime = _rnd.NextBoolean(),
            };
            testObject.DisplayedTextHours = testObject.ActualTime.ToString("h", CultureInfo.CurrentCulture);
            testObject.DisplayedTextMinutes = testObject.ActualTime.ToString("mm", CultureInfo.CurrentCulture);
            testObject.DisplayedText = testObject.DisplayedTextHours + (testObject.DisplayedTextFootnote.Length == 0 ? testObject.DisplayedTextFootnote : " ") + testObject.DisplayedTextMinutes;
            return testObject;
        }

        private static TrainTime GetRandomTrainTime()
        {
            TrainTime tt = new TrainTime { Time = _rnd.NextTimeOfDay() };
            int footnoteCount = _rnd.Next(4);
            for (int i = 0; i < footnoteCount; ++i)
            {
                tt.Footnotes.Add(new Note { Symbol = _rnd.NextString(1) });
            }
            return tt;
        }

        private static TimeDisplayFormattingStrings GetRandomFormattingStrings()
        {
            if (_rnd.NextBoolean())
            {
                return new TimeDisplayFormattingStrings
                {
                    Complete = "h{0}mm",
                    Hours = "h",
                    Minutes = "mm",
                    TimeWithoutFootnotes = "h mm",
                };
            }
            return new TimeDisplayFormattingStrings
            {
                Complete = "HH{0}mm",
                Hours = "HH",
                Minutes = "mm",
                TimeWithoutFootnotes = "HH mm",
            };
        }

        [TestMethod]
        public void TrainLocationTimeModelClassCopyMethodReturnsNewObject()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassCopyMethodReturnsObjectWithActualTimePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ActualTime, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassCopyMethodReturnsObjectWithDisplayedTextPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayedText, testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassCopyMethodReturnsObjectWithDisplayedTextFootnotePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayedTextFootnote, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassCopyMethodReturnsObjectWithDisplayedTextHoursPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayedTextHours, testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassCopyMethodReturnsObjectWithDisplayedTextMinutesPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayedTextMinutes, testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassCopyMethodReturnsObjectWithEntryTypePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.EntryType, testOutput.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassCopyMethodReturnsObjectWithLocationKeyPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocationKey, testOutput.LocationKey);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassCopyMethodReturnsObjectWithLocationIdPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocationId, testOutput.LocationId);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassCopyMethodReturnsObjectWithIsPassingTimePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.IsPassingTime, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassILocationEntryCopyMethodReturnsNewObject()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassILocationEntryCopyMethodReturnsObjectWithActualTimePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.ActualTime, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassILocationEntryCopyMethodReturnsObjectWithDisplayedTextPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.DisplayedText, testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassILocationEntryCopyMethodReturnsObjectWithDisplayedTextFootnotePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.DisplayedTextFootnote, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassILocationEntryCopyMethodReturnsObjectWithDisplayedTextHoursPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.DisplayedTextHours, testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassILocationEntryCopyMethodReturnsObjectWithDisplayedTextMinutesPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.DisplayedTextMinutes, testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassILocationEntryCopyMethodReturnsObjectWithEntryTypePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.EntryType, testOutput.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassILocationEntryCopyMethodReturnsObjectWithLocationKeyPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.LocationKey, testOutput.LocationKey);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassILocationEntryCopyMethodReturnsObjectWithLocationIdPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.LocationId, testOutput.LocationId);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassILocationEntryCopyMethodReturnsObjectWithIsPassingTimePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.IsPassingTime, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassPopulateMethodDoesNotFailIfFirstParameterIsNull()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            testObject.Populate(null, GetRandomFormattingStrings());
        }

        [TestMethod]
        public void TrainLocationTimeModelClassPopulateMethodDoesNotFailIfFirstParameterTimePropertyIsNull()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = new TrainTime { Time = null };

            testObject.Populate(param0, GetRandomFormattingStrings());
        }

        [TestMethod]
        public void TrainLocationTimeModelClassPopulateMethodDoesNotFailIfSecondParameterIsNull()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();

            testObject.Populate(param0, null);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassPopulateMethodSetsActualTimePropertyIfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(param0.Time, testObject.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassPopulateMethodSetsEntryTypePropertyIfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(TrainLocationTimeEntryType.Time, testObject.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassPopulateMethodSetsDisplayedTextPropertyIfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(string.Format(CultureInfo.CurrentCulture, param0.Time.ToString(param1.Complete, CultureInfo.CurrentCulture), param0.FootnoteSymbols), testObject.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassPopulateMethodSetsDisplayedTextHoursPropertyIfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(param0.Time.ToString(param1.Hours, CultureInfo.CurrentCulture), testObject.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassPopulateMethodSetsDisplayedTextMinutesPropertyIfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(param0.Time.ToString(param1.Minutes, CultureInfo.CurrentCulture), testObject.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeModelClassPopulateMethodSetsDisplayedTextFootnotePropertyIfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(param0.FootnoteSymbols, testObject.DisplayedTextFootnote);
        }
    }
}
