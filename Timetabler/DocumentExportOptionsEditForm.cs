﻿using NLog;
using System;
using System.Globalization;
using System.Windows.Forms;
using Timetabler.Data;
using Timetabler.Helpers;

namespace Timetabler
{
    /// <summary>
    /// Form for editing a <see cref="DocumentExportOptions"/> object.
    /// </summary>
    public partial class DocumentExportOptionsEditForm : Form
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        private bool _inViewUpdate;
        private DocumentExportOptions _model;

        /// <summary>
        /// The export options object to be edited.
        /// </summary>
        public DocumentExportOptions Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                UpdateViewFromModel();
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DocumentExportOptionsEditForm()
        {
            InitializeComponent();
            cbPdfEngine.Items.AddRange(HumanReadableEnumFactory.GetPdfExportEngine());
            cbFontChoice.Items.AddRange(HumanReadableEnumFactory.GetPdfFontChoice());
            HumanReadableEnum<CoreData.Orientation>[] orientations = HumanReadableEnumFactory.GetOrientation();
            cbTableOrientation.Items.AddRange(orientations);
            cbGraphOrientation.Items.AddRange(orientations);
        }

        private void UpdateViewFromModel()
        {
            if (Model == null)
            {
                return;
            }

            _inViewUpdate = true;
            if (Model.ExportEngine == PdfExportEngine.Unicorn)
            {
                Model.FontChoice = PdfFontChoice.Standard;
                cbFontChoice.Enabled = false;
            }
            ckDisplayLocoDiagram.Checked = Model.DisplayLocoDiagramRow;
            ckDisplayToWorkRow.Checked = Model.DisplayToWorkRow;
            ckDisplayBoxHours.Checked = Model.DisplayBoxHours;
            ckDisplayCredits.Checked = Model.DisplayCredits;
            ckDisplayGraph.Checked = Model.DisplayGraph;
            ckDisplayGlossary.Checked = Model.DisplayGlossary;
            nudLineWidth.Value = (decimal)Model.LineWidth;
            nudFillerDashLineWidth.Value = (decimal)Model.FillerDashLineWidth;
            foreach (var item in cbPdfEngine.Items)
            {
                if (item is HumanReadableEnum<PdfExportEngine> engineItem && engineItem.Value == Model.ExportEngine)
                {
                    cbPdfEngine.SelectedItem = engineItem;
                    break;
                }
            }
            foreach (var item in cbTableOrientation.Items)
            {
                if (item is HumanReadableEnum<CoreData.Orientation> orientItem && orientItem.Value == Model.TablePageOrientation)
                {
                    cbTableOrientation.SelectedItem = orientItem;
                    break;
                }
            }
            foreach (var item in cbGraphOrientation.Items)
            {
                if (item is HumanReadableEnum<CoreData.Orientation> orientItem && orientItem.Value == Model.GraphPageOrientation)
                {
                    cbGraphOrientation.SelectedItem = orientItem;
                    break;
                }
            }
            SetCbFontChoice();
            _inViewUpdate = false;
        }

        private void SetCbFontChoice()
        {
            foreach (var item in cbFontChoice.Items)
            {
                if (item is HumanReadableEnum<PdfFontChoice> fontItem && fontItem.Value == Model.FontChoice)
                {
                    cbFontChoice.SelectedItem = fontItem;
                    break;
                }
            }
        }

        private void CkDisplayLocoDiagram_CheckedChanged(object sender, EventArgs e)
        {          
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CkDisplayLocoDiagramValue, ckDisplayLocoDiagram.Checked);
            Model.DisplayLocoDiagramRow = ckDisplayLocoDiagram.Checked;
        }

        private void CkDisplayToWorkRow_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CkDisplayToWorkRowValue, ckDisplayToWorkRow.Checked);
            Model.DisplayToWorkRow = ckDisplayToWorkRow.Checked;
        }

        private void CkDisplayBoxHours_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CkDisplayBoxHoursValue, ckDisplayBoxHours.Checked);
            Model.DisplayBoxHours = ckDisplayBoxHours.Checked;
        }

        private void CkDisplayCredits_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CkDisplayCreditsValue, ckDisplayCredits.Checked);
            Model.DisplayCredits = ckDisplayCredits.Checked;
        }

        private void CkDisplayLocoToWorkRow_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CkDisplayLocoToWorkRowValue, ckDisplayLocoToWorkRow.Checked);
            Model.DisplayLocoToWorkRow = ckDisplayLocoToWorkRow.Checked;
        }

        private void NudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_NudLineWidthValue, nudLineWidth.Value);
            Model.LineWidth = (double)nudLineWidth.Value;
        }

        private void NudFillerDashLineWidth_ValueChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_NudFillerDashLineWidthValue, nudFillerDashLineWidth.Value);
            Model.FillerDashLineWidth = (double)nudFillerDashLineWidth.Value;
        }

        private void CkDisplayGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CkDisplayGraphValue, ckDisplayGraph.Checked);
            Model.DisplayGraph = ckDisplayGraph.Checked;
        }

        private void CkDisplayGlossary_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CkDisplayGlossaryValue, ckDisplayGlossary.Checked);
            Model.DisplayGlossary = ckDisplayGlossary.Checked;
        }

        private void CbPdfEngine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }
            if (!(cbPdfEngine.SelectedItem is HumanReadableEnum<PdfExportEngine> item))
            {
                Log.Trace("cbPdfEngine: null item selected");
                return;
            }
            lblWarning.Visible = item.Value == PdfExportEngine.Unicorn;
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CbPdfEngineValue, item.Name);
            Model.ExportEngine = item.Value;
            if (item.Value == PdfExportEngine.Unicorn)
            {
                Model.FontChoice = PdfFontChoice.Standard;
                _inViewUpdate = true;
                SetCbFontChoice();
                _inViewUpdate = false;
                cbFontChoice.Enabled = false;
            }
            else
            {
                cbFontChoice.Enabled = true;
            }
        }

        private void CbFontChoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }
            if (!(cbFontChoice.SelectedItem is HumanReadableEnum<PdfFontChoice> item))
            {
                Log.Trace("cbFontChoice: null item selected.");
                return;
            }
            Model.FontChoice = item.Value;
        }

        private void CbTableOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbTableOrientation.SelectedItem is HumanReadableEnum<CoreData.Orientation> item))
            {
                Log.Trace("cbTableOrientation: null item selected.");
                return;
            }
            if (_inViewUpdate || Model is null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CbTableOrientation_Value, item.Name);
            Model.TablePageOrientation = item.Value;
        }

        private void CbGraphOrientation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbGraphOrientation.SelectedItem is HumanReadableEnum<CoreData.Orientation> item))
            {
                Log.Trace("cbGraphOrientation: null item selected.");
                return;
            }
            if (_inViewUpdate || Model is null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CbGraphOrientation_Value, item.Name);
            Model.GraphPageOrientation = item.Value;
        }

        
    }
}
