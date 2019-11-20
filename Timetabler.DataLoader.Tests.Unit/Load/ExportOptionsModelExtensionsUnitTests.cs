using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data;
using Timetabler.DataLoader.Load;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Load
{
    [TestClass]
    public class ExportOptionsModelExtensionsUnitTests
    {
        private const int TestMultipleRuns = 10;

        [TestMethod]
        public void ExportOptionsModelExtensionsClassToDocumentExportOptionsMethodReturnsObjectThatIsNotNullIfParameterIsNotNull()
        {
            ExportOptionsModel testSourceObject = new ExportOptionsModel();

            DocumentExportOptions testResultObject = testSourceObject.ToDocumentExportOptions();

            Assert.IsNotNull(testResultObject);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClassToDocumentExportOptionsMethodReturnsObjectWithCorrectDisplayLocoDiagramRowPropertyIfParameterIsNotNull()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                ExportOptionsModel testSourceObject = new ExportOptionsModel { DisplayLocoDiagramRow = testValue };

                DocumentExportOptions testResultObject = testSourceObject.ToDocumentExportOptions();

                Assert.AreEqual(testValue, testResultObject.DisplayLocoDiagramRow);
            }
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClassToDocumentExportOptionsMethodReturnsObjectWithCorrectDisplayToWorkRowPropertyIfParameterIsNotNull()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                ExportOptionsModel testSourceObject = new ExportOptionsModel { ToWorkRowInOutput = testValue };

                DocumentExportOptions testResultObject = testSourceObject.ToDocumentExportOptions();

                Assert.AreEqual(testValue, testResultObject.DisplayToWorkRow);
            }
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClassToDocumentExportOptionsMethodReturnsObjectWithCorrectDisplayLocoToWorkRowPropertyIfParameterIsNotNull()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                ExportOptionsModel testSourceObject = new ExportOptionsModel { LocoToWorkRowInOutput = testValue };

                DocumentExportOptions testResultObject = testSourceObject.ToDocumentExportOptions();

                Assert.AreEqual(testValue, testResultObject.DisplayLocoToWorkRow);
            }
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClassToDocumentExportOptionsMethodReturnsObjectWithCorrectDisplayBoxHoursPropertyIfParameterIsNotNull()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                ExportOptionsModel testSourceObject = new ExportOptionsModel { BoxHoursInOutput = testValue };

                DocumentExportOptions testResultObject = testSourceObject.ToDocumentExportOptions();

                Assert.AreEqual(testValue, testResultObject.DisplayBoxHours);
            }
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClassToDocumentExportOptionsMethodReturnsObjectWithCorrectDisplayCreditsPropertyIfParameterIsNotNull()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                ExportOptionsModel testSourceObject = new ExportOptionsModel { CreditsInOutput = testValue };

                DocumentExportOptions testResultObject = testSourceObject.ToDocumentExportOptions();

                Assert.AreEqual(testValue, testResultObject.DisplayCredits);
            }
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClassToDocumentExportOptionsMethodReturnsObjectWithCorrectDisplayGlossaryPropertyIfParameterIsNotNull()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                ExportOptionsModel testSourceObject = new ExportOptionsModel { GlossaryInOutput = testValue };

                DocumentExportOptions testResultObject = testSourceObject.ToDocumentExportOptions();

                Assert.AreEqual(testValue, testResultObject.DisplayGlossary);
            }
        }
    }
}
