using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Timetabler.SerialData.Tests.Unit
{
    [TestClass]
    public class TrainModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TrainModelClass_IsPublic()
        {
            Type classType = typeof(TrainModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_IsNotAbstract()
        {
            Type classType = typeof(TrainModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(TrainModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicIdPropertyOfTypeString()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("Id");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicHeadcodePropertyOfTypeString()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("Headcode");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicLocoDiagramPropertyOfTypeString()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("LocoDiagram");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }
        [TestMethod]
        public void TrainModelClass_HasPublicTrainClassIdPropertyOfTypeString()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("TrainClassId");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicInlineNotePropertyOfTypeString()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("InlineNote");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicLocoToWorkPropertyOfTypeToWorkModel()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("LocoToWork");
            Assert.AreEqual(typeof(ToWorkModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicSetToWorkPropertyOfTypeToWorkModel()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("SetToWork");
            Assert.AreEqual(typeof(ToWorkModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicGraphPropertiesPropertyOfTypeGraphTrainPropertiesModel()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("GraphProperties");
            Assert.AreEqual(typeof(GraphTrainPropertiesModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicIncludeSeparatorAbovePropertyOfTypeNullableBool()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("IncludeSeparatorAbove");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicIncludeSeparatorBelowPropertyOfTypeNullableBool()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("IncludeSeparatorBelow");
            Assert.AreEqual(typeof(bool?), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicReadableTrainTimesPropertyDerivedFromTypeICollectionOfTrainLocationTimeModel()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("TrainTimes");
            Assert.IsTrue(typeof(ICollection<TrainLocationTimeModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_HasPublicReadableFootnoteIdsPropertyDerivedFromTypeICollectionOfString()
        {
            Type classType = typeof(TrainModel);
            PropertyInfo property = classType.GetProperty("FootnoteIds");
            Assert.IsTrue(typeof(ICollection<string>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TrainModelClass_Constructor_SetsTrainTimesPropertyToEmptyCollection()
        {
            TrainModel testOutput = new TrainModel();

            Assert.IsNotNull(testOutput.TrainTimes);
            Assert.AreEqual(0, testOutput.TrainTimes.Count);
        }

        [TestMethod]
        public void TrainModelClass_Constructor_SetsFootnoteIdsPropertyToEmptyCollection()
        {
            TrainModel testOutput = new TrainModel();

            Assert.IsNotNull(testOutput.FootnoteIds);
            Assert.AreEqual(0, testOutput.FootnoteIds.Count);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
