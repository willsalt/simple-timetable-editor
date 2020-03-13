using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class SignalboxHoursModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SignalboxHoursModelClass_IsPublic()
        {
            Type classType = typeof(SignalboxHoursModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_IsNotAbstract()
        {
            Type classType = typeof(SignalboxHoursModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(SignalboxHoursModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_HasPublicSignalboxIdPropertyOfTypeString()
        {
            Type classType = typeof(SignalboxHoursModel);
            PropertyInfo property = classType.GetProperty("SignalboxId");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_HasPublicStartTimePropertyOfTypeTimeOfDayModel()
        {
            Type classType = typeof(SignalboxHoursModel);
            PropertyInfo property = classType.GetProperty("StartTime");
            Assert.AreEqual(typeof(TimeOfDayModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_HasPublicFinishTimePropertyOfTypeTimeOfDayModel()
        {
            Type classType = typeof(SignalboxHoursModel);
            PropertyInfo property = classType.GetProperty("FinishTime");
            Assert.AreEqual(typeof(TimeOfDayModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursModelClass_HasPublicTokenBalanceWarningPropertyOfTypeNullableBool()
        {
            Type classType = typeof(SignalboxHoursModel);
            PropertyInfo property = classType.GetProperty("TokenBalanceWarning");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }


#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
