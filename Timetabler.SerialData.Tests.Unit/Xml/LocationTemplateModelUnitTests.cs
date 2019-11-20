using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class LocationTemplateModelUnitTests
    {
        [TestMethod]
        public void LocationTemplateModelClassIsPublic()
        {
            Assert.IsTrue(typeof(LocationTemplateModel).IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClassIsDecoratedWithXmlRootAttribute()
        {
            Assert.IsNotNull(typeof(LocationTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First());
        }

        [TestMethod]
        public void LocationTemplateModelClassXmlRootAttributeElementNamePropertyEqualsLocationTemplateModel()
        {
            XmlRootAttribute attr = typeof(LocationTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual("LocationTemplateModel", attr.ElementName);
        }

        [TestMethod]
        public void LocationTemplateModelClassXmlRootAttributeNamespacePropertyEqualsNamespacesV3()
        {
            XmlRootAttribute attr = typeof(LocationTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual(Namespaces.V3, attr.Namespace);
        }

        [TestMethod]
        public void LocationTemplateModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(LocationTemplateModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClassParameterlessConstructorSetsVersionPropertyTo3()
        {
            LocationTemplateModel model = new LocationTemplateModel();

            Assert.AreEqual(3, model.Version);
        }

        [TestMethod]
        public void LocationTemplateModelClassHasPublicVersionPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(LocationTemplateModel).GetProperty("Version");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationTemplateModelClassVersionPropertyIsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(LocationTemplateModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>().First());
        }

        [TestMethod]
        public void LocationTemplateModelClassVersionPropertyXmlAttributeAttributeAttributeNamePropertyEqualsVersion()
        {
            XmlAttributeAttribute attribute = typeof(LocationTemplateModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>().First();
            Assert.AreEqual("version", attribute.AttributeName);
        }

        [TestMethod]
        public void LocationTemplateModelClassHasPublicMapsPropertyOfTypeListOfNetworkMapModel()
        {
            PropertyInfo pInfo = typeof(LocationTemplateModel).GetProperty("Maps");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<NetworkMapModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationTemplateModelClassMapsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(LocationTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void LocationTemplateModelClassMapsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(LocationTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void LocationTemplateModelClassMapsPropertyXmlArrayItemAttributeElementNamePropertyEqualsMap()
        {
            XmlArrayItemAttribute attr = typeof(LocationTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Map", attr.ElementName);
        }
    }
}
