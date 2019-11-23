using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class TrainTimeModelUnitTests
    {
        [TestMethod]
        public void TrainTimeModelClassIsPublic()
        {
            Assert.IsTrue(typeof(TrainTimeModel).IsPublic);
        }

        [TestMethod]
        public void TrainTimeModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TrainTimeModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TrainTimeModelClassHasPublicTimePropertyOfTypeTimeOfDayModel()
        {
            PropertyInfo pInfo = typeof(TrainTimeModel).GetProperty("Time");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TimeOfDayModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TrainTimeModelClassHasPublicFootnoteIdsPropertyOfTypeListOfString()
        {
            PropertyInfo pInfo = typeof(TrainTimeModel).GetProperty("FootnoteIds");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(List<string>), pInfo.PropertyType);
        }
    }
}
