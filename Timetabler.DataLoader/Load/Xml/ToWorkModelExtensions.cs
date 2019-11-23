using Timetabler.Data;
using Timetabler.SerialData.Xml;

namespace Timetabler.DataLoader.Load.Xml
{
    /// <summary>
    /// Methods for deserialising a <see cref="ToWork" /> instance from serializable form. 
    /// </summary>
    public static class ToWorkModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="ToWorkModel" /> object into a <see cref="ToWork" /> object.  
        /// </summary>
        /// <param name="model">The data to be converted.</param>
        /// <returns>A <see cref="ToWork" /> instance which is equivalent to the object.</returns>
        public static ToWork ToToWork(this ToWorkModel model)
        {
            ToWork output = new ToWork { Text = model.Text };
            if (model.AtTime != null)
            {
                output.AtTime = model.AtTime.ToTimeOfDay();
            }
            return output;
        }
    }
}
