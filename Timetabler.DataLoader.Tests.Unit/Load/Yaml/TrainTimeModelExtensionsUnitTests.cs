using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.DataLoader.Tests.Unit.TestHelpers;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class TrainTimeModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static TrainTimeModel GetTestObject()
        {
            TimeOfDaySpecification timeSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds);
            TrainTimeModel model = new TrainTimeModel { At = timeSpec.Model };
            int noteCount = _rnd.Next(5);
            for (int i = 0; i < noteCount; ++i)
            {
                string noteId;
                do
                {
                    noteId = _rnd.NextHexString(8);
                } while (model.FootnoteIds.Contains(noteId));
                model.FootnoteIds.Add(noteId);
            }
            return model;
        }

        private static Dictionary<string, Note> GetNoteDictionaryWithContents(List<string> noteIds, bool andExtra = true)
        {
            Dictionary<string, Note> output = new Dictionary<string, Note>();
            foreach (string id in noteIds)
            {
                output.Add(id, new Note 
                { 
                    Id = id, 
                    AppliesToTimings = _rnd.NextBoolean(), 
                    AppliesToTrains = _rnd.NextBoolean(), 
                    DefinedInGlossary = _rnd.NextBoolean(), 
                    DefinedOnPages = _rnd.NextBoolean(), 
                    Definition = _rnd.NextString(_rnd.Next(50)), 
                    Symbol = _rnd.NextString(_rnd.Next(1, 2)) 
                });
            }
            if (andExtra)
            {
                int extraCount = _rnd.Next(20);
                List<string> extraNotes = new List<string>(extraCount);
                for (int i = 0; i < extraCount; ++i)
                {
                    string newId;
                    do
                    {
                        newId = _rnd.NextHexString(8);
                    } while (extraNotes.Contains(newId) || output.ContainsKey(newId));
                    extraNotes.Add(newId);
                }
                Dictionary<string, Note> extraOutput = GetNoteDictionaryWithContents(extraNotes, false);
                foreach (KeyValuePair<string, Note> item in extraOutput)
                {
                    output.Add(item.Key, item.Value);
                }
            }

            return output;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ThrowsNullReferenceException_IfFirstParameterIsNull()
        {
            TrainTimeModel testParam0 = null;
            Dictionary<string, Note> testParam1 = new Dictionary<string, Note>();

            _ = testParam0.ToTrainTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ReturnsObjectWithTimePropertyEqualToNull_IfFirstParameterHasAtPropertyThatIsNull()
        {
            TrainTimeModel testParam0 = GetTestObject();
            testParam0.At = null;
            Dictionary<string, Note> testParam1 = GetNoteDictionaryWithContents(testParam0.FootnoteIds);

            TrainTime testOutput = testParam0.ToTrainTime(testParam1);

            Assert.IsNull(testOutput.Time);
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ThrowsFormatException_IfFirstParameterHasAtPropertyWithTimePropertyThatIsNull()
        {
            TrainTimeModel testParam0 = GetTestObject();
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NullValue);
            testParam0.At = testParamSpec.Model;
            Dictionary<string, Note> testParam1 = new Dictionary<string, Note>();

            _ = testParam0.ToTrainTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ThrowsFormatException_IfFirstParameterHasAtPropertyWithTimePropertyThatIsEmptyString()
        {
            TrainTimeModel testParam0 = GetTestObject();
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.EmptyValue);
            testParam0.At = testParamSpec.Model;
            Dictionary<string, Note> testParam1 = new Dictionary<string, Note>();

            _ = testParam0.ToTrainTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ThrowsFormatException_IfFirstParameterHasAtPropertyWithTimePropertyThatIsSolelyWhitespace()
        {
            TrainTimeModel testParam0 = GetTestObject();
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.WhitespaceValue);
            testParam0.At = testParamSpec.Model;
            Dictionary<string, Note> testParam1 = new Dictionary<string, Note>();

            _ = testParam0.ToTrainTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ThrowsFormatException_IfFirstParameterHasAtPropertyWithTimePropertyThatIsNonNumericString()
        {
            TrainTimeModel testParam0 = GetTestObject();
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NonNumericValue);
            testParam0.At = testParamSpec.Model;
            Dictionary<string, Note> testParam1 = new Dictionary<string, Note>();

            _ = testParam0.ToTrainTime(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ReturnsObjectWithCorrectTimeProperty_IfFirstParameterHasAtPropertyWithTimePropertyThatIsANumberInRange()
        {
            TrainTimeModel testParam0 = GetTestObject();
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursOnly);
            testParam0.At = testParamSpec.Model;
            Dictionary<string, Note> testParam1 = GetNoteDictionaryWithContents(testParam0.FootnoteIds);

            TrainTime testOutput = testParam0.ToTrainTime(testParam1);

            Assert.AreEqual(testParamSpec.Hours.Value, testOutput.Time.Hours24);
            Assert.AreEqual(0, testOutput.Time.Minutes);
            Assert.AreEqual(0, testOutput.Time.Seconds);
        }

        [TestMethod]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ReturnsObjectWithCorrectTimeProperty_IfFirstParameterHasAtPropertyWithTimePropertyThatIsTwoNumbersInRangeSeparatedByAColon()
        {
            TrainTimeModel testParam0 = GetTestObject();
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursAndMinutes);
            testParam0.At = testParamSpec.Model;
            Dictionary<string, Note> testParam1 = GetNoteDictionaryWithContents(testParam0.FootnoteIds);

            TrainTime testOutput = testParam0.ToTrainTime(testParam1);

            Assert.AreEqual(testParamSpec.Hours.Value, testOutput.Time.Hours24);
            Assert.AreEqual(testParamSpec.Minutes.Value, testOutput.Time.Minutes);
            Assert.AreEqual(0, testOutput.Time.Seconds);
        }

        [TestMethod]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ReturnsObjectWithCorrectTimeProperty_IfFirstParameterHasAtPropertyWithTimePropertyThatIsThreeNumbersInRangeSeparatedByColons()
        {
            TrainTimeModel testParam0 = GetTestObject();
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds);
            testParam0.At = testParamSpec.Model;
            Dictionary<string, Note> testParam1 = GetNoteDictionaryWithContents(testParam0.FootnoteIds);

            TrainTime testOutput = testParam0.ToTrainTime(testParam1);

            Assert.AreEqual(testParamSpec.Hours.Value, testOutput.Time.Hours24);
            Assert.AreEqual(testParamSpec.Minutes.Value, testOutput.Time.Minutes);
            Assert.AreEqual(testParamSpec.Seconds.Value, testOutput.Time.Seconds);
        }

        [TestMethod]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ReturnsObjectWithCorrectTimeProperty_IfFirstParameterHasAtPropertyWithTimePropertyThatIsMoreThanThreeNumbersInRangeSeparatedByColons()
        {
            TrainTimeModel testParam0 = GetTestObject();
            TimeOfDaySpecification testParamSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSecondsAndMore);
            testParam0.At = testParamSpec.Model;
            Dictionary<string, Note> testParam1 = GetNoteDictionaryWithContents(testParam0.FootnoteIds);

            TrainTime testOutput = testParam0.ToTrainTime(testParam1);

            Assert.AreEqual(testParamSpec.Hours.Value, testOutput.Time.Hours24);
            Assert.AreEqual(testParamSpec.Minutes.Value, testOutput.Time.Minutes);
            Assert.AreEqual(testParamSpec.Seconds.Value, testOutput.Time.Seconds);
        }

        [TestMethod]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ReturnsObjectWithEmptyFootnotesCollection_IfSecondParameterIsNull()
        {
            TrainTimeModel testParam0 = GetTestObject();
            Dictionary<string, Note> testParam1 = null;

            TrainTime testOutput = testParam0.ToTrainTime(testParam1);

            Assert.IsNotNull(testOutput.Footnotes);
            Assert.AreEqual(0, testOutput.Footnotes.Count);
        }

        [TestMethod]
        public void TrainTimeModelExtensionsClass_ToTrainTimeMethod_ReturnsObjectWithFootnotesCollectionWithCorrectContents_IfSecondParameterIsCollectionWithAllElementsContainedInFootnoteIdsPropertyOfFirstParameter()
        {
            TrainTimeModel testParam0 = GetTestObject();
            Dictionary<string, Note> testParam1 = GetNoteDictionaryWithContents(testParam0.FootnoteIds);

            TrainTime testOutput = testParam0.ToTrainTime(testParam1);

            Assert.AreEqual(testParam0.FootnoteIds.Count, testOutput.Footnotes.Count);
            for (int i = 0; i < testParam0.FootnoteIds.Count; ++i)
            {
                Assert.AreEqual(testParam0.FootnoteIds[i], testOutput.Footnotes[i].Id);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
