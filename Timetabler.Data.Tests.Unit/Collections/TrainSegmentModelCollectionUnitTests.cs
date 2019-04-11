using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Timetabler.Data.Collections;
using Timetabler.Data.Display;
using Timetabler.Data.Events;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit.Collections
{
    [TestClass]
    public class TrainSegmentModelCollectionUnitTests
    {
        private Random _random;
        private const int TestMultipleRuns = 10;

        public TrainSegmentModelCollectionUnitTests()
        {
            _random = new Random();
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassParameterlessConstructorReturnsEmptyCollection()
        {
            TrainSegmentModelCollection collection = new TrainSegmentModelCollection();

            Assert.AreEqual(0, collection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassConstructorWithIEnumerableParameterReturnsCollectionOfCorrectSize()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);

            TrainSegmentModelCollection collection = new TrainSegmentModelCollection(testData);

            Assert.AreEqual(testData.Count, collection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassConstructorWithIEnumerableParameterReturnsCollectionWithCorrectContents()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);

            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassCopyMethodReturnsCollectionofCorrectSize()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            Assert.AreEqual(sourceCollection.Count, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassCopyMethodReturnsDifferentObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            Assert.AreNotSame(sourceCollection, testCollection);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWhichAreDifferentObjects()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithCorrectFootnoteProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithCorrectHalfOfDayProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithCorrectHeadcodeProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithCorrectIncludeSeparatorAboveProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithCorrectIncludeSeparatorBelowProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithCorrectInlineNoteProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithCorrectLocoDiagramProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithTimingPropertiesOfCorrectSize()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithTimingPropertiesContentsThatAreNotSameObjects()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithTimingPropertiesWithCorrectActualTimeProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                for (int j = 0; j < sourceCollection[i].Timings.Count; ++j)
                {
                    var sourceTiming = sourceCollection[i].Timings[j] as TrainLocationTimeModel;
                    var testTiming = sourceCollection[i].Timings[j] as TrainLocationTimeModel;
                    Assert.AreEqual(sourceTiming.ActualTime, testTiming.ActualTime);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithTimingPropertiesWithCorrectDisplayedTextProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithTimingPropertiesWithCorrectEntryTypeProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithTimingPropertiesWithCorrectIsPassingTimeProperties()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(0, 64);
            TrainSegmentModelCollection sourceCollection = new TrainSegmentModelCollection(testData);

            TrainSegmentModelCollection testCollection = sourceCollection.Copy();

            for (int i = 0; i < sourceCollection.Count; ++i)
            {
                for (int j = 0; j < sourceCollection[i].Timings.Count; ++j)
                {
                    var sourceTiming = sourceCollection[i].Timings[j] as TrainLocationTimeModel;
                    var testTiming = sourceCollection[i].Timings[j] as TrainLocationTimeModel;
                    Assert.AreEqual(sourceTiming.IsPassingTime, testTiming.IsPassingTime);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithTimingPropertiesWithCorrectLocationIdProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithTimingsIndexPropertiesWithCorrectSize()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithTimingsIndexPropertiesThatCorrectlyIndexTheTimingsProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithToWorkCellPropertiesThatAreDifferentObjects()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithToWorkCellPropertiesWithCorrectActualTimeProperty()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithToWorkCellPropertiesWithCorrectDisplayedTextProperty()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithToWorkCellPropertiesWithCorrectEntryTypeProperty()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithCorrectTrainClassProperties()
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
        public void TrainSegmentModelCollectionClassCopyMethodReturnsContentsWithCorrectTrainIdProperties()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterSetsCorrectObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();
            int idx = _random.Next(testData.Count);

            testCollection[idx] = testObject;

            Assert.AreSame(testObject, testCollection[idx]);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterRaisesTrainSegmentModelRemoveEventIfSetIsCalledWithDifferentObject()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterDoesNotRaiseTrainSegmentModelRemoveEventIfSetIsCalledWithSameObject()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterRaisesTrainSegmentModelRemoveEventWithCorrectSenderIfSetIsCalledWithDifferentObject()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterRaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectModelIfSetIsCalledWithDifferentObject()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterRaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectIndexIfSetIsCalledWithDifferentObject()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterRaisesTrainSegmentModelAddEventIfSetIsCalledWithDifferentObject()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterDoesNotRaiseTrainSegmentModelAddEventIfSetIsCalledWithSameObject()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterRaisesTrainSegmentModelAddEventWithCorrectSenderIfSetIsCalledWithDifferentObject()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterRaisesTrainSegmentModelAddEventWithEventArgsWithCorrectModelIfSetIsCalledWithDifferentObject()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterRaisesTrainSegmentModelAddEventWithEventArgsWithCorrectIndexIfSetIsCalledWithDifferentObject()
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
        public void TrainSegmentModelCollectionClassIndexerWithIntParameterGetMethodReturnsCorrectObject()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = null;
            int idx = _random.Next(testData.Count);

            testObject = testCollection[idx];

            Assert.AreSame(testData[idx], testObject);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassCountPropertyHasCorrectValue()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int len;

            len = testCollection.Count;

            Assert.AreEqual(testData.Count, len);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassIsReadOnlyPropertyReturnsFalse()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            bool val;

            val = testCollection.IsReadOnly;

            Assert.IsFalse(val);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassAddMethodIncreasesCountPropertyByOne()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();

            testCollection.Add(testObject);

            Assert.AreEqual(testData.Count + 1, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassAddMethodSetsFinalMemberOfCollectionToParameter()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            TrainSegmentModel testObject = TrainSegmentModelHelpers.GetTrainSegmentModel();

            testCollection.Add(testObject);

            Assert.AreSame(testObject, testCollection[testCollection.Count - 1]);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassAddMethodDoesNotAlterPriorContentsOfCollection()
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
        public void TrainSegmentModelCollectionClassAddMethodRaisesTrainSegmentModelAddEvent()
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
        public void TrainSegmentModelCollectionClassAddMethodRaisesTrainSegmentModelAddEventWithCorrectSender()
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
        public void TrainSegmentModelCollectionClassAddMethodRaisesTrainSegmentModelAddEventWithEventArgsWithCorrectModelProperty()
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
        public void TrainSegmentModelCollectionClassAddMethodRaisesTrainSegmentModelAddEventWithEventArgsWithCorrectIndexProperty()
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
        public void TrainSegmentModelCollectionClassClearMethodSetsCountToZero()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            testCollection.Clear();

            Assert.AreEqual(0, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassContainsMethodReturnsTrueIfParameterIsInCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);

            bool testResult = testCollection.Contains(testData[idx]);

            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassContainsMethodReturnsFalseIfParameterIsNotInCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            bool testResult = testCollection.Contains(TrainSegmentModelHelpers.GetTrainSegmentModel());

            Assert.IsFalse(testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassIndexOfMethodReturnsIndexOfParameterIfParameterIsInCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);

            int testResult = testCollection.IndexOf(testData[idx]);

            Assert.AreEqual(idx, testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassIndexOfMethodReturnsNegativeOneIfParameterIsNotInCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            int testResult = testCollection.IndexOf(TrainSegmentModelHelpers.GetTrainSegmentModel());

            Assert.AreEqual(-1, testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassCopyToMethodCopiesDataCorrectlyIntoDestinationArray()
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
        public void TrainSegmentModelCollectionClassCopyToMethodThrowsArgumentNullExceptionIfFirstParameterIsNull()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int startPoint = _random.Next(100);

            testCollection.CopyTo(null, startPoint);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TrainSegmentModelCollectionClassCopyToMethodThrowsArgumentOutOfRangeExceptionIfSecondParameterIsNegative()
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
        public void TrainSegmentModelCollectionClassCopyToMethodThrowsArgumentExceptionIfArrayIsNotLongEnough()
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
        public void TrainSegmentModelCollectionClassCopyToMethodShouldNeverThrowIndexOutOfRangeExceptionInCasesWhereArgumentExceptionShouldBeThrown()
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
        public void TrainSegmentModelCollectionClassRemoveMethodReducesCountByOneIfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            int originalCount = testCollection.Count;

            testCollection.Remove(testData[idx]);

            Assert.AreEqual(originalCount - 1, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveMethodReturnsTrueIfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);

            bool testResult = testCollection.Remove(testData[idx]);

            Assert.IsTrue(testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveMethodDoesNotAlterCollectionPriorToParameterIfParameterIsContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(2, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count - 1) + 1;

            bool testResult = testCollection.Remove(testData[idx]);

            for (int i = 0; i < idx; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveMethodMovesAllElementsAfterParameterDownByOneIfParameterIsContainedWithinCollection()
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
        public void TrainSegmentModelCollectionClassRemoveMethodRaisesTrainSegmentModelRemoveEventIfParameterIsContainedWithinCollection()
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
        public void TrainSegmentModelCollectionClassRemoveMethodRaisesTrainSegmentModelRemoveEventWithCorrectSenderIfParameterIsContainedWithinCollection()
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
        public void TrainSegmentModelCollectionClassRemoveMethodRaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectModelPropertyIfParameterIsContainedWithinCollection()
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
        public void TrainSegmentModelCollectionClassRemoveRaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectIndexPropertyIfParameterIsContainedWithinCollection()
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
        public void TrainSegmentModelCollectionClassRemoveMethodDoesNotChangeCountIfParameterIsNotContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int originalCount = testCollection.Count;

            testCollection.Remove(TrainSegmentModelHelpers.GetTrainSegmentModel());

            Assert.AreEqual(originalCount, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveMethodReturnsFalseIfParameterIsNotContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            bool testResult = testCollection.Remove(TrainSegmentModelHelpers.GetTrainSegmentModel());

            Assert.IsFalse(testResult);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveMethodDoesNotAlterCollectionIfParameterIsNotContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            bool testResult = testCollection.Remove(TrainSegmentModelHelpers.GetTrainSegmentModel());

            for (int i = 0; i < testData.Count; ++i)
            {
                Assert.AreSame(testData[i], testCollection[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveMethodDoesNotRaiseTrainSegmentModelRemoveEventIfParameterIsNotContainedWithinCollection()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int invocations = 0;
            testCollection.TrainSegmentModelRemove += new TrainSegmentModelEventHandler((o, e) => { invocations++; });

            testCollection.Remove(TrainSegmentModelHelpers.GetTrainSegmentModel());

            Assert.AreEqual(0, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveAtMethodReducesCountByOneIfParameterIsWithinCorrectRange()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testData.Count);
            int originalCount = testCollection.Count;

            testCollection.RemoveAt(idx);

            Assert.AreEqual(originalCount - 1, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveAtMethodDoesNotAlterCollectionPriorToParameterIfParameterIsWithinCorrectRange()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodMovesAllElementsAfterParameterDownByOneIfParameterIsWithinCorrectRange()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodRaisesTrainSegmentModelRemoveEventIfParameterIsWithinCorrectRange()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodRaisesTrainSegmentModelRemoveEventWithCorrectSenderIfParameterIsWithinCorrectRange()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodRaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectModelPropertyIfParameterIsWithinCorrectRange()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodRaisesTrainSegmentModelRemoveEventWithEventArgsWithCorrectIndexPropertyIfParameterIsWithinCorrectRange()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodThrowsArgumentOutOfRangeExceptionIfParameterIsNegative()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = -(_random.Next(int.MaxValue - 1) + 1);

            testCollection.RemoveAt(idx);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveAtMethodDoesNotChangeCollectionContentsIfParameterIsNegative()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodDoesNotChangeCountIfParameterIsNegative()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodThrowsArgumentOutOfRangeExceptionIfParameterIsEqualToCountProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = testCollection.Count;

            testCollection.RemoveAt(idx);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveAtMethodDoesNotChangeCollectionContentsIfParameterIsEqualToCountProperty()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodDoesNotChangeCountIfParameterIsNegativeIsEqualToCountProperty()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodThrowsArgumentOutOfRangeExceptionIfParameterIsGreaterThanOrEqualToCountProperty()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);
            int idx = _random.Next(testCollection.Count, int.MaxValue);

            testCollection.RemoveAt(idx);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassRemoveAtMethodDoesNotChangeCollectionContentsIfParameterIsGreaterThanOrEqualToCountProperty()
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
        public void TrainSegmentModelCollectionClassRemoveAtMethodDoesNotChangeCountIfParameterIsNegativeIsGreaterThanOrEqualToCountProperty()
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
        public void TrainSegmentModelCollectionClassAddSortedMethodThrowsArgumentNullExceptionIfCountIsNonZeroAndSecondParameterIsNull()
        {
            List<TrainSegmentModel> testData = TrainSegmentModelHelpers.GetTrainSegmentModelList(1, 64);
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection(testData);

            testCollection.AddSorted(TrainSegmentModelHelpers.GetTrainSegmentModel(), null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassAddSortedMethodDoesNotThrowArgumentNullExceptionIfCountIsZeroAndSecondParameterIsNull()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();

            testCollection.AddSorted(TrainSegmentModelHelpers.GetTrainSegmentModel(), null);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassAddSortedMethodSetsCountToOneIfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();

            testCollection.AddSorted(TrainSegmentModelHelpers.GetTrainSegmentModel(), null);

            Assert.AreEqual(1, testCollection.Count);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassAddSortedMethodSetsFirstElementOfCollectionToFirstParameterIfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();
            TrainSegmentModel testItem = TrainSegmentModelHelpers.GetTrainSegmentModel();

            testCollection.AddSorted(testItem, null);

            Assert.AreSame(testItem, testCollection[0]);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassAddSortedMethodRaisesTrainSegmentModelAddEventIfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();
            TrainSegmentModel testItem = TrainSegmentModelHelpers.GetTrainSegmentModel();
            int invocations = 0;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { invocations++; });

            testCollection.AddSorted(testItem, null);

            Assert.AreEqual(1, invocations);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassAddSortedMethodRaisesTrainSegmentModelAddEventWithCorrectSenderIfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();
            TrainSegmentModel testItem = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelCollection capturedSender = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedSender = o as TrainSegmentModelCollection; });

            testCollection.AddSorted(testItem, null);

            Assert.AreSame(testCollection, capturedSender);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassAddSortedMethodRaisesTrainSegmentModelAddEventWithEventArgsWithModelEqualToFirstParameterIfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();
            TrainSegmentModel testItem = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });

            testCollection.AddSorted(testItem, null);

            Assert.AreSame(testItem, capturedEventArgs.Model);
        }

        [TestMethod]
        public void TrainSegmentModelCollectionClassAddSortedMethodRaisesTrainSegmentModelAddEventWithEventArgsWithIndexEqualToZeroIfCountIsZero()
        {
            TrainSegmentModelCollection testCollection = new TrainSegmentModelCollection();
            TrainSegmentModel testItem = TrainSegmentModelHelpers.GetTrainSegmentModel();
            TrainSegmentModelEventArgs capturedEventArgs = null;
            testCollection.TrainSegmentModelAdd += new TrainSegmentModelEventHandler((o, e) => { capturedEventArgs = e; });

            testCollection.AddSorted(testItem, null);

            Assert.AreEqual(0, capturedEventArgs.Index);
        }
    }
}
