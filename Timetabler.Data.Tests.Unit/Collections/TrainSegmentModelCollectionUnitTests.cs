using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Providers;
using Timetabler.Data.Collections;
using Timetabler.Data.Display;
using Timetabler.Data.Events;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit.Collections
{
    [TestClass]
    public class TrainSegmentModelCollectionUnitTests
    {
        private static readonly Random _random = RandomProvider.Default;
        private const int TestMultipleRuns = 10;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainSegmentModelCollectionClass_ParameterlessConstructor_ReturnsEmptyCollection()
        {
            TrainSegmentModelCollection collection = new TrainSegmentModelCollection();

            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_ConstructorWithIEnumerableParameter_ReturnsCollectionOfCorrectSize()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);

            TrainSegmentModelCollection collection = new TrainSegmentModelCollection(testData);

            Assert.AreEqual(testData.Count, collection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_ConstructorWithIEnumerableParameter_ReturnsCollectionWithCorrectContents()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);

            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsCollectionofCorrectSize()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            Assert.AreEqual(sourceCollection.Count, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsDifferentObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            Assert.AreNotSame(sourceCollection, testCollection);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWhichAreDifferentObjects()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreNotSame(sourceCollection[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithCorrectFootnoteProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].Footnotes, testCollection[i].Footnotes);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithCorrectHalfOfDayProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].HalfOfDay, testCollection[i].HalfOfDay);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithCorrectHeadcodeProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].Headcode, testCollection[i].Headcode);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithCorrectIncludeSeparatorAboveProperties()
        {
            for (int rep = 0; rep < TestMultipleRuns; ++rep)
            {
                List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
                TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

                TrainSegmentModelCollection testCollection = sourceCollection.Copy();

                for (int i = 0; i < sourceCollection.Count; ++i)
                {
                    Assert.AreEqual(sourceCollection[i].IncludeSeparatorAbove, testCollection[i].IncludeSeparatorAbove);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithCorrectIncludeSeparatorBelowProperties()
        {
            for (int rep = 0; rep < TestMultipleRuns; ++rep)
            {
                List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
                TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

                TrainSegmentModelCollection testCollection = sourceCollection.Copy();

                for (int i = 0; i < sourceCollection.Count; ++i)
                {
                    Assert.AreEqual(sourceCollection[i].IncludeSeparatorBelow, testCollection[i].IncludeSeparatorBelow);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithCorrectInlineNoteProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].InlineNote, testCollection[i].InlineNote);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithCorrectLocoDiagramProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].LocoDiagram, testCollection[i].LocoDiagram);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithTimingPropertiesOfCorrectSize()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].Timings.Count, testCollection[i].Timings.Count);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithTimingPropertiesContentsThatAreNotSameObjects()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                for (int j = 0; j < sourceCollection[i].Timings.Count; ++j)
                {
                    Assert.AreNotSame(sourceCollection[i].Timings[j], testCollection[i].Timings[j]);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithTimingPropertiesWithCorrectActualTimeProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                for (int j = 0; j < sourceCollection[i].Timings.Count; ++j)
                {
                    var sourceTiming = sourceCollection[i].Timings[j] as TrainLocationTimeModel;
                    var testTiming = testCollection[i].Timings[j] as TrainLocationTimeModel;
                    Assert.AreEqual(sourceTiming.ActualTime, testTiming.ActualTime);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithTimingPropertiesWithCorrectDisplayedTextProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                for (int j = 0; j < sourceCollection[i].Timings.Count; ++j)
                {
                    Assert.AreEqual(sourceCollection[i].Timings[j].DisplayedText, testCollection[i].Timings[j].DisplayedText);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithTimingPropertiesWithCorrectEntryTypeProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                for (int j = 0; j < sourceCollection[i].Timings.Count; ++j)
                {
                    Assert.AreEqual(sourceCollection[i].Timings[j].EntryType, testCollection[i].Timings[j].EntryType);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithTimingPropertiesWithCorrectIsPassingTimeProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                for (int j = 0; j < sourceCollection[i].Timings.Count; ++j)
                {
                    var sourceTiming = sourceCollection[i].Timings[j] as TrainLocationTimeModel;
                    var testTiming = testCollection[i].Timings[j] as TrainLocationTimeModel;
                    Assert.AreEqual(sourceTiming.IsPassingTime, testTiming.IsPassingTime);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithTimingPropertiesWithCorrectLocationIdProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                for (int j = 0; j < sourceCollection[i].Timings.Count; ++j)
                {
                    Assert.AreEqual(sourceCollection[i].Timings[j].LocationKey, testCollection[i].Timings[j].LocationKey);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithTimingsIndexPropertiesWithCorrectSize()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].TimingsIndex.Count, testCollection[i].TimingsIndex.Count);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithTimingsIndexPropertiesThatCorrectlyIndexTheTimingsProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                for (int j = 0; j < testCollection[i].Timings.Count; ++j)
                {
                    Assert.AreSame(testCollection[i].Timings[j], testCollection[i].TimingsIndex[testCollection[i].Timings[j].LocationKey]);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithToWorkCellPropertiesThatAreDifferentObjects()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreNotSame(sourceCollection[i].ToWorkCell, testCollection[i].ToWorkCell);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithToWorkCellPropertiesWithCorrectActualTimeProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].ToWorkCell.ActualTime, testCollection[i].ToWorkCell.ActualTime);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithToWorkCellPropertiesWithCorrectDisplayedTextProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].ToWorkCell.DisplayedText, testCollection[i].ToWorkCell.DisplayedText);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithToWorkCellPropertiesWithCorrectEntryTypeProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].ToWorkCell.EntryType, testCollection[i].ToWorkCell.EntryType);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithCorrectTrainClassProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].TrainClass, testCollection[i].TrainClass);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyMethod_ReturnsContentsWithCorrectTrainIdProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                Assert.AreEqual(sourceCollection[i].TrainId, testCollection[i].TrainId);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_SetsCorrectObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreSame(testObject, testCollection[idx]);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_RaisesTrainSegmentModelRemoveEvent_IfSetIsCalledWithDifferentObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            int invocations = 0;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { invocations++; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_DoesNotRaiseTrainSegmentModelRemoveEvent_IfSetIsCalledWithSameObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int invocations = 0;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { invocations++; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testData[idx];

            Assert.AreEqual(0, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_RaisesTrainSegmentModelRemoveEventWithCorrectSender_IfSetIsCalledWithDifferentObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelCollection capturedSender = null;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { capturedSender = o as TrainSegmentModelCollection; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreSame(testCollection, capturedSender);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_RaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectModel_IfSetIsCalledWithDifferentObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreSame(testData[idx], capturedEventArgs.Model);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_RaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectIndex_IfSetIsCalledWithDifferentObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreEqual(idx, capturedEventArgs.Index);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_RaisesTrainSegmentModelAddEvent_IfSetIsCalledWithDifferentObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            int invocations = 0;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { invocations++; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_DoesNotRaiseTrainSegmentModelAddEvent_IfSetIsCalledWithSameObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int invocations = 0;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { invocations++; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testData[idx];

            Assert.AreEqual(0, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_RaisesTrainSegmentModelAddEventWithCorrectSender_IfSetIsCalledWithDifferentObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelCollection capturedSender = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedSender = o as TrainSegmentModelCollection; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreSame(testCollection, capturedSender);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_RaisesTrainSegmentModelAddEventWithEventArgsWithCorrectModel_IfSetIsCalledWithDifferentObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreSame(testObject, capturedEventArgs.Model);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_RaisesTrainSegmentModelAddEventWithEventArgsWithCorrectIndex_IfSetIsCalledWithDifferentObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreEqual(idx, capturedEventArgs.Index);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexerWithIntParameter_GetMethodReturnsCorrectObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);

            TrainSegmentModel testObject = testCollection[idx];

            Assert.AreSame(testData[idx], testObject);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CountProperty_HasCorrectValue()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int len;

            len = testCollection.Count;

            Assert.AreEqual(testData.Count, len);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IsReadOnlyProperty_ReturnsFalse()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            bool val;

            val = testCollection.IsReadOnly;

            Assert.IsFalse(val);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddMethod_IncreasesCountPropertyByOne()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();

            testCollection.Add(testObject);

            Assert.AreEqual(testData.Count + 1, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddMethod_SetsFinalMemberOfCollectionToParameter()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();

            testCollection.Add(testObject);

            Assert.AreSame(testObject, testCollection[testCollection.Count - 1]);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddMethod_DoesNotAlterPriorContentsOfCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();

            testCollection.Add(testObject);

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddMethod_RaisesTrainSegmentModelAddEvent()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            int invocations = 0;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { invocations++; });

            testCollection.Add(testObject);

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddMethod_RaisesTrainSegmentModelAddEventWithCorrectSender()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelCollection capturedSender = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedSender = o as TrainSegmentModelCollection; });

            testCollection.Add(testObject);

            Assert.AreSame(testCollection, capturedSender);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddMethod_RaisesTrainSegmentModelAddEventWithEventArgsWithCorrectModelProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });

            testCollection.Add(testObject);

            Assert.AreSame(testObject, capturedEventArgs.Model);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddMethod_RaisesTrainSegmentModelAddEventWithEventArgsWithCorrectIndexProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });

            testCollection.Add(testObject);

            Assert.AreEqual(testCollection.Count - 1, capturedEventArgs.Index);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_ClearMethod_SetsCountToZero()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            testCollection.Clear();

            Assert.AreEqual(0, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_ContainsMethod_ReturnsTrue_IfParameterIsInCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);

            bool testResult = testCollection.Contains(testData[idx]);

            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_ContainsMethod_ReturnsFalse_IfParameterIsNotInCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            bool testResult = testCollection.Contains(TrainSegmentModelHelpers.GetTrainSegmentModel());

            Assert.IsFalse(testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexOfMethod_ReturnsIndexOfParameter_IfParameterIsInCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);

            int testResult = testCollection.IndexOf(testData[idx]);

            Assert.AreEqual(idx, testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_IndexOfMethod_ReturnsNegativeOne_IfParameterIsNotInCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            int testResult = testCollection.IndexOf(TrainSegmentModelHelpers.GetTrainSegmentModel());

            Assert.AreEqual(-1, testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyToMethod_CopiesDataCorrectlyIntoDestinationArray()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int startPoint = _random.Next(100);
            int arrayLen = startPoint + testData.Count + _random.Next(100);
            TrainSegmentModel[] testDestination = new TrainSegmentModel[arrayLen];

            testCollection.CopyTo(testDestination, startPoint);

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testDestination[i + startPoint]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainSegmentModelCollectionClass_CopyToMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int startPoint = _random.Next(100);

            testCollection.CopyTo(null, startPoint);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TrainSegmentModelCollectionClass_CopyToMethod_ThrowsArgumentOutOfRangeException_IfSecondParameterIsNegative()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int startPoint = _random.Next(100);
            int arrayLen = startPoint + testData.Count + _random.Next(100);
            TrainSegmentModel[] testDestination = new TrainSegmentModel[arrayLen];

            testCollection.CopyTo(testDestination, -_random.Next(1, int.MaxValue));

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TrainSegmentModelCollectionClass_CopyToMethod_ThrowsArgumentException_IfArrayIsNotLongEnough()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int startPoint = _random.Next(100);
            int arrayLen = _random.Next(startPoint + testData.Count);
            TrainSegmentModel[] testDestination = new TrainSegmentModel[arrayLen];

            testCollection.CopyTo(testDestination, startPoint);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_CopyToMethod_ShouldNeverThrowIndexOutOfRangeExceptionInCasesWhereArgumentExceptionShouldBeThrown()
        {
            int count = TestMultipleRuns * 10;
            for (int lp = 0; lp < count; ++lp)
            {
                try
                {
                    List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
                    TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
                    int startPoint = _random.Next(100);
                    int arrayLen = _random.Next(startPoint + testData.Count);
                    TrainSegmentModel[] testDestination = new TrainSegmentModel[arrayLen];

                    testCollection.CopyTo(testDestination, startPoint);
                }
                catch (ArgumentException)
                {
                    // this is expected.
                }
                catch (IndexOutOfRangeException)
                {
                    Assert.Fail();
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_ReducesCountByOne_IfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            int originalCount = testCollection.Count;

            testCollection.Remove(testData[idx]);

            Assert.AreEqual(originalCount - 1, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_ReturnsTrue_IfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);

            bool testResult = testCollection.Remove(testData[idx]);

            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_DoesNotAlterCollectionPriorToParameter_IfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(2, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count - 1) + 1;
            
            _ = testCollection.Remove(testData[idx]);

            for (int i = 0; i < idx; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_MovesAllElementsAfterParameterDownByOne_IfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(2, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(1, testData.Count);

            testCollection.Remove(testData[idx]);

            for (int i = idx + 1; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i - 1]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_RaisesTrainSegmentModelRemoveEvent_IfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            int invocations = 0;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { invocations++; });

            testCollection.Remove(testData[idx]);

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_RaisesTrainSegmentModelRemoveEventWithCorrectSender_IfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            TrainSegmentModelCollection capturedSender = null;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { capturedSender = o as TrainSegmentModelCollection; });

            testCollection.Remove(testData[idx]);

            Assert.AreSame(testCollection, capturedSender);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_RaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectModelProperty_IfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });

            testCollection.Remove(testData[idx]);

            Assert.AreSame(testData[idx], capturedEventArgs.Model);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_RaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectIndexProperty_IfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });

            testCollection.Remove(testData[idx]);

            Assert.AreEqual(idx, capturedEventArgs.Index);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_DoesNotChangeCount_IfParameterIsNotContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int originalCount = testCollection.Count;

            testCollection.Remove(TrainSegmentModelHelpers.GetTrainSegmentModel());

            Assert.AreEqual(originalCount, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_ReturnsFalse_IfParameterIsNotContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            bool testResult = testCollection.Remove(TrainSegmentModelHelpers.GetTrainSegmentModel());

            Assert.IsFalse(testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_DoesNotAlterCollection_IfParameterIsNotContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            _ = testCollection.Remove(TrainSegmentModelHelpers.GetTrainSegmentModel());

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveMethod_DoesNotRaiseTrainSegmentModelRemoveEvent_IfParameterIsNotContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int invocations = 0;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { invocations++; });

            testCollection.Remove(TrainSegmentModelHelpers.GetTrainSegmentModel());

            Assert.AreEqual(0, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_ReducesCountByOne_IfParameterIsWithinCorrectRange()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            int originalCount = testCollection.Count;

            testCollection.RemoveAt(idx);

            Assert.AreEqual(originalCount - 1, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_DoesNotAlterCollectionPriorToParameter_IfParameterIsWithinCorrectRange()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(2, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count - 1) + 1;

            testCollection.RemoveAt(idx);

            for (int i = 0; i < idx; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_MovesAllElementsAfterParameterDownByOne_IfParameterIsWithinCorrectRange()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(2, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(1, testData.Count);

            testCollection.RemoveAt(idx);

            for (int i = idx + 1; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i - 1]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_RaisesTrainSegmentModelRemoveEvent_IfParameterIsWithinCorrectRange()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            int invocations = 0;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { invocations++; });

            testCollection.RemoveAt(idx);

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_RaisesTrainSegmentModelRemoveEventWithCorrectSender_IfParameterIsWithinCorrectRange()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            TrainSegmentModelCollection capturedSender = null;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { capturedSender = o as TrainSegmentModelCollection; });

            testCollection.RemoveAt(idx);

            Assert.AreSame(testCollection, capturedSender);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_RaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectModelProperty_IfParameterIsWithinCorrectRange()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });

            testCollection.RemoveAt(idx);

            Assert.AreSame(testData[idx], capturedEventArgs.Model);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_RaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectIndexProperty_IfParameterIsWithinCorrectRange()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });

            testCollection.RemoveAt(idx);

            Assert.AreEqual(idx, capturedEventArgs.Index);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_ThrowsArgumentOutOfRangeException_IfParameterIsNegative()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = -(_random.Next(int.MaxValue - 1) + 1);

            testCollection.RemoveAt(idx);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_DoesNotChangeCollectionContents_IfParameterIsNegative()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = -(_random.Next(int.MaxValue - 1) + 1);

            try
            {
                testCollection.RemoveAt(idx);
            }
            catch (ArgumentOutOfRangeException)
            { }

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_DoesNotChangeCount_IfParameterIsNegative()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = -(_random.Next(int.MaxValue - 1) + 1);
            int originalCount = testCollection.Count;

            try
            {
                testCollection.RemoveAt(idx);
            }
            catch (ArgumentOutOfRangeException)
            { }

            Assert.AreEqual(originalCount, testCollection.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_ThrowsArgumentOutOfRangeException_IfParameterIsEqualToCountProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = testCollection.Count;

            testCollection.RemoveAt(idx);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_DoesNotChangeCollectionContents_IfParameterIsEqualToCountProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = testCollection.Count;

            try
            {
                testCollection.RemoveAt(idx);
            }
            catch (ArgumentOutOfRangeException)
            { }

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_DoesNotChangeCount_IfParameterIsNegativeIsEqualToCountProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = testCollection.Count;
            int originalCount = testCollection.Count;

            try
            {
                testCollection.RemoveAt(idx);
            }
            catch (ArgumentOutOfRangeException)
            { }

            Assert.AreEqual(originalCount, testCollection.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_ThrowsArgumentOutOfRangeException_IfParameterIsGreaterThanOrEqualToCountProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testCollection.Count, int.MaxValue);

            testCollection.RemoveAt(idx);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_DoesNotChangeCollectionContents_IfParameterIsGreaterThanOrEqualToCountProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testCollection.Count, int.MaxValue);

            try
            {
                testCollection.RemoveAt(idx);
            }
            catch (ArgumentOutOfRangeException)
            { }

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_RemoveAtMethod_DoesNotChangeCount_IfParameterIsNegativeIsGreaterThanOrEqualToCountProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testCollection.Count, int.MaxValue);
            int originalCount = testCollection.Count;

            try
            {
                testCollection.RemoveAt(idx);
            }
            catch (ArgumentOutOfRangeException)
            { }

            Assert.AreEqual(originalCount, testCollection.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainSegmentModelCollectionClass_AddSortedMethod_ThrowsArgumentNullException_IfCountIsNonZeroAndSecondParameterIsNull()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            testCollection.AddSorted(TrainSegmentModelHelpers.GetTrainSegmentModel(), null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddSortedMethod_DoesNotThrowArgumentNullException_IfCountIsZeroAndSecondParameterIsNull()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();

            testCollection.AddSorted(TrainSegmentModelHelpers.GetTrainSegmentModel(), null);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddSortedMethod_SetsCountToOne_IfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();

            testCollection.AddSorted(TrainSegmentModelHelpers.GetTrainSegmentModel(), null);

            Assert.AreEqual(1, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddSortedMethod_SetsFirstElementOfCollectionToFirstParameter_IfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();
            TrainSegmentModel testItem = TrainSegmentModelHelpers.GetTrainSegmentModel();

            testCollection.AddSorted(testItem, null);

            Assert.AreSame(testItem, testCollection[0]);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddSortedMethod_RaisesTrainSegmentModelAddEvent_IfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();
            TrainSegmentModel testItem = TrainSegmentModelHelpers.GetTrainSegmentModel();
            int invocations = 0;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { invocations++; });

            testCollection.AddSorted(testItem, null);

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddSortedMethod_RaisesTrainSegmentModelAddEventWithCorrectSender_IfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();
            TrainSegmentModel testItem = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelCollection capturedSender = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedSender = o as TrainSegmentModelCollection; });

            testCollection.AddSorted(testItem, null);

            Assert.AreSame(testCollection, capturedSender);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddSortedMethod_RaisesTrainSegmentModelAddEventWithEventArgsWithModelEqualToFirstParameter_IfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();
            TrainSegmentModel testItem = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });

            testCollection.AddSorted(testItem, null);

            Assert.AreSame(testItem, capturedEventArgs.Model);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClass_AddSortedMethod_RaisesTrainSegmentModelAddEventWithEventArgsWithIndexEqualToZero_IfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();
            TrainSegmentModel testItem = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });

            testCollection.AddSorted(testItem, null);

            Assert.AreEqual(0, capturedEventArgs.Index);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
