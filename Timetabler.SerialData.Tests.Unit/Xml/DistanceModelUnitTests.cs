using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class DistanceModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void DistanceModel_IsPublic()
        {
            Assert.IsTrue(typeof(DistanceModel).IsPublic);
        }

        [TestMethod]
        public void DistanceModel_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(DistanceModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void DistanceModel_HasPublicMileagePropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(DistanceModel).GetProperty("Mileage");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DistanceModel_MileageProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(DistanceModel).GetProperty("Mileage").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void DistanceModel_HasPublicChainagePropertyOfTypeDouble()
        {
            PropertyInfo pInfo = typeof(DistanceModel).GetProperty("Chainage");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(double), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DistanceModel_ChainageProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(DistanceModel).GetProperty("Chainage").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
