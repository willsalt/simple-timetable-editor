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
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SignalboxHoursModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(SignalboxHoursModel).IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(SignalboxHoursModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_HasPublicSignalboxIdPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursModel).GetProperty("SignalboxId");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_SignalboxIdProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursModel).GetProperty("SignalboxId").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursModelClass_HasPublicStartTimePropertyOfTypeTimeOfDayModel()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursModel).GetProperty("StartTime");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TimeOfDayModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_StartTimeProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursModel).GetProperty("StartTime").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursModelClass_HasPublicFinishTimePropertyOfTypeTimeOfDayModel()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursModel).GetProperty("FinishTime");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(TimeOfDayModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_FinishTimeProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursModel).GetProperty("FinishTime").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void SignalboxHoursModelClass_HasPublicTokenBalanceWarningPropertyOfTypeBool()
        {
            PropertyInfo pInfo = typeof(SignalboxHoursModel).GetProperty("TokenBalanceWarning");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(bool), pInfo.PropertyType);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_TokenBalanceWarningProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SignalboxHoursModel).GetProperty("TokenBalanceWarning").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
