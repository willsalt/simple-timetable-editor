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
using Unicorn.Impl.PdfSharp;
using Unicorn.Interfaces;
using Unicorn.Shapes;
using Timetabler.PdfExport.Interfaces;
using System.Globalization;

namespace Timetabler.PdfExport
{
    public class PdfExporter : IExporter
    {
        private readonly IDocumentDescriptorFactory _engineSelector;

        public double MainLineWidth { get; set; }
        public double PassingTrainDashWidth { get; set; }

        private const double lineGapSize = 2.0;
        private const double interSectionGapSize = 10.0;
        private const double graphTickLength = 5.0;
        private const double distanceTickLabelMargin = 2.0;
        private const double cellTotalMargins = 6.0;

#pragma warning disable CA1823 // Avoid unused private fields - this is done this way because of how the PdfSharp library likes to configure its fonts
        private static readonly FontConfigurator FontConfigurator = new FontConfigurator(new[]
#pragma warning restore CA1823 // Avoid unused private fields
        {
            new FontConfigurationData { Name = "Serif", Style = UniFontStyles.Regular, Filename = Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SerifRomanFace) },
            new FontConfigurationData { Name = "Serif", Style = UniFontStyles.Bold, Filename = Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SerifBoldFace) },
            new FontConfigurationData { Name = "Serif", Style = UniFontStyles.Italic, Filename = Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SerifItalicFace) },
            new FontConfigurationData { Name = "Serif", Style = UniFontStyles.Bold | UniFontStyles.Italic, Filename = Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SerifBoldItalicFace) },
            new FontConfigurationData { Name = "Sans", Style = UniFontStyles.Regular, Filename = Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SansRomanFace) },
            new FontConfigurationData { Name = "Sans", Style = UniFontStyles.Bold, Filename = Path.Combine(Properties.Settings.Default.FontFolder, Properties.Settings.Default.SansBoldFace) },
        });

        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        private readonly FontDescriptor _titleFont;
        private readonly FontDescriptor _subtitleFont;
        private readonly FontDescriptor _plainBodyFont;
        private readonly FontDescriptor _italicBodyFont;
        private readonly FontDescriptor _boldBodyFont;
        private readonly FontDescriptor _alternativeLocationFont;

        private HorizontalArrow _leftPointingArrow;
        private HorizontalArrow _rightPointingArrow;
        private double _arrowHOffset = cellTotalMargins / 2;

        private const double _locationListMargins = 3.0;
        private const double _locationListMinimumColumnGap = 2.5;
        private const double _defaultHorizontalMarginProportion = 0.06;
        private const double _defaultVerticalMarginProportion = 0.06;

        private IPageDescriptor _currentPage;

        public PdfExporter(IDocumentDescriptorFactory ddf)
        {
            _engineSelector = ddf;

            _titleFont = new FontDescriptor("Serif", UniFontStyles.Bold, 16);
            _subtitleFont = new FontDescriptor("Serif", UniFontStyles.Bold, 14);
            _plainBodyFont = new FontDescriptor("Serif", 7.5);
            _italicBodyFont = new FontDescriptor("Serif", UniFontStyles.Italic, 7.5);
            _boldBodyFont = new FontDescriptor("Serif", UniFontStyles.Bold, 7.5);
            _alternativeLocationFont = new FontDescriptor("Sans", UniFontStyles.Bold, 7.5);

            Log.Info("Loaded fonts.");
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_PlainBodyOffset, _plainBodyFont.Ascent);
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_ItalicBodyOffset, _italicBodyFont.Ascent);
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_BoldBodyOffset, _boldBodyFont.Ascent);

            MainLineWidth = 1.0;
            PassingTrainDashWidth = 0.5;
        }

        private void StartPage(IDocumentDescriptor doc)
        {
            _currentPage = doc.AppendPage();
        }

        private void StartPage(IDocumentDescriptor doc, PageOrientation orientation)
        {
            _currentPage = doc.AppendPage(orientation);
        }

        private int ComputeColumnsForSection(TimetableSectionModel entireSection, int startingColumn, SectionMetrics sectionMetrics)
        {
            double availableWidth = _currentPage.PageAvailableWidth - sectionMetrics.MainSectionMetrics.TotalSize.Width;
            int colsCounted = 0;
            while (availableWidth > 0 && startingColumn + colsCounted < entireSection.TrainSegments.Count)
            {
                availableWidth -= MeasureSegmentWidth(entireSection.TrainSegments[startingColumn + colsCounted++], sectionMetrics);
            }
            return availableWidth > 0 ? colsCounted : colsCounted - 1;
        }

        public void Export(TimetableDocument document, Stream outputStream)
        {
            if (document is null)
            {
                throw new ArgumentNullException(nameof(document));
            }

            IDocumentDescriptor doc = _engineSelector.GetDocumentDescriptor(_defaultHorizontalMarginProportion, _defaultVerticalMarginProportion);
            bool workNotFinished = true;
            while (workNotFinished)
            {
                StartPage(doc);
                bool firstOnPage = true;
                Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_PageMargins, _currentPage.TopMarginPosition, _currentPage.BottomMarginPosition, _currentPage.LeftMarginPosition, 
                    _currentPage.RightMarginPosition);
                            
                SectionMetrics sectionMetricsWithTitle = MeasureSectionMetrics(document.DownTrainsDisplay, document.ExportOptions, document.Title, document.Subtitle, document.DateDescription);
                SectionMetrics sectionMetricsWithNoTitle = sectionMetricsWithTitle.CopyWithNoTitle();
                SectionMetrics sectionMetrics = sectionMetricsWithTitle;

                int columnsPerPage;
                for (int i = 0; i < document.DownTrainsDisplay.TrainSegments.Count; i += columnsPerPage)
                {
                    columnsPerPage = ComputeColumnsForSection(document.DownTrainsDisplay, i, sectionMetrics);
                    Area footnotesForSection = LayOutFootnotesForSection(document.DownTrainsDisplay, i, columnsPerPage);
                    if (_currentPage.CurrentVerticalCursor + sectionMetrics.TotalHeight + footnotesForSection.Height > _currentPage.BottomMarginPosition)
                    {
                        StartPage(doc);
                        firstOnPage = true;
                        sectionMetrics = sectionMetricsWithTitle;
                    }
                    _currentPage.CurrentVerticalCursor += 
                        DrawSection(document.DownTrainsDisplay, false, document.ExportOptions, i, columnsPerPage, sectionMetrics, Resources.DownSectionName, firstOnPage, document.Title, document.Subtitle,
                            document.DateDescription, footnotesForSection, _currentPage.LeftMarginPosition, _currentPage.CurrentVerticalCursor, _currentPage.RightMarginPosition);
                    _currentPage.CurrentVerticalCursor += interSectionGapSize;

                    if (firstOnPage)
                    {
                        firstOnPage = false;
                        sectionMetrics = sectionMetricsWithNoTitle;
                    }
                }

                sectionMetricsWithTitle = MeasureSectionMetrics(document.UpTrainsDisplay, document.ExportOptions, document.Title, document.Subtitle, document.DateDescription);
                sectionMetricsWithNoTitle = sectionMetricsWithTitle.CopyWithNoTitle();
                sectionMetrics = firstOnPage ? sectionMetricsWithTitle : sectionMetricsWithNoTitle;
                
                for (int i = 0; i < document.UpTrainsDisplay.TrainSegments.Count; i += columnsPerPage)
                {
                    columnsPerPage = ComputeColumnsForSection(document.UpTrainsDisplay, i, sectionMetrics);
                    Area footnotesForSection = LayOutFootnotesForSection(document.UpTrainsDisplay, i, columnsPerPage);
                    if (_currentPage.CurrentVerticalCursor + sectionMetrics.TotalHeight + footnotesForSection.Height > _currentPage.BottomMarginPosition)
                    {
                        StartPage(doc);
                        firstOnPage = true;
                        sectionMetrics = sectionMetricsWithTitle;
                    }
                    _currentPage.CurrentVerticalCursor += 
                        DrawSection(document.UpTrainsDisplay, true, document.ExportOptions, i, columnsPerPage, sectionMetrics, Resources.UpSectionName, firstOnPage, document.Title, document.Subtitle,
                            document.DateDescription, footnotesForSection, _currentPage.LeftMarginPosition, _currentPage.CurrentVerticalCursor, _currentPage.RightMarginPosition);
                    _currentPage.CurrentVerticalCursor += interSectionGapSize;

                    if (!firstOnPage)
                    {
                        firstOnPage = false;
                        sectionMetrics = sectionMetricsWithNoTitle;
                    }
                }

                UniSize boxHoursSize = null;
                if ((document.ExportOptions?.DisplayBoxHours ?? true) && document.SignalboxHoursSets.Count > 0)
                {
                    Table hoursTable = new Table { RuleGapSize = lineGapSize, RuleStyle = TableRuleStyle.SolidColumnsBrokenRows };
                    MarginSet hoursTableCellMargins = new MarginSet(0, 3, 0, 3);
                    List<TableCell> cells = new List<TableCell>
                    {
                        new PlainTextTableCell(string.Empty, _plainBodyFont, _currentPage.PageGraphics)
                    };
                    foreach (var box in document.Signalboxes)
                    {
                        cells.Add(new PlainTextTableCell(box.Code, _boldBodyFont, hoursTableCellMargins, _currentPage.PageGraphics));
                    }
                    hoursTable.AddRow(cells);
                    foreach (var hoursSet in document.SignalboxHoursSets)
                    {
                        cells.Clear();
                        cells.Add(new PlainTextTableCell(hoursSet.Category, _plainBodyFont, hoursTableCellMargins, _currentPage.PageGraphics));
                        foreach (var box in document.Signalboxes)
                        {
                            string cellContent = hoursSet.Hours[box.Id].ToString(document.Options.ClockType);
                            cells.Add(new PlainTextTableCell(cellContent, _plainBodyFont, hoursTableCellMargins, _currentPage.PageGraphics));
                        }
                        hoursTable.AddRow(cells);
                    }

                    boxHoursSize = new UniSize(hoursTable.ComputedWidth, hoursTable.ComputedHeight);
                    hoursTable.DrawAt(_currentPage.PageGraphics, _currentPage.LeftMarginPosition, _currentPage.CurrentVerticalCursor);
                }

                if (document.ExportOptions.DisplayCredits)
                {
                    Table creditsTable = new Table { RuleGapSize = lineGapSize, RuleStyle = TableRuleStyle.SolidColumnsBrokenRows, RuleWidth = MainLineWidth };
                    MarginSet creditsTableCellMargins = new MarginSet(0, 3, 0, 3);
                    if (!string.IsNullOrWhiteSpace(document.WrittenBy))
                    {
                        creditsTable.AddRow(new PlainTextTableCell(Resources.WrittenByCaption, _plainBodyFont, creditsTableCellMargins, _currentPage.PageGraphics),
                            new PlainTextTableCell(document.WrittenBy, _plainBodyFont, creditsTableCellMargins, _currentPage.PageGraphics));
                    }
                    if (!string.IsNullOrWhiteSpace(document.CheckedBy))
                    {
                        creditsTable.AddRow(new PlainTextTableCell(Resources.CheckedByCaption, _plainBodyFont, creditsTableCellMargins, _currentPage.PageGraphics),
                            new PlainTextTableCell(document.CheckedBy, _plainBodyFont, creditsTableCellMargins, _currentPage.PageGraphics));
                    }
                    if (!string.IsNullOrWhiteSpace(document.TimetableVersion))
                    {
                        creditsTable.AddRow(new PlainTextTableCell(Resources.VersionCaption, _plainBodyFont, creditsTableCellMargins, _currentPage.PageGraphics),
                            new PlainTextTableCell(document.TimetableVersion, _plainBodyFont, creditsTableCellMargins, _currentPage.PageGraphics));
                    }
                    if (!string.IsNullOrWhiteSpace(document.PublishedDate))
                    {
                        creditsTable.AddRow(new PlainTextTableCell(Resources.PublishedDateCaption, _plainBodyFont, creditsTableCellMargins, _currentPage.PageGraphics),
                            new PlainTextTableCell(document.PublishedDate, _plainBodyFont, creditsTableCellMargins, _currentPage.PageGraphics));
                    }

                    if (boxHoursSize != null && creditsTable.ComputedWidth + boxHoursSize.Width > _currentPage.PageAvailableWidth)
                    {
                        _currentPage.CurrentVerticalCursor += boxHoursSize.Height + 1;
                    }
                    creditsTable.DrawAt(_currentPage.PageGraphics, _currentPage.RightMarginPosition - creditsTable.ComputedWidth, _currentPage.CurrentVerticalCursor);
                }

                if (document.ExportOptions.DisplayGraph)
                {
                    StartPage(doc);
                    DrawGraph(new TrainGraphModel(document.LocationList, document.TrainList) { DisplayTrainLabels = document.Options.DisplayTrainLabelsOnGraphs },
                        document.Title, document.Subtitle, document.DateDescription);
                }

                workNotFinished = false;
            }

            if (document.ExportOptions.DisplayGlossary)
            {
                ExportGlossary(doc, document.NoteDefinitions);
            }

            doc.Write(outputStream);
        }

        private void DrawGraph(TrainGraphModel trainGraphModel, string title, string subtitle, string dateDescription)
        {
            double titleHeight = title != null ? _currentPage.PageGraphics.MeasureString(title, _titleFont).Height : 0;
            double subtitleHeight = subtitle != null ? _currentPage.PageGraphics.MeasureString(subtitle, _subtitleFont).Height : 0;
            DrawTitleAndSubtitle(title, subtitle, dateDescription, _currentPage.LeftMarginPosition, lineGapSize * 2, _currentPage.CurrentVerticalCursor, 
                _currentPage.RightMarginPosition - _currentPage.LeftMarginPosition, titleHeight, subtitleHeight, false, 0, 0);
            _currentPage.CurrentVerticalCursor += titleHeight + subtitleHeight;

            double bottomLimit = _currentPage.BottomMarginPosition;
            double topLimit = _currentPage.CurrentVerticalCursor;
            double leftLimit = _currentPage.LeftMarginPosition;
            List<TrainGraphAxisTickInfo> timeAxisInfo = trainGraphModel.GetTimeAxisInformation().Select(i => { i.PopulateSize(_currentPage.PageGraphics, _plainBodyFont); return i; }).ToList();
            bottomLimit -= (timeAxisInfo.Max(i => i.Height).Value + graphTickLength);

            List<TrainGraphAxisTickInfo> distanceAxisInfo = trainGraphModel.GetDistanceAxisInformation().Select(i => { i.PopulateSize(_currentPage.PageGraphics, _plainBodyFont); return i; }).ToList();
            topLimit += distanceAxisInfo.Last().Height.Value / 2;
            leftLimit += distanceAxisInfo.Max(i => i.Width).Value + graphTickLength + distanceTickLabelMargin;

            LineDrawingWrapper("y-axis", leftLimit, topLimit, leftLimit, bottomLimit, MainLineWidth);
            LineDrawingWrapper("x-axis", leftLimit, bottomLimit, _currentPage.RightMarginPosition, bottomLimit, MainLineWidth);
            foreach (TrainGraphAxisTickInfo tick in distanceAxisInfo)
            {
                double y = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - tick.Coordinate);
                LineDrawingWrapper("horizontal grid line", _currentPage.RightMarginPosition, y, leftLimit - graphTickLength, y, MainLineWidth);
                Word tickWord = new Word(tick.Label, _plainBodyFont, _currentPage.PageGraphics, 0);
                tickWord.DrawAt(_currentPage.PageGraphics, leftLimit - (tick.Width.Value + graphTickLength + distanceTickLabelMargin), y - tick.Height.Value / 2);
            }

            foreach (TrainGraphAxisTickInfo tick in timeAxisInfo)
            {
                double x = CoordinateHelper.Stretch(leftLimit, _currentPage.RightMarginPosition, tick.Coordinate);
                LineDrawingWrapper("vertical grid line", x, topLimit, x, bottomLimit + graphTickLength, MainLineWidth);
                Word tickWord = new Word(tick.Label, _plainBodyFont, _currentPage.PageGraphics, 0);
                tickWord.DrawAt(_currentPage.PageGraphics, x - tick.Width.Value / 2, bottomLimit + graphTickLength);
            }

            foreach (TrainDrawingInfo info in trainGraphModel.GetTrainDrawingInformation())
            {
                foreach (LineCoordinates lineData in info.Lines)
                {
                    _currentPage.PageGraphics.DrawLine(CoordinateHelper.Stretch(leftLimit, _currentPage.RightMarginPosition, lineData.Vertex1.X),
                        CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - lineData.Vertex1.Y), CoordinateHelper.Stretch(leftLimit, _currentPage.RightMarginPosition, lineData.Vertex2.X),
                        CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - lineData.Vertex2.Y), info.Properties.Width, info.Properties.DashStyle.ToUniDashStyle());
                }

                if (trainGraphModel.DisplayTrainLabels && !string.IsNullOrWhiteSpace(info.Headcode))
                {
                    UniSize headcodeDimensions = _currentPage.PageGraphics.MeasureString(info.Headcode.Trim(), _plainBodyFont);
                    LineCoordinates longestLine = info.Lines[LineCoordinates.GetIndexOfLongestLine(info.Lines)];
                    double llX1 = CoordinateHelper.Stretch(leftLimit, _currentPage.RightMarginPosition, longestLine.Vertex1.X);
                    double llX2 = CoordinateHelper.Stretch(leftLimit, _currentPage.RightMarginPosition, longestLine.Vertex2.X);
                    double llY1 = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - longestLine.Vertex1.Y);
                    double llY2 = CoordinateHelper.Stretch(topLimit, bottomLimit, 1 - longestLine.Vertex2.Y);
                    UniPoint longestLineMidpoint = new UniPoint((llX1 + llX2) / 2, (llY1 + llY2) / 2);
                    IGraphicsState state = _currentPage.PageGraphics.Save();
                    _currentPage.PageGraphics.RotateAt(Math.Atan2(llY1 - llY2, llX1 - llX2) * (180.0 / Math.PI) + 180.0, longestLineMidpoint.X, longestLineMidpoint.Y);
                    Word headcode = new Word(info.Headcode, _plainBodyFont, _currentPage.PageGraphics, 0);
                    headcode.DrawAt(_currentPage.PageGraphics, longestLineMidpoint.X - (headcode.ContentWidth / 2), longestLineMidpoint.Y - (headcode.MinHeight + 2));
                    _currentPage.PageGraphics.Restore(state);
                }
            }
        }

        private SectionMetrics MeasureSectionMetrics(TimetableSectionModel section, DocumentExportOptions options, string title, string subtitle, string dateDescription)
        {
            var shm = new SectionMetrics
            {
                TitleHeight = _currentPage.PageGraphics.MeasureString(title ?? string.Empty, _titleFont).Height
            };
            double subtitleLeftHeight = _currentPage.PageGraphics.MeasureString(subtitle ?? string.Empty, _subtitleFont).Height;
            double subtitleRightHeight = _currentPage.PageGraphics.MeasureString(dateDescription ?? string.Empty, _subtitleFont).Height;
            shm.SubtitleHeight = subtitleLeftHeight > subtitleRightHeight ? subtitleLeftHeight : subtitleRightHeight;
            shm.MainSectionMetrics = MeasureLocationList(section);
            shm.IncludeLocoDiagramRow = options.DisplayLocoDiagramRow && section.TrainSegments.Any(s => !string.IsNullOrWhiteSpace(s.LocoDiagram));
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_IsLocoDiagramRowIncluded, shm.IncludeLocoDiagramRow);
            shm.IncludeToWorkRow = options.DisplayToWorkRow && section.TrainSegments.Any(s => !string.IsNullOrWhiteSpace(s.ToWorkCell?.DisplayedText));
            shm.ToWorkHeight = shm.IncludeToWorkRow ? MeasureToWorkRowHeight(section) : 0;
            shm.IncludeLocoToWorkRow = options.DisplayLocoToWorkRow && section.TrainSegments.Any(s => !string.IsNullOrWhiteSpace(s.LocoToWorkCell?.DisplayedText));
            shm.LocoToWorkHeight = shm.IncludeLocoToWorkRow ? MeasureLocoToWorkRowHeight(section) : 0;
            shm.HeaderHeight = MeasureHeaderHeight(section, shm.IncludeLocoDiagramRow);
            shm.HeaderIncludesFootnoteRow = section.TrainSegments.Any(t => !string.IsNullOrWhiteSpace(t.Footnotes));
            shm.ColumnWidth = MeasureMaximumCellWidth(section, options);
            MeasureArrows(shm.ColumnWidth - cellTotalMargins, shm.MainSectionMetrics.LocationOffsetList.Max(t => t.Bottom - t.Top));
            return shm;
        }

        private void MeasureArrows(double timingPointWidth, double timingPointHeight)
        {
            _leftPointingArrow = new HorizontalArrow(HorizontalDirection.ToLeft, timingPointWidth * 0.8, MainLineWidth, timingPointHeight / 3, timingPointWidth / 6, timingPointWidth / 24);
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
            List<PositionedLine> lines = relevantFootnotes.Select(n => n.ToPositionedLine(_currentPage.PageGraphics, _alternativeLocationFont, _plainBodyFont)).OrderBy(pl => pl.MinWidth).ToList();
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

        private double DrawSection(TimetableSectionModel section, bool reverseLocationOrder, DocumentExportOptions options, int startingColumn, int columnCount, SectionMetrics sectionMetrics, 
            string sectionName, bool includeTitleAndSubtitle, string title, string subtitle, string dateDescription, Area footnotes, double leftCoord, double topCoord, double rightCoord)
        {
            Log.Trace("Starting to draw section.  Coordinates: T {0}, L {1}, R {2}", topCoord, leftCoord, rightCoord);

            double maxWidth = rightCoord - leftCoord;
            double subtitleTop = topCoord + sectionMetrics.TitleHeight;
            double headerTop = topCoord + sectionMetrics.HeaderOffset;
            double mainSectionTop = topCoord + sectionMetrics.MainSectionOffset;

            Log.Trace(CultureInfo.CurrentCulture, "Width: {0}.  Subtitle Top: {1}, Header Top: {2}, Main Section Top: {3}", maxWidth, subtitleTop, headerTop, mainSectionTop);

            if (includeTitleAndSubtitle)
            {
                DrawTitleAndSubtitle(title, subtitle, dateDescription, leftCoord, lineGapSize * 2, topCoord, maxWidth, sectionMetrics.TitleHeight, sectionMetrics.SubtitleHeight, true,
                    lineGapSize * 2, headerTop);
            }

            Log.Trace(CultureInfo.CurrentCulture, "Drawing section bounding box: L{0} T{1} W{2} H{3}", leftCoord, subtitleTop, maxWidth, sectionMetrics.MainSectionBoundingHeight);
            _currentPage.PageGraphics.DrawRectangle(leftCoord, subtitleTop, maxWidth, sectionMetrics.MainSectionBoundingHeight, MainLineWidth);
            LineDrawingWrapper("subtitle-headings line", leftCoord + lineGapSize * 2, mainSectionTop, leftCoord + sectionMetrics.MainSectionMetrics.TotalSize.Width - lineGapSize * 2, mainSectionTop,
                MainLineWidth);
            var labelDims = _currentPage.PageGraphics.MeasureString(sectionName, _subtitleFont);
            WritingWrapper(sectionName, _subtitleFont, leftCoord + (sectionMetrics.MainSectionMetrics.TotalSize.Width - labelDims.Width) / 2,
                headerTop + _subtitleFont.Ascent + (sectionMetrics.HeaderHeight - labelDims.Height) / 2);
            int columnsPerPage = (int)((rightCoord - leftCoord - sectionMetrics.MainSectionMetrics.TotalSize.Width) / sectionMetrics.ColumnWidth);
            Log.Trace("I have computed {0} columns per page.  Available width is {1} and column width is {2}", columnsPerPage,
                rightCoord - leftCoord - sectionMetrics.MainSectionMetrics.TotalSize.Width, sectionMetrics.ColumnWidth);

            DrawLocationList(section, sectionMetrics.MainSectionMetrics, leftCoord, mainSectionTop);
            DrawLocoToWorkRowHeader(sectionMetrics, leftCoord, mainSectionTop + sectionMetrics.MainSectionMetrics.TotalSize.Height);
            DrawToWorkRowHeader(sectionMetrics, leftCoord, mainSectionTop + sectionMetrics.MainSectionMetrics.TotalSize.Height + sectionMetrics.LocoToWorkHeight);
            double columnLeft = leftCoord + sectionMetrics.MainSectionMetrics.TotalSize.Width;
            LineDrawingWrapper("initial separator", columnLeft, headerTop + lineGapSize, columnLeft,
                (headerTop + sectionMetrics.HeaderHeight + sectionMetrics.MainSectionMetrics.TotalSize.Height + sectionMetrics.ToWorkHeight + sectionMetrics.LocoToWorkHeight) - lineGapSize,
                MainLineWidth);
            for (int i = 0; i < columnCount && i + startingColumn < section.TrainSegments.Count; i++)
            {
                columnLeft += DrawSegment(section, section.TrainSegments[i + startingColumn], options, sectionMetrics, reverseLocationOrder, columnLeft, headerTop);
            }

            footnotes.DrawAt(_currentPage.PageGraphics, leftCoord, topCoord + sectionMetrics.TotalHeight);

            return sectionMetrics.TotalHeight + footnotes.Height;
        }

        private void DrawTitleAndSubtitle(string title, string subtitle, string dateDescription, double x, double subtitleXOffset, double y, double pageWidth, double titleHeight, 
            double subtitleHeight, bool drawSeparator, double separatorLineGap, double separatorY)
        {
            title = title ?? string.Empty;
            subtitle = subtitle ?? string.Empty;
            dateDescription = dateDescription ?? string.Empty;
            WritingWrapper(title, _titleFont, new UniRectangle(x, y, pageWidth, titleHeight), HorizontalAlignment.Centred, VerticalAlignment.Top);
            WritingWrapper(subtitle, _subtitleFont, new UniRectangle(x + subtitleXOffset, y + titleHeight, pageWidth, subtitleHeight), HorizontalAlignment.Left, VerticalAlignment.Top);
            WritingWrapper(dateDescription, _subtitleFont, new UniRectangle(x, y + titleHeight, pageWidth - subtitleXOffset, subtitleHeight), HorizontalAlignment.Right, VerticalAlignment.Top);
            if (drawSeparator)
            {
                LineDrawingWrapper("title-subtitle line", x + separatorLineGap, separatorY, x + pageWidth - separatorLineGap, separatorY, MainLineWidth);
            }
        }

        private double MeasureSegmentWidth(TrainSegmentModel segment, SectionMetrics sectionMetrics)
        {
            if (string.IsNullOrWhiteSpace(segment.InlineNote))
            {
                return sectionMetrics.ColumnWidth;
            }

            UniRange largestEmptyBlock = FindLargestEmptyBlock(segment, sectionMetrics.MainSectionMetrics);
            Paragraph para = new Paragraph(largestEmptyBlock.Size, sectionMetrics.ColumnWidth, Orientation.RotatedRight, HorizontalAlignment.Centred, VerticalAlignment.Centred, new MarginSet(2));
            para.AddText(segment.InlineNote, _plainBodyFont, _currentPage.PageGraphics);
            if (!para.OverspillHeight)
            {
                return sectionMetrics.ColumnWidth;
            }

            para = new Paragraph(sectionMetrics.MainSectionMetrics.TotalSize.Height, null, Orientation.RotatedRight, HorizontalAlignment.Centred, VerticalAlignment.Centred, new MarginSet(0.75));
            para.AddText(segment.InlineNote, _plainBodyFont, _currentPage.PageGraphics);
            return sectionMetrics.ColumnWidth + para.ComputedHeight;
        }

        private double DrawSegment(TimetableSectionModel section, TrainSegmentModel segment, DocumentExportOptions options, SectionMetrics sectionMetrics, bool reverseLocationOrder, double xCoord,
            double yCoord)
        {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            UniSize currentDims;
            LocationCollection locationMap = section.LocationMap;
            LocationBoxDimensions locationDims = sectionMetrics.MainSectionMetrics;
            double currentYCoord = yCoord + sectionMetrics.HeaderHeight;
            double segmentWidth = sectionMetrics.ColumnWidth;

            // Write timing points
            foreach (var timingPoint in segment.Timings)
            {
                FontDescriptor selectedFont;
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
                Log.Trace("Writing \"{0}\" at {1}, {2}", timingPoint.DisplayedText, xCoord + (segmentWidth - currentDims.Width) / 2,
                    currentYCoord + locationDims.LocationOffsets[timingPoint.LocationKey].Baseline);
                _currentPage.PageGraphics.DrawString(timingPoint.DisplayedText, selectedFont, xCoord + (segmentWidth - currentDims.Width) / 2, 
                    currentYCoord + locationDims.LocationOffsets[timingPoint.LocationKey].Baseline);
            }

            // Draw continuation arrows if needed
            List<string> locationsInSegment = segment.Timings.Select(t => t.LocationKey).ToList();
            List<TextVerticalLocation> offsetList = null;
            if (segment.ContinuationFromEarlier)
            {
                offsetList = sectionMetrics.MainSectionMetrics.LocationOffsetList;
                DrawContinuationArrow(segment.Timings.First(), offsetList, sectionMetrics.MainSectionMetrics.LocationOffsets, locationsInSegment, _leftPointingArrow, xCoord, currentYCoord);
            }
            if (segment.ContinuesLater)
            {
                if (offsetList == null)
                {
                    offsetList = sectionMetrics.MainSectionMetrics.LocationOffsetList;
                }
                DrawContinuationArrow(segment.Timings.Last(), offsetList, sectionMetrics.MainSectionMetrics.LocationOffsets, locationsInSegment, _rightPointingArrow, xCoord, currentYCoord);
            }

            // If there is an inline note to display, work out the position of the largest empty block...
            UniRange largestEmptyBlock = new UniRange(0, 0);
            if (!string.IsNullOrWhiteSpace(segment.InlineNote))
            {
                largestEmptyBlock = FindLargestEmptyBlock(segment, locationDims);                

                // Write the inline note into the largest empty block.
                Paragraph para = new Paragraph(largestEmptyBlock.Size, sectionMetrics.ColumnWidth, Orientation.RotatedRight, HorizontalAlignment.Centred, VerticalAlignment.Centred,
                    new MarginSet(2));
                para.AddText(segment.InlineNote, _plainBodyFont, _currentPage.PageGraphics);
                // If the paragraph fits within the empty block, draw it.  If not, widen the column and draw the note to the right of the train data.
                if (!para.OverspillHeight)
                {
                    para.DrawAt(_currentPage.PageGraphics, xCoord, currentYCoord + largestEmptyBlock.Start);
                    // Recompute start and end of "empty block", reducing it to just the size of the note.
                    double blockMidpoint = largestEmptyBlock.Start + (largestEmptyBlock.Size / 2);
                    double halfNewBlockWidth = para.ContentWidth / 2;
                    largestEmptyBlock = new UniRange(blockMidpoint - halfNewBlockWidth, blockMidpoint + halfNewBlockWidth);
                }
                else
                {
                    para = new Paragraph(sectionMetrics.MainSectionMetrics.TotalSize.Height, null, Orientation.RotatedRight, HorizontalAlignment.Centred, VerticalAlignment.Centred, 
                        new MarginSet(0.75));
                    para.AddText(segment.InlineNote, _plainBodyFont, _currentPage.PageGraphics);
                    para.DrawAt(_currentPage.PageGraphics, xCoord + sectionMetrics.ColumnWidth, currentYCoord);
                    segmentWidth += para.ComputedHeight;
                    // Ensure filler dots are written everywhere required.
                    largestEmptyBlock = new UniRange(0, 0);
                }
            }

            // Separator line between this segment and the next
            LineDrawingWrapper("separator", xCoord + segmentWidth, yCoord + lineGapSize, xCoord + segmentWidth,
                currentYCoord + locationDims.TotalSize.Height + sectionMetrics.ToWorkHeight + sectionMetrics.LocoToWorkHeight - lineGapSize, MainLineWidth);
            
            UniSize fillerDims = _currentPage.PageGraphics.MeasureString(Resources.RowEmptyCellFiller, _plainBodyFont);
            UniSize alternateFillerDims = _currentPage.PageGraphics.MeasureString(Resources.RowEmptyCellAlternateFiller, _plainBodyFont);
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
                    locationDims.LocationOffsets[loc.LocationKey].Bottom < largestEmptyBlock.Start ||
                    locationDims.LocationOffsets[loc.LocationKey].Top >= largestEmptyBlock.End)
                {
                    if (i < firstIndex || i > lastIndex)
                    {
                        double stringWidth = locationDims.LocationParity[loc.LocationKey] ? fillerDims.Width : alternateFillerDims.Width;
                        Log.Trace("Inserting filler for {0} at {1}, {2}", loc, xCoord + (sectionMetrics.ColumnWidth - stringWidth) / 2, currentYCoord + locationDims.LocationOffsets[loc.LocationKey].Baseline);
                        _currentPage.PageGraphics.DrawString(locationDims.LocationParity[loc.LocationKey] ? Resources.RowEmptyCellFiller : Resources.RowEmptyCellAlternateFiller, _plainBodyFont,
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
                    LineDrawingWrapper("location separator", xCoord + lineGapSize, currentYCoord + separatorOffset, (xCoord + sectionMetrics.ColumnWidth) - lineGapSize, currentYCoord + separatorOffset, MainLineWidth);
                }
            }

            if (segment.IncludeSeparatorAbove && segment.Timings[0].LocationKey.StripArrivalDepartureSuffix() != locationMap[reverseLocationOrder ? locationMap.Count - 1 : 0].Id)
            {
                LineDrawingWrapper("segment start separator", xCoord + lineGapSize, currentYCoord + locationDims.LocationOffsets[segment.Timings[0].LocationKey].Top,
                    xCoord + sectionMetrics.ColumnWidth - lineGapSize, currentYCoord + locationDims.LocationOffsets[segment.Timings[0].LocationKey].Top, MainLineWidth);
            }

            if (segment.IncludeSeparatorBelow && 
                segment.Timings[segment.Timings.Count - 1].LocationKey.StripArrivalDepartureSuffix() != locationMap[reverseLocationOrder ? 0 : locationMap.Count - 1].Id)
            {
                LineDrawingWrapper("segment end separator", xCoord + lineGapSize, currentYCoord + locationDims.LocationOffsets[segment.Timings[segment.Timings.Count - 1].LocationKey].Bottom,
                    xCoord + sectionMetrics.ColumnWidth - lineGapSize, currentYCoord + locationDims.LocationOffsets[segment.Timings[segment.Timings.Count - 1].LocationKey].Bottom, MainLineWidth);
            }

            // Write train class
            currentYCoord = yCoord;
            currentDims = _currentPage.PageGraphics.MeasureString(segment.TrainClass, _boldBodyFont);
            Log.Trace("Writing \"{0}\" at {1}, {2}", segment.TrainClass, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + _boldBodyFont.Ascent);
            _currentPage.PageGraphics.DrawString(segment.TrainClass, _boldBodyFont, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + _boldBodyFont.Ascent);
            currentYCoord += currentDims.Height;

            // Write diagram/headcode
            LineDrawingWrapper("separator", xCoord + lineGapSize, currentYCoord, (xCoord + segmentWidth) - lineGapSize, currentYCoord, MainLineWidth);
            currentDims = _currentPage.PageGraphics.MeasureString(segment.Headcode, _boldBodyFont);
            Log.Trace("Writing \"{0}\" at {1}, {2}", segment.Headcode, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + _boldBodyFont.Ascent);
            _currentPage.PageGraphics.DrawString(segment.Headcode, _boldBodyFont, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + _boldBodyFont.Ascent);
            currentYCoord += currentDims.Height;

            // Write loco diagram
            if (sectionMetrics.IncludeLocoDiagramRow)
            {
                currentDims = _currentPage.PageGraphics.MeasureString(segment.LocoDiagram, _boldBodyFont);
                Log.Trace("Writing \"{0}\" at {1}, {2}", segment.LocoDiagram, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + _boldBodyFont.Ascent);
                _currentPage.PageGraphics.DrawString(segment.LocoDiagram, _boldBodyFont, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + _boldBodyFont.Ascent);
                currentYCoord += currentDims.Height;
            }
            else
            {
                Log.Trace("Skipping loco diagram field.");
            }

            // Write header footnote row
            if (sectionMetrics.HeaderIncludesFootnoteRow)
            {
                currentDims = _currentPage.PageGraphics.MeasureString(segment.Footnotes, _boldBodyFont);
                Log.Trace("Writing \"{0}\" at {1}, {2}", segment.Footnotes, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + _boldBodyFont.Ascent);
                _currentPage.PageGraphics.DrawString(segment.Footnotes, _boldBodyFont, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + _boldBodyFont.Ascent);
                currentYCoord += currentDims.Height;
            }

            // Write am/pm indicator
            Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_DrawingSeparator, xCoord + lineGapSize, currentYCoord, (xCoord + segmentWidth) - lineGapSize, currentYCoord);
            _currentPage.PageGraphics.DrawLine(xCoord + lineGapSize, currentYCoord, (xCoord + segmentWidth) - lineGapSize, currentYCoord);
            currentDims = _currentPage.PageGraphics.MeasureString(segment.HalfOfDay, _plainBodyFont);
            Log.Trace("Writing \"{0}\" at {1}, {2}", segment.HalfOfDay, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + _plainBodyFont.Ascent);
            _currentPage.PageGraphics.DrawString(segment.HalfOfDay, _plainBodyFont, xCoord + (segmentWidth - currentDims.Width) / 2, currentYCoord + _plainBodyFont.Ascent);
            currentYCoord += currentDims.Height;

            // Draw separator line between header and timing points.
            LineDrawingWrapper("separator", xCoord + lineGapSize, currentYCoord, (xCoord + segmentWidth) - lineGapSize, currentYCoord, MainLineWidth);

            // Write "Loco to work"
            if (sectionMetrics.IncludeLocoToWorkRow)
            {
                double yc = currentYCoord + locationDims.TotalSize.Height;
                LineDrawingWrapper("separator line", xCoord + lineGapSize, yc, xCoord + segmentWidth - lineGapSize, yc, MainLineWidth);
                if (!string.IsNullOrWhiteSpace(segment.LocoToWorkCell?.DisplayedText))
                {
                    currentDims = _currentPage.PageGraphics.MeasureString(segment.LocoToWorkCell.DisplayedText, _plainBodyFont);
                    double xc = xCoord + (segmentWidth - currentDims.Width) / 2;
                    yc = currentYCoord + locationDims.TotalSize.Height + _plainBodyFont.Ascent;
                    Log.Trace("Writing \"{0}\" at {1}, {2}", segment.LocoToWorkCell.DisplayedText, xc, yc);
                    _currentPage.PageGraphics.DrawString(segment.LocoToWorkCell.DisplayedText, _plainBodyFont, xc, yc);
                }
            }

            // Write "Set to work"
            if (sectionMetrics.IncludeToWorkRow)
            {
                double yc = currentYCoord + locationDims.TotalSize.Height + sectionMetrics.LocoToWorkHeight;
                LineDrawingWrapper("separator line", xCoord + lineGapSize, yc, xCoord + segmentWidth - lineGapSize, yc, MainLineWidth);
                if (!string.IsNullOrWhiteSpace(segment.ToWorkCell?.DisplayedText))
                {
                    currentDims = _currentPage.PageGraphics.MeasureString(segment.ToWorkCell.DisplayedText, _plainBodyFont);
                    double xc = xCoord + (segmentWidth - currentDims.Width) / 2;
                    yc = currentYCoord + locationDims.TotalSize.Height + sectionMetrics.LocoToWorkHeight + _plainBodyFont.Ascent;
                    Log.Trace("Writing \"{0}\" at {1}, {2}", segment.ToWorkCell.DisplayedText, xc, yc);
                    _currentPage.PageGraphics.DrawString(segment.ToWorkCell.DisplayedText, _plainBodyFont, xc, yc);
                }
            }

            return segmentWidth;
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
            arrow.DrawAt(_currentPage.PageGraphics, xc + _arrowHOffset, yc + (offsetList[tpIndex].Top + (offsetList[tpIndex].Baseline - offsetList[tpIndex].Top) / 2));
            keyList.Add(offsetDict.First(o => o.Value == offsetList[tpIndex]).Key);
        }

        private static UniRange FindLargestEmptyBlock(TrainSegmentModel segment, LocationBoxDimensions locationDims)
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
                        startCurrentEmptyBlock = item.Value.Top;
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

            return new UniRange(startLargestEmptyBlock, endLargestEmptyBlock);
        }

        private Line MakeLineForTimingPoint(TrainLocationTimeModel timingPoint)
        {
            FontDescriptor timeFont = timingPoint.IsPassingTime ? _italicBodyFont : _boldBodyFont;
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
                LineDrawingWrapper("location separator", xCoord + lineGapSize, yCoord + separatorOffset, xCoord + locationDims.TotalSize.Width - lineGapSize, yCoord + separatorOffset, MainLineWidth);
            }
            yCoord += _plainBodyFont.Ascent;
            double xc1, yc1;
            for (int i = 0; i < timetableSection.Locations.Count; ++i)
            {
                LocationDisplayModel loc = timetableSection.Locations[i];
                FontDescriptor locationFont = SwitchFont(loc);
                UniSize locationSize = _currentPage.PageGraphics.MeasureString(loc.ExportDisplayName ?? string.Empty, locationFont);
                UniSize labelSize = _currentPage.PageGraphics.MeasureString(loc.ArrivalDepartureLabel ?? string.Empty, _plainBodyFont);
                double locationXCoord = xCoord + _locationListMargins;
                double labelXCoord = xCoord + locationDims.TotalSize.Width - (labelSize.Width + _locationListMargins);
                string locationLabel;
                if (!loc.IsRoutingCodeRow && locationDims.LocationFillerDotCounts.ContainsKey(loc.LocationKey) && locationDims.LocationFillerDotCounts[loc.LocationKey] > 0)
                {
                    locationLabel = AppendFillerDots(loc.ExportDisplayName, locationDims.LocationFillerDotCounts[loc.LocationKey]);
                }
                else
                {
                    locationLabel = loc.ExportDisplayName;
                }
                xc1 = locationXCoord;
                yc1 = yCoord;
                Log.Trace("Writing \"{0}\" at {1}, {2}", locationLabel, xc1, yc1);
                _currentPage.PageGraphics.DrawString(locationLabel ?? string.Empty, locationFont, xc1, yc1);
                xc1 = labelXCoord;
                Log.Trace("Writing \"{0}\" at {1}, {2}", loc.ArrivalDepartureLabel, xc1, yc1);
                _currentPage.PageGraphics.DrawString(loc.ArrivalDepartureLabel ?? string.Empty, _plainBodyFont, xc1, yc1);

                yc1 = locationSize.Height > labelSize.Height ? locationSize.Height : labelSize.Height;
                Log.Trace(CultureInfo.CurrentCulture, LogMessageResources.LogMessage_IncreasingYCoordinate, yc1);
                yCoord += yc1;
            }
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
            Log.Trace(CultureInfo.CurrentCulture, "Writing \"{0}\" within box at ({1}, {2}) dims {3}x{4}", text, boundingBox.Left, boundingBox.Top, boundingBox.Width, boundingBox.Height);
            _currentPage.PageGraphics.DrawString(text, font, boundingBox, hAlign, vAlign);
        }

        private void DrawToWorkRowHeader(SectionMetrics metrics, double xCoord, double yCoord)
        {
            if (!metrics.IncludeToWorkRow)
            {
                return;
            }

            LineDrawingWrapper("to work row header", xCoord + lineGapSize, yCoord, xCoord + metrics.MainSectionMetrics.TotalSize.Width - lineGapSize, yCoord, MainLineWidth);
            yCoord += _plainBodyFont.Ascent;
            double headerXCoord = xCoord + _locationListMargins;
            _currentPage.PageGraphics.DrawString(metrics.IncludeLocoToWorkRow ? Resources.SetToWorkRowCaption : Resources.ToWorkRowCaption, _plainBodyFont, headerXCoord, yCoord);
        }

        private void DrawLocoToWorkRowHeader(SectionMetrics metrics, double xCoord, double yCoord)
        {
            if (!metrics.IncludeLocoToWorkRow)
            {
                return;
            }

            LineDrawingWrapper("loco to work row header", xCoord + lineGapSize, yCoord, xCoord + metrics.MainSectionMetrics.TotalSize.Width - lineGapSize, yCoord, MainLineWidth);
            yCoord += _plainBodyFont.Ascent;
            double headerXCoord = xCoord + _locationListMargins;
            _currentPage.PageGraphics.DrawString(Resources.LocoToWorkRowCaption, _plainBodyFont, headerXCoord, yCoord);
        }

        private static string AppendFillerDots(string lbl, int count)
        {
            StringBuilder builder = new StringBuilder(lbl);
            for (int i = 0; i < count; ++i)
            {
                builder.Append(" .");
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
            FontDescriptor locationFont;
            for (int i = 0; i < timetableSection.Locations.Count; ++i)
            {
                LocationDisplayModel loc = timetableSection.Locations[i];
                locationFont = SwitchFont(loc);

                UniSize locationSize = _currentPage.PageGraphics.MeasureString(loc.ExportDisplayName ?? string.Empty, locationFont);
                UniSize labelSize = _currentPage.PageGraphics.MeasureString(loc.ArrivalDepartureLabel ?? string.Empty, _plainBodyFont);
                UniSize locationSizeInPlainFont = (locationFont == _plainBodyFont) ? locationSize : _currentPage.PageGraphics.MeasureString(loc.ExportDisplayName, _plainBodyFont);
                double baselineOffset = _plainBodyFont.Ascent > locationFont.Ascent ? _plainBodyFont.Ascent : locationFont.Ascent;
                double descenderHeight =  (locationFont == _plainBodyFont || (locationSize.Height - _alternativeLocationFont.Ascent) < (locationSizeInPlainFont.Height - _plainBodyFont.Ascent))
                    ? locationSizeInPlainFont.Height - _plainBodyFont.Ascent : locationSize.Height - _alternativeLocationFont.Ascent;
                double locationHeight = baselineOffset + descenderHeight;
                TextVerticalLocation tvl = new TextVerticalLocation { Baseline = totalHeight + baselineOffset, Top = totalHeight, Bottom = totalHeight + locationHeight };
                dimensions.LocationOffsets.Add(loc.LocationKey, tvl);
                dimensions.LocationParity.Add(loc.LocationKey, parity);
                parity = !parity;
                totalHeight += locationHeight > labelSize.Height ? locationHeight : labelSize.Height;
                if (locationSize.Width + labelSize.Width > maxWidth)
                {
                    maxWidth = locationSize.Width + labelSize.Width;
                    widestId = loc.LocationKey;
                }
                if (i > 0 && loc.DisplaySeparatorAbove)
                {
                    dimensions.LocationSeparatorOffsets.Add(tvl.Top);
                }
                if (i < timetableSection.Locations.Count - 1 && loc.DisplaySeparatorBelow && !timetableSection.Locations[i + 1].DisplaySeparatorAbove)
                {
                    dimensions.LocationSeparatorOffsets.Add(tvl.Bottom);
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

        private FontDescriptor SwitchFont(LocationDisplayModel loc)
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
                double height = _currentPage.PageGraphics.MeasureString(segment.TrainClass, _boldBodyFont).Height + 
                    _currentPage.PageGraphics.MeasureString(segment.Headcode, _boldBodyFont).Height + _currentPage.PageGraphics.MeasureString(segment.HalfOfDay, _plainBodyFont).Height;
                if (!string.IsNullOrWhiteSpace(segment.Footnotes))
                {
                    height += _currentPage.PageGraphics.MeasureString(segment.Footnotes, _boldBodyFont).Height;
                }
                if (includeLocoDiagramRow)
                {
                    height += _currentPage.PageGraphics.MeasureString(segment.LocoDiagram, _boldBodyFont).Height;
                }
                if (height > maxHeight)
                {
                    maxHeight = height;
                }
            }

            return maxHeight;
        }

        private double MeasureToWorkRowHeight(TimetableSectionModel section)
        {
            double maxHeight = _currentPage.PageGraphics.MeasureString(Resources.ToWorkRowCaption, _plainBodyFont).Height;
            foreach (var segment in section.TrainSegments)
            {
                double height = 
                   string.IsNullOrWhiteSpace(segment.ToWorkCell?.DisplayedText) ? 0 : _currentPage.PageGraphics.MeasureString(segment.ToWorkCell.DisplayedText, _plainBodyFont).Height;
                if (height > maxHeight)
                {
                    maxHeight = height;
                }
            }
            return maxHeight;
        }

        private double MeasureLocoToWorkRowHeight(TimetableSectionModel section)
        {
            double maxHeight = _currentPage.PageGraphics.MeasureString(Resources.LocoToWorkRowCaption, _plainBodyFont).Height;
            foreach (var segment in section.TrainSegments)
            {
                double height =
                   string.IsNullOrWhiteSpace(segment.LocoToWorkCell?.DisplayedText) ? 0 : _currentPage.PageGraphics.MeasureString(segment.LocoToWorkCell.DisplayedText, _plainBodyFont).Height;
                if (height > maxHeight)
                {
                    maxHeight = height;
                }
            }
            return maxHeight;
        }

        private void ExportGlossary(IDocumentDescriptor doc, NoteCollection noteDefinitions)
        {
            StartPage(doc, PageOrientation.Portrait);
            double titleHeight = _currentPage.PageGraphics.MeasureString(Resources.GlossaryTitle, _subtitleFont).Height;
            WritingWrapper(Resources.GlossaryTitle, _subtitleFont, new UniRectangle(_currentPage.LeftMarginPosition, _currentPage.TopMarginPosition, _currentPage.PageAvailableWidth, titleHeight),
                HorizontalAlignment.Centred, VerticalAlignment.Centred);
            List<Note> glossaryNotes = noteDefinitions.Where(n => n.DefinedInGlossary && !string.IsNullOrEmpty(n.Symbol) && !string.IsNullOrEmpty(n.Definition)).OrderBy(n => n.Symbol).ToList();
            Table footnotesTable = new Table { RuleStyle = TableRuleStyle.None };
            MarginSet footnotesTableCellMargins = new MarginSet(0, 3, 0, 3);
            foreach (Note n in glossaryNotes) { 
                footnotesTable.AddRow(new PlainTextTableCell(n.Symbol, _alternativeLocationFont, footnotesTableCellMargins, _currentPage.PageGraphics),
                    new PlainTextTableCell(n.Definition, _plainBodyFont, footnotesTableCellMargins, _currentPage.PageGraphics));
            }
            footnotesTable.DrawAt(_currentPage.PageGraphics, _currentPage.LeftMarginPosition, _currentPage.TopMarginPosition + titleHeight * 2);
        }
    }
}
