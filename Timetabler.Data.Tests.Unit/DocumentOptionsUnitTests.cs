using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class DocumentOptionsUnitTests
    {
        private static Random _rnd = new Random();

        [TestMethod]
        public void DocumentOptionsClassFormattingStringsPropertyReturnsCorrectValuesIfClockTypeIsTwelveHourClock()
        {
            DocumentOptions testObject = new DocumentOptions { ClockType = ClockType.TwelveHourClock, DisplayTrainLabelsOnGraphs = _rnd.NextBoolean() };

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
            DocumentOptions testObject = new DocumentOptions { ClockType = ClockType.TwentyFourHourClock, DisplayTrainLabelsOnGraphs = _rnd.NextBoolean() };

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
            DocumentOptions testObject = new DocumentOptions { ClockType = ClockType.TwelveHourClock, DisplayTrainLabelsOnGraphs = _rnd.NextBoolean() };

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
            DocumentOptions testObject = new DocumentOptions { ClockType = ClockType.TwentyFourHourClock, DisplayTrainLabelsOnGraphs = _rnd.NextBoolean() };

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
            DocumentOptions testObject = new DocumentOptions
            {
                ClockType = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock,
                DisplayTrainLabelsOnGraphs = _rnd.NextBoolean()
            };

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreNotSame(testOutput, testObject);
        }

        [TestMethod]
        public void DocumentOptionsClassCopyMethodReturnsNewObjectWithCorrectClockTypeProperty()
        {
            DocumentOptions testObject = new DocumentOptions
            {
                ClockType = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock,
                DisplayTrainLabelsOnGraphs = _rnd.NextBoolean()
            };

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ClockType, testOutput.ClockType);
        }

        [TestMethod]
        public void DocumentOptionsClassCopyMethodReturnsNewObjectWithCorrectDisplayTrainLabelsOnGraphsProperty()
        {
            DocumentOptions testObject = new DocumentOptions
            {
                ClockType = _rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock,
                DisplayTrainLabelsOnGraphs = _rnd.NextBoolean()
            };

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayTrainLabelsOnGraphs, testOutput.DisplayTrainLabelsOnGraphs);
        }

        [TestMethod]
        public void DocumentOptionsClassCopyMethodReturnsNewObjectWithCorrectFormattingStringsPropertiesIfClockTypeIsTwelveHourClock()
        {
            DocumentOptions testObject = new DocumentOptions
            {
                ClockType = ClockType.TwelveHourClock,
                DisplayTrainLabelsOnGraphs = _rnd.NextBoolean()
            };

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
            DocumentOptions testObject = new DocumentOptions
            {
                ClockType = ClockType.TwentyFourHourClock,
                DisplayTrainLabelsOnGraphs = _rnd.NextBoolean()
            };

            TimeDisplayFormattingStrings testOutput = testObject.Copy().FormattingStrings;

            Assert.AreEqual("HH{0}mmf", testOutput.Complete);
            Assert.AreEqual("HH mmf", testOutput.TimeWithoutFootnotes);
            Assert.AreEqual("HH", testOutput.Hours);
            Assert.AreEqual("mmf", testOutput.Minutes);
            Assert.AreEqual("HH:mmf", testOutput.Tooltip);
        }
    }
}
