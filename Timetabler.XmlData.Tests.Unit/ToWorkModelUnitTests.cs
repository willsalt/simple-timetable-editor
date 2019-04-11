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
            ConstructorInfo cInfo = typeof(ToWorkModel).GetConstructor(new Type[0]);
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
