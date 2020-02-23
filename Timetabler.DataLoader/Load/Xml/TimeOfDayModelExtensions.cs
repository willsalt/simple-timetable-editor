using Timetabler.CoreData;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Load.Xml
{
    /// <summary>
    /// Extension methods for loading a TimeOfDay from serialisable form.
    /// </summary>
    public static class TimeOfDayModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="TimeOfDayModel"/> instance to a <see cref="TimeOfDay"/> instance.
        /// </summary>
        /// <param name="model">The object to convert.</param>
        /// <returns>The <see cref="TimeOfDay"/> object.</returns>
        public static TimeOfDay ToTimeOfDay(this TimeOfDayModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new TimeOfDay(model.Hours24, model.Minutes, model.Seconds);
        }
    }
}
