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
    public class SignalboxHoursSetModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static SignalboxHoursSetModel GetTestObject()
        {
            int count = _rnd.Next(1, 10);
            SignalboxHoursSetModel output = new SignalboxHoursSetModel
            {
                Category = _rnd.NextString(_rnd.Next(20)),
            };
            for (int i = 0; i < count; ++i)
            {
                string boxId;
                do
                {
                    boxId = _rnd.NextHexString(8);
                } while (output.Signalboxes.Any(b => b.SignalboxId == boxId));
                output.Signalboxes.Add(new SignalboxHoursModel
                {
                    SignalboxId = boxId,
                    StartTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds).Model,
                    FinishTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds).Model,
                    TokenBalanceWarning = _rnd.NextNullableBoolean()
                });
            }

            return output;
        }

        private static IDictionary<string, Signalbox> GetSignalboxCollectionWithoutItems(ICollection<string> items)
        {
            int count = _rnd.Next(1, 20);
            Dictionary<string, Signalbox> output = new Dictionary<string, Signalbox>();
            for (int i = 0; i < count; ++i)
            {
                string id;
                do
                {
                    id = _rnd.NextHexString(8);
                } while (items.Contains(id) || output.ContainsKey(id));
                output.Add(id,
                    new Signalbox { Id = id, Code = _rnd.NextString(_rnd.Next(1, 6)), EditorDisplayName = _rnd.NextString(10), ExportDisplayName = _rnd.NextString(10) });
            }
            return output;
        }

        private static IDictionary<string, Signalbox> GetSignalboxCollectionWithItems(IEnumerable<string> it)
        {
            List<string> items = it.ToList();
            IDictionary<string, Signalbox> output = GetSignalboxCollectionWithoutItems(items);
            foreach (string item in items)
            {
                output.Add(item,
                    new Signalbox 
                    { 
                        Id = item, 
                        Code = _rnd.NextString(_rnd.Next(1, 6)), 
                        EditorDisplayName = _rnd.NextString(10), 
                        ExportDisplayName = _rnd.NextString(10) 
                    });
            }
            return output;
        }

        private static IEnumerable<SignalboxHoursSet> GetExistingSets()
        {
            int count = _rnd.Next(2000);
            List<SignalboxHoursSet> output = new List<SignalboxHoursSet>(count);
            for (int i = 0; i < count; ++i)
            {
                string setId;
                do
                {
                    setId = _rnd.NextHexString(8);
                } while (output.Any(s => s.Id == setId));
                output.Add(new SignalboxHoursSet { Id = setId });
            }
            return output;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsNullReferenceException_IfFirstParameterIsNull()
        {
            SignalboxHoursSetModel testParam0 = null;
            IDictionary<string, Signalbox> testParam1 = new Dictionary<string, Signalbox>();
            IEnumerable<SignalboxHoursSet> testParam2 = new List<SignalboxHoursSet>();

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = null;
            IEnumerable<SignalboxHoursSet> testParam2 = new List<SignalboxHoursSet>();

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsArgumentNullException_IfThirdParameterIsNull()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = new Dictionary<string, Signalbox>();
            IEnumerable<SignalboxHoursSet> testParam2 = null;

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithIdPropertyThatDiffersFromIdsOfContentsOfThirdParameter()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.IsFalse(testParam2.Any(s => s.Id == testOutput.Id));
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithCorrectCategoryProperty()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.AreEqual(testParam0.Category, testOutput.Category);
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingCorrectNumberOfElements()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.AreEqual(testParam0.Signalboxes.Count, testOutput.Hours.Count);
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingCorrectlyIndexedElements()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (KeyValuePair<string, SignalboxHours> item in testOutput.Hours)
            {
                Assert.AreEqual(item.Key, item.Value.Signalbox.Id);
            }
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingElementsWithCorrectSignalboxProperties()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (string id in testParam0.Signalboxes.Select(s => s.SignalboxId))
            {
                Assert.AreSame(testParam1[id], testOutput.Hours[id].Signalbox);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsNullReferenceException_IfFirstParameterHasSignalboxesPropertyContainingElementsWithStartTimePropertyThatIsNull()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                box.StartTime = null;
            }

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsFormatException_IfFirstParameterHasSignalboxesPropertyContainingElementsWithStartTimePropertyThatHaveTimePropertyThatIsNull()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                box.StartTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NullValue).Model;
            }

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsFormatException_IfFirstParameterHasSignalboxesPropertyContainingElementsWithStartTimePropertyThatHaveTimePropertyThatIsEmptyString()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                box.StartTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.EmptyValue).Model;
            }

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsFormatException_IfFirstParameterHasSignalboxesPropertyContainingElementsWithStartTimePropertyThatHaveTimePropertyThatIsSolelyWhiteSpace()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                box.StartTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.WhitespaceValue).Model;
            }

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsFormatException_IfFirstParameterHasSignalboxesPropertyContainingElementsWithStartTimePropertyThatHaveTimePropertyThatIsNotNumeric()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                box.StartTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NonNumericValue).Model;
            }

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingElementsWithCorrectStartTimeProperty_IfFirstParameterHasSignalboxesPropertyContainingElementsWithStartTimePropertiesThatHaveTimePropertyThatIsANumberWithinRange()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            Dictionary<string, TimeOfDaySpecification> timeSpecs = new Dictionary<string, TimeOfDaySpecification>();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                TimeOfDaySpecification timeSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursOnly);
                box.StartTime = timeSpec.Model;
                timeSpecs.Add(box.SignalboxId, timeSpec);
            }

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (string id in testParam0.Signalboxes.Select(s => s.SignalboxId))
            {
                Assert.AreEqual(timeSpecs[id].Hours.Value, testOutput.Hours[id].StartTime.Hours24);
                Assert.AreEqual(0, testOutput.Hours[id].StartTime.Minutes);
                Assert.AreEqual(0, testOutput.Hours[id].StartTime.Seconds);
            }
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingElementsWithCorrectStartTimeProperty_IfFirstParameterHasSignalboxesPropertyContainingElementsWithStartTimePropertiesThatHaveTimePropertyThatIsTwoNumbersWithinRangeSeparatedByAColon()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            Dictionary<string, TimeOfDaySpecification> timeSpecs = new Dictionary<string, TimeOfDaySpecification>();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                TimeOfDaySpecification timeSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursAndMinutes);
                box.StartTime = timeSpec.Model;
                timeSpecs.Add(box.SignalboxId, timeSpec);
            }

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (string id in testParam0.Signalboxes.Select(s => s.SignalboxId))
            {
                Assert.AreEqual(timeSpecs[id].Hours.Value, testOutput.Hours[id].StartTime.Hours24);
                Assert.AreEqual(timeSpecs[id].Minutes.Value, testOutput.Hours[id].StartTime.Minutes);
                Assert.AreEqual(0, testOutput.Hours[id].StartTime.Seconds);
            }
        }
            

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingElementsWithCorrectStartTimeProperty_IfFirstParameterHasSignalboxesPropertyContainingElementsWithStartTimePropertiesThatHaveTimePropertyThatIsThreeNumbersWithinRangeSeparatedByColons()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            Dictionary<string, TimeOfDaySpecification> timeSpecs = new Dictionary<string, TimeOfDaySpecification>();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                TimeOfDaySpecification timeSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds);
                box.StartTime = timeSpec.Model;
                timeSpecs.Add(box.SignalboxId, timeSpec);
            }

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (string id in testParam0.Signalboxes.Select(s => s.SignalboxId))
            {
                Assert.AreEqual(timeSpecs[id].Hours.Value, testOutput.Hours[id].StartTime.Hours24);
                Assert.AreEqual(timeSpecs[id].Minutes.Value, testOutput.Hours[id].StartTime.Minutes);
                Assert.AreEqual(timeSpecs[id].Seconds.Value, testOutput.Hours[id].StartTime.Seconds);
            }
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingElementsWithCorrectStartTimeProperty_IfFirstParameterHasSignalboxesPropertyContainingElementsWithStartTimePropertiesThatHaveTimePropertyThatIsMoreThanThreeNumbersWithinRangeSeparatedByColons()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            Dictionary<string, TimeOfDaySpecification> timeSpecs = new Dictionary<string, TimeOfDaySpecification>();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                TimeOfDaySpecification timeSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSecondsAndMore);
                box.StartTime = timeSpec.Model;
                timeSpecs.Add(box.SignalboxId, timeSpec);
            }

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (string id in testParam0.Signalboxes.Select(s => s.SignalboxId))
            {
                Assert.AreEqual(timeSpecs[id].Hours.Value, testOutput.Hours[id].StartTime.Hours24);
                Assert.AreEqual(timeSpecs[id].Minutes.Value, testOutput.Hours[id].StartTime.Minutes);
                Assert.AreEqual(timeSpecs[id].Seconds.Value, testOutput.Hours[id].StartTime.Seconds);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsNullReferenceException_IfFirstParameterHasSignalboxesPropertyContainingElementsWithFinishTimePropertyThatIsNull()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                box.FinishTime = null;
            }

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsFormatException_IfFirstParameterHasSignalboxesPropertyContainingElementsWithFinishTimePropertyThatHaveTimePropertyThatIsNull()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                box.FinishTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NullValue).Model;
            }

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsFormatException_IfFirstParameterHasSignalboxesPropertyContainingElementsWithFinishTimePropertyThatHaveTimePropertyThatIsEmptyString()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                box.FinishTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.EmptyValue).Model;
            }

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsFormatException_IfFirstParameterHasSignalboxesPropertyContainingElementsWithFinishTimePropertyThatHaveTimePropertyThatIsSolelyWhiteSpace()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                box.FinishTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.WhitespaceValue).Model;
            }

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsFormatException_IfFirstParameterHasSignalboxesPropertyContainingElementsWithFinishTimePropertyThatHaveTimePropertyThatIsNotNumeric()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                box.FinishTime = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.NonNumericValue).Model;
            }

            _ = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingElementsWithCorrectEndTimeProperty_IfFirstParameterHasSignalboxesPropertyContainingElementsWithFinishTimePropertiesThatHaveTimePropertyThatIsANumberWithinRange()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            Dictionary<string, TimeOfDaySpecification> timeSpecs = new Dictionary<string, TimeOfDaySpecification>();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                TimeOfDaySpecification timeSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursOnly);
                box.FinishTime = timeSpec.Model;
                timeSpecs.Add(box.SignalboxId, timeSpec);
            }

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (string id in testParam0.Signalboxes.Select(s => s.SignalboxId))
            {
                Assert.AreEqual(timeSpecs[id].Hours.Value, testOutput.Hours[id].EndTime.Hours24);
                Assert.AreEqual(0, testOutput.Hours[id].EndTime.Minutes);
                Assert.AreEqual(0, testOutput.Hours[id].EndTime.Seconds);
            }
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingElementsWithCorrectEndTimeProperty_IfFirstParameterHasSignalboxesPropertyContainingElementsWithFinishTimePropertiesThatHaveTimePropertyThatIsTwoNumbersWithinRangeSeparatedByAColon()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            Dictionary<string, TimeOfDaySpecification> timeSpecs = new Dictionary<string, TimeOfDaySpecification>();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                TimeOfDaySpecification timeSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursAndMinutes);
                box.FinishTime = timeSpec.Model;
                timeSpecs.Add(box.SignalboxId, timeSpec);
            }

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (string id in testParam0.Signalboxes.Select(s => s.SignalboxId))
            {
                Assert.AreEqual(timeSpecs[id].Hours.Value, testOutput.Hours[id].EndTime.Hours24);
                Assert.AreEqual(timeSpecs[id].Minutes.Value, testOutput.Hours[id].EndTime.Minutes);
                Assert.AreEqual(0, testOutput.Hours[id].EndTime.Seconds);
            }
        }


        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingElementsWithCorrectEndTimeProperty_IfFirstParameterHasSignalboxesPropertyContainingElementsWithFinishTimePropertiesThatHaveTimePropertyThatIsThreeNumbersWithinRangeSeparatedByColons()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            Dictionary<string, TimeOfDaySpecification> timeSpecs = new Dictionary<string, TimeOfDaySpecification>();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                TimeOfDaySpecification timeSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSeconds);
                box.FinishTime = timeSpec.Model;
                timeSpecs.Add(box.SignalboxId, timeSpec);
            }

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (string id in testParam0.Signalboxes.Select(s => s.SignalboxId))
            {
                Assert.AreEqual(timeSpecs[id].Hours.Value, testOutput.Hours[id].EndTime.Hours24);
                Assert.AreEqual(timeSpecs[id].Minutes.Value, testOutput.Hours[id].EndTime.Minutes);
                Assert.AreEqual(timeSpecs[id].Seconds.Value, testOutput.Hours[id].EndTime.Seconds);
            }
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingElementsWithCorrectEndTimeProperty_IfFirstParameterHasSignalboxesPropertyContainingElementsWithFinishTimePropertiesThatHaveTimePropertyThatIsMoreThanThreeNumbersWithinRangeSeparatedByColons()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            Dictionary<string, TimeOfDaySpecification> timeSpecs = new Dictionary<string, TimeOfDaySpecification>();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                TimeOfDaySpecification timeSpec = new TimeOfDaySpecification(TimeOfDaySpecification.TimeOfDaySpecificationKind.HoursMinutesSecondsAndMore);
                box.FinishTime = timeSpec.Model;
                timeSpecs.Add(box.SignalboxId, timeSpec);
            }

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (string id in testParam0.Signalboxes.Select(s => s.SignalboxId))
            {
                Assert.AreEqual(timeSpecs[id].Hours.Value, testOutput.Hours[id].EndTime.Hours24);
                Assert.AreEqual(timeSpecs[id].Minutes.Value, testOutput.Hours[id].EndTime.Minutes);
                Assert.AreEqual(timeSpecs[id].Seconds.Value, testOutput.Hours[id].EndTime.Seconds);
            }
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ReturnsObjectWithHoursPropertyContainingElementsWithCorrectTokenBalanceWarningProperty()
        {
            SignalboxHoursSetModel testParam0 = GetTestObject();
            IDictionary<string, Signalbox> testParam1 = GetSignalboxCollectionWithItems(testParam0.Signalboxes.Select(s => s.SignalboxId));
            IEnumerable<SignalboxHoursSet> testParam2 = GetExistingSets();
            Dictionary<string, bool?> tokenBalanceWarningFlags = new Dictionary<string, bool?>();
            foreach (SignalboxHoursModel box in testParam0.Signalboxes)
            {
                tokenBalanceWarningFlags.Add(box.SignalboxId, box.TokenBalanceWarning);
            }

            SignalboxHoursSet testOutput = testParam0.ToSignalboxHoursSet(testParam1, testParam2);

            foreach (string id in testParam0.Signalboxes.Select(s => s.SignalboxId))
            {
                Assert.AreEqual(tokenBalanceWarningFlags[id] ?? false, testOutput.Hours[id].TokenBalanceWarning);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
