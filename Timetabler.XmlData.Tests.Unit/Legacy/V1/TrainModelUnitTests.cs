using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Timetabler.XmlData.Tests.Unit.Legacy.V1
{
    [TestClass]
    public class TrainModelUnitTests
    {
        [TestMethod]
        public void TrainModelClassIsPublic()
        {
            Assert.IsTrue(typeof(XmlData.Legacy.V1.TrainModel).IsPublic);
        }

        [TestMethod]
        public void TrainModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(XmlData.Legacy.V1.TrainModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TrainModelClassHasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V1.TrainModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicHeadcodePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V1.TrainModel).GetProperty("Headcode");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicTrainClassIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V1.TrainModel).GetProperty("TrainClassId");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicGraphPropertiesPropertyOfTypeGraphTrainPropertiesModel()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V1.TrainModel).GetProperty("GraphProperties");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(GraphTrainPropertiesModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicTrainTimesPropertyOfTypeListOfTrainLocationTimeModel()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V1.TrainModel).GetProperty("TrainTimes");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<TrainLocationTimeModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicFootnoteIdsPropertyOfTypeListOfString()
        {
            PropertyInfo pInfo = typeof(XmlData.Legacy.V1.TrainModel).GetProperty("FootnoteIds");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<string>), pInfo.PropertyType);
        }
    }
}
