using NLog;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Timetabler.Data.Display;
using Timetabler.Data.Events;
using Timetabler.Helpers;

namespace Timetabler.Adapters
{
    /// <summary>
    /// Glue class for connecting a <see cref="TimetableSectionModel" /> instance to a <see cref="DataGridView" /> instance.  
    /// </summary>
    public class TimetableSectionModelDataAdapter
    {
        /// <summary>
        /// The data model.
        /// </summary>
        public TimetableSectionModel Model { get; private set; }

        /// <summary>
        /// The view.
        /// </summary>
        public DataGridView View { get; private set; }

        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        // Fixed column indexes
        private const int _locationIdColIdx = 0;
        private const int _locationNameColIdx = 1;
        private const int _locationArrivalDepartureSymbolColIdx = 2;

        // The column index of the first train column in the view.
        private const int _trainColumnIdxBase = 3;

        // Fixed row indexes
        private const int _trainIdRowIdx = 0;
        private const int _trainDiagramRowIdx = 1;
        private const int _trainToWorkRowIdx = -1; // This index is from the end, not the start.

        // Varying row indexes
        private int? _trainLocoDiagramRowIdx = null;
        private int? _trainLocoToWorkRowIdx = null;
        private int _trainFootnotesRowIdx = 2;
        
        private int TrainClassRowIdx { get { return _trainFootnotesRowIdx + 1; } }
        
        private int TrainAmPmRowIdx { get { return _trainFootnotesRowIdx + 2; } }
        
        private int StartingRowCount { get { return TrainAmPmRowIdx; } }
        
        private int LocationRowIdxBase { get { return TrainAmPmRowIdx + 1; } }

        private static readonly Font _stoppingFont = new Font("Cambria", 8f, FontStyle.Bold);
        private static readonly Font _passingFont = new Font("Cambria", 8f);

        private const string ContinuedFromEarlier = "<<<";
        private const string ContinuesLater = ">>>";

        private DataGridViewAutoSizeColumnsMode _newColumnAutoSizeColumnMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        private DataGridViewAutoSizeRowsMode _newRowAutoSizeRowMode = DataGridViewAutoSizeRowsMode.DisplayedCells;

        /// <summary>
        /// Constructor which sets read-only properties.
        /// </summary>
        /// <param name="model">The data model.</param>
        /// <param name="view">The view.</param>
        public TimetableSectionModelDataAdapter(TimetableSectionModel model, DataGridView view)
        {
            Model = model ?? throw new ArgumentNullException(nameof(model));
            View = view ?? throw new ArgumentNullException(nameof(view));

            Model.TrainSegments.TrainSegmentModelAdd += SegmentAdded;
            Model.TrainSegments.TrainSegmentModelRemove += SegmentRemoved;
            Model.Locations.LocationDisplayModelAdd += LocationAdded;
            Model.Locations.LocationDisplayModelRemove += LocationRemoved;

            SetGridLayoutMode(GridLayoutMode.Frozen);
            InitialiseView();
            PopulateInitialData();
            SetGridLayoutMode(GridLayoutMode.Automatic);
        }

        /// <summary>
        /// Set whether or not the grid which this adapter is linked to should automatically resize itself.
        /// </summary>
        /// <param name="mode">Whether or not the grid should automatically resize itself.</param>
        public void SetGridLayoutMode(GridLayoutMode mode)
        {
            switch (mode)
            {
                case GridLayoutMode.Automatic:
                default:
                    _newColumnAutoSizeColumnMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                    _newRowAutoSizeRowMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
                    break;
                case GridLayoutMode.Frozen:
                    _newColumnAutoSizeColumnMode = DataGridViewAutoSizeColumnsMode.None;
                    _newRowAutoSizeRowMode = DataGridViewAutoSizeRowsMode.None;
                    break;
            }

            ResetAllColumnAutoSizeModes();
        }

        private void ResetAllColumnAutoSizeModes()
        {
            View.AutoSizeColumnsMode = _newColumnAutoSizeColumnMode;
            View.AutoSizeRowsMode = _newRowAutoSizeRowMode;
        }

        private void PopulateInitialData()
        {
            for (int i = 0; i < Model.Locations.Count; ++i)
            {
                InsertLocationRow(i + LocationRowIdxBase, Model.Locations[i]);
            }
            for (int i = 0; i < Model.TrainSegments.Count; ++i)
            {
                InsertTrainColumn(i + _trainColumnIdxBase, Model.TrainSegments[i]);
            }
        }

        private void LocationRemoved(object sender, LocationDisplayModelEventArgs e)
        {
            if (e?.Index == null)
            {
                return;
            }
            View.Rows.RemoveAt(e.Index.Value + LocationRowIdxBase);
        }

        private void LocationAdded(object sender, LocationDisplayModelEventArgs e)
        {
            if (e?.Index == null || e?.Model == null)
            {
                return;
            }
            InsertLocationRow(e.Index.Value + LocationRowIdxBase, e.Model);
        }

        private void InsertLocationRow(int rowIdx, LocationDisplayModel model)
        {
            if (View.Rows.Count == 0)
            {
                InitialiseView();
            }
            View.Rows.Insert(rowIdx, View.RowTemplate.Clone());
            View[_locationIdColIdx, rowIdx].Value = model.LocationKey;
            View[_locationNameColIdx, rowIdx].Value = model.EditorDisplayName;
            View[_locationArrivalDepartureSymbolColIdx, rowIdx].Value = model.ArrivalDepartureLabel;
        }


        private void SegmentRemoved(object sender, TrainSegmentModelEventArgs e)
        {
            if (e.Index.HasValue)
            {
                View.Columns.RemoveAt(e.Index.Value + _trainColumnIdxBase);
            }
        }

        private void SegmentAdded(object sender, TrainSegmentModelEventArgs e)
        {
            if (e?.Index == null || e?.Model == null)
            {
                return;
            }
            InsertTrainColumn(e.Index.Value + _trainColumnIdxBase, e.Model);
        }

        private void InsertTrainColumn(int idx, TrainSegmentModel segment)
        {
            Log.Trace("Inserting column for {0} at {1}", segment.TrainId, idx);

            if (View.Rows.Count == 0)
            {
                InitialiseView();
            }

            if (!string.IsNullOrWhiteSpace(segment.LocoDiagram))
            {
                CheckAndInsertLocoDiagramRow();
            }
            if (!string.IsNullOrWhiteSpace(segment.LocoToWorkCell?.DisplayedText))
            {
                CheckAndInsertLocoToWorkRow();
            }
            View.Columns.Insert(idx, new DataGridViewTextBoxColumn
            {
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter },
            });
            View[idx, _trainIdRowIdx].Value = segment.TrainId;
            View[idx, _trainDiagramRowIdx].Value = segment.Headcode;
            View[idx, TrainAmPmRowIdx].Value = segment.HalfOfDay;
            View[idx, TrainClassRowIdx].Value = segment.TrainClass;
            View[idx, _trainFootnotesRowIdx].Value = segment.Footnotes;
            if (segment.ToWorkCell != null)
            {
                segment.ToWorkCell.DisplayAdapter = new LocationEntryDisplayAdapter { Cell = View[idx, View.Rows.Count + _trainToWorkRowIdx] };
            }
            if (_trainLocoDiagramRowIdx.HasValue)
            {
                View[idx, _trainLocoDiagramRowIdx.Value].Value = segment.LocoDiagram;
            }
            if (_trainLocoToWorkRowIdx.HasValue && segment.LocoToWorkCell != null)
            {
                segment.LocoToWorkCell.DisplayAdapter = new LocationEntryDisplayAdapter { Cell = View[idx, View.Rows.Count + _trainLocoToWorkRowIdx.Value] };
            }

            int firstLocationIndex = -1;
            int lastLocationIndex = -1;
            for (int i = 0; i < Model.Locations.Count; ++i)
            {
                if (segment.TimingsIndex.ContainsKey(Model.Locations[i].LocationKey))
                {
                    if (firstLocationIndex < 0)
                    {
                        firstLocationIndex = i;
                    }
                    lastLocationIndex = i;
                    segment.TimingsIndex[Model.Locations[i].LocationKey].DisplayAdapter = new LocationEntryDisplayAdapter { Cell = View[idx, LocationRowIdxBase + i] };
                    if (segment.TimingsIndex[Model.Locations[i].LocationKey] is TrainLocationTimeModel tltm && !tltm.IsPassingTime)
                    {
                        View[idx, LocationRowIdxBase + i].Style.Font = _stoppingFont;
                    }
                    else
                    {
                        View[idx, LocationRowIdxBase + i].Style.Font = _passingFont;
                    }
                }
            }

            if (segment.ContinuationFromEarlier && LocationRowIdxBase + firstLocationIndex > 0)
            {
                View[idx, LocationRowIdxBase + firstLocationIndex - 1].Value = ContinuedFromEarlier;
            }
            if (segment.ContinuesLater && LocationRowIdxBase + lastLocationIndex < View.RowCount)
            {
                View[idx, LocationRowIdxBase + lastLocationIndex + 1].Value = ContinuesLater;
            }
        }

        private void CheckAndInsertLocoDiagramRow()
        {
            if (_trainLocoDiagramRowIdx.HasValue)
            {
                return;
            }
            int idx = _trainFootnotesRowIdx++;
            View.Rows.Insert(idx, View.RowTemplate.Clone());
            _trainLocoDiagramRowIdx = idx;
        }

        private void CheckAndInsertLocoToWorkRow()
        {
            if (_trainLocoToWorkRowIdx.HasValue)
            {
                return;
            }
            int idx = -2;
            View.Rows.Insert(View.Rows.Count + idx + 1, View.RowTemplate.Clone());
            _trainLocoToWorkRowIdx = idx;
            View[_locationNameColIdx, View.Rows.Count + idx].Value = Resources.MainForm_TimetableGridView_LocoToWorkRowName;
            View[_locationNameColIdx, View.Rows.Count + _trainToWorkRowIdx].Value = Resources.MainForm_TimetableGridView_SetToWorkRowName;
        }

        /// <summary>
        /// Clear the grid and add the initial rows.
        /// </summary>
        public void InitialiseView()
        {
            View.ClearGrid(_locationArrivalDepartureSymbolColIdx);
            if (Model.TrainSegments.Count > 0 || Model.Locations.Count > 0)
            {
                View.AddStartingRows(StartingRowCount + 1); // _startingRowCount is the number of rows in the header; we also add one for the To Work row in the footer.
                View[_locationNameColIdx, View.Rows.Count + _trainToWorkRowIdx].Value = Resources.MainForm_TimetableGridView_ToWorkRowName;
            }
        }

        /// <summary>
        /// Given a column, return the ID of the train with a segment in that column.
        /// </summary>
        /// <param name="columnIdx">The index of the column to look up the train ID for.</param>
        /// <returns>null if the column index parameter is not the index of a train segment column; the ID of the relevant train otherwise.</returns>
        public string GetTrainIdForViewColumn(int columnIdx)
        {
            if (columnIdx < _trainColumnIdxBase)
            {
                return null;
            }
            if (columnIdx >= View.Columns.Count)
            {
                return null;
            }
            return View[columnIdx, _trainIdRowIdx].Value as string;
        }

        /// <summary>
        /// Determines whether or not a column in the view contains a train segment.
        /// </summary>
        /// <param name="columnIdx">The index of the column to check.</param>
        /// <returns>True if the column exists and contains a train segment; false if the column does not exist or does not contain a train segment.</returns>
        public bool IsColumnTrainColumn(int columnIdx)
        {
            if (columnIdx < _trainColumnIdxBase)
            {
                Log.Trace("Column {0} is lower than base column {1}", columnIdx, _trainColumnIdxBase);
                return false;
            }

            if (columnIdx >= View.Columns.Count)
            {
                Log.Warn("Apparent column {0} is too high to be valid.  Grid column count: {1}", columnIdx, View.Columns.Count);
                return false;
            }

            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_ColumnIsATrainColumn, columnIdx);
            return true;
        }
    }
}
