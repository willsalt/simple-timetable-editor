using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class TimetableFileModelExtensionsUnitTests
    {
        private const int TestMultipleRuns = 10;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TimetableFileModelExtensionsClass_ToTimetableDocumentMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            TimetableFileModel testObject = null;

            _ = testObject.ToTimetableDocument();

            Assert.Fail();
        }

        [TestMethod]
        public void TimetableFIleModelExtensionsClass_ToTimetableDocumentMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
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

#pragma warning restore CA1707 // Identifiers should not contain underscores

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
