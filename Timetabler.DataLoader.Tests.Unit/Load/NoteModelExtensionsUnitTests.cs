using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Timetabler.Data;
using Timetabler.DataLoader.Load;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Tests.Unit.Load
{
    [TestClass]
    public class NoteModelExtensionsUnitTests
    {
        private Random _random;

        public NoteModelExtensionsUnitTests()
        {
            _random = new Random();
        }

        private NoteModel GetRandomNoteModel()
        {
            return new NoteModel
            {
                AppliesToTimings = _random.NextBoolean(),
                AppliesToTrains = _random.NextBoolean(),
                DefinedInGlossary = _random.NextBoolean(),
                DefinedOnPages = _random.NextBoolean(),
                Definition = _random.NextString(_random.Next(128)),
                Id = _random.NextHexString(8),
                Symbol = _random.NextString(1),
            };
        }

        [TestMethod]
        public void NoteModelExtensionsClassToNoteMethodReturnsObjectIfParameterIsNotNull()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.IsNotNull(testResult);
        }

        [TestMethod]
        public void NoteModelExtensionsClassToNoteMethodReturnsObjectWithCorrectIdProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.Id, testResult.Id);
        }

        [TestMethod]
        public void NoteModelExtensionsClassToNoteMethodReturnsObjectWithCorrectSymbolProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.Symbol, testResult.Symbol);
        }

        [TestMethod]
        public void NoteModelExtensionsClassToNoteMethodReturnsObjectWithCorrectDefinitionProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.Definition, testResult.Definition);
        }

        [TestMethod]
        public void NoteModelExtensionsClassToNoteMethodReturnsObjectWithCorrectAppliesToTrainsProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.AppliesToTrains, testResult.AppliesToTrains);
        }

        [TestMethod]
        public void NoteModelExtensionsClassToNoteMethodReturnsObjectWithCorrectAppliesToTimingsProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.AppliesToTimings, testResult.AppliesToTimings);
        }

        [TestMethod]
        public void NoteModelExtensionsClassToNoteMethodReturnsObjectWithCorrectDefinedInGlossaryProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.DefinedInGlossary, testResult.DefinedInGlossary);
        }

        [TestMethod]
        public void NoteModelExtensionsClassToNoteMethodReturnsObjectWithCorrectDefinedOnPagesProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.DefinedOnPages, testResult.DefinedOnPages);
        }
    }
}
