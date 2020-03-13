using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Yaml;
using Timetabler.DataLoader.Tests.Unit.TestHelpers.Extensions;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Yaml
{
    [TestClass]
    public class DistanceExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static Distance GetTestObject()
        {
            return _rnd.NextDistance();
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DistanceExtensionsClass_ToYamlDistanceModelMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            Distance testParam = null;

            _ = testParam.ToYamlDistanceModel();

            Assert.Fail();
        }

        [TestMethod]
        public void DistanceExtensionsClass_ToYamlDistanceModelMethod_ReturnsObjectWithCorrectMilesProperty_IfParameterIsNotNull()
        {
            Distance testParam = GetTestObject();

            DistanceModel testOutput = testParam.ToYamlDistanceModel();

            Assert.AreEqual(testParam.Mileage, testOutput.Miles);
        }

        [TestMethod]
        public void DistanceExtensionsClass_ToYamlDistanceModelMethod_ReturnsObjectWithCorrectChainsProperty_IfParameterIsNotNull()
        {
            Distance testParam = GetTestObject();

            DistanceModel testOutput = testParam.ToYamlDistanceModel();

            Assert.AreEqual(testParam.Chainage, testOutput.Chains);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
