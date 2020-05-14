using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.Models;

namespace Timetabler.Tests.Unit.Models
{
    [TestClass]
    public class TrainAdjustTimesFormModelUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static IEnumerable<Location> GetRandomLocations()
        {
            int count = _rnd.Next(20);
            Location[] data = new Location[count];
            for (int i = 0; i < data.Length; ++i)
            {
                data[i] = new Location();
            }
            return data;
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainAdjustTimesFormModelClass_Constructor_CreatesObjectWithNonNullValidLocationsProperty_IfParameterIsNull()
        {
            IEnumerable<Location> testParam0 = Array.Empty<Location>();

            TrainAdjustTimesFormModel testOutput = new TrainAdjustTimesFormModel(testParam0);

            Assert.IsNotNull(testOutput.ValidLocations);
        }

        [TestMethod]
        public void TrainAdjustTimesFormModelClass_Constructor_CreatesObjectWithValidLocationsPropertyWithCountPropertyEqualToZero_IfParameterIsNull()
        {
            IEnumerable<Location> testParam0 = Array.Empty<Location>();

            TrainAdjustTimesFormModel testOutput = new TrainAdjustTimesFormModel(testParam0);

            Assert.AreEqual(0, testOutput.ValidLocations.Count);
        }

        [TestMethod]
        public void TrainAdjustTimesFormModelClass_Constructor_CreatesObjectWithValidLocationsPropertyWithCountPropertyEqualToNumberOfElementsInParameter_IfParameterIsNotNull()
        {
            IEnumerable<Location> testParam0 = GetRandomLocations();

            TrainAdjustTimesFormModel testOutput = new TrainAdjustTimesFormModel(testParam0);

            Assert.AreEqual(testParam0.Count(), testOutput.ValidLocations.Count);
        }

        [TestMethod]
        public void TrainAdjustTimesFormModelClass_Constructor_CreatesObjectWithValidLocationsPropertyWithSameContentsInSameOrderAsParameter_IfParameterIsNotNull()
        {
            IEnumerable<Location> testParam0 = GetRandomLocations();

            TrainAdjustTimesFormModel testOutput = new TrainAdjustTimesFormModel(testParam0);

            Location[] testData = testParam0.ToArray();
            for (int i = 0; i < testOutput.ValidLocations.Count; ++i)
            {
                Assert.AreSame(testData[i], testOutput.ValidLocations[i]);
            }
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
