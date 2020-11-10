using System.Collections.Generic;

namespace Timetabler.SerialData
{
    /// <summary>
    /// Class representing a set of signalbox hours: in other words, a list of signalbox hours details, each applying to a different signalbox,
    /// with a common "category" such as "Day service" or "With evening service".
    /// </summary>
    public class SignalboxHoursSetModel
    {
        /// <summary>
        /// The category, describing the service pattern that this set of hours applies to.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// The list of signalbox hours data in this set.
        /// </summary>
        public List<SignalboxHoursModel> Signalboxes { get; } = new List<SignalboxHoursModel>();
    }
}
