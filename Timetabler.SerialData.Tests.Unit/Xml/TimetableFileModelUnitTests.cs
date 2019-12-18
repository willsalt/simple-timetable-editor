using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml
{
    [TestClass]
    public class TimetableFileModelUnitTests
    {
        [TestMethod]
        public void TimetableFileModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(TimetableFileModel).IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_IsDecoratedWithXmlRootAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetCustomAttributes<XmlRootAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_XmlRootAttributeElementNamePropertyEqualsDocumentModel()
        {
            XmlRootAttribute attr = typeof(TimetableFileModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual("DocumentModel", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_XmlRootAttributeNamespacePropertyEqualsNamespacesV4()
        {
            XmlRootAttribute attr = typeof(TimetableFileModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual(Namespaces.V4, attr.Namespace);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(TimetableFileModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicVersionPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("Version");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_VersionPropertyIsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_VersionPropertyXmlAttributeAttributeAttributeNamePropertyEqualsVersion()
        {
            XmlAttributeAttribute attr = typeof(TimetableFileModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>(false).First();
            Assert.AreEqual("version", attr.AttributeName);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicOptionsPropertyOfTypeDocumentOptionsModel()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("Options");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(DocumentOptionsModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_OptionsPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("Options").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicTitlePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("Title");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_TitlePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("Title").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicSubtitlePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("Subtitle");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_SubtitlePropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("Subtitle").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicDateDescriptionPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("DateDescription");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_DateDescriptionPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("DateDescription").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicNoteDefinitionsPropertyOfTypeListOfNoteModel()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("NoteDefinitions");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<NoteModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_NoteDefinitionsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_NoteDefinitionsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_NoteDefinitionsPropertyXmlArrayItemAttributeElementNamePropertyEqualsNote()
        {
            XmlArrayItemAttribute attr = typeof(TimetableFileModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Note", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicTrainClassListPropertyOfTypeListOfTrainClassModel()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("TrainClassList");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<TrainClassModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainClassListPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("TrainClassList").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainClassListPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("TrainClassList").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainClassListPropertyXmlArrayItemAttributeElementNamePropertyEqualsTrainClass()
        {
            XmlArrayItemAttribute attr = typeof(TimetableFileModel).GetProperty("TrainClassList").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("TrainClass", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicTrainListPropertyOfTypeListOfTrainModel()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("TrainList");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<TrainModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainListPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("TrainList").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainListPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("TrainList").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainListPropertyXmlArrayItemAttributeElementNamePropertyEqualsTrain()
        {
            XmlArrayItemAttribute attr = typeof(TimetableFileModel).GetProperty("TrainList").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Train", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicWrittenByPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("WrittenBy");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_WrittenByPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("WrittenBy").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicCheckedByPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("CheckedBy");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_CheckedByPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("CheckedBy").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicTimetableVersionPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("TimetableVersion");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_TimetableVersionPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("TimetableVersion").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicPublishedDatePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("PublishedDate");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_PublishedDatePropertyIsDecoratedFromXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("PublishedDate").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicMapsPropertyOfTypeListOfNetworkMapModels()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("Maps");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<NetworkMapModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_MapsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("Maps").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_MapsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_MapsPropertyXmlArrayItemAttributeElementNamePropertyEqualsMap()
        {
            XmlArrayItemAttribute attr = typeof(TimetableFileModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Map", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicExportOptionsPropertyOfTypeExportOptionsModel()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("ExportOptions");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ExportOptionsModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_ExportOptionsPropertyIsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("ExportOptions").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicSignalboxHoursSetsPropertyOfTypeListOfSignalboxHoursSetModel()
        {
            PropertyInfo pInfo = typeof(TimetableFileModel).GetProperty("SignalboxHoursSets");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<SignalboxHoursSetModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_SignalboxHoursSetsPropertyIsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("SignalboxHoursSets").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_SignalboxHoursSetsPropertyIsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(TimetableFileModel).GetProperty("SignalboxHoursSets").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_SignalboxHoursSetsPropertyXmlArrayItemAttributeElementNamePropertyEqualsSignalboxHoursSet()
        {
            XmlArrayItemAttribute attr = typeof(TimetableFileModel).GetProperty("SignalboxHoursSets").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("SignalboxHoursSet", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_Constructor_CreatesObjectWithMapsPropertyThatIsNotNull()
        {
            TimetableFileModel testOutput = new TimetableFileModel();

            Assert.IsNotNull(testOutput.Maps);
        }

        [TestMethod]
        public void TimetableFileModelClass_Constructor_CreatesObjectWithNoteDefinitionsPropertyThatIsNotNull()
        {
            TimetableFileModel testOutput = new TimetableFileModel();

            Assert.IsNotNull(testOutput.NoteDefinitions);
        }

        [TestMethod]
        public void TimetableFileModelClass_Constructor_CreatesObjectWithTrainClassListPropertyThatIsNotNull()
        {
            TimetableFileModel testOutput = new TimetableFileModel();

            Assert.IsNotNull(testOutput.TrainClassList);
        }

        [TestMethod]
        public void TimetableFileModelClass_Constructor_CreatesObjectWithTrainListPropertyThatIsNotNull()
        {
            TimetableFileModel testOutput = new TimetableFileModel();

            Assert.IsNotNull(testOutput.TrainList);
        }

        [TestMethod]
        public void TimetableFileModelClass_Constructor_CreatesObjectWithSignalboxHoursSetsPropertyThatIsNotNull()
        {
            TimetableFileModel testOutput = new TimetableFileModel();

            Assert.IsNotNull(testOutput.SignalboxHoursSets);
        }
    }
}
