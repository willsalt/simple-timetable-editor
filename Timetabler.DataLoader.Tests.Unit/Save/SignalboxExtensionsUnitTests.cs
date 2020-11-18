using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class SignalboxExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static Signalbox GetTestObject() => new Signalbox
        {
            Code = _rnd.NextString(_rnd.Next(7)),
            EditorDisplayName = _rnd.NextString(_rnd.Next(20)),
            ExportDisplayName = _rnd.NextString(_rnd.Next(20)),
            Id = _rnd.NextHexString(8),
        };

#pragma warning restore CA5394 // Do not use insecure randomness

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxExtensionsClass_ToSignalboxModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Signalbox testParam = null;

            _ = testParam.ToSignalboxModel();

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxExtensionsClass_ToSignalboxModelMethod_ReturnsObjectWithCorrectIdProperty_IfParameterIsNotNull()
        {
            Signalbox testParam = GetTestObject();

            SignalboxModel testOutput = testParam.ToSignalboxModel();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        public void SignalboxExtensionsClass_ToSignalboxModelMethod_ReturnsObjectWithCorrectCodeProperty_IfParameterIsNotNull()
        {
            Signalbox testParam = GetTestObject();

            SignalboxModel testOutput = testParam.ToSignalboxModel();

            Assert.AreEqual(testParam.Code, testOutput.Code);
        }

        [TestMethod]
        public void SignalboxExtensionsClass_ToSignalboxModelMethod_ReturnsObjectWithCorrectEditorDisplayNameProperty_IfParameterIsNotNull()
        {
            Signalbox testParam = GetTestObject();

            SignalboxModel testOutput = testParam.ToSignalboxModel();

            Assert.AreEqual(testParam.EditorDisplayName, testOutput.EditorDisplayName);
        }

        [TestMethod]
        public void SignalboxExtensionsClass_ToSignalboxModelMethod_ReturnsObjectWithCorrectTimetableDisplayNameProperty_IfParameterIsNotNull()
        {
            Signalbox testParam = GetTestObject();

            SignalboxModel testOutput = testParam.ToSignalboxModel();

            Assert.AreEqual(testParam.ExportDisplayName, testOutput.TimetableDisplayName);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
