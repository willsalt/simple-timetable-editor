using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.Data;
using Timetabler.Data.Collections;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Load.Xml
{
    /// <summary>
    /// Class for loading <see cref="DocumentTemplate"/> classes from serialized form into memory.
    /// </summary>
    public static class TimetableDocumentTemplateModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="TimetableDocumentTemplateModel"/> object into a <see cref="DocumentTemplate"/> object.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <returns>A converted <see cref="DocumentTemplate"/> object.</returns>
        public static DocumentTemplate ToDocumentTemplate(this TimetableDocumentTemplateModel model)
        {
            IEnumerable<Location> locationSource;
            if (model.Maps != null && model.Maps.Count > 0 && model.Maps[0] != null)
            {
                locationSource = model.Maps[0].LocationList.Select(l => l.ToLocation());
            }
            else
            {
                locationSource = Array.Empty<Location>();
            }

            DocumentTemplate template = new DocumentTemplate(
                locationSource, 
                model.NoteDefinitions.Select(n => n.ToNote()), 
                model.TrainClasses.Select(c => c.ToTrainClass()), 
                model.Signalboxes.Select(s => s.ToSignalbox()))
            {
                DocumentOptions = model.DefaultOptions.ToDocumentOptions(),
                ExportOptions = model.DefaultExportOptions.ToDocumentExportOptions(),
            };

            return template;
        }
    }
}
