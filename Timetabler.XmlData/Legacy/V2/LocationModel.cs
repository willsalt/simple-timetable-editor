using System;
using System.Xml.Serialization;
using Timetabler.CoreData;

namespace Timetabler.XmlData.Legacy.V2
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
        /// Whether or not this location should have arrival and/or departure rows present by default in the timetable whether or not any trains call.
        /// </summary>
        [XmlElement]
        [Obsolete("Do not use - retained for compatibility with file version 1.")]
        public ArrivalDepartureOptions DefaultArrivalDepartureOptions { get; set; }

        /// <summary>
        /// Whether or not this location should always have arrival and/or departure rows displayed on Up pages of the timetable.
        /// </summary>
        [XmlElement]
        public ArrivalDepartureOptions UpArrivalDepartureAlwaysDisplayed { get; set; }

        /// <summary>
        /// Whether or not this location should always have arrival and/or departure rows displayed on Down pages of the timetable.
        /// </summary>
        [XmlElement]
        public ArrivalDepartureOptions DownArrivalDepartureAlwaysDisplayed { get; set; }

        /// <summary>
        /// The mileage value of this location.
        /// </summary>
        [XmlElement]
        public DistanceModel Mileage { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocationModel()
        {
            Mileage = new DistanceModel();
            DefaultArrivalDepartureOptions = ArrivalDepartureOptions.Arrival | ArrivalDepartureOptions.Departure;
        }
    }
}
