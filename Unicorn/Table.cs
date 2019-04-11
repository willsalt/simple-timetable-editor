using System.Collections.Generic;
using System.Linq;
using Unicorn.Interfaces;

namespace Unicorn
{
    /// <summary>
    /// A table with uniform rows and columns.
    /// </summary>
    public class Table : IDrawable
    {
        private List<TableRow> _rows;
        private List<TableColumn> _columns;

        /// <summary>
        /// Style to use when drawing table gridlines.
        /// </summary>
        public TableRuleStyle RuleStyle { get; set; }

        /// <summary>
        /// If a TableRuleStyle whose lines do not meet is selected, how large a gap will be left between lines.
        /// </summary>
        public double RuleGapSize { get; set; }

        /// <summary>
        /// Width of the table's lines.
        /// </summary>
        public double RuleWidth { get; set; }

        /// <summary>
        /// The width of the entire table when drawn.
        /// </summary>
        public double ComputedWidth
        {
            get
            {
                if (_rows.Count == 0)
                {
                    return 0;
                }
                return _rows.First(r => r != null).ComputedWidth;
            }
        }

        /// <summary>
        /// The height of this table when drawn.
        /// </summary>
        public double ComputedHeight
        {
            get
            {
                if (_columns.Count == 0)
                {
                    return 0;
                }
                return _columns.First(c => c != null).ComputedHeight;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Table()
        {
            _rows = new List<TableRow>();
            _columns = new List<TableColumn>();
            RuleWidth = 1.0;
        }

        /// <summary>
        /// Gets the row at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the row to get.</param>
        /// <returns>The row at the specified index.</returns>
        public TableRow this[int index]
        {
            get
            {
                return _rows[index];
            }
        }

        /// <summary>
        /// Add a <see cref="TableRow"/> to the table.
        /// </summary>
        /// <param name="row">The row to add to the table.</param>
        /// <remarks>If the added row contains more cells than the rows currently in the table, the rows currently in the table are padded on the right with null cells until they are the same
        /// width as the new row.  If the added row contains fewer cells than the rows currently in the table, it is padded on the right until it is the same with as the other rows.</remarks>
        public void AddRow(TableRow row)
        {
            // Make sure table is wide enough for the new row
            while (row.Count > _columns.Count)
            {
                _columns.Add(new TableColumn());
                for (int i = 0; i < _rows.Count; ++i)
                {
                    _columns[_columns.Count - 1].Add(null);
                }
            }

            _rows.Add(row);
            for (int i = 0; i < row.Count; ++i)
            {
                _columns[i].Add(row[i]);
            }
            for (int i = row.Count; i < _columns.Count; ++i)
            {
                _columns[i].Add(null);
            }
        }

        /// <summary>
        /// Add a row to the table, consisting of a list of cells.
        /// </summary>
        /// <param name="rowContents">The cells to add to the table.</param>
        /// <remarks>This method adds a new row to the table, consisting of a range of cells.  The cells are added to columns starting with column 0.  If there are fewer cells than columns,
        /// the new row is padded with null cells on the right.  If there are more cells than columns, the existing rows in the table are passed with null cells on the right.</remarks>
        public void AddRow(IEnumerable<TableCell> rowContents)
        {
            TableRow row = new TableRow();
            row.AddRange(rowContents);
            AddRow(row);
        }

        /// <summary>
        /// Add a row to the table, consisting of a list of cells.
        /// </summary>
        /// <param name="rowContents">The cels to add to the table.</param>
        /// <remarks>This method adds a new row to the table, consisting of a range of cells.  The cells are added to columns starting with column 0.  If there are fewer cells than columns,
        /// the new row is padded with null cells on the right.  If there are more cells than columns, the existing rows in the table are passed with null cells on the right.</remarks>
        public void AddRow(params TableCell[] rowContents)
        {
            AddRow((IEnumerable<TableCell>)rowContents);
        }

        /// <summary>
        /// Add a <see cref="TableColumn"/> to the table.
        /// </summary>
        /// <param name="col">The column to add to the table.</param>
        public void AddColumn(TableColumn col)
        {
            // Make sure table is deep enough for the new column
            while (col.Count > _rows.Count)
            {
                _rows.Add(new TableRow());
                for (int i = 0; i < _columns.Count; ++i)
                {
                    _rows[_rows.Count - 1].Add(null);
                }
            }

            _columns.Add(col);
            for (int i = 0; i < col.Count; ++i)
            {
                _rows[i].Add(col[i]);
            }
            for (int i = col.Count; i < _rows.Count; ++i)
            {
                _rows[i].Add(null);
            }
        }

        /// <summary>
        /// Add a new column to the table, consisting of a range of cells.
        /// </summary>
        /// <param name="columnContents">The cells to add to the table.</param>
        public void AddColumn(IEnumerable<TableCell> columnContents)
        {
            TableColumn col = new TableColumn();
            col.AddRange(columnContents);
            AddColumn(col);
        }

        /// <summary>
        /// Add a new column to the table, consisting of a range of cells.
        /// </summary>
        /// <param name="columnContents">The cells to add to the table.</param>
        public void AddColumn(params TableCell[] columnContents)
        {
            AddColumn((IEnumerable<TableCell>)columnContents);
        }

        /// <summary>
        /// Draw this table at the given location on the graphics context.
        /// </summary>
        /// <param name="graphicsContext">The graphics context to use to draw the table.</param>
        /// <param name="xCoord">The X coordinate of the top left corner of the table.</param>
        /// <param name="yCoord">The Y coordinate of the top left corner of the table.</param>
        public void DrawAt(IGraphicsContext graphicsContext, double xCoord, double yCoord)
        {
            double yOffset = 0;
            foreach (TableRow row in _rows)
            {
                double xOffset = 0;
                foreach (TableCell cell in row)
                {
                    cell.DrawContentsAt(graphicsContext, xCoord + xOffset, yCoord + yOffset);
                    xOffset += cell.ComputedWidth;
                }
                if (row.Count > 0)
                {
                    yOffset += row[0].ComputedHeight;
                }
            }
            switch (RuleStyle)
            {
                case TableRuleStyle.LinesMeet:
                    DrawFullGrid(graphicsContext, xCoord, yCoord);
                    break;
                case TableRuleStyle.SolidColumnsBrokenRows:
                    DrawSolidColumnGrid(graphicsContext, xCoord, yCoord);
                    break;
                case TableRuleStyle.SolidRowsBrokenColumns:
                    DrawSolidRowGrid(graphicsContext, xCoord, yCoord);
                    break;
                case TableRuleStyle.None:
                default:
                    break;
            }
        }

        private void DrawFullGrid(IGraphicsContext graphicsContext, double x, double y)
        {
            graphicsContext.DrawLine(x, y, x, y + ComputedHeight);
            double xOffset = 0;
            foreach (TableColumn column in _columns)
            {
                xOffset += column.ComputedWidth;
                graphicsContext.DrawLine(x + xOffset, y, x + xOffset, y + ComputedHeight, RuleWidth);
            }
            graphicsContext.DrawLine(x, y, x + ComputedWidth, y, RuleWidth);
            double yOffset = 0;
            foreach (TableRow row in _rows)
            {
                yOffset += row.ComputedWidth;
                graphicsContext.DrawLine(x, y + yOffset, x + ComputedWidth, y + yOffset, RuleWidth);
            }
        }

        private void DrawSolidColumnGrid(IGraphicsContext graphicsContext, double x, double y)
        {
            graphicsContext.DrawLine(x, y, x, y + ComputedHeight, RuleWidth);
            double xOffset = 0;
            for (int i = 0; i < _columns.Count; ++i)
            {
                double rgs = RuleGapSize;
                if (i == _columns.Count - 1)
                {
                    rgs = 0d;
                }
                xOffset += _columns[i].ComputedWidth;
                graphicsContext.DrawLine(x + xOffset, y + rgs, x + xOffset, y + ComputedHeight - rgs, RuleWidth);
            }
            graphicsContext.DrawLine(x, y, x + ComputedWidth, y, RuleWidth);
            double yOffset = 0;
            for (int i = 0; i < _rows.Count - 1; ++i)
            {
                yOffset += _rows[i].ComputedHeight;
                xOffset = 0;
                foreach (TableColumn column in _columns)
                {
                    graphicsContext.DrawLine(x + RuleGapSize + xOffset, y + yOffset, x + column.ComputedWidth + xOffset - RuleGapSize, y + yOffset);
                    xOffset += column.ComputedWidth;
                }
            }
            graphicsContext.DrawLine(x, y + ComputedHeight, x + ComputedWidth, y + ComputedHeight, RuleWidth);
        }

        private void DrawSolidRowGrid(IGraphicsContext graphicsContext, double x, double y)
        {
            graphicsContext.DrawLine(x, y, x + ComputedWidth, y, RuleWidth);
            double yOffset = 0;
            for (int i = 0; i < _rows.Count; ++i)
            {
                double rgs = RuleGapSize;
                if (i == _rows.Count - 1)
                {
                    rgs = 0d;
                }
                yOffset += _rows[i].ComputedHeight;
                graphicsContext.DrawLine(x + rgs, y + yOffset, x + ComputedWidth - rgs, y + yOffset, RuleWidth);
            }
            graphicsContext.DrawLine(x, y, x, y + ComputedHeight, RuleWidth);
            double xOffset = 0;
            for (int i = 0; i < _columns.Count - 1; ++i)
            {
                xOffset += _columns[i].ComputedWidth;
                yOffset = 0;
                foreach (TableRow row in _rows)
                {
                    graphicsContext.DrawLine(x + xOffset, y + yOffset + RuleGapSize, x + xOffset, y + yOffset + row.ComputedHeight - RuleGapSize, RuleWidth);
                    yOffset += row.ComputedWidth;
                }
            }
            graphicsContext.DrawLine(x + ComputedWidth, y, x + ComputedWidth, y + ComputedHeight, RuleWidth);
        }
    }
}
