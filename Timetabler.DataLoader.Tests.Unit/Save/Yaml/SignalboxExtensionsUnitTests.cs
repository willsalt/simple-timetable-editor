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
    public class SignalboxExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static Signalbox GetTestObject()
        {
            return new Signalbox
            {
                Code = _rnd.NextString(_rnd.Next(7)),
                EditorDisplayName = _rnd.NextString(_rnd.Next(20)),
                ExportDisplayName = _rnd.NextString(_rnd.Next(20)),
                Id = _rnd.NextHexString(8),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void SignalboxExtensionsClass_ToYamlSignalboxModelMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            Signalbox testParam = null;

            _ = testParam.ToYamlSignalboxModel();

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxExtensionsClass_ToYamlSignalboxModelMethod_ReturnsObjectWithCorrectIdProperty_IfParameterIsNotNull()
        {
            Signalbox testParam = GetTestObject();

            SignalboxModel testOutput = testParam.ToYamlSignalboxModel();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        public void SignalboxExtensionsClass_ToYamlSignalboxModelMethod_ReturnsObjectWithCorrectCodeProperty_IfParameterIsNotNull()
        {
            Signalbox testParam = GetTestObject();

            SignalboxModel testOutput = testParam.ToYamlSignalboxModel();

            Assert.AreEqual(testParam.Code, testOutput.Code);
        }

        [TestMethod]
        public void SignalboxExtensionsClass_ToYamlSignalboxModelMethod_ReturnsObjectWithCorrectEditorDisplayNameProperty_IfParameterIsNotNull()
        {
            Signalbox testParam = GetTestObject();

            SignalboxModel testOutput = testParam.ToYamlSignalboxModel();

            Assert.AreEqual(testParam.EditorDisplayName, testOutput.EditorDisplayName);
        }

        [TestMethod]
        public void SignalboxExtensionsClass_ToYamlSignalboxModelMethod_ReturnsObjectWithCorrectTimetableDisplayNameProperty_IfParameterIsNotNull()
        {
            Signalbox testParam = GetTestObject();

            SignalboxModel testOutput = testParam.ToYamlSignalboxModel();

            Assert.AreEqual(testParam.ExportDisplayName, testOutput.TimetableDisplayName);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
