using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class SignalboxHoursSetExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursSetExtensionsClass_ToSignalboxHoursSetModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            SignalboxHoursSet testObject = null;

            _ = testObject.ToSignalboxHoursSetModel();

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursSetExtensionsClass_ToSignalboxHoursSetModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            SignalboxHoursSet testObject = null;

            try
            {
                _ = testObject.ToSignalboxHoursSetModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("hoursSet", ex.ParamName);
            }
        }
    }
}
