namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// Class that describes the opening hours of a signalbox for a particular timetable.
    /// </summary>
    public class SignalboxHoursModel
    {
        /// <summary>
        /// The unique ID of the relevant signalbox.
        /// </summary>
        public string SignalboxId { get; set; }

        /// <summary>
        /// Signalbox opening time.
        /// </summary>
        public TimeOfDayModel StartTime { get; set; }

        /// <summary>
        /// Signalbox closing time.
        /// </summary>
        public TimeOfDayModel FinishTime { get; set; }

        /// <summary>
        /// Whether or not the token balance warning footnote should be displayed as part of the closing time.
        /// </summary>
        public bool? TokenBalanceWarning { get; set; }
    }
}
