using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Timetabler.SerialData.Yaml;

namespace Timetabler.SerialData.Tests.Unit.Yaml
{
    [TestClass]
    public class TimetableFileModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TimetableFileModelClass_IsPublic()
        {
            Type classType = typeof(TimetableFileModel);
            Assert.IsTrue(classType.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_IsNotAbstract()
        {
            Type classType = typeof(TimetableFileModel);
            Assert.IsFalse(classType.IsAbstract);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicParameterlessConstructor()
        {
            Type classType = typeof(TimetableFileModel);
            ConstructorInfo constructor = classType.GetConstructor(Array.Empty<Type>());
            Assert.IsTrue(constructor.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicVersionPropertyOfTypeInt()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("Version");
            Assert.AreEqual(typeof(int), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicFileOptionsPropertyOfTypeDocumentOptionsModel()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("FileOptions");
            Assert.AreEqual(typeof(DocumentOptionsModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicExportOptionsPropertyOfTypeExportOptionsModel()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("ExportOptions");
            Assert.AreEqual(typeof(ExportOptionsModel), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicTitlePropertyOfTypeString()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("Title");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicSubtitlePropertyOfTypeString()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("Subtitle");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicDateDescriptionPropertyOfTypeString()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("DateDescription");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicWrittenByPropertyOfTypeString()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("WrittenBy");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicCheckedByPropertyOfTypeString()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("CheckedBy");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicTimetableVersionPropertyOfTypeString()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("TimetableVersion");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicPublishedDatePropertyOfTypeString()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("PublishedDate");
            Assert.AreEqual(typeof(string), property.PropertyType);
            Assert.IsTrue(property.GetMethod.IsPublic);
            Assert.IsTrue(property.SetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicReadableMapsPropertyDerivedFromTypeICollectionOfNetworkMapModel()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("Maps");
            Assert.IsTrue(typeof(ICollection<NetworkMapModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicReadableSignalboxHoursSetsPropertyDerivedFromTypeICollectionOfSignalboxHoursSetModel()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("SignalboxHoursSets");
            Assert.IsTrue(typeof(ICollection<SignalboxHoursSetModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicReadableNoteDefinitionsPropertyDerivedFromTypeICollectionOfNoteModel()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("NoteDefinitions");
            Assert.IsTrue(typeof(ICollection<NoteModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicReadableTrainClassListPropertyDerivedFromTypeICollectionOfTrainClassModel()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("TrainClassList");
            Assert.IsTrue(typeof(ICollection<TrainClassModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicReadableTrainListPropertyDerivedFromTypeICollectionOfTrainModel()
        {
            Type classType = typeof(TimetableFileModel);
            PropertyInfo property = classType.GetProperty("TrainList");
            Assert.IsTrue(typeof(ICollection<TrainModel>).IsAssignableFrom(property.PropertyType));
            Assert.IsTrue(property.GetMethod.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_Constructor_SetsMapsPropertyToEmptyCollection()
        {
            TimetableFileModel testOutput = new TimetableFileModel();

            Assert.IsNotNull(testOutput.Maps);
            Assert.AreEqual(0, testOutput.Maps.Count);
        }

        [TestMethod]
        public void TimetableFileModelClass_Constructor_SetsSignalboxHoursSetsPropertyToEmptyCollection()
        {
            TimetableFileModel testOutput = new TimetableFileModel();

            Assert.IsNotNull(testOutput.SignalboxHoursSets);
            Assert.AreEqual(0, testOutput.SignalboxHoursSets.Count);
        }

        [TestMethod]
        public void TimetableFileModelClass_Constructor_SetsTrainListPropertyToEmptyCollection()
        {
            TimetableFileModel testOutput = new TimetableFileModel();

            Assert.IsNotNull(testOutput.TrainList);
            Assert.AreEqual(0, testOutput.TrainList.Count);
        }

        [TestMethod]
        public void TimetableFileModelClass_Constructor_SetsTrainClassListPropertyToEmptyCollection()
        {
            TimetableFileModel testOutput = new TimetableFileModel();

            Assert.IsNotNull(testOutput.TrainClassList);
            Assert.AreEqual(0, testOutput.TrainClassList.Count);
        }

        [TestMethod]
        public void TimetableFileModelClass_Constructor_SetsNoteDefinitionsPropertyToEmptyCollection()
        {
            TimetableFileModel testOutput = new TimetableFileModel();

            Assert.IsNotNull(testOutput.NoteDefinitions);
            Assert.AreEqual(0, testOutput.NoteDefinitions.Count);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
