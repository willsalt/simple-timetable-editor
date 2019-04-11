using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class LocationExtensionsUnitTests
    {
        private Random _random = new Random();

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsNonNullObjectIfParameterIsNotNull()
        {
            Location testObject = new Location();

            LocationModel testResult = testObject.ToLocationModel();

            Assert.IsNotNull(testResult);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsNullIfParameterIsNull()
        {
            Location testObject = null;

            LocationModel testResult = testObject.ToLocationModel();

            Assert.IsNull(testResult);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectIdPropertyIfPopulated()
        {
            string testData = _random.NextHexString(8);
            Location testObject = new Location { Id = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(testData, testResult.Id);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectIdPropertyIfNull()
        {
            Location testObject = new Location { Id = null };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.IsNull(testResult.Id);
        }
 
        [TestMethod]
        public void LocationExtensionsClassToLocationModelReturnsObjectWithCorrectIdPropertyIfEmptyString()
        {
            Location testObject = new Location { Id = string.Empty };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(string.Empty, testResult.Id);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelReturnsObjectWithCorrectEditorDisplayNamePropertyIfPopulated()
        {
            string testData = _random.NextString(_random.Next(5, 128));
            Location testObject = new Location { EditorDisplayName = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(testData, testResult.EditorDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelReturnsObjectWithCorrectEditorDisplayNamePropertyIfNull()
        {
            Location testObject = new Location { EditorDisplayName = null };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.IsNull(testResult.EditorDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectEditorDisplayNamePropertyIfEmptyString()
        {
            Location testObject = new Location { EditorDisplayName = string.Empty };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(string.Empty, testResult.EditorDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectTimetableDisplayNamePropertyIfPopulated()
        {
            string testData = _random.NextString(_random.Next(5, 128));
            Location testObject = new Location { TimetableDisplayName = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(testData, testResult.TimetableDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectTimetableDisplayNamePropertyIfNull()
        {
            Location testObject = new Location { TimetableDisplayName = null };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.IsNull(testResult.TimetableDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectTimetableDisplayNamePropertyIfEmptyString()
        {
            Location testObject = new Location { TimetableDisplayName = string.Empty };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(string.Empty, testResult.TimetableDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectGraphDisplayNamePropertyIfPopulated()
        {
            string testData = _random.NextString(_random.Next(128));
            Location testObject = new Location { GraphDisplayName = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(testData, testResult.GraphDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectGraphDisplayNamePropertyIfNull()
        {
            Location testObject = new Location { GraphDisplayName = null };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.IsNull(testResult.GraphDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectGraphDisplayNamePropertyIfEmptyString()
        {
            Location testObject = new Location { GraphDisplayName = string.Empty };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(string.Empty, testResult.GraphDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectTiplocPropertyIfPopulated()
        {
            string testData = _random.NextString(_random.Next(1, 16));
            Location testObject = new Location { Tiploc = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(testData, testResult.Tiploc);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelReturnsObjectWithCorrectTiplocPropertyIfNull()
        {
            Location testObject = new Location { Tiploc = null };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.IsNull(testResult.Tiploc);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelReturnsObjectWithCorrectTiplocPropertyIfEmptyString()
        {
            Location testObject = new Location { Tiploc = string.Empty };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(string.Empty, testResult.Tiploc);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelReturnsObjectWithCorrectUpArrivalDepartureAlwaysDisplayedProperty()
        {
            ArrivalDepartureOptions testData = _random.NextArrivalDepartureOptions();
            Location testObject = new Location { UpArrivalDepartureAlwaysDisplayed = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(testData, testResult.UpArrivalDepartureAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelReturnsObjectWithCorrectUpRoutingCodesAlwaysDisplayedProperty()
        {
            TrainRoutingOptions testData = _random.NextTrainRoutingOptions();
            Location testObject = new Location { UpRoutingCodesAlwaysDisplayed = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.IsTrue(testResult.UpRoutingCodesAlwaysDisplayed.HasValue);
            Assert.AreEqual(testData, testResult.UpRoutingCodesAlwaysDisplayed.Value);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectDownArrivalDepartureAlwaysDisplayedProperty()
        {
            ArrivalDepartureOptions testData = _random.NextArrivalDepartureOptions();
            Location testObject = new Location { DownArrivalDepartureAlwaysDisplayed = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(testData, testResult.DownArrivalDepartureAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithCorrectDownRoutingCodesAlwaysDisplayedProperty()
        {
            TrainRoutingOptions testData = _random.NextTrainRoutingOptions();
            Location testObject = new Location { DownRoutingCodesAlwaysDisplayed = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.IsTrue(testResult.DownRoutingCodesAlwaysDisplayed.HasValue);
            Assert.AreEqual(testData, testResult.DownRoutingCodesAlwaysDisplayed.Value);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelMethodReturnsObjectWithMileagePropertyWithCorrectMileagePropertyIfMileagePropertyIsNotNull()
        {
            Distance testData = _random.NextDistance(new Distance { Mileage = int.MaxValue });
            Location testObject = new Location { Mileage = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(testData.Mileage, testResult.Mileage.Mileage);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelReturnsObjectWithMileagePropertyWithCorrectChainagePropertyIfMileagePropertyIsNotNull()
        {
            Distance testData = _random.NextDistance(new Distance { Mileage = int.MaxValue });
            Location testObject = new Location { Mileage = testData };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.AreEqual(testData.Chainage, testResult.Mileage.Chainage);
        }

        [TestMethod]
        public void LocationExtensionsClassToLocationModelReturnsObjectWithMileagePropertyEqualToNullIfMileagePropertyIsNull()
        {
            Location testObject = new Location { Mileage = null };

            LocationModel testResult = testObject.ToLocationModel();

            Assert.IsNull(testResult.Mileage);
        }
    }
}
