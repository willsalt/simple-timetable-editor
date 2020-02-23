using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class TimetableDocumentExtensionsUnitTests
    {
        // Run some tests this number of times to ensure a good range of randomly-selected data is tested.
        private const int TestMultipleRuns = 10;

#pragma warning disable CA1707 // Identifiers should not contain underscores
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimetableDocumentExtensionsClass_ToTimetableFileModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TimetableDocument document = null;

            _ = document.ToTimetableFileModel();

            Assert.Fail();
        }

        [TestMethod]
        public void TimetableFileDocumentExtensionsClass_ToTimetableFileModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            TimetableDocument document = null;

            try
            {
                _ = document.ToTimetableFileModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("document", ex.ParamName);
            }
        }

        [TestMethod]
        public void TimetableDocumentExtensionsClass_ToTimetableFileModelMethod_ReturnsModelWithExportOptionsPropertyThatIsNotNull()
        {
            TimetableDocument document = new TimetableDocument();

            TimetableFileModel result = document.ToTimetableFileModel();

            Assert.IsNotNull(result.ExportOptions);
        }

        [TestMethod]
        public void TimetableDocumentExtensionsClass_ToTimetableFileModelMethod_ReturnsModelWithExportOptionsPropertyWithCorrectDisplayLocoDiagramRowValue()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                TimetableDocument document = new TimetableDocument { ExportOptions = new DocumentExportOptions { DisplayLocoDiagramRow = testValue } };

                TimetableFileModel result = document.ToTimetableFileModel();

                Assert.AreEqual(testValue, result.ExportOptions.DisplayLocoDiagramRow);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
