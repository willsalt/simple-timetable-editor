using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class SignalboxModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SignalboxModelClass_IsPublic()
        {
            Type classType = typeof(SignalboxModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void SignalboxModelClass_IsNotAbstract()
        {
            Type classType = typeof(SignalboxModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void SignalboxModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(SignalboxModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void SignalboxModelClass_HasPublicIdPropertyOfTypeString()
        {
            Type classType = typeof(SignalboxModel);
            PropertyInfo property = classType.GetProperty("Id");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void SignalboxModelClass_HasPublicCodePropertyOfTypeString()
        {
            Type classType = typeof(SignalboxModel);
            PropertyInfo property = classType.GetProperty("Code");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void SignalboxModelClass_HasPublicEditorDisplayNamePropertyOfTypeString()
        {
            Type classType = typeof(SignalboxModel);
            PropertyInfo property = classType.GetProperty("EditorDisplayName");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void SignalboxModelClass_HasPublicTimetableDisplayNamePropertyOfTypeString()
        {
            Type classType = typeof(SignalboxModel);
            PropertyInfo property = classType.GetProperty("TimetableDisplayName");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
