using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.Data.Tests.Utility.Extensions;
using Timetabler.DataLoader.Save.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Yaml
{
    [TestClass]
    public class NoteExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static Note GetTestObject()
        {
            return _rnd.NextNote();
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NoteExtensionsClass_ToYamlNoteModelMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            Note testParam = null;

            _ = testParam.ToYamlNoteModel();

            Assert.Fail();
        }

        [TestMethod]
        public void NoteExtensionsClass_ToYamlNoteModelMethod_ReturnsObjectWithCorrectIdProperty_IfParameterIsNotNull()
        {
            Note testParam = GetTestObject();

            NoteModel testOutput = testParam.ToYamlNoteModel();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        public void NoteExtensionsClass_ToYamlNoteModelMethod_ReturnsObjectWithCorrectSymbolProperty_IfParameterIsNotNull()
        {
            Note testParam = GetTestObject();

            NoteModel testOutput = testParam.ToYamlNoteModel();

            Assert.AreEqual(testParam.Symbol, testOutput.Symbol);
        }

        [TestMethod]
        public void NoteExtensionsClass_ToYamlNoteModelMethod_ReturnsObjectWithCorrectAppliesToTimingsProperty_IfParameterIsNotNull()
        {
            Note testParam = GetTestObject();

            NoteModel testOutput = testParam.ToYamlNoteModel();

            Assert.AreEqual(testParam.AppliesToTimings, testOutput.AppliesToTimings);
        }

        [TestMethod]
        public void NoteExtensionsClass_ToYamlNoteModelMethod_ReturnsObjectWithCorrectAppliesToTrainsProperty_IfParameterIsNotNull()
        {
            Note testParam = GetTestObject();

            NoteModel testOutput = testParam.ToYamlNoteModel();

            Assert.AreEqual(testParam.AppliesToTrains, testOutput.AppliesToTrains);
        }

        [TestMethod]
        public void NoteExtensionsClass_ToYamlNoteModelMethod_ReturnsObjectWithCorrectDefinedInGlossaryProperty_IfParameterIsNotNull()
        {
            Note testParam = GetTestObject();

            NoteModel testOutput = testParam.ToYamlNoteModel();

            Assert.AreEqual(testParam.DefinedInGlossary, testOutput.DefinedInGlossary);
        }

        [TestMethod]
        public void NoteExtensionsClass_ToYamlNoteModelMethod_ReturnsObjectWithCorrectDefinedOnPagesProperty_IfParameterIsNotNull()
        {
            Note testParam = GetTestObject();

            NoteModel testOutput = testParam.ToYamlNoteModel();

            Assert.AreEqual(testParam.DefinedOnPages, testOutput.DefinedOnPages);
        }

        [TestMethod]
        public void NoteExtensionsClass_ToYamlNoteModelMethod_ReturnsObjectWithCorrectDefinitionProperty_IfParameterIsNotNull()
        {
            Note testParam = GetTestObject();

            NoteModel testOutput = testParam.ToYamlNoteModel();

            Assert.AreEqual(testParam.Definition, testOutput.Definition);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
