using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.CoreData;

namespace Timetabler.SerialData.Tests.Unit
{
    [TestClass]
    public class LocationModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void LocationModelClass_IsPublic()
        {
            Type classType = typeof(LocationModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_IsNotAbstract()
        {
            Type classType = typeof(LocationModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(LocationModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicIdPropertyOfTypeString()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("Id");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicGraphDisplayNamePropertyOfTypeString()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("GraphDisplayName");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicLocationCodePropertyOfTypeString()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("LocationCode");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicUpArrivalDepartureAlwaysDisplayedPropertyOfTypeNullableArrivalDepartureOptions()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("UpArrivalDepartureAlwaysDisplayed");
            Assert.AreEqual(typeof(ArrivalDepartureOptions?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicDownArrivalDepartureAlwaysDisplayedPropertyOfTypeNullableArrivalDepartureOptions()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("DownArrivalDepartureAlwaysDisplayed");
            Assert.AreEqual(typeof(ArrivalDepartureOptions?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicUpRoutingCodesAlwaysDisplayedPropertyOfTypeNullableTrainRoutingOptions()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("UpRoutingCodesAlwaysDisplayed");
            Assert.AreEqual(typeof(TrainRoutingOptions?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicDownRoutingCodesAlwaysDisplayedPropertyOfTypeNullableTrainRoutingOptions()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("DownRoutingCodesAlwaysDisplayed");
            Assert.AreEqual(typeof(TrainRoutingOptions?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicDisplaySeparatorAbovePropertyOfTypeNullableBool()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("DisplaySeparatorAbove");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicDisplaySeparatorBelowPropertyOfTypeNullableBool()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("DisplaySeparatorBelow");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicIdPropertyOfTypeDistanceModel()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("Mileage");
            Assert.AreEqual(typeof(DistanceModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicEditorDisplayNamePropertyOfTypeString()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("EditorDisplayName");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicTimetableDisplayNamePropertyOfTypeString()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("TimetableDisplayName");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicFontTypeNamePropertyOfTypeString()
        {
            Type classType = typeof(LocationModel);
            PropertyInfo property = classType.GetProperty("FontTypeName");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
