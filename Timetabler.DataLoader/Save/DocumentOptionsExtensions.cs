using System;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Extension methods for converting a <see cref="DocumentOptions"/> instance into serializable form.
    /// </summary>
    public static class DocumentOptionsExtensions
    {
        /// <summary>
        /// Convert a <see cref="DocumentOptions"/> instance into a <see cref="DocumentOptionsModel"/> instance.
        /// </summary>
        /// <param name="options">The instance to be converted.</param>
        /// <returns>A <see cref="DocumentOptionsModel"/> instance representing the options parameter.</returns>
        public static DocumentOptionsModel ToDocumentOptionsModel(this DocumentOptions options)
        {
            return new DocumentOptionsModel
            {
                ClockTypeName = Enum.GetName(typeof(ClockType), options.ClockType),
                DisplayTrainLabelsOnGraphs = options.DisplayTrainLabelsOnGraphs,
                GraphEditStyle = Enum.GetName(typeof(GraphEditStyle), options.GraphEditStyle),
            };
        }
    }
}
