using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class NoteExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

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

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
