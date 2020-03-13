using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class NetworkMapModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void NetworkMapModelClass_IsPublic()
        {
            Type classType = typeof(NetworkMapModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void NetworkMapModelClass_IsNotAbstract()
        {
            Type classType = typeof(NetworkMapModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void NetworkMapModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(NetworkMapModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void NetworkMapModelClass_HasPublicReadableLocationListPropertyDerivedFromTypeICollectionOfLocationModel()
        {
            Type classType = typeof(NetworkMapModel);
            PropertyInfo property = classType.GetProperty("LocationList");
            Assert.IsTrue(typeof(ICollection<LocationModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void NetworkMapModelClass_HasPublicReadableBlockSectionsPropertyDerivedFromTypeICollectionOfLocationModel()
        {
            Type classType = typeof(NetworkMapModel);
            PropertyInfo property = classType.GetProperty("BlockSections");
            Assert.IsTrue(typeof(ICollection<BlockSectionModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void NetworkMapModelClass_HasPublicReadableSignalboxesPropertyDerivedFromTypeICollectionOfLocationModel()
        {
            Type classType = typeof(NetworkMapModel);
            PropertyInfo property = classType.GetProperty("Signalboxes");
            Assert.IsTrue(typeof(ICollection<SignalboxModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void NetworkMapModelClass_Constructor_SetsLocationListPropertyToEmptyCollection()
        {
            NetworkMapModel testOutput = new NetworkMapModel();

            Assert.IsNotNull(testOutput.LocationList);
            Assert.AreEqual(0, testOutput.LocationList.Count);
        }

        [TestMethod]
        public void NetworkMapModelClass_Constructor_SetsBlockSectionsPropertyToEmptyCollection()
        {
            NetworkMapModel testOutput = new NetworkMapModel();

            Assert.IsNotNull(testOutput.BlockSections);
            Assert.AreEqual(0, testOutput.BlockSections.Count);
        }

        [TestMethod]
        public void NetworkMapModelClass_Constructor_SetsSignalboxesPropertyToEmptyCollection()
        {
            NetworkMapModel testOutput = new NetworkMapModel();

            Assert.IsNotNull(testOutput.Signalboxes);
            Assert.AreEqual(0, testOutput.Signalboxes.Count);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
