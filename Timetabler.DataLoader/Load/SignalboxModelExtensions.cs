using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for loading a <see cref="SignalboxModel"/> instance into memory.
    /// </summary>
    public static class SignalboxModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="SignalboxModel"/> instance into a <see cref="Signalbox"/> instance.
        /// </summary>
        /// <param name="model">The model instance to be converted.</param>
        /// <returns>A <see cref="Signalbox"/> instance converted from the model.</returns>
        public static Signalbox ToSignalbox(this SignalboxModel model)
        {
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
