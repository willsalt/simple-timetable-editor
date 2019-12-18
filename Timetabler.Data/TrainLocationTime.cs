using System;
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

        /// <summary>
        /// The format strings to use for converting the time components of this timing point into strings.
        /// </summary>
        public TimeDisplayFormattingStrings FormattingStrings { get; set; }

        private TrainLocationTimeModel _arrivalTimeModel;

        private TrainLocationTimeModel _departureTimeModel;

        /// <summary>
        /// The model used to display the arrival time of this timing point.
        /// </summary>
        public TrainLocationTimeModel ArrivalTimeModel
        {
            get
            {
                return UpdateTrainLocationTimeModel(ref _arrivalTimeModel, ArrivalTime, LocationIdSuffixes.Arrival);
            }
        }

        /// <summary>
        /// The model used to display the departure time of this timing point.
        /// </summary>
        public TrainLocationTimeModel DepartureTimeModel
        {
            get
            {
                return UpdateTrainLocationTimeModel(ref _departureTimeModel, DepartureTime, LocationIdSuffixes.Departure);
            }
        }

        /// <summary>
        /// Gets whichever time occurs later, the arrival time or the departure time.  In theory this should always be the departure time.
        /// </summary>
        public TrainTime LastTime
        {
            get
            {
                if (ArrivalTime?.Time > DepartureTime?.Time)
                {
                    return ArrivalTime;
                }
                return DepartureTime;
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

        /// <summary>
        /// Ensure any changes to the times of the timing point are reflected in the display model data.  This method is provided for clarity, because this is also done as a side-effect of the
        /// display models' get methods, but there are are situations in which calling code might need to ensure that the display models have been updated but does not need to get a reference to
        /// the model objects themselves.  Calling the get methods purely to activate the side-effect but throwing away the result does not lead to readable code.
        /// </summary>
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
        /// Offset both arrival and departure time by the same specified amount.
        /// </summary>
        /// <param name="minutesOffset">The number of minutes to change the time by (positive for later, negative for earlier).</param>
        public void OffsetTimes(int minutesOffset)
        {
            if (ArrivalTime?.Time != null)
            {
                ArrivalTime.Time.AddMinutes(minutesOffset);
            }
            if (DepartureTime?.Time != null)
            {
                DepartureTime.Time.AddMinutes(minutesOffset);
            }
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
            if (map is null)
            {
                throw new ArgumentNullException(nameof(map));
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

        /// <summary>
        /// Change the times of this <see cref="TrainLocationTime" /> by reflecting them over another time.  In other words, if beforehand the train arrives ten minutes before and departs five 
        /// minutes before the reflection time, then afterwards, the train will arrive five minutes after and depart ten minutes after the reflection time.
        /// </summary>
        /// <param name="aroundTime">The time to reflect about.</param>
        /// <param name="alwaysSwap">If this parameter is false (the default), if the object only has a <see cref="DepartureTime" />, the reflected time will still be the 
        ///   <see cref="DepartureTime" />.  If it is true, then if the object only has a <see cref="DepartureTime" /> it will become the <see cref="ArrivalTime" />.</param>
        public void Reflect(TimeOfDay aroundTime, bool alwaysSwap = false)
        {
            TrainTime newArrivalTime = DepartureTime?.CopyAndReflect(aroundTime);
            TrainTime newDepartureTime = ArrivalTime?.CopyAndReflect(aroundTime);
            if (newDepartureTime?.Time == null && newArrivalTime?.Time != null && !alwaysSwap)
            {
                DepartureTime = newArrivalTime;
                ArrivalTime = newDepartureTime;
            }
            else
            {
                DepartureTime = newDepartureTime;
                ArrivalTime = newArrivalTime;
            }
        }
    }
}
