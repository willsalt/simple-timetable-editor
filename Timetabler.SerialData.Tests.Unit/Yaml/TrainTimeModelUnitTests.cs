using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class TrainTimeModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainTimeModelClass_IsPublic()
        {
            Type classType = typeof(TrainTimeModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void TrainTimeModelClass_IsNotAbstract()
        {
            Type classType = typeof(TrainTimeModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void TrainTimeModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(TrainTimeModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void TrainTimeModelClass_HasPublicAtPropertyOfTypeTimeOfDayModel()
        {
            Type classType = typeof(TrainTimeModel);
            PropertyInfo property = classType.GetProperty("At");
            Assert.AreEqual(typeof(TimeOfDayModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainTimeModelClass_HasPublicReadableFootnoteIdsPropertyDerivedFromTypeICollectionOfString()
        {
            Type classType = typeof(TrainTimeModel);
            PropertyInfo property = classType.GetProperty("FootnoteIds");
            Assert.IsTrue(typeof(ICollection<string>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainTimeModelClass_Constructor_SetsFootnoteIdsPropertyToEmptyCollection()
        {
            TrainTimeModel testOutput = new TrainTimeModel();

            Assert.IsNotNull(testOutput.FootnoteIds);
            Assert.AreEqual(0, testOutput.FootnoteIds.Count);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores


    }
}
