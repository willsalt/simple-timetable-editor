using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Timetabler.Data;
using Timetabler.DataLoader.Save.Xml;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader
{
    /// <summary>
    /// The main data saving API
    /// </summary>
    public static class Saver
    {
        /// <summary>
        /// Save a timetable document to a stream.
        /// </summary>
        /// <param name="document">The document to be saved.</param>
        /// <param name="destination">The stream to save the document to.</param>
        public static void Save(TimetableDocument document, Stream destination)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TimetableFileModel));
            serializer.Serialize(destination, document.ToTimetableFileModel());
        }

        /// <summary>
        /// Save a location template to a stream.
        /// </summary>
        /// <param name="locations">The list of locations to include in the template.</param>
        /// <param name="destination">The stream to save the location template to.</param>
        public static void Save(IEnumerable<Location> locations, Stream destination)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(LocationTemplateModel));
            serializer.Serialize(destination, new LocationTemplateModel
            {
                Maps = new List<NetworkMapModel> { new NetworkMapModel { LocationList = locations.Select(l => l.ToLocationModel()).ToList() } }
            });
        }

        /// <summary>
        /// Save a document template to a stream.
        /// </summary>
        /// <param name="template">The <see cref="DocumentTemplate"/> to be saved.</param>
        /// <param name="destination">The stream to save the location template to.</param>
        public static void Save(DocumentTemplate template, Stream destination)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(TimetableDocumentTemplateModel));
            serializer.Serialize(destination, template.ToTimetableDocumentTemplateModel());
        }
    }
}
