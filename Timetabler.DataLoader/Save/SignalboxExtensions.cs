using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Extension methods for serializing a <see cref="Signalbox"/> instance.
    /// </summary>
    public static class SignalboxExtensions
    {
        /// <summary>
        /// Convert a <see cref="Signalbox"/> instance into a <see cref="SignalboxModel"/> instance.
        /// </summary>
        /// <param name="box">The <see cref="Signalbox"/> to be converted.</param>
        /// <returns>A <see cref="SignalboxModel"/> converted from the parameter.</returns>
        public static SignalboxModel ToSignalboxModel(this Signalbox box)
        {
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
