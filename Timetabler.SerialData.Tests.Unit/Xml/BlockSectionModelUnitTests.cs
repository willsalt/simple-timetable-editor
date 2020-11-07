using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class BlockSectionModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void BlockSectionModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(BlockSectionModel).IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(BlockSectionModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClass_HasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(BlockSectionModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClass_IdProperty_IsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(BlockSectionModel).GetProperty("Id").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void BlockSectionModelClass_HasPublicStartLocationIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(BlockSectionModel).GetProperty("StartLocationId");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionsModelClass_StartLocationIdProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(BlockSectionModel).GetProperty("StartLocationId").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void BlockSectionModelClass_HasPublicEndLocationIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(BlockSectionModel).GetProperty("EndLocationId");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionsModelClass_EndLocationIdProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(BlockSectionModel).GetProperty("EndLocationId").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void BlockSectionsModelClass_HasPublicCapacityPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(BlockSectionModel).GetProperty("Capacity");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionsModelClass_CapacityProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(BlockSectionModel).GetProperty("Capacity").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
