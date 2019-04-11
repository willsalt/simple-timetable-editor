﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;

namespace Timetabler.XmlData.Tests.Unit
{
    [TestClass]
    public class DistanceModelUnitTests
    {
        [TestMethod]
        public void DistanceModelIsPublic()
        {
            Assert.IsTrue(typeof(DistanceModel).IsPublic);
        }

        [TestMethod]
        public void DistanceModelHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(DistanceModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void DistanceModelHasPublicMileagePropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(DistanceModel).GetProperty("Mileage");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DistanceModelMileagePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(DistanceModel).GetProperty("Mileage").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void DistanceModelHasPublicChainagePropertyOfTypeDouble()
        {
            PropertyInfo pInfo = typeof(DistanceModel).GetProperty("Chainage");
            Assert.IsNotNull(pInfo);
            Assert.AreEqual(typeof(double), pInfo.PropertyType);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
        }

        [TestMethod]
        public void DistanceModelChainagePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(DistanceModel).GetProperty("Chainage").GetCustomAttributes<XmlElementAttribute>(false).First());
        }
    }
}
