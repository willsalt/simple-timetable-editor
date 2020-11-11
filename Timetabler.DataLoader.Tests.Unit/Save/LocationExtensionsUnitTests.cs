using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.DataLoader.Tests.Unit.TestHelpers.Extensions;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Tests.Unit.Save
{
    [TestClass]
    public class LocationExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static Location GetTestObject()
        {
            return new Location
            {
                DisplaySeparatorAbove = _rnd.NextBoolean(),
                DisplaySeparatorBelow = _rnd.NextBoolean(),
                DownArrivalDepartureAlwaysDisplayed = _rnd.NextArrivalDepartureOptions(),
                DownRoutingCodesAlwaysDisplayed = _rnd.NextTrainRoutingOptions(),
                EditorDisplayName = _rnd.NextString(_rnd.Next(20)),
                FontType = _rnd.NextLocationFontType(),
                GraphDisplayName = _rnd.NextString(_rnd.Next(20)),
                Id = _rnd.NextHexString(8),
                Mileage = _rnd.NextDistance(),
                TimetableDisplayName = _rnd.NextString(_rnd.Next(20)),
                Tiploc = _rnd.NextString(_rnd.Next(10)),
                UpArrivalDepartureAlwaysDisplayed = _rnd.NextArrivalDepartureOptions(),
                UpRoutingCodesAlwaysDisplayed = _rnd.NextTrainRoutingOptions(),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsNull_IfParameterIsNull()
        {
            Location testParam = null;

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectIdProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectEditorDisplayNameProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.EditorDisplayName, testOutput.EditorDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectTimetableDisplayNameProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.TimetableDisplayName, testOutput.TimetableDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectGraphDisplayNameProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.GraphDisplayName, testOutput.GraphDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectLocationCodeProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.Tiploc, testOutput.LocationCode);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectUpArrivalDepartureAlwaysDisplayedProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.UpArrivalDepartureAlwaysDisplayed, testOutput.UpArrivalDepartureAlwaysDisplayed.Value);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectUpRoutingCodesAlwaysDisplayedProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.UpRoutingCodesAlwaysDisplayed, testOutput.UpRoutingCodesAlwaysDisplayed.Value);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectDownArrivalDepartureAlwaysDisplayedProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.DownArrivalDepartureAlwaysDisplayed, testOutput.DownArrivalDepartureAlwaysDisplayed.Value);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectDownRoutingCodesAlwaysDisplayedProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.DownRoutingCodesAlwaysDisplayed, testOutput.DownRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectDisplaySeparatorAboveProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.DisplaySeparatorAbove, testOutput.DisplaySeparatorAbove.Value);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectDisplaySeparatorBelowProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.DisplaySeparatorBelow, testOutput.DisplaySeparatorBelow);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithMileagePropertyWithCorrectMilesProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.Mileage.Mileage, testOutput.Mileage.Miles);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithMileagePropertyWithCorrectChainsProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.Mileage.Chainage, testOutput.Mileage.Chains);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToLocationModelMethod_ReturnsObjectWithCorrectFontTypeNameProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToLocationModel();

            Assert.AreEqual(testParam.FontType.ToString("g"), testOutput.FontTypeName);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
