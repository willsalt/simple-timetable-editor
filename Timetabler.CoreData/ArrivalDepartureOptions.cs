using System;

namespace Timetabler.CoreData
{
    /// <summary>
    /// A flags enum which describes whether something applies to arrival, departure, or both.
    /// </summary>
    [Flags]
    public enum ArrivalDepartureOptions
    {
        /// <summary>
        /// Applies to arrivals.
        /// </summary>
        Arrival = 1,

        /// <summary>
        /// Applies to departures.
        /// </summary>
        Departure = 2
    }
}
