using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Timetabler.CoreData;

namespace Timetabler.Helpers
{
    /// <summary>
    /// Various helper methods to do with time handling.
    /// </summary>
    public static class TimeHelpers
    {
        /// <summary>
        /// Reset a set of time-edit controls to the blank state.
        /// </summary>
        /// <param name="tbHours">A <see cref="TextBox" /> to be blanked out.</param>
        /// <param name="tbMinutes">A <see cref="TextBox" /> to be blanked out.</param>
        /// <param name="cbHalf">A <see cref="ComboBox" /> to be reset.</param>
        public static void ClearTimeBoxes(TextBox tbHours, TextBox tbMinutes, ComboBox cbHalf)
        {
            if (tbHours is null)
            {
                throw new ArgumentNullException(nameof(tbHours));
            }
            if (tbMinutes is null)
            {
                throw new ArgumentNullException(nameof(tbMinutes));
            }
            if (cbHalf is null)
            {
                throw new ArgumentNullException(nameof(cbHalf));
            }

            tbHours.Text = string.Empty;
            tbMinutes.Text = string.Empty;
            cbHalf.SelectedIndex = 0;
        }

        /// <summary>
        /// Populate an array of combo boxes with values derived from the <see cref="HalfOfDay" /> enum.
        /// </summary>
        /// <param name="boxes">The <see cref="ComboBox" /> instances to populate.</param>
        public static void PopulateHalfOfDayComboBoxes(params ComboBox[] boxes)
        {
            foreach (ComboBox box in boxes)
            {
                box.Items.AddRange(HumanReadableEnumFactory.GetHalfOfDayForSelection());
            }
        }

        /// <summary>
        /// Set the value of a named property of an object to a <see cref="TimeOfDay" /> instance created from the contents of a set of <see cref="TextBox" /> instances and optionally a 
        /// <see cref="ComboBox" /> instance.
        /// </summary>
        /// <param name="model">The object with a <see cref="TimeOfDay" /> property to be set.</param>
        /// <param name="prop">The property of the object to set the value of.</param>
        /// <param name="tbHours">The <see cref="TextBox" /> containing the hours part of the time.</param>
        /// <param name="tbMinutes">The <see cref="TextBox" /> containing the minutes part of the time.</param>
        /// <param name="cbHalfOfDay">The <see cref="ComboBox" /> used to select the half of the day, or null.</param>
        /// <param name="seconds">The seconds part of the time.</param>
        /// <remarks>If the cbHalfOfDay parameter is null, the content of the tbHours <see cref="TextBox" /> will be interpreted as a time on the 24-hour clock.  If the cbHalfOfDay parameter
        /// is not null, it is assumed that the content of the tbHours <see cref="TextBox" /> is a time on the 12-hour clock, and the cbHalfOfDay parameter's <see cref="ComboBox.SelectedItem" /> 
        /// property will be a <see cref="HumanReadableEnum{TEnum}" /> instance wrapping a <see cref="HalfOfDay" /> value.  This value will be used to determine whether the time is before or after 
        /// midday.</remarks>
        public static void SetTimeProperty(object model, PropertyInfo prop, TextBox tbHours, TextBox tbMinutes, ComboBox cbHalfOfDay, int seconds)
        {
            if (tbHours is null)
            {
                throw new ArgumentNullException(nameof(tbHours));
            }
            if (tbMinutes is null)
            {
                throw new ArgumentNullException(nameof(tbMinutes));
            }
            if (prop is null)
            {
                throw new ArgumentNullException(nameof(prop));
            }

            if (tbHours.Text.Length == 0 || tbMinutes.Text.Length == 0)
            {
                prop.SetValue(model, null);
            }
            else
            {
                if (int.TryParse(tbHours.Text, out int h) && int.TryParse(tbMinutes.Text, out int m))
                {
                    if (cbHalfOfDay != null)
                    {
                        if ((cbHalfOfDay.SelectedItem as HumanReadableEnum<HalfOfDay>)?.Value == HalfOfDay.PM)
                        {
                            if (h < 12)
                            {
                                h += 12;
                            }
                        }
                        else if (h >= 12)
                        {
                            h -= 12;
                        }
                    }
                    prop.SetValue(model, new TimeOfDay(h, m, seconds));
                }
            }
        }
    }
}
