using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class TrainClassModelUnitTests
    {
        [TestMethod]
        public void TrainClassModelClassIsPublic()
        {
            Assert.IsTrue(typeof(TrainClassModel).IsPublic);
        }

        [TestMethod]
        public void TrainClassModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TrainClassModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TrainClassModelClassHasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainClassModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainClassModelClassIdPropertyIsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(TrainClassModel).GetProperty("Id").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void TrainClassModelClassHasPublicTableCodePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainClassModel).GetProperty("TableCode");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainClassModelClassTableCodePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TrainClassModel).GetProperty("TableCode").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TrainClassModelClassHasPublicDescriptionPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainClassModel).GetProperty("Description");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainClassModelClassDescriptionPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TrainClassModel).GetProperty("Description").GetCustomAttributes<XmlElementAttribute>(false).First());
        }
    }
}
