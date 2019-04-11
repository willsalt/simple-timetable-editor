using System.Collections.Generic;
using System.Linq;
using Timetabler.Data.Collections;
using Timetabler.Data.Events;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// The model for data displayed on a train graph.
    /// </summary>
    public class TrainGraphModel
    {
        /// <summary>
        /// The type of handler methods for the <see cref="TrainChanged"/> event.
        /// </summary>
        /// <param name="sender">The object raising the event.</param>
        /// <param name="e">The event args.</param>
        public delegate void TrainChangedEventHandler(object sender, TrainEventArgs e);

        /// <summary>
        /// Raised when a change has occurred in the contents of the <see cref="TrainList"/>.
        /// </summary>
        public event TrainChangedEventHandler TrainChanged;

        /// <summary>
        /// The locations to appear on the location axis.
        /// </summary>
        public LocationCollection LocationList { get; set; }

        /// <summary>
        /// Whether or not to display train labels on the train graph.
        /// </summary>
        public bool DisplayTrainLabels { get; set; }

        private TrainCollection _trainList;

        private int? _baseTimeSeconds;

        private int? _maxTimeSeconds;

        private Dictionary<string, double> _locationCoordinates = new Dictionary<string, double>();

        /// <summary>
        /// The trains to be displayed on the graph.
        /// </summary>
        public TrainCollection TrainList
        {
            get
            {
                return _trainList;
            }
            set
            {
                if (_trainList != null)
                {
                    RemoveTrainListEvents();
                }
                _trainList = value;
                SetTrainListEvents();
            }
        }

        private void TrainListChangeHandler(object sender, TrainEventArgs e)
        {
            OnTrainChanged(e.Train);
        }

        /// <summary>
        /// Raises the <see cref="TrainChanged"/> event.
        /// </summary>
        /// <param name="train">The train which has caused the change.</param>
        protected void OnTrainChanged(Train train)
        {
            TrainChanged?.Invoke(this, new TrainEventArgs { Train = train });
        }

        private void RemoveTrainListEvents()
        {
            _trainList.TrainAdd -= TrainListChangeHandler;
            _trainList.TrainRemove -= TrainListChangeHandler;
        }

        private void SetTrainListEvents()
        {
            _trainList.TrainAdd += TrainListChangeHandler;
            _trainList.TrainRemove += TrainListChangeHandler;
        }

        private void RecomputeTimeBase()
        {
            _baseTimeSeconds = 86400;
            _maxTimeSeconds = 0;

            foreach (Train train in TrainList)
            {
                TrainLocationTime first = train.TrainTimes.FirstOrDefault();
                if (first == null)
                {
                    continue;
                }
                if (first.ArrivalTime?.Time != null && first.ArrivalTime.Time.AbsoluteSeconds < _baseTimeSeconds)
                {
                    _baseTimeSeconds = first.ArrivalTime.Time.AbsoluteSeconds;
                }
                else if (first.DepartureTime?.Time != null && first.DepartureTime.Time.AbsoluteSeconds < _baseTimeSeconds)
                {
                    _baseTimeSeconds = first.DepartureTime.Time.AbsoluteSeconds;
                }
                TrainLocationTime last = train.TrainTimes.LastOrDefault();
                if (last.DepartureTime?.Time != null && last.DepartureTime.Time.AbsoluteSeconds > _maxTimeSeconds)
                {
                    _maxTimeSeconds = last.DepartureTime.Time.AbsoluteSeconds;
                }
                else if (last.ArrivalTime?.Time != null && last.ArrivalTime.Time.AbsoluteSeconds > _maxTimeSeconds)
                {
                    _maxTimeSeconds = last.ArrivalTime.Time.AbsoluteSeconds;
                }
            }

            // Round up/down to nearest hour
            _baseTimeSeconds = (_baseTimeSeconds / 3600) * 3600;
            _maxTimeSeconds = (_maxTimeSeconds / 3600 + 1) * 3600;
        }

        /// <summary>
        /// Generate time axis drawing information.
        /// </summary>
        /// <returns>A series of tick information objects.</returns>
        public IEnumerable<TrainGraphAxisTickInfo> GetTimeAxisInformation()
        {
            RecomputeTimeBase();

            // Assumes hourly ticks - will need changing if this ever becomes configurable.
            for (int pos = _baseTimeSeconds.Value; pos <= _maxTimeSeconds; pos += 3600)
            {
                yield return new TrainGraphAxisTickInfo(new TimeOfDay(pos).ToString("htt"), (double)(pos - _baseTimeSeconds) / (double)(_maxTimeSeconds - _baseTimeSeconds));
            }
        }

        private void RecomputeLocationCoordinates()
        {
            _locationCoordinates.Clear();
            double baseDistance = LocationList.First().Mileage.AbsoluteDistance;
            double length = LocationList.Last().Mileage.AbsoluteDistance - baseDistance;
            foreach (Location loc in LocationList)
            {
                _locationCoordinates.Add(loc.Id, (loc.Mileage.AbsoluteDistance - baseDistance) / length);
            }
        }

        /// <summary>
        /// Generate distance axis drawing information.
        /// </summary>
        /// <returns>A series of tick information objects.</returns>
        public IEnumerable<TrainGraphAxisTickInfo> GetDistanceAxisInformation()
        {
            RecomputeLocationCoordinates();

            foreach (Location loc in LocationList.Where(l => _locationCoordinates.ContainsKey(l.Id)))
            {
                yield return new TrainGraphAxisTickInfo(loc.GraphDisplayName, _locationCoordinates[loc.Id]);
            }
        }

        /// <summary>
        /// Generate train drawing information.
        /// </summary>
        /// <returns>A series of train drawing information objects containing drawing instructions.</returns>
        public IEnumerable<TrainDrawingInfo> GetTrainDrawingInformation()
        {
            RecomputeTimeBase();
            RecomputeLocationCoordinates();

            foreach (Train train in TrainList.Where(t => t.TrainTimes?.Count > 0))
            {
                TrainDrawingInfo tdi = new TrainDrawingInfo { Properties = train.GraphProperties, Headcode = train.Headcode };
                for (int i = 0; i < train.TrainTimes.Count; ++i)
                {
                    if (train.TrainTimes[i]?.ArrivalTime?.Time != null && train.TrainTimes[i]?.DepartureTime?.Time != null)
                    {
                        double locationCoordinate = _locationCoordinates[train.TrainTimes[i].Location.Id];
                        tdi.LineVertexes.Add(new LineCoordinates(GetXPositionFromTime(train.TrainTimes[i].ArrivalTime.Time), locationCoordinate,
                            GetXPositionFromTime(train.TrainTimes[i].DepartureTime.Time), locationCoordinate));
                    }
                    if (i > 0 && train.TrainTimes[i - 1]?.DepartureTime?.Time != null)
                    {
                        double startX = GetXPositionFromTime(train.TrainTimes[i - 1].DepartureTime.Time);
                        double startY = _locationCoordinates[train.TrainTimes[i - 1].Location.Id];
                        double endY = _locationCoordinates[train.TrainTimes[i].Location.Id];
                        if (train.TrainTimes[i]?.ArrivalTime?.Time != null)
                        {
                            tdi.LineVertexes.Add(new LineCoordinates(startX, startY, GetXPositionFromTime(train.TrainTimes[i].ArrivalTime.Time), endY));
                        }
                        else if (train.TrainTimes[i]?.DepartureTime?.Time != null)
                        {
                            tdi.LineVertexes.Add(new LineCoordinates(startX, startY, GetXPositionFromTime(train.TrainTimes[i].DepartureTime.Time), endY));
                        }
                    }
                }

                yield return tdi;
            }
        }

        private double GetXPositionFromTime(TimeOfDay t)
        {
            if (!_baseTimeSeconds.HasValue || !_maxTimeSeconds.HasValue)
            {
                return 0;
            }

            return (double)(t.AbsoluteSeconds - _baseTimeSeconds) / (double)(_maxTimeSeconds - _baseTimeSeconds);
        }
    }
}
