using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class DocumentOptionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static DocumentOptions GetDocumentOptions()
        {
            return GetDocumentOptions(_rnd.NextBoolean() ? ClockType.TwelveHourClock : ClockType.TwentyFourHourClock);
        }

        private static DocumentOptions GetDocumentOptions(ClockType clockType)
        {
            return new DocumentOptions
            {
                ClockType = clockType,
                DisplayTrainLabelsOnGraphs = _rnd.NextBoolean(),
                GraphEditStyle = _rnd.NextBoolean() ? GraphEditStyle.Free : GraphEditStyle.PreserveSectionTimes,
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DocumentOptionsClass_Constructor_SetsGraphEditStylePropertyToPreserveSectionTimes()
        {
            DocumentOptions testObject = new DocumentOptions();

            Assert.AreEqual(GraphEditStyle.PreserveSectionTimes, testObject.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsClass_FormattingStringsProperty_ReturnsCorrectValues_IfClockTypeIsTwelveHourClock()
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
        public void DocumentOptionsClass_FormattingStringsProperty_ReturnsCorrectValues_IfClockTypeIsTwentyFourHourClock()
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
        public void DocumentOptionsClass_ClockTypeProperty_SetMethod_UpdatesPropertiesOfFormattingStringsObject_IfClockTypeIsSetToTwentyFourHourClock()
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
        public void DocumentOptionsClass_ClockTypeProperty_SetMethod_UpdatesPropertiesOfFormattingStringsObject_IfClockTypeIsSetToTwelverHourClock()
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
        public void DocumentOptionsClass_CopyMethod_ReturnsNewObject()
        {
            DocumentOptions testObject = GetDocumentOptions();

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreNotSame(testOutput, testObject);
        }

        [TestMethod]
        public void DocumentOptionsClass_CopyMethod_ReturnsNewObjectWithCorrectClockTypeProperty()
        {
            DocumentOptions testObject = GetDocumentOptions();

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ClockType, testOutput.ClockType);
        }

        [TestMethod]
        public void DocumentOptionsClass_CopyMethod_ReturnsNewObjectWithCorrectDisplayTrainLabelsOnGraphsProperty()
        {
            DocumentOptions testObject = GetDocumentOptions();

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayTrainLabelsOnGraphs, testOutput.DisplayTrainLabelsOnGraphs);
        }

        [TestMethod]
        public void DocumentOptionsClass_CopyMethod_ReturnsNewObjectWithCorrectFormattingStringsProperties_IfClockTypeIsTwelveHourClock()
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
        public void DocumentOptionsClass_CopyMethod_ReturnsNewObjectWithCorrectFormattingStringsProperties_IfClockTypeIsTwentyFourHourClock()
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
        public void DocumentOptionsClass_CopyMethod_ReturnsNewObjectWithCorrectGraphEditStyleProperty()
        {
            DocumentOptions testObject = GetDocumentOptions();

            DocumentOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.GraphEditStyle, testOutput.GraphEditStyle);
        }

        [TestMethod]
        public void DocumentOptionsClass_CopyToMethod_OverwritesGraphEditStyleProperty()
        {
            DocumentOptions testObject = GetDocumentOptions();
            DocumentOptions target = GetDocumentOptions();

            testObject.CopyTo(target);

            Assert.AreEqual(testObject.GraphEditStyle, target.GraphEditStyle);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
