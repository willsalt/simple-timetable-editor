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
using Timetabler.CoreData;
using Timetabler.Data.Extensions;
using System.Globalization;

namespace Timetabler.Controls
{
    /// <summary>
    /// A control for displaying a train graph on a form.
    /// </summary>
    public partial class TrainGraph : UserControl
    {
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

        private SortedDictionary<int, SortedDictionary<int, VertexInformation>> TrainCoordinates { get; set; }

        private VertexInformation _nearestVertex = null;

        private readonly ToolTip _tooltip;

        private bool InDragMode { get; set; }

        /// <summary>
        /// When dragging, the real X-axis distance between the mouse pointer and the control point.
        /// </summary>
        private float DragPointerOffset { get; set; }

        private float LocationAxisXCoordinate { get; set; }

        private float MaximumXCoordinate
        {
            get
            {
                if (RightMarginPercent == 1f)
                {
                    return 0f;
                }
                return Size.Width * (1f - RightMarginPercent);
            }
        }

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
            TrainCoordinates = new SortedDictionary<int, SortedDictionary<int, VertexInformation>>();
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

            if (Model == null || Model.LocationList == null || Model.LocationList.Count == 0 || Model.TrainList == null || Model.TrainList.Count == 0 || e is null)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            float leftLimit = Size.Width * LeftMarginPercent;
            float topLimit = Size.Height * TopMarginPercent;
            float bottomLimit = Size.Height * (1 - BottomMarginPercent);

            TrainCoordinates.Clear();

            // Work out horizontal resolution
            List<TrainGraphAxisTickInfo> timeAxisInfo = Model.GetTimeAxisInformation().Select(i => { i.PopulateSize(e.Graphics, TimeAxisFont); return i; }).ToList();
            bottomLimit -= timeAxisInfo.Max(i => (float)i.Height.Value) + 5;
            using (Pen axisPen = new Pen(Color.Black, 1f))
            {
                // Draw Y axis
                List<TrainGraphAxisTickInfo> locationAxisInfo = Model.GetDistanceAxisInformation().Select(i => { i.PopulateSize(e.Graphics, LocationAxisFont); return i; }).ToList();
                topLimit += (float)locationAxisInfo.Last().Height.Value / 2;
                LocationAxisXCoordinate = leftLimit += locationAxisInfo.Max(i => (float)i.Width) + 5;

                using (SolidBrush backColourBrush = new SolidBrush(GraphBackColour))
                {
                    e.Graphics.FillRectangle(backColourBrush, leftLimit, topLimit, MaximumXCoordinate - leftLimit, bottomLimit - topLimit);
                }
                e.Graphics.DrawLine(axisPen, leftLimit, bottomLimit, leftLimit, topLimit);
                e.Graphics.DrawLine(axisPen, MaximumXCoordinate, bottomLimit, MaximumXCoordinate, topLimit);
                using (SolidBrush blackBrush = new SolidBrush(Color.Black))
                {
                    foreach (TrainGraphAxisTickInfo tick in locationAxisInfo)
                    {
                        float y = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - tick.Coordinate);
                        e.Graphics.DrawLine(axisPen, MaximumXCoordinate, y, leftLimit - 5, y);
                        e.Graphics.DrawString(tick.Label, LocationAxisFont, blackBrush, (float)(leftLimit - (tick.Width.Value + 5)), (float)(y - tick.Height.Value / 2));
                    }

                    // Draw X axis ticks / gridlines.
                    foreach (TrainGraphAxisTickInfo tick in timeAxisInfo)
                    {
                        float x = CoordinateHelper.Stretch(leftLimit, MaximumXCoordinate, tick.Coordinate);
                        float yTop = ShowVerticalGridLines ? topLimit : bottomLimit;
                        e.Graphics.DrawLine(axisPen, x, yTop, x, bottomLimit + 5);
                        e.Graphics.DrawString(tick.Label, TimeAxisFont, blackBrush, (float)(x - tick.Width.Value / 2), bottomLimit + 5);
                    }
                }
            }

            // Draw trains
            List<TrainDrawingInfo> trainDrawingInfo = Model.GetTrainDrawingInformation().ToList();
            List<Tuple<float, float>> selectedTrainCoordinates = new List<Tuple<float, float>>();
            foreach (TrainDrawingInfo info in trainDrawingInfo)
            {
                using (Pen trainPen = new Pen(info.Properties.Colour, info.Properties.Width) { DashStyle = info.Properties.DashStyle })
                {
                    foreach (LineCoordinates lineData in info.Lines)
                    {
                        DrawLine(e.Graphics, trainPen, lineData.Vertex1, lineData.Vertex2, leftLimit, MaximumXCoordinate, topLimit, bottomLimit, selectedTrainCoordinates);
                    }
                }
                if (Model.DisplayTrainLabels && !string.IsNullOrWhiteSpace(info.Headcode))
                {
                    SizeF headcodeDimensions = e.Graphics.MeasureString(info.Headcode.Trim(), TrainLabelFont);
                    LineCoordinates longestLine = info.Lines[LineCoordinates.GetIndexOfLongestLine(info.Lines)];
                    float llX1 = CoordinateHelper.Stretch(leftLimit, MaximumXCoordinate, longestLine.Vertex1.X);
                    float llX2 = CoordinateHelper.Stretch(leftLimit, MaximumXCoordinate, longestLine.Vertex2.X);
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

            // Draw vertex/train being dragged (if appropriate)
            if (InDragMode)
            {
                float x = CoordinateHelper.Stretch(leftLimit, MaximumXCoordinate, _nearestVertex.X + _nearestVertex.DragOffset) - handleOffset;
                float y = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - _nearestVertex.Y) - handleOffset;
                //_log.Trace("Drawing drag handle at {0}, {1}", x, y);
                e.Graphics.FillEllipse(Brushes.LightGray, x, y, ControlHandleSize, ControlHandleSize);
                e.Graphics.DrawEllipse(Pens.Black, x, y, ControlHandleSize, ControlHandleSize);
            }
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
            if (controlHandleCoordinates != null && v0.Train == Model.SelectedTrain)
            {
                controlHandleCoordinates.Add(new Tuple<float, float>(xc0, yc0));
                controlHandleCoordinates.Add(new Tuple<float, float>(xc1, yc1));
            }
        }

        private void AddCoordinate(VertexInformation vertex, float xCoord, float yCoord)
        {
            int xc = (int)xCoord;
            int yc = (int)yCoord;

            if (!TrainCoordinates.ContainsKey(xc))
            {
                TrainCoordinates.Add(xc, new SortedDictionary<int, VertexInformation>());
            }
            if (!TrainCoordinates[xc].ContainsKey(yc))
            {
                TrainCoordinates[xc].Add(yc, vertex);
            }
        }

        private void TrainGraph_MouseMove(object sender, MouseEventArgs e)
        {
            if (InDragMode)
            {
                if (e.X > Size.Width || e.Y > Size.Height || e.X < 0 || e.Y < 0)
                {
                    InDragMode = false;
                    _tooltip.Hide(this);
                    return;
                }
                double relativeX = CoordinateHelper.Unstretch(LocationAxisXCoordinate, MaximumXCoordinate, e.X - DragPointerOffset);
                _nearestVertex.DragOffset = relativeX - _nearestVertex.X;            
                TimeOfDay coordinateTime = Model.GetTimeOfDayFromXPosition(relativeX);
                _tooltip.Show(coordinateTime.ToString(Model.TooltipFormattingString, CultureInfo.CurrentCulture), this);
                Invalidate();
                return;
            }

            _nearestVertex = FindVertexFromCoordinates(e.Location);
            if (_nearestVertex != null)
            {
                if (_nearestVertex.Train == Model.SelectedTrain)
                {
                    Cursor.Current = Cursors.SizeWE;
                }
                else
                {
                    Cursor.Current = Cursors.Cross;
                }
                if (ShowTooltip)
                {
                    _tooltip.Show(_nearestVertex.Time.ToString(Model.TooltipFormattingString, CultureInfo.CurrentCulture), this);
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
            var nearestX = FindFuzzyItemInList(location.X, TrainCoordinates.Keys.ToList());
            if (!nearestX.HasValue)
            {
                return null;
            }
            var nearestY = FindFuzzyItemInList(location.Y, TrainCoordinates[nearestX.Value].Keys.ToList());
            if (!nearestY.HasValue)
            {
                return null;
            }
            return TrainCoordinates[nearestX.Value][nearestY.Value];
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

        private void TrainGraph_MouseDown(object sender, MouseEventArgs e)
        {
            if (_nearestVertex != null)
            {
                Model.SelectedTrain = _nearestVertex.Train;
                DragPointerOffset = e.X - CoordinateHelper.Stretch(LocationAxisXCoordinate, MaximumXCoordinate, _nearestVertex.X);
                InDragMode = true;
                Cursor.Current = Cursors.SizeWE;
                Invalidate();
            }
            else if (Model.SelectedTrain != null)
            {
                Model.SelectedTrain = null;
                Invalidate();
            }
        }

        private void TrainGraph_MouseUp(object sender, MouseEventArgs e)
        {
            if (InDragMode && _nearestVertex != null)
            {
                ProcessEndOfDrag(e.X);
                Invalidate();
            }
            InDragMode = false;
        }

        private void ProcessEndOfDrag(int xCoord)
        {
            double relativeX = CoordinateHelper.Unstretch(LocationAxisXCoordinate, MaximumXCoordinate, xCoord - DragPointerOffset);
            if (Model.GraphEditStyle == GraphEditStyle.Free)
            {
                _nearestVertex.X = relativeX;
                Model.GetTimeOfDayFromXPosition(relativeX).CopyTo(_nearestVertex.Time);
            }
            else if (Model.GraphEditStyle == GraphEditStyle.PreserveSectionTimes)
            {
                TimeSpan timeOffset = Model.GetTimeOfDayFromXPosition(relativeX) - _nearestVertex.Time;
                IList<VertexInformation> vertexes;
                // Departure moved later
                if ((_nearestVertex.ArrivalDeparture & ArrivalDepartureOptions.Departure) != 0 && timeOffset.TotalSeconds > 0)
                {
                    vertexes = _nearestVertex.TrainDrawingInfo.LineVertexes.LaterThan(_nearestVertex).ToList();
                }
                // Arrival moved earlier
                else if ((_nearestVertex.ArrivalDeparture & ArrivalDepartureOptions.Arrival) != 0 && timeOffset.TotalSeconds < 0)
                {
                    vertexes = _nearestVertex.TrainDrawingInfo.LineVertexes.EarlierThan(_nearestVertex).ToList();
                }
                // Departure moved earlier or arrival moved later
                else
                {
                    vertexes = _nearestVertex.TrainDrawingInfo.LineVertexes.ToList();
                }
                ShiftVertexes(vertexes, timeOffset);
            }
            _nearestVertex.Train.RefreshTimingPointModels();    
        }

        private void ShiftVertexes(IList<VertexInformation> vertexes, TimeSpan timeOffset)
        {
            foreach (TimeOfDay time in vertexes.Times())
            {
                (time + timeOffset).CopyTo(time);
            }
            foreach (VertexInformation vertex in vertexes)
            {
                vertex.X = Model.GetXPositionFromTime(vertex.Time);
            }
        }

        private void TrainGraph_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_nearestVertex?.Train != null)
            {
                EditTrain(_nearestVertex?.Train);
            }
        }

        private void EditTrain(Train train)
        {
            if (Model?.EditTrainMethod != null)
            {
                Model.EditTrainMethod(train.Id);
                Invalidate();
            }
        }
    }
}
