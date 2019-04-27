using System.Collections.Generic;
using Timetabler.CoreData;
using Timetabler.Data.Display;

namespace Timetabler.Data
{
    /// <summary>
    /// The timings of a train at a given location.
    /// </summary>
    public class TrainLocationTime
    {
        /// <summary>
        /// The Path code for the location.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// The arrival time of the train at the location.
        /// </summary>
        public TrainTime ArrivalTime { get; set; }

        /// <summary>
        /// The Platform code for the location.
        /// </summary>
        public string Platform { get; set; }

        /// <summary>
        /// The departure or passing time of the train at the location.
        /// </summary>
        public TrainTime DepartureTime { get; set; }

        /// <summary>
        /// The Line code for the location.
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// Whether the departure time should be displayed as a passing time, or as a stopping time.
        /// </summary>
        public bool Pass { get; set; }

        /// <summary>
        /// The location this timing point is applicable to.
        /// </summary>
        public Location Location { get; set; }

        public TimeDisplayFormattingStrings FormattingStrings { get; set; }

        private TrainLocationTimeModel _arrivalTimeModel;

        private TrainLocationTimeModel _departureTimeModel;

        public TrainLocationTimeModel ArrivalTimeModel
        {
            get
            {
                return UpdateTrainLocationTimeModel(ref _arrivalTimeModel, ArrivalTime, LocationIdSuffixes.Departure);
            }
        }

        public TrainLocationTimeModel DepartureTimeModel
        {
            get
            {
                return UpdateTrainLocationTimeModel(ref _departureTimeModel, DepartureTime, LocationIdSuffixes.Departure);
            }
        }

        private TrainLocationTimeModel UpdateTrainLocationTimeModel(ref TrainLocationTimeModel model, TrainTime time, string idSuffix)
        {
            if (time == null || FormattingStrings == null || Location == null)
            {
                return null;
            }
            if (model == null)
            {
                model = new TrainLocationTimeModel
                {
                    LocationId = Location.Id,
                    LocationKey = Location.Id + idSuffix,
                    EntryType = TrainLocationTimeEntryType.Time,
                };
            }
            model.IsPassingTime = Pass;
            model.Populate(time, FormattingStrings);
            return model;
        }

        public void RefreshTimeModels()
        {
            UpdateTrainLocationTimeModel(ref _arrivalTimeModel, ArrivalTime, LocationIdSuffixes.Arrival);
            UpdateTrainLocationTimeModel(ref _departureTimeModel, DepartureTime, LocationIdSuffixes.Departure);
        }
        
        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainLocationTime()
        {
            ArrivalTime = new TrainTime();
            DepartureTime = new TrainTime();
        }

        /// <summary>
        /// Attempt to populate the <see cref="Location"/> property, and any timing point footnote properties, by looking their values up in dictionaries.
        /// </summary>
        /// <param name="locationMap">A dictionary of valid locations.</param>
        /// <param name="allFootnotes">A dictionary of valid footnotes.</param>
        public void ResolveAll(IDictionary<string, Location> locationMap, IDictionary<string, Note> allFootnotes)
        {
            ResolveLocation(locationMap);
            if (ArrivalTime != null)
            {
                ArrivalTime.ResolveFootnotes(allFootnotes);
            }
            if (DepartureTime != null)
            {
                DepartureTime.ResolveFootnotes(allFootnotes);
            }
        }

        /// <summary>
        /// Attempt to populate the <see cref="Location"/> property, by looking that property up in a dictionary.
        /// </summary>
        /// <param name="map">A dictionary of valid locations, whose key is the location ID.</param>
        public void ResolveLocation(IDictionary<string, Location> map)
        {
            if (Location == null)
            {
                return;
            }
            if (map.ContainsKey(Location.Id))
            {
                Location = map[Location.Id];
            }
        }

        /// <summary>
        /// Create a copy of this instance.  The <see cref="ArrivalTime"/> and <see cref="DepartureTime"/> properties are deep copies, the others shallow copies.
        /// </summary>
        /// <returns>A <see cref="TrainLocationTime"/> object whose properties are equal to this instance.</returns>
        public TrainLocationTime Copy()
        {
            TrainLocationTime tlt = new TrainLocationTime
            {
                ArrivalTime = ArrivalTime.Copy(),
                DepartureTime = DepartureTime.Copy(),
                Location = Location,
                Pass = Pass,
                Path = Path,
                Platform = Platform,
                Line = Line,
                FormattingStrings = FormattingStrings,
            };
            return tlt;
        }
    }
}
