using System.Xml.Serialization;

namespace Timetabler.XmlData
{
    /// <summary>
    /// XML-serialisable class to store the opening hours of a signalbox.
    /// </summary>
    public class SignalboxHoursModel
    {
        /// <summary>
        /// The ID of the signalbox.
        /// </summary>
        [XmlElement]
        public string SignalboxId { get; set; }

        /// <summary>
        /// The turn start time.
        /// </summary>
        [XmlElement]
        public TimeOfDayModel StartTime { get; set; }

        /// <summary>
        /// The turn finish time.
        /// </summary>
        [XmlElement]
        public TimeOfDayModel FinishTime { get; set; }

        /// <summary>
        /// Whether or not this turn has unbalanced movements, and therefore a warning flag should be displayed.
        /// </summary>
        [XmlElement]
        public bool TokenBalanceWarning { get; set; }
    }
}
