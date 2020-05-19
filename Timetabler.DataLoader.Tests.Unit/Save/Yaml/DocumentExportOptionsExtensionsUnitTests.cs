using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Yaml
{
    [TestClass]
    public class DocumentExportOptionsExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static DocumentExportOptions GetTestObject()
        {
            return new DocumentExportOptions
            {
                DisplayBoxHours = _rnd.NextBoolean(),
                DisplayCredits = _rnd.NextBoolean(),
                DisplayGlossary = _rnd.NextBoolean(),
                DisplayGraph = _rnd.NextBoolean(),
                DisplayLocoDiagramRow = _rnd.NextBoolean(),
                DisplayLocoToWorkRow = _rnd.NextBoolean(),
                DisplayToWorkRow = _rnd.NextBoolean(),
                ExportEngine = _rnd.NextBoolean() ? PdfExportEngine.External : PdfExportEngine.Unicorn,
                FillerDashLineWidth = _rnd.NextDouble() * 5,
                LineWidth = _rnd.NextDouble() * 5,
                GraphAxisLineWidth = _rnd.NextDouble() * 5,
                TablePageOrientation = _rnd.NextOrientation(),
                GraphPageOrientation = _rnd.NextOrientation(),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            DocumentExportOptions testParam = null;

            _ = testParam.ToYamlExportOptionsModel();

            Assert.Fail();
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectDisplayLocoDiagramRowProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.DisplayLocoDiagramRow, testOutput.DisplayLocoDiagramRow);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectSetToWorkRowInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.DisplayToWorkRow, testOutput.SetToWorkRowInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectLocoToWorkRowInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.DisplayLocoToWorkRow, testOutput.LocoToWorkRowInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectBoxHoursInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.DisplayBoxHours, testOutput.BoxHoursInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectCreditsInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.DisplayCredits, testOutput.CreditsInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectLineWidthProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.LineWidth, testOutput.LineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectGraphAxisLineWidthProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.GraphAxisLineWidth, testOutput.GraphAxisLineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectFillerDashLineWidthProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.FillerDashLineWidth, testOutput.FillerDashLineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectGraphsInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.DisplayGraph, testOutput.GraphsInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectGlossaryInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.DisplayGlossary, testOutput.GlossaryInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectTablePageOrientationProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.TablePageOrientation, testOutput.TablePageOrientation.Value);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToYamlExportOptionsModelMethod_ReturnsObjectWithCorrectGraphPageOrientationProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToYamlExportOptionsModel();

            Assert.AreEqual(testParam.GraphPageOrientation, testOutput.GraphPageOrientation.Value);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
