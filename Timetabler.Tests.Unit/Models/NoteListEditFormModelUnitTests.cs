using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Timetabler.Data;
using Timetabler.Models;

namespace Timetabler.Tests.Unit.Models
{
    [TestClass]
    public class NoteListEditFormModelUnitTests
    {
        [TestMethod]
        public void NoteListEditFormModelClass_Constructor_SetsDataPropertyToNonNullValue_IfParameterIsNull()
        {
            Dictionary<string, Note> testParam0 = null;

            NoteListEditFormModel testOutput = new NoteListEditFormModel(testParam0);

            Assert.IsNotNull(testOutput.Data);
        }

        [TestMethod]
        public void NoteListEditFormModelClass_Constructor_SetsDataPropertyToObjectWithDataPropertyWithCountPropertyZero_IfParameterIsNull()
        {
            Dictionary<string, Note> testParam0 = null;

            NoteListEditFormModel testOutput = new NoteListEditFormModel(testParam0);

            Assert.AreEqual(0, testOutput.Data.Count);
        }

        [TestMethod]
        public void NoteListEditFormModelClass_Constructor_SetsDataPropertyToParameter_IfParameterIsNotNull()
        {
            Dictionary<string, Note> testParam0 = new Dictionary<string, Note>();

            NoteListEditFormModel testOutput = new NoteListEditFormModel(testParam0);

            Assert.AreSame(testParam0, testOutput.Data);
        }
    }
}
