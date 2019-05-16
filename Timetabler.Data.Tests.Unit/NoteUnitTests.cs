using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data.Display;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class NoteUnitTests
    {
        [TestMethod]
        public void NoteClassToFootnoteDisplayModelMethodReturnsFootnoteDisplayModelWithCorrectNoteIdProperty()
        {
            Note testObject = NoteHelpers.GetNote();

            FootnoteDisplayModel testOutput = testObject.ToFootnoteDisplayModel();

            Assert.AreEqual(testObject.Id, testOutput.NoteId);
        }

        [TestMethod]
        public void NoteClassToFootnoteDisplayModelMethodReturnsFootnoteDisplayModelWithCorrectSymbolProperty()
        {
            Note testObject = NoteHelpers.GetNote();

            FootnoteDisplayModel testOutput = testObject.ToFootnoteDisplayModel();

            Assert.AreEqual(testObject.Symbol, testOutput.Symbol);
        }

        [TestMethod]
        public void NoteClassToFootnoteDisplayModelMethodReturnsFootnoteDisplayModelWithCorrectDefinitionProperty()
        {
            Note testObject = NoteHelpers.GetNote();

            FootnoteDisplayModel testOutput = testObject.ToFootnoteDisplayModel();

            Assert.AreEqual(testObject.Definition, testOutput.Definition);
        }

        [TestMethod]
        public void NoteClassToFootnoteDisplayModelMethodReturnsFootnoteDisplayModelWithCorrectDisplayOnPagesProperty()
        {
            Note testObject = NoteHelpers.GetNote();

            FootnoteDisplayModel testOutput = testObject.ToFootnoteDisplayModel();

            Assert.AreEqual(testObject.DefinedOnPages, testOutput.DisplayOnPage);
        }
    }
}
