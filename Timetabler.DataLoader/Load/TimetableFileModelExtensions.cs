using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for <see cref="TimetableFileModel" /> class.
    /// </summary>
    public static class TimetableFileModelExtensions
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Convert a <see cref="TimetableFileModel" /> instance to a <see cref="TimetableDocument" /> instance.
        /// </summary>
        /// <param name="model">The object to convert.</param>
        /// <returns>A <see cref="TimetableDocument" /> instance containing the same data as the parameter.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is <c>null</c>.</exception>
        public static TimetableDocument ToTimetableDocument(this TimetableFileModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Dictionary<string, Signalbox> signalboxes = new Dictionary<string, Signalbox>();

            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_TimetableFileModelConversionVersion, model.Version);
            TimetableDocument document = new TimetableDocument
            {
                Version = model.Version,
                Options = model.FileOptions != null ? model.FileOptions.ToDocumentOptions() : new DocumentOptions(),
                ExportOptions = model.ExportOptions != null ? model.ExportOptions.ToDocumentExportOptions() : new DocumentExportOptions(),
                Title = model.Title ?? string.Empty,
                Subtitle = model.Subtitle ?? string.Empty,
                DateDescription = model.DateDescription ?? string.Empty,
                WrittenBy = model.WrittenBy ?? string.Empty,
                CheckedBy = model.CheckedBy ?? string.Empty,
                TimetableVersion = model.TimetableVersion ?? string.Empty,
                PublishedDate = model.PublishedDate ?? string.Empty,
            };

            if (model.Maps != null && model.Maps.Count > 0 && model.Maps[0] != null)
            {
                if (model.Maps[0].LocationList != null)
                {
                    Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_LocationCount, model.Maps[0].LocationList.Count);
                    LocationModel.PopulateMissingIds(model.Maps[0].LocationList);
                    foreach (LocationModel loc in model.Maps[0].LocationList)
                    {
                        document.LocationList.Add(loc.ToLocation());
                    }
                    Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_LocationsLoaded, document.LocationList.Count);
                }
                else
                {
                    Log.Trace("No locations to load.");
                }

                if (model.Maps[0].Signalboxes != null)
                {
                    Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_SignalboxCount, model.Maps[0].Signalboxes.Count);
                    UniqueItemModel.PopulateMissingIds(model.Maps[0].Signalboxes);
                    foreach (SignalboxModel box in model.Maps[0].Signalboxes)
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

            if (model.SignalboxHoursSets != null)
            {
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_SignalboxHoursSetCount, model.SignalboxHoursSets.Count);
                foreach (SignalboxHoursSetModel set in model.SignalboxHoursSets)
                {
                    document.SignalboxHoursSets.Add(set.ToSignalboxHoursSet(signalboxes, document.SignalboxHoursSets));
                }
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_SignalboxHoursSetsLoaded, document.SignalboxHoursSets.Count);
            }
            else
            {
                Log.Trace("No signalbox hours sets to load.");
            }

            if (model.NoteDefinitions != null)
            {
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_NoteDefinitionCount, model.NoteDefinitions.Count);
                UniqueItemModel.PopulateMissingIds(model.NoteDefinitions);
                foreach (NoteModel note in model.NoteDefinitions)
                {
                    document.NoteDefinitions.Add(note.ToNote());
                }
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_NoteDefinitionsLoaded, document.NoteDefinitions.Count);
            }
            else
            {
                Log.Trace("No note definitions to load.");
            }

            if (model.TrainClassList != null)
            {
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_TrainClassCount, model.TrainClassList.Count);
                UniqueItemModel.PopulateMissingIds(model.TrainClassList);
                foreach (TrainClassModel tc in model.TrainClassList)
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
            if (model.TrainList != null)
            {
                Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_TrainCount, model.TrainList.Count);
                UniqueItemModel.PopulateMissingIds(model.TrainList);
                foreach (TrainModel trn in model.TrainList)
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
