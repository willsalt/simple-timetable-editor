using System;

namespace Timetabler.CoreData
{
    /// <summary>
    /// An enum type to describe which of the train routing fields (if any) apply to a timing point.
    /// </summary>
    [Flags]
    public enum TrainRoutingOptions
    {
        /// <summary>
        /// Path - the train routing field that precedes arrival
        /// </summary>
        Path = 1,

        /// <summary>
        /// Platform - the train routing field that is between arrival and departure.
        /// </summary>
        Platform = 2,

        /// <summary>
        /// Line - the train routing field that is after departure.
        /// </summary>
        Line = 4,
    }
}
