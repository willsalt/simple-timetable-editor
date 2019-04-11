using Timetabler.Data;
using Timetabler.XmlData;

namespace Timetabler.DataLoader.Save
{
    /// <summary>
    /// Convert a <see cref="ToWork" /> instance into a serializable form. 
    /// </summary>
    public static class ToWorkExtensions
    {
        /// <summary>
        /// Convert a <see cref="ToWork" /> instance into a <see cref="ToWorkModel" /> instance.  
        /// </summary>
        /// <param name="data">The object to be converted.</param>
        /// <returns>A <see cref="ToWorkModel" /> instance containing the same data as the parameter.</returns>
        public static ToWorkModel ToToWorkModel(this ToWork data)
        {
            ToWorkModel model = new ToWorkModel { Text = data.Text };
            if (data.AtTime != null)
            {
                model.AtTime = data.AtTime.ToTimeOfDayModel();
            }
            return model;
        }
    }
}
