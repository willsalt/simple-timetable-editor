using NLog;
using System;
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
            cbClockType.Items.AddRange(HumanReadableEnum<ClockType>.GetClockTypes());
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
                var clockTypeItem = item as HumanReadableEnum<ClockType>;
                if (clockTypeItem != null && clockTypeItem.Value == _model.ClockType)
                {
                    cbClockType.SelectedItem = clockTypeItem;
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
            var item = cbClockType.SelectedItem as HumanReadableEnum<ClockType>;
            if (item == null)
            {
                Log.Trace("cbCLockType: null item selected");
                return;
            }
            Log.Trace("cbClockType: value is {0}", item.Name);
            _model.ClockType = item.Value;
        }

        private void ckDisplayTrainLabelsOnGraphs_CheckedChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model == null)
            {
                return;
            }
            Log.Trace("ckDisplayTrainLabelsOnGraphs is {0}", ckDisplayTrainLabelsOnGraphs.Checked);
            _model.DisplayTrainLabelsOnGraphs = ckDisplayTrainLabelsOnGraphs.Checked;
        }
    }
}
