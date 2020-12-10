﻿using System;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.SerialData;

namespace Timetabler.DataLoader.Load
{
    /// <summary>
    /// Extension methods for the <see cref="ExportOptionsModel" /> class.
    /// </summary>
    public static class ExportOptionsModelExtensions
    {
        /// <summary>
        /// Convert a <see cref="ExportOptionsModel" /> instance to a <see cref="DocumentExportOptions" /> instance.
        /// </summary>
        /// <param name="model">The object to be converted.</param>
        /// <returns>A <see cref="DocumentExportOptions" /> instance representing the original data.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the parameter is <c>null</c>.</exception>
        public static DocumentExportOptions ToDocumentExportOptions(this ExportOptionsModel model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            DocumentExportOptions deo = new DocumentExportOptions
            {
                DisplayLocoDiagramRow = model.DisplayLocoDiagramRow ?? false,
                DisplayToWorkRow = model.SetToWorkRowInOutput ?? false,
                DisplayLocoToWorkRow = model.LocoToWorkRowInOutput ?? false,
                DisplayBoxHours = model.BoxHoursInOutput ?? false,
                DisplayCredits = model.CreditsInOutput ?? false,
                DisplayGlossary = model.GlossaryInOutput ?? false,
                LineWidth = model.LineWidth ?? 1.0,
                GraphAxisLineWidth = model.GraphAxisLineWidth ?? model.LineWidth ?? 1.0,
                FillerDashLineWidth = model.FillerDashLineWidth ?? 0.5,
                DisplayGraph = model.GraphsInOutput ?? true,
                TablePageOrientation = model.TablePageOrientation ?? Orientation.Landscape,
                GraphPageOrientation = model.GraphPageOrientation ?? Orientation.Landscape,
                DistancesInOutput = model.DistancesInOutput ?? SectionSelection.None,
                FirstDirectionExported = model.FirstDirectionExported ?? Direction.Down,
            };
            if (!(model.UpSectionLabel is null))
            {
                deo.UpSectionLabel = model.UpSectionLabel;
            }
            if (!(model.DownSectionLabel is null))
            {
                deo.DownSectionLabel = model.DownSectionLabel;
            }
            if (!(model.MorningLabel is null))
            {
                deo.MorningLabel = model.MorningLabel;
            }
            if (!(model.MiddayLabel is null))
            {
                deo.MiddayLabel = model.MiddayLabel;
            }
            if (!(model.AfternoonLabel is null))
            {
                deo.AfternoonLabel = model.AfternoonLabel;
            }

            return deo;
        }
    }
}
