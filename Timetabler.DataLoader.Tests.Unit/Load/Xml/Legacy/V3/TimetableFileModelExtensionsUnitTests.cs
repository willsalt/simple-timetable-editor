using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.DataLoader.Load.Xml.Legacy.V3;
using Timetabler.SerialData.Xml.Legacy.V3;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml.Legacy.V3
{
    [TestClass]
    public class TimetableFileModelExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimetableFileModelExtensionsClass_ToTimetableDocumentMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TimetableFileModel testObject = null;

            _ = testObject.ToTimetableDocument();

            Assert.Fail();
        }

        [TestMethod]
        public void TimetableFileModelExtensionsClass_ToTimetableDocumentMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TimetableFileModel testObject = null;

            try
            {
                _ = testObject.ToTimetableDocument();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("file", ex.ParamName);
            }
        }
    }
}
