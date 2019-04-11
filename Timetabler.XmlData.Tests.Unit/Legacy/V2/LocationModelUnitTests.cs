using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Timetabler.CoreData;

namespace Timetabler.XmlData.Tests.Unit.Legacy.V2
{
    [TestClass]
    public class LocationModelUnitTests
    {
        [TestMethod]
        public void LocationModelClassIsPublic()
        {
            Assert.IsTrue(typeof(XmlData.Legacy.V2.LocationModel).IsPublic);
        }

        [TestMethod]
        public void LocationModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(XmlData.Legacy.V2.LocationModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassHasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V2.LocationModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassIdPropertyIsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.LocationModel).GetProperty("Id").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicEditorDisplayNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V2.LocationModel).GetProperty("EditorDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassEditorDisplayNamePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.LocationModel).GetProperty("EditorDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicTimetableDisplayNameProperty()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V2.LocationModel).GetProperty("TimetableDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassTimetableDisplayNamePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.LocationModel).GetProperty("TimetableDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicGraphDisplayNamePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V2.LocationModel).GetProperty("GraphDisplayName");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassGraphDisplayNamePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.LocationModel).GetProperty("GraphDisplayName").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicTiplocPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V2.LocationModel).GetProperty("Tiploc");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassTiplocPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.LocationModel).GetProperty("Tiploc").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicDefaultArrivalDepartureOptionsPropertyOfTypeArrivalDepartureOptions()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V2.LocationModel).GetProperty("DefaultArrivalDepartureOptions");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(ArrivalDepartureOptions), pInfo.PropertyType);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassDefaultArrivalDepartureOptionsPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.LocationModel).GetProperty("DefaultArrivalDepartureOptions").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassDefaultArrivalDepartureOptionsPropertyIsDecoratedWithObsoleteAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.LocationModel).GetProperty("DefaultArrivalDepartureOptions").GetCustomAttributes<ObsoleteAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicUpArrivalDepartureAlwaysDisplayedPropertyOfTypeArrivalDepartureOptions()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V2.LocationModel).GetProperty("UpArrivalDepartureAlwaysDisplayed");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(ArrivalDepartureOptions), pInfo.PropertyType);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassUpArrivalDepartureOptionsAlwaysDisplayedPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.LocationModel).GetProperty("UpArrivalDepartureAlwaysDisplayed").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicDownArrivalDepartureAlwaysDisplayedPropertyOfTypeArrivalDepartureOptions()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V2.LocationModel).GetProperty("DownArrivalDepartureAlwaysDisplayed");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(ArrivalDepartureOptions), pInfo.PropertyType);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassDownArrivalDepartureOptionsAlwaysDisplayedPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.LocationModel).GetProperty("DownArrivalDepartureAlwaysDisplayed").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassHasPublicMileagePropertyOfTypeDistanceModel()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V2.LocationModel).GetProperty("Mileage");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(DistanceModel), pInfo.PropertyType);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationModelClassMileagePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V2.LocationModel).GetProperty("Mileage").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void LocationModelClassMileagePropertyIsNotNullOnConstruction()
        {
            XmlData.Legacy.V2.LocationModel testObject = new XmlData.Legacy.V2.LocationModel();

            Assert.IsNotNull(testObject.Mileage);
        }
    }
}
