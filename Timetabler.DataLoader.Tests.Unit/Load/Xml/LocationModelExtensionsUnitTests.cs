using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Xml
{
    [TestClass]
    public class LocationModelExtensionsUnitTests
    {
        private static readonly Random _random = RandomProvider.Default;

        private static DistanceModel GetRandomDistanceModel()
        {
            return new DistanceModel
            {
                Mileage = _random.Next(),
                Chainage = _random.NextDouble() * 80,
            };
        }

        private static LocationFontType GetRandomLocationFontType()
        {
            LocationFontType[] possibles = new[] { LocationFontType.Normal, LocationFontType.Condensed };
            return possibles[_random.Next(possibles.Length)];
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsNonNullObject_IfParameterIsNonNull()
        {
            LocationModel testObject = new LocationModel();

            Location testResult = testObject.ToLocation();

            Assert.IsNotNull(testResult);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsNull_IfParameterIsNull()
        {
            LocationModel testObject = null;

            Location testResult = testObject.ToLocation();

            Assert.IsNull(testResult);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectId()
        {
            string testId = _random.NextHexString(8);
            LocationModel testObject = new LocationModel { Id = testId };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testId, testResult.Id);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectEditorDisplayNameProperty()
        {
            string testValue = _random.NextString(_random.Next(5, 128));
            LocationModel testObject = new LocationModel { EditorDisplayName = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.EditorDisplayName);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectTimetableDisplayNameProperty()
        {
            string testValue = _random.NextString(_random.Next(5, 128));
            LocationModel testObject = new LocationModel { TimetableDisplayName = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.TimetableDisplayName);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectGraphDisplayNameProperty()
        {
            string testValue = _random.NextString(_random.Next(5, 128));
            LocationModel testObject = new LocationModel { GraphDisplayName = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.GraphDisplayName);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectTiplocProperty()
        {
            string testValue = _random.NextString(_random.Next(5, 128));
            LocationModel testObject = new LocationModel { Tiploc = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.Tiploc);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethodReturns_ObjectWithCorrectUpArrivalDepartureAlwaysDisplayedProperty()
        {
            ArrivalDepartureOptions testValue = _random.NextArrivalDepartureOptions();
            LocationModel testObject = new LocationModel { UpArrivalDepartureAlwaysDisplayed = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.UpArrivalDepartureAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectUpRoutingCodesAlwaysDisplayedProperty_IfPropertyIsNotNullInParameter()
        {
            TrainRoutingOptions testValue = _random.NextTrainRoutingOptions();
            LocationModel testObject = new LocationModel { UpRoutingCodesAlwaysDisplayed = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.UpRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithUpRoutingCodesAlwaysDisplayedPropertyEqualToZero_IfPropertyIsNullInParameter()
        {
            LocationModel testObject = new LocationModel { UpRoutingCodesAlwaysDisplayed = null };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual((TrainRoutingOptions) 0, testResult.UpRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectDownArrivalDepartureAlwaysDisplayedProperty()
        {
            ArrivalDepartureOptions testValue = _random.NextArrivalDepartureOptions();
            LocationModel testObject = new LocationModel { DownArrivalDepartureAlwaysDisplayed = testValue };
            
            _ = testObject.ToLocation();

            Assert.AreEqual(testValue, testObject.DownArrivalDepartureAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectDownRoutingCodesAlwaysDisplayedProperty_IfPropertyIsNotNullInParameter()
        {
            TrainRoutingOptions testValue = _random.NextTrainRoutingOptions();
            LocationModel testObject = new LocationModel { DownRoutingCodesAlwaysDisplayed = testValue };

            Location testResult = testObject.ToLocation();

            Assert.AreEqual(testValue, testResult.DownRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithMileagePropertyWithCorrectMileageProperty()
        {
            DistanceModel testDistanceModelObject = GetRandomDistanceModel();
            LocationModel testObject = new LocationModel { Mileage = testDistanceModelObject };

            Location result = testObject.ToLocation();

            Assert.AreEqual(testDistanceModelObject.Mileage, result.Mileage.Mileage);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithMileagePropertyWithCorrectChainageProperty()
        {
            DistanceModel testDistanceModelObject = GetRandomDistanceModel();
            LocationModel testObject = new LocationModel { Mileage = testDistanceModelObject };

            Location result = testObject.ToLocation();

            Assert.AreEqual(testDistanceModelObject.Chainage, result.Mileage.Chainage);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectFontTypeProperty()
        {
            LocationFontType testFontType = GetRandomLocationFontType();
            LocationModel testObject = new LocationModel { FontTypeName = testFontType.ToString("g") };

            Location result = testObject.ToLocation();

            Assert.AreEqual(testFontType, result.FontType);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
