using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class NoteModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static NoteModel GetModel()
        {
            return new NoteModel
            {
                Id = _rnd.NextHexString(8),
                Symbol = _rnd.NextString(_rnd.Next(4)),
                Definition = _rnd.NextString(_rnd.Next(120)),
                AppliesToTimings = _rnd.NextNullableBoolean(),
                AppliesToTrains = _rnd.NextNullableBoolean(),
                DefinedInGlossary = _rnd.NextNullableBoolean(),
                DefinedOnPages = _rnd.NextNullableBoolean(),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NoteModelExtensionsClass_ToNoteMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            NoteModel testParam = null;

            _ = testParam.ToNote();

            Assert.Fail();
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectIdProperty_IfParameterIsNotNull()
        {
            NoteModel testParam = GetModel();

            Note testOutput = testParam.ToNote();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NoteModelExtensionsClass_ToNoteMethod_ThrowsArgumentException_IfParameterIsNotNullAndIdPropertyOfParameterIsNull()
        {
            NoteModel testParam = GetModel();
            testParam.Id = null;

            _ = testParam.ToNote();

            Assert.Fail();
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectSymbolProperty_IfParameterIsNotNull()
        {
            NoteModel testParam = GetModel();

            Note testOutput = testParam.ToNote();

            Assert.AreEqual(testParam.Symbol, testOutput.Symbol);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectDefinitionProperty_IfParameterIsNotNull()
        {
            NoteModel testParam = GetModel();

            Note testOutput = testParam.ToNote();

            Assert.AreEqual(testParam.Definition, testOutput.Definition);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectAppliesToTrainsProperty_IfParameterHasAppliesToTrainsPropertyThatIsNotNull()
        {
            NoteModel testParam = GetModel();
            testParam.AppliesToTrains = _rnd.NextBoolean();

            Note testOutput = testParam.ToNote();

            Assert.AreEqual(testParam.AppliesToTrains.Value, testOutput.AppliesToTrains);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithAppliesToTrainsPropertyEqualToFalse_IfParameterHasAppliesToTrainsPropertyThatIsNull()
        {
            NoteModel testParam = GetModel();
            testParam.AppliesToTrains = null;

            Note testOutput = testParam.ToNote();

            Assert.IsFalse(testOutput.AppliesToTrains);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectAppliesToTimingsProperty_IfParameterHasAppliesToTimingsPropertyThatIsNotNull()
        {
            NoteModel testParam = GetModel();
            testParam.AppliesToTimings = _rnd.NextBoolean();

            Note testOutput = testParam.ToNote();

            Assert.AreEqual(testParam.AppliesToTimings.Value, testOutput.AppliesToTimings);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithAppliesToTimingsPropertyEqualToFalse_IfParameterHasAppliesToTimingsPropertyThatIsNull()
        {
            NoteModel testParam = GetModel();
            testParam.AppliesToTimings = null;

            Note testOutput = testParam.ToNote();

            Assert.IsFalse(testOutput.AppliesToTimings);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectDefinedInGlossaryProperty_IfParameterHasDefinedInGlossaryPropertyThatIsNotNull()
        {
            NoteModel testParam = GetModel();
            testParam.DefinedInGlossary = _rnd.NextBoolean();

            Note testOutput = testParam.ToNote();

            Assert.AreEqual(testParam.DefinedInGlossary.Value, testOutput.DefinedInGlossary);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithDefinedInGlossaryPropertyEqualToFalse_IfParameterHasDefinedInGlossaryPropertyThatIsNull()
        {
            NoteModel testParam = GetModel();
            testParam.DefinedInGlossary = null;

            Note testOutput = testParam.ToNote();

            Assert.IsFalse(testOutput.DefinedInGlossary);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithCorrectDefinedOnPagesProperty_IfParameterHasDefinedOnPagesPropertyThatIsNotNull()
        {
            NoteModel testParam = GetModel();
            testParam.DefinedOnPages = _rnd.NextBoolean();

            Note testOutput = testParam.ToNote();

            Assert.AreEqual(testParam.DefinedOnPages.Value, testOutput.DefinedOnPages);
        }

        [TestMethod]
        public void NoteModelExtensionsClass_ToNoteMethod_ReturnsObjectWithDefinedOnPagesPropertyEqualToFalse_IfParameterHasDefinedOnPagesPropertyThatIsNull()
        {
            NoteModel testParam = GetModel();
            testParam.DefinedOnPages = null;

            Note testOutput = testParam.ToNote();

            Assert.IsFalse(testOutput.DefinedOnPages);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
