using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data.Comparers;
using Timetabler.Data.Display;
using Timetabler.Data.Tests.Unit.TestHelpers;

namespace Timetabler.Data.Tests.Unit.Comparers
{
    [TestClass]
    public class LocationDisplayModelComparerUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsZeroIfConstructedForUpAndBothParametersAreNull()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Up);

            int result = comparer.Compare(null, null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsZeroIfConstructedForDownAndBothParametersAreNull()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Down);

            int result = comparer.Compare(null, null);

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsMinusOneIfConstructedForUpFirstParameterIsNullAndSecondParameterIsNotNull()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Up);
            LocationDisplayModel location = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistance() };

            int result = comparer.Compare(null, location);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsMinusOneIfConstructedForDownFirstParameterIsNullAndSecondParameterIsNotNull()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Down);
            LocationDisplayModel location = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistance() };

            int result = comparer.Compare(null, location);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsOneIfConstructedForUpFirstParameterIsNotNullAndSecondParameterIsNull()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Up);
            LocationDisplayModel location = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistance() };

            int result = comparer.Compare(location, null);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsOneIfConstructedForDownFirstParameterIsNotNullAndSecondParameterIsNull()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Down);
            LocationDisplayModel location = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistance() };

            int result = comparer.Compare(location, null);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsOneIfConstructedForUpAndFirstParameterHasLowerMileageThanSecondParameter()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Up);
            LocationDisplayModel x = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistance() };
            LocationDisplayModel y = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistanceGreaterThan(x.Mileage) };

            int result = comparer.Compare(x, y);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsMinusOneIfConstructedForDownAndFirstParameterHasLowerMileageThanSecondParameter()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Down);
            LocationDisplayModel x = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistance() };
            LocationDisplayModel y = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistanceGreaterThan(x.Mileage) };

            int result = comparer.Compare(x, y);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsMinusOneIfConstructedForUpAndFirstParameterHasGreaterMileageThanSecondParameter()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Up);
            LocationDisplayModel y = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistance() };
            LocationDisplayModel x = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistanceGreaterThan(y.Mileage) };

            int result = comparer.Compare(x, y);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsOneIfConstructedForDownAndFirstParameterHasGreaterMileageThanSecondParameter()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Down);
            LocationDisplayModel y = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistance() };
            LocationDisplayModel x = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistanceGreaterThan(y.Mileage) };

            int result = comparer.Compare(x, y);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsMinusOneIfConstructedForUpAndParametersHaveSameMileageAndFirstParameterIsArrivalRowAndSecondParameterIsDepartureRow()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Up);
            LocationDisplayModel x = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistance(), LocationKey = _rnd.NextHexString(8) + "-a" };
            LocationDisplayModel y = new LocationDisplayModel { Mileage = new Distance { Mileage = x.Mileage.Mileage, Chainage = x.Mileage.Chainage }, LocationKey = _rnd.NextHexString(8) + "-d" };

            int result = comparer.Compare(x, y);

            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void LocationDisplayModelComparerClassCompareMethodReturnsMinusOneIfConstructedForDownAndParametersHaveSameMileageAndFirstParameterIsArrivalRowAndSecondParameterIsDepartureRow()
        {
            LocationDisplayModelComparer comparer = new LocationDisplayModelComparer(Direction.Down);
            LocationDisplayModel x = new LocationDisplayModel { Mileage = DistanceHelpers.GetDistance(), LocationKey = _rnd.NextHexString(8) + "-a" };
            LocationDisplayModel y = new LocationDisplayModel { Mileage = new Distance { Mileage = x.Mileage.Mileage, Chainage = x.Mileage.Chainage }, LocationKey = _rnd.NextHexString(8) + "-d" };

            int result = comparer.Compare(x, y);

            Assert.AreEqual(-1, result);
        }
    }
}
