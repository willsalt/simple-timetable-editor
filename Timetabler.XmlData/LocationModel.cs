using System;
using System.Xml.Serialization;
using Timetabler.CoreData;

namespace Timetabler.XmlData
{
    /// <summary>
    /// The XML-serializable representation of a Location object.
    /// </summary>
    public class LocationModel
    {
        /// <summary>
        /// A string that uniquely identifies this location.
        /// </summary>
        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// The name of this location, as formatted for display in the application GUI.
        /// </summary>
        [XmlElement]
        public string EditorDisplayName { get; set; }

        /// <summary>
        /// The name of this location, as formatted for display on timetables formatted for printed output.
        /// </summary>
        [XmlElement]
        public string TimetableDisplayName { get; set; }

        /// <summary>
        /// The name of this location, as formatted for display on train graphs.
        /// </summary>
        [XmlElement]
        public string GraphDisplayName { get; set; }

        /// <summary>
        /// An abbreviated code to describe this location.
        /// </summary>
        [XmlElement]
        public string Tiploc { get; set; }

        /// <summary>
        /// Whether or not this location should always have arrival and/or departure rows displayed on Up pages of the timetable.
        /// </summary>
        [XmlElement]
        public ArrivalDepartureOptions UpArrivalDepartureAlwaysDisplayed { get; set; }

        /// <summary>
        /// Which of the train routing code fields (path, platform, or line), are always displayed for this location on the up pages of the timetable. 
        /// </summary>
        [XmlElement]
        public TrainRoutingOptions? UpRoutingCodesAlwaysDisplayed { get; set; }

        /// <summary>
        /// Whether or not this location should always have arrival and/or departure rows displayed on Down pages of the timetable.
        /// </summary>
        [XmlElement]
        public ArrivalDepartureOptions DownArrivalDepartureAlwaysDisplayed { get; set; }

        /// <summary>
        /// Which of the train routing code fields (path, platform, or line), are always displayed for this location on the down pages of the timetable.
        /// </summary>
        [XmlElement]
        public TrainRoutingOptions? DownRoutingCodesAlwaysDisplayed { get; set; }

        /// <summary>
        /// Whether on export a separator line should be drawn above this location.
        /// </summary>
        [XmlElement]
        public bool? DisplaySeparatorAbove { get; set; }

        /// <summary>
        /// Whether on export a separator line should be drawn below this location.
        /// </summary>
        [XmlElement]
        public bool? DisplaySeparatorBelow { get; set; }

        /// <summary>
        /// The mileage value of this location.
        /// </summary>
        [XmlElement]
        public DistanceModel Mileage { get; set; }

        /// <summary>
        /// Whether this location name should be displayed using the "normal" or "alternative" font, if the display method supports that option.
        /// </summary>
        [XmlElement]
        public string FontTypeName { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocationModel()
        {
            Mileage = new DistanceModel();
        }
    }
}
