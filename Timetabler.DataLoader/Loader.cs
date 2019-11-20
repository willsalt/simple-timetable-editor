using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Timetabler.CoreData.Exceptions;
using Timetabler.Data;
using Timetabler.Data.Collections;
using Timetabler.DataLoader.Load;
using Timetabler.DataLoader.Load.Legacy.V3;
using Timetabler.SerialData;

namespace Timetabler.DataLoader
{
    /// <summary>
    /// The main data loading API
    /// </summary>
    public static class Loader
    {
        /// <summary>
        /// The latest version of the timetable document format supported by the loader.
        /// </summary>
        public static int LatestTimetableDocumentVersion => Versions.CurrentTimetableDocument;

        /// <summary>
        /// Load a TimetableDocument class from a stream.
        /// </summary>
        /// <param name="str">The stream to load the class data from.</param>
        /// <returns>The list of locations in the template.</returns>
        public static TimetableDocument LoadTimetableDocument(Stream str)
        {
            XmlReader reader;
            try
            {
                reader = XmlReader.Create(str);
                reader.MoveToContent();
            }
            catch (Exception ex)
            {
                throw new TimetableLoaderException("Unexpected exception occurred in loader.", ex);
            }

            if (reader == null)
            {
                throw new TimetableLoaderException("Could not create XML reader.");
            }
            if (reader.Name != "DocumentModel")
            {
                throw new TimetableLoaderException("Stream does not contain <DocumentModel>");
            }
            int version = 0;
            if (!int.TryParse(reader.GetAttribute("version"), out version))
            {
                throw new TimetableLoaderException("<DocumentModel> element does not specify version number.");
            }
            if (version > Versions.CurrentTimetableDocument)
            {
                throw new TimetableLoaderException(string.Format("<DocumentModel> version {0} is too high to be supported.", version));
            }

            try
            {
                if (version < 4)
                {
                    return LoadVersion3(reader);
                }
                XmlSerializer deserializer = new XmlSerializer(typeof(TimetableFileModel));
                return ((TimetableFileModel)deserializer.Deserialize(reader)).ToTimetableDocument();
            }
            catch (Exception ex)
            {
                throw new TimetableLoaderException("Unexpected exception occurred in loader.", ex);
            }
        }

        private static TimetableDocument LoadVersion3(XmlReader reader)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(SerialData.Legacy.V3.TimetableFileModel));
            return ((SerialData.Legacy.V3.TimetableFileModel)deserializer.Deserialize(reader)).ToTimetableDocument();
        }

        /// <summary>
        /// Load a timetable location template from a stream.
        /// </summary>
        /// <param name="str">The stream containing the template to be loaded.</param>
        /// <returns>The list of locations in the template.</returns>
        public static LocationCollection LoadLocationTemplate(Stream str)
        {
            XmlReader reader = null;
            try
            {
                reader = XmlReader.Create(str);
                reader.MoveToContent();
            }
            catch (Exception ex)
            {
                throw new TimetableLoaderException("Unexpected exception occurred in loader.", ex);
            }

            if (reader == null)
            {
                throw new TimetableLoaderException("Could not create XML reader.");
            }
            if (reader.Name != "LocationTemplateModel")
            {
                throw new TimetableLoaderException("Stream does not contain <LocationTemplateModel>");
            }
            int version = 0;
            if (!int.TryParse(reader.GetAttribute("version"), out version))
            {
                throw new TimetableLoaderException("<LocationTemplateModel> element does not specify version number.");
            }
            if (version > Versions.CurrentLocationTemplate)
            {
                throw new TimetableLoaderException(string.Format("<LocationTemplateModel> version {0} is too high to be supported.", version));
            }

            // Version-detection code goes here!

            try
            {
                if (version < 3)
                {
                    return LoadLocationsVersion0(reader);
                }
                XmlSerializer deserialiser = new XmlSerializer(typeof(LocationTemplateModel));
                LocationTemplateModel templateModel = (LocationTemplateModel)deserialiser.Deserialize(reader);
                if (templateModel == null || templateModel.Maps == null || templateModel.Maps.Count == 0 || templateModel.Maps[0].LocationList == null)
                {
                    return null;
                }
                return new LocationCollection(templateModel.Maps[0].LocationList.Select(l => l.ToLocation()));
            }
            catch (Exception ex)
            {
                throw new TimetableLoaderException("Unexpected exception occurred in loader.", ex);
            }
        }

        private static LocationCollection LoadLocationsVersion0(XmlReader reader)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(SerialData.Legacy.V1.LocationTemplateModel));
            SerialData.Legacy.V1.LocationTemplateModel templateModel = (SerialData.Legacy.V1.LocationTemplateModel)deserializer.Deserialize(reader);
            if (templateModel == null || templateModel.LocationList == null)
            {
                return null;
            }
            return new LocationCollection(templateModel.LocationList.Select(l => l.ToLocation()));
        }

        /// <summary>
        /// Load a <see cref="DocumentTemplate"/> object from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="str">The <see cref="Stream"/> to load data from.</param>
        /// <returns>A <see cref="DocumentTemplate"/> object.</returns>
        public static DocumentTemplate LoadDocumentTemplate(Stream str)
        {
            XmlReader reader = null;
            try
            {
                reader = XmlReader.Create(str);
                reader.MoveToContent();
            }
            catch (Exception ex)
            {
                throw new TimetableLoaderException("Unexpected exception occurred in loader.", ex);
            }

            if (reader == null)
            {
                throw new TimetableLoaderException("Could not create XML reader.");
            }
            if (reader.Name != "TimetableDocumentTemplate")
            {
                throw new TimetableLoaderException("Stream does not contain <TimetableDocumentTemplate> element.");
            }
            if (!int.TryParse(reader.GetAttribute("version"), out int version))
            {
                throw new TimetableLoaderException("<TimetableDocumentTemplate> element does not specify version number.");
            }
            if (version > Versions.CurrentDocumentTemplate)
            {
                throw new TimetableLoaderException(string.Format("<TimetableDocumentTemplate> version {0} is too high to be supported.", version));
            }

            // Version-detection code to go here.

            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(TimetableDocumentTemplateModel));
                TimetableDocumentTemplateModel templateModel = (TimetableDocumentTemplateModel)deserializer.Deserialize(reader);
                return templateModel.ToDocumentTemplate();
            }
            catch (Exception ex)
            {
                throw new TimetableLoaderException("Unexpected exception occurred in loader.", ex);
            }
        }
    }
}
