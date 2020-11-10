using System;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="Signalbox" /> class.
    /// </summary>
    public static class SignalboxExtensions
    {
        /// <summary>
        /// Convert a <see cref="Signalbox" /> instance to a <see cref="SignalboxModel" /> instance.
        /// </summary>
        /// <param name="box">The object to be converted.</param>
        /// <returns>A <see cref="SignalboxModel" /> instance containing the same data as the parameter in serialisable form.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static SignalboxModel ToYamlSignalboxModel(this Signalbox box)
        {
            if (box is null)
            {
                throw new NullReferenceException();
            }

            return new SignalboxModel
            {
                Id = box.Id,
                Code = box.Code,
                EditorDisplayName = box.EditorDisplayName,
                TimetableDisplayName = box.ExportDisplayName,
            };
        }
    }
}
