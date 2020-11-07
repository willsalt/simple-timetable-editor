namespace Timetabler.CoreData
{
    /// <summary>
    /// An enum type for stating which sections someting applies to.
    /// </summary>
    public enum SectionSelection
    {
        /// <summary>
        /// Does not apply to any sections in the group.
        /// </summary>
        None,

        /// <summary>
        /// Only applies to the first section in the group.
        /// </summary>
        First,

        /// <summary>
        /// Applies to all sections in the group.
        /// </summary>
        All,
    }
}
