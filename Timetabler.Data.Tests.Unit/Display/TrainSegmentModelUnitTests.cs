using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class TrainSegmentModelUnitTests
    {
        private static Random _rnd = new Random();

        private TrainSegmentModel GetTestObject(int? timings, bool? continuesEarlier, bool? continuesLater)
        {
            int pageFootnoteCount = _rnd.Next(10) + 1;
            TrainSegmentModel tsm = new TrainSegmentModel
            {
                Footnotes = _rnd.NextString(_rnd.Next(5)),
                HalfOfDay = _rnd.NextString(4),
                Headcode = _rnd.NextString(4),
                IncludeSeparatorAbove = _rnd.NextBoolean(),
                IncludeSeparatorBelow = _rnd.NextBoolean(),
                InlineNote = _rnd.NextString(_rnd.Next(50)),
                LocoDiagram = _rnd.NextString(_rnd.Next(4)),
                TrainClass = _rnd.NextString(1),
                TrainId = _rnd.NextHexString(8),
                ContinuationFromEarlier = continuesEarlier ?? _rnd.NextBoolean(),
                ContinuesLater = continuesLater ?? _rnd.NextBoolean(),
                ToWorkCell = new GenericTimeModel { ActualTime = _rnd.NextTimeOfDay(), DisplayedText = _rnd.NextString(_rnd.Next(5)) },
            };
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
            TrainSegmentModel testObject = GetTestObject(null, null, null);
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
            TrainSegmentModel testObject = GetTestObject(null, null, null);
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
            TrainSegmentModel testObject = GetTestObject(null, null, null);
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
            TrainSegmentModel testObject = GetTestObject(null, null, null);
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
            TrainSegmentModel testObject = GetTestObject(null, null, null);
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
            TrainSegmentModel testObject = GetTestObject(null, null, null);
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
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectFootnotesProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Footnotes, testOutput.Footnotes);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectHalfOfDayProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.HalfOfDay, testOutput.HalfOfDay);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectHeadcodeProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Headcode, testOutput.Headcode);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectIncludeSeparatorAboveProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            
            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.IncludeSeparatorAbove, testOutput.IncludeSeparatorAbove);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectIncludeSeparatorBelowProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.IncludeSeparatorBelow, testOutput.IncludeSeparatorBelow);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectInlineNoteProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.InlineNote, testOutput.InlineNote);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectLocoDiagramProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocoDiagram, testOutput.LocoDiagram);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectTrainClassProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.TrainClass, testOutput.TrainClass);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectTrainIdProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.TrainId, testOutput.TrainId);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectContinuationFromEarlierProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ContinuationFromEarlier, testOutput.ContinuationFromEarlier);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithCorrectContinuesLaterProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ContinuesLater, testOutput.ContinuesLater);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithTimingsPropertyOfCorrectLength()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Timings.Count, testOutput.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithTimingsPropertyWithContentsWithCorrectLocationKeyProperties()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.Timings.Count; ++i)
            {
                Assert.AreEqual(testObject.Timings[i].LocationKey, testOutput.Timings[i].LocationKey);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithToWorkCellPropertyWithCorrectActualTimeProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ToWorkCell.ActualTime, testOutput.ToWorkCell.ActualTime);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithToWorkCellPropertyWithCorrectDisplayedTextProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ToWorkCell.DisplayedText, testOutput.ToWorkCell.DisplayedText);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithPageFootnotesPropertyOfCorrectLength()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.PageFootnotes.Count, testOutput.PageFootnotes.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectNoteIdProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            for (int i = 0; i < testObject.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].NoteId, testOutput.PageFootnotes[i].NoteId);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectSymbolProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            for (int i = 0; i < testObject.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].Symbol, testOutput.PageFootnotes[i].Symbol);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectDefinitionProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            for (int i = 0; i < testObject.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].Definition, testOutput.PageFootnotes[i].Definition);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassCopyMethodReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectDisplayOnPageProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            for (int i = 0; i < testObject.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].DisplayOnPage, testOutput.PageFootnotes[i].DisplayOnPage);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNullIfParameterIsLessThanZero()
        {
            int testParam0 = _rnd.Next(int.MaxValue - 1) * -1 - 1;
            int testParam1 = _rnd.Next();
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNullIfParameterIsZero()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(0, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNullIfParameterIsSameAsIndexOfLastTimingEntry()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testObject.Timings.Count - 1, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNullIfParameterIsEqualToTimingsPropertyCountProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testObject.Timings.Count, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNullIfParameterIsEqualToOrGreaterThanTimingsPropertyCountProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(int.MaxValue - testObject.Timings.Count) + testObject.Timings.Count;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsNonNullResultIfParameterIsGreaterThanZeroAndLessThanFinalIndexOfTimingsProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, _rnd.Next());

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodDoesNotReduceNumberOfTimingsInOriginalSegmentIfOverlapIsEqualToNumberOfTimingsBetweenSplitPointAndEnd()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = testObject.Timings.Count - testParam0;
            int timingCount = testObject.Timings.Count;

            TrainSegmentModel train = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(timingCount, testObject.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodDoesNotReduceNumberOfTimingsInOriginalSegmentIfOverlapIsGreaterThanNumberOfTimingsBetweenSplitPointAndEnd()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(int.MaxValue - testObject.Timings.Count) + testObject.Timings.Count - testParam0;
            int timingCount = testObject.Timings.Count;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(timingCount, testObject.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReducesNumberOfTimingsInOriginalSegmentIfSplitPointPlusOverlapIsLessThanTotalNumberOfTimings()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            int timingCount = testObject.Timings.Count;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.IsTrue(testObject.Timings.Count < timingCount);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReducesNumberOfTimingsInOriginalSegmentToSplitPointPlusOverlap()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testParam0 + testParam1, testObject.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodKeepsCorrectTimingsInOriginalSegment()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            List<ILocationEntry> savedTimings = testObject.Timings.Select(t => t.Copy()).ToList();

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testObject.Timings.Count; ++i)
            {
                Assert.AreEqual(savedTimings[i].LocationKey, testObject.Timings[i].LocationKey);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodSetsContinuesLaterPropertyOfOriginalSegmentToTrue()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, false);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.IsTrue(testObject.ContinuesLater);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithCorrectFootnotesProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.Footnotes, testOutput.Footnotes);
        }

        // FIXME this tests to the code, but does not at present return the correct result in cases where the segment crosses noon.  See GitHub ticket #84
        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithCorrectHalfOfDayProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            var savedTimings = testObject.Timings.Select(t => t.Copy()).ToList();

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.HalfOfDay, testOutput.HalfOfDay);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithCorrectHeadcodeProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.Headcode, testOutput.Headcode);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithCorrectIncludeSeparatorBelowProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.IncludeSeparatorBelow, testOutput.IncludeSeparatorBelow);
        }

        // FIXME this raises a question - the note should only appear on one of the two segments, but which one?  See GitHub ticket #85
        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithCorrectInlineNoteProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.InlineNote, testOutput.InlineNote);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithCorrectLocoDiagramProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.LocoDiagram, testOutput.LocoDiagram);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithCorrectTrainClassProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.TrainClass, testOutput.TrainClass);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithCorrectTrainIdProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.TrainId, testOutput.TrainId);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithCorrectContinuesLaterProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            bool originalContinuesLater = testObject.ContinuesLater;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(originalContinuesLater, testOutput.ContinuesLater);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithContinuationFromEarlierPropertyEqualToTrue()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.IsTrue(testOutput.ContinuationFromEarlier);
        }

        // all PageFootnotes tests of TrainSegmentModel.SplitAtIndex() pass with the current behaviour, which is suspected to be wrong.
        // See GitHub issue #87

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithPageFootnotesPropertyOfCorrectLength()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.PageFootnotes.Count, testOutput.PageFootnotes.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectNoteIdProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testOutput.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].NoteId, testOutput.PageFootnotes[i].NoteId);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectSymbolProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testOutput.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].Symbol, testOutput.PageFootnotes[i].Symbol);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectDefinitionProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testOutput.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].Definition, testOutput.PageFootnotes[i].Definition);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectDisplayOnPageProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testOutput.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].DisplayOnPage, testOutput.PageFootnotes[i].DisplayOnPage);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithCorrectNumberOfTimings()
        {
            // The correct number of timings is: the number of elements from the split point to the end.
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            List<ILocationEntry> savedTimings = testObject.Timings.Select(t => t.Copy()).ToList();

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(savedTimings.Count - testParam0, testOutput.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClassSplitAtIndexMethodReturnsObjectWithTimingsPropertyWithObjectsContainingCorrectLocationKeys()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            List<ILocationEntry> savedTimings = testObject.Timings.Select(t => t.Copy()).ToList();

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testOutput.Timings.Count; ++i)
            {
                Assert.AreEqual(savedTimings[i + testParam0].LocationKey, testOutput.Timings[i].LocationKey);
            }
        }
    }
}
