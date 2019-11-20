using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class TimetableDocumentExtensionsUnitTests
    {
        // Run some tests this number of times to ensure a good range of randomly-selected data is tested.
        private const int TestMultipleRuns = 10;

        [TestMethod]
        public void TimetableDocumentExtensionsClassToTimetableFileModelMethodReturnsModelWithExportOptionsPropertyThatIsNotNull()
        {
            TimetableDocument document = new TimetableDocument();

            TimetableFileModel result = document.ToTimetableFileModel();

            Assert.IsNotNull(result.ExportOptions);
        }

        [TestMethod]
        public void TimetableDocumentExtensionsClassToTimetableFileModelMethodReturnsModelWithExportOptionsPropertyWithCorrectDisplayLocoDiagramRowValue()
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
    }
}
