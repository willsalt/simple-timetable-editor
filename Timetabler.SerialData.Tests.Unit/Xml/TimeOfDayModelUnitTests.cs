using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class TimeOfDayModelUnitTests
    {
        [TestMethod]
        public void TimeOfDayModelClassIsPublic()
        {
            Assert.IsTrue(typeof(TimeOfDayModel).IsPublic);
        }

        [TestMethod]
        public void TimeOfDayModelClassHasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TimeOfDayModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TimeOfDayModelClassHasPublicHours24PropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(TimeOfDayModel).GetProperty("Hours24");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimeOfDayModelClassHasPublicMinutesPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(TimeOfDayModel).GetProperty("Minutes");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimeOfDayModelClassHasPublicSecondsPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(TimeOfDayModel).GetProperty("Seconds");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }
    }
}
