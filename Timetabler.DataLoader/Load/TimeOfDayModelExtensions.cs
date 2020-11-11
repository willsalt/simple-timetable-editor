using System;
using System.Globalization;
using Timetabler.CoreData;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extensions methods for the <see cref="TimeOfDayModel" /> class.
    /// </summary>
    public static class TimeOfDayModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="TimeOfDayModel" /> instance to a <see cref="TimeOfDay" /> instance.
        /// </summary>
        /// <param name="model">The instance to be converted.</param>
        /// <returns>A <see cref="TimeOfDay" /> object containing equivalent properties.</returns>
        /// <exception cref="NullReferenceException">Thrown if the <c>this</c> parameter is <c>null</c>.</exception>
        public static TimeOfDay ToTimeOfDay(this TimeOfDayModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            if (string.IsNullOrWhiteSpace(model.Time))
            {
                throw new FormatException(Resources.Error_EmptyTime);
            }
            string[] parts = model.Time.Split(':');
            int hours = 0;
            int minutes = 0;
            int seconds = 0;
            try
            {
                if (parts.Length > 0)
                {
                    hours = int.Parse(parts[0], CultureInfo.InvariantCulture);
                }
                if (parts.Length > 1)
                {
                    minutes = int.Parse(parts[1], CultureInfo.InvariantCulture);
                }
                if (parts.Length > 2)
                {
                    seconds = int.Parse(parts[2], CultureInfo.InvariantCulture);
                }
            }
            catch (FormatException ex)
            {
                throw new FormatException(Resources.Error_TimeUnparseable, ex);
            }
            catch (OverflowException ex)
            {
                throw new FormatException(Resources.Error_TimeUnparseable, ex);
            }

            return new TimeOfDay(hours, minutes, seconds);
        }
    }
}
