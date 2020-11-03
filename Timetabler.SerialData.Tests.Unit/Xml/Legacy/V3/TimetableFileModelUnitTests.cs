using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using Timetabler.SerialData.Xml;

namespace Timetabler.SerialData.Tests.Unit.Xml.Legacy.V3
{
    [TestClass]
    public class TimetableFileModelUnitTests
    {
#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void TimetableFileModelClass_IsPublic()
        {
            Assert.IsTrue(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_IsDecoratedWithXmlRootAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetCustomAttributes<XmlRootAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_XmlRootAttributeElementNameProperty_EqualsDocumentModel()
        {
            XmlRootAttribute attr = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual("DocumentModel", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_XmlRootAttributeNamespaceProperty_EqualsNamespacesV3()
        {
            XmlRootAttribute attr = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetCustomAttributes<XmlRootAttribute>(false).First();
            Assert.AreEqual(Namespaces.V3, attr.Namespace);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicParameterlessConstructor()
        {
            ConstructorInfo cInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetConstructor(Array.Empty<Type>());
            Assert.IsNotNull(cInfo);
            Assert.IsTrue(cInfo.IsPublic);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicVersionPropertyOfTypeInt()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Version");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(int), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_VersionProperty_IsDecoratedWithXmlAttributeAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_VersionProperty_XmlAttributeAttributeAttributeNamePropertyEqualsVersion()
        {
            XmlAttributeAttribute attr = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Version").GetCustomAttributes<XmlAttributeAttribute>(false).First();
            Assert.AreEqual("version", attr.AttributeName);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicOptionsPropertyOfTypeDocumentOptionsModel()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Options");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(DocumentOptionsModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_OptionsProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Options").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicTitlePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Title");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_TitleProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Title").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicSubtitlePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Subtitle");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_SubtitleProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Subtitle").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicDateDescriptionPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("DateDescription");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_DateDescriptionProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("DateDescription").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicNoteDefinitionsPropertyOfTypeListOfNoteModel()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("NoteDefinitions");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<NoteModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_NoteDefinitionsProperty_IsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_NoteDefinitionsProperty_IsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_NoteDefinitionsProperty_XmlArrayItemAttributeElementNamePropertyEqualsNote()
        {
            XmlArrayItemAttribute attr = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("NoteDefinitions").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Note", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicTrainClassListPropertyOfTypeListOfTrainClassModel()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("TrainClassList");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<TrainClassModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainClassListProperty_IsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("TrainClassList").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainClassListProperty_IsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("TrainClassList").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainClassListProperty_XmlArrayItemAttributeElementNamePropertyEqualsTrainClass()
        {
            XmlArrayItemAttribute attr = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("TrainClassList").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("TrainClass", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicTrainListPropertyOfTypeListOfTrainModel()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("TrainList");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<TrainModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainListProperty_IsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("TrainList").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainListProperty_IsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("TrainList").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_TrainListProperty_XmlArrayItemAttributeElementNamePropertyEqualsTrain()
        {
            XmlArrayItemAttribute attr = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("TrainList").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Train", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicWrittenByPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("WrittenBy");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_WrittenByProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("WrittenBy").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicCheckedByPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("CheckedBy");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_CheckedByProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("CheckedBy").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicTimetableVersionPropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("TimetableVersion");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_TimetableVersionProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("TimetableVersion").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicPublishedDatePropertyOfTypeString()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("PublishedDate");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(string), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_PublishedDateProperty_IsDecoratedFromXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("PublishedDate").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicMapsPropertyOfTypeListOfNetworkMapModels()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Maps");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.AreEqual(typeof(List<NetworkMapModel>), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_MapsProperty_IsDecoratedWithXmlArrayAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Maps").GetCustomAttributes<XmlArrayAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_MapsProperty_IsDecoratedWithXmlArrayItemAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First());
        }

        [TestMethod]
        public void TimetableFileModelClass_MapsProperty_XmlArrayItemAttributeElementNamePropertyEqualsMap()
        {
            XmlArrayItemAttribute attr = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("Maps").GetCustomAttributes<XmlArrayItemAttribute>(false).First();
            Assert.AreEqual("Map", attr.ElementName);
        }

        [TestMethod]
        public void TimetableFileModelClass_HasPublicExportOptionsPropertyOfTypeExportOptionsModel()
        {
            PropertyInfo pInfo = typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("ExportOptions");
            Assert.IsNotNull(pInfo);
            Assert.IsTrue(pInfo.GetMethod.IsPublic);
            Assert.IsTrue(pInfo.SetMethod.IsPublic);
            Assert.AreEqual(typeof(ExportOptionsModel), pInfo.PropertyType);
        }

        [TestMethod]
        public void TimetableFileModelClass_ExportOptionsProperty_IsDecoratedWithXmlElementAttribute()
        {
            Assert.IsNotNull(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel).GetProperty("ExportOptions").GetCustomAttributes<XmlElementAttribute>(false).First());
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
