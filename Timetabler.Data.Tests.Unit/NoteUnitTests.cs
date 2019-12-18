using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data.Display;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class NoteUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoteClass_CopyToMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Note testObject = NoteHelpers.GetNote();

            testObject.CopyTo(null);

            Assert.Fail();
        }

        [TestMethod]
        public void NoteClass_CopyToMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Note testObject = NoteHelpers.GetNote();

            try
            {
                testObject.CopyTo(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("target", ex.ParamName);
            }
        }

        [TestMethod]
        public void NoteClass_ToFootnoteDisplayModelMethod_ReturnsFootnoteDisplayModelWithCorrectNoteIdProperty()
        {
            Note testObject = NoteHelpers.GetNote();

            FootnoteDisplayModel testOutput = testObject.ToFootnoteDisplayModel();

            Assert.AreEqual(testObject.Id, testOutput.NoteId);
        }

        [TestMethod]
        public void NoteClass_ToFootnoteDisplayModelMethod_ReturnsFootnoteDisplayModelWithCorrectSymbolProperty()
        {
            Note testObject = NoteHelpers.GetNote();

            FootnoteDisplayModel testOutput = testObject.ToFootnoteDisplayModel();

            Assert.AreEqual(testObject.Symbol, testOutput.Symbol);
        }

        [TestMethod]
        public void NoteClass_ToFootnoteDisplayModelMethod_ReturnsFootnoteDisplayModelWithCorrectDefinitionProperty()
        {
            Note testObject = NoteHelpers.GetNote();

            FootnoteDisplayModel testOutput = testObject.ToFootnoteDisplayModel();

            Assert.AreEqual(testObject.Definition, testOutput.Definition);
        }

        [TestMethod]
        public void NoteClass_ToFootnoteDisplayModelMethod_ReturnsFootnoteDisplayModelWithCorrectDisplayOnPagesProperty()
        {
            Note testObject = NoteHelpers.GetNote();

            FootnoteDisplayModel testOutput = testObject.ToFootnoteDisplayModel();

            Assert.AreEqual(testObject.DefinedOnPages, testOutput.DisplayOnPage);
        }
    }
}
