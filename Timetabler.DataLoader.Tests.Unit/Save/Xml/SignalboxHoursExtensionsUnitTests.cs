using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class SignalboxHoursExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursExtensionsClass_ToSignalboxHoursModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            SignalboxHours testObject = null;

            _ = testObject.ToSignalboxHoursModel();

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursExtensionsClass_ToSignalboxHoursModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            SignalboxHours testObject = null;

            try
            {
                _ = testObject.ToSignalboxHoursModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("hours", ex.ParamName);
            }
        }
    }
}
