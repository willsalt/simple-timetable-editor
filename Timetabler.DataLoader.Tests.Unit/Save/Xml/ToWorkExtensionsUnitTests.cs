using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Xml
{
    [TestClass]
    public class ToWorkExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToWorkExtensionsClass_ToWorkModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            ToWork testObject = null;

            _ = testObject.ToToWorkModel();

            Assert.Fail();
        }

        [TestMethod]
        public void ToWorkExtensionsClass_ToToWorkModelMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            ToWork testObject = null;

            try
            {
                _ = testObject.ToToWorkModel();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("data", ex.ParamName);
            }
        }
    }
}
