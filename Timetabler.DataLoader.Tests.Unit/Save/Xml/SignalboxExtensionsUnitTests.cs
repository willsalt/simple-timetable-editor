using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class SignalboxExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxExtensionsClass_ToSignalboxModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            Signalbox testObject = null;

            _ = testObject.ToSignalboxModel();

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxExtensionsClass_ToSignalboxModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            Signalbox testObject = null;

            try
            {
                _ = testObject.ToSignalboxModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("box", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
