using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class SignalboxHoursModelExtensionsUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            SignalboxHoursModel testObject = null;
            IDictionary<string, Signalbox> testParam1 = new Dictionary<string, Signalbox>();

            _ = testObject.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            SignalboxHoursModel testObject = null;
            IDictionary<string, Signalbox> testParam1 = new Dictionary<string, Signalbox>();

            try
            {
                _ = testObject.ToSignalboxHours(testParam1);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsArgumentNullException_IfSecondParameterIsNull()
        {
            SignalboxHoursModel testObject = new SignalboxHoursModel();
            IDictionary<string, Signalbox> testParam1 = null;

            _ = testObject.ToSignalboxHours(testParam1);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursModelExtensionsClass_ToSignalboxHoursMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfSecondParameterIsNull()
        {
            SignalboxHoursModel testObject = new SignalboxHoursModel();
            IDictionary<string, Signalbox> testParam1 = null;

            try
            {
                _ = testObject.ToSignalboxHours(testParam1);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("signalboxes", ex.ParamName);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
