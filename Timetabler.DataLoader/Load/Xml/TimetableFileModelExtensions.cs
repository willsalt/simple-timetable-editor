using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Load.Xml
{
    /// <summary>
    /// Extension methods for loading a <see cref="TimetableDocument"/> instance from serialized form.
    /// </summary>
    public static class TimetableFileModelExtensions
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Convert a deserialized <see cref="TimetableFileModel"/> instance to a <see cref="TimetableDocument"/> instance.
        /// </summary>
        /// <param name="file">The deserialized data to convert.</param>
        /// <returns>The data.</returns>
        public static TimetableDocument ToTimetableDocument(this TimetableFileModel file)
        {
            if (file is null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            Dictionary<string, Signalbox> signalboxes = new Dictionary<string, Signalbox>();

            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_TimetableFileModelConversionVersion, file.Version);
            TimetableDocument document = new TimetableDocument
            {
                Version = file.Version,
                Options = file.Options != null ? file.Options.ToDocumentOptions() : new DocumentOptions(),
                ExportOptions = file.ExportOptions != null ? file.ExportOptions.ToDocumentExportOptions() : new DocumentExportOptions(),
                Title = file.Title ?? string.Empty,
                Subtitle = file.Subtitle ?? string.Empty,
                DateDescription = file.DateDescription ?? string.Empty,
                WrittenBy = file.WrittenBy ?? string.Empty,
                CheckedBy = file.CheckedBy ?? string.Empty,
                TimetableVersion = file.TimetableVersion ?? string.Empty,
                PublishedDate = file.PublishedDate ?? string.Empty,
            };

            if (file.Maps != null && file.Maps.Count > 0 && file.Maps[0] != null)
            {
                if (file.Maps[0].LocationList != null)
                {
                    Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_LocationCount, file.Maps[0].LocationList.Count);
                    foreach (LocationModel loc in file.Maps[0].LocationList)
                    {
                        document.LocationList.Add(loc.ToLocation());
                    }
                    Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_LocationsLoaded, document.LocationList.Count);
                }
                else
                {
                    Log.Trace("No locations to load.");
                }

                if (file.Maps[0].Signalboxes != null)
                {
                    Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_SignalboxCount, file.Maps[0].Signalboxes.Count);
                    foreach (SignalboxModel box in file.Maps[0].Signalboxes)
                    {
                        Signalbox b = box.ToSignalbox();
                        document.Signalboxes.Add(b);
                        if (!signalboxes.ContainsKey(b.Id))
                        {
                            signalboxes.Add(b.Id, b);
                        }
                    }
                    Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_SignalboxesLoaded, document.Signalboxes.Count);
                }
                else
                {
                    Log.Trace("No signalboxes to load");
                }
            }

            if (file.SignalboxHoursSets != null)
            {
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_SignalboxHoursSetCount, file.SignalboxHoursSets.Count);
                foreach (SignalboxHoursSetModel set in file.SignalboxHoursSets)
                {
                    document.SignalboxHoursSets.Add(set.ToSignalboxHoursSet(signalboxes, document.SignalboxHoursSets));
                }
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_SignalboxHoursSetsLoaded, document.SignalboxHoursSets.Count);
            }
            else
            {
                Log.Trace("No signalbox hours sets to load.");
            }

            if (file.NoteDefinitions != null)
            {
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_NoteDefinitionCount, file.NoteDefinitions.Count);
                foreach (NoteModel note in file.NoteDefinitions)
                {
                    document.NoteDefinitions.Add(note.ToNote());
                }
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_NoteDefinitionsLoaded, document.NoteDefinitions.Count);
            }
            else
            {
                Log.Trace("No note definitions to load.");
            }

            if (file.TrainClassList != null)
            {
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_TrainClassCount, file.TrainClassList.Count);
                foreach (TrainClassModel tc in file.TrainClassList)
                {
                    document.TrainClassList.Add(tc.ToTrainClass());
                }
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_TrainClassesLoaded, document.TrainClassList.Count);
            }
            else
            {
                Log.Trace("No train classes to load.");
            }

            Dictionary<string, Location> locationMap = document.LocationList.ToDictionary(o => o.Id);
            Dictionary<string, TrainClass> classMap = document.TrainClassList.ToDictionary(c => c.Id);
            Dictionary<string, Note> noteMap = document.NoteDefinitions.ToDictionary(n => n.Id);
            if (file.TrainList != null)
            {
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_TrainCount, file.TrainList.Count);
                foreach (TrainModel trn in file.TrainList)
                {
                    document.TrainList.Add(trn.ToTrain(locationMap, classMap, noteMap, document.Options));
                }
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_TrainsLoaded, document.TrainList.Count);
            }
            else
            {
                Log.Trace("No trains to load.");
            }

            return document;
        }
    }
}
