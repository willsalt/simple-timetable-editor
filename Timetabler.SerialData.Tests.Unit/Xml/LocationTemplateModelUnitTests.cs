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
        public void LocationTemplateModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(LocationTemplateModel).IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClass_IsDecoratedWithXmlRootAttribute()
        {
            Assert.IsNotNull(typeof(LocationTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First());
        }

        [TestMethod]
        public void LocationTemplateModelClass_XmlRootAttributeElementNamePropertyEqualsLocationTemplateModel()
        {
            XmlRootAttribute attr = typeof(LocationTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual("LocationTemplateModel", attr.ElementName);
        }

        [TestMethod]
        public void LocationTemplateModelClass_XmlRootAttributeNamespacePropertyEqualsNamespacesV3()
        {
            XmlRootAttribute attr = typeof(LocationTemplateModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual(Namespaces.V3, attr.Namespace);
        }

        [TestMethod]
        public void LocationTemplateModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(LocationTemplateModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClass_ParameterlessConstructorSetsVersionPropertyTo3()
        {
            LocationTemplateModel model = new LocationTemplateModel();

            Assert.AreEqual(3, model.Version);
        }

        [TestMethod]
        public void LocationTemplateModelClass_HasPublicVersionPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(LocationTemplateModel).GetProperty("Version");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationTemplateModelClass_VersionPropertyIsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(LocationTemplateModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>().First());
        }

        [TestMethod]
        public void LocationTemplateModelClass_VersionPropertyXmlAttributeAttributeAttributeNamePropertyEqualsVersion()
        {
            XmlAttributeAttribute attribute = typeof(LocationTemplateModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>().First();
            Assert.AreEqual("version", attribute.AttributeName);
        }

        [TestMethod]
        public void LocationTemplateModelClass_HasPublicMapsPropertyOfTypeListOfNetworkMapModel()
        {
            PropertyInfo pInfo = typeof(LocationTemplateModel).GetProperty("Maps");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<NetworkMapModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void LocationTemplateModelClass_MapsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(LocationTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void LocationTemplateModelClass_MapsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(LocationTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void LocationTemplateModelClass_MapsPropertyXmlArrayItemAttributeElementNamePropertyEqualsMap()
        {
            XmlArrayItemAttribute attr = typeof(LocationTemplateModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Map", attr.ElementName);
        }

        [TestMethod]
        public void LocationTemplateModelClass_Constructor_CreatesObjectWithMapsPropertyThatIsNotNull()
        {
            LocationTemplateModel testOutput = new LocationTemplateModel();

            Assert.IsNotNull(testOutput.Maps);
        }
    }
}
