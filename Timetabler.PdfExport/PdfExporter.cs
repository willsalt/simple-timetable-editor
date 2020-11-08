using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NLog;
using Timetabler.CoreData;
using Timetabler.CoreData.Helpers;
using Timetabler.Data;
using Timetabler.Data.Interfaces;
using Timetabler.Data.Collections;
using Timetabler.Data.Display;
using Timetabler.Data.Display.Interfaces;
using Timetabler.PdfExport.Extensions;
using Unicorn;
using Unicorn.CoreTypes;
using Unicorn.FontTools;
using Unicorn.Shapes;
using Timetabler.PdfExport.Interfaces;
using System.Globalization;

namespace Timetabler.PdfExport
{
    /// <summary>
    /// Class which controls the exporting of a timetable document to PDF.
    /// </summary>
    public class PdfExporter : IExporter, IDisposable
    {
        /// <summary>
        /// Delegate type for event handlers for status update events.
        /// </summary>
        /// <param name="sender">The object raising the event.</param>
        /// <param name="e">The event arguments.</param>
        public delegate void StatusUpdateEventHandler(object sender, StatusUpdateEventArgs e);

        /// <summary>
        /// Event raised when the exporter status changes.
        /// </summary>
        public event StatusUpdateEventHandler StatusUpdate;

        private readonly IDocumentDescriptorFactory _engineSelector;

        /// <summary>
        /// Width of the most important "scaffolding" lines used to draw the timetable.
        /// </summary>
        public double MainLineWidth { get; private set; }

        /// <summary>
        /// Width of the axes and gridlines on train graphs.
        /// </summary>
        public double GraphLineWidth { get; private set; }

        private double LineOffset => MainLineWidth / 2;

        /// <summary>
        /// Width of the lines drawn as dashes to indicate a train passes a location without stopping.
        /// </summary>
        public double PassingTrainDashWidth { get; private set; }

        private const double lineGapSize = 1.5;
        private const double interSectionGapSize = 10.0;
        private const double graphTickLength = 5.0;
        private const double distanceTickLabelMargin = 2.0;
        private const double cellTotalMargins = 5.0;

        private OpenTypeFontLoader _fontLoader = new OpenTypeFontLoader();

        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        private readonly IFontDescriptor _titleFont;
        private readonly IFontDescriptor _subtitleFont;
        private readonly IFontDescriptor _plainBodyFont;
        private readonly IFontDescriptor _italicBodyFont;
        private readonly IFontDescriptor _boldBodyFont;
        private readonly IFontDescriptor _alternativeLocationFont;

        private HorizontalArrow _leftPointingArrow;
        private HorizontalArrow _rightPointingArrow;
        private double _arrowHOffset = cellTotalMargins / 2;

        private const double _locationListMargins = 3.0;
        private const double _locationListMinimumColumnGap = 2.5;
        private const double _defaultHorizontalMarginProportion = 0.06;
        private const double _defaultVerticalMarginProportion = 0.06;

        private readonly MarginSet _tableCellStandardMargins;

        private IPageDescriptor _currentPage;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="ddf">The factory used to instantiate Unicorn driver-level objects, so that the implementation can be selected.</param>
        public PdfExporter(IDocumentDescriptorFactory ddf)
        {
            if (ddf is null)
            {
                throw new ArgumentNullException(nameof(ddf));
            }

            _engineSelector = ddf;

            _titleFont = _fontLoader.LoadFont(Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SerifBoldFace), 16);
            _subtitleFont = _fontLoader.LoadFont(Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SerifBoldFace), 14);
            _plainBodyFont = _fontLoader.LoadFont(Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SerifRomanFace), 7.5);
            _italicBodyFont = _fontLoader.LoadFont(Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SerifItalicFace), 7.5);
            _boldBodyFont = _fontLoader.LoadFont(Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SerifBoldFace), 7.5);
            _alternativeLocationFont = _fontLoader.LoadFont(Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SansBoldFace), 7.5);
            _tableCellStandardMargins = new MarginSet(2, 3, 1, 3);

            Log.Info("Loaded fonts.");
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_PlainBodyOffset, _plainBodyFont.Ascent);
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_ItalicBodyOffset, _italicBodyFont.Ascent);
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_BoldBodyOffset, _boldBodyFont.Ascent);

            MainLineWidth = 1.0;
            GraphLineWidth = 1.0;
            PassingTrainDashWidth = 0.5;
        }

        /// <summary>
        /// Raises the <see cref="StatusUpdate" /> event.
        /// </summary>
        /// <param name="isInProgress">Whether or not exporting is currently in progress.</param>
        /// <param name="progress">The completeness of the export process (as a fraction between 0 and 1).</param>
        /// <param name="status">A status message, potentially to display.</param>
        protected void OnStatusUpdate(bool isInProgress, double progress, string status)
        {
            StatusUpdate?.Invoke(this, new StatusUpdateEventArgs(isInProgress, progress, status));
        }

        private void StartPage(IDocumentDescriptor doc, PageOrientation orientation)
        {
            _currentPage = doc.AppendPage(orientation);
        }

        private int ComputeColumnsForSection(TimetableSectionModel entireSection, int startingColumn, SectionMetrics sectionMetrics)
        {
            double availableWidth = _currentPage.PageAvailableWidth - (sectionMetrics.LocationMetrics.TotalSize.Width + MainLineWidth * 3);
            if (sectionMetrics.DisplayDistanceColumn)
            {
                availableWidth -= (sectionMetrics.LocationMetrics.LeftOffset + MainLineWidth);
            }
            int colsCounted = 0;
            while (availableWidth > 0 && startingColumn + colsCounted < entireSection.TrainSegments.Count)
            {
                availableWidth -= MeasureSegmentWidth(entireSection.TrainSegments[startingColumn + colsCounted++], sectionMetrics);
            }
            return availableWidth > 0 ? colsCounted : colsCounted - 1;
        }

        /// <summary>
        /// Render a <see cref="TimetableDocument" /> to PDF, and write the PDF data to a <see cref="Stream" />.
        /// </summary>
        /// <param name="document">The document to be exported.</param>
        /// <param name="outputStream">The stream to write the output data to.</param>
        public void Export(TimetableDocument document, Stream outputStream)
        {
            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }
            if (document.ExportOptions is null)
            {
                throw new ArgumentException(Resources.PdfExporter_Export_ExportOptionsMissingError, nameof(document));
            }

            OnStatusUpdate(true, 0d, Resources.PdfExporter_Export_StartMessage);

            SetLineWidths(document.ExportOptions);

            IDocumentDescriptor doc = _engineSelector.GetDocumentDescriptor(_defaultHorizontalMarginProportion, _defaultVerticalMarginProportion);
            StartPage(doc, document.ExportOptions.TablePageOrientation.ToPageOrientation());
            bool firstOnPage = true;
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_PageMargins, _currentPage.TopMarginPosition, _currentPage.BottomMarginPosition,
                _currentPage.LeftMarginPosition, _currentPage.RightMarginPosition);

            SectionMetrics sectionMetricsWithTitle = MeasureSectionMetrics(document.DownTrainsDisplay, document.ExportOptions);
            SectionMetrics sectionMetricsWithNoTitle = sectionMetricsWithTitle.CopyWithNoTitle(document.ExportOptions.DistancesInOutput == SectionSelection.All);
            SectionMetrics sectionMetrics = sectionMetricsWithTitle;

            int columnsPerPage;
            for (int i = 0; i < document.DownTrainsDisplay.TrainSegments.Count; i += columnsPerPage)
            {
                OnStatusUpdate(true, 0.1 + 0.4 * ((double)i / document.DownTrainsDisplay.TrainSegments.Count), Resources.PdfExporter_Export_DownTrainsMessage);
                columnsPerPage = ComputeColumnsForSection(document.DownTrainsDisplay, i, sectionMetrics);
                Area footnotesForSection = LayOutFootnotesForSection(document.DownTrainsDisplay, i, columnsPerPage);
                if (_currentPage.CurrentVerticalCursor + sectionMetrics.TotalHeight + footnotesForSection.Height > _currentPage.BottomMarginPosition)
                {
                    StartPage(doc, document.ExportOptions.TablePageOrientation.ToPageOrientation());
                    firstOnPage = true;
                    sectionMetrics = sectionMetricsWithTitle;
                }
                _currentPage.CurrentVerticalCursor +=
                    DrawSection(document.DownTrainsDisplay, false, document.ExportOptions, i, columnsPerPage, sectionMetrics,
                        document.ExportOptions.DownSectionLabel, firstOnPage, document.Title, document.Subtitle, document.DateDescription, footnotesForSection,
                        _currentPage.LeftMarginPosition, _currentPage.CurrentVerticalCursor, _currentPage.RightMarginPosition);
                _currentPage.CurrentVerticalCursor += interSectionGapSize;

                if (firstOnPage)
                {
                    firstOnPage = false;
                    sectionMetrics = sectionMetricsWithNoTitle;
                }
            }

            sectionMetricsWithTitle = MeasureSectionMetrics(document.UpTrainsDisplay, document.ExportOptions);
            sectionMetricsWithNoTitle = sectionMetricsWithTitle.CopyWithNoTitle(true);
            sectionMetrics = firstOnPage ? sectionMetricsWithTitle : sectionMetricsWithNoTitle;

            for (int i = 0; i < document.UpTrainsDisplay.TrainSegments.Count; i += columnsPerPage)
            {
                OnStatusUpdate(true, 0.5 + 0.4 * ((double)i / document.UpTrainsDisplay.TrainSegments.Count), Resources.PdfExporter_Export_UpTrainsMessage);
                columnsPerPage = ComputeColumnsForSection(document.UpTrainsDisplay, i, sectionMetrics);
                Area footnotesForSection = LayOutFootnotesForSection(document.UpTrainsDisplay, i, columnsPerPage);
                if (_currentPage.CurrentVerticalCursor + sectionMetrics.TotalHeight + footnotesForSection.Height > _currentPage.BottomMarginPosition)
                {
                    StartPage(doc, document.ExportOptions.TablePageOrientation.ToPageOrientation());
                    firstOnPage = true;
                    sectionMetrics = sectionMetricsWithTitle;
                }
                _currentPage.CurrentVerticalCursor +=
                    DrawSection(document.UpTrainsDisplay, true, document.ExportOptions, i, columnsPerPage, sectionMetrics, document.ExportOptions.UpSectionLabel,
                        firstOnPage, document.Title, document.Subtitle, document.DateDescription, footnotesForSection, _currentPage.LeftMarginPosition,
                        _currentPage.CurrentVerticalCursor, _currentPage.RightMarginPosition);
                _currentPage.CurrentVerticalCursor += interSectionGapSize;

                if (!firstOnPage)
                {
                    firstOnPage = false;
                    sectionMetrics = sectionMetricsWithNoTitle;
                }
                if (document.ExportOptions.DistancesInOutput != SectionSelection.All)
                {
                    sectionMetricsWithNoTitle.DisplayDistanceColumn = false;
                }
            }

            OnStatusUpdate(true, 0.9, Resources.PdfExporter_Export_AdditionalMessage);

            UniSize boxHoursSize = default;
            if ((document.ExportOptions?.DisplayBoxHours ?? true) && document.SignalboxHoursSets.Count > 0)
            {
                Table hoursTable = new Table { RuleGapSize = lineGapSize, RuleStyle = TableRuleStyle.SolidColumnsBrokenRows, RuleWidth = MainLineWidth };
                List<TableCell> cells = new List<TableCell>
                    {
                        new PlainTextTableCell("", _plainBodyFont, _currentPage.PageGraphics)
                    };
                foreach (var box in document.Signalboxes)
                {
                    cells.Add(new PlainTextTableCell(box.Code, _boldBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics));
                }
                hoursTable.AddRow(cells);
                foreach (var hoursSet in document.SignalboxHoursSets)
                {
                    cells.Clear();
                    cells.Add(new PlainTextTableCell(hoursSet.Category, _plainBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics));
                    foreach (var box in document.Signalboxes)
                    {
                        string cellContent = hoursSet.Hours[box.Id].ToString(document.Options.ClockType);
                        cells.Add(new PlainTextTableCell(cellContent, _plainBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics));
                    }
                    hoursTable.AddRow(cells);
                }

                boxHoursSize = new UniSize(hoursTable.ComputedWidth, hoursTable.ComputedHeight);
                hoursTable.DrawAt(_currentPage.PageGraphics, _currentPage.LeftMarginPosition, _currentPage.CurrentVerticalCursor);
            }

            if (document.ExportOptions.DisplayCredits)
            {
                Table creditsTable = new Table { RuleGapSize = lineGapSize, RuleStyle = TableRuleStyle.SolidColumnsBrokenRows, RuleWidth = MainLineWidth };
                if (!string.IsNullOrWhiteSpace(document.WrittenBy))
                {
                    creditsTable.AddRow(new PlainTextTableCell(Resources.WrittenByCaption, _plainBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics),
                        new PlainTextTableCell(document.WrittenBy, _plainBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics));
                }
                if (!string.IsNullOrWhiteSpace(document.CheckedBy))
                {
                    creditsTable.AddRow(new PlainTextTableCell(Resources.CheckedByCaption, _plainBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics),
                        new PlainTextTableCell(document.CheckedBy, _plainBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics));
                }
                if (!string.IsNullOrWhiteSpace(document.TimetableVersion))
                {
                    creditsTable.AddRow(new PlainTextTableCell(Resources.VersionCaption, _plainBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics),
                        new PlainTextTableCell(document.TimetableVersion, _plainBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics));
                }
                if (!string.IsNullOrWhiteSpace(document.PublishedDate))
                {
                    creditsTable.AddRow(new PlainTextTableCell(Resources.PublishedDateCaption, _plainBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics),
                        new PlainTextTableCell(document.PublishedDate, _plainBodyFont, _tableCellStandardMargins, _currentPage.PageGraphics));
                }

                if (boxHoursSize != default && creditsTable.ComputedWidth + boxHoursSize.Width > _currentPage.PageAvailableWidth)
                {
                    _currentPage.CurrentVerticalCursor += boxHoursSize.Height + 1;
                }
                creditsTable.DrawAt(_currentPage.PageGraphics, _currentPage.RightMarginPosition - creditsTable.ComputedWidth, _currentPage.CurrentVerticalCursor);
            }

            if (document.ExportOptions.DisplayGraph)
            {
                StartPage(doc, document.ExportOptions.GraphPageOrientation.ToPageOrientation());
                DrawGraph(new TrainGraphModel(document.LocationList, document.TrainList) { DisplayTrainLabels = document.Options.DisplayTrainLabelsOnGraphs },
                    document.Title, document.Subtitle, document.DateDescription);
            }

            if (document.ExportOptions.DisplayGlossary)
            {
                ExportGlossary(doc, document.NoteDefinitions);
            }

            doc.Write(outputStream);
            OnStatusUpdate(false, 1d, Resources.PdfExporter_Export_CompleteMessage);
        }

        private void SetLineWidths(DocumentExportOptions exportOptions)
        {
            MainLineWidth = exportOptions.LineWidth;
            GraphLineWidth = exportOptions.GraphAxisLineWidth;
            PassingTrainDashWidth = exportOptions.FillerDashLineWidth;
        }

        private void DrawGraph(TrainGraphModel trainGraphModel, string title, string subtitle, string dateDescription)
        {
            double titleHeight = _titleFont.EmptyStringMetrics.MaxHeight;
            double subtitleHeight = _subtitleFont.EmptyStringMetrics.MaxHeight;
            DrawTitleAndSubtitle(title, subtitle, dateDescription, _currentPage.LeftMarginPosition, lineGapSize * 2, _currentPage.CurrentVerticalCursor, 
                _currentPage.RightMarginPosition - _currentPage.LeftMarginPosition, titleHeight, subtitleHeight, false, 0, 0);
            _currentPage.CurrentVerticalCursor += titleHeight + subtitleHeight;

            double bottomLimit = _currentPage.BottomMarginPosition;
            double topLimit = _currentPage.CurrentVerticalCursor;
            double leftLimit = _currentPage.LeftMarginPosition;
            double lineWidthOffset = GraphLineWidth / 2;
            List<TrainGraphAxisTickInfo> timeAxisInfo = 
                trainGraphModel.GetTimeAxisInformation().Select(i => { i.PopulateSize(_currentPage.PageGraphics, _plainBodyFont); return i; }).ToList();
            bottomLimit -= (timeAxisInfo.Max(i => i.Height).Value + graphTickLength + lineWidthOffset);

            List<TrainGraphAxisTickInfo> distanceAxisInfo = 
                trainGraphModel.GetDistanceAxisInformation().Select(i => { i.PopulateSize(_currentPage.PageGraphics, _plainBodyFont); return i; }).ToList();
            topLimit += distanceAxisInfo.Last().Height.Value / 2;
            leftLimit += distanceAxisInfo.Max(i => i.Width).Value + graphTickLength + lineWidthOffset + distanceTickLabelMargin;

            LineDrawingWrapper("y-axis", leftLimit, topLimit - lineWidthOffset, leftLimit, bottomLimit + lineWidthOffset, GraphLineWidth);
            LineDrawingWrapper("x-axis", leftLimit - lineWidthOffset, bottomLimit, _currentPage.RightMarginPosition + lineWidthOffset, bottomLimit, GraphLineWidth);
            foreach (TrainGraphAxisTickInfo tick in distanceAxisInfo)
            {
                double y = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - tick.Coordinate);
                LineDrawingWrapper("horizontal grid line", _currentPage.RightMarginPosition + lineWidthOffset, y, leftLimit - (graphTickLength + lineWidthOffset), y, 
                    GraphLineWidth);
                Word tickWord = new Word(tick.Label, _plainBodyFont, _currentPage.PageGraphics, 0);
                tickWord.DrawAt(_currentPage.PageGraphics, leftLimit - (tick.Width.Value + graphTickLength + lineWidthOffset + distanceTickLabelMargin), 
                    y - tick.Height.Value / 2);
            }

            foreach (TrainGraphAxisTickInfo tick in timeAxisInfo)
            {
                double x = CoordinateHelper.Stretch(leftLimit, _currentPage.RightMarginPosition, tick.Coordinate);
                LineDrawingWrapper("vertical grid line", x, topLimit - lineWidthOffset, x, bottomLimit + graphTickLength + lineWidthOffset, GraphLineWidth);
                Word tickWord = new Word(tick.Label, _plainBodyFont, _currentPage.PageGraphics, 0);
                tickWord.DrawAt(_currentPage.PageGraphics, x - tick.Width.Value / 2, bottomLimit + graphTickLength + lineWidthOffset);
            }

            foreach (TrainDrawingInfo info in trainGraphModel.GetTrainDrawingInformation())
            {
                foreach (LineCoordinates lineData in info.Lines)
                {
                    _currentPage.PageGraphics.DrawLine(CoordinateHelper.Stretch(leftLimit, _currentPage.RightMarginPosition, lineData.Vertex1.X),
                        CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - lineData.Vertex1.Y), 
                        CoordinateHelper.Stretch(leftLimit, _currentPage.RightMarginPosition, lineData.Vertex2.X),
                        CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - lineData.Vertex2.Y), info.Properties.Width, info.Properties.DashStyle.ToUniDashStyle());
                }

                if (trainGraphModel.DisplayTrainLabels && !string.IsNullOrWhiteSpace(info.Headcode))
                {
                    LineCoordinates longestLine = info.Lines[LineCoordinates.GetIndexOfLongestLine(info.Lines)];
                    double llX1 = CoordinateHelper.Stretch(leftLimit, _currentPage.RightMarginPosition, longestLine.Vertex1.X);
                    double llX2 = CoordinateHelper.Stretch(leftLimit, _currentPage.RightMarginPosition, longestLine.Vertex2.X);
                    double llY1 = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - longestLine.Vertex1.Y);
                    double llY2 = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - longestLine.Vertex2.Y);
                    UniPoint longestLineMidpoint = new UniPoint((llX1 + llX2) / 2, (llY1 + llY2) / 2);
                    IGraphicsState state = _currentPage.PageGraphics.Save();
                    _currentPage.PageGraphics.RotateAt(MathsHelpers.RadToDeg(Math.Atan2(llY1 - llY2, llX1 - llX2)) + 180.0, longestLineMidpoint);
                    Word headcode = new Word(info.Headcode, _plainBodyFont, _currentPage.PageGraphics, 0);
                    headcode.DrawAt(_currentPage.PageGraphics, longestLineMidpoint.X - (headcode.ContentWidth / 2), longestLineMidpoint.Y - (headcode.MinHeight + 2));
                    _currentPage.PageGraphics.Restore(state);
                }
            }
        }

        private SectionMetrics MeasureSectionMetrics(TimetableSectionModel section, DocumentExportOptions options)
        {
            Log.Trace(CultureInfo.InvariantCulture, "Title font metrics: Total {0} Baseline {1} Ascent {2} Descent {3} MaxHeight {4}", 
                _titleFont.EmptyStringMetrics.LineHeight, _titleFont.EmptyStringMetrics.HeightAboveBaseline, _titleFont.EmptyStringMetrics.AscenderHeight, 
                _titleFont.EmptyStringMetrics.DescenderHeight, _titleFont.EmptyStringMetrics.MaxHeight);
            Log.Trace(CultureInfo.InvariantCulture, "Subtitle font metrics: Total {0} Baseline {1} Ascent {2} Descent {3} MaxHeight {4}", 
                _subtitleFont.EmptyStringMetrics.LineHeight, _subtitleFont.EmptyStringMetrics.HeightAboveBaseline, _subtitleFont.EmptyStringMetrics.AscenderHeight, 
                _subtitleFont.EmptyStringMetrics.DescenderHeight, _subtitleFont.EmptyStringMetrics.MaxHeight);
            var shm = new SectionMetrics(MainLineWidth)
            {
                TitleHeight = _titleFont.EmptyStringMetrics.MaxHeight + MainLineWidth,
                SubtitleHeight = _subtitleFont.EmptyStringMetrics.MaxHeight + MainLineWidth,
                LocationMetrics = MeasureLocationList(section),
                IncludeLocoDiagramRow = options.DisplayLocoDiagramRow && section.TrainSegments.Any(s => !string.IsNullOrWhiteSpace(s.LocoDiagram)),
                IncludeToWorkRow = options.DisplayToWorkRow && section.TrainSegments.Any(s => !string.IsNullOrWhiteSpace(s.ToWorkCell?.DisplayedText)),
                IncludeLocoToWorkRow = options.DisplayLocoToWorkRow && section.TrainSegments.Any(s => !string.IsNullOrWhiteSpace(s.LocoToWorkCell?.DisplayedText)),
                HeaderIncludesFootnoteRow = section.TrainSegments.Any(t => !string.IsNullOrWhiteSpace(t.Footnotes)),
                ColumnWidth = MeasureMaximumCellWidth(section, options),
                DisplayDistanceColumn = options.DistancesInOutput != SectionSelection.None,
            };
            shm.ToWorkHeight = shm.IncludeToWorkRow ? MeasureToWorkRowHeight() : 0;
            shm.LocoToWorkHeight = shm.IncludeLocoToWorkRow ? MeasureLocoToWorkRowHeight() : 0;
            shm.HeaderHeight = MeasureHeaderHeight(section, shm.IncludeLocoDiagramRow);
            MeasureArrows(shm.ColumnWidth - cellTotalMargins, shm.LocationMetrics.LocationOffsetList.Max(t => t.ClearanceHeight));
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_IsLocoDiagramRowIncluded, shm.IncludeLocoDiagramRow);
            return shm;
        }

        private void MeasureArrows(double timingPointWidth, double timingPointHeight)
        {
            _leftPointingArrow = new HorizontalArrow(HorizontalDirection.ToLeft, timingPointWidth * 0.8, MainLineWidth, timingPointHeight / 3, timingPointWidth / 6, 
                timingPointWidth / 24);
            _rightPointingArrow = _leftPointingArrow.Flip();
            _arrowHOffset = cellTotalMargins / 2 + timingPointWidth * 0.1;
        }

        private Area LayOutFootnotesForSection(TimetableSectionModel section, int startingColumn, int columnCount)
        {
            List<FootnoteDisplayModel> relevantFootnotes = section.TrainSegments
                .Skip(startingColumn)
                .Take(columnCount)
                .SelectMany(s => s.PageFootnotes.Where(f => f.DisplayOnPage))
                .Distinct()
                .ToList();
            if (relevantFootnotes.Count == 0)
            {
                return new Area();
            }
            List<PositionedLine> lines = relevantFootnotes
                .Select(n => n.ToPositionedLine(_currentPage.PageGraphics, _alternativeLocationFont, _plainBodyFont))
                .OrderBy(pl => pl.MinWidth)
                .ToList();
            double yOffset = 2;
            for (int i = 0; i < lines.Count; ++i)
            {
                int endOfGroup;
                double totalWidth = lines[i].MinWidth;
                double spacing = 10;
                for (endOfGroup = i; endOfGroup < lines.Count - 1; ++endOfGroup)
                {
                    if (totalWidth + lines[endOfGroup + 1].MinWidth + spacing > _currentPage.PageAvailableWidth)
                    {
                        break;
                    }
                    totalWidth += lines[endOfGroup + 1].MinWidth + spacing;
                }
                double ongoingWidth = 0;
                for (int j = i; j <= endOfGroup; ++j)
                {
                    lines[j].Y = yOffset;
                    lines[j].X = ongoingWidth * (_currentPage.PageAvailableWidth / totalWidth);
                    ongoingWidth += lines[j].MinWidth + spacing;
                }

                yOffset += lines.Skip(i).Take((endOfGroup - i) + 1).Max(pl => pl.ContentHeight);
                i = endOfGroup;
            }

            return new Area(lines);
        }

        private double DrawSection(TimetableSectionModel section, bool reverseLocationOrder, DocumentExportOptions options, int startingColumn, int columnCount, 
            SectionMetrics sectionMetrics, string sectionName, bool includeTitleAndSubtitle, string title, string subtitle, string dateDescription, Area footnotes, 
            double leftCoord, double topCoord, double rightCoord)
        {
            Log.Trace("Starting to draw section.  Coordinates: T {0}, L {1}, R {2}", topCoord, leftCoord, rightCoord);

            double maxWidth = rightCoord - leftCoord;
            double subtitleTop = topCoord + sectionMetrics.TitleHeight;
            double headerTop = topCoord + sectionMetrics.HeaderOffset;
            double mainSectionTop = topCoord + sectionMetrics.MainSectionOffset;

            Log.Trace(CultureInfo.CurrentCulture, "Width: {0}.  Subtitle Top: {1}, Header Top: {2}, Main Section Top: {3}", maxWidth, subtitleTop, headerTop, 
                mainSectionTop);

            if (includeTitleAndSubtitle)
            {
                DrawTitleAndSubtitle(title, subtitle, dateDescription, leftCoord, lineGapSize * 2, topCoord, maxWidth, sectionMetrics.TitleHeight, 
                    sectionMetrics.SubtitleHeight, true, lineGapSize * 2, headerTop);
            }

            Log.Trace(CultureInfo.CurrentCulture, "Drawing section bounding box: L{0} T{1} W{2} H{3}", leftCoord + LineOffset, subtitleTop - LineOffset, 
                maxWidth - MainLineWidth, sectionMetrics.MainSectionBoundingHeight + MainLineWidth);
            _currentPage.PageGraphics.DrawRectangle(leftCoord + LineOffset, subtitleTop - LineOffset, maxWidth - MainLineWidth, 
                sectionMetrics.MainSectionBoundingHeight + MainLineWidth, MainLineWidth);

            double dimensionColumnShift = sectionMetrics.DisplayDistanceColumn ? sectionMetrics.LocationMetrics.LeftOffset + MainLineWidth : 0;

            LineDrawingWrapper("top border of location list", leftCoord + MainLineWidth + dimensionColumnShift + lineGapSize * 2, mainSectionTop - LineOffset, 
                leftCoord + MainLineWidth + dimensionColumnShift + sectionMetrics.LocationMetrics.TotalSize.Width - lineGapSize * 2, mainSectionTop - LineOffset,
                MainLineWidth);

            Paragraph sectionNameParagraph = new Paragraph(sectionMetrics.LocationMetrics.TotalSize.Width, sectionMetrics.HeaderHeight, Unicorn.Orientation.Normal,
                HorizontalAlignment.Centred, VerticalAlignment.Centred);
            sectionNameParagraph.AddText(sectionName, _subtitleFont, _currentPage.PageGraphics);
            sectionNameParagraph.DrawAt(_currentPage.PageGraphics, leftCoord + dimensionColumnShift + MainLineWidth, headerTop);

            DrawLocationList(section, sectionMetrics.LocationMetrics, leftCoord + MainLineWidth + dimensionColumnShift, mainSectionTop);
            if (sectionMetrics.DisplayDistanceColumn)
            {
                DrawLocationDistanceColumn(section, sectionMetrics.LocationMetrics, leftCoord + MainLineWidth, mainSectionTop, headerTop);
            }
            DrawLocoToWorkRowHeader(sectionMetrics, leftCoord, mainSectionTop + sectionMetrics.LocationMetrics.TotalSize.Height);
            DrawToWorkRowHeader(sectionMetrics, leftCoord, mainSectionTop + sectionMetrics.LocationMetrics.TotalSize.Height + sectionMetrics.LocoToWorkHeight);
            double columnLeft = leftCoord + sectionMetrics.LocationMetrics.TotalSize.Width + MainLineWidth * 2 + dimensionColumnShift;
            LineDrawingWrapper("initial separator", columnLeft - LineOffset, headerTop + lineGapSize, columnLeft - LineOffset, 
                headerTop + sectionMetrics.TableHeight - lineGapSize, MainLineWidth);
            for (int i = 0; i < columnCount && i + startingColumn < section.TrainSegments.Count; i++)
            {
                columnLeft += DrawSegment(section, section.TrainSegments[i + startingColumn], options, sectionMetrics, reverseLocationOrder, columnLeft, headerTop);
            }

            footnotes.DrawAt(_currentPage.PageGraphics, leftCoord, topCoord + sectionMetrics.TotalHeight);

            return sectionMetrics.TotalHeight + footnotes.Height;
        }

        private void DrawTitleAndSubtitle(string title, string subtitle, string dateDescription, double x, double subtitleXOffset, double y, double pageWidth, 
            double titleHeight, double subtitleHeight, bool drawSeparator, double separatorLineGap, double separatorY)
        {
            title = title ?? string.Empty;
            subtitle = subtitle ?? string.Empty;
            dateDescription = dateDescription ?? string.Empty;
            WritingWrapper(title, _titleFont, new UniRectangle(x, y, pageWidth, titleHeight), HorizontalAlignment.Centred, VerticalAlignment.Top);
            WritingWrapper(subtitle, _subtitleFont, 
                new UniRectangle(x + subtitleXOffset + MainLineWidth, y + titleHeight, pageWidth - (MainLineWidth * 2), subtitleHeight), 
                HorizontalAlignment.Left, VerticalAlignment.Top);
            WritingWrapper(dateDescription, _subtitleFont, 
                new UniRectangle(x + MainLineWidth, y + titleHeight, pageWidth - (subtitleXOffset + MainLineWidth * 2), subtitleHeight), 
                HorizontalAlignment.Right, VerticalAlignment.Top);
            if (drawSeparator)
            {
                LineDrawingWrapper("subtitle-headings line", x + MainLineWidth + separatorLineGap, separatorY - LineOffset, 
                    x + pageWidth - (MainLineWidth + separatorLineGap), separatorY - LineOffset, MainLineWidth);
            }
        }

        private double MeasureSegmentWidth(TrainSegmentModel segment, SectionMetrics sectionMetrics)
        {
            if (string.IsNullOrWhiteSpace(segment.InlineNote))
            {
                return sectionMetrics.ColumnWidth + MainLineWidth;
            }

            UniRange largestEmptyBlock = FindLargestEmptyBlock(segment, sectionMetrics.LocationMetrics);
            Paragraph para = new Paragraph(largestEmptyBlock.Size, sectionMetrics.ColumnWidth, Unicorn.Orientation.RotatedRight, HorizontalAlignment.Centred, VerticalAlignment.Centred, new MarginSet(2));
            para.AddText(segment.InlineNote, _plainBodyFont, _currentPage.PageGraphics);
            if (!para.OverspillHeight)
            {
                return sectionMetrics.ColumnWidth + MainLineWidth;
            }

            para = new Paragraph(sectionMetrics.LocationMetrics.TotalSize.Height, null, Unicorn.Orientation.RotatedRight, HorizontalAlignment.Centred, VerticalAlignment.Centred, new MarginSet(0.75));
            para.AddText(segment.InlineNote, _plainBodyFont, _currentPage.PageGraphics);
            return sectionMetrics.ColumnWidth + para.ComputedHeight + MainLineWidth;
        }

        private double DrawSegment(TimetableSectionModel section, TrainSegmentModel segment, DocumentExportOptions options, SectionMetrics sectionMetrics, 
            bool reverseLocationOrder, double xCoord, double yCoord)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            UniTextSize currentDims;
            LocationCollection locationMap = section.LocationMap;
            LocationBoxDimensions locationDims = sectionMetrics.LocationMetrics;
            double currentYCoord = yCoord + sectionMetrics.HeaderHeight;
            double segmentWidth = sectionMetrics.ColumnWidth;

            // Write timing points
            foreach (var timingPoint in segment.Timings)
            {
                IFontDescriptor selectedFont;
                if (timingPoint.EntryType == TrainLocationTimeEntryType.Time)
                {
                    DrawTimingPoint(timingPoint as TrainLocationTimeModel, xCoord, segmentWidth, currentYCoord, locationDims);
                    continue;
                }
                else if (timingPoint.EntryType == TrainLocationTimeEntryType.RoutingCode)
                {
                    selectedFont = _alternativeLocationFont; // FIXME make this a more sensible name.
                }
                else
                {
                    selectedFont = _boldBodyFont;
                }

                currentDims = _currentPage.PageGraphics.MeasureString(timingPoint.DisplayedText, selectedFont);

                WritingWrapper(timingPoint.DisplayedText, selectedFont, xCoord + (segmentWidth - currentDims.Width) / 2,
                    currentYCoord + locationDims.LocationOffsets[timingPoint.LocationKey].Baseline);
            }

            // Draw continuation arrows if needed
            List<string> locationsInSegment = segment.Timings.Select(t => t.LocationKey).ToList();
            List<TextVerticalLocation> offsetList = null;
            if (segment.ContinuationFromEarlier)
            {
                offsetList = sectionMetrics.LocationMetrics.LocationOffsetList;
                DrawContinuationArrow(segment.Timings.First(), offsetList, sectionMetrics.LocationMetrics.LocationOffsets, locationsInSegment, _leftPointingArrow, 
                    xCoord, currentYCoord);
            }
            if (segment.ContinuesLater)
            {
                if (offsetList == null)
                {
                    offsetList = sectionMetrics.LocationMetrics.LocationOffsetList;
                }
                DrawContinuationArrow(segment.Timings.Last(), offsetList, sectionMetrics.LocationMetrics.LocationOffsets, locationsInSegment, _rightPointingArrow,
                    xCoord, currentYCoord);
            }

            // If there is an inline note to display, work out the position of the largest empty block...
            UniRange largestEmptyBlock = new UniRange(0, 0);
            if (!string.IsNullOrWhiteSpace(segment.InlineNote))
            {
                largestEmptyBlock = FindLargestEmptyBlock(segment, locationDims);                

                // Write the inline note into the largest empty block.
                Paragraph para = new Paragraph(largestEmptyBlock.Size, sectionMetrics.ColumnWidth, Unicorn.Orientation.RotatedRight, HorizontalAlignment.Centred, 
                    VerticalAlignment.Centred, new MarginSet(2));
                para.AddText(segment.InlineNote, _plainBodyFont, _currentPage.PageGraphics);
                // If the paragraph fits within the empty block, draw it.  If not, widen the column and draw the note to the right of the train data.
                if (!para.OverspillHeight)
                {
                    para.DrawAt(_currentPage.PageGraphics, xCoord, currentYCoord + largestEmptyBlock.Start);
                    // Recompute start and end of "empty block", reducing it to just the size of the note.
                    double blockMidpoint = largestEmptyBlock.Start + (largestEmptyBlock.Size / 2);
                    double halfNewBlockWidth = para.ContentWidth / 2 + LineOffset;
                    largestEmptyBlock = new UniRange(blockMidpoint - halfNewBlockWidth, blockMidpoint + halfNewBlockWidth);
                }
                else
                {
                    para = new Paragraph(sectionMetrics.LocationMetrics.TotalSize.Height, null, Unicorn.Orientation.RotatedRight, HorizontalAlignment.Centred, 
                        VerticalAlignment.Centred, new MarginSet(0.75));
                    para.AddText(segment.InlineNote, _plainBodyFont, _currentPage.PageGraphics);
                    para.DrawAt(_currentPage.PageGraphics, xCoord + sectionMetrics.ColumnWidth, currentYCoord);
                    segmentWidth += para.ComputedHeight;
                    // Ensure filler dots are written everywhere required.
                    largestEmptyBlock = new UniRange(0, 0);
                }
            }

            // Separator line between this segment and the next
            LineDrawingWrapper("separator", xCoord + segmentWidth + LineOffset, yCoord + lineGapSize, xCoord + segmentWidth + LineOffset,
                currentYCoord + locationDims.TotalSize.Height + sectionMetrics.ToWorkHeight + sectionMetrics.LocoToWorkHeight - lineGapSize, MainLineWidth);
            
            UniTextSize fillerDims = _currentPage.PageGraphics.MeasureString(Resources.RowEmptyCellFiller, _plainBodyFont);
            UniTextSize alternateFillerDims = _currentPage.PageGraphics.MeasureString(Resources.RowEmptyCellAlternateFiller, _plainBodyFont);
            int firstIndex;
            int lastIndex;
            firstIndex = section.Locations.IndexOf(section.Locations.First(l => locationsInSegment.Contains(l.LocationKey)));
            lastIndex = section.Locations.IndexOf(section.Locations.Last(l => locationsInSegment.Contains(l.LocationKey)));
            for (int i = 0; i < section.Locations.Count; ++i) 
            {
                LocationDisplayModel loc = section.Locations[i];
                if (locationsInSegment.Contains(loc.LocationKey))
                {
                    continue;
                }
                
                // Do not include filler dots for routing code rows.
                if (loc.IsRoutingCodeRow)
                {
                    Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_RowIsARoutingCodeRow, loc.LocationKey);
                    continue;
                }

                Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_RowIsNotARoutingCodeRow, loc.LocationKey);
                if (string.IsNullOrWhiteSpace(segment.InlineNote) ||
                    locationDims.LocationOffsets[loc.LocationKey].ClearanceBottom < largestEmptyBlock.Start ||
                    locationDims.LocationOffsets[loc.LocationKey].ClearanceTop >= largestEmptyBlock.End)
                {
                    if (i < firstIndex || i > lastIndex)
                    {
                        double stringWidth = locationDims.LocationParity[loc.LocationKey] ? fillerDims.Width : alternateFillerDims.Width;
                        Log.Trace("Inserting filler for {0} at {1}, {2}", loc, xCoord + (sectionMetrics.ColumnWidth - stringWidth) / 2, 
                            currentYCoord + locationDims.LocationOffsets[loc.LocationKey].Baseline);
                        _currentPage.PageGraphics.DrawString(
                            locationDims.LocationParity[loc.LocationKey] ? Resources.RowEmptyCellFiller : Resources.RowEmptyCellAlternateFiller, _plainBodyFont,
                            xCoord + (sectionMetrics.ColumnWidth - stringWidth) / 2, currentYCoord + locationDims.LocationOffsets[loc.LocationKey].Baseline);
                    }
                    else
                    {
                        double dashWidth = sectionMetrics.ColumnWidth * 0.6;
                        double dashOffset = sectionMetrics.ColumnWidth * 0.2;
                        double xc = xCoord + dashOffset;
                        double yc = currentYCoord + locationDims.LocationOffsets[loc.LocationKey].TextMidLine;
                        LineDrawingWrapper("filler line", xc, yc, xc + dashWidth, yc, PassingTrainDashWidth);
                    }
                }
            }

            foreach (double separatorOffset in locationDims.LocationSeparatorOffsets)
            {
                if (string.IsNullOrWhiteSpace(segment.InlineNote) || separatorOffset <= largestEmptyBlock.Start || separatorOffset >= largestEmptyBlock.End)
                {
                    LineDrawingWrapper("location separator", xCoord + lineGapSize, currentYCoord + separatorOffset, 
                        (xCoord + sectionMetrics.ColumnWidth) - lineGapSize, currentYCoord + separatorOffset, MainLineWidth);
                }
            }

            if (segment.IncludeSeparatorAbove && 
                segment.Timings[0].LocationKey.StripArrivalDepartureSuffix() != locationMap[reverseLocationOrder ? locationMap.Count - 1 : 0].Id)
            {
                double separatorY = currentYCoord + locationDims.LocationOffsets[segment.Timings[0].LocationKey].ClearanceTop - LineOffset;
                LineDrawingWrapper("segment start separator", xCoord + lineGapSize, separatorY, xCoord + sectionMetrics.ColumnWidth - lineGapSize, separatorY, 
                    MainLineWidth);
            }

            if (segment.IncludeSeparatorBelow && 
                segment.Timings[segment.Timings.Count - 1].LocationKey.StripArrivalDepartureSuffix() != locationMap[reverseLocationOrder ? 0 : locationMap.Count - 1].Id)
            {
                double separatorY = currentYCoord + locationDims.LocationOffsets[segment.Timings[segment.Timings.Count - 1].LocationKey].Bottom + LineOffset;
                LineDrawingWrapper("segment end separator", xCoord + lineGapSize, separatorY, xCoord + sectionMetrics.ColumnWidth - lineGapSize, separatorY, 
                    MainLineWidth);
            }

            // Write train class
            currentYCoord = yCoord;
            currentDims = _currentPage.PageGraphics.MeasureString(segment.TrainClass, _boldBodyFont);
            WritingWrapper(segment.TrainClass, _boldBodyFont, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + currentDims.HeightAboveBaseline);
            currentYCoord += currentDims.LineHeight + MainLineWidth;

            // Write diagram/headcode
            LineDrawingWrapper("separator", xCoord + lineGapSize, currentYCoord - LineOffset, (xCoord + segmentWidth) - lineGapSize, currentYCoord - LineOffset, 
                MainLineWidth);
            currentDims = _currentPage.PageGraphics.MeasureString(segment.Headcode, _boldBodyFont);
            WritingWrapper(segment.Headcode, _boldBodyFont, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + currentDims.HeightAboveBaseline);
            currentYCoord += currentDims.LineHeight;

            // Write loco diagram
            if (sectionMetrics.IncludeLocoDiagramRow)
            {
                currentDims = _currentPage.PageGraphics.MeasureString(segment.LocoDiagram, _boldBodyFont);
                WritingWrapper(segment.LocoDiagram, _boldBodyFont, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + currentDims.HeightAboveBaseline);
                currentYCoord += currentDims.LineHeight;
            }
            else
            {
                Log.Trace("Skipping loco diagram field.");
            }

            // Write header footnote row
            if (sectionMetrics.HeaderIncludesFootnoteRow)
            {
                currentDims = _currentPage.PageGraphics.MeasureString(segment.Footnotes, _boldBodyFont);
                WritingWrapper(segment.Footnotes, _boldBodyFont, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + currentDims.HeightAboveBaseline);
                currentYCoord += currentDims.LineHeight + MainLineWidth;
            }

            // Write am/pm indicator
            LineDrawingWrapper(LogMessageResources.LogMessage_DrawingSeparator, xCoord + lineGapSize, currentYCoord - LineOffset, 
                (xCoord + segmentWidth) - lineGapSize, currentYCoord - LineOffset, MainLineWidth);
            currentDims = _currentPage.PageGraphics.MeasureString(segment.HalfOfDay, _plainBodyFont);
            WritingWrapper(segment.HalfOfDay, _plainBodyFont, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + currentDims.HeightAboveBaseline);
            currentYCoord += currentDims.LineHeight + MainLineWidth;

            // Draw separator line between header and timing points.
            LineDrawingWrapper("separator", xCoord + lineGapSize, currentYCoord - LineOffset, (xCoord + segmentWidth) - lineGapSize, currentYCoord - LineOffset, 
                MainLineWidth);

            // Write "Loco to work"
            if (sectionMetrics.IncludeLocoToWorkRow)
            {
                double yc = currentYCoord + locationDims.TotalSize.Height;
                LineDrawingWrapper("separator line", xCoord + lineGapSize, yc - LineOffset, xCoord + segmentWidth - lineGapSize, yc - LineOffset, MainLineWidth);
                if (!string.IsNullOrWhiteSpace(segment.LocoToWorkCell?.DisplayedText))
                {
                    currentDims = _currentPage.PageGraphics.MeasureString(segment.LocoToWorkCell.DisplayedText, _plainBodyFont);
                    double xc = xCoord + (segmentWidth - currentDims.Width) / 2;
                    yc += currentDims.HeightAboveBaseline;
                    WritingWrapper(segment.LocoToWorkCell.DisplayedText, _plainBodyFont, xc, yc);
                }
            }

            // Write "Set to work"
            if (sectionMetrics.IncludeToWorkRow)
            {
                double yc = currentYCoord + locationDims.TotalSize.Height + sectionMetrics.LocoToWorkHeight;
                LineDrawingWrapper("separator line", xCoord + lineGapSize, yc - LineOffset, xCoord + segmentWidth - lineGapSize, yc - LineOffset, MainLineWidth);
                if (!string.IsNullOrWhiteSpace(segment.ToWorkCell?.DisplayedText))
                {
                    currentDims = _currentPage.PageGraphics.MeasureString(segment.ToWorkCell.DisplayedText, _plainBodyFont);
                    double xc = xCoord + (segmentWidth - currentDims.Width) / 2;
                    yc += currentDims.HeightAboveBaseline;
                    WritingWrapper(segment.ToWorkCell.DisplayedText, _plainBodyFont, xc, yc);
                }
            }

            return segmentWidth + MainLineWidth;
        }

        private void DrawContinuationArrow(ILocationEntry nearestTimingPoint, List<TextVerticalLocation> offsetList, Dictionary<string, TextVerticalLocation> offsetDict, List<string> keyList,
            HorizontalArrow arrow, double xc, double yc)
        {
            int dir = arrow.Direction == HorizontalDirection.ToLeft ? -1 : 1;
            int tpIndex = offsetList.IndexOf(offsetDict[nearestTimingPoint.LocationKey]);
            if ((dir == -1 && tpIndex == 0) || (dir == 1 && tpIndex == offsetList.Count - 1))
            {
                return;
            }
            tpIndex += dir;
            arrow.DrawAt(_currentPage.PageGraphics, xc + _arrowHOffset, yc + offsetList[tpIndex].TextBodyMidLine);
            keyList.Add(offsetDict.First(o => o.Value == offsetList[tpIndex]).Key);
        }

        private UniRange FindLargestEmptyBlock(TrainSegmentModel segment, LocationBoxDimensions locationDims)
        {
            double startLargestEmptyBlock = 0;
            double endLargestEmptyBlock = 0;
            double startCurrentEmptyBlock = 0;
            double endCurrentEmptyBlock = 0;
            double largestBlockSize = 0;
            bool inEmptyBlock = false;
            foreach (KeyValuePair<string, TextVerticalLocation> item in locationDims.LocationOffsets.OrderBy(d => d.Value.Top))
            {
                if (segment.Timings.Any(t => t.LocationKey == item.Key))
                {
                    if (inEmptyBlock)
                    {
                        if (endCurrentEmptyBlock - startCurrentEmptyBlock > largestBlockSize)
                        {
                            startLargestEmptyBlock = startCurrentEmptyBlock;
                            endLargestEmptyBlock = endCurrentEmptyBlock;
                            largestBlockSize = endLargestEmptyBlock - startLargestEmptyBlock;
                        }
                        inEmptyBlock = false;
                    }
                }
                else
                {
                    if (!inEmptyBlock)
                    {
                        startCurrentEmptyBlock = item.Value.ClearanceTop;
                        inEmptyBlock = true;
                    }
                    endCurrentEmptyBlock = item.Value.Bottom;
                }
            }
            if (inEmptyBlock && endCurrentEmptyBlock - startCurrentEmptyBlock > largestBlockSize)
            {
                startLargestEmptyBlock = startCurrentEmptyBlock;
                endLargestEmptyBlock = endCurrentEmptyBlock;
                largestBlockSize = endLargestEmptyBlock - startLargestEmptyBlock;
            }

            // FIXME The addition of MainLineWidth here is something of a hack.  It is only *needed* if the block is below the final timing point and a separator line
            // has been inserted; or if the block is above the first timing point and a separator line has been inserted.  In both cases we need to allow for the 
            // separator line when marking out the block.  However, they can't *both* be needed, and often neither will be!
            // See GitHub issue #210.
            return new UniRange(startLargestEmptyBlock + MainLineWidth, endLargestEmptyBlock - MainLineWidth);
        }

        private Line MakeLineForTimingPoint(TrainLocationTimeModel timingPoint)
        {
            IFontDescriptor timeFont = timingPoint.IsPassingTime ? _italicBodyFont : _boldBodyFont;
            Line timingPointLine = new Line(new[]
            {
                new Word(timingPoint.DisplayedTextHours, timeFont, _currentPage.PageGraphics, 0),
                new Word(timingPoint.DisplayedTextFootnote, _alternativeLocationFont, _currentPage.PageGraphics, 0),
                new Word(timingPoint.DisplayedTextMinutes, timeFont, _currentPage.PageGraphics, 0),
            });
            return timingPointLine;
        }

        private void DrawTimingPoint(TrainLocationTimeModel timingPoint, double xCoord, double columnWidth, double baseYCoord, LocationBoxDimensions locationDims)
        {
            Line tpl = MakeLineForTimingPoint(timingPoint);
            tpl.DrawAt(_currentPage.PageGraphics, xCoord + (columnWidth - tpl.MinWidth) / 2, baseYCoord + locationDims.LocationOffsets[timingPoint.LocationKey].Top);
        }

        private void DrawLocationList(TimetableSectionModel timetableSection, LocationBoxDimensions locationDims, double xCoord, double yCoord)
        {
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_DrawingLocationList, _plainBodyFont.Ascent);
            foreach (double separatorOffset in locationDims.LocationSeparatorOffsets)
            {
                LineDrawingWrapper("location separator", xCoord + lineGapSize, yCoord + separatorOffset, xCoord + locationDims.TotalSize.Width - lineGapSize, 
                    yCoord + separatorOffset, MainLineWidth);
            }
            double xc1, yc1;
            for (int i = 0; i < timetableSection.Locations.Count; ++i)
            {
                LocationDisplayModel loc = timetableSection.Locations[i];
                IFontDescriptor locationFont = SwitchFont(loc);
                UniTextSize labelSize = _currentPage.PageGraphics.MeasureString(loc.ArrivalDepartureLabel ?? string.Empty, _plainBodyFont);
                double locationXCoord = xCoord + _locationListMargins;
                double labelXCoord = xCoord + locationDims.TotalSize.Width - (labelSize.Width + _locationListMargins);
                string locationLabel;
                if (!loc.IsRoutingCodeRow && locationDims.LocationFillerDotCounts.ContainsKey(loc.LocationKey) && 
                    locationDims.LocationFillerDotCounts[loc.LocationKey] > 0)
                {
                    locationLabel = AppendFillerDots(loc.ExportDisplayName, locationDims.LocationFillerDotCounts[loc.LocationKey]);
                }
                else
                {
                    locationLabel = loc.ExportDisplayName;
                }
                xc1 = locationXCoord;
                yc1 = yCoord + locationDims.LocationOffsets[loc.LocationKey].Baseline;
                WritingWrapper(locationLabel ?? "", locationFont, xc1, yc1);
                xc1 = labelXCoord;
                WritingWrapper(loc.ArrivalDepartureLabel ?? "", _plainBodyFont, xc1, yc1);
            }
        }

        private void DrawLocationDistanceColumn(TimetableSectionModel timetableSection, LocationBoxDimensions locationDims, double xCoord, double yCoord, double yTop)
        {
            double xLeft = xCoord + lineGapSize;
            double xRight = xCoord + locationDims.LeftOffset - lineGapSize;
            LineDrawingWrapper("Top of mileage column values", xLeft, yCoord - MainLineWidth / 2, xRight, yCoord - MainLineWidth / 2, MainLineWidth);
            double yTopLine = yCoord - (_plainBodyFont.EmptyStringMetrics.LineHeight + MainLineWidth * 1.5);
            LineDrawingWrapper("Top of mileage column", xLeft, yTopLine, xRight, yTopLine, MainLineWidth);
            foreach (double separatorOffset in locationDims.LocationSeparatorOffsets)
            {
                LineDrawingWrapper("location mileage separator", xLeft, yCoord + separatorOffset, xRight, yCoord + separatorOffset, MainLineWidth);
            }
            IEnumerable<string> locationIds = timetableSection.Locations.Select(c => c.LocationId).Distinct();
            Distance baseDistance = timetableSection.Locations.First(loc => loc.LocationId == locationIds.First()).Mileage;
            foreach (string locationId in locationIds)
            {
                LocationDisplayModel location = timetableSection.Locations.First(loc => loc.LocationId == locationId);
                Distance locationDistance = Distance.Difference(baseDistance, location.Mileage);
                double yc = yCoord + locationDims.LocationOffsets[location.LocationKey].Baseline;
                DrawLocationDistance(locationDistance.Mileage, xCoord, yc, locationDims.MajorDistanceColumnWidth);
                DrawLocationDistance((int)locationDistance.Chainage, xCoord + locationDims.MajorDistanceColumnWidth, yc, locationDims.MinorDistanceColumnWidth);
            }

            DrawLocationDistanceLabel(Distance.MajorLabel, xCoord, yCoord, locationDims.MajorDistanceColumnWidth);
            DrawLocationDistanceLabel(Distance.MinorLabel, xCoord + locationDims.MajorDistanceColumnWidth, yCoord, locationDims.MinorDistanceColumnWidth);
            xRight = xCoord + locationDims.LeftOffset + MainLineWidth / 2;
            LineDrawingWrapper("distance column right edge", xRight, yTop + lineGapSize, xRight, yCoord + locationDims.TotalSize.Height - lineGapSize, MainLineWidth);
        }

        private void DrawLocationDistanceLabel(string label, double xc, double yc, double columnWidth)
        {
            UniTextSize labelSize = _currentPage.PageGraphics.MeasureString(label, _plainBodyFont);
            WritingWrapper(label, _plainBodyFont, xc + (columnWidth - labelSize.Width) / 2, yc - (MainLineWidth + labelSize.HeightBelowBaseline));
        }

        private void DrawLocationDistance(int value, double xc, double yc, double columnWidth)
        {
            string distance = value.ToString(CultureInfo.InvariantCulture);
            UniTextSize distanceSize = _currentPage.PageGraphics.MeasureString(distance, _plainBodyFont);
            double xAdj = xc + (columnWidth - distanceSize.Width) / 2;
            WritingWrapper(distance, _plainBodyFont, xAdj, yc);
        }

        private void LineDrawingWrapper(string descr, double x1, double y1, double x2, double y2, double width)
        {
            Log.Trace(CultureInfo.CurrentCulture, "Drawing {0} from {1}, {2} to {3}, {4} (width {5})", descr, x1, y1, x2, y2, width);
            _currentPage.PageGraphics.DrawLine(x1, y1, x2, y2, width);
        }

        private void WritingWrapper(string text, IFontDescriptor font, double x, double y)
        {
            Log.Trace("Writing \"{0}\" at {1}, {2}", text, x, y);
            _currentPage.PageGraphics.DrawString(text, font, x, y);
        }

        private void WritingWrapper(string text, IFontDescriptor font, UniRectangle boundingBox, HorizontalAlignment hAlign, VerticalAlignment vAlign)
        {
            Log.Trace(CultureInfo.CurrentCulture, "Writing \"{0}\" within box at ({1}, {2}) dims {3}x{4}", text, boundingBox.MinX, boundingBox.MinY, boundingBox.Width, 
                boundingBox.Height);
            _currentPage.PageGraphics.DrawString(text, font, boundingBox, hAlign, vAlign);
        }

        private void DrawToWorkRowHeader(SectionMetrics metrics, double xCoord, double yCoord)
        {
            if (!metrics.IncludeToWorkRow)
            {
                return;
            }

            DrawRowHeader(metrics, xCoord, yCoord, metrics.IncludeLocoToWorkRow ? Resources.SetToWorkRowCaption : Resources.ToWorkRowCaption, "To Work row header");
        }

        private void DrawLocoToWorkRowHeader(SectionMetrics metrics, double xCoord, double yCoord)
        {
            if (!metrics.IncludeLocoToWorkRow)
            {
                return;
            }

            DrawRowHeader(metrics, xCoord, yCoord, Resources.LocoToWorkRowCaption, "Loco To Work row header");
        }

        private void DrawRowHeader(SectionMetrics metrics, double xCoord, double yCoord, string headerText, string logMessage)
        {
            LineDrawingWrapper(logMessage, xCoord + MainLineWidth + lineGapSize, yCoord - LineOffset, 
                xCoord + MainLineWidth + metrics.LocationMetrics.TotalSize.Width + 
                (metrics.DisplayDistanceColumn ? metrics.LocationMetrics.LeftOffset + MainLineWidth : 0) - lineGapSize, yCoord - LineOffset, MainLineWidth);
            yCoord += _plainBodyFont.EmptyStringMetrics.HeightAboveBaseline;
            double headerXCoord = xCoord + MainLineWidth + _locationListMargins;
            _currentPage.PageGraphics.DrawString(headerText, _plainBodyFont, headerXCoord, yCoord);
        }

        private static string AppendFillerDots(string lbl, int count)
        {
            StringBuilder builder = new StringBuilder(lbl);
            for (int i = 0; i < count; ++i)
            {
                builder.Append(Resources.LocationFillerDotPattern);
            }
            return builder.ToString();
        }

        private LocationBoxDimensions MeasureLocationList(TimetableSectionModel timetableSection)
        {
            var dimensions = new LocationBoxDimensions();
            double totalHeight = 0;
            double maxWidth = 0;
            string widestId = string.Empty;
            bool parity = false;
            bool setLineAbove = false;
            IFontDescriptor locationFont;
            Distance baseDistance = timetableSection.Locations.Select(loc => loc.Mileage).Min();
            for (int i = 0; i < timetableSection.Locations.Count; ++i)
            {
                LocationDisplayModel loc = timetableSection.Locations[i];
                locationFont = SwitchFont(loc);

                // If the location has a separator line above it, that has not already been accounted for, leave space for it.
                if (loc.DisplaySeparatorAbove && !setLineAbove)
                {
                    totalHeight += MainLineWidth;
                }

                Distance distanceOffset = Distance.Difference(baseDistance, loc.Mileage);
                double distanceWidth = MeasureDistanceColumnWidth(distanceOffset.Mileage);
                if (dimensions.MajorDistanceColumnWidth < distanceWidth)
                {
                    dimensions.MajorDistanceColumnWidth = distanceWidth;
                }
                distanceWidth = MeasureDistanceColumnWidth((int)Math.Round(distanceOffset.Chainage));
                if (dimensions.MinorDistanceColumnWidth < distanceWidth)
                {
                    dimensions.MinorDistanceColumnWidth = distanceWidth;
                }

                UniTextSize locationSize = _currentPage.PageGraphics.MeasureString(loc.ExportDisplayName ?? "", locationFont);
                UniTextSize labelSize = _currentPage.PageGraphics.MeasureString(loc.ArrivalDepartureLabel ?? "", _plainBodyFont);
                UniTextSize locationSizeInPlainFont = 
                    (locationFont == _plainBodyFont) ? locationSize : _currentPage.PageGraphics.MeasureString(loc.ExportDisplayName, _plainBodyFont);
                Log.Trace(CultureInfo.InvariantCulture, "Location dimensions for {0}: Width {1}, HAB {2}, MHAB {3}, HBB {4}, MHBB {5}", loc.ExportDisplayName,
                    locationSize.Width, locationSize.HeightAboveBaseline, locationSize.MaxHeightAboveBaseline, locationSize.HeightBelowBaseline,
                    locationSize.MaxHeightBelowBaseline);
                double baselineOffset = 
                    labelSize.MaxHeightAboveBaseline > locationSize.MaxHeightAboveBaseline ? labelSize.MaxHeightAboveBaseline : locationSize.MaxHeightAboveBaseline;
                double lineTopOffset = 
                    labelSize.HeightAboveBaseline > locationSize.HeightAboveBaseline ? labelSize.HeightAboveBaseline : locationSize.HeightAboveBaseline;
                double lineDescenderHeight =
                    labelSize.HeightBelowBaseline > locationSize.HeightBelowBaseline ? labelSize.HeightBelowBaseline : locationSize.HeightBelowBaseline;
                double descenderHeight = 
                    labelSize.MaxHeightBelowBaseline > locationSize.MaxHeightBelowBaseline ? labelSize.MaxHeightBelowBaseline : locationSize.MaxHeightBelowBaseline;
                double locationHeight = baselineOffset + descenderHeight;
                TextVerticalLocation tvl = new TextVerticalLocation(totalHeight, totalHeight + (baselineOffset - lineTopOffset), totalHeight + baselineOffset, 
                    totalHeight + baselineOffset + lineDescenderHeight, totalHeight + locationHeight);
                dimensions.LocationOffsets.Add(loc.LocationKey, tvl);
                dimensions.LocationParity.Add(loc.LocationKey, parity);
                parity = !parity;

                totalHeight += locationHeight;

                // If the location has a separator line below it, leave space for it.
                if (loc.DisplaySeparatorBelow)
                {
                    totalHeight += MainLineWidth;
                    setLineAbove = true;
                }
                else
                {
                    setLineAbove = false;
                }

                if (locationSize.Width + labelSize.Width > maxWidth)
                {
                    maxWidth = locationSize.Width + labelSize.Width;
                    widestId = loc.LocationKey;
                }
                if (i > 0 && loc.DisplaySeparatorAbove)
                {
                    dimensions.LocationSeparatorOffsets.Add(tvl.ClearanceTop - LineOffset);
                }
                if (i < timetableSection.Locations.Count - 1 && loc.DisplaySeparatorBelow && !timetableSection.Locations[i + 1].DisplaySeparatorAbove)
                {
                    dimensions.LocationSeparatorOffsets.Add(tvl.Bottom + LineOffset);
                }
            }
            foreach (var loc in timetableSection.Locations.Where(l => l.LocationKey != widestId))
            {
                int ctr = 0;
                string lbl = loc.ExportDisplayName;
                double lblWidth = _currentPage.PageGraphics.MeasureString(lbl, _plainBodyFont).Width;
                while (lblWidth < maxWidth)
                {
                    ctr++;
                    lbl += " .";
                    lblWidth = _currentPage.PageGraphics.MeasureString(lbl, _plainBodyFont).Width;
                }
                dimensions.LocationFillerDotCounts.Add(loc.LocationKey, --ctr);
            }

            dimensions.TotalSize = new UniSize(maxWidth + _locationListMargins * 2 + _locationListMinimumColumnGap, totalHeight);
            return dimensions;
        }

        private double MeasureDistanceColumnWidth(int d)
        {
            return _currentPage.PageGraphics.MeasureString($"0{d}0", _plainBodyFont).Width;
        }

        private IFontDescriptor SwitchFont(LocationDisplayModel loc)
        {
            switch (loc.FontType)
            {
                case LocationFontType.Normal:
                default:
                    return _plainBodyFont;
                case LocationFontType.Condensed:
                    return _alternativeLocationFont;
            }
        }

        private double MeasureMaximumCellWidth(TimetableSectionModel timetableSection, DocumentExportOptions options)
        {
            double maxWidth = 0;
            foreach (var segment in timetableSection.TrainSegments)
            {
                double width = _currentPage.PageGraphics.MeasureString(segment.TrainClass, _plainBodyFont).Width;
                if (width > maxWidth)
                {
                    maxWidth = width;
                }
                if (options.DisplayLocoDiagramRow)
                {
                    width = _currentPage.PageGraphics.MeasureString(segment.LocoDiagram, _boldBodyFont).Width;
                    if (width > maxWidth)
                    {
                        maxWidth = width;
                    }
                }
                width = _currentPage.PageGraphics.MeasureString(segment.Footnotes, _plainBodyFont).Width;
                if (width > maxWidth)
                {
                    maxWidth = width;
                }
                width = _currentPage.PageGraphics.MeasureString(segment.Headcode, _plainBodyFont).Width;
                if (width > maxWidth)
                {
                    maxWidth = width;
                }
                width = _currentPage.PageGraphics.MeasureString(segment.HalfOfDay, _plainBodyFont).Width;
                if (width > maxWidth)
                {
                    maxWidth = width;
                }
                foreach (var timingPoint in segment.Timings)
                {
                    IFontDescriptor selectedFont;
                    if (timingPoint.EntryType == TrainLocationTimeEntryType.Time)
                    {
                        Line tpl = MakeLineForTimingPoint(timingPoint as TrainLocationTimeModel);
                        width = tpl.MinWidth;
                    }
                    else
                    {
                        if (timingPoint.EntryType == TrainLocationTimeEntryType.RoutingCode)
                        {
                            selectedFont = _alternativeLocationFont; // FIXME make this a more sensible name.
                        }
                        else
                        {
                            selectedFont = _boldBodyFont;
                        }
                        width = _currentPage.PageGraphics.MeasureString(timingPoint.DisplayedText, selectedFont).Width;
                    }
                    if (width > maxWidth)
                    {
                        maxWidth = width;
                    }
                }
                if (options.DisplayToWorkRow && !string.IsNullOrWhiteSpace(segment.ToWorkCell?.DisplayedText))
                {
                    width = _currentPage.PageGraphics.MeasureString(segment.ToWorkCell.DisplayedText, _plainBodyFont).Width;
                    if (width > maxWidth)
                    {
                        maxWidth = width;
                    }
                }
            }

            return maxWidth + cellTotalMargins;
        }

        private double MeasureHeaderHeight(TimetableSectionModel timetableSection, bool includeLocoDiagramRow)
        {
            double maxHeight = 0;
            foreach (var segment in timetableSection.TrainSegments)
            {
                // This accounts for the lines always present: train class, headcode and AM/PM.
                double height = _boldBodyFont.EmptyStringMetrics.LineHeight * 2 + _plainBodyFont.EmptyStringMetrics.LineHeight + MainLineWidth * 3;
                if (!string.IsNullOrWhiteSpace(segment.Footnotes))
                {
                    height += _boldBodyFont.EmptyStringMetrics.LineHeight;
                }
                if (includeLocoDiagramRow)
                {
                    height += _boldBodyFont.EmptyStringMetrics.LineHeight;
                }
                if (height > maxHeight)
                {
                    maxHeight = height;
                }
            }

            return maxHeight;
        }

        private double MeasureToWorkRowHeight()
        {
            return MeasureRowHeight();
        }

        private double MeasureLocoToWorkRowHeight()
        {
            return MeasureRowHeight() + MainLineWidth;
        }

        private double MeasureRowHeight() => _plainBodyFont.EmptyStringMetrics.LineHeight;

        private void ExportGlossary(IDocumentDescriptor doc, NoteCollection noteDefinitions)
        {
            StartPage(doc, PageOrientation.Portrait);
            double titleHeight = _subtitleFont.EmptyStringMetrics.LineHeight;
            WritingWrapper(Resources.GlossaryTitle, _subtitleFont, 
                new UniRectangle(_currentPage.LeftMarginPosition, _currentPage.TopMarginPosition, _currentPage.PageAvailableWidth, titleHeight),
                HorizontalAlignment.Centred, VerticalAlignment.Centred);
            List<Note> glossaryNotes = noteDefinitions
                .Where(n => n.DefinedInGlossary && !string.IsNullOrEmpty(n.Symbol) && !string.IsNullOrEmpty(n.Definition))
                .OrderBy(n => n.Symbol)
                .ToList();
            Table footnotesTable = new Table { RuleStyle = TableRuleStyle.None };
            MarginSet footnotesTableCellMargins = new MarginSet(0, 3, 0, 3);
            foreach (Note n in glossaryNotes) { 
                footnotesTable.AddRow(new PlainTextTableCell(n.Symbol, _alternativeLocationFont, footnotesTableCellMargins, _currentPage.PageGraphics),
                    new PlainTextTableCell(n.Definition, _plainBodyFont, footnotesTableCellMargins, _currentPage.PageGraphics));
            }
            footnotesTable.DrawAt(_currentPage.PageGraphics, _currentPage.LeftMarginPosition, _currentPage.TopMarginPosition + titleHeight * 2);
        }

        #region IDisposable Support
        private bool disposedValue; // To detect redundant calls

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="PdfExporter" /> and optionally releases the managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to only release unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _fontLoader?.Dispose();
                    _fontLoader = null;
                }
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        /// <summary>
        /// Releases all resources used by the <see cref="PdfExporter" />.
        /// </summary>
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
