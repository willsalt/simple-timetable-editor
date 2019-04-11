namespace Timetabler.Adapters
{
    /// <summary>
    /// Column/row resize mode for a timetable grid.
    /// </summary>
    public enum GridLayoutMode
    {
        /// <summary>
        /// Frozen layout - adding or changing data will not resize anything.
        /// </summary>
        Frozen,

        /// <summary>
        /// Automatic layout - adding or changing data will resize everything automatically.  This is quite slow.
        /// </summary>
        Automatic,
    }
}
