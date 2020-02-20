using Timetabler.CoreData;

namespace Timetabler.SerialData.Yaml
{
    /// <summary>
    /// Class representing a location, in serialisable form.
    /// </summary>
    public class LocationModel
    {
        /// <summary>
        /// The unique ID of this location.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The name of the location as displayed in the editor grid.
        /// </summary>
        public string EditorDisplayName { get; set; }

        /// <summary>
        /// The name of the location as displayed in timetables in PDF exports.
        /// </summary>
        public string TimetableDisplayName { get; set; }

        /// <summary>
        /// The name of the location as displayed on train graphs.
        /// </summary>
        public string GraphDisplayName { get; set; }

        /// <summary>
        /// A code for the location (such as a TIPLOC code).
        /// </summary>
        public string LocationCode { get; set; }

        /// <summary>
        /// Whether arrival and/or departure rows should always be displayed for this location on Up tables, even if they are not used by trains.
        /// </summary>
        public ArrivalDepartureOptions? UpArrivalDepartureAlwaysDisplayed { get; set; }

        /// <summary>
        /// Whether a routing code row should always be displayed for this location on Up tables, even if it is not used by trains.
        /// </summary>
        public TrainRoutingOptions? UpRoutingCodesAlwaysDisplayed { get; set; }

        /// <summary>
        /// Whether arrival and/or departure rows should always be displayed for this location on Down tables, even if they are not used by trains.
        /// </summary>
        public ArrivalDepartureOptions? DownArrivalDepartureAlwaysDisplayed { get; set; }

        /// <summary>
        /// Whether a routing code row should always be displayed for this location on Down tables, even if it is not used by trains.
        /// </summary>
        public TrainRoutingOptions? DownRoutingCodesAlwaysDisplayed { get; set; }

        /// <summary>
        /// Always draw a separator line above the rows for this location.
        /// </summary>
        public bool? DisplaySeparatorAbove { get; set; }

        /// <summary>
        /// Always draw a separator line below the rows for this location.
        /// </summary>
        public bool? DisplaySeparatorBelow { get; set; }

        /// <summary>
        /// The mileage of this location.
        /// </summary>
        public DistanceModel Mileage { get; set; }

        /// <summary>
        /// The font type to use to display the location on PDF exports ("Normal" or "Condensed").
        /// </summary>
        public string FontTypeName { get; set; }
    }
}
