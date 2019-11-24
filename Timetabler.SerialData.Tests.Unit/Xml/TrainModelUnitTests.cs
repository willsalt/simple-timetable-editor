using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class TrainModelUnitTests
    {
        [TestMethod]
        public void TrainModelClassIsPublic()
        {
            Assert.IsTrue(typeof(TrainModel).IsPublic);
        }

        [TestMethod]
        public void TrainModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TrainModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TrainModelClassHasPublicIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("Id");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicHeadcodePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("Headcode");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicLocoDiagramPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("LocoDiagram");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicTrainClassIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("TrainClassId");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicGraphPropertiesPropertyOfTypeGraphTrainPropertiesModel()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("GraphProperties");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(GraphTrainPropertiesModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicTrainTimesPropertyOfTypeListOfTrainLocationTimeModel()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("TrainTimes");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<TrainLocationTimeModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicFootnoteIdsPropertyOfTypeListOfString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("FootnoteIds");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<string>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicIncludeSeparatorAbovePropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("IncludeSeparatorAbove");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicIncludeSeparatorBelowPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("IncludeSeparatorBelow");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicInlineNotePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("InlineNote");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicToWorkPropertyOfTypeToWorkModel()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("ToWork");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ToWorkModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainModelClassHasPublicLocoToWorkPropertyOfTypeToWorkModel()
        {
            PropertyInfo pInfo = typeof(TrainModel).GetProperty("LocoToWork");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ToWorkModel), pInfo.PropertyType);
        }
    }
}
