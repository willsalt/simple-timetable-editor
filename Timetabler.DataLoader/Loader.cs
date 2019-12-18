using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using Timetabler.CoreData.Exceptions;
using Timetabler.Data;
using Timetabler.Data.Collections;
using Timetabler.DataLoader.Load.Xml;
using Timetabler.DataLoader.Load.Xml.Legacy.V3;
using Timetabler.SerialData;
using Timetabler.SerialData.Xml;

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
        /// <param name="stream">The stream to load the class data from.</param>
        /// <returns>The list of locations in the template.</returns>
        public static TimetableDocument LoadTimetableDocument(Stream stream)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    if (reader == null)
                    {
                        throw new TimetableLoaderException(Resources.Error_CouldNotCreateXmlReader);
                    }
                    reader.MoveToContent();
                    if (reader.Name != "DocumentModel")
                    {
                        throw new TimetableLoaderException(Resources.Error_XmlDoesNotContainDocumentModel);
                    }
                    if (!int.TryParse(reader.GetAttribute("version"), out int version))
                    {
                        throw new TimetableLoaderException(Resources.Error_XmlDoesNotSpecifyVersion);
                    }
                    if (version > Versions.CurrentTimetableDocument)
                    {
                        throw new TimetableLoaderException(string.Format(CultureInfo.CurrentCulture, Resources.Error_XmlUnsupportedVersion, version));
                    }


                    if (version < 4)
                    {
                        return LoadVersion3(reader);
                    }
                    XmlSerializer deserializer = new XmlSerializer(typeof(TimetableFileModel));
                    return ((TimetableFileModel)deserializer.Deserialize(reader)).ToTimetableDocument();
                }
            }
            catch (TimetableLoaderException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new TimetableLoaderException(Resources.Error_GenericLoaderError, ex);
            }
        }

        private static TimetableDocument LoadVersion3(XmlReader reader)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(SerialData.Xml.Legacy.V3.TimetableFileModel));
            return ((SerialData.Xml.Legacy.V3.TimetableFileModel)deserializer.Deserialize(reader)).ToTimetableDocument();
        }

        /// <summary>
        /// Load a timetable location template from a stream.
        /// </summary>
        /// <param name="str">The stream containing the template to be loaded.</param>
        /// <returns>The list of locations in the template.</returns>
        public static LocationCollection LoadLocationTemplate(Stream str)
        {
            try
            {
                using (XmlReader reader = XmlReader.Create(str))
                {
                    if (reader == null)
                    {
                        throw new TimetableLoaderException(Resources.Error_CouldNotCreateXmlReader);
                    }
                    reader.MoveToContent();
                    if (reader.Name != "LocationTemplateModel")
                    {
                        throw new TimetableLoaderException(Resources.Error_XmlDoesNotContainLocationTemplateModel);
                    }
                    if (!int.TryParse(reader.GetAttribute("version"), out int version))
                    {
                        throw new TimetableLoaderException(Resources.Error_XmlLocationTemplateDoesNotSpecifyVersion);
                    }
                    if (version > Versions.CurrentLocationTemplate)
                    {
                        throw new TimetableLoaderException(string.Format(CultureInfo.CurrentCulture, Resources.Error_XmlLocationTemplateUnsupportedVersion, version));
                    }

                    // Version-detection code goes here!
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
            }
            catch (TimetableLoaderException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new TimetableLoaderException(Resources.Error_GenericLoaderError, ex);
            }
        }

        private static LocationCollection LoadLocationsVersion0(XmlReader reader)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(SerialData.Xml.Legacy.V1.LocationTemplateModel));
            SerialData.Xml.Legacy.V1.LocationTemplateModel templateModel = (SerialData.Xml.Legacy.V1.LocationTemplateModel)deserializer.Deserialize(reader);
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
            try
            {
                using (XmlReader reader = XmlReader.Create(str))
                {
                    if (reader == null)
                    {
                        throw new TimetableLoaderException(Resources.Error_CouldNotCreateXmlReader);
                    }
                    reader.MoveToContent();
                    if (reader.Name != "TimetableDocumentTemplate")
                    {
                        throw new TimetableLoaderException(Resources.Error_XmlDoesNotContainTimetableDocumentTemplate);
                    }
                    if (!int.TryParse(reader.GetAttribute("version"), out int version))
                    {
                        throw new TimetableLoaderException(Resources.Error_XmlTimetableDocumentTemplateDoesNotSpecifyVersion);
                    }
                    if (version > Versions.CurrentDocumentTemplate)
                    {
                        throw new TimetableLoaderException(string.Format(CultureInfo.CurrentCulture, Resources.Error_XmlTimetableDocumentTemplateUnsupportedVersion, version));
                    }

                    // Version-detection code to go here.
                    XmlSerializer deserializer = new XmlSerializer(typeof(TimetableDocumentTemplateModel));
                    TimetableDocumentTemplateModel templateModel = (TimetableDocumentTemplateModel)deserializer.Deserialize(reader);
                    return templateModel.ToDocumentTemplate();
                }
            }
            catch (TimetableLoaderException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new TimetableLoaderException(Resources.Error_GenericLoaderError, ex);
            }
        }
    }
}
