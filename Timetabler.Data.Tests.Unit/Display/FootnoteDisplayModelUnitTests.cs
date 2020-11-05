using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data.Display;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit.Display
{
    [TestClass]
    public class FootnoteDisplayModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static FootnoteDisplayModel GetTestObject()
        {
            return FootnoteDisplayModelHelpers.GetFootnoteDisplayModel();
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void FootnoteDisplayModelClass_Constructor_SetsNoteIdPropertyToEqualFirstParameter()
        {
            string testParam0 = _rnd.NextHexString(8);
            string testParam1 = _rnd.NextString(1);
            string testParam2 = _rnd.NextString(_rnd.Next(50));
            bool testParam3 = _rnd.NextBoolean();

            FootnoteDisplayModel testOutput = new FootnoteDisplayModel(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam0, testOutput.NoteId);
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_Constructor_SetsSymbolPropertyToEqualSecondParameter()
        {
            string testParam0 = _rnd.NextHexString(8);
            string testParam1 = _rnd.NextString(1);
            string testParam2 = _rnd.NextString(_rnd.Next(50));
            bool testParam3 = _rnd.NextBoolean();

            FootnoteDisplayModel testOutput = new FootnoteDisplayModel(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam1, testOutput.Symbol);
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_Constructor_SetsDefinitionPropertyToEqualThirdParameter()
        {
            string testParam0 = _rnd.NextHexString(8);
            string testParam1 = _rnd.NextString(1);
            string testParam2 = _rnd.NextString(_rnd.Next(50));
            bool testParam3 = _rnd.NextBoolean();

            FootnoteDisplayModel testOutput = new FootnoteDisplayModel(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam2, testOutput.Definition);
        }


        [TestMethod]
        public void FootnoteDisplayModelClass_Constructor_SetsDisplayOnPagePropertyToEqualFourthParameter()
        {
            string testParam0 = _rnd.NextHexString(8);
            string testParam1 = _rnd.NextString(1);
            string testParam2 = _rnd.NextString(_rnd.Next(50));
            bool testParam3 = _rnd.NextBoolean();

            FootnoteDisplayModel testOutput = new FootnoteDisplayModel(testParam0, testParam1, testParam2, testParam3);

            Assert.AreEqual(testParam3, testOutput.DisplayOnPage);
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_CopyMethod_ReturnsDifferentObject()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            FootnoteDisplayModel testOutput = testObject.Copy();

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_CopyMethod_ReturnsObjectWithSameNoteIdProperty()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            FootnoteDisplayModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.NoteId, testOutput.NoteId);
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_CopyMethod_ReturnsObjectWithSameSymbolProperty()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            FootnoteDisplayModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Symbol, testOutput.Symbol);
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_CopyMethod_ReturnsObjectWithSameDefinitionProperty()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            FootnoteDisplayModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.Definition, testOutput.Definition);
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_CopyMethod_ReturnsObjectWithSameDisplayOnPageProperty()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            FootnoteDisplayModel testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayOnPage, testOutput.DisplayOnPage);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void FootnoteDisplayModelClass_CopyToMethod_ThrowsArgumentNullExceptionIfParameterIsNull()
        {
            FootnoteDisplayModel testObject = GetTestObject();

            testObject.CopyTo(null);

            Assert.Fail();
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_CopyToMethod_SetsNoteIdPropertyOfTarget()
        {
            FootnoteDisplayModel testObject = GetTestObject();
            FootnoteDisplayModel targetObject = GetTestObject();

            testObject.CopyTo(targetObject);

            Assert.AreEqual(testObject.NoteId, targetObject.NoteId);
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_CopyToMethod_SetsSymbolPropertyOfTarget()
        {
            FootnoteDisplayModel testObject = GetTestObject();
            FootnoteDisplayModel targetObject = GetTestObject();

            testObject.CopyTo(targetObject);

            Assert.AreEqual(testObject.Symbol, targetObject.Symbol);
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_CopyToMethod_SetsDefinitionPropertyOfTarget()
        {
            FootnoteDisplayModel testObject = GetTestObject();
            FootnoteDisplayModel targetObject = GetTestObject();

            testObject.CopyTo(targetObject);

            Assert.AreEqual(testObject.Definition, targetObject.Definition);
        }

        [TestMethod]
        public void FootnoteDisplayModelClass_CopyToMethod_SetsDisplayOnPagePropertyOfTarget()
        {
            FootnoteDisplayModel testObject = GetTestObject();
            FootnoteDisplayModel targetObject = GetTestObject();

            testObject.CopyTo(targetObject);

            Assert.AreEqual(testObject.DisplayOnPage, targetObject.DisplayOnPage);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
