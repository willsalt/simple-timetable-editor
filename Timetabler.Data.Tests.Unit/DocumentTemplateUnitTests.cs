using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Tests.Utility.Providers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class DocumentTemplateUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static List<Location> GetLocations()
        {
            List<Location> result = new List<Location>();
            int count = _rnd.Next(50);
            for (int i = 0; i < count; ++i)
            {
                result.Add(new Location());
            }
            return result;
        }

        private static List<Note> GetNoteDefinitions()
        {
            List<Note> result = new List<Note>();
            int count = _rnd.Next(50);
            for (int i = 0; i < count; ++i)
            {
                result.Add(new Note());
            }
            return result;
        }

        private static List<TrainClass> GetTrainClasses()
        {
            List<TrainClass> result = new List<TrainClass>();
            int count = _rnd.Next(16);
            for (int i = 0; i < count; ++i)
            {
                result.Add(new TrainClass());
            }
            return result;
        }

        private static List<Signalbox> GetSignalboxes()
        {
            List<Signalbox> result = new List<Signalbox>();
            int count = _rnd.Next(50);
            for (int i = 0; i < count; ++i)
            {
                result.Add(new Signalbox());
            }
            return result;
        }

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DocumentTemplateClass_Constructor_CreatesObjectWithEmptyLocationsProperty_IfFirstParameterIsNull()
        {
            DocumentTemplate testObject = new DocumentTemplate(null, GetNoteDefinitions(), GetTrainClasses(), GetSignalboxes());

            Assert.IsNotNull(testObject.Locations);
            Assert.AreEqual(0, testObject.Locations.Count);
        }

        [TestMethod]
        public void DocumentTemplateClass_Constructor_CreatesObjectWithLocationsPropertyWithCorrectContents_IfFirstParameterIsNotNull()
        {
            List<Location> testParam0 = GetLocations();
            DocumentTemplate testObject = new DocumentTemplate(testParam0, GetNoteDefinitions(), GetTrainClasses(), GetSignalboxes());

            Assert.IsNotNull(testObject.Locations);
            Assert.AreEqual(testParam0.Count, testObject.Locations.Count);
            for (int i = 0; i < testParam0.Count; ++i)
            {
                Assert.AreSame(testParam0[i], testObject.Locations[i]);
            }
        }

        [TestMethod]
        public void DocumentTemplateClass_Constructor_CreatesObjectWithEmptyNoteDefinitionsProperty_IfSecondParameterIsNull()
        {
            DocumentTemplate testObject = new DocumentTemplate(GetLocations(), null, GetTrainClasses(), GetSignalboxes());

            Assert.IsNotNull(testObject.NoteDefinitions);
            Assert.AreEqual(0, testObject.NoteDefinitions.Count);
        }

        [TestMethod]
        public void DocumentTemplateClass_Constructor_CreatesObjectWithNoteDefinitionsPropertyWithCorrectContents_IfSecondParameterIsNotNull()
        {
            List<Note> testParam1 = GetNoteDefinitions();
            DocumentTemplate testObject = new DocumentTemplate(GetLocations(), testParam1, GetTrainClasses(), GetSignalboxes());

            Assert.IsNotNull(testObject.NoteDefinitions);
            Assert.AreEqual(testParam1.Count, testObject.NoteDefinitions.Count);
            for (int i = 0; i < testParam1.Count; ++i)
            {
                Assert.AreSame(testParam1[i], testObject.NoteDefinitions[i]);
            }
        }

        [TestMethod]
        public void DocumentTemplateClass_Constructor_CreatesObjectWithEmptyTrainClassesProperty_IfThirdParameterIsNull()
        {
            DocumentTemplate testObject = new DocumentTemplate(GetLocations(), GetNoteDefinitions(), null, GetSignalboxes());

            Assert.IsNotNull(testObject.TrainClasses);
            Assert.AreEqual(0, testObject.TrainClasses.Count);
        }

        [TestMethod]
        public void DocumentTemplateClass_Constructor_CreatesObjectWithTrainClassesPropertyWithCorrectContents_IfThirdParameterIsNotNull()
        {
            List<TrainClass> testParam2 = GetTrainClasses();
            DocumentTemplate testObject = new DocumentTemplate(GetLocations(), GetNoteDefinitions(), testParam2, GetSignalboxes());

            Assert.IsNotNull(testObject.TrainClasses);
            Assert.AreEqual(testParam2.Count, testObject.TrainClasses.Count);
            for (int i = 0; i < testParam2.Count; ++i)
            {
                Assert.AreSame(testParam2[i], testObject.TrainClasses[i]);
            }
        }

        [TestMethod]
        public void DocumentTemplateClass_Constructor_CreatesObjectWithEmptySignalboxesProperty_IfFourthParameterIsNull()
        {
            DocumentTemplate testObject = new DocumentTemplate(GetLocations(), GetNoteDefinitions(), GetTrainClasses(), null);

            Assert.IsNotNull(testObject.Signalboxes);
            Assert.AreEqual(0, testObject.Signalboxes.Count);
        }

        [TestMethod]
        public void DocumentTemplateClass_Constructor_CreatesObjectWithSignalboxesPropertyWithCorrectContent_IfFourthParameterIsNotNull()
        {
            List<Signalbox> testParam3 = GetSignalboxes();
            DocumentTemplate testObject = new DocumentTemplate(GetLocations(), GetNoteDefinitions(), GetTrainClasses(), testParam3);

            Assert.IsNotNull(testObject.Signalboxes);
            Assert.AreEqual(testParam3.Count, testObject.Signalboxes.Count);
            for (int i = 0; i < testParam3.Count; ++i)
            {
                Assert.AreSame(testParam3[i], testObject.Signalboxes[i]);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
