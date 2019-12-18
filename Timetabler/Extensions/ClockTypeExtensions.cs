using System.Collections.Generic;
using System.Windows.Forms;
using Timetabler.Data;

namespace Timetabler.Extensions
{
    /// <summary>
    /// Helper classes for the <see cref="ClockType" /> enum.
    /// </summary>
    public static class ClockTypeExtensions
    {
        /// <summary>
        /// Extension method that takes a list of <see cref="Control" /> objects and sets them to visible if the <see cref="ClockType" /> is the 12-hour clock.
        /// </summary>
        /// <param name="clockType">The <see cref="ClockType" /> to use to determine the objects' visibility.</param>
        /// <param name="controls">The <see cref="Control" /> objects to control the visibility of.</param>
        public static void SetControlsVisibleIn12HourMode(this ClockType clockType, IList<Control> controls)
        {
            if (controls is null)
            {
                return;
            }
            bool visibility = clockType == ClockType.TwelveHourClock;
            foreach (Control control in controls)
            {
                control.Visible = visibility;
            }
        }
    }
}
