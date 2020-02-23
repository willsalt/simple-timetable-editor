using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Yaml;
using Timetabler.DataLoader.Tests.Unit.TestHelpers.Extensions;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Tests.Unit.Save.Yaml
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
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsNull_IfParameterIsNull()
        {
            Location testParam = null;

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.IsNull(testOutput);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectIdProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.Id, testOutput.Id);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectEditorDisplayNameProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.EditorDisplayName, testOutput.EditorDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectTimetableDisplayNameProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.TimetableDisplayName, testOutput.TimetableDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectGraphDisplayNameProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.GraphDisplayName, testOutput.GraphDisplayName);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectLocationCodeProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.Tiploc, testOutput.LocationCode);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectUpArrivalDepartureAlwaysDisplayedProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.UpArrivalDepartureAlwaysDisplayed, testOutput.UpArrivalDepartureAlwaysDisplayed.Value);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectUpRoutingCodesAlwaysDisplayedProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.UpRoutingCodesAlwaysDisplayed, testOutput.UpRoutingCodesAlwaysDisplayed.Value);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectDownArrivalDepartureAlwaysDisplayedProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.DownArrivalDepartureAlwaysDisplayed, testOutput.DownArrivalDepartureAlwaysDisplayed.Value);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectDownRoutingCodesAlwaysDisplayedProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.DownRoutingCodesAlwaysDisplayed, testOutput.DownRoutingCodesAlwaysDisplayed);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectDisplaySeparatorAboveProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.DisplaySeparatorAbove, testOutput.DisplaySeparatorAbove.Value);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectDisplaySeparatorBelowProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.DisplaySeparatorBelow, testOutput.DisplaySeparatorBelow);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithNullMileageProperty_IfParameterHasMileagePropertyThatIsNull()
        {
            Location testParam = GetTestObject();
            testParam.Mileage = null;

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.IsNull(testOutput.Mileage);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithMileagePropertyWithCorrectMilesProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.Mileage.Mileage, testOutput.Mileage.Miles);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithMileagePropertyWithCorrectChainsProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.Mileage.Chainage, testOutput.Mileage.Chains);
        }

        [TestMethod]
        public void LocationExtensionsClass_ToYamlLocationModelMethod_ReturnsObjectWithCorrectFontTypeNameProperty_IfParameterIsNotNull()
        {
            Location testParam = GetTestObject();

            LocationModel testOutput = testParam.ToYamlLocationModel();

            Assert.AreEqual(testParam.FontType.ToString("g"), testOutput.FontTypeName);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
