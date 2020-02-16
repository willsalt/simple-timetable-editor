using System;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Save.Yaml
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="DocumentOptions" /> class.
    /// </summary>
    public static class DocumentOptionsExtensions
    {
        /// <summary>
        /// Convert a <see cref="DocumentOptions" /> instance to a <see cref="DocumentOptionsModel" /> instance.
        /// </summary>
        /// <param name="options">The object to convert.</param>
        /// <returns>A <see cref="DocumentOptionsModel" /> instance containing the same data as the parameter in serialisable form.</returns>
        /// <exception cref="NullReferenceException">Thrown if the <c>this</c> parameter is <c>null</c>.</exception>
        public static DocumentOptionsModel ToYamlDocumentOptionsModel(this DocumentOptions options)
        {
            if (options is null)
            {
                throw new NullReferenceException();
            }

            return new DocumentOptionsModel
            {
                ClockTypeName = Enum.GetName(typeof(ClockType), options.ClockType),
                DisplayTrainLabelsOnGraphs = options.DisplayTrainLabelsOnGraphs,
                GraphEditStyle = Enum.GetName(typeof(GraphEditStyle), options.GraphEditStyle),
            };
        }
    }
}
