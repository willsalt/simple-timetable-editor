using NLog;
using System;
using System.Globalization;
using System.Windows.Forms;
using Timetabler.Data;
using Timetabler.Helpers;

namespace Timetabler
{
    /// <summary>
    /// A form for editing document options.
    /// </summary>
    public partial class DocumentOptionsEditForm : Form
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();
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
            _inViewUpdate = false;
        }

        private void cbClockType_SelectedIndexChanged(object sender, EventArgs e)
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

        private void ckDisplayTrainLabelsOnGraphs_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model == null)
            {
                return;
            }
            Log.Trace(CultureInfo.CurrentCulture, Resources.LogMessage_CkDisplayTrainLabelsOnGraphsValue, ckDisplayTrainLabelsOnGraphs.Checked);
            _model.DisplayTrainLabelsOnGraphs = ckDisplayTrainLabelsOnGraphs.Checked;
        }

        private void cbGraphEditStyle_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
