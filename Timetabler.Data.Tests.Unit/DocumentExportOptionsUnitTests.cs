using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Tests.Unit.TestHelpers.Extensions;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class DocumentExportOptionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static DocumentExportOptions GetDocumentExportOptions()
        {
            return new DocumentExportOptions
            {
                DisplayLocoDiagramRow = _rnd.NextBoolean(),
                DisplayToWorkRow = _rnd.NextBoolean(),
                DisplayLocoToWorkRow = _rnd.NextBoolean(),
                DisplayBoxHours = _rnd.NextBoolean(),
                DisplayCredits = _rnd.NextBoolean(),
                DisplayGraph = _rnd.NextBoolean(),
                DisplayGlossary = _rnd.NextBoolean(),
                LineWidth = _rnd.NextDouble() * 10,
                FillerDashLineWidth = _rnd.NextDouble() * 10,
                ExportEngine = _rnd.NextPdfExportEngine(),
                TablePageOrientation = _rnd.NextOrientation(),
                GraphPageOrientation = _rnd.NextOrientation(),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores
        
        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsLineWidthPropertyToOnePointZero()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();

            Assert.AreEqual(1.0, testObject.LineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsFillerDashLineWidthPropertyToZeroPointFive()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();

            Assert.AreEqual(0.5, testObject.FillerDashLineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsExportEnginePropertyToExternal()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();

            Assert.AreEqual(PdfExportEngine.External, testObject.ExportEngine);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsTablePageOrientationPropertyToLandscape()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();

            Assert.AreEqual(Orientation.Landscape, testObject.TablePageOrientation);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsGraphPageOrientationPropertyToLandscape()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();

            Assert.AreEqual(Orientation.Landscape, testObject.GraphPageOrientation);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsDifferentObject()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreNotSame(testObject, testOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectDisplayLocoDiagramRowProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayLocoDiagramRow, testOutput.DisplayLocoDiagramRow);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectDisplayToWorkRowProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayToWorkRow, testOutput.DisplayToWorkRow);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectDisplayLocoToWorkRowProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayLocoToWorkRow, testOutput.DisplayLocoToWorkRow);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectDisplayBoxHoursProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayBoxHours, testOutput.DisplayBoxHours);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectDisplayCreditsProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayCredits, testOutput.DisplayCredits);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectDisplayGraphProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayGraph, testOutput.DisplayGraph);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectDisplayGlossaryProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DisplayGlossary, testOutput.DisplayGlossary);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectLineWidthProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.LineWidth, testOutput.LineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectFillerDashLineWidthProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.FillerDashLineWidth, testOutput.FillerDashLineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectExportEngineProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.ExportEngine, testOutput.ExportEngine);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectTablePageOrientationProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.TablePageOrientation, testOutput.TablePageOrientation);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectGraphPageOrientationProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.GraphPageOrientation, testOutput.GraphPageOrientation);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
