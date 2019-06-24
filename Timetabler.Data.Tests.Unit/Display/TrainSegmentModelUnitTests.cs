using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Timetabler.Data.Display;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class TrainSegmentModelUnitTests
    {
        private static Random _rnd = new Random();

        private TrainSegmentModel GetTestObject(int? timings)
        {
            int pageFootnoteCount = _rnd.Next(10) + 1;
            TrainSegmentModel tsm = new TrainSegmentModel();
            for (int i = 0; i < pageFootnoteCount; ++i)
            {
                tsm.PageFootnotes.Add(FootnoteDisplayModelHelpers.GetFootnoteDisplayModel());
            }
            int timingsCount;
            if (timings.HasValue)
            {
                timingsCount = timings.Value;
            }
            else
            {
                timingsCount = _rnd.Next(20) + 3;
            }
            for (int i = 0; i < timingsCount; ++i)
            {
                tsm.Timings.Add(new TrainLocationTimeModel { LocationKey = i.ToString() });
            }

            return tsm;
        }

        private Note[] GetTestNotes(IList<string> noteIds)
        {
            Note[] notes = new Note[noteIds.Count];
            for (int i = 0; i < noteIds.Count; ++i)
            {
                Note note = NoteHelpers.GetNote();
                note.Id = noteIds[i];
                notes[i] = note;
            }
            return notes;
        }

        [TestMethod]
        public void TrainSegmentModelClassUpdatePageFootnotesMethodDoesNotChangePageFootnotesPropertyIfParameterIsNull()
        {
            TrainSegmentModel testObject = GetTestObject(null);
            int testFootnoteCount = testObject.PageFootnotes.Count;
            var pageFootnotesCopy = testObject.PageFootnotes.ToList();

            testObject.UpdatePageFootnotes(null);

            Assert.AreEqual(testFootnoteCount, testObject.PageFootnotes.Count);
            for (int i = 0; i < testFootnoteCount; ++i)
            {
                FootnoteDisplayModelHelpers.FullEqualityTest(pageFootnotesCopy[i], testObject.PageFootnotes[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassUpdatePageFootnotesMethodDoesNotChangePageFootnotesPropertyIfParameterIsEmpty()
        {
            TrainSegmentModel testObject = GetTestObject(null);
            int testFootnoteCount = testObject.PageFootnotes.Count;
            List<FootnoteDisplayModel> pageFootnotesCopy = testObject.PageFootnotes.ToList();

            testObject.UpdatePageFootnotes(new Note[0]);

            Assert.AreEqual(testFootnoteCount, testObject.PageFootnotes.Count);
            for (int i = 0; i < testFootnoteCount; ++i)
            {
                FootnoteDisplayModelHelpers.FullEqualityTest(pageFootnotesCopy[i], testObject.PageFootnotes[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassUpdatePageFootnotesMethodChangesPageFootnotesElementsWithIdsThatAppearInParameter()
        {
            TrainSegmentModel testObject = GetTestObject(null);
            int testFootnoteCount = testObject.PageFootnotes.Count;
            List<FootnoteDisplayModel> pageFootnotesCopy = testObject.PageFootnotes.ToList();
            List<string> idsToChange = new List<string>();
            foreach (FootnoteDisplayModel fdm in testObject.PageFootnotes)
            {
                if (_rnd.NextBoolean())
                {
                    idsToChange.Add(fdm.NoteId);
                }
            }
            Note[] testParameter = GetTestNotes(idsToChange);

            testObject.UpdatePageFootnotes(testParameter);

            Assert.AreEqual(testFootnoteCount, testObject.PageFootnotes.Count);
            for (int i = 0; i < testFootnoteCount; ++i)
            {
                if (idsToChange.Contains(testObject.PageFootnotes[i].NoteId))
                {
                    Assert.AreNotSame(pageFootnotesCopy[i], testObject.PageFootnotes[i]);
                }
                else
                {
                    Assert.AreSame(pageFootnotesCopy[i], testObject.PageFootnotes[i]);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassUpdatePageFootnotesMethodSetsPageFootnotesElementsDefinitionPropertiesIfIdAppearsInParameter()
        {
            TrainSegmentModel testObject = GetTestObject(null);
            int testFootnoteCount = testObject.PageFootnotes.Count;
            List<string> idsToChange = new List<string>();
            foreach (FootnoteDisplayModel fdm in testObject.PageFootnotes)
            {
                if (_rnd.NextBoolean())
                {
                    idsToChange.Add(fdm.NoteId);
                }
            }
            Note[] testParameter = GetTestNotes(idsToChange);

            testObject.UpdatePageFootnotes(testParameter);

            Assert.AreEqual(testFootnoteCount, testObject.PageFootnotes.Count);
            for (int i = 0; i < testFootnoteCount; ++i)
            {
                if (idsToChange.Contains(testObject.PageFootnotes[i].NoteId))
                {
                    Assert.AreEqual(testParameter.First(n => n.Id == testObject.PageFootnotes[i].NoteId).Definition, testObject.PageFootnotes[i].Definition);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassUpdatePageFootnotesMethodSetsPageFootnotesElementsSymbolPropertiesIfIdAppearsInParameter()
        {
            TrainSegmentModel testObject = GetTestObject(null);
            int testFootnoteCount = testObject.PageFootnotes.Count;
            List<string> idsToChange = new List<string>();
            foreach (FootnoteDisplayModel fdm in testObject.PageFootnotes)
            {
                if (_rnd.NextBoolean())
                {
                    idsToChange.Add(fdm.NoteId);
                }
            }
            Note[] testParameter = GetTestNotes(idsToChange);

            testObject.UpdatePageFootnotes(testParameter);

            Assert.AreEqual(testFootnoteCount, testObject.PageFootnotes.Count);
            for (int i = 0; i < testFootnoteCount; ++i)
            {
                if (idsToChange.Contains(testObject.PageFootnotes[i].NoteId))
                {
                    Assert.AreEqual(testParameter.First(n => n.Id == testObject.PageFootnotes[i].NoteId).Symbol, testObject.PageFootnotes[i].Symbol);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassUpdatePageFootnotesMethodSetsPageFootnotesElementsDisplayOnPagePropertiesIfIdAppearsInParameter()
        {
            TrainSegmentModel testObject = GetTestObject(null);
            int testFootnoteCount = testObject.PageFootnotes.Count;
            List<string> idsToChange = new List<string>();
            foreach (FootnoteDisplayModel fdm in testObject.PageFootnotes)
            {
                if (_rnd.NextBoolean())
                {
                    idsToChange.Add(fdm.NoteId);
                }
            }
            Note[] testParameter = GetTestNotes(idsToChange);

            testObject.UpdatePageFootnotes(testParameter);

            Assert.AreEqual(testFootnoteCount, testObject.PageFootnotes.Count);
            for (int i = 0; i < testFootnoteCount; ++i)
            {
                if (idsToChange.Contains(testObject.PageFootnotes[i].NoteId))
                {
                    Assert.AreEqual(testParameter.First(n => n.Id == testObject.PageFootnotes[i].NoteId).DefinedOnPages, testObject.PageFootnotes[i].DisplayOnPage);
                }
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNullIfParameterIsLessThanZero()
        {
            int testParam0 = _rnd.Next(int.MaxValue - 1) * -1 - 1;
            int testParam1 = _rnd.Next();
            TrainSegmentModel testObject = GetTestObject(null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNullIfParameterIsZero()
        {
            TrainSegmentModel testObject = GetTestObject(null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(0, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNullIfParameterIsSameAsIndexOfLastTimingEntry()
        {
            TrainSegmentModel testObject = GetTestObject(null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testObject.Timings.Count - 1, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNullIfParameterIsEqualToTimingsPropertyCountProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testObject.Timings.Count, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNullIfParameterIsEqualToOrGreaterThanTimingsPropertyCountProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null);
            int testParam0 = _rnd.Next(int.MaxValue - testObject.Timings.Count) + testObject.Timings.Count;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNonNullResultIfParameterIsGreaterThanZeroAndLessThanFinalIndexOfTimingsProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, _rnd.Next());

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodDoesNotReduceNumberOfTimingsInOriginalSegmentIfOverlapIsEqualToNumberOfTimingsBetweenSplitPointAndEnd()
        {
            TrainSegmentModel testObject = GetTestObject(null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = testObject.Timings.Count - testParam0;
            int timingCount = testObject.Timings.Count;

            TrainSegmentModel train = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(timingCount, testObject.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodDoesNotReduceNumberOfTimingsInOriginalSegmentIfOverlapIsGreaterThanNumberOfTimingsBetweenSplitPointAndEnd()
        {
            TrainSegmentModel testObject = GetTestObject(null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(int.MaxValue - testObject.Timings.Count) + testObject.Timings.Count - testParam0;
            int timingCount = testObject.Timings.Count;

            TrainSegmentModel train = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(timingCount, testObject.Timings.Count);
        }
    }
}
