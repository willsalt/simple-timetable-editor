using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Timetabler.Models;
using System.Drawing.Drawing2D;
using Timetabler.Helpers;
using Timetabler.Data;
using Timetabler.Data.Events;
using System;
using Timetabler.Data.Display;
using Timetabler.Extensions;
using Timetabler.CoreData.Helpers;

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
        /// Default constructor; sets properties to their default values.
        /// </summary>
        public TrainGraph()
        {
            LeftMarginPercent = 0.05f;
            RightMarginPercent = 0.05f;
            TopMarginPercent = 0.1f;
            BottomMarginPercent = 0.1f;
            LocationAxisFont = new Font("Cambria", 8);
            TimeAxisFont = new Font("Cambria", 8);
            TrainLabelFont = new Font("Cambria", 8);
            GraphBackColour = Color.White;
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

            List<TrainGraphAxisTickInfo> timeAxisInfo = Model.GetTimeAxisInformation().Select(i => { i.PopulateSize(e.Graphics, TimeAxisFont); return i; }).ToList();
            bottomLimit -= timeAxisInfo.Max(i => (float)i.Height.Value) + 5;
            Pen axisPen = new Pen(Color.Black, 1f);

            // Draw Y axis
            List<TrainGraphAxisTickInfo> locationAxisInfo = Model.GetDistanceAxisInformation().Select(i => { i.PopulateSize(e.Graphics, LocationAxisFont); return i; }).ToList();
            topLimit += (float)locationAxisInfo.Last().Height.Value / 2;
            leftLimit += locationAxisInfo.Max(i => (float)i.Width) + 5;

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
            foreach (TrainDrawingInfo info in Model.GetTrainDrawingInformation())
            {
                Pen trainPen = new Pen(info.Properties.Colour, info.Properties.Width) { DashStyle = info.Properties.DashStyle };
                foreach (LineCoordinates lineData in info.LineVertexes)
                {
                    e.Graphics.DrawLine(trainPen, CoordinateHelper.Stretch(leftLimit, rightLimit, lineData.X1), CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - lineData.Y1),
                        CoordinateHelper.Stretch(leftLimit, rightLimit, lineData.X2), CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - lineData.Y2));
                }

                if (Model.DisplayTrainLabels && !string.IsNullOrWhiteSpace(info.Headcode))
                {
                    SizeF headcodeDimensions = e.Graphics.MeasureString(info.Headcode.Trim(), TrainLabelFont);
                    LineCoordinates longestLine = info.LineVertexes[LineCoordinates.GetIndexOfLongestLine(info.LineVertexes)];
                    float llX1 = CoordinateHelper.Stretch(leftLimit, rightLimit, longestLine.X1);
                    float llX2 = CoordinateHelper.Stretch(leftLimit, rightLimit, longestLine.X2);
                    float llY1 = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - longestLine.Y1);
                    float llY2 = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - longestLine.Y2);
                    PointF longestLineMidpoint = new PointF((llX1 + llX2) / 2, (llY1 + llY2) / 2);
                    e.Graphics.TranslateTransform(longestLineMidpoint.X, longestLineMidpoint.Y);
                    e.Graphics.RotateTransform((float)(Math.Atan2(llY1 - llY2, llX1 - llX2) * (180.0 / Math.PI) + 180.0));
                    e.Graphics.TranslateTransform(-headcodeDimensions.Width / 2, -headcodeDimensions.Height);
                    e.Graphics.DrawString(info.Headcode.Trim(), TrainLabelFont, Brushes.Black, new PointF(0, 0));
                    e.Graphics.ResetTransform();
                }
            }
        }
    }
}
