using System.Collections.Generic;
using Timetabler.CoreData;
using Timetabler.Data.Display;

namespace Timetabler.Data.Comparers
{
    /// <summary>
    /// An <see cref="IComparer{T}"/> implementation for <see cref="LocationDisplayModel"/> instances, which orders based on location.
    /// Can be configured to order in either the up or down directions.
    /// </summary>
    public class LocationDisplayModelComparer : IComparer<LocationDisplayModel>
    {
        private readonly Direction _direction;

        /// <summary>
        /// The constructor needs to know what direction its output is supposed to be in.
        /// </summary>
        /// <param name="direction">The direction to order in - Down if locations with lower mileage come first, Up if locations with higher mileage come first.</param>
        public LocationDisplayModelComparer(Direction direction)
        {
            _direction = direction;
        }

        /// <summary>
        /// Compare two <see cref="LocationDisplayModel"/> instances.  Compares based on location first, then on whether this display model is for an arrival or departure row.  Null parameters
        /// compare as lower than any non-null parameter.
        /// </summary>
        /// <param name="x">A <see cref="LocationDisplayModel"/> instance.</param>
        /// <param name="y">A <see cref="LocationDisplayModel"/> instance.</param>
        /// <returns>-1, 0 or 1 according to whether x is less than, equal to or greater than y.</returns>
        public int Compare(LocationDisplayModel x, LocationDisplayModel y)
        {
            if (x == null)
            {
                return (y == null) ? 0 : -1;
            }
            if (y == null)
            {
                return 1;
            }

            int compareResult = 0;
            if (x.Mileage < y.Mileage)
            {
                compareResult = -1;
            }
            else if (x.Mileage > y.Mileage)
            {
                compareResult = 1;
            }
            if (_direction == Direction.Down && compareResult != 0)
            {
                return compareResult;
            }
            if (compareResult < 0)
            {
                return 1;
            }
            if (compareResult > 0)
            {
                return -1;
            }

            // If we reach this point, the location rows are for locations with the same mileage, so we assume it is the same location and we are ordering arrival and departure rows
            if (x.LocationKey.Contains("-") && y.LocationKey.Contains("-"))
            {
                return string.Compare(x.LocationKey.Substring(x.LocationKey.LastIndexOf("-") + 1), y.LocationKey.Substring(y.LocationKey.LastIndexOf("-") + 1));
            } 
            
            // The locations have the same mileage, but do not have standard format location keys.
            return 0;
        }
    }
}
