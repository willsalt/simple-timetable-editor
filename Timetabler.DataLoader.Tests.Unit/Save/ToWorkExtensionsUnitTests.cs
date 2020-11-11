using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class ToWorkExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static ToWork GetTestObject()
        {
            return new ToWork
            { 
                Text = _rnd.NextString(_rnd.Next(20)),
                AtTime = _rnd.NextTimeOfDay(),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ToWorkExtensionsClass_ToToWorkModelMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            ToWork testParam = null;

            _ = testParam.ToToWorkModel();

            Assert.Fail();
        }

        [TestMethod]
        public void ToWorkExtensionsClass_ToToWorkModelMethod_ReturnsObjectWithCorrectTextProperty_IfParameterHasTextPropertyThatIsNotNull()
        {
            ToWork testParam = GetTestObject();

            ToWorkModel testOutput = testParam.ToToWorkModel();

            Assert.AreEqual(testParam.Text, testOutput.Text);
        }

        [TestMethod]
        public void ToWorkExtensionsClass_ToToWorkModelMethod_ReturnsObjectWithTextPropertyEqualToNull_IfParameterHasTextPropertyThatIsNotNull()
        {
            ToWork testParam = GetTestObject();
            testParam.Text = null;

            ToWorkModel testOutput = testParam.ToToWorkModel();

            Assert.IsNull(testOutput.Text);
        }

        [TestMethod]
        public void ToWorkExtensionsClass_ToToWorkModelMethod_ReturnsObjectWithAtPropertyWithCorrectTimeProperty_IfParameterHasAtTimePropertyThatIsNotNull()
        {
            ToWork testParam = GetTestObject();

            ToWorkModel testOutput = testParam.ToToWorkModel();

            string expectedValue = testParam.AtTime.Hours24.ToString("d2", CultureInfo.InvariantCulture) + ":" +
                testParam.AtTime.Minutes.ToString("d2", CultureInfo.InvariantCulture) + ":" +
                testParam.AtTime.Seconds.ToString("d2", CultureInfo.InvariantCulture);
            Assert.AreEqual(expectedValue, testOutput.At.Time);
        }

        [TestMethod]
        public void ToWorkExtensionsClass_ToToWorkModelMethod_ReturnsObjectWithAtPropertyEqualToNull_IfParameterHasAtTimePropertyThatIsNotNull()
        {
            ToWork testParam = GetTestObject();
            testParam.AtTime = null;

            ToWorkModel testOutput = testParam.ToToWorkModel();

            Assert.IsNull(testOutput.At);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
