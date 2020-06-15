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
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainClassModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(TrainClassModel).IsPublic);
        }

        [TestMethod]
        public void TrainClassModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TrainClassModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TrainClassModelClass_HasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainClassModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainClassModelClass_IdProperty_IsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(TrainClassModel).GetProperty("Id").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void TrainClassModelClass_HasPublicTableCodePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainClassModel).GetProperty("TableCode");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainClassModelClass_TableCodeProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TrainClassModel).GetProperty("TableCode").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TrainClassModelClass_HasPublicDescriptionPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainClassModel).GetProperty("Description");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainClassModelClass_DescriptionProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TrainClassModel).GetProperty("Description").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
