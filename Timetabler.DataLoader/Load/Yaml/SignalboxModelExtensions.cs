using System;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    /// <summary>
    /// Extension methods for the <see cref="SignalboxModel" /> class.
    /// </summary>
    public static class SignalboxModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="SignalboxModel" /> instance to a <see cref="Signalbox" /> instance.
        /// </summary>
        /// <param name="model">The object to convert.</param>
        /// <returns>A <see cref="Signalbox" /> instance containing the same data as the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static Signalbox ToSignalbox(this SignalboxModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            return new Signalbox
            {
                Id = model.Id,
                Code = model.Code,
                EditorDisplayName = model.EditorDisplayName,
                ExportDisplayName = model.TimetableDisplayName,
            };
        }
    }
}
