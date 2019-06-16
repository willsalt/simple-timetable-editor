using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class DocumentOptionsUnitTests
    {
        private static Random _rnd = RandomProvider.Default;

        private DocumentOptions GetDocumentOptions()
        {
            return GetDocumentOptions(_rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock);
        }

        private DocumentOptions GetDocumentOptions(ClockType clockType)
        {
            return new DocumentOptions
            {
                ClockType = clockType,
                DisplayTrainLabelsOnGraphs = _rnd.NextBoolean(),
                GraphEditStyle = _rnd.NextBoolean() ? GraphEditStyle.Free : GraphEditStyle.PreserveSectionTimes,
            };
        }


        [TestMethod]
        public void DocumentOptionsClassFormattingStringsPropertyReturnsCorrectValuesIfClockTypeIsTwelveHourClock()
        {
            DocumentOptions testObject = GetDocumentOptions(ClockType.TwelveHourClock);

            TimeDisplayFormattingStrings testOutput = testObject.FormattingStrings;

            Assert.AreEqual("h{0}mmf", testOutput.Complete);
            Assert.AreEqual("h mmf", testOutput.TimeWithoutFootnotes);
            Assert.AreEqual("h", testOutput.Hours);
            Assert.AreEqual("mmf", testOutput.Minutes);
            Assert.AreEqual("h:mmftt", testOutput.Tooltip);
        }

        [TestMethod]
        public void DocumentOptionsClassFormattingStringsPropertyReturnsCorrectValuesIfClockTypeIsTwentyFourHourClock()
        {
            DocumentOptions testObject = GetDocumentOptions(ClockType.TwentyFourHourClock);

            TimeDisplayFormattingStrings testOutput = testObject.FormattingStrings;

            Assert.AreEqual("HH{0}mmf", testOutput.Complete);
            Assert.AreEqual("HH mmf", testOutput.TimeWithoutFootnotes);
            Assert.AreEqual("HH", testOutput.Hours);
            Assert.AreEqual("mmf", testOutput.Minutes);
            Assert.AreEqual("HH:mmf", testOutput.Tooltip);
        }

        [TestMethod]
        public void DocumentOptionsClassClockTypePropertySetMethodUpdatesPropertiesOfFormattingStringsObjectIfClockTypeIsSetToTwentyFourHourClock()
        {
            DocumentOptions testObject = GetDocumentOptions(ClockType.TwelveHourClock);

            TimeDisplayFormattingStrings testOutput = testObject.FormattingStrings;
            testObject.ClockType = ClockType.TwentyFourHourClock;

            Assert.AreEqual("HH{0}mmf", testOutput.Complete);
            Assert.AreEqual("HH mmf", testOutput.TimeWithoutFootnotes);
            Assert.AreEqual("HH", testOutput.Hours);
            Assert.AreEqual("mmf", testOutput.Minutes);
            Assert.AreEqual("HH:mmf", testOutput.Tooltip);
        }

        [TestMethod]
        public void DocumentOptionsClassClockTypePropertySetMethodUpdatesPropertiesOfFormattingStringsObjectIfClockTypeIsSetToTwelverHourClock()
        {
            DocumentOptions testObject = GetDocumentOptions(ClockType.TwentyFourHourClock);

            TimeDisplayFormattingStrings testOutput = testObject.FormattingStrings;
            testObject.ClockType = ClockType.TwelveHourClock;

            Assert.AreEqual("h{0}mmf", testOutput.Complete);
            Assert.AreEqual("h mmf", testOutput.TimeWithoutFootnotes);
            Assert.AreEqual("h", testOutput.Hours);
            Assert.AreEqual("mmf", testOutput.Minutes);
            Assert.AreEqual("h:mmftt", testOutput.Tooltip);
        }

        [TestMethod]
        public void DocumentOptionsClassCopyMethodReturnsNewObject()
        {
            DocumentOptions testObject = GetDocumentOptions();

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreNotSame(testOutput, testObject);
        }

        [TestMethod]
        public void DocumentOptionsClassCopyMethodReturnsNewObjectWithCorrectClockTypeProperty()
        {
            DocumentOptions testObject = GetDocumentOptions();

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ClockType, testOutput.ClockType);
        }

        [TestMethod]
        public void DocumentOptionsClassCopyMethodReturnsNewObjectWithCorrectDisplayTrainLabelsOnGraphsProperty()
        {
            DocumentOptions testObject = GetDocumentOptions();

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayTrainLabelsOnGraphs, testOutput.DisplayTrainLabelsOnGraphs);
        }

        [TestMethod]
        public void DocumentOptionsClassCopyMethodReturnsNewObjectWithCorrectFormattingStringsPropertiesIfClockTypeIsTwelveHourClock()
        {
            DocumentOptions testObject = GetDocumentOptions(ClockType.TwelveHourClock);

            TimeDisplayFormattingStrings testOutput = testObject.Copy().FormattingStrings;

            Assert.AreEqual("h{0}mmf", testOutput.Complete);
            Assert.AreEqual("h mmf", testOutput.TimeWithoutFootnotes);
            Assert.AreEqual("h", testOutput.Hours);
            Assert.AreEqual("mmf", testOutput.Minutes);
            Assert.AreEqual("h:mmftt", testOutput.Tooltip);
        }

        [TestMethod]
        public void DocumentOptionsClassCopyMethodReturnsNewObjectWithCorrectFormattingStringsPropertiesIfClockTypeIsTwentyFourHourClock()
        {
            DocumentOptions testObject = GetDocumentOptions(ClockType.TwentyFourHourClock);

            TimeDisplayFormattingStrings testOutput = testObject.Copy().FormattingStrings;

            Assert.AreEqual("HH{0}mmf", testOutput.Complete);
            Assert.AreEqual("HH mmf", testOutput.TimeWithoutFootnotes);
            Assert.AreEqual("HH", testOutput.Hours);
            Assert.AreEqual("mmf", testOutput.Minutes);
            Assert.AreEqual("HH:mmf", testOutput.Tooltip);
        }

        [TestMethod]
        public void DocumentOptionsClassCopyMethodReturnsNewObjectWithCorrectGraphEditStyleProperty()
        {
            DocumentOptions testObject = GetDocumentOptions();

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.GraphEditStyle, testOutput.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsClassCopyToMethodOverwritesGraphEditStyleProperty()
        {
            DocumentOptions testObject = GetDocumentOptions();
            DocumentOptions target = GetDocumentOptions();

            testObject.CopyTo(target);

            Assert.AreEqual(testObject.GraphEditStyle, target.GraphEditStyle);
        }
    }
}
