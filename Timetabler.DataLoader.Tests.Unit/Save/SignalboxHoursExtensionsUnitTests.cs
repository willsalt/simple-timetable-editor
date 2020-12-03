using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Timetabler.Data;
using Timetabler.Data.Tests.Utility.Helpers;
using Timetabler.DataLoader.Save;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class SignalboxHoursExtensionsUnitTests
    {
        private static SignalboxHours GetTestObject(bool withBox = true) => SignalboxHoursHelpers.GetSignalboxHours(withBox ? SignalboxHelpers.GetSignalbox() : null);

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SignalboxHoursExtensionsClass_ToSignalboxHoursModelMethod_ThrowsArgumentNullException_IfParameterIsNull()
        {
            SignalboxHours testParam = null;

            _ = testParam.ToSignalboxHoursModel();

            Assert.Fail();
        }

        [TestMethod]
        public void SignalboxHoursExtensionsClass_ToSignalboxHoursModelMethod_ReturnsObjectWithSignalboxIdPropertyThatIsNull_IfParameterHasSignalboxPropertyThatIsNull()
        {
            SignalboxHours testParam = GetTestObject(false);

            SignalboxHoursModel testOutput = testParam.ToSignalboxHoursModel();

            Assert.IsNull(testOutput.SignalboxId);
        }

        [TestMethod]
        public void SignalboxHoursExtensionsClass_ToSignalboxHoursModelMethod_ReturnsObjectWithSignalboxIdPropertyEqualToIdPropertyOfSignalboxPropertyOfParameter_IfParameterHasSignalboxPropertyThatIsNotNull()
        {
            SignalboxHours testParam = GetTestObject();

            SignalboxHoursModel testOutput = testParam.ToSignalboxHoursModel();

            Assert.AreEqual(testParam.Signalbox.Id, testOutput.SignalboxId);
        }

        [TestMethod]
        public void SignalboxHoursExtensionsClass_ToSignalboxHoursModelMethod_ReturnsPropertyWithStartTimePropertyWithCorrectTimeProperty_IfParameterIsNotNull()
        {
            SignalboxHours testParam = GetTestObject();
            string expectedValue = testParam.StartTime.ToTimeOfDayModel().Time;

            SignalboxHoursModel testOutput = testParam.ToSignalboxHoursModel();

            Assert.AreEqual(expectedValue, testOutput.StartTime.Time);
        }

        [TestMethod]
        public void SignalboxHoursExtensionsClass_ToSignalboxHoursModelMethod_ReturnsPropertyWithFinishTimePropertyWithCorrectTimeProperty_IfParameterIsNotNull()
        {
            SignalboxHours testParam = GetTestObject();
            string expectedValue = testParam.EndTime.ToTimeOfDayModel().Time;

            SignalboxHoursModel testOutput = testParam.ToSignalboxHoursModel();

            Assert.AreEqual(expectedValue, testOutput.FinishTime.Time);
        }

        [TestMethod]
        public void SignalboxHoursExtensionsClass_ToSignalboxHoursModelMethod_ReturnsPropertyWithCorrectTokenBalanceWarningProperty_IfParameterIsNotNull()
        {
            SignalboxHours testParam = GetTestObject();

            SignalboxHoursModel testOutput = testParam.ToSignalboxHoursModel();

            Assert.AreEqual(testParam.TokenBalanceWarning, testOutput.TokenBalanceWarning);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
