namespace Timetabler.Data
{
    /// <summary>
    /// The way in which the train graph control should behave when timing points are dragged.
    /// </summary>
    public enum GraphEditStyle
    {
        /// <summary>
        /// Allow free editing - even if it makes trains appear to travel in time.
        /// </summary>
        Free = 0,

        /// <summary>
        /// Preserve section times - when a time is dragged forward in time, times in the future are also moved forward.  When a time is dragged backwards in time, times in the past
        /// are moved backwards.
        /// </summary>
        PreserveSectionTimes = 1
    }
}
