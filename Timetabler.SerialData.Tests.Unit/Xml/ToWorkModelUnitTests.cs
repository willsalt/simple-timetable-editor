using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class ToWorkModelUnitTests
    {
        [TestMethod]
        public void ToWorkModelClassIsPublic()
        {
            Assert.IsTrue(typeof(ToWorkModel).IsPublic);
        }

        [TestMethod]
        public void ToWorkModelClassImplementsIXmlSerializable()
        {
            Assert.IsTrue(typeof(IXmlSerializable).IsAssignableFrom(typeof(ToWorkModel)));
        }

        [TestMethod]
        public void ToWorkModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(ToWorkModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void ToWorkModelClassHasPublicAtTimePropertyOfTypeTimeOfDayModel()
        {
            PropertyInfo pInfo = typeof(ToWorkModel).GetProperty("AtTime");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TimeOfDayModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void ToWorkModelClassHasPublicTextPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(ToWorkModel).GetProperty("Text");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }
    }
}
