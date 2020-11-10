using NLog;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Extensions;
using Timetabler.Helpers;

namespace Timetabler
{
    /// <summary>
    /// A form for editing document options.
    /// </summary>
    public partial class DocumentOptionsEditForm : Form
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();
        private bool _inViewUpdate;
        private DocumentOptions _model;

        /// <summary>
        /// The document options object to be edited.
        /// </summary>
        public DocumentOptions Model
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
        /// Default constructor: creates the form and initialises the clock types checkbox values.
        /// </summary>
        public DocumentOptionsEditForm()
        {
            InitializeComponent();
            cbClockType.Items.AddRange(HumanReadableEnumFactory.GetClockTypes());
            cbGraphEditStyle.Items.AddRange(HumanReadableEnumFactory.GetGraphEditStyle());
            cbLinePattern.Items.AddRange(HumanReadableEnumFactory.GetDashStyles());
        }

        private void UpdateViewFromModel()
        {
            if (_model == null)
            {
                return;
            }

            _inViewUpdate = true;
            foreach (var item in cbClockType.Items)
            {
                if (item is HumanReadableEnum<ClockType> clockTypeItem && clockTypeItem.Value == _model.ClockType)
                {
                    cbClockType.SelectedItem = clockTypeItem;
                    break;
                }
            }
            foreach (var item in cbGraphEditStyle.Items)
            {
                if (item is HumanReadableEnum<GraphEditStyle> gesItem && gesItem.Value == _model.GraphEditStyle)
                {
                    cbGraphEditStyle.SelectedItem = gesItem;
                    break;
                }
            }
            ckDisplayTrainLabelsOnGraphs.Checked = _model.DisplayTrainLabelsOnGraphs;
            ckDisplaySpeedLines.Checked = _model.DisplaySpeedLinesOnGraphs;
            SetSpeedLineControlsEnabled();
            tbSpeedLineSpeed.Text = _model.SpeedLineSpeed.ToString(CultureInfo.InvariantCulture);
            tbSpeedLineSpacing.Text = _model.SpeedLineSpacingMinutes.ToString(CultureInfo.InvariantCulture);
            nudLineWidth.Value = (decimal)_model.SpeedLineAppearance.Width;
            foreach (var item in cbLinePattern.Items)
            {
                if (item is HumanReadableEnum<DashStyle> enItem && enItem.Value == _model.SpeedLineAppearance.DashStyle)
                {
                    cbLinePattern.SelectedItem = enItem;
                    break;
                }
            }
            btnColour.BackColor = _model.SpeedLineAppearance.Colour.ToColor();
            btnColour.ForeColor = UIHelpers.ComputeButtonForeColour(_model.SpeedLineAppearance.Colour).ToColor();
            _inViewUpdate = false;
        }

        private void SetSpeedLineControlsEnabled()
        {
            tbSpeedLineSpeed.Enabled = _model.DisplaySpeedLinesOnGraphs;
            tbSpeedLineSpacing.Enabled = _model.DisplaySpeedLinesOnGraphs;
            nudLineWidth.Enabled = _model.DisplaySpeedLinesOnGraphs;
            cbLinePattern.Enabled = _model.DisplaySpeedLinesOnGraphs; 
            btnColour.Enabled = _model.DisplaySpeedLinesOnGraphs;
        }

        private void CbClockType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model == null)
            {
                return;
            }
            if (!(cbClockType.SelectedItem is HumanReadableEnum<ClockType> item))
            {
                Log.Trace("cbCLockType: null item selected");
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CbClockTypeValue, item.Name);
            _model.ClockType = item.Value;
        }

        private void CkDisplayTrainLabelsOnGraphs_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CkDisplayTrainLabelsOnGraphsValue, ckDisplayTrainLabelsOnGraphs.Checked);
            _model.DisplayTrainLabelsOnGraphs = ckDisplayTrainLabelsOnGraphs.Checked;
        }

        private void CbGraphEditStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model == null)
            {
                return;
            }
            if (!(cbGraphEditStyle.SelectedItem is HumanReadableEnum<GraphEditStyle> item))
            {
                Log.Trace("cbGraphEditStyle: null item selected.");
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CbGraphEditStyleValue, item.Name);
            _model.GraphEditStyle = item.Value;
        }

        private void CkDisplaySpeedLines_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model == null)
            {
                return;
            }
            _model.DisplaySpeedLinesOnGraphs = ckDisplaySpeedLines.Checked;
            SetSpeedLineControlsEnabled();
        }

        private void TbSpeedLineSpeed_Validating(object sender, CancelEventArgs e)
        {
            UIHelpers.ValidateIntegerTextBox(tbSpeedLineSpeed, errorProvider, Resources.DocumentOptionsEditForm_ValidateSpeedLineSpeed_Error, e);
        }

        private void TbSpeedLineSpeed_Validated(object sender, EventArgs e)
        {
            SetIntValue(tbSpeedLineSpeed, s => _model.SpeedLineSpeed = s);
        }

        private void TbSpeedLineSpacing_Validating(object sender, CancelEventArgs e)
        {
            UIHelpers.ValidateIntegerTextBox(tbSpeedLineSpacing, errorProvider, Resources.DocumentOptionsEditForm_ValidateSpeedLineSpacing_Error, e);
        }

        private void TbSpeedLineSpacing_Validated(object sender, EventArgs e)
        {
            SetIntValue(tbSpeedLineSpacing, s => _model.SpeedLineSpacingMinutes = s);
        }

        private void SetIntValue(TextBox tb, Action<int> setter)
        {
            if (_inViewUpdate || _model == null)
            {
                return;
            }
            if (!int.TryParse(tb.Text, out int v))
            {
                return;
            }
            setter(v);
        }

        private void NudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            _model.SpeedLineAppearance.Width = (float)nudLineWidth.Value;
        }

        private void CbLinePattern_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }
            if (!(cbLinePattern.SelectedItem is HumanReadableEnum<DashStyle> pattern))
            {
                return;
            }
            _model.SpeedLineAppearance.DashStyle = pattern.Value;
        }

        private void BtnColour_Click(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model == null)
            {
                return;
            }
            UIHelpers.ColourDialogueHelper(_model.SpeedLineAppearance.Colour, c => _model.SpeedLineAppearance.Colour = c, btnColour);
        }
    }
}
