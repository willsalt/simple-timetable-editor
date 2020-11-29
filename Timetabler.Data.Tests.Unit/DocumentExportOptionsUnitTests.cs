using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class DocumentExportOptionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static DocumentExportOptions GetDocumentExportOptions() => new DocumentExportOptions
        {
            DisplayLocoDiagramRow = _rnd.NextBoolean(),
            DisplayToWorkRow = _rnd.NextBoolean(),
            DisplayLocoToWorkRow = _rnd.NextBoolean(),
            DisplayBoxHours = _rnd.NextBoolean(),
            DisplayCredits = _rnd.NextBoolean(),
            DisplayGraph = _rnd.NextBoolean(),
            DisplayGlossary = _rnd.NextBoolean(),
            LineWidth = _rnd.NextDouble() * 10,
            GraphAxisLineWidth = _rnd.NextDouble() * 10,
            FillerDashLineWidth = _rnd.NextDouble() * 10,
            TablePageOrientation = _rnd.NextOrientation(),
            GraphPageOrientation = _rnd.NextOrientation(),
            UpSectionLabel = _rnd.NextString(_rnd.Next(10)),
            DownSectionLabel = _rnd.NextString(_rnd.Next(10)),
            MorningLabel = _rnd.NextString(_rnd.Next(5)),
            MiddayLabel = _rnd.NextString(_rnd.Next(6)),
            AfternoonLabel = _rnd.NextString(_rnd.Next(5)),
            DistancesInOutput = _rnd.NextSectionSelection(),
        };

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsLineWidthPropertyToOnePointZero()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();

            Assert.AreEqual(1.0, testObject.LineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsGraphAxisLineWidthPropertyToOnePointZero()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();

            Assert.AreEqual(1.0, testObject.GraphAxisLineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsFillerDashLineWidthPropertyToZeroPointFive()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();

            Assert.AreEqual(0.5, testObject.FillerDashLineWidth);
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
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsUpSectionLabelPropertyToValueFromResourcesFile()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();
            string expectedValue = Resources.DocumentExportOptions_DefaultUpSectionLabel;

            Assert.AreEqual(expectedValue, testObject.UpSectionLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsDownSectionLabelPropertyToValueFromResourcesFile()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();
            string expectedValue = Resources.DocumentExportOptions_DefaultDownSectionLabel;

            Assert.AreEqual(expectedValue, testObject.DownSectionLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsMorningLabelPropertyToValueFromResourcesFile()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();
            string expectedValue = Resources.DocumentExportOptions_DefaultMorningLabel;

            Assert.AreEqual(expectedValue, testObject.MorningLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsMiddayLabelPropertyToValueFromResourcesFile()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();
            string expectedValue = Resources.DocumentExportOptions_DefaultMiddayLabel;

            Assert.AreEqual(expectedValue, testObject.MiddayLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsAfternoonLabelPropertyToValueFromResourcesFile()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();
            string expectedValue = Resources.DocumentExportOptions_DefaultAfternoonLabel;

            Assert.AreEqual(expectedValue, testObject.AfternoonLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_ParameterlessConstructor_SetsDistancesInOutputPropertyToNone()
        {
            DocumentExportOptions testObject = new DocumentExportOptions();

            Assert.AreEqual(SectionSelection.None, testObject.DistancesInOutput);
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
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectGraphAxisLineWidthProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.GraphAxisLineWidth, testOutput.GraphAxisLineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectFillerDashLineWidthProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.FillerDashLineWidth, testOutput.FillerDashLineWidth);
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

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectUpSectionLabelProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.UpSectionLabel, testOutput.UpSectionLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectDownSectionLabelProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DownSectionLabel, testOutput.DownSectionLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectMorningLabelProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.MorningLabel, testOutput.MorningLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectMiddayLabelProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.MiddayLabel, testOutput.MiddayLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectAfternoonLabelProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.AfternoonLabel, testOutput.AfternoonLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsClass_CopyMethod_ReturnsObjectWithCorrectDistancesInOutputProperty()
        {
            DocumentExportOptions testObject = GetDocumentExportOptions();

            DocumentExportOptions testOutput = testObject.Copy();

            Assert.AreEqual(testObject.DistancesInOutput, testOutput.DistancesInOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
