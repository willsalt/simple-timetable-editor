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

        private TrainSegmentModel GetTestObject()
        {
            int pageFootnoteCount = _rnd.Next(10) + 1;
            TrainSegmentModel tsm = new TrainSegmentModel();
            for (int i = 0; i < pageFootnoteCount; ++i)
            {
                tsm.PageFootnotes.Add(FootnoteDisplayModelHelpers.GetFootnoteDisplayModel());
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
            TrainSegmentModel testObject = GetTestObject();
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
            TrainSegmentModel testObject = GetTestObject();
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
            TrainSegmentModel testObject = GetTestObject();
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
            TrainSegmentModel testObject = GetTestObject();
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
            TrainSegmentModel testObject = GetTestObject();
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
            TrainSegmentModel testObject = GetTestObject();
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
    }
}
