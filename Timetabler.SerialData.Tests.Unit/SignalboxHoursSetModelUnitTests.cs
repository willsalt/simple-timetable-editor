using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Timetabler.SerialData.Tests.Unit
{
    [TestClass]
    public class SignalboxHoursSetModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void SignalboxHoursSetModelClass_IsPublic()
        {
            Type classType = typeof(SignalboxHoursSetModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_IsNotAbstract()
        {
            Type classType = typeof(SignalboxHoursSetModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(SignalboxHoursSetModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_HasPublicCategoryPropertyOfTypeString()
        {
            Type classType = typeof(SignalboxHoursSetModel);
            PropertyInfo property = classType.GetProperty("Category");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_HasPublicReadableSignalboxesPropertyDerivedFromTypeICollectionOfSignalboxHoursModel()
        {
            Type classType = typeof(SignalboxHoursSetModel);
            PropertyInfo property = classType.GetProperty("Signalboxes");
            Assert.IsTrue(typeof(ICollection<SignalboxHoursModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void SignalboxHoursSetModelClass_Constructor_SetsSignalboxesPropertyToEmptyCollection()
        {
            SignalboxHoursSetModel testOutput = new SignalboxHoursSetModel();

            Assert.IsNotNull(testOutput.Signalboxes);
            Assert.AreEqual(0, testOutput.Signalboxes.Count);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
