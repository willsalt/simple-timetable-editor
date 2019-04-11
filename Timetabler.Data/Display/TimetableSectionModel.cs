using NLog;
using System.Collections.Generic;
using System.Linq;
using Timetabler.CoreData;
using Timetabler.CoreData.Helpers;
using Timetabler.Data.Collections;
using Timetabler.Data.Comparers;
using Timetabler.Data.Events;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// This class stores display data for a section ("Up" or "Down") of a timetable.
    /// </summary>
    public class TimetableSectionModel
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The event handler type for the <see cref="TrainSegmentAdd"/> event.
        /// </summary>
        /// <param name="sender">The object raising the event.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void TrainSegmentEventHandler(object sender, TrainSegmentEventArgs e);

        /// <summary>
        /// Event raised when a train segment is added to the model.
        /// </summary>
        public event TrainSegmentEventHandler TrainSegmentAdd;

        /// <summary>
        /// Event raised when a train segment is removed from the model.
        /// </summary>
        public event TrainSegmentEventHandler TrainSegmentRemove;

        /// <summary>
        /// Which direction of travel this timetable section is for.
        /// </summary>
        public Direction Direction
        {
            get
            {
                return _direction;
            }
            set
            {
                _direction = value;
                _locationDisplayModelComparer = new LocationDisplayModelComparer(_direction);
            }
        }

        private Direction _direction;

        private LocationDisplayModelComparer _locationDisplayModelComparer;

        private LocationCollection _locationMap;

        /// <summary>
        /// A list of all the locations that may appear in this section.
        /// </summary>
        public LocationCollection LocationMap
        {
            get
            {
                return _locationMap;
            }
            set
            {
                _locationMap = value;
            }
        }

        private Dictionary<string, Location> LocationDict
        {
            get
            {
                return LocationMap.ToDictionary(c => c.Id);
            }
        }

        /// <summary>
        /// The list of locations display rows in this section.
        /// </summary>
        public LocationDisplayModelCollection Locations { get; set; }

        /// <summary>
        /// The list of train segments which make up the columns of this section.
        /// </summary>
        public TrainSegmentModelCollection TrainSegments { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="direction">The direction which applies to this section.</param>
        public TimetableSectionModel(Direction direction)
        {
            Direction = direction;
            Locations = new LocationDisplayModelCollection();
            TrainSegments = new TrainSegmentModelCollection();
        }

        /// <summary>
        /// Remove any rows that are no longer being used.
        /// </summary>
        public void CleanLocations()
        {
            var keys = TrainSegments.SelectMany(t => t.TimingsIndex).Select(t => t.Key).Distinct().ToArray();
            Locations.RemoveAll(o => !keys.Contains(o.LocationKey) && !o.AlwaysDisplay);
        }

        /// <summary>
        /// Add a column to the table.
        /// </summary>
        /// <param name="segment">The data in the column to be added.</param>
        public void Add(TrainSegmentModel segment)
        {
            foreach (string locationKey in TrainSegments.SelectMany(t => t.TimingsIndex).Select(t => t.Key).Union(segment.TimingsIndex.Select(t => t.Key)))
            {
                if (!Locations.Any(l => l.LocationKey == locationKey))
                {
                    string strippedKey = locationKey.StripArrivalDepartureSuffix();
                    Location loc = LocationDict[strippedKey];
                    LocationDisplayModel ldm = new LocationDisplayModel
                    {
                        LocationKey = locationKey,
                        LocationId = loc.Id,
                        Mileage = loc.Mileage,
                        FontType = loc.FontType,
                        DisplaySeparatorAbove = loc.DisplaySeparatorAbove,
                        DisplaySeparatorBelow = loc.DisplaySeparatorBelow,
                        ParentDisplaySeparatorBelow = loc.DisplaySeparatorBelow,
                        ParentDisplaySeparatorAbove = loc.DisplaySeparatorAbove,
                    };
                    if (locationKey.EndsWith(LocationIdSuffixes.Arrival) || locationKey.EndsWith(LocationIdSuffixes.Departure))
                    {
                        ldm.ArrivalDepartureLabel = locationKey.Substring(locationKey.Length - 1);
                        ldm.EditorDisplayName = loc.EditorDisplayName;
                        ldm.ExportDisplayName = loc.TimetableDisplayName;
                    }
                    else
                    {
                        ldm.EditorDisplayName = string.Empty;
                        ldm.ExportDisplayName = string.Empty;
                        ldm.IsRoutingCodeRow = true;
                        if (locationKey.EndsWith(LocationIdSuffixes.Platform))
                        {
                            ldm.ArrivalDepartureLabel = Resources.LocationRow_Abbreviation_Platform;
                        }
                    }
                    Locations.AddSorted(ldm, _locationDisplayModelComparer);
                }
            }
            TrainSegments.AddSorted(segment, new TrainSegmentModelComparer(Locations));
        }

        /// <summary>
        /// Raises the <see cref="TrainSegmentAdd"/> event.
        /// </summary>
        /// <param name="segment">The segment which has been added to the model.</param>
        /// <param name="index">The index number of the segment within the model, after sorting.</param>
        protected virtual void OnAdd(TrainSegmentModel segment, int index)
        {
            TrainSegmentAdd?.Invoke(this, new TrainSegmentEventArgs { TrainSegment = segment, Index = index });
        }

        /// <summary>
        /// Ensure that this timetable section always displays locations marked as compulsary.
        /// </summary>
        public void CheckCompulsaryLocationsAreVisible()
        {
            if (LocationMap == null || LocationMap.Count == 0)
            {
                return;
            }
            switch (Direction)
            {
                case Direction.Down:
                    foreach (Location loc in LocationMap)
                    {
                        if ((loc.DownRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Path) != 0)
                        {
                            AddCompulsaryRoutingCodeRow(loc, LocationIdSuffixes.Path);
                        }
                        if ((loc.DownArrivalDepartureAlwaysDisplayed & ArrivalDepartureOptions.Arrival) != 0)
                        {
                            AddCompulsaryLocation(loc, LocationIdSuffixes.Arrival);
                        }
                        if ((loc.DownRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Platform) != 0)
                        {
                            AddCompulsaryRoutingCodeRow(loc, LocationIdSuffixes.Platform);
                        }
                        if ((loc.DownArrivalDepartureAlwaysDisplayed & ArrivalDepartureOptions.Departure) != 0)
                        {
                            AddCompulsaryLocation(loc, LocationIdSuffixes.Departure);
                        }
                        if ((loc.DownRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Line) != 0)
                        {
                            AddCompulsaryRoutingCodeRow(loc, LocationIdSuffixes.Line);
                        }
                    }
                    break;
                case Direction.Up:
                    foreach (Location loc in LocationMap)
                    {
                        if ((loc.UpRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Path) != 0)
                        {
                            AddCompulsaryRoutingCodeRow(loc, LocationIdSuffixes.Path);
                        }
                        if ((loc.UpArrivalDepartureAlwaysDisplayed & ArrivalDepartureOptions.Arrival) != 0)
                        {
                            AddCompulsaryLocation(loc, LocationIdSuffixes.Arrival);
                        }
                        if ((loc.UpRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Platform) != 0)
                        {
                            AddCompulsaryRoutingCodeRow(loc, LocationIdSuffixes.Platform);
                        }
                        if ((loc.UpArrivalDepartureAlwaysDisplayed & ArrivalDepartureOptions.Departure) != 0)
                        {
                            AddCompulsaryLocation(loc, LocationIdSuffixes.Departure);
                        }
                        if ((loc.UpRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Line) != 0)
                        {
                            AddCompulsaryRoutingCodeRow(loc, LocationIdSuffixes.Line);
                        }
                    }
                    break;
            }
        }

        private void AddCompulsaryLocation(Location loc, string locationKeySuffix)
        {
            string locationKey = loc.Id + locationKeySuffix;
            Log.Trace("Adding location arrival/departure row for {0}", locationKey);
            if (!Locations.Any(l => l.LocationKey == locationKey))
            {
                Locations.AddSorted(new LocationDisplayModel
                {
                    LocationKey = locationKey,
                    LocationId = loc.Id,
                    AlwaysDisplay = true,
                    ArrivalDepartureLabel = locationKey.Substring(locationKey.Length - 1),
                    EditorDisplayName = loc.EditorDisplayName,
                    ExportDisplayName = loc.TimetableDisplayName,
                    Mileage = loc.Mileage,
                    FontType = loc.FontType,
                    IsRoutingCodeRow = false,
                    DisplaySeparatorAbove = loc.DisplaySeparatorAbove,
                    DisplaySeparatorBelow = loc.DisplaySeparatorBelow,
                    ParentDisplaySeparatorAbove = loc.DisplaySeparatorAbove,
                    ParentDisplaySeparatorBelow = loc.DisplaySeparatorBelow,
                }, _locationDisplayModelComparer);
            }
        }

        private void AddCompulsaryRoutingCodeRow(Location loc, string keySuffix)
        {
            string locationKey = loc.Id + keySuffix;
            Log.Trace("Adding routing code row for {0}", locationKey);
            if (!Locations.Any(l => l.LocationKey == locationKey))
            {
                Locations.AddSorted(new LocationDisplayModel
                {
                    LocationKey = locationKey,
                    LocationId = loc.Id,
                    AlwaysDisplay = true,
                    ArrivalDepartureLabel = string.Empty,
                    EditorDisplayName = string.Empty,
                    ExportDisplayName = string.Empty,
                    Mileage = loc.Mileage,
                    FontType = loc.FontType,
                    IsRoutingCodeRow = true,
                    DisplaySeparatorAbove = loc.DisplaySeparatorAbove,
                    DisplaySeparatorBelow = loc.DisplaySeparatorBelow,
                    ParentDisplaySeparatorAbove = loc.DisplaySeparatorAbove,
                    ParentDisplaySeparatorBelow = loc.DisplaySeparatorBelow,
                }, _locationDisplayModelComparer);
            }
        }
    }
}
