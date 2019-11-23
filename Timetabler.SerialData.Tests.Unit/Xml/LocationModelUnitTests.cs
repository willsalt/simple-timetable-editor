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
        [TestMethod]
        public void LocationModelClassIsPublic()
        {
            Assert.IsTrue(typeof(LocationModel).IsPublic);
        }

        [TestMethod]
        public void LocationModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(LocationModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassParameterlessConstructorReturnsObjectWithMileagePropertyThatIsNotNull()
        {
            LocationModel model = new LocationModel();

            Assert.IsNotNull(model.Mileage);
        }

        [TestMethod]
        public void LocationModelClassHasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClassIdPropertyIsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("Id").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicEditorDisplayNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("EditorDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClassEditorDisplayNamePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("EditorDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicTimetableDisplayNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("TimetableDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClassGraphDisplayNamePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("GraphDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicTiplocPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("Tiploc");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClassTiplocPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("Tiploc").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicUpArrivalDepartureAlwaysDisplayedPropertyOfTypeArrivalDepartureOptions()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("UpArrivalDepartureAlwaysDisplayed");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ArrivalDepartureOptions), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClassUpArrivalDepartureAlwaysDisplayedPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("UpArrivalDepartureAlwaysDisplayed").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicUpRoutingCodesAlwaysDisplayedPropertyOfTypeNullableTrainRoutingOptions()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("UpRoutingCodesAlwaysDisplayed");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TrainRoutingOptions?), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClassUpRoutingCodesAlwaysDisplayedPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("UpRoutingCodesAlwaysDisplayed").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicDownArrivalDepartureAlwaysDisplayedPropertyOfTypeArrivalDepartureOptions()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("DownArrivalDepartureAlwaysDisplayed");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ArrivalDepartureOptions), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClassDownArrivalDepartureAlwaysDisplayedPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("DownArrivalDepartureAlwaysDisplayed").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicDownRoutingCodesAlwaysDisplayedPropertyOfTypeNullableTrainRoutingOptions()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("DownRoutingCodesAlwaysDisplayed");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TrainRoutingOptions?), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClassDownRoutingCodesAlwaysDisplayedPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("DownRoutingCodesAlwaysDisplayed").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicMileagePropertyOfTypeDistanceModel()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("Mileage");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(DistanceModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClassMileagePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("Mileage").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicFontTypeNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(LocationModel).GetProperty("FontTypeName");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationModelClassFontTypeNamePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(LocationModel).GetProperty("FontTypeName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }
    }
}
