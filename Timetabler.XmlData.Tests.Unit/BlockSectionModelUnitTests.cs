using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Timetabler.XmlData.Tests.Unit
{
    [TestClass]
    public class BlockSectionModelUnitTests
    {
        [TestMethod]
        public void BlockSectionModelClassIsPublic()
        {
            Assert.IsTrue(typeof(BlockSectionModel).IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(BlockSectionModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClassHasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(BlockSectionModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionModelClassIdPropertyIsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(BlockSectionModel).GetProperty("Id").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void BlockSectionModelClassHasPublicStartLocationIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(BlockSectionModel).GetProperty("StartLocationId");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionsModelClassStartLocationIdPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(BlockSectionModel).GetProperty("StartLocationId").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void BlockSectionModelClassHasPublicEndLocationIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(BlockSectionModel).GetProperty("EndLocationId");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionsModelClassEndLocationIdPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(BlockSectionModel).GetProperty("EndLocationId").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void BlockSectionsModelClassHasPublicCapacityPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(BlockSectionModel).GetProperty("Capacity");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void BlockSectionsModelClassCapacityPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(BlockSectionModel).GetProperty("Capacity").GetCustomAttributes<XmlElementAttribute>(false).First());
        }
    }
}
