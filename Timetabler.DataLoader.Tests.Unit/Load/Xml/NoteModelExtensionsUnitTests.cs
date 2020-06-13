using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class NoteModelExtensionsUnitTests
    {
        private static readonly Random _random = RandomProvider.Default;

        private static NoteModel GetRandomNoteModel()
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

#pragma warning disable CA1707 // Identifiers should not contain underscores
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoteModelExtensionsClass_ToNoteMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            NoteModel testObject = null;

            _ = testObject.ToNote();

            Assert.Fail();
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            NoteModel testObject = null;

            try
            {
                _ = testObject.ToNote();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
            }
        }
        
        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObject_IfParameterIsNotNull()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.IsNotNull(testResult);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectIdProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.Id, testResult.Id);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectSymbolProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.Symbol, testResult.Symbol);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectDefinitionProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.Definition, testResult.Definition);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectAppliesToTrainsProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.AppliesToTrains, testResult.AppliesToTrains);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectAppliesToTimingsProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.AppliesToTimings, testResult.AppliesToTimings);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectDefinedInGlossaryProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.DefinedInGlossary, testResult.DefinedInGlossary);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectDefinedOnPagesProperty()
        {
            NoteModel testObject = GetRandomNoteModel();

            Note testResult = testObject.ToNote();

            Assert.AreEqual(testObject.DefinedOnPages, testResult.DefinedOnPages);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
