using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using Timetabler.Data;
using Timetabler.PdfExport.Interfaces;

namespace Timetabler.PdfExport.Tests.Unit
{
    [TestClass]
    public class PdfExporterUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PdfExporterClass_ExportMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            PdfExporter testObject = new PdfExporter(new Mock<IDocumentDescriptorFactory>().Object);
            TimetableDocument testParam0 = null;
            Stream testParam1 = new Mock<Stream>().Object;

            testObject.Export(testParam0, testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void PdfExporterClass_ExportMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            PdfExporter testObject = new PdfExporter(new Mock<IDocumentDescriptorFactory>().Object);
            TimetableDocument testParam0 = null;
            Stream testParam1 = new Mock<Stream>().Object;

            try
            {
                testObject.Export(testParam0, testParam1);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("document", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
