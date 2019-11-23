using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class SignalboxHoursModelUnitTests
    {
        [TestMethod]
        public void SignalboxHoursModelClassIsPublic()
        {
            Assert.IsTrue(typeof(SignalboxHoursModel).IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(SignalboxHoursModel).GetConstructor(new Type[0]);
            Assert.IsNotNull(cInfo);
        }

        [TestMethod]
        public void SignalboxHoursModelClassHasPublicSignalboxIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursModel).GetProperty("SignalboxId");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursModelClassSignalboxIdPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursModel).GetProperty("SignalboxId").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursModelClassHasPublicStartTimePropertyOfTypeTimeOfDayModel()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursModel).GetProperty("StartTime");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TimeOfDayModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursModelClassStartTimePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursModel).GetProperty("StartTime").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursModelClassHasPublicFinishTimePropertyOfTypeTimeOfDayModel()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursModel).GetProperty("FinishTime");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TimeOfDayModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursModelClassFinishTimePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursModel).GetProperty("FinishTime").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursModelClassHasPublicTokenBalanceWarningPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursModel).GetProperty("TokenBalanceWarning");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursModelClassTokenBalanceWarningPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursModel).GetProperty("TokenBalanceWarning").GetCustomAttributes<XmlElementAttribute>(false).First());
        }
    }
}
