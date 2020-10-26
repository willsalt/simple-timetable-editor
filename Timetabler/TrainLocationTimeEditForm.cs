using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Timetabler.Data;
using Timetabler.Extensions;
using Timetabler.Helpers;
using Timetabler.Models;

namespace Timetabler
{
    public partial class TrainLocationTimeEditForm : Form
    {
        private TrainLocationTimeEditFormModel _model;

        private bool _inViewUpdate;

        /// <summary>
        /// The data to be edited by this form.
        /// </summary>
        public TrainLocationTimeEditFormModel Model
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

        private void UpdateViewFromModel()
        {
            if (_model == null)
            {
                return;
            }
            _inViewUpdate = true;
            SetHalfOfDayComboBoxVisibility();
            if (_model.ValidLocations != null)
            {
                UpdateLocationList();
            }
            if (_model.ValidNotes != null)
            {
                clbArrival.Items.Clear();
                clbDeparture.Items.Clear();
                foreach (var noteObj in _model.ValidNotes)
                {
                    bool arrSelected = _model.Data.ArrivalTime.Footnotes.Any(n => n.Id == noteObj.Id);
                    bool depSelected = _model.Data.DepartureTime.Footnotes.Any(n => n.Id == noteObj.Id);
                    clbArrival.Items.Add(noteObj, arrSelected);
                    clbDeparture.Items.Add(noteObj, depSelected);
                }
            }
            if (_model.Data != null)
            {
                UpdateFormData();
            }
            _inViewUpdate = false;
        }

        private void SetHalfOfDayComboBoxVisibility()
        {
            _model.InputMode.SetControlsVisibleIn12HourMode(new[] { cbArrivalHalfOfDay, cbDepartureHalfOfDay });
        }

        private void UpdateFormData()
        {
            if (_model != null && _model.Data != null && _model.Data.Location != null && cbLocation.Items.Contains(_model.Data.Location))
            {
                cbLocation.SelectedItem = _model.Data.Location;
            }
            if (_model.Data.ArrivalTime?.Time != null)
            {
                _model.Data.ArrivalTime.Time.SetTime(tbArrivalHour, tbArrivalMinute, cbArrivalHalfOfDay, _model.InputMode);
            }
            else
            {
                TimeHelpers.ClearTimeBoxes(tbArrivalHour, tbArrivalMinute, cbArrivalHalfOfDay);
            }
            if (_model.Data.DepartureTime?.Time != null)
            {
                _model.Data.DepartureTime?.Time.SetTime(tbDepartureHour, tbDepartureMinute, cbDepartureHalfOfDay, _model.InputMode);
            }
            else
            {
                TimeHelpers.ClearTimeBoxes(tbDepartureHour, tbDepartureMinute, cbDepartureHalfOfDay);
            }
            ckPassingTime.Checked = _model.Data.Pass;
            tbPath.Text = _model.Data.Path;
            tbPlatform.Text = _model.Data.Platform;
            tbLine.Text = _model.Data.Line;
        }

        private void UpdateLocationList()
        {
            _model.ValidLocations.Sort(new LocationComparer());
            cbLocation.BeginUpdate();
            cbLocation.Items.Clear();
            cbLocation.Items.AddRange(_model.ValidLocations.ToArray());
            cbLocation.EndUpdate();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainLocationTimeEditForm()
        {
            InitializeComponent();

            TimeHelpers.PopulateHalfOfDayComboBoxes(cbArrivalHalfOfDay, cbDepartureHalfOfDay);
        }

        private void CbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Location loc = cbLocation.SelectedItem as Location;
            if (loc == null)
            {
                return;
            }
            if (_model.Data == null)
            {
                return;
            }
            _model.Data.Location = loc;
        }

        private void TextBoxHoursMinutes_Validating(object sender, CancelEventArgs e)
        {
            UIHelpers.ValidateIntegerTextBox(sender as TextBox, errorProvider, Resources.TrainLocationTimeEditForm_ValidateTimes_Error, e);
        }

        private void StoreArrivalTime()
        {
            if (_model.Data == null)
            {
                return;
            }
            TimeHelpers.SetTimeProperty(_model.Data.ArrivalTime, _model.Data.ArrivalTime.GetType().GetProperty("Time"), tbArrivalHour, tbArrivalMinute, 
                _model.InputMode == ClockType.TwelveHourClock ? cbArrivalHalfOfDay : null, _model.Data.ArrivalTime?.Time != null ? _model.Data.ArrivalTime.Time.Seconds : 0);
        }

        private void StoreDepartureTime()
        {
            if (_model.Data == null)
            {
                return;
            }
            TimeHelpers.SetTimeProperty(_model.Data.DepartureTime, _model.Data.DepartureTime.GetType().GetProperty("Time"), tbDepartureHour, tbDepartureMinute,
                _model.InputMode == ClockType.TwelveHourClock ? cbDepartureHalfOfDay : null, _model.Data.DepartureTime?.Time != null ? _model.Data.DepartureTime.Time.Seconds : 0);
        }

        private void TbArrivalHour_Validated(object sender, EventArgs e)
        {
            StoreArrivalTime();
        }

        private void TbArrivalMinute_Validated(object sender, EventArgs e)
        {
            StoreArrivalTime();
        }

        private void TbDepartureHour_Validated(object sender, EventArgs e)
        {
            StoreDepartureTime();
        }

        private void TbDepartureMinute_Validated(object sender, EventArgs e)
        {
            StoreDepartureTime();
        }

        private void CkPassingTime_CheckedChanged(object sender, EventArgs e)
        {
            _model.Data.Pass = ckPassingTime.Checked;
        }

        private void ClbArrival_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }
            FootnoteItemCheck(clbArrival, _model.Data.ArrivalTime, e);
        }

        private void ClbDeparture_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }
            FootnoteItemCheck(clbDeparture, _model.Data.DepartureTime, e);
        }

        private static void FootnoteItemCheck(CheckedListBox clb, TrainTime timingPoint, ItemCheckEventArgs e)
        {
            if (!(clb.Items[e.Index] is Note item))
            {
                return;
            }
            if (e.NewValue == CheckState.Checked && !timingPoint.Footnotes.Any(n => n.Id == item.Id))
            {
                timingPoint.Footnotes.Add(item);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                timingPoint.Footnotes.RemoveAll(n => n.Id == item.Id);
            }
        }

        private void CbArrivalHalfOfDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }

            StoreArrivalTime();
        }

        private void CbDepartureHalfOfDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }

            StoreDepartureTime();
        }

        private void TbPath_TextChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model?.Data == null)
            {
                return;
            }

            _model.Data.Path = tbPath.Text;
        }

        private void TbPlatform_TextChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model?.Data == null)
            {
                return;
            }

            _model.Data.Platform = tbPlatform.Text;
        }

        private void TbLine_TextChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model?.Data == null)
            {
                return;
            }

            _model.Data.Line = tbLine.Text;
        }
    }
}
