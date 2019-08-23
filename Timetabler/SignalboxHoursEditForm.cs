using System;
using System.ComponentModel;
using System.Windows.Forms;
using Timetabler.Data;
using Timetabler.Extensions;
using Timetabler.Helpers;
using Timetabler.Models;

namespace Timetabler
{
    /// <summary>
    /// A form for editing <see cref="SignalboxHours" /> instances.
    /// </summary>
    public partial class SignalboxHoursEditForm : Form
    {
        private SignalboxHoursEditFormModel _model;
        private bool _inViewUpdate = false;

        /// <summary>
        /// The data to be edited by the form.
        /// </summary>
        public SignalboxHoursEditFormModel Model
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
        public SignalboxHoursEditForm()
        {
            InitializeComponent();
            TimeHelpers.PopulateHalfOfDayComboBoxes(cbStartHalfOfDay, cbEndHalfOfDay);
        }

        private void UpdateViewFromModel()
        {
            if (Model?.Data == null)
            {
                return;
            }
            _inViewUpdate = true;
            lblBoxName.Text = Model.Data.Signalbox?.EditorDisplayName ?? Resources.SignalboxHoursEditForm_Signalbox_Name_Unknown;
            _model.InputMode.SetControlsVisibleIn12HourMode(new[] { cbStartHalfOfDay, cbEndHalfOfDay });
            if (_model.Data.StartTime != null)
            {
                _model.Data.StartTime.SetTime(tbStartHours, tbStartMinutes, cbStartHalfOfDay, _model.InputMode);
            }
            else
            {
                TimeHelpers.ClearTimeBoxes(tbStartMinutes, tbStartMinutes, cbStartHalfOfDay);
            }
            if (_model.Data.EndTime != null)
            {
                _model.Data.EndTime.SetTime(tbEndHours, tbEndMinutes, cbEndHalfOfDay, _model.InputMode);
            }
            else
            {
                TimeHelpers.ClearTimeBoxes(tbEndMinutes, tbEndMinutes, cbEndHalfOfDay);
            }
            ckTokenWarning.Checked = _model.Data.TokenBalanceWarning;
            _inViewUpdate = false;
        }

        private void textBoxHoursMinutes_Validating(object sender, CancelEventArgs e)
        {
            TimeHelpers.ValidateTimeTextBox(sender as TextBox, errorProvider, Resources.SignalboxHoursEditForm_ValidateTimes_Error, e);
        }

        private void StoreStartTime()
        {
            if (_model?.Data == null)
            {
                return;
            }
            TimeHelpers.SetTimeProperty(_model.Data, _model.Data.GetType().GetProperty("StartTime"), tbStartHours, tbStartMinutes, 
                _model.InputMode == ClockType.TwelveHourClock ? cbStartHalfOfDay : null, _model.Data.StartTime?.Seconds ?? 0);
        }

        private void StoreEndTime()
        {
            if (_model?.Data == null)
            {
                return;
            }
            TimeHelpers.SetTimeProperty(_model.Data, _model.Data.GetType().GetProperty("EndTime"), tbEndHours, tbEndMinutes,
                _model.InputMode == ClockType.TwelveHourClock ? cbEndHalfOfDay : null, _model.Data.EndTime?.Seconds ?? 0);
        }

        private void tbStartHours_Validated(object sender, EventArgs e)
        {
            StoreStartTime();
        }

        private void tbStartMinutes_Validated(object sender, EventArgs e)
        {
            StoreStartTime();
        }

        private void cbStartHalfOfDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }
            StoreStartTime();
        }

        private void tbEndHours_Validated(object sender, EventArgs e)
        {
            StoreEndTime();
        }

        private void tbEndMinutes_Validated(object sender, EventArgs e)
        {
            StoreEndTime();
        }

        private void cbEndHalfOfDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }
            StoreEndTime();
        }

        private void ckTokenWarning_CheckedChanged(object sender, EventArgs e)
        {
            if (!_inViewUpdate)
            {
                _model.Data.TokenBalanceWarning = ckTokenWarning.Checked;
            }
        }
    }
}
