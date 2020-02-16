using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class SignalboxModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static SignalboxModel GetModel()
        {
            return new SignalboxModel
            {
                Id = _rnd.NextHexString(8),
                Code = _rnd.NextString(_rnd.Next(10)),
                EditorDisplayName = _rnd.NextString(_rnd.Next(32)),
                TimetableDisplayName = _rnd.NextString(_rnd.Next(32)),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SignalboxModelExtensionsClass_ToSignalboxMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            SignalboxModel testParam = null;

            _ = testParam.ToSignalbox();

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxModelExtensionsClass_ToSignalboxMethod_ReturnsObjectWithCorrectIdProperty_IfParameterIsNotNull()
        {
            SignalboxModel testParam = GetModel();

            Signalbox testOutput = testParam.ToSignalbox();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        public void SignalboxModelExtensionsClass_ToSignalboxMethod_ReturnsObjectWithCorrectCodeProperty_IfParameterIsNotNull()
        {
            SignalboxModel testParam = GetModel();

            Signalbox testOutput = testParam.ToSignalbox();

            Assert.AreEqual(testParam.Code, testOutput.Code);
        }

        [TestMethod]
        public void SignalboxModelExtensionsClass_ToSignalboxMethod_ReturnsObjectWithCorrectEditorDisplayNameProperty_IfParameterIsNotNull()
        {
            SignalboxModel testParam = GetModel();

            Signalbox testOutput = testParam.ToSignalbox();

            Assert.AreEqual(testParam.EditorDisplayName, testOutput.EditorDisplayName);
        }

        [TestMethod]
        public void SignalboxModelExtensionsClass_ToSignalboxMethod_ReturnsObjectWithCorrectExportDisplayNameProperty_IfParameterIsNotNull()
        {
            SignalboxModel testParam = GetModel();

            Signalbox testOutput = testParam.ToSignalbox();

            Assert.AreEqual(testParam.TimetableDisplayName, testOutput.ExportDisplayName);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
