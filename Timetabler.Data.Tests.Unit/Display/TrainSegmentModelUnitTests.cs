using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class TrainSegmentModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static TrainSegmentModel GetTestObject(int? timings, bool? continuesEarlier, bool? continuesLater, HalfOfDay? definitelyMorning, 
            List<ILocationEntry> additionalTimings = null)
        {
            int pageFootnoteCount = _rnd.Next(10) + 1;
            TrainSegmentModel tsm = new TrainSegmentModel(null)
            {
                Footnotes = _rnd.NextString(_rnd.Next(5)),
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
            TimeOfDay baseTime;
            if (definitelyMorning.HasValue)
            {
                if (definitelyMorning.Value == HalfOfDay.AM)
                {
                    baseTime = _rnd.NextTimeOfDayBefore(43200);
                }
                else if (definitelyMorning.Value == HalfOfDay.PM)
                {
                    baseTime = _rnd.NextTimeOfDayBetween(43200, 86400 - (timingsCount + 2));
                }
                else
                {
                    baseTime = new TimeOfDay(43200);
                }
            }
            else
            {
                baseTime = _rnd.NextTimeOfDayBefore(86400 - (timingsCount + 2));
            }
            for (int i = 0; i < timingsCount; ++i)
            {
                tsm.Timings.Add(new TrainLocationTimeModel { LocationKey = i.ToString(CultureInfo.CurrentCulture), ActualTime = baseTime });
                baseTime = _rnd.NextTimeOfDayBetween(baseTime, 86400 - (timingsCount - i));
            }
            if (additionalTimings != null)
            {
                foreach (ILocationEntry timing in additionalTimings)
                {
                    tsm.Timings.Add(timing);
                }
            }

            return tsm;
        }

        private static Note[] GetTestNotes(IList<string> noteIds)
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

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TrainSegmentModelClass_ConstructorWithTrainAndListOfILocationEntryParameters_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            _ = new TrainSegmentModel(null, null);

            Assert.Fail();
        }

        [TestMethod]
        public void TrainSegmentModelClass_ConstructorWithTrainAndListOfILocationEntryParameters_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            try
            {
                TrainSegmentModel testObject = new TrainSegmentModel(null, null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("train", ex.ParamName);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_HalfOfDayProperty_HasCorrectValue_IfFirstTimingPointIsInMorning()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, HalfOfDay.AM);

            string testOutput = testObject.HalfOfDay;

            Assert.AreEqual("a.m.", testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClass_HalfOfDayProperty_HasCorrectValue_IfFirstTimingPointIsInAfternoon()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, HalfOfDay.PM);

            string testOutput = testObject.HalfOfDay;

            Assert.AreEqual("P.M.", testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClass_HalfOfDayProperty_HasCorrectValue_IfFirstTimingPointIsAtNoon()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, HalfOfDay.Noon);

            string testOutput = testObject.HalfOfDay;

            Assert.AreEqual("noon", testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClass_UpdatePageFootnotesMethod_DoesNotChangePageFootnotesProperty_IfParameterIsNull()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
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
        public void TrainSegmentModelClass_UpdatePageFootnotesMethod_DoesNotChangePageFootnotesProperty_IfParameterIsEmpty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testFootnoteCount = testObject.PageFootnotes.Count;
            List<FootnoteDisplayModel> pageFootnotesCopy = testObject.PageFootnotes.ToList();

            testObject.UpdatePageFootnotes(Array.Empty<Note>());

            Assert.AreEqual(testFootnoteCount, testObject.PageFootnotes.Count);
            for (int i = 0; i < testFootnoteCount; ++i)
            {
                FootnoteDisplayModelHelpers.FullEqualityTest(pageFootnotesCopy[i], testObject.PageFootnotes[i]);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_UpdatePageFootnotesMethod_ChangesPageFootnotesElementsWithIdsThatAppearInParameter()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
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
        public void TrainSegmentModelClass_UpdatePageFootnotesMethod_SetsPageFootnotesElementsDefinitionProperties_IfIdAppearsInParameter()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
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
        public void TrainSegmentModelClass_UpdatePageFootnotesMethod_SetsPageFootnotesElementsSymbolProperties_IfIdAppearsInParameter()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
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
        public void TrainSegmentModelClass_UpdatePageFootnotesMethod_SetsPageFootnotesElementsDisplayOnPageProperties_IfIdAppearsInParameter()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
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
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectFootnotesProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Footnotes, testOutput.Footnotes);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectHalfOfDayProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.HalfOfDay, testOutput.HalfOfDay);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectHeadcodeProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Headcode, testOutput.Headcode);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectIncludeSeparatorAboveProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            
            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.IncludeSeparatorAbove, testOutput.IncludeSeparatorAbove);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectIncludeSeparatorBelowProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.IncludeSeparatorBelow, testOutput.IncludeSeparatorBelow);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectInlineNoteProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.InlineNote, testOutput.InlineNote);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectLocoDiagramProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LocoDiagram, testOutput.LocoDiagram);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectTrainClassProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.TrainClass, testOutput.TrainClass);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectTrainIdProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.TrainId, testOutput.TrainId);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectContinuationFromEarlierProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ContinuationFromEarlier, testOutput.ContinuationFromEarlier);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithCorrectContinuesLaterProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ContinuesLater, testOutput.ContinuesLater);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithTimingsPropertyOfCorrectLength()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Timings.Count, testOutput.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithTimingsPropertyWithContentsWithCorrectLocationKeyProperties()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            for (int i = 0; i < testOutput.Timings.Count; ++i)
            {
                Assert.AreEqual(testObject.Timings[i].LocationKey, testOutput.Timings[i].LocationKey);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithToWorkCellPropertyWithCorrectActualTimeProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ToWorkCell.ActualTime, testOutput.ToWorkCell.ActualTime);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithToWorkCellPropertyWithCorrectDisplayedTextProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ToWorkCell.DisplayedText, testOutput.ToWorkCell.DisplayedText);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithPageFootnotesPropertyOfCorrectLength()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.PageFootnotes.Count, testOutput.PageFootnotes.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectNoteIdProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            for (int i = 0; i < testObject.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].NoteId, testOutput.PageFootnotes[i].NoteId);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectSymbolProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            for (int i = 0; i < testObject.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].Symbol, testOutput.PageFootnotes[i].Symbol);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectDefinitionProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            for (int i = 0; i < testObject.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].Definition, testOutput.PageFootnotes[i].Definition);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_CopyMethod_ReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectDisplayOnPageProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.Copy();

            for (int i = 0; i < testObject.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].DisplayOnPage, testOutput.PageFootnotes[i].DisplayOnPage);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsNull_IfParameterIsLessThanZero()
        {
            int testParam0 = _rnd.Next(int.MaxValue - 1) * -1 - 1;
            int testParam1 = _rnd.Next();
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsNull_IfParameterIsZero()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(0, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsNull_IfParameterIsSameAsIndexOfLastTimingEntry()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testObject.Timings.Count - 1, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsNull_IfParameterIsEqualToTimingsPropertyCountProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testObject.Timings.Count, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsNull_IfParameterIsEqualToOrGreaterThanTimingsPropertyCountProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(int.MaxValue - testObject.Timings.Count) + testObject.Timings.Count;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, _rnd.Next());

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsNonNullResult_IfParameterIsGreaterThanZeroAndLessThanFinalIndexOfTimingsProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, _rnd.Next());

            Assert.IsNotNull(testOutput);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_DoesNotReduceNumberOfTimingsInOriginalSegment_IfOverlapIsEqualToNumberOfTimingsBetweenSplitPointAndEnd()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = testObject.Timings.Count - testParam0;
            int timingCount = testObject.Timings.Count;

            _ = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(timingCount, testObject.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_DoesNotReduceNumberOfTimingsInOriginalSegmentIfOverlapIsGreaterThanNumberOfTimingsBetweenSplitPointAndEnd()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(int.MaxValue - testObject.Timings.Count) + testObject.Timings.Count - testParam0;
            int timingCount = testObject.Timings.Count;

            _ = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(timingCount, testObject.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReducesNumberOfTimingsInOriginalSegment_IfSplitPointPlusOverlapIsLessThanTotalNumberOfTimings()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            int timingCount = testObject.Timings.Count;

            _ = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.IsTrue(testObject.Timings.Count < timingCount);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReducesNumberOfTimingsInOriginalSegmentToSplitPointPlusOverlap()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            _ = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testParam0 + testParam1, testObject.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_KeepsCorrectTimingsInOriginalSegment()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
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
        public void TrainSegmentModelClass_SplitAtIndexMethod_SetsContinuesLaterPropertyOfOriginalSegmentToTrue()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, false, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            _ = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.IsTrue(testObject.ContinuesLater);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithCorrectFootnotesProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.Footnotes, testOutput.Footnotes);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithCorrectHeadcodeProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.Headcode, testOutput.Headcode);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithCorrectIncludeSeparatorBelowProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.IncludeSeparatorBelow, testOutput.IncludeSeparatorBelow);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithCorrectInlineNoteProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            string savedNote = testObject.InlineNote;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(savedNote, testOutput.InlineNote);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_SetsInlineNotePropertyOfParameterToEmptyString()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            _ = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual("", testObject.InlineNote);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithCorrectLocoDiagramProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.LocoDiagram, testOutput.LocoDiagram);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithCorrectTrainClassProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.TrainClass, testOutput.TrainClass);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithCorrectTrainIdProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.TrainId, testOutput.TrainId);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithCorrectContinuesLaterProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            bool originalContinuesLater = testObject.ContinuesLater;

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(originalContinuesLater, testOutput.ContinuesLater);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithContinuationFromEarlierPropertyEqualToTrue()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.IsTrue(testOutput.ContinuationFromEarlier);
        }

        // all PageFootnotes tests of TrainSegmentModel.SplitAtIndex() pass with the current behaviour, which is suspected to be wrong.
        // See GitHub issue #87

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithPageFootnotesPropertyOfCorrectLength()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(testObject.PageFootnotes.Count, testOutput.PageFootnotes.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectNoteIdProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testOutput.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].NoteId, testOutput.PageFootnotes[i].NoteId);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectSymbolProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testOutput.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].Symbol, testOutput.PageFootnotes[i].Symbol);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectDefinitionProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testOutput.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].Definition, testOutput.PageFootnotes[i].Definition);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithPageFootnotesPropertyContainingObjectsWithCorrectDisplayOnPageProperty()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testOutput.PageFootnotes.Count; ++i)
            {
                Assert.AreEqual(testObject.PageFootnotes[i].DisplayOnPage, testOutput.PageFootnotes[i].DisplayOnPage);
            }
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithCorrectNumberOfTimings()
        {
            // The correct number of timings is: the number of elements from the split point to the end.
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            List<ILocationEntry> savedTimings = testObject.Timings.Select(t => t.Copy()).ToList();

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            Assert.AreEqual(savedTimings.Count - testParam0, testOutput.Timings.Count);
        }

        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithTimingsPropertyWithObjectsContainingCorrectLocationKeys()
        {
            TrainSegmentModel testObject = GetTestObject(null, null, null, null);
            int testParam0 = _rnd.Next(testObject.Timings.Count - 2) + 1;
            int testParam1 = _rnd.Next(testObject.Timings.Count - testParam0);
            List<ILocationEntry> savedTimings = testObject.Timings.Select(t => t.Copy()).ToList();

            TrainSegmentModel testOutput = testObject.SplitAtIndex(testParam0, testParam1);

            for (int i = 0; i < testOutput.Timings.Count; ++i)
            {
                Assert.AreEqual(savedTimings[i + testParam0].LocationKey, testOutput.Timings[i].LocationKey);
            }
        }

        // Exercises GitHub issue #84.
        [TestMethod]
        public void TrainSegmentModelClass_SplitAtIndexMethod_ReturnsObjectWithCorrectHalfOfDayProperty_IfSplitIsAfterMidday()
        {
            TrainSegmentModel testObject = GetTestObject(0, null, null, null, new List<ILocationEntry>
            {
                new TrainLocationTimeModel { LocationKey = "A", ActualTime = new TimeOfDay(11, 0) },
                new TrainLocationTimeModel { LocationKey = "B", ActualTime = new TimeOfDay(11, 30) },
                new TrainLocationTimeModel { LocationKey = "C", ActualTime = new TimeOfDay(12, 10) },
                new TrainLocationTimeModel { LocationKey = "D", ActualTime = new TimeOfDay(12, 15) },
            });

            TrainSegmentModel testOutput = testObject.SplitAtIndex(2, 1);

            Assert.AreEqual("P.M.", testOutput.HalfOfDay);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
