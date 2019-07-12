using System;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Class for loading <see cref="DocumentOptions"/> data from serialised form into memory.
    /// </summary>
    public static class DocumentOptionsModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="DocumentOptionsModel"/> instance into a <see cref="DocumentOptions"/> instance.
        /// </summary>
        /// <param name="model">The data to be converted.</param>
        /// <returns>The<see cref="DocumentOptions"/> instance.</returns>
        public static DocumentOptions ToDocumentOptions(this DocumentOptionsModel model)
        {
            DocumentOptions options = new DocumentOptions
            {
                DisplayTrainLabelsOnGraphs = model.DisplayTrainLabelsOnGraphs ?? true
            };

            ClockType ct;
            if (Enum.TryParse(model.ClockTypeName, out ct))
            {
                options.ClockType = ct;
            }

            GraphEditStyle ges;
            if (Enum.TryParse(model.GraphEditStyle, out ges))
            {
                options.GraphEditStyle = ges;
            }

            return options;
        }
    }
}
