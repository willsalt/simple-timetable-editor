using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class NoteExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NoteExtensionsClass_ToNoteModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Note testObject = null;

            _ = testObject.ToNoteModel();

            Assert.Fail();
        }

        [TestMethod]
        public void NoteExtensionsClass_ToNoteModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Note testObject = null;

            try
            {
                _ = testObject.ToNoteModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("note", ex.ParamName);
            }
        }
    }
}
