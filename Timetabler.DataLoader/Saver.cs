using SharpYaml.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Timetabler.CoreData.Extensions;
using Timetabler.Data;
using Timetabler.DataLoader.Save;
using Timetabler.SerialData;

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
            Serializer serializer = GetSerializer();
            using (StreamWriter writer = new StreamWriter(destination))
            {
                writer.WriteLine("%WTT");
                serializer.Serialize(writer, document.ToTimetableFileModel());
            } 
        }

        /// <summary>
        /// Save a location template to a stream.
        /// </summary>
        /// <param name="locations">The list of locations to include in the template.</param>
        /// <param name="destination">The stream to save the location template to.</param>
        public static void Save(IEnumerable<Location> locations, Stream destination)
        {
            LocationTemplateModel locationTemplateModel = new LocationTemplateModel();
            locationTemplateModel.Maps.Add(BuildNetworkMapModel(locations));
            Serializer serialiser = GetSerializer();
            using (StreamWriter writer = new StreamWriter(destination))
            {
                writer.WriteLine("%WTL");
                serialiser.Serialize(writer, locationTemplateModel);
            }
        }

        private static NetworkMapModel BuildNetworkMapModel(IEnumerable<Location> locations)
        {
            NetworkMapModel model = new NetworkMapModel();
            model.LocationList.AddRange(locations.Select(c => c.ToLocationModel()));
            return model;
        }

        /// <summary>
        /// Save a document template to a stream.
        /// </summary>
        /// <param name="template">The <see cref="DocumentTemplate"/> to be saved.</param>
        /// <param name="destination">The stream to save the location template to.</param>
        public static void Save(DocumentTemplate template, Stream destination)
        {
            Serializer serializer = GetSerializer();
            using (StreamWriter writer = new StreamWriter(destination))
            {
                writer.WriteLine("%WTM");
                serializer.Serialize(writer, template.ToTimetableDocumentTemplateModel());
            }
        }

        private static Serializer GetSerializer()
        {
            SerializerSettings settings = new SerializerSettings { EmitAlias = false, EmitTags = false };
            return new Serializer(settings);
        }
    }
}
