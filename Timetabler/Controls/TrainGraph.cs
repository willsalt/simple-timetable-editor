using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Timetabler.Models;
using System.Drawing.Drawing2D;
using Timetabler.Data;
using Timetabler.Data.Events;
using System;
using Timetabler.Data.Display;
using Timetabler.Extensions;
using Timetabler.CoreData.Helpers;
using NLog;

namespace Timetabler.Controls
{
    /// <summary>
    /// A control for displaying a train graph on a form.
    /// </summary>
    public partial class TrainGraph : UserControl
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// The distance from the left edge of the graph to the left edge of the control, as a proportion of control width.
        /// </summary>
        [DefaultValue(0.05f)]
        public float LeftMarginPercent { get; set; }

        /// <summary>
        /// The distance from the right edge of the graph to the right edge of the control, as a proportion of control width.
        /// </summary>
        [DefaultValue(0.05f)]
        public float RightMarginPercent { get; set; }

        /// <summary>
        /// The distance from the top edge of the graph to the top edge of the control, as a proportion of control height.
        /// </summary>
        [DefaultValue(0.1f)]
        public float TopMarginPercent { get; set; }

        /// <summary>
        /// The distance from the bottom edge of the graph to the bottom edge of the control, as a proportion of control height.
        /// </summary>
        [DefaultValue(0.1f)]
        public float BottomMarginPercent { get; set; }

        /// <summary>
        /// The background colour of the drawing area of the graph.
        /// </summary>
        [DefaultValue(typeof(Color), "White")]
        public Color GraphBackColour { get; set; }

        /// <summary>
        /// Whether or not vertical lines should be drawn at each tick interval.
        /// </summary>
        [DefaultValue(false)]
        public bool ShowVerticalGridLines { get; set; }

        /// <summary>
        /// Whether or not a tooltip should be displayed when the mouse cursor is close to a vertex.
        /// </summary>
        [DefaultValue(true)]
        public bool ShowTooltip { get; set; }

        /// <summary>
        /// The font to use for the location (Y) axis labels.
        /// </summary>
        public Font LocationAxisFont { get; set; }

        /// <summary>
        /// The font to use for the time (X) axis labels.
        /// </summary>
        public Font TimeAxisFont { get; set; }

        /// <summary>
        /// The font to use for the train labels.
        /// </summary>
        public Font TrainLabelFont { get; set; }

        private TrainGraphModel _model;

        /// <summary>
        /// The data to display on the graph.
        /// </summary>
        public TrainGraphModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (_model != null)
                {
                    _model.TrainChanged -= ModelChangedHandler;
                }
                _model = value;
                if (_model != null)
                {
                    _model.TrainChanged += ModelChangedHandler;
                }
            }
        }

        private void ModelChangedHandler(object sender, TrainEventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Size of control handles.
        /// </summary>
        [DefaultValue(10f)]
        public float ControlHandleSize { get; set; }

        private Dictionary<string, TrainGraphYAxisTickModel> _locationYTicks { get; set; }

        private SortedDictionary<int, SortedDictionary<int, VertexInformation>> _trainCoordinates { get; set; }

        private VertexInformation _nearestVertex = null;

        private Train _selectedTrain = null;

        private ToolTip _tooltip;

        private bool InDragMode { get; set; }

        private float LocationAxisXCoordinate { get; set; }

        /// <summary>
        /// Default constructor; sets properties to their default values.
        /// </summary>
        public TrainGraph()
        {
            LeftMarginPercent = 0.05f;
            RightMarginPercent = 0.05f;
            TopMarginPercent = 0.1f;
            BottomMarginPercent = 0.1f;
            ControlHandleSize = 10f;
            LocationAxisFont = new Font("Cambria", 8);
            TimeAxisFont = new Font("Cambria", 8);
            TrainLabelFont = new Font("Cambria", 8);
            GraphBackColour = Color.White;
            _trainCoordinates = new SortedDictionary<int, SortedDictionary<int, VertexInformation>>();
            ShowTooltip = true;
            _tooltip = new ToolTip();
            InitializeComponent();
        }

        /// <summary>
        /// Paint the control.
        /// </summary>
        /// <param name="e">The <see cref="PaintEventArgs"/> object encapsulating the drawing context.</param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Model == null || Model.LocationList == null || Model.LocationList.Count == 0 || Model.TrainList == null || Model.TrainList.Count == 0)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            float leftLimit = Size.Width * LeftMarginPercent;
            float rightLimit = Size.Width * (1 - RightMarginPercent);
            float topLimit = Size.Height * TopMarginPercent;
            float bottomLimit = Size.Height * (1 - BottomMarginPercent);

            _trainCoordinates.Clear();

            // Work out horizontal resolution
            List<TrainGraphAxisTickInfo> timeAxisInfo = Model.GetTimeAxisInformation().Select(i => { i.PopulateSize(e.Graphics, TimeAxisFont); return i; }).ToList();
            bottomLimit -= timeAxisInfo.Max(i => (float)i.Height.Value) + 5;
            Pen axisPen = new Pen(Color.Black, 1f);

            // Draw Y axis
            List<TrainGraphAxisTickInfo> locationAxisInfo = Model.GetDistanceAxisInformation().Select(i => { i.PopulateSize(e.Graphics, LocationAxisFont); return i; }).ToList();
            topLimit += (float)locationAxisInfo.Last().Height.Value / 2;
            LocationAxisXCoordinate = leftLimit += locationAxisInfo.Max(i => (float)i.Width) + 5;

            e.Graphics.FillRectangle(new SolidBrush(GraphBackColour), leftLimit, topLimit, rightLimit - leftLimit, bottomLimit - topLimit);
            e.Graphics.DrawLine(axisPen, leftLimit, bottomLimit, leftLimit, topLimit);
            e.Graphics.DrawLine(axisPen, rightLimit, bottomLimit, rightLimit, topLimit);
            foreach (TrainGraphAxisTickInfo tick in locationAxisInfo)
            {
                float y = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - tick.Coordinate);
                e.Graphics.DrawLine(axisPen, rightLimit, y, leftLimit - 5, y);
                e.Graphics.DrawString(tick.Label, LocationAxisFont, new SolidBrush(Color.Black), (float)(leftLimit - (tick.Width.Value + 5)), (float)(y - tick.Height.Value / 2));
            }

            // Draw X axis ticks / gridlines.
            foreach (TrainGraphAxisTickInfo tick in timeAxisInfo)
            {
                float x = CoordinateHelper.Stretch(leftLimit, rightLimit, tick.Coordinate);
                float yTop = ShowVerticalGridLines ? topLimit : bottomLimit;
                e.Graphics.DrawLine(axisPen, x, yTop, x, bottomLimit + 5);
                e.Graphics.DrawString(tick.Label, TimeAxisFont, new SolidBrush(Color.Black), (float)(x - tick.Width.Value / 2), bottomLimit + 5);
            }

            // Draw trains
            List<TrainDrawingInfo> trainDrawingInfo = Model.GetTrainDrawingInformation().ToList();
            List<Tuple<float, float>> selectedTrainCoordinates = new List<Tuple<float, float>>();
            foreach (TrainDrawingInfo info in trainDrawingInfo)
            {
                Pen trainPen = new Pen(info.Properties.Colour, info.Properties.Width) { DashStyle = info.Properties.DashStyle };
                foreach (LineCoordinates lineData in info.LineVertexes)
                {
                    DrawLine(e.Graphics, trainPen, lineData.Vertex1, lineData.Vertex2, leftLimit, rightLimit, topLimit, bottomLimit, selectedTrainCoordinates);
                }

                if (Model.DisplayTrainLabels && !string.IsNullOrWhiteSpace(info.Headcode))
                {
                    SizeF headcodeDimensions = e.Graphics.MeasureString(info.Headcode.Trim(), TrainLabelFont);
                    LineCoordinates longestLine = info.LineVertexes[LineCoordinates.GetIndexOfLongestLine(info.LineVertexes)];
                    float llX1 = CoordinateHelper.Stretch(leftLimit, rightLimit, longestLine.Vertex1.X);
                    float llX2 = CoordinateHelper.Stretch(leftLimit, rightLimit, longestLine.Vertex2.X);
                    float llY1 = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - longestLine.Vertex1.Y);
                    float llY2 = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - longestLine.Vertex2.Y);
                    PointF longestLineMidpoint = new PointF((llX1 + llX2) / 2, (llY1 + llY2) / 2);
                    e.Graphics.TranslateTransform(longestLineMidpoint.X, longestLineMidpoint.Y);
                    e.Graphics.RotateTransform((float)(Math.Atan2(llY1 - llY2, llX1 - llX2) * (180.0 / Math.PI) + 180.0));
                    e.Graphics.TranslateTransform(-headcodeDimensions.Width / 2, -headcodeDimensions.Height);
                    e.Graphics.DrawString(info.Headcode.Trim(), TrainLabelFont, Brushes.Black, new PointF(0, 0));
                    e.Graphics.ResetTransform();
                }
            }
            float handleOffset = ControlHandleSize / 2f;
            foreach (Tuple<float, float> controlHandleCoordinate in selectedTrainCoordinates)
            {
                e.Graphics.FillEllipse(Brushes.White, controlHandleCoordinate.Item1 - handleOffset, controlHandleCoordinate.Item2 - handleOffset, ControlHandleSize, ControlHandleSize);
                e.Graphics.DrawEllipse(Pens.Black, controlHandleCoordinate.Item1 - handleOffset, controlHandleCoordinate.Item2 - handleOffset, ControlHandleSize, ControlHandleSize);
            }
        }

        private int GetIndexOfLongestLine(IList<Tuple<PointF, PointF>> coordinates)
        {
            double max = 0;
            int idx = 0;
            for (int i = 0; i < coordinates.Count; ++i)
            {
                double len = Math.Sqrt(Math.Pow(coordinates[i].Item1.X - coordinates[i].Item2.X, 2) + Math.Pow(coordinates[i].Item1.Y - coordinates[i].Item2.Y, 2));
                if (len > max)
                {
                    max = len;
                    idx = i;
                }
            }

            return idx;
        }

        private void DrawLine(
            Graphics graphics, 
            Pen trainPen, 
            VertexInformation v0, 
            VertexInformation v1, 
            float leftLimit, 
            float rightLimit, 
            float topLimit, 
            float bottomLimit, 
            List<Tuple<float, float>> controlHandleCoordinates)
        {
            float xc0 = CoordinateHelper.Stretch(leftLimit, rightLimit, v0.X);
            float yc0 = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - v0.Y);
            float xc1 = CoordinateHelper.Stretch(leftLimit, rightLimit, v1.X);
            float yc1 = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - v1.Y);
            AddCoordinate(v0, xc0, yc0);
            AddCoordinate(v1, xc1, yc1);
            graphics.DrawLine(trainPen, new PointF(xc0, yc0), new PointF(xc1, yc1));
            if (controlHandleCoordinates != null && v0.Train == _selectedTrain)
            {
                controlHandleCoordinates.Add(new Tuple<float, float>(xc0, yc0));
                controlHandleCoordinates.Add(new Tuple<float, float>(xc1, yc1));
            }
        }

        private void AddCoordinate(VertexInformation vertex, float xCoord, float yCoord)
        {
            int xc = (int)xCoord;
            int yc = (int)yCoord;

            if (!_trainCoordinates.ContainsKey(xc))
            {
                _trainCoordinates.Add(xc, new SortedDictionary<int, VertexInformation>());
            }
            if (!_trainCoordinates[xc].ContainsKey(yc))
            {
                _trainCoordinates[xc].Add(yc, vertex);
            }
        }

        private void TrainGraph_MouseMove(object sender, MouseEventArgs e)
        {
            _log.Trace("Mouse moved to {0}, {1} (buttons {2} InDragMode {3})", e.X, e.Y, e.Button, InDragMode);
            if (InDragMode)
            {
                if (e.X > Size.Width || e.Y > Size.Height || e.X < 0 || e.Y < 0)
                {
                    InDragMode = false;
                    _tooltip.Hide(this);
                    return;
                }
                float rightLimit = Size.Width * (1 - RightMarginPercent);
                TimeOfDay coordinateTime = Model.GetTimeOfDayFromXPosition(CoordinateHelper.Unstretch(LocationAxisXCoordinate, rightLimit, e.X));
                _tooltip.Show($"Dragging {coordinateTime.ToString(Model.TooltipFormattingString)}", this);
                Invalidate();
                return;
            }

            _nearestVertex = FindVertexFromCoordinates(e.Location);
            if (_nearestVertex != null)
            {
                if (_nearestVertex.Train == _selectedTrain)
                {
                    Cursor.Current = Cursors.SizeWE;
                }
                else
                {
                    Cursor.Current = Cursors.Cross;
                }
                if (ShowTooltip)
                {
                    _tooltip.Show(_nearestVertex.Time.ToString(Model.TooltipFormattingString), this);
                }
            }
            else
            {
                Cursor.Current = Cursors.Default;
                _tooltip.Hide(this);
            }
        }

        private VertexInformation FindVertexFromCoordinates(Point location)
        {
            var nearestX = FindFuzzyItemInList(location.X, _trainCoordinates.Keys.ToList());
            if (!nearestX.HasValue)
            {
                return null;
            }
            var nearestY = FindFuzzyItemInList(location.Y, _trainCoordinates[nearestX.Value].Keys.ToList());
            if (!nearestY.HasValue)
            {
                return null;
            }
            return _trainCoordinates[nearestX.Value][nearestY.Value];
        }

        private int? FindFuzzyItemInList(int val, List<int> keys)
        {
            int limit = (int)ControlHandleSize;

            int min = 0;
            int max = keys.Count - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (val == keys[mid])
                {
                    return val;
                }
                if (val < keys[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }

            int diffMin = min >= 0 && min < keys.Count ? Math.Abs(keys[min] - val) : int.MaxValue;
            int diffMax = max >= 0 && max < keys.Count ? Math.Abs(keys[max] - val) : int.MaxValue;
            if (diffMin <= limit || diffMax <= limit)
            {
                if (diffMin < diffMax)
                {
                    return keys[min];
                }
                return keys[max];
            }
            return null;
        }

        private void TrainGraph_MouseClick(object sender, MouseEventArgs e)
        {
            _selectedTrain = _nearestVertex?.Train;
            Invalidate();
        }

        private void TrainGraph_MouseDown(object sender, MouseEventArgs e)
        {
            _log.Trace("TrainGraph_MouseDown()");
            if (_nearestVertex != null)
            {
                _log.Trace("InDragMode true");
                InDragMode = true;
            }
        }

        private void TrainGraph_MouseUp(object sender, MouseEventArgs e)
        {
            _log.Trace("TrainGraph_MouseUp(): InDragMode false");
            InDragMode = false;
        }
    }
}
