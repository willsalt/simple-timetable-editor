using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Timetabler.Data.Tests.Unit
{
    [TestClass]
    public class SignalboxHoursUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursClass_CopyToMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            SignalboxHours testObject = new SignalboxHours();

            testObject.CopyTo(null);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursClass_CopyToMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfParameterIsNull()
        {
            SignalboxHours testObject = new SignalboxHours();

            try
            {
                testObject.CopyTo(null);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("target", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
