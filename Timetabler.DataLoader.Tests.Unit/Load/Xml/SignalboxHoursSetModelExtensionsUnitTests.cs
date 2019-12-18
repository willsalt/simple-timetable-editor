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
    public class SignalboxHoursSetModelExtensionsUnitTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsArgumentNullException_IfFirstParameterIsNull()
        {
            SignalboxHoursSetModel testObject = null;
            IDictionary<string, Signalbox> testParam1 = new Dictionary<string, Signalbox>();
            IEnumerable<SignalboxHoursSet> testParam2 = Array.Empty<SignalboxHoursSet>();

            _ = testObject.ToSignalboxHoursSet(testParam1, testParam2);

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursSetModelExtensionsClass_ToSignalboxHoursSetMethod_ThrowsArgumentNullExceptionWithCorrectParamNameProperty_IfFirstParameterIsNull()
        {
            SignalboxHoursSetModel testObject = null;
            IDictionary<string, Signalbox> testParam1 = new Dictionary<string, Signalbox>();
            IEnumerable<SignalboxHoursSet> testParam2 = Array.Empty<SignalboxHoursSet>();

            try
            {
                _ = testObject.ToSignalboxHoursSet(testParam1, testParam2);
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("model", ex.ParamName);
            }
        }
    }
}
