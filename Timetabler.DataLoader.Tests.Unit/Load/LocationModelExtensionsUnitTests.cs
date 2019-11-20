using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.DataLoader.Load;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Load
{
    [TestClass]
    public class LocationModelExtensionsUnitTests
    {
        private static readonly Random _random = RandomProvider.Default;

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsNonNullObjectIfParameterIsNonNull()
        {
            LocationModel testObject = new LocationModel();

            Location testResult = testObject.ToLocation();

            Assert.IsNotNull(testResult);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsNullIfParameterIsNull()
        {
            LocationModel testObject = null;

            Location testResult = testObject.ToLocation();

            Assert.IsNull(testResult);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithCorrectId()
        {
            string testId = _random.NextHexString(8);
            LocationModel testObject = new LocationModel { Id = testId };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testId, testResult.Id);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithCorrectEditorDisplayNameProperty()
        {
            string testValue = _random.NextString(_random.Next(5, 128));
            LocationModel testObject = new LocationModel { EditorDisplayName = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.EditorDisplayName);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithCorrectTimetableDisplayNameProperty()
        {
            string testValue = _random.NextString(_random.Next(5, 128));
            LocationModel testObject = new LocationModel { TimetableDisplayName = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.TimetableDisplayName);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithCorrectGraphDisplayNameProperty()
        {
            string testValue = _random.NextString(_random.Next(5, 128));
            LocationModel testObject = new LocationModel { GraphDisplayName = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.GraphDisplayName);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithCorrectTiplocProperty()
        {
            string testValue = _random.NextString(_random.Next(5, 128));
            LocationModel testObject = new LocationModel { Tiploc = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.Tiploc);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithCorrectUpArrivalDepartureAlwaysDisplayedProperty()
        {
            ArrivalDepartureOptions testValue = _random.NextArrivalDepartureOptions();
            LocationModel testObject = new LocationModel { UpArrivalDepartureAlwaysDisplayed = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.UpArrivalDepartureAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithCorrectUpRoutingCodesAlwaysDisplayedPropertyIfPropertyIsNotNullInParameter()
        {
            TrainRoutingOptions testValue = _random.NextTrainRoutingOptions();
            LocationModel testObject = new LocationModel { UpRoutingCodesAlwaysDisplayed = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.UpRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithUpRoutingCodesAlwaysDisplayedPropertyEqualToZeroIfPropertyIsNullInParameter()
        {
            LocationModel testObject = new LocationModel { UpRoutingCodesAlwaysDisplayed = null };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual((TrainRoutingOptions) 0, testResult.UpRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithCorrectDownArrivalDepartureAlwaysDisplayedProperty()
        {
            ArrivalDepartureOptions testValue = _random.NextArrivalDepartureOptions();
            LocationModel testObject = new LocationModel { DownArrivalDepartureAlwaysDisplayed = testValue };
            
            _ = testObject.ToLocation();

            Assert.AreEqual(testValue, testObject.DownArrivalDepartureAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithCorrectDownRoutingCodesAlwaysDisplayedPropertyIfPropertyIsNotNullInParameter()
        {
            TrainRoutingOptions testValue = _random.NextTrainRoutingOptions();
            LocationModel testObject = new LocationModel { DownRoutingCodesAlwaysDisplayed = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.DownRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithMileagePropertyWithCorrectMileageProperty()
        {
            DistanceModel testDistanceModelObject = GetRandomDistanceModel();
            LocationModel testObject = new LocationModel { Mileage = testDistanceModelObject };

            Location result = testObject.ToLocation();

            Assert.AreEqual(testDistanceModelObject.Mileage, result.Mileage.Mileage);
        }

        private DistanceModel GetRandomDistanceModel()
        {
            return new DistanceModel
            {
                Mileage = _random.Next(),
                Chainage = _random.NextDouble() * 80,
            };
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithMileagePropertyWithCorrectChainageProperty()
        {
            DistanceModel testDistanceModelObject = GetRandomDistanceModel();
            LocationModel testObject = new LocationModel { Mileage = testDistanceModelObject };

            Location result = testObject.ToLocation();

            Assert.AreEqual(testDistanceModelObject.Chainage, result.Mileage.Chainage);
        }

        [TestMethod]
        public void LocationModelExtensionsClassToLocationMethodReturnsObjectWithCorrectFontTypeProperty()
        {
            LocationFontType testFontType = GetRandomLocationFontType();
            LocationModel testObject = new LocationModel { FontTypeName = testFontType.ToString("g") };

            Location result = testObject.ToLocation();

            Assert.AreEqual(testFontType, result.FontType);
        }

        private LocationFontType GetRandomLocationFontType()
        {
            LocationFontType[] possibles = new[] { LocationFontType.Normal, LocationFontType.Condensed };
            return possibles[_random.Next(possibles.Length)];
        }
    }
}
