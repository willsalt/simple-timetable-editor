using NLog;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Timetabler.CoreData;
using Timetabler.Data.Collections;
using Timetabler.Data.Display;
using Timetabler.Data.Events;

namespace Timetabler.Data
{
    /// <summary>
    /// This class is the top-level document container which is serialised to save a file.  It also contains methods for manipulating the contents of the document and updating the on-screen display
    /// appropriately.
    /// </summary>
    public class TimetableDocument
    {
        private int _version;

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Document file format version number.
        /// </summary>
        public int Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
                OnTimetableDocumentChanged();
            }
        }

        /// <summary>
        /// The filename that this document was loaded from or last saved to.
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// Document-level settings.
        /// </summary>
        public DocumentOptions Options { get; set; }

        /// <summary>
        /// Export-specific settings.
        /// </summary>
        public DocumentExportOptions ExportOptions { get; set; }

        private string _title;

        /// <summary>
        /// Timetable title.
        /// </summary>
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnTimetableDocumentChanged();
            }
        }

        private string _subtitle;

        /// <summary>
        /// Timetable subtitle.
        /// </summary>
        public string Subtitle
        {
            get
            {
                return _subtitle;
            }
            set
            {
                _subtitle = value;
                OnTimetableDocumentChanged();
            }
        }

        private string _dateDescription;

        /// <summary>
        /// Timetable date range description, such as "Sunday" or "Table C".
        /// </summary>
        public string DateDescription
        {
            get
            {
                return _dateDescription;
            }
            set
            {
                _dateDescription = value;
                OnTimetableDocumentChanged();
            }
        }

        private string _writtenBy;

        /// <summary>
        /// Nmae/initials of the writer
        /// </summary>
        public string WrittenBy
        {
            get
            {
                return _writtenBy;
            }
            set
            {
                _writtenBy = value;
                OnTimetableDocumentChanged();
            }
        }

        private string _checkedBy;

        /// <summary>
        /// Name/initials of the proofer
        /// </summary>
        public string CheckedBy
        {
            get
            {
                return _checkedBy;
            }
            set
            {
                _checkedBy = value;
                OnTimetableDocumentChanged();
            }
        }

        private string _timetableVersion;

        /// <summary>
        /// Content version
        /// </summary>
        public string TimetableVersion
        {
            get
            {
                return _timetableVersion;
            }
            set
            {
                _timetableVersion = value;
                OnTimetableDocumentChanged();
            }
        }

        private string _publishedDate;

        /// <summary>
        /// Date/place of publication
        /// </summary>
        public string PublishedDate
        {
            get
            {
                return _publishedDate;
            }
            set
            {
                _publishedDate = value;
                OnTimetableDocumentChanged();
            }
        }

        /// <summary>
        /// List of locations used in these timetables.
        /// </summary>
        public LocationCollection LocationList { get; private set; }

        /// <summary>
        /// The signalboxes in this timetable, for which we will want to specify hours.
        /// </summary>
        public SignalboxCollection Signalboxes { get; private set; }

        private void SignalboxChangedHandler(object sender, SignalboxEventArgs e)
        {
            OnTimetableDocumentChanged();
        }

        private void SignalboxHoursSetChangedHandler(object sender, SignalboxHoursSetEventArgs eventArgs)
        {
            OnTimetableDocumentChanged();
        }

        /// <summary>
        /// The collection of potential signalbox opening hours associated with this timetable.
        /// </summary>
        public SignalboxHoursSetCollection SignalboxHoursSets { get; private set; }

        /// <summary>
        /// Footnotes used in these timetables.
        /// </summary>
        public NoteCollection NoteDefinitions { get; private set; }

        /// <summary>
        /// The train classes used in these timetables.
        /// </summary>
        public TrainClassCollection TrainClassList { get; private set; }

        /// <summary>
        /// The trains in this timetable.
        /// </summary>
        public TrainCollection TrainList { get; private set; }

        /// <summary>
        /// The Down train segments in this timetable as formatted for display.
        /// </summary>
        public TimetableSectionModel DownTrainsDisplay { get; private set; }

        /// <summary>
        /// The Up train segments in this timetable as formatted for display.
        /// </summary>
        public TimetableSectionModel UpTrainsDisplay { get; private set; }

        /// <summary>
        /// The type of event handler delegate for the <see cref="TimetableDocumentChanged"/> event.
        /// </summary>
        /// <param name="sender">The object raising the event.</param>
        /// <param name="e">The event arguments (not used).</param>
        public delegate void TimetableDocumentChangedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Raised on changes to the document content..
        /// </summary>
        public event TimetableDocumentChangedEventHandler TimetableDocumentChanged;

        /// <summary>
        /// Default constructor - sets the version number and creates empty objects for deep properties.
        /// </summary>
        public TimetableDocument()
        {
            Version = 2;

            TrainClassList = new TrainClassCollection();
            TrainClassList.TrainClassAdd += TrainClassChangedHandler;
            TrainClassList.TrainClassRemove -= TrainClassChangedHandler;
            TrainList = new TrainCollection();
            TrainList.TrainAdd += TrainAddHandler;
            TrainList.TrainRemove += TrainRemoveHandler;
            LocationList = new LocationCollection();
            LocationList.LocationAdd += LocationChangedHandler;
            LocationList.LocationRemove += LocationChangedHandler;
            DownTrainsDisplay = new TimetableSectionModel(Direction.Down, LocationList);
            UpTrainsDisplay = new TimetableSectionModel(Direction.Up, LocationList);
            Signalboxes = new SignalboxCollection();
            Signalboxes.SignalboxAdd += SignalboxChangedHandler;
            Signalboxes.SignalboxRemove += SignalboxChangedHandler;
            SignalboxHoursSets = new SignalboxHoursSetCollection();
            SignalboxHoursSets.SignalboxHoursSetAdd += SignalboxHoursSetChangedHandler;
            SignalboxHoursSets.SignalboxHoursSetRemove += SignalboxHoursSetChangedHandler;
            Options = new DocumentOptions();
            NoteDefinitions = new NoteCollection();
            NoteDefinitions.NoteAdd += NoteChangedHandler;
            NoteDefinitions.NoteRemove += NoteChangedHandler;
            ExportOptions = new DocumentExportOptions();
        }

        

        private void TrainAddHandler(object sender, TrainEventArgs e)
        {
            ProcessTrain(e.Train);
            OnTimetableDocumentChanged();
        }

        private void TrainRemoveHandler(object sender, TrainEventArgs e)
        {
            if (DownTrainsDisplay.TrainSegments.RemoveAll(s => s.TrainId == e.Train.Id) > 0)
            {
                DownTrainsDisplay.CleanLocations();
            }
            if (UpTrainsDisplay.TrainSegments.RemoveAll(s => s.TrainId == e.Train.Id) > 0)
            {
                UpTrainsDisplay.CleanLocations();
            }
            OnTimetableDocumentChanged();
        }

        private void NoteChangedHandler(object sender, NoteEventArgs e)
        {
            OnTimetableDocumentChanged();
        }

        private void TrainClassChangedHandler(object sender, TrainClassEventArgs e)
        {
            OnTimetableDocumentChanged();
        }

        private void LocationChangedHandler(object sender, LocationEventArgs e)
        {
            OnTimetableDocumentChanged();
        }

        /// <summary>
        /// Raises the <see cref="TimetableDocumentChanged"/> event.
        /// </summary>
        protected void OnTimetableDocumentChanged()
        {
            TimetableDocumentChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// This method is to be called after deserialisation.  Where a child object contains both a reference property and a string property containing the ID of the object the reference 
        /// property should refer to, this method tries to populate the reference property with the object referred to by the ID property, if possible.
        /// </summary>
        public void ResolveAll()
        {
            Dictionary<string, Location> map = LocationList.ToDictionary(l => l.Id);
            Dictionary<string, TrainClass> trainClasses = TrainClassList.ToDictionary(c => c.Id);
            Dictionary<string, Note> footnotes = NoteDefinitions.ToDictionary(n => n.Id);
            foreach (var train in TrainList)
            {
                train.ResolveTrainClass(trainClasses);
                train.ResolveFootnotes(footnotes);
                foreach (var time in train.TrainTimes)
                {
                    time.ResolveAll(map, footnotes);
                }
            }
        }

        private static IEnumerable<FootnoteDisplayModel> GetFootnotesForTimingPoint(TrainLocationTime timingPoint)
        {
            List<FootnoteDisplayModel> footnotes = new List<FootnoteDisplayModel>();
            if (timingPoint.ArrivalTime != null)
            {
                footnotes.AddRange(GetFootnotesForTrainTime(timingPoint.ArrivalTime));
            }
            if (timingPoint.DepartureTime != null)
            {
                footnotes.AddRange(GetFootnotesForTrainTime(timingPoint.DepartureTime));
            }

            return footnotes;
        }

        private static IEnumerable<FootnoteDisplayModel> GetFootnotesForTrainTime(TrainTime time)
        {
            if (time.Footnotes == null)
            {
                return Array.Empty<FootnoteDisplayModel>();
            }
            return time.Footnotes.Select(f => f.ToFootnoteDisplayModel());
        }

        private void SetToWorkCellValue(GenericTimeModel toWorkModel)
        {
            if (toWorkModel == null)
            {
                return;
            }
            if (toWorkModel.ActualTime != null)
            {
                toWorkModel.DisplayedText = toWorkModel.ActualTime.ToString(Options.FormattingStrings.TimeWithoutFootnotes, CultureInfo.CurrentCulture);
            }
        }

        private void ProcessTrain(Train train)
        {
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_ProcessTrain, train.Id);

            TrainSegmentModel currentSegment = new TrainSegmentModel(train, null);
            SetToWorkCellValue(currentSegment.ToWorkCell);
            SetToWorkCellValue(currentSegment.LocoToWorkCell);

            Direction? currentDirection = null;
            currentSegment.PageFootnotes.AddRange(GetFootnotesForTimingPoint(train.TrainTimes[0]));
            if (!string.IsNullOrWhiteSpace(train.TrainTimes[0].Path))
            {
                LocationEntryModel lem = new LocationEntryModel
                {
                    DisplayedText = train.TrainTimes[0].Path,
                    EntryType = TrainLocationTimeEntryType.RoutingCode,
                    LocationId = train.TrainTimes[0].Location.Id,
                    LocationKey = train.TrainTimes[0].Location.Id + LocationIdSuffixes.Path,
                };
                currentSegment.Timings.Add(lem);
                currentSegment.TimingsIndex.Add(lem.LocationKey, lem);
            }
            if (train.TrainTimes[0].ArrivalTime?.Time != null)
            {
                var timeModel = train.TrainTimes[0].ArrivalTimeModel;
                currentSegment.Timings.Add(timeModel);
                currentSegment.TimingsIndex.Add(train.TrainTimes[0].Location.Id + LocationIdSuffixes.Arrival, timeModel);
            }
            if (!string.IsNullOrWhiteSpace(train.TrainTimes[0].Platform))
            {
                LocationEntryModel lem = new LocationEntryModel
                {
                    DisplayedText = train.TrainTimes[0].Platform,
                    EntryType = TrainLocationTimeEntryType.RoutingCode,
                    LocationId = train.TrainTimes[0].Location.Id,
                    LocationKey = train.TrainTimes[0].Location.Id + LocationIdSuffixes.Platform,
                };
                currentSegment.Timings.Add(lem);
                currentSegment.TimingsIndex.Add(lem.LocationKey, lem);
            }
            if (train.TrainTimes[0].DepartureTime?.Time != null)
            {
                var timeModel = train.TrainTimes[0].DepartureTimeModel;
                currentSegment.Timings.Add(timeModel);
                currentSegment.TimingsIndex.Add(train.TrainTimes[0].Location.Id + LocationIdSuffixes.Departure, timeModel);
            }
            if (!string.IsNullOrWhiteSpace(train.TrainTimes[0].Line))
            {
                LocationEntryModel lem = new LocationEntryModel
                {
                    DisplayedText = train.TrainTimes[0].Line,
                    EntryType = TrainLocationTimeEntryType.RoutingCode,
                    LocationId = train.TrainTimes[0].Location.Id,
                    LocationKey = train.TrainTimes[0].Location.Id + LocationIdSuffixes.Line,
                };
                currentSegment.Timings.Add(lem);
                currentSegment.TimingsIndex.Add(lem.LocationKey, lem);
            }
            for (int i = 1; i < train.TrainTimes.Count; ++i)
            {
                Direction newDirection = train.TrainTimes[i].Location > train.TrainTimes[i - 1].Location ? Direction.Down : Direction.Up;
                if (currentDirection == null)
                {
                    currentDirection = newDirection;
                }
                else if (currentDirection != newDirection)
                {
                    if (currentDirection == Direction.Down)
                    {
                        DownTrainsDisplay.Add(currentSegment);
                    }
                    else
                    {
                        UpTrainsDisplay.Add(currentSegment);
                    }
                    currentSegment = new TrainSegmentModel(train, null);
                    currentDirection = newDirection;
                }
                currentSegment.PageFootnotes.AddRange(GetFootnotesForTimingPoint(train.TrainTimes[i]));
                if (!string.IsNullOrWhiteSpace(train.TrainTimes[i].Path))
                {
                    LocationEntryModel lem = new LocationEntryModel
                    {
                        DisplayedText = train.TrainTimes[i].Path,
                        EntryType = TrainLocationTimeEntryType.RoutingCode,
                        LocationId = train.TrainTimes[i].Location.Id,
                        LocationKey = train.TrainTimes[i].Location.Id + LocationIdSuffixes.Path,
                    };
                    currentSegment.Timings.Add(lem);
                    currentSegment.TimingsIndex.Add(lem.LocationKey, lem);
                }
                if (train.TrainTimes[i].ArrivalTime?.Time != null)
                {
                    var timeModel = train.TrainTimes[i].ArrivalTimeModel;
                    currentSegment.Timings.Add(timeModel);
                    currentSegment.TimingsIndex.Add(train.TrainTimes[i].Location.Id + LocationIdSuffixes.Arrival, timeModel);
                }
                if (!string.IsNullOrWhiteSpace(train.TrainTimes[i].Platform))
                {
                    LocationEntryModel lem = new LocationEntryModel
                    {
                        DisplayedText = train.TrainTimes[i].Platform,
                        EntryType = TrainLocationTimeEntryType.RoutingCode,
                        LocationId = train.TrainTimes[i].Location.Id,
                        LocationKey = train.TrainTimes[i].Location.Id + LocationIdSuffixes.Platform,
                    };
                    currentSegment.Timings.Add(lem);
                    currentSegment.TimingsIndex.Add(lem.LocationKey, lem);
                }
                if (train.TrainTimes[i].DepartureTime?.Time != null)
                {
                    var timeModel = train.TrainTimes[i].DepartureTimeModel;
                    currentSegment.Timings.Add(timeModel);
                    currentSegment.TimingsIndex.Add(train.TrainTimes[i].Location.Id + LocationIdSuffixes.Departure, timeModel);
                }
                if (!string.IsNullOrWhiteSpace(train.TrainTimes[i].Line))
                {
                    LocationEntryModel lem = new LocationEntryModel
                    {
                        DisplayedText = train.TrainTimes[i].Line,
                        EntryType = TrainLocationTimeEntryType.RoutingCode,
                        LocationId = train.TrainTimes[i].Location.Id,
                        LocationKey = train.TrainTimes[i].Location.Id + LocationIdSuffixes.Line,
                    };
                    currentSegment.Timings.Add(lem);
                    currentSegment.TimingsIndex.Add(lem.LocationKey, lem);
                }
            }
            if (currentDirection == Direction.Down)
            {
                DownTrainsDisplay.Add(currentSegment);
            }
            else
            {
                UpTrainsDisplay.Add(currentSegment);
            }
        }

        private enum TimeDisplayFormatType
        {
            WithFootnoteSpace,
            Plain
        }

        /// <summary>
        /// Refresh the displayed values of all train segments, without doing a full reload of the grid contents.  This should be called if anything has happened which changes what should
        /// be displayed on-screen for a large number of trains, but that does not affect what train segments are displayed in the grid or their ordering - for example, if the document
        /// clock type is changed.
        /// </summary>
        public void RefreshTrainDisplayFormatting()
        {
            Dictionary<string, Train> trainIndex = new Dictionary<string, Train>(TrainList.Count);
            foreach (var train in TrainList)
            {
                trainIndex.Add(train.Id, train);
                train.RefreshTimingPointModels();
            }
            foreach (var trainSegment in DownTrainsDisplay.TrainSegments)
            {
                trainSegment.UpdatePageFootnotes(NoteDefinitions);
                SetToWorkCellValue(trainSegment.LocoToWorkCell);
                SetToWorkCellValue(trainSegment.ToWorkCell);
            }
            foreach (var trainSegment in UpTrainsDisplay.TrainSegments)
            {
                trainSegment.UpdatePageFootnotes(NoteDefinitions);
                SetToWorkCellValue(trainSegment.LocoToWorkCell);
                SetToWorkCellValue(trainSegment.ToWorkCell);
            }
        }

        /// <summary>
        /// Update the display models with all trains in the document.
        /// </summary>
        public void UpdateTrainDisplays()
        {
            DownTrainsDisplay.TrainSegments.Clear();
            DownTrainsDisplay.CleanLocations();
            UpTrainsDisplay.TrainSegments.Clear();
            UpTrainsDisplay.CleanLocations();
            foreach (var train in TrainList)
            {
                ProcessTrain(train);
            }
        }
    }
}
