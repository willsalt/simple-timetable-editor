using NLog;
using System;
using System.Globalization;
using System.Windows.Forms;
using Timetabler.CoreData;
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
            HumanReadableEnum<CoreData.Orientation>[] orientations = HumanReadableEnumFactory.GetOrientation();
            cbTableOrientation.Items.AddRange(orientations);
            cbGraphOrientation.Items.AddRange(orientations);
            cbDistanceInfoInOutput.Items.AddRange(HumanReadableEnumFactory.GetSectionSelection());
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
            nudGraphAxisLineWidth.Value = (decimal)Model.GraphAxisLineWidth;
            tbUpSectionLabel.Text = Model.UpSectionLabel;
            tbDownSectionLabel.Text = Model.DownSectionLabel;
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
            foreach (var item in cbDistanceInfoInOutput.Items)
            {
                if (item is HumanReadableEnum<SectionSelection> sectionItem && sectionItem.Value == Model.DistancesInOutput)
                {
                    cbDistanceInfoInOutput.SelectedItem = sectionItem;
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

        private void NudGraphAxisLineWidth_ValueChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_NudGraphAxisLineWidthValue, nudGraphAxisLineWidth.Value);
            Model.GraphAxisLineWidth = (double)nudGraphAxisLineWidth.Value;
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

        private void CbDistanceInfoInOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!(cbDistanceInfoInOutput.SelectedItem is HumanReadableEnum<CoreData.SectionSelection> item))
            {
                Log.Trace("cbDistanceInfoInOutput: null item selected.");
                return;
            }
            if (_inViewUpdate || Model is null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CbDistanceInOutput_Value, item.Name);
            Model.DistancesInOutput = item.Value;
        }

        private void TbUpSectionLabel_TextChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model is null)
            {
                return;
            }
            Model.UpSectionLabel = tbUpSectionLabel.Text;
        }

        private void TbDownSectionLabel_TextChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || Model is null)
            {
                return;
            }
            Model.DownSectionLabel = tbDownSectionLabel.Text;
        }
    }
}
