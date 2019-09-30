using NLog;
using System;
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
        private static Logger Log = LogManager.GetCurrentClassLogger();

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
            cbPdfEngine.Items.AddRange(HumanReadableEnum<PdfExportEngine>.GetPdfExportEngine());
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
                var engineItem = item as HumanReadableEnum<PdfExportEngine>;
                if (engineItem != null && engineItem.Value == Model.ExportEngine)
                {
                    cbPdfEngine.SelectedItem = engineItem;
                    break;
                }
            }
            _inViewUpdate = false;
        }

        private void ckDisplayLocoDiagram_CheckedChanged(object sender, EventArgs e)
        {          
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace("ckDisplayLocoDiagram is {0}", ckDisplayLocoDiagram.Checked);
            Model.DisplayLocoDiagramRow = ckDisplayLocoDiagram.Checked;
        }

        private void ckDisplayToWorkRow_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace("ckDisplayToWorkRow is {0}", ckDisplayToWorkRow.Checked);
            Model.DisplayToWorkRow = ckDisplayToWorkRow.Checked;
        }

        private void ckDisplayBoxHours_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace("ckDisplayBoxHours is {0}", ckDisplayBoxHours.Checked);
            Model.DisplayBoxHours = ckDisplayBoxHours.Checked;
        }

        private void ckDisplayCredits_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace("ckDisplayCredits is {0}", ckDisplayCredits.Checked);
            Model.DisplayCredits = ckDisplayCredits.Checked;
        }

        private void ckDisplayLocoToWorkRow_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace("ckDisplayLocoToWorkRow is {0}", ckDisplayLocoToWorkRow.Checked);
            Model.DisplayLocoToWorkRow = ckDisplayLocoToWorkRow.Checked;
        }

        private void nudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace("nudLineWidth is {0}", nudLineWidth.Value);
            Model.LineWidth = (double)nudLineWidth.Value;
        }

        private void nudFillerDashLineWidth_ValueChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace("nudFillerDashLineWidth is {0}", nudFillerDashLineWidth.Value);
            Model.FillerDashLineWidth = (double)nudFillerDashLineWidth.Value;
        }

        private void ckDisplayGraph_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace("ckDisplayGraph is {0}", ckDisplayGraph.Checked);
            Model.DisplayGraph = ckDisplayGraph.Checked;
        }

        private void ckDisplayGlossary_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace("ckDisplayGlossary is {0}", ckDisplayGlossary.Checked);
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
            Log.Trace("cbPdfEngine is {0}", item.Name);
            Model.ExportEngine = item.Value;
        }
    }
}
