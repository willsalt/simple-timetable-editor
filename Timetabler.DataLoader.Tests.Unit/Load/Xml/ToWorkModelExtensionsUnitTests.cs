using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class ToWorkModelExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            ToWorkModel testObject = null;

            _ = testObject.ToToWork();

            Assert.Fail();
        }

        [TestMethod]
        public void ToWorkModelExtensionsClass_ToToWorkMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            ToWorkModel testObject = null;

            try
            {
                _ = testObject.ToToWork();
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
