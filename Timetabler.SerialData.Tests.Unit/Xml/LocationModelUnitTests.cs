using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.CoreData;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class LocationModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void LocationModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(LocationModel).IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(LocationModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void LocationModelClass_ParameterlessConstructor_ReturnsObjectWithMileagePropertyThatIsNotNull()
        {
            LocationModel model = new LocationModel();

            Assert.IsNotNull(model.Mileage);
        }

        [TestMethod]
        public void LocationModelClass_HasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClass_IdProperty_IsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("Id").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClass_HasPublicEditorDisplayNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("EditorDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClass_EditorDisplayNameProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("EditorDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClass_HasPublicTimetableDisplayNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("TimetableDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClass_GraphDisplayNameProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("GraphDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClass_HasPublicTiplocPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("Tiploc");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClass_TiplocProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("Tiploc").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClass_HasPublicUpArrivalDepartureAlwaysDisplayedPropertyOfTypeArrivalDepartureOptions()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("UpArrivalDepartureAlwaysDisplayed");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ArrivalDepartureOptions), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClass_UpArrivalDepartureAlwaysDisplayedProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("UpArrivalDepartureAlwaysDisplayed").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClass_HasPublicUpRoutingCodesAlwaysDisplayedPropertyOfTypeNullableTrainRoutingOptions()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("UpRoutingCodesAlwaysDisplayed");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TrainRoutingOptions?), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClass_UpRoutingCodesAlwaysDisplayedProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("UpRoutingCodesAlwaysDisplayed").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClass_HasPublicDownArrivalDepartureAlwaysDisplayedPropertyOfTypeArrivalDepartureOptions()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("DownArrivalDepartureAlwaysDisplayed");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ArrivalDepartureOptions), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClass_DownArrivalDepartureAlwaysDisplayedProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("DownArrivalDepartureAlwaysDisplayed").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClass_HasPublicDownRoutingCodesAlwaysDisplayedPropertyOfTypeNullableTrainRoutingOptions()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("DownRoutingCodesAlwaysDisplayed");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TrainRoutingOptions?), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClass_DownRoutingCodesAlwaysDisplayedProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("DownRoutingCodesAlwaysDisplayed").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClass_HasPublicMileagePropertyOfTypeDistanceModel()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("Mileage");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(DistanceModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClass_MileageProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("Mileage").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClass_HasPublicFontTypeNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("FontTypeName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClass_FontTypeNameProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("FontTypeName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
