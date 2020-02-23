using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class LocationTemplateModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void LocationTemplateModelClass_IsPublic()
        {
            Type classType = typeof(LocationTemplateModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClass_IsNotAbstract()
        {
            Type classType = typeof(LocationTemplateModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void LocationTemplateModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(LocationTemplateModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClass_HasPublicVersionPropertyOfTypeNullableInt()
        {
            Type classType = typeof(LocationTemplateModel);
            PropertyInfo property = classType.GetProperty("Version");
            Assert.AreEqual(typeof(int?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClass_HasPublicReadableMapsPropertyDerivedFromTypeICollectionOfNetworkMapModel()
        {
            Type classType = typeof(LocationTemplateModel);
            PropertyInfo property = classType.GetProperty("Maps");
            Assert.IsTrue(typeof(ICollection<NetworkMapModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void LocationTemplateModelClass_Constructor_SetsMapsPropertyToEmptyCollection()
        {
            LocationTemplateModel testOutput = new LocationTemplateModel();

            Assert.IsNotNull(testOutput.Maps);
            Assert.AreEqual(0, testOutput.Maps.Count);
        }

        [TestMethod]
        public void LocationTemplateModelClass_Constructor_SetsVersionPropertyTo3()
        {
            LocationTemplateModel testOutput = new LocationTemplateModel();

            Assert.AreEqual(3, testOutput.Version.Value);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
