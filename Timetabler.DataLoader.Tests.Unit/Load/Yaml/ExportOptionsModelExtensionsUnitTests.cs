using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class ExportOptionsModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static ExportOptionsModel GetModel()
        {
            return new ExportOptionsModel
            {
                DisplayLocoDiagramRow = _rnd.NextNullableBoolean(),
                FontSet = _rnd.NextString(_rnd.Next(50)),
                GraphsInOutput = _rnd.NextNullableBoolean(),
                SetToWorkRowInOutput = _rnd.NextNullableBoolean(),
                LocoToWorkRowInOutput = _rnd.NextNullableBoolean(),
                BoxHoursInOutput = _rnd.NextNullableBoolean(),
                CreditsInOutput = _rnd.NextNullableBoolean(),
                GlossaryInOutput = _rnd.NextNullableBoolean(),
                LineWidth = _rnd.NextNullableDouble(3d),
                FillerDashLineWidth = _rnd.NextNullableDouble(3d),
                TablePageOrientation = _rnd.NextNullableOrientation(),
                GraphPageOrientation = _rnd.NextNullableOrientation(),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            ExportOptionsModel testParam = null;

            testParam.ToDocumentExportOptions();

            Assert.Fail();
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayLocoDiagramRowPropertyEqualToTrue_IfParameterDisplayLocoDiagramRowPropertyIsEqualToTrue()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.DisplayLocoDiagramRow = true;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsTrue(testOutput.DisplayLocoDiagramRow);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayLocoDiagramRowPropertyEqualToFalse_IfParameterDisplayLocoDiagramRowPropertyIsEqualToFalse()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.DisplayLocoDiagramRow = false;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayLocoDiagramRow);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayLocoDiagramRowPropertyEqualToFalse_IfParameterDisplayLocoDiagramRowPropertyIsEqualToNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.DisplayLocoDiagramRow = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayLocoDiagramRow);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayToWorkRowPropertyEqualToTrue_IfParameterSetToWorkRowInOutputPropertyIsEqualToTrue()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.SetToWorkRowInOutput = true;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsTrue(testOutput.DisplayToWorkRow);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayToWorkRowPropertyEqualToFalse_IfParameterSetToWorkRowInOutputPropertyIsEqualToFalse()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.SetToWorkRowInOutput = false;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayToWorkRow);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayToWorkRowPropertyEqualToFalse_IfParameterSetToWorkRowInOutputPropertyIsEqualToNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.SetToWorkRowInOutput = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayToWorkRow);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayLocoToWorkRowPropertyEqualToTrue_IfParameterLocoToWorkRowInOutputPropertyIsEqualToTrue()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.LocoToWorkRowInOutput = true;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsTrue(testOutput.DisplayLocoToWorkRow);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayLocoToWorkRowPropertyEqualToFalse_IfParameterLocoToWorkRowInOutputPropertyIsEqualToFalse()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.LocoToWorkRowInOutput = false;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayLocoToWorkRow);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayLocoToWorkRowPropertyEqualToFalse_IfParameterLocoToWorkRowInOutputPropertyIsEqualToNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.LocoToWorkRowInOutput = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayLocoToWorkRow);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayBoxHoursPropertyEqualToTrue_IfParameterBoxHoursInOutputPropertyIsEqualToTrue()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.BoxHoursInOutput = true;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsTrue(testOutput.DisplayBoxHours);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayBoxHoursPropertyEqualToFalse_IfParameterBoxHoursInOutputPropertyIsEqualToFalse()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.BoxHoursInOutput = false;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayBoxHours);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayBoxHoursPropertyEqualToFalse_IfParameterBoxHoursInOutputPropertyIsEqualToNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.BoxHoursInOutput = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayBoxHours);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayCreditsPropertyEqualToTrue_IfParameterCreditsInOutputPropertyIsEqualToTrue()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.CreditsInOutput = true;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsTrue(testOutput.DisplayCredits);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayCreditsPropertyEqualToFalse_IfParameterCreditsInOutputPropertyIsEqualToFalse()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.CreditsInOutput = false;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayCredits);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayCreditsPropertyEqualToFalse_IfParameterCreditsInOutputPropertyIsEqualToNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.CreditsInOutput = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayCredits);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayGlossaryPropertyEqualToTrue_IfParameterGlossaryInOutputPropertyIsEqualToTrue()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.GlossaryInOutput = true;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsTrue(testOutput.DisplayGlossary);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayGlossaryPropertyEqualToFalse_IfParameterGlossaryInOutputPropertyIsEqualToFalse()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.GlossaryInOutput = false;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayGlossary);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayGlossaryPropertyEqualToFalse_IfParameterGlossaryInOutputPropertyIsEqualToNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.GlossaryInOutput = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayGlossary);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayGraphPropertyEqualToTrue_IfParameterGraphsInOutputPropertyIsEqualToTrue()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.GraphsInOutput = true;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsTrue(testOutput.DisplayGraph);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayGraphPropertyEqualToFalse_IfParameterGraphsInOutputPropertyIsEqualToFalse()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.GraphsInOutput = false;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsFalse(testOutput.DisplayGraph);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsMethod_ReturnsObjectWithDisplayGraphPropertyEqualToTrue_IfParameterGraphsInOutputPropertyIsEqualToNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.GraphsInOutput = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.IsTrue(testOutput.DisplayGraph);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsModel_ReturnsObjectWithCorrectLineWidthProperty_IfLineWidthPropertyOfParameterIsNotNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.LineWidth = _rnd.NextDouble() * 5;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.AreEqual(testParam.LineWidth, testOutput.LineWidth);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsModel_ReturnsObjectWithLineWidthPropertyEqualTo1_IfLineWidthPropertyOfParameterIsNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.LineWidth = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.AreEqual(1d, testOutput.LineWidth);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsModel_ReturnsObjectWithCorrectFillerDashLineWidthProperty_IfFillerDashLineWidthPropertyOfParameterIsNotNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.FillerDashLineWidth = _rnd.NextDouble() * 5;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.AreEqual(testParam.FillerDashLineWidth, testOutput.FillerDashLineWidth);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsModel_ReturnsObjectWithFillerDashLineWidthPropertyEqualToZeroPointFive_IfFillerDashLineWidthPropertyOfParameterIsNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.FillerDashLineWidth = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.AreEqual(0.5, testOutput.FillerDashLineWidth);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsModel_ReturnsObjectWithCorrectTablePageOrientationProperty_IfTablePageOrientationPropertyOfParameterIsPortrait()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.TablePageOrientation = Orientation.Portrait;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.AreEqual(Orientation.Portrait, testOutput.TablePageOrientation);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsModel_ReturnsObjectWithCorrectTablePageOrientationProperty_IfTablePageOrientationPropertyOfParameterIsLandscape()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.TablePageOrientation = Orientation.Landscape;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.AreEqual(Orientation.Landscape, testOutput.TablePageOrientation);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsModel_ReturnsObjectWithCorrectTablePageOrientationProperty_IfTablePageOrientationPropertyOfParameterIsNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.TablePageOrientation = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.AreEqual(Orientation.Landscape, testOutput.TablePageOrientation);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsModel_ReturnsObjectWithCorrectGraphPageOrientationProperty_IfGraphPageOrientationPropertyOfParameterIsPortrait()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.GraphPageOrientation = Orientation.Portrait;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.AreEqual(Orientation.Portrait, testOutput.GraphPageOrientation);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsModel_ReturnsObjectWithCorrectGraphPageOrientationProperty_IfGraphPageOrientationPropertyOfParameterIsLandscape()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.GraphPageOrientation = Orientation.Landscape;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.AreEqual(Orientation.Landscape, testOutput.GraphPageOrientation);
        }

        [TestMethod]
        public void ExportOptionsModelExtensionsClass_ToDocumentExportOptionsModel_ReturnsObjectWithCorrectGraphPageOrientationProperty_IfGraphPageOrientationPropertyOfParameterIsNull()
        {
            ExportOptionsModel testParam = GetModel();
            testParam.GraphPageOrientation = null;

            DocumentExportOptions testOutput = testParam.ToDocumentExportOptions();

            Assert.AreEqual(Orientation.Landscape, testOutput.GraphPageOrientation);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
