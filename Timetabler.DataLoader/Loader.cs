using SharpYaml.Serialization;
using System;
using System.IO;
using System.Linq;
using Timetabler.CoreData.Exceptions;
using Timetabler.Data;
using Timetabler.Data.Collections;
using Timetabler.DataLoader.Load;
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
        /// <param name="stream">The stream to load the class data from.</param>
        /// <param name="displayWarning">Method to use to display warning messages to the user if necessary.</param>
        /// <returns>The list of locations in the template.</returns>
        public static TimetableDocument LoadTimetableDocument(Stream stream, Action<LoaderWarningMessage> displayWarning)
        {
            return LoadByFileType(stream, LoadYamlTimetableDocument, displayWarning);
        }

        private static T LoadByFileType<T>(Stream stream, Func<string, T> loader, Action<LoaderWarningMessage> displayWarning)
        {
            if (stream is null)
            {
                throw new NullReferenceException();
            }
            if (displayWarning is null)
            {
                throw new ArgumentNullException(nameof(displayWarning));
            }

            using (StreamReader reader = new StreamReader(stream))
            {
                try
                {
                    string startLine = reader.ReadLine();
                    if (startLine.StartsWith("%W", StringComparison.InvariantCulture))
                    {
                        return loader(reader.ReadToEnd());
                    }
                    displayWarning(LoaderWarningMessage.XmlFile);
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

            throw new TimetableLoaderException(Resources.Error_XmlLoaderError);
        }

        internal static TimetableDocument LoadYamlTimetableDocument(string content)
        {
            Serializer deserialiser = new Serializer();
            return deserialiser.Deserialize<TimetableFileModel>(content).ToTimetableDocument();
        }

        /// <summary>
        /// Load a timetable location template from a stream.
        /// </summary>
        /// <param name="str">The stream containing the template to be loaded.</param>
        /// <param name="displayWarning">Method to use to display warning messages to the user if necessary.</param>
        /// <returns>The list of locations in the template.</returns>
        public static LocationCollection LoadLocationTemplate(Stream str, Action<LoaderWarningMessage> displayWarning)
        {
            return LoadByFileType(str, LoadYamlLocationTemplate, displayWarning);
        }

        internal static LocationCollection LoadYamlLocationTemplate(string content)
        {
            Serializer deserialiser = new Serializer();
            LocationTemplateModel templateModel = deserialiser.Deserialize<LocationTemplateModel>(content);
            if (templateModel == null || templateModel.Maps == null || templateModel.Maps.Count == 0 || templateModel.Maps[0].LocationList == null)
            {
                return null;
            }
            UniqueItemModel.PopulateMissingIds(templateModel.Maps[0].LocationList);
            return new LocationCollection(templateModel.Maps[0].LocationList.Select(l => l.ToLocation()));
        }

        /// <summary>
        /// Load a <see cref="DocumentTemplate"/> object from a <see cref="Stream"/>.
        /// </summary>
        /// <param name="str">The <see cref="Stream"/> to load data from.</param>
        /// <param name="displayWarning">A method to call to display warning messages to the user if necessary.</param>
        /// <returns>A <see cref="DocumentTemplate"/> object.</returns>
        public static DocumentTemplate LoadDocumentTemplate(Stream str, Action<LoaderWarningMessage> displayWarning)
        {
            return LoadByFileType(str, LoadYamlDocumentTemplate, displayWarning);
        }

        internal static DocumentTemplate LoadYamlDocumentTemplate(string content)
        {
            Serializer deserialiser = new Serializer();
            TimetableDocumentTemplateModel templateModel = deserialiser.Deserialize<TimetableDocumentTemplateModel>(content);
            return templateModel.ToDocumentTemplate();
        }
    }
}
