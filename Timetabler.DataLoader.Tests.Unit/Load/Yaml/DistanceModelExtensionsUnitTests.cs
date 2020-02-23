using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.DataLoader.Tests.Unit.TestHelpers.Extensions;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class DistanceModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DistanceModelExtensionsClass_ToDistanceMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            DistanceModel testParam = null;

            testParam.ToDistance();

            Assert.Fail();
        }

        [TestMethod]
        public void DistanceModelExtensionsClass_ToDistanceMethod_ReturnsDistanceObjectWithCorrectMileageProperty_IfParameterIsNotNull()
        {
            DistanceModel testParam = _rnd.NextDistanceModel();

            Distance testOutput = testParam.ToDistance();

            Assert.AreEqual(testParam.Miles, testOutput.Mileage);
        }

        [TestMethod]
        public void DistanceModelExtensionsClass_ToDistanceMethod_ReturnsDistanceObjectWithCorrectChainageProperty_IfParameterIsNotNull()
        {
            DistanceModel testParam = _rnd.NextDistanceModel();

            Distance testOutput = testParam.ToDistance();

            Assert.AreEqual(testParam.Chains, testOutput.Chainage);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
