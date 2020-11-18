using System;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for the <see cref="DocumentOptionsModel" /> class.
    /// </summary>
    public static class DocumentOptionsModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="DocumentOptionsModel" /> instance to a <see cref="DocumentOptions" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <returns>A <see cref="DocumentOptions" /> insstance whose properties match the parameter.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is null.</exception>
        public static DocumentOptions ToDocumentOptions(this DocumentOptionsModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            DocumentOptions options = new DocumentOptions
            {
                DisplayTrainLabelsOnGraphs = model.DisplayTrainLabelsOnGraphs ?? true,
                DisplaySpeedLinesOnGraphs = model.DisplaySpeedLinesOnGraphs ?? false,
                SpeedLineSpeed = model.SpeedLineSpeed ?? DocumentOptions.DefaultSpeedLineSpeed,
                SpeedLineSpacingMinutes = model.SpeedLineSpacingMinutes ?? DocumentOptions.DefaultSpeedLineSpacing,
            };

            if (model.SpeedLineAppearance != null)
            {
                options.SpeedLineAppearance = model.SpeedLineAppearance.ToGraphTrainProperties();
            }

            if (Enum.TryParse(model.ClockTypeName, out ClockType ct))
            {
                options.ClockType = ct;
            }

            if (Enum.TryParse(model.GraphEditStyle, out GraphEditStyle ges))
            {
                options.GraphEditStyle = ges;
            }

            return options;
        }
    }
}
