using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class DocumentExportOptionsExtensionsUnitTests
    {
        private const int TestMultipleRuns = 10;

        [TestMethod]
        public void DocumentExportOptionsExtensionsClassToExportOptionsModelMethodReturnsExportOptionsModelObjectThatIsNotNull()
        {
            DocumentExportOptions testSourceObject = new DocumentExportOptions();

            ExportOptionsModel testResultObject = testSourceObject.ToExportOptionsModel();

            Assert.IsNotNull(testResultObject);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClassToExportOptionsModelMethodReturnsExportOptionsModelObjectWithCorrectDisplayLocoDiagramRowProperty()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                DocumentExportOptions testSourceObject = new DocumentExportOptions { DisplayLocoDiagramRow = testValue };

                ExportOptionsModel testResultObject = testSourceObject.ToExportOptionsModel();

                Assert.AreEqual(testValue, testResultObject.DisplayLocoDiagramRow);
            }
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClassToExportOptionsModelMethodReturnsExportOptionsModelObjectWithCorrectToWorkRowInOutputProperty()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                DocumentExportOptions testSourceObject = new DocumentExportOptions { DisplayToWorkRow = testValue };

                ExportOptionsModel testResultObject = testSourceObject.ToExportOptionsModel();

                Assert.AreEqual(testValue, testResultObject.ToWorkRowInOutput);
            }
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClassToExportOptionsModelMethodReturnsExportOptionsModelObjectWithCorrectLocoToWorkRowInOutputProperty()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                DocumentExportOptions testSourceObject = new DocumentExportOptions { DisplayLocoToWorkRow = testValue };

                ExportOptionsModel testResultObject = testSourceObject.ToExportOptionsModel();

                Assert.AreEqual(testValue, testResultObject.LocoToWorkRowInOutput);
            }
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClassToExportOptionsModelMethodReturnsExportOptionsModelObjectWithCorrectBoxHoursInOutputProperty()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testValue = random.NextBoolean();
                DocumentExportOptions testSourceObject = new DocumentExportOptions { DisplayBoxHours = testValue };

                ExportOptionsModel testResultObject = testSourceObject.ToExportOptionsModel();

                Assert.AreEqual(testValue, testResultObject.BoxHoursInOutput);
            }
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClassToExportOptionsModelMethodReturnsExportOptionsModelObjectWithCorrectCreditsInOutputProperty()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testvalue = random.NextBoolean();
                DocumentExportOptions testSourceObject = new DocumentExportOptions { DisplayCredits = testvalue };

                ExportOptionsModel testResultObject = testSourceObject.ToExportOptionsModel();

                Assert.AreEqual(testvalue, testResultObject.CreditsInOutput);
            }
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClassToExportOptionsModelMethodReturnsExportOptionsModelObjectWithCorrectGlossaryInOutputProperty()
        {
            Random random = new Random();
            for (int i = 0; i < TestMultipleRuns; ++i)
            {
                bool testvalue = random.NextBoolean();
                DocumentExportOptions testSourceObject = new DocumentExportOptions { DisplayGlossary = testvalue };

                ExportOptionsModel testResultObject = testSourceObject.ToExportOptionsModel();

                Assert.AreEqual(testvalue, testResultObject.GlossaryInOutput);
            }
        }
    }
}
