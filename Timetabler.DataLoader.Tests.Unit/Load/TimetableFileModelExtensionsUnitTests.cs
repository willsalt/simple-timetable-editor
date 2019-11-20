using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data;
using Timetabler.DataLoader.Load;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Load
{
    [TestClass]
    public class TimetableFileModelExtensionsUnitTests
    {
        private const int TestMultipleRuns = 10;

        [TestMethod]
        public void TimetableFileModelExtensionsClassToTimetableDocumentMethodReturnsTimetableDocumentObjectWithExportOptionsPropertyThatIsNotNullIfExportOptionsPropertyOfParameterIsNull()
        {
            TimetableFileModel testSourceObject = new TimetableFileModel { ExportOptions = null };

            TimetableDocument testResultObject = testSourceObject.ToTimetableDocument();

            Assert.IsNotNull(testResultObject.ExportOptions);
        }

        [TestMethod]
        public void TimetableFileModelExtensionsClassToTimetableDocumentMethodReturnsTimetableDocumentObjectWithExportOptionsPropertyThatIsNotNullIfExportOptionsPropertyOfParameterIsNotNull()
        {
            TimetableFileModel testSourceObject = new TimetableFileModel { ExportOptions = new ExportOptionsModel() };

            TimetableDocument testResultObject = testSourceObject.ToTimetableDocument();

            Assert.IsNotNull(testResultObject.ExportOptions);
        }

        [TestMethod]
        public void TimetableFileModelExtensionsClassToTimetableDocumentMethodReturnsTimetableDocumentObjectWithExportOptionsPropertyWithCorrectDisplayLocoDiagramRowPropertyIfExportOptionsPropertyOfParameterIsNotNull()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                TimetableFileModel testSourceObject = new TimetableFileModel { ExportOptions = new ExportOptionsModel { DisplayLocoDiagramRow = testValue } };

                TimetableDocument testResultObject = testSourceObject.ToTimetableDocument();

                Assert.AreEqual(testValue, testResultObject.ExportOptions.DisplayLocoDiagramRow);
            }
        }
    }
}
