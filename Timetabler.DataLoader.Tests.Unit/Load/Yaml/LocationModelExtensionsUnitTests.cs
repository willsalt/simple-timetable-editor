using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.DataLoader.Load.Yaml;
using Timetabler.DataLoader.Tests.Unit.TestHelpers.Extensions;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Load.Yaml
{
    [TestClass]
    public class LocationModelExtensionsUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

        private static readonly string[] _validFontTypes = { "Normal", "Condensed" };

        private static LocationModel GetModel()
        {
            return new LocationModel
            {
                Id = _rnd.NextHexString(8),
                EditorDisplayName = _rnd.NextString(_rnd.Next(20)),
                TimetableDisplayName = _rnd.NextString(_rnd.Next(20)),
                GraphDisplayName = _rnd.NextString(_rnd.Next(20)),
                LocationCode = _rnd.NextString(8),
                UpArrivalDepartureAlwaysDisplayed = _rnd.NextNullableArrivalDepartureOptions(),
                DownArrivalDepartureAlwaysDisplayed = _rnd.NextNullableArrivalDepartureOptions(),
                UpRoutingCodesAlwaysDisplayed = _rnd.NextNullableTrainRoutingOptions(),
                DownRoutingCodesAlwaysDisplayed = _rnd.NextNullableTrainRoutingOptions(),
                Mileage = _rnd.NextDistanceModel(),
                DisplaySeparatorAbove = _rnd.NextNullableBoolean(),
                DisplaySeparatorBelow = _rnd.NextNullableBoolean(),
                FontTypeName = _rnd.NextPotentiallyValidString(_validFontTypes),
            };
        }

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void LocationModelExtensionsClass_ToLocationMethod_ThrowsNullReferenceException_IfParameterIsNull()
        {
            LocationModel testParam = null;

            _ = testParam.ToLocation();

            Assert.Fail();
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectIdProperty_IfParameterIsNotNull()
        {
            LocationModel testParam = GetModel();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectEditorDisplayNameProperty_IfParameterIsNotNull()
        {
            LocationModel testParam = GetModel();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.EditorDisplayName, testOutput.EditorDisplayName);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectTimetableDisplayNameProperty_IfParameterIsNotNull()
        {
            LocationModel testParam = GetModel();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.TimetableDisplayName, testOutput.TimetableDisplayName);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectGraphDisplayNameProperty_IfParameterIsNotNull()
        {
            LocationModel testParam = GetModel();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.GraphDisplayName, testOutput.GraphDisplayName);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectTiplocProperty_IfParameterIsNotNull()
        {
            LocationModel testParam = GetModel();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.LocationCode, testOutput.Tiploc);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectUpArrivalDepartureAlwaysDisplayedProperty_IfParameterHasUpArrivalDepartureAlwaysDisplayedPropertyThatIsNotNull()
        {
            LocationModel testParam = GetModel();
            testParam.UpArrivalDepartureAlwaysDisplayed = _rnd.NextArrivalDepartureOptions();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.UpArrivalDepartureAlwaysDisplayed.Value, testOutput.UpArrivalDepartureAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectUpArrivalDepartureAlwaysDisplayedProperty_IfParameterHasUpArrivalDepartureAlwaysDisplayedPropertyThatIsNull()
        {
            LocationModel testParam = GetModel();
            testParam.UpArrivalDepartureAlwaysDisplayed = null;

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual((ArrivalDepartureOptions)0, testOutput.UpArrivalDepartureAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectDownArrivalDepartureAlwaysDisplayedProperty_IfParameterHasDownArrivalDepartureAlwaysDisplayedPropertyThatIsNotNull()
        {
            LocationModel testParam = GetModel();
            testParam.DownArrivalDepartureAlwaysDisplayed = _rnd.NextArrivalDepartureOptions();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.DownArrivalDepartureAlwaysDisplayed.Value, testOutput.DownArrivalDepartureAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectDownArrivalDepartureAlwaysDisplayedProperty_IfParameterHasDownArrivalDepartureAlwaysDisplayedPropertyThatIsNull()
        {
            LocationModel testParam = GetModel();
            testParam.DownArrivalDepartureAlwaysDisplayed = null;

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual((ArrivalDepartureOptions)0, testOutput.DownArrivalDepartureAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectUpRoutingCodesAlwaysDisplayedProperty_IfParameterHasUpRoutingCodesAlwaysDisplayedPropertyThatIsNotNull()
        {
            LocationModel testParam = GetModel();
            testParam.UpRoutingCodesAlwaysDisplayed = _rnd.NextTrainRoutingOptions();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.UpRoutingCodesAlwaysDisplayed.Value, testOutput.UpRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectUpRoutingCodesAlwaysDisplayedProperty_IfParameterHasUpRoutingCodesAlwaysDisplayedPropertyThatIsNull()
        {
            LocationModel testParam = GetModel();
            testParam.UpRoutingCodesAlwaysDisplayed = null;

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual((TrainRoutingOptions)0, testOutput.UpRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectDOwnRoutingCodesAlwaysDisplayedProperty_IfParameterHasDownRoutingCodesAlwaysDisplayedPropertyThatIsNotNull()
        {
            LocationModel testParam = GetModel();
            testParam.DownRoutingCodesAlwaysDisplayed = _rnd.NextTrainRoutingOptions();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.DownRoutingCodesAlwaysDisplayed.Value, testOutput.DownRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectDownRoutingCodesAlwaysDisplayedProperty_IfParameterHasDownRoutingCodesAlwaysDisplayedPropertyThatIsNull()
        {
            LocationModel testParam = GetModel();
            testParam.DownRoutingCodesAlwaysDisplayed = null;

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual((TrainRoutingOptions)0, testOutput.DownRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectDisplaySeparatorAboveProperty_IfParameterHasDisplaySeparatorAbovePropertyThatIsNotNull()
        {
            LocationModel testParam = GetModel();
            testParam.DisplaySeparatorAbove = _rnd.NextBoolean();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.DisplaySeparatorAbove.Value, testOutput.DisplaySeparatorAbove);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithDisplaySeparatorAbovePropertyEqualToFalse_IfParameterHasDisplaySeparatorAbovePropertyThatIsNull()
        {
            LocationModel testParam = GetModel();
            testParam.DisplaySeparatorAbove = null;

            Location testOutput = testParam.ToLocation();

            Assert.IsFalse(testOutput.DisplaySeparatorAbove);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithCorrectDisplaySeparatorBelowProperty_IfParameterHasDisplaySeparatorBelowPropertyThatIsNotNull()
        {
            LocationModel testParam = GetModel();
            testParam.DisplaySeparatorBelow = _rnd.NextBoolean();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.DisplaySeparatorBelow.Value, testOutput.DisplaySeparatorBelow);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithDisplaySeparatorBelowPropertyEqualToFalse_IfParameterHasDisplaySeparatorBelowPropertyThatIsNull()
        {
            LocationModel testParam = GetModel();
            testParam.DisplaySeparatorBelow = null;

            Location testOutput = testParam.ToLocation();

            Assert.IsFalse(testOutput.DisplaySeparatorBelow);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithMileagePropertyWithCorrectMileageProperty_IfParameterIsNotNull()
        {
            LocationModel testParam = GetModel();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.Mileage.Miles, testOutput.Mileage.Mileage);
        }

        [TestMethod]
        public void LocationModelExtensionsClass_ToLocationMethod_ReturnsObjectWithMileagePropertyWithCorrectChainageProperty_IfParameterIsNotNull()
        {
            LocationModel testParam = GetModel();

            Location testOutput = testParam.ToLocation();

            Assert.AreEqual(testParam.Mileage.Chains, testOutput.Mileage.Chainage);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
