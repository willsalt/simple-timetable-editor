using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Timetabler.Data.Collections;
using Timetabler.Data.Display;

namespace Timetabler.Helpers
{
    /// <summary>
    /// Extension methods for <see cref="DataGridView"/>
    /// </summary>
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Remove all of the rows from a grid, and all of the columns above a certain index.
        /// </summary>
        /// <param name="grid">The grid to operate on.</param>
        /// <param name="clearFrom">The index of the rightmost column to retain.</param>
        public static void ClearGrid(this DataGridView grid, int clearFrom)
        {
            grid.Rows.Clear();
            while (grid.Columns.Count > clearFrom + 1)
            {
                grid.Columns.RemoveAt(clearFrom);
            }
        }

        /// <summary>
        /// Add an invisible ID row, followed by a set number of additional visible rows.
        /// </summary>
        /// <param name="grid">The grid to operate on.</param>
        /// <param name="count">The number of visible rows to add.</param>
        public static void AddStartingRows(this DataGridView grid, int count)
        {
            grid.Rows.Add(new DataGridViewRow { Visible = false });
            grid.Rows.Add(count);
        }

        /// <summary>
        /// Add a column for each train segment given, and populate the header rows of each column.
        /// </summary>
        /// <param name="grid">The grid to operate on.</param>
        /// <param name="segments">The segments to add columns for.</param>
        /// <param name="idRowIdx">The index of the row to populate with train ID strings.</param>
        /// <param name="diagramRowIdx">The index of the row to populate with the train diagram codes.</param>
        /// <param name="locoDiagramRowIdx">The index of the row to populate with the loco diagram codes, or null if no such row should be populated.</param>
        /// <param name="amPmRowIdx">The index of the row to populate with whether or not the first time is in the morning or afternoon.</param>
        /// <param name="classRowIdx">The index of the row to populate with the train class.</param>
        /// <param name="footnoteRowIdx">The index of the row to populate with the train's footnotes.</param>
        public static void AddColumnsForSegments(this DataGridView grid, IEnumerable<TrainSegmentModel> segments, int idRowIdx, int diagramRowIdx, int? locoDiagramRowIdx, int amPmRowIdx, int classRowIdx, int footnoteRowIdx)
        {
            foreach (var seg in segments)
            {
                int idx = grid.Columns.Add(new DataGridViewTextBoxColumn { DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleCenter } });
                grid[idx, idRowIdx].Value = seg.TrainId;
                grid[idx, diagramRowIdx].Value = seg.Headcode;
                grid[idx, amPmRowIdx].Value = seg.HalfOfDay;
                grid[idx, classRowIdx].Value = seg.TrainClass;
                grid[idx, footnoteRowIdx].Value = seg.Footnotes;
                if (locoDiagramRowIdx.HasValue)
                {
                    grid[idx, locoDiagramRowIdx.Value].Value = seg.LocoDiagram;
                }
            }
        }

        /// <summary>
        /// Populate a grid with location rows and train details.  The grid must have at least as many columns as there are trains.
        /// </summary>
        /// <param name="grid">The grid to populate.</param>
        /// <param name="locations">The list of location display rows.</param>
        /// <param name="segments">The list of train column segments</param>
        /// <param name="locationIdColIdx">The index of the location ID code column.</param>
        /// <param name="locationNameColIdx">The index of the location name column.</param>
        /// <param name="locationADSymColIdx">The index of the row arrival/departure symbol column.</param>
        /// <param name="stoppingFont">The font to display stopping times in.</param>
        /// <param name="passingFont">The font to display passing times in.</param>
        /// <exception cref="InvalidOperationException">Thrown if the grid does not contain enough columns to display the number of train segments passed in.</exception>
        public static void AddAndPopulateLocationRows(this DataGridView grid, IEnumerable<LocationDisplayModel> locations, TrainSegmentModelCollection segments, int locationIdColIdx, 
            int locationNameColIdx, int locationADSymColIdx, Font stoppingFont, Font passingFont)
        {
            ColumnCountCheck(grid, locationADSymColIdx, segments.Count);
            foreach (var loc in locations)
            {
                int idx = grid.Rows.Add();
                grid[locationIdColIdx, idx].Value = loc.LocationKey;
                grid[locationNameColIdx, idx].Value = loc.EditorDisplayName;
                grid[locationADSymColIdx, idx].Value = loc.ArrivalDepartureLabel;
                for (int i = 0; i < segments.Count; ++i)
                {
                    if (segments[i].TimingsIndex.ContainsKey(loc.LocationKey))
                    {
                        grid[locationADSymColIdx + i + 1, idx].Value = segments[i].TimingsIndex[loc.LocationKey].DisplayedText;
                        var tltm = segments[i].TimingsIndex[loc.LocationKey] as TrainLocationTimeModel;
                        if (tltm != null && !tltm.IsPassingTime)
                        {
                            grid[locationADSymColIdx + i + 1, idx].Style.Font = stoppingFont;
                        }
                        else
                        {
                            grid[locationADSymColIdx + i + 1, idx].Style.Font = passingFont;
                        }
                    }
                }
            }
        }

        private static void ColumnCountCheck(DataGridView grid, int locationADSymColIdx, int segmentCount)
        {
            if (grid.ColumnCount <= locationADSymColIdx + segmentCount)
            {
                throw new InvalidOperationException(string.Format("This grid does not have enough columns for the number of trains ({0}/{2}+{1})", grid.ColumnCount, segmentCount,
                    locationADSymColIdx));
            }
        }

        /// <summary>
        /// Add the "To Work" timetable row to a data grid.
        /// </summary>
        /// <param name="grid">The <see cref="DataGridView"/> to add the row to.</param>
        /// <param name="segments">The train segments which contain the data to be added.</param>
        /// <param name="locationNameColIdx"></param>
        /// <param name="locationADSymColIdx"></param>
        /// <param name="toWorkFont"></param>
        public static void AddAndPopulateToWorkRow(this DataGridView grid, TrainSegmentModelCollection segments, int locationNameColIdx, int locationADSymColIdx, Font toWorkFont)
        {
            ColumnCountCheck(grid, locationADSymColIdx, segments.Count);
            int rowIdx = grid.Rows.Add();
            grid[locationNameColIdx, rowIdx].Value = Resources.MainForm_TimetableGridView_ToWorkRowName;
            for (int i = 0; i < segments.Count; ++i)
            {
                if (segments[i].ToWorkCell != null && !string.IsNullOrWhiteSpace(segments[i].ToWorkCell.DisplayedText))
                {
                    grid[locationADSymColIdx + i + 1, rowIdx].Value = segments[i].ToWorkCell.DisplayedText;
                    grid[locationADSymColIdx + i + 1, rowIdx].Style.Font = toWorkFont;
                }
            }
        }
    }
}
