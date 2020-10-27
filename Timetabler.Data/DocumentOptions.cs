using System.Drawing;

namespace Timetabler.Data
{
    /// <summary>
    /// Timetable-level configurable options.
    /// </summary>
    public class DocumentOptions
    {
        /// <summary>
        /// The default speed of graph speed lines.
        /// </summary>
        public const int DefaultSpeedLineSpeed = 20;

        /// <summary>
        /// The default spacing of graph speed lines (in minutes).
        /// </summary>
        public const int DefaultSpeedLineSpacing = 60;

        /// <summary>
        /// The default appearance of graph speed lines.
        /// </summary>
        public static GraphTrainProperties DefaultSpeedLineAppearence =>
            new GraphTrainProperties { Colour = Color.LightGray, DashStyle = System.Drawing.Drawing2D.DashStyle.Dot, Width = 1f };

        private ClockType _clockType;

        /// <summary>
        /// Whether this timetable uses the 12-hour or 24-hour clock.
        /// </summary>
        public ClockType ClockType
        {
            get
            {
                return _clockType;
            }
            set
            {
                _clockType = value;
                UpdateFormattingStrings();
            }
        }

        /// <summary>
        /// Whether or not to display train labels on graphs.
        /// </summary>
        public bool DisplayTrainLabelsOnGraphs { get; set; }

        /// <summary>
        /// How the train graph control should behave.
        /// </summary>
        public GraphEditStyle GraphEditStyle { get; set; }

        /// <summary>
        /// Whether or not to display speed guides on graphs.
        /// </summary>
        public bool DisplaySpeedLinesOnGraphs { get; set; }

        /// <summary>
        /// If speed guides are displayed on graphs, what speed should they indicate.
        /// </summary>
        public int SpeedLineSpeed { get; set; }

        /// <summary>
        /// If speed guides are displayed on graphs, what should their horizontal spacing be.
        /// </summary>
        public int SpeedLineSpacingMinutes { get; set; }

        /// <summary>
        /// If speed guides are displayed on graphs, what should their visual appearance be.
        /// </summary>
        public GraphTrainProperties SpeedLineAppearance { get; set; }

        /// <summary>
        /// The correct formatting strings to use for time output, given the current value of the <see cref="ClockType" /> property.  Note that subsequent calls to the get method of this property
        /// may return the same object.  That object's properties are tied to the this object's <see cref="ClockType" /> property and will change if the <see cref="ClockType" /> property 
        /// of this object is changed.
        /// </summary>
        public TimeDisplayFormattingStrings FormattingStrings { get; } = new TimeDisplayFormattingStrings();

        /// <summary>
        /// Default constructor.  Sets <see cref="GraphEditStyle" /> property to <see cref="GraphEditStyle.PreserveSectionTimes" />.
        /// </summary>
        public DocumentOptions()
        {
            GraphEditStyle = GraphEditStyle.PreserveSectionTimes;
            SpeedLineAppearance = DefaultSpeedLineAppearence;
            SpeedLineSpeed = DefaultSpeedLineSpeed;
            SpeedLineSpacingMinutes = DefaultSpeedLineSpacing;
        }

        /// <summary>
        /// Produce a shallow copy of this instance
        /// </summary>
        /// <returns>A copy of this instance.</returns>
        public DocumentOptions Copy()
        {
            return new DocumentOptions 
            { 
                ClockType = ClockType, 
                DisplayTrainLabelsOnGraphs = DisplayTrainLabelsOnGraphs, 
                GraphEditStyle = GraphEditStyle,
                DisplaySpeedLinesOnGraphs = DisplaySpeedLinesOnGraphs,
                SpeedLineSpeed = SpeedLineSpeed,
                SpeedLineSpacingMinutes = SpeedLineSpacingMinutes,
                SpeedLineAppearance = SpeedLineAppearance.Copy(),
            };
        }

        /// <summary>
        /// Copies the properties of this object into another <see cref="DocumentOptions" /> object.  This is a shallow copy.
        /// </summary>
        /// <param name="options">The object whose properties will be overwritten with the values of this object's properties.</param>
        public void CopyTo(DocumentOptions options)
        {
            if (options == null)
            {
                return;
            }

            // This test avoids changing all the formatting strings if we don't actually have to.
            if (options.ClockType != ClockType)
            {
                options.ClockType = ClockType;
            }
            options.DisplayTrainLabelsOnGraphs = DisplayTrainLabelsOnGraphs;
            options.GraphEditStyle = GraphEditStyle;
            options.DisplaySpeedLinesOnGraphs = DisplaySpeedLinesOnGraphs;
            options.SpeedLineSpacingMinutes = SpeedLineSpacingMinutes;
            options.SpeedLineSpeed = SpeedLineSpeed;
            SpeedLineAppearance.CopyTo(options.SpeedLineAppearance);
        }

        /// <summary>
        /// Update the <see cref="FormattingStrings" /> object's properties when the value of the <see cref="ClockType" /> property has changed.
        /// </summary>
        private void UpdateFormattingStrings()
        {
            const string formatPlaceholder = "{0}";
            switch (_clockType)
            {
                case ClockType.TwelveHourClock:
                default:
                    FormattingStrings.Complete = "h" + formatPlaceholder + "mmf";
                    FormattingStrings.TimeWithoutFootnotes = "h mmf";
                    FormattingStrings.Hours = "h";
                    FormattingStrings.Minutes = "mmf";
                    FormattingStrings.Tooltip = "h:mmftt";
                    break;
                case ClockType.TwentyFourHourClock:
                    FormattingStrings.Complete = "HH" + formatPlaceholder + "mmf";
                    FormattingStrings.TimeWithoutFootnotes = "HH mmf";
                    FormattingStrings.Hours = "HH";
                    FormattingStrings.Minutes = "mmf";
                    FormattingStrings.Tooltip = "HH:mmf";
                    break;
            }
        }
    }
}
