using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    /// <summary>
    /// Extension methods for <see cref="TimetableDocumentTemplateModel" /> class.
    /// </summary>
    public static class TimetableDocumentTemplateModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="TimetableDocumentTemplateModel" /> instance to a <see cref="DocumentTemplate" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <returns>A <see cref="DocumentTemplate" /> instance containing the same data as the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static DocumentTemplate ToDocumentTemplate(this TimetableDocumentTemplateModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            IEnumerable<Location> locationSource;
            if (model.Maps != null && model.Maps.Count > 0 && model.Maps[0] != null)
            {
                UniqueItemModel.PopulateMissingIds(model.Maps[0].LocationList);
                locationSource = model.Maps[0].LocationList.Select(l => l.ToLocation());
            }
            else
            {
                locationSource = Array.Empty<Location>();
            }

            UniqueItemModel.PopulateMissingIds(model.NoteDefinitions);
            UniqueItemModel.PopulateMissingIds(model.Maps[0].Signalboxes);
            UniqueItemModel.PopulateMissingIds(model.TrainClasses);
            DocumentTemplate template = new DocumentTemplate(
                locationSource,
                model.NoteDefinitions.Select(n => n.ToNote()),
                model.TrainClasses.Select(c => c.ToTrainClass()),
                model.Maps[0].Signalboxes.Select(s => s.ToSignalbox()))
            {
                DocumentOptions = model.DefaultOptions.ToDocumentOptions(),
                ExportOptions = model.DefaultExportOptions.ToDocumentExportOptions(),
            };

            return template;
        }
    }
}
