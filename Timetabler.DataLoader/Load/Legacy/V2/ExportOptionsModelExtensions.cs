using Timetabler.Data;
using Timetabler.XmlData.Legacy.V2;

namespace Timetabler.DataLoader.Load.Legacy.V2
{
    /// <summary>
    /// Extensions methods for converting <see cref="ExportOptionsModel"/> instances into in-memory form.
    /// </summary>
    public static class ExportOptionsModelExtensions
    {
        /// <summary>
        /// Convert an <see cref="ExportOptionsModel"/> instance into a <see cref="DocumentExportOptions"/> instance.
        /// </summary>
        /// <param name="exportOptionsModel">The object to convert.</param>
        /// <returns>The converted object.</returns>
        public static DocumentExportOptions ToDocumentExportOptions(this ExportOptionsModel exportOptionsModel)
        {
            return new DocumentExportOptions
            {
                DisplayLocoDiagramRow = exportOptionsModel != null ? exportOptionsModel.DisplayLocoDiagramRow : false,
            };
        }
    }
}
