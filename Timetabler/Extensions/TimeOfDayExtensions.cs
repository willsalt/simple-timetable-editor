using System;
using System.Globalization;
using System.Windows.Forms;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Helpers;

namespace Timetabler.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="TimeOfDay" /> type.
    /// </summary>
    public static class TimeOfDayExtensions
    {
        /// <summary>
        /// Set the values of a set of <see cref="Control" /> objects based on the value of a <see cref="TimeOfDay" /> instance.
        /// </summary>
        /// <param name="time">The <see cref="TimeOfDay" /> to use to set the objects' values.</param>
        /// <param name="tbHour">The hours <see cref="TextBox" />.</param>
        /// <param name="tbMinute">The minutes <see cref="TextBox" />.</param>
        /// <param name="cbHalfOfDay">The half-of-day <see cref="ComboBox" />.  Not used unless the inputMode parameter is set to the 12-hour clock.</param>
        /// <param name="inputMode">The <see cref="ClockType" /> to determine whether to format the values using the 12-hour or 24-hour clock.</param>
        public static void SetTime(this TimeOfDay time, TextBox tbHour, TextBox tbMinute, ComboBox cbHalfOfDay, ClockType inputMode)
        {
            if (time is null)
            {
                throw new ArgumentNullException(nameof(time));
            }
            if (tbMinute is null)
            {
                throw new ArgumentNullException(nameof(tbMinute));
            }
            if (tbHour is null)
            {
                throw new ArgumentNullException(nameof(tbHour));
            }
            if (cbHalfOfDay is null)
            {
                throw new ArgumentNullException(nameof(cbHalfOfDay));
            }

            tbMinute.Text = time.Minutes.ToString("d2", CultureInfo.CurrentCulture);
            switch (inputMode)
            {
                case ClockType.TwelveHourClock:
                    tbHour.Text = time.Hours12.ToString(CultureInfo.CurrentCulture);
                    SetTimeHalfOfDay(cbHalfOfDay, time);
                    break;
                case ClockType.TwentyFourHourClock:
                    tbHour.Text = time.Hours24.ToString(CultureInfo.CurrentCulture);
                    break;
            }
        }

        private static void SetTimeHalfOfDay(ComboBox cbHalfOfDay, TimeOfDay time)
        {
            HalfOfDay expectedValue = time.Hours24 < 12 ? HalfOfDay.AM : HalfOfDay.PM;
            foreach (object obj in cbHalfOfDay.Items)
            {
                if (obj is HumanReadableEnum<HalfOfDay> hodItem && hodItem.Value == expectedValue)
                {
                    cbHalfOfDay.SelectedItem = hodItem;
                    break;
                }
            }
        }
    }
}
