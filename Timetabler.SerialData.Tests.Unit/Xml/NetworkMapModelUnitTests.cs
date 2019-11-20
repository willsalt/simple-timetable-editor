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
    public class NetworkMapModelUnitTests
    {
        [TestMethod]
        public void NetworkMapModelClassIsPublic()
        {
            Assert.IsTrue(typeof(NetworkMapModel).IsPublic);
        }

        [TestMethod]
        public void NetworkMapModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(NetworkMapModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void NetworkMapModelClassHasPublicLocationListPropertyOfTypeListOfLocationModel()
        {
            PropertyInfo pInfo = typeof(NetworkMapModel).GetProperty("LocationList");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<LocationModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void NetworkMapModelClassLocationListPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("LocationList").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClassLocationListPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("LocationList").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClassLocationListPropertyXmlArrayItemAttributeElementNamePropertyEqualsLocation()
        {
            XmlArrayItemAttribute attr = typeof(NetworkMapModel).GetProperty("LocationList").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Location", attr.ElementName);
        }

        [TestMethod]
        public void NetworkMapModelClassHasPublicBlockSectionsPropertyOfTypeListOfBlockSectionModel()
        {
            PropertyInfo pInfo = typeof(NetworkMapModel).GetProperty("BlockSections");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<BlockSectionModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void NetworkMapModelClassBlockSectionsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("BlockSections").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClassBlockSectionsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("BlockSections").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClassBlockSectionsPropertyXmlArrayItemAttributeElementNamePropertyEqualsBlockSection()
        {
            XmlArrayItemAttribute attr = typeof(NetworkMapModel).GetProperty("BlockSections").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("BlockSection", attr.ElementName);
        }

        [TestMethod]
        public void NetworkMapModelClassHasPublicSignalboxesPropertyOfTypeListOfSignalboxModel()
        {
            PropertyInfo pInfo = typeof(NetworkMapModel).GetProperty("Signalboxes");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<SignalboxModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void NetworkMapModelClassSignalboxesPropertyIsDecoratedWIthXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClassSignalboxesPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClassSignalboxesPropertyXmlArrayItemAttributeElementNamePropertyEqualsSignalbox()
        {
            XmlArrayItemAttribute attr = typeof(NetworkMapModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Signalbox", attr.ElementName);
        }
    }
}
