using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Data.Comparers
{
    /// <summary>
    /// A class to order train segments.  This class is similar to an <see cref="IComparer{T}"/> implementation, but the return type of its 
    /// <see cref="Compare(TrainSegmentModel, TrainSegmentModel)"/> method does not match that required by <see cref="IComparer{T}"/> as it may be necessary to modify the
    /// input objects.
    /// </summary>
    public class TrainSegmentModelComparer
    {
        private List<LocationDisplayModel> _locationMap;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="locationList">A list of the locations that may be encountered, so that their relative order can be used during comparisons.</param>
        public TrainSegmentModelComparer(IEnumerable<LocationDisplayModel> locationList)
        {
            _locationMap = locationList.ToList();
        }

        /// <summary>
        /// Compare two train segments and determine whether what order they should be placed in.
        /// </summary>
        /// <param name="x">A train segment to be compared.</param>
        /// <param name="y">A train segment to be compared.</param>
        /// <returns>A <see cref="Tuple{T1, T2}"/>.  The first element is an <see cref="int"/> which is -1, 0 or 1 according to whether x is less than, equal to or greater than y.  
        /// The second element is potentially a further train segment which has been created by splitting the lower-valued of the two segments into two parts.</returns>
        public Tuple<int, TrainSegmentModel> Compare(TrainSegmentModel x, TrainSegmentModel y)
        {
            // firstly, null checks
            int? nullCheckResult = CompareNullChecks(x, y);
            if (nullCheckResult.HasValue)
            {
                return new Tuple<int, TrainSegmentModel>(nullCheckResult.Value, null);
            }

            // secondly, no-times-present checks
            int? noTimesCheckResult = CompareNullChecks(x, y);
            if (noTimesCheckResult.HasValue)
            {
                return new Tuple<int, TrainSegmentModel>(noTimesCheckResult.Value, null);
            }

            // Trains overlap for at least one row
            if (x.Timings.Where(t => t is TrainLocationTimeModel).Any(t => y.TimingsIndex.ContainsKey(t.LocationKey)))
            {
                return CompareWithSharedTimes(x, y);
            }

            return CompareWithNoSharedTimes(x, y);
        }

        private Tuple<int, TrainSegmentModel> CompareWithNoSharedTimes(TrainSegmentModel x, TrainSegmentModel y)
        {
            // Take a subset of the location list that consists of all the timings in y, and the first in x
            var xFirst = x.Timings.First(t => t is TrainLocationTimeModel) as TrainLocationTimeModel;
            var subMap = _locationMap
                .Where(m => y.TimingsIndex.Where(t => t.Value is TrainLocationTimeModel).ToDictionary(z => z.Key, z => z.Value).ContainsKey(m.LocationKey) || m.LocationKey == xFirst.LocationKey)
                .ToList();

            // If the first timing in x comes before all the timings in y, repeat this the other way around
            int xFirstIndex = subMap.IndexOf(_locationMap.First(m => xFirst.LocationKey == m.LocationKey));
            if (xFirstIndex == 0)
            {
                var swappedResult = CompareWithNoSharedTimes(y, x);
                if (swappedResult.Item1 < 0)
                {
                    return new Tuple<int, TrainSegmentModel>(1, swappedResult.Item2);
                }
                else if (swappedResult.Item1 > 0)
                {
                    return new Tuple<int, TrainSegmentModel>(-1, swappedResult.Item2);
                }
                else
                {
                    return swappedResult;
                }
            }

            int dir;
            var yTime = (y.TimingsIndex[subMap[xFirstIndex - 1].LocationKey] as TrainLocationTimeModel).ActualTime;
            if (xFirst.ActualTime < yTime)
            {
                dir = -1;
            }
            else if (xFirst.ActualTime > yTime)
            {
                dir = 1;
            }
            else
            {
                dir = 0;
            }

            // FIXME to do this properly we then need to iterate through the full list of common times and check that the ordering remains consistent throughout.
            // If it's not consistent, we need to split the lower of the two segments into two, modifying the first chunk in-place and returning the second chunk for reinsertion.
            // However *for now* we will assume that trains do not pass each other.
            return new Tuple<int, TrainSegmentModel>(dir, null);
        }

        private Tuple<int, TrainSegmentModel> CompareWithSharedTimes(TrainSegmentModel x, TrainSegmentModel y)
        {
            // Check first common time
            int dir;
            var xFirstCommon = x.Timings.First(t => t is TrainLocationTimeModel && y.TimingsIndex.ContainsKey(t.LocationKey)) as TrainLocationTimeModel;
            var XCommonTimes = x.Timings
                .Select((t, i) => new IndexedTrainLocationTimeModel { Entry = t, Index = i })
                .Where(t => t.Model != null && y.TimingsIndex.ContainsKey(t.Model.LocationKey))
                .ToList();
            List<int> timeComparisons = new List<int>(XCommonTimes.Count);
            List<IndexedTrainLocationTimeModel> YCommonTimes = new List<IndexedTrainLocationTimeModel>();
            foreach (IndexedTrainLocationTimeModel entry in XCommonTimes)
            {
                ILocationEntry yEntry = y.TimingsIndex[entry.Entry.LocationKey];
                var yModel = new IndexedTrainLocationTimeModel { Entry = yEntry, Index = y.Timings.IndexOf(yEntry) };
                YCommonTimes.Add(yModel);
                timeComparisons.Add(TrainLocationTimeModelComparer.Default.Compare(entry.Model, yModel.Model));
            }

            if (timeComparisons.All(t => t == 0))
            {
                return new Tuple<int, TrainSegmentModel>(0, null);
            }

            List<int> differentTimeComparisons = timeComparisons.Where(t => t != 0).ToList();
            int firstDifference = differentTimeComparisons[0];
            if (differentTimeComparisons.Skip(1).All(t => t == firstDifference))
            {
                return new Tuple<int, TrainSegmentModel>(firstDifference, null);
            }

            int switchIdx = 0;
            foreach (int tc in timeComparisons.Skip(1))
            {
                if (tc != firstDifference && tc != 0)
                {
                    break;
                }
                switchIdx++;
            }

            TrainSegmentModel splitSegment;
            if (firstDifference < 0)
            {
                splitSegment = x.SplitAtIndex(XCommonTimes[switchIdx].Index);
            }
            else
            {
                splitSegment = y.SplitAtIndex(YCommonTimes[switchIdx].Index);
            }
            return new Tuple<int, TrainSegmentModel>(firstDifference, splitSegment);
        }

        private int? CompareNullChecks(TrainSegmentModel x, TrainSegmentModel y)
        {
            if (x == null)
            {
                return y == null ? 0 : -1;
            }

            if (y == null)
            {
                return 1;
            }

            return null;
        }

        private int? CompareIfTimesNotPresent(TrainSegmentModel x, TrainSegmentModel y)
        {
            if (x.Timings == null ||x.Timings.Count == 0)
            {
                if (y.Timings == null || y.Timings.Count == 0)
                {
                    return 0;
                }
                return -1;
            }
            if (y.Timings == null || y.Timings.Count == 0)
            {
                return 1;
            }

            return null;
        }
    }
}
