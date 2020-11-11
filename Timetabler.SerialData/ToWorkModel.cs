namespace Timetabler.SerialData
{
    /// <summary>
    /// Class representing a timetable "to work" cell, which can contain either a time of day or free text.
    /// </summary>
    public class ToWorkModel
    {
        /// <summary>
        /// The time entered in the cell, if no free text has been entered.
        /// </summary>
        public TimeOfDayModel At { get; set; }

        /// <summary>
        /// The free text that has been entered in the cell.
        /// </summary>
        public string Text { get; set; }
    }
}
