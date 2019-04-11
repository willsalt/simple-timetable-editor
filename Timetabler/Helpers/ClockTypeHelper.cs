using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timetabler.Data;

namespace Timetabler.Helpers
{
    /// <summary>
    /// Helper classes for the <see cref="ClockType" /> enum.
    /// </summary>
    public static class ClockTypeHelper
    {
        /// <summary>
        /// Extension method that takes a list of <see cref="Control" /> objects and sets them to visible if the <see cref="ClockType" /> is the 12-hour clock.
        /// </summary>
        /// <param name="clockType">The <see cref="ClockType" /> to use to determine the objects' visibility.</param>
        /// <param name="controls">The <see cref="Control" /> objects to control the visibility of.</param>
        public static void SetControlsVisibleIn12HourMode(this ClockType clockType, IList<Control> controls)
        {
            bool visibility = clockType == ClockType.TwelveHourClock;
            foreach (Control control in controls)
            {
                control.Visible = visibility;
            }
        }
    }
}
