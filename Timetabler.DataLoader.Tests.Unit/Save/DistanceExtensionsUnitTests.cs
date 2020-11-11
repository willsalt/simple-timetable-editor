using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.DataLoader.Tests.Unit.TestHelpers.Extensions;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
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
        public void DistanceExtensionsClass_ToDistanceModelMethod_ReturnsObjectWithCorrectMilesProperty()
        {
            Distance testParam = GetTestObject();

            DistanceModel testOutput = testParam.ToDistanceModel();

            Assert.AreEqual(testParam.Mileage, testOutput.Miles);
        }

        [TestMethod]
        public void DistanceExtensionsClass_ToDistanceModelMethod_ReturnsObjectWithCorrectChainsProperty()
        {
            Distance testParam = GetTestObject();

            DistanceModel testOutput = testParam.ToDistanceModel();

            Assert.AreEqual(testParam.Chainage, testOutput.Chains);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
