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

#pragma warning disable CA5394 // Do not use insecure randomness

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
            testObject.DisplayedText = testObject.DisplayedTextHours + (testObject.DisplayedTextFootnote.Length == 0 ? 
                testObject.DisplayedTextFootnote : 
                " ") + testObject.DisplayedTextMinutes;
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

#pragma warning restore CA5394 // Do not use insecure randomness

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

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainLocationTimeModelClass_CopyMethod_ReturnsNewObject()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_CopyMethod_ReturnsObjectWithActualTimePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ActualTime, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_CopyMethod_ReturnsObjectWithDisplayedTextPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayedText, testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_CopyMethod_ReturnsObjectWithDisplayedTextFootnotePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayedTextFootnote, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_CopyMethod_ReturnsObjectWithDisplayedTextHoursPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayedTextHours, testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_CopyMethod_ReturnsObjectWithDisplayedTextMinutesPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayedTextMinutes, testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_CopyMethod_ReturnsObjectWithEntryTypePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.EntryType, testOutput.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_CopyMethod_ReturnsObjectWithLocationKeyPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocationKey, testOutput.LocationKey);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_CopyMethod_ReturnsObjectWithLocationIdPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocationId, testOutput.LocationId);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_CopyMethod_ReturnsObjectWithIsPassingTimePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.IsPassingTime, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ILocationEntryCopyMethod_ReturnsNewObject()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ILocationEntryCopyMethod_ReturnsObjectWithActualTimePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.ActualTime, testOutput.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ILocationEntryCopyMethod_ReturnsObjectWithDisplayedTextPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.DisplayedText, testOutput.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ILocationEntryCopyMethod_ReturnsObjectWithDisplayedTextFootnotePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.DisplayedTextFootnote, testOutput.DisplayedTextFootnote);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ILocationEntryCopyMethod_ReturnsObjectWithDisplayedTextHoursPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.DisplayedTextHours, testOutput.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ILocationEntryCopyMethod_ReturnsObjectWithDisplayedTextMinutesPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.DisplayedTextMinutes, testOutput.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ILocationEntryCopyMethod_ReturnsObjectWithEntryTypePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.EntryType, testOutput.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ILocationEntryCopyMethod_ReturnsObjectWithLocationKeyPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.LocationKey, testOutput.LocationKey);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ILocationEntryCopyMethod_ReturnsObjectWithLocationIdPropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.LocationId, testOutput.LocationId);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_ILocationEntryCopyMethod_ReturnsObjectWithIsPassingTimePropertyWithSameValue()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            TrainLocationTimeModel testOutput = (testObject as ILocationEntry).Copy() as TrainLocationTimeModel;

            Assert.AreEqual(testObject.IsPassingTime, testOutput.IsPassingTime);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_PopulateMethod_DoesNotFail_IfFirstParameterIsNull()
        {
            TrainLocationTimeModel testObject = GetTestObject();

            testObject.Populate(null, GetRandomFormattingStrings());
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_PopulateMethod_DoesNotFail_IfFirstParameterTimePropertyIsNull()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = new TrainTime { Time = null };

            testObject.Populate(param0, GetRandomFormattingStrings());
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_PopulateMethod_DoesNotFail_IfSecondParameterIsNull()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();

            testObject.Populate(param0, null);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_PopulateMethod_SetsActualTimeProperty_IfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(param0.Time, testObject.ActualTime);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_PopulateMethod_SetsEntryTypeProperty_IfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(TrainLocationTimeEntryType.Time, testObject.EntryType);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_PopulateMethod_SetsDisplayedTextProperty_IfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(string.Format(CultureInfo.CurrentCulture, param0.Time.ToString(param1.Complete, CultureInfo.CurrentCulture), param0.FootnoteSymbols), testObject.DisplayedText);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_PopulateMethod_SetsDisplayedTextHoursProperty_IfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(param0.Time.ToString(param1.Hours, CultureInfo.CurrentCulture), testObject.DisplayedTextHours);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_PopulateMethod_SetsDisplayedTextMinutesProperty_IfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(param0.Time.ToString(param1.Minutes, CultureInfo.CurrentCulture), testObject.DisplayedTextMinutes);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_PopulateMethod_SetsDisplayedTextFootnoteProperty_IfParametersAreProvided()
        {
            TrainLocationTimeModel testObject = GetTestObject();
            TrainTime param0 = GetRandomTrainTime();
            TimeDisplayFormattingStrings param1 = GetRandomFormattingStrings();

            testObject.Populate(param0, param1);

            Assert.AreEqual(param0.FootnoteSymbols, testObject.DisplayedTextFootnote);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
