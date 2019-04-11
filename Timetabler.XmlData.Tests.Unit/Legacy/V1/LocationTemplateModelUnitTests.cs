using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Timetabler.XmlData.Tests.Unit.Legacy.V1
{
    [TestClass]
    public class LocationTemplateModelUnitTests
    {
        [TestMethod]
        public void LocationTemplateModelClassIsPublic()
        {
            Assert.IsTrue(typeof(XmlData.Legacy.V1.LocationTemplateModel).IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(XmlData.Legacy.V1.LocationTemplateModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClassIsDecoratedWithXmlRootAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V1.LocationTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First());
        }

        [TestMethod]
        public void LocationTemplateModelClassXmlRootAttributeElementNamePropertyEqualsLocationTemplateModel()
        {
            XmlRootAttribute attr = typeof(XmlData.Legacy.V1.LocationTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual("LocationTemplateModel", attr.ElementName);
        }

        [TestMethod]
        public void LocationTemplateModelClassXmlRootAttributeNamespacePropertyEqualsNamespacesV1()
        {
            XmlRootAttribute attr = typeof(XmlData.Legacy.V1.LocationTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual(Namespaces.V1, attr.Namespace);
        }

        [TestMethod]
        public void LocationTemplateModelClassHasPublicVersionPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V1.LocationTemplateModel).GetProperty("Version");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClassVersionPropertyIsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V1.LocationTemplateModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void LocationTemplateModelClassVersionPropertyXmlAttributeAttributeAttributeNamePropertyEqualsVersion()
        {
            XmlAttributeAttribute attr = typeof(XmlData.Legacy.V1.LocationTemplateModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>(false).First();
            Assert.AreEqual("version", attr.AttributeName);
        }

        [TestMethod]
        public void LocationTemplateModelClassVersionPropertyEquals1OnConstruction()
        {
            XmlData.Legacy.V1.LocationTemplateModel testObject = new XmlData.Legacy.V1.LocationTemplateModel();

            Assert.AreEqual(1, testObject.Version);
        }

        [TestMethod]
        public void LocationTemplateModelClassHasPublicLocationListPropertyOfTypeListOfLocationModel()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V1.LocationTemplateModel).GetProperty("LocationList");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(List<LocationModel>), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClassLocationListPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V1.LocationTemplateModel).GetProperty("LocationList").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void LocationTemplateModelClassLocationListPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(XmlData.Legacy.V1.LocationTemplateModel).GetProperty("LocationList").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void LocationTemplateModelClassLocationListPropertyXmlArrayItemAttributeElementNamePropertyEqualsLocation()
        {
            XmlArrayItemAttribute attr = typeof(XmlData.Legacy.V1.LocationTemplateModel).GetProperty("LocationList").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Location", attr.ElementName);
        }
    }
}
