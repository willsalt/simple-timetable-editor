using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class ExportOptionsModelExtensionsUnitTests
    {
        private const int TestMultipleRuns = 10;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectThatIsNotNull_IfParameterIsNotNull()
        {
            ExportOptionsModel testSourceObject = new ExportOptionsModel();

            DocumentExportOptions testResultObject = testSourceObject.ToDocumentExportOptions();

            Assert.IsNotNull(testResultObject);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithCorrectDisplayLocoDiagramRowProperty_IfParameterIsNotNull()
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
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithCorrectDisplayToWorkRowProperty_IfParameterIsNotNull()
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
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithCorrectDisplayLocoToWorkRowProperty_IfParameterIsNotNull()
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
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithCorrectDisplayBoxHoursProperty_IfParameterIsNotNull()
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
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithCorrectDisplayCreditsProperty_IfParameterIsNotNull()
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
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithCorrectDisplayGlossaryProperty_IfParameterIsNotNull()
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

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
