using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data.Display;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class FootnoteDisplayModelUnitTests
    {
        private FootnoteDisplayModel GetTestObject()
        {
            return FootnoteDisplayModelHelpers.GetFootnoteDisplayModel();
        }

        [TestMethod]
        public void FootnoteDisplayModelClassCopyMethodReturnsDifferentObject()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            FootnoteDisplayModel testOutput = testObject.Copy();

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void FootnoteDisplayModelClassCopyMethodReturnsObjectWithSameNoteIdProperty()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            FootnoteDisplayModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.NoteId, testOutput.NoteId);
        }

        [TestMethod]
        public void FootnoteDisplayModelClassCopyMethodReturnsObjectWithSameSymbolProperty()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            FootnoteDisplayModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Symbol, testOutput.Symbol);
        }

        [TestMethod]
        public void FootnoteDisplayModelClassCopyMethodReturnsObjectWithSameDefinitionProperty()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            FootnoteDisplayModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Definition, testOutput.Definition);
        }

        [TestMethod]
        public void FootnoteDisplayModelClassCopyMethodReturnsObjectWithSameDisplayOnPageProperty()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            FootnoteDisplayModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayOnPage, testOutput.DisplayOnPage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FootnoteDisplayModelClassCopyToMethodThrowsArgumentNullExceptionIfParameterIsNull()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            testObject.CopyTo(null);

            Assert.Fail();
        }

        [TestMethod]
        public void FootnoteDisplayModelClassCopyToMethodSetsNoteIdPropertyOfTarget()
        {
            FootnoteDisplayModel testObject = GetTestObject();
            FootnoteDisplayModel targetObject = GetTestObject();

            testObject.CopyTo(targetObject);

            Assert.AreEqual(testObject.NoteId, targetObject.NoteId);
        }

        [TestMethod]
        public void FootnoteDisplayModelClassCopyToMethodSetsSymbolPropertyOfTarget()
        {
            FootnoteDisplayModel testObject = GetTestObject();
            FootnoteDisplayModel targetObject = GetTestObject();

            testObject.CopyTo(targetObject);

            Assert.AreEqual(testObject.Symbol, targetObject.Symbol);
        }

        [TestMethod]
        public void FootnoteDisplayModelClassCopyToMethodSetsDefinitionPropertyOfTarget()
        {
            FootnoteDisplayModel testObject = GetTestObject();
            FootnoteDisplayModel targetObject = GetTestObject();

            testObject.CopyTo(targetObject);

            Assert.AreEqual(testObject.Definition, targetObject.Definition);
        }

        [TestMethod]
        public void FootnoteDisplayModelClassCopyToMethodSetsDisplayOnPagePropertyOfTarget()
        {
            FootnoteDisplayModel testObject = GetTestObject();
            FootnoteDisplayModel targetObject = GetTestObject();

            testObject.CopyTo(targetObject);

            Assert.AreEqual(testObject.DisplayOnPage, targetObject.DisplayOnPage);
        }
    }
}
