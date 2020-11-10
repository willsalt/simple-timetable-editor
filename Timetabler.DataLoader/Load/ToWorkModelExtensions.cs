using System;
using Timetabler.Data;
using Timetabler.SerialData.Yaml;

namespace Timetabler.DataLoader.Load.Yaml
{
    /// <summary>
    /// Extension methods for the <see cref="ToWorkModel" /> class.
    /// </summary>
    public static class ToWorkModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="ToWorkModel" /> instance to a <see cref="ToWork" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <returns>A <see cref="ToWork" /> instance that contains the same data as the parameter.</returns>
        /// <exception cref="NullReferenceException">Thrown if the parameter is <c>null</c>.</exception>
        public static ToWork ToToWork(this ToWorkModel model)
        {
            if (model is null)
            {
                throw new NullReferenceException();
            }

            ToWork output = new ToWork { Text = model.Text };
            if (model.At != null)
            {
                output.AtTime = model.At.ToTimeOfDay();
            }
            return output;
        }
    }
}
