using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class TrainLocationTimeModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainLocationTimeModelClass_IsPublic()
        {
            Type classType = typeof(TrainLocationTimeModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_IsNotAbstract()
        {
            Type classType = typeof(TrainLocationTimeModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(TrainLocationTimeModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicLocationIdPropertyOfTypeString()
        {
            Type classType = typeof(TrainLocationTimeModel);
            PropertyInfo property = classType.GetProperty("LocationId");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicPathPropertyOfTypeString()
        {
            Type classType = typeof(TrainLocationTimeModel);
            PropertyInfo property = classType.GetProperty("Path");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicPlatformPropertyOfTypeString()
        {
            Type classType = typeof(TrainLocationTimeModel);
            PropertyInfo property = classType.GetProperty("Platform");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicLinePropertyOfTypeString()
        {
            Type classType = typeof(TrainLocationTimeModel);
            PropertyInfo property = classType.GetProperty("Line");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicArrivalPropertyOfTypeTrainTimeModel()
        {
            Type classType = typeof(TrainLocationTimeModel);
            PropertyInfo property = classType.GetProperty("Arrival");
            Assert.AreEqual(typeof(TrainTimeModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicDeparturePropertyOfTypeTrainTimeModel()
        {
            Type classType = typeof(TrainLocationTimeModel);
            PropertyInfo property = classType.GetProperty("Departure");
            Assert.AreEqual(typeof(TrainTimeModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainLocationTimeModelClass_HasPublicPassPropertyOfTypeNullableBool()
        {
            Type classType = typeof(TrainLocationTimeModel);
            PropertyInfo property = classType.GetProperty("Pass");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
