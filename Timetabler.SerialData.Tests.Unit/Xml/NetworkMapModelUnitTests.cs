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
        public void NetworkMapModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(NetworkMapModel).IsPublic);
        }

        [TestMethod]
        public void NetworkMapModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(NetworkMapModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void NetworkMapModelClass_HasPublicLocationListPropertyOfTypeListOfLocationModel()
        {
            PropertyInfo pInfo = typeof(NetworkMapModel).GetProperty("LocationList");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<LocationModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void NetworkMapModelClass_LocationListProperty_IsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("LocationList").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClass_LocationListProperty_IsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("LocationList").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClass_LocationListPropertyXmlArrayItemAttributeElementNamePropertyEqualsLocation()
        {
            XmlArrayItemAttribute attr = typeof(NetworkMapModel).GetProperty("LocationList").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Location", attr.ElementName);
        }

        [TestMethod]
        public void NetworkMapModelClass_HasPublicBlockSectionsPropertyOfTypeListOfBlockSectionModel()
        {
            PropertyInfo pInfo = typeof(NetworkMapModel).GetProperty("BlockSections");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<BlockSectionModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void NetworkMapModelClass_BlockSectionsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("BlockSections").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClass_BlockSectionsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("BlockSections").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClass_BlockSectionsPropertyXmlArrayItemAttributeElementNamePropertyEqualsBlockSection()
        {
            XmlArrayItemAttribute attr = typeof(NetworkMapModel).GetProperty("BlockSections").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("BlockSection", attr.ElementName);
        }

        [TestMethod]
        public void NetworkMapModelClass_HasPublicSignalboxesPropertyOfTypeListOfSignalboxModel()
        {
            PropertyInfo pInfo = typeof(NetworkMapModel).GetProperty("Signalboxes");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<SignalboxModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void NetworkMapModelClass_SignalboxesPropertyIsDecoratedWIthXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClass_SignalboxesPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(NetworkMapModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void NetworkMapModelClass_SignalboxesPropertyXmlArrayItemAttributeElementNamePropertyEqualsSignalbox()
        {
            XmlArrayItemAttribute attr = typeof(NetworkMapModel).GetProperty("Signalboxes").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Signalbox", attr.ElementName);
        }

        [TestMethod]
        public void NetworkMapModelClass_Constructor_CreatesObjectWithLocationListPropertyThatIsNotNull()
        {
            NetworkMapModel testOutput = new NetworkMapModel();

            Assert.IsNotNull(testOutput.LocationList);
        }

        [TestMethod]
        public void NetworkMapModelClass_Constructor_CreatesObjectWithBlockSectionsPropertyThatIsNotNull()
        {
            NetworkMapModel testOutput = new NetworkMapModel();

            Assert.IsNotNull(testOutput.BlockSections);
        }

        [TestMethod]
        public void NetworkMapModelClass_Constructor_CreatesObjectWithSignalboxesPropertyThatIsNotNull()
        {
            NetworkMapModel testOutput = new NetworkMapModel();

            Assert.IsNotNull(testOutput.Signalboxes);
        }
    }
}
