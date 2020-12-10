﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class DocumentExportOptionsExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static DocumentExportOptions GetTestObject() => new DocumentExportOptions
        {
            DisplayBoxHours = _rnd.NextBoolean(),
            DisplayCredits = _rnd.NextBoolean(),
            DisplayGlossary = _rnd.NextBoolean(),
            DisplayGraph = _rnd.NextBoolean(),
            DisplayLocoDiagramRow = _rnd.NextBoolean(),
            DisplayLocoToWorkRow = _rnd.NextBoolean(),
            DisplayToWorkRow = _rnd.NextBoolean(),
            FillerDashLineWidth = _rnd.NextDouble() * 5,
            LineWidth = _rnd.NextDouble() * 5,
            GraphAxisLineWidth = _rnd.NextDouble() * 5,
            TablePageOrientation = _rnd.NextOrientation(),
            GraphPageOrientation = _rnd.NextOrientation(),
            UpSectionLabel = _rnd.NextString(_rnd.Next(10)),
            DownSectionLabel = _rnd.NextString(_rnd.Next(10)),
            MorningLabel = _rnd.NextString(_rnd.Next(6)),
            MiddayLabel = _rnd.NextString(_rnd.Next(6)),
            AfternoonLabel = _rnd.NextString(_rnd.Next(6)),
            DistancesInOutput = _rnd.NextSectionSelection(),
            FirstDirectionExported = _rnd.NextDirection(),
        };

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            DocumentExportOptions testParam = null;

            _ = testParam.ToExportOptionsModel();

            Assert.Fail();
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectDisplayLocoDiagramRowProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.DisplayLocoDiagramRow, testOutput.DisplayLocoDiagramRow);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectSetToWorkRowInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.DisplayToWorkRow, testOutput.SetToWorkRowInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectLocoToWorkRowInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.DisplayLocoToWorkRow, testOutput.LocoToWorkRowInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectBoxHoursInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.DisplayBoxHours, testOutput.BoxHoursInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectCreditsInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.DisplayCredits, testOutput.CreditsInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectLineWidthProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.LineWidth, testOutput.LineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectGraphAxisLineWidthProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.GraphAxisLineWidth, testOutput.GraphAxisLineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectFillerDashLineWidthProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.FillerDashLineWidth, testOutput.FillerDashLineWidth);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectGraphsInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.DisplayGraph, testOutput.GraphsInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectGlossaryInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.DisplayGlossary, testOutput.GlossaryInOutput);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectTablePageOrientationProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.TablePageOrientation, testOutput.TablePageOrientation.Value);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectGraphPageOrientationProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.GraphPageOrientation, testOutput.GraphPageOrientation.Value);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectUpSectionLabelProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.UpSectionLabel, testOutput.UpSectionLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectDownSectionLabelProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.DownSectionLabel, testOutput.DownSectionLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectMorningLabelProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.MorningLabel, testOutput.MorningLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectMiddayLabelProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.MiddayLabel, testOutput.MiddayLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectAfternoonLabelProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.AfternoonLabel, testOutput.AfternoonLabel);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectDistancesInOutputProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.DistancesInOutput, testOutput.DistancesInOutput.Value);
        }

        [TestMethod]
        public void DocumentExportOptionsExtensionsClass_ToExportOptionsModelMethod_ReturnsObjectWithCorrectFirstDirectionExportedProperty_IfParameterIsNotNull()
        {
            DocumentExportOptions testParam = GetTestObject();

            ExportOptionsModel testOutput = testParam.ToExportOptionsModel();

            Assert.AreEqual(testParam.FirstDirectionExported, testOutput.FirstDirectionExported.Value);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
