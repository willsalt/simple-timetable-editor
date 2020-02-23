using NLog;
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
        }

        private void UpdateViewFromModel()
        {
            if (Model == null)
            {
                return;
            }

            _inViewUpdate = true;
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
            _inViewUpdate = false;
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
        }
    }
}
