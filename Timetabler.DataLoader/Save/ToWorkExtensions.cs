using System;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// YAML-related extension methods for the <see cref="ToWork" /> class.
    /// </summary>
    public static class ToWorkExtensions
    {
        /// <summary>
        /// Convert a <see cref="ToWork" /> instance to a <see cref="ToWorkModel" /> instance.
        /// </summary>
        /// <param name="toWork">The object to be converted.</param>
        /// <returns>A <see cref="ToWorkModel" /> instance containing the same data as the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static ToWorkModel ToToWorkModel(this ToWork toWork)
        {
            if (toWork is null)
            {
                throw new NullReferenceException();
            }

            return new ToWorkModel
            {
                Text = toWork.Text,
                At = toWork.AtTime?.ToTimeOfDayModel(),
            };
        }
    }
}
