using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Data.Collections;
using Timetabler.Extensions;
using Timetabler.Helpers;
using Timetabler.Models;

namespace Timetabler
{
    /// <summary>
    /// Form for editing train details.
    /// </summary>
    public partial class TrainEditForm : Form
    {
        private bool _inViewUpdate;

        private TrainEditFormModel _model;

        /// <summary>
        /// The data to be edited in the form.
        /// </summary>
        public TrainEditFormModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                UpdateViewFromModel();
                UpdateTimingsViewFromModel();
            }
        }

        private void UpdateViewFromModel()
        {
            if (_model == null || _model.Data == null)
            {
                return;
            }

            _inViewUpdate = true;
            if (_model.ValidTrainNotes != null)
            {
                clbFootnotes.Items.Clear();
                foreach (var noteObj in _model.ValidTrainNotes)
                {
                    bool selected = _model.Data.Footnotes.Any(n => n.Id == noteObj.Id);
                    clbFootnotes.Items.Add(noteObj, selected);
                }
            }
            if (_model.ValidClasses != null)
            {
                cbTrainClass.Items.Clear();
                cbTrainClass.Items.Add("(none)");
                cbTrainClass.Items.AddRange(_model.ValidClasses.ToArray());
            }
            tbHeadcode.Text = _model.Data.Headcode;
            tbLocoDiagram.Text = _model.Data.LocoDiagram;
            if (string.IsNullOrEmpty(_model.Data.TrainClassId))
            {
                cbTrainClass.SelectedIndex = 0;
            }
            else if (_model.ValidClasses.Any(c => c.Id == _model.Data.TrainClassId))
            {
                cbTrainClass.SelectedItem = _model.ValidClasses.First(c => c.Id == _model.Data.TrainClassId);
            }
            if (_model.Data.GraphProperties == null)
            {
                _model.Data.GraphProperties = new GraphTrainProperties();
            }
            nudLineWidth.Value = (decimal) _model.Data.GraphProperties.Width;
            foreach (var item in cbLinePattern.Items)
            {
                if (item is HumanReadableEnum<DashStyle> enItem && enItem.Value == _model.Data.GraphProperties.DashStyle)
                {
                    cbLinePattern.SelectedItem = enItem;
                    break;
                }
            }
            btnColour.BackColor = _model.Data.GraphProperties.Colour;
            btnColour.ForeColor = UIHelpers.ComputeButtonForeColour(_model.Data.GraphProperties.Colour);
            ckSeparatorAbove.Checked = _model.Data.IncludeSeparatorAbove;
            ckSeparatorBelow.Checked = _model.Data.IncludeSeparatorBelow;
            tbInlineNote.Text = _model.Data.InlineNote ?? string.Empty;
            _model.DocumentOptions.ClockType.SetControlsVisibleIn12HourMode(new[] { cbToWorkHalfOfDay, cbLocoToWorkHalfOfDay });
            if (_model.Data.ToWork?.AtTime != null)
            {
                _model.Data.ToWork.AtTime.SetTime(tbToWorkHour, tbToWorkMinute, cbToWorkHalfOfDay, _model.DocumentOptions.ClockType);
            }
            if (_model.Data.LocoToWork?.AtTime != null)
            {
                _model.Data.LocoToWork.AtTime.SetTime(tbLocoToWorkHour, tbLocoToWorkMinute, cbLocoToWorkHalfOfDay, _model.DocumentOptions.ClockType);
            }
            tbToWorkText.Text = _model.Data.ToWork?.Text ?? string.Empty;
            tbLocoToWorkText.Text = _model.Data.LocoToWork?.Text ?? string.Empty;
            _inViewUpdate = false;
        }

        private void UpdateTimingsViewFromModel()
        {
            if (_model == null || _model.Data == null)
            {
                return;
            }
            dgvTimings.SuspendLayout();
            dgvTimings.Rows.Clear();
            foreach (var timing in _model.Data.TrainTimes.Where(t => t != null && t.Location != null))
            {
                string arrivalTime = timing.ArrivalTime?.Time != null ? FormatTimeSpan(timing.ArrivalTime.Time) : string.Empty;
                string departureTime = timing.DepartureTime?.Time != null ? FormatTimeSpan(timing.DepartureTime.Time) : string.Empty;
                dgvTimings.Rows.Add(timing.Location.EditorDisplayName, arrivalTime, departureTime);
            }
            btnAdjust.Enabled = _model.Data.TrainTimes.Count > 0;
        }

        private string FormatTimeSpan(TimeOfDay time)
        {
            return time.ToString(Model.DocumentOptions.ClockType == ClockType.TwentyFourHourClock ? "HH:mmf" : "h:mmf tt", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainEditForm()
        {
            InitializeComponent();
            _inViewUpdate = true;
            cbLinePattern.Items.AddRange(HumanReadableEnumFactory.GetDashStyles());
            TimeHelpers.PopulateHalfOfDayComboBoxes(cbToWorkHalfOfDay, cbLocoToWorkHalfOfDay);
            _inViewUpdate = false;
        }

        private void BtnAddTiming_Click(object sender, EventArgs e)
        {
            using (TrainLocationTimeEditForm form = new TrainLocationTimeEditForm
                {
                    Model = new TrainLocationTimeEditFormModel((_model != null && _model.ValidLocations != null) ? _model.ValidLocations : new LocationCollection(), 
                        _model?.ValidTimingPointNotes != null ? _model.ValidTimingPointNotes : new List<Note>())
                    {
                        Data = new TrainLocationTime { FormattingStrings = _model.DocumentOptions.FormattingStrings },
                        InputMode = _model.DocumentOptions.ClockType,
                    }
                })
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                if (_model == null || _model.Data == null)
                {
                    return;
                }

                _model.Data.TrainTimes.Add(form.Model.Data);
            }
            _model.Data.TrainTimes.Sort(new TrainLocationArrivalTimeComparer());
            UpdateTimingsViewFromModel();
        }

        private void DgvTimings_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            if (dgvTimings.SelectedCells.Count > 0)
            {
                btnEditTiming.Enabled = true;
                btnDeleteTiming.Enabled = true;
            }
            else
            {
                btnEditTiming.Enabled = false;
                btnDeleteTiming.Enabled = false;
            }
        }

        private void BtnEditTiming_Click(object sender, EventArgs e)
        {
            if (dgvTimings.SelectedCells.Count == 0)
            {
                return;
            }
            EditTimingRow(dgvTimings.SelectedCells[0].RowIndex);
        }

        private void DgvTimings_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                EditTimingRow(e.RowIndex);
            }
        }

        private void EditTimingRow(int rowIndex)
        {
            if (Model == null || Model.Data == null || Model.Data.TrainTimes == null || Model.Data.TrainTimes.Count <= rowIndex)
            {
                return;
            }
            using (TrainLocationTimeEditForm form = new TrainLocationTimeEditForm
                {
                    Model = new TrainLocationTimeEditFormModel(Model.ValidLocations, Model.ValidTimingPointNotes ?? new List<Note>())
                    {
                        Data = Model.Data.TrainTimes[rowIndex].Copy(),
                        InputMode = Model.DocumentOptions.ClockType,
                    }
                })
            {
                if (form.ShowDialog() != DialogResult.OK || form.Model == null || form.Model.Data == null)
                {
                    return;
                }
                Model.Data.TrainTimes[rowIndex] = form.Model.Data;
            }
            Model.Data.TrainTimes.Sort(new TrainLocationArrivalTimeComparer());
            UpdateTimingsViewFromModel();
        }

        private void BtnDeleteTiming_Click(object sender, EventArgs e)
        {
            if (dgvTimings.SelectedCells.Count == 0 || Model == null || Model.Data == null || Model.Data.TrainTimes == null)
            {
                return;
            }
            List<int> indices = new List<int>();
            for (var i = 0; i < dgvTimings.SelectedCells.Count; ++i)
            {
                indices.Add(dgvTimings.SelectedCells[i].RowIndex);
            }
            indices = indices.Where(i => i < Model.Data.TrainTimes.Count).OrderByDescending(i => i).Distinct().ToList();
            foreach (int idx in indices)
            {
                Model.Data.TrainTimes.RemoveAt(idx);
            }
            Model.Data.TrainTimes.Sort(new TrainLocationArrivalTimeComparer());
            UpdateTimingsViewFromModel();
        }

        private void TbHeadcode_Validated(object sender, EventArgs e)
        {
            Model.Data.Headcode = tbHeadcode.Text;
        }

        private void CbTrainClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate || _model.Data == null)
            {
                return;
            }
            if (cbTrainClass.SelectedIndex == 0)
            {
                _model.Data.TrainClassId = null;
                _model.Data.TrainClass = null;
                return;
            }
            if (!(cbTrainClass.SelectedItem is TrainClass cls))
            {
                return;
            }
            _model.Data.TrainClass = cls;
            _model.Data.TrainClassId = cls.Id;
        }

        private void NudLineWidth_ValueChanged(object sender, EventArgs e)
        {
            _model.Data.GraphProperties.Width = (float) nudLineWidth.Value;
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
            _model.Data.GraphProperties.DashStyle = pattern.Value;
        }

        private void BtnColour_Click(object sender, EventArgs e)
        {
            if (_model == null || _model.Data == null || _model.Data.GraphProperties == null)
            {
                return;
            }
            UIHelpers.ColourDialogueHelper(_model.Data.GraphProperties.Colour, c => _model.Data.GraphProperties.Colour = c, btnColour);
        }

        private void BtnAdjust_Click(object sender, EventArgs e)
        {
            TrainAdjustTimesFormModel adjustModel = new TrainAdjustTimesFormModel(_model.Data.TrainTimes.Select(t => t.Location).Where(loc => loc != null));
            using (TrainAdjustTimesForm form = new TrainAdjustTimesForm { Model = adjustModel })
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                AdjustTimes(form.Model);
            }
            UpdateTimingsViewFromModel();
        }

        private void AdjustTimes(TrainAdjustTimesFormModel adjustModel)
        {
            switch (adjustModel.AddSubtract)
            {
                case AddSubtract.Subtract:
                    foreach (var timing in _model.Data.TrainTimes)
                    {
                        timing.OffsetTimes(-adjustModel.Offset);
                    }
                    break;
                case AddSubtract.Add:
                    bool foundStartingPoint = adjustModel.SelectedLocation == null;
                    foreach (var timing in _model.Data.TrainTimes)
                    {
                        if (!foundStartingPoint && adjustModel.SelectedLocation.Id != timing.Location.Id)
                        {
                            continue;
                        }
                        if ((foundStartingPoint || (adjustModel.SelectedLocation.Id == timing.Location.Id && adjustModel.ArriveDepart == ArrivalDepartureOptions.Arrival)) 
                            && timing.ArrivalTime?.Time != null)
                        {
                            timing.ArrivalTime.Time.AddMinutes(adjustModel.Offset);
                        }
                        if (timing.DepartureTime?.Time != null)
                        {
                            timing.DepartureTime.Time.AddMinutes(adjustModel.Offset);
                        }
                        foundStartingPoint = true;
                    }
                    break;
            }
        }

        private void ClbFootnotes_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }
            if (!(clbFootnotes.Items[e.Index] is Note item))
            {
                return;
            }
            if (e.NewValue == CheckState.Checked && !_model.Data.Footnotes.Any(n => n.Id == item.Id))
            {
                _model.Data.Footnotes.Add(item);
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                _model.Data.Footnotes.RemoveAll(n => n.Id == item.Id);
            }
        }

        private void TbLocoDiagram_TextChanged(object sender, EventArgs e)
        {
            Model.Data.LocoDiagram = tbLocoDiagram.Text;
        }

        private void CkSeparatorAbove_CheckedChanged(object sender, EventArgs e)
        {
            if (!_inViewUpdate)
            {
                _model.Data.IncludeSeparatorAbove = ckSeparatorAbove.Checked;
            }
        }

        private void CkSeparatorBelow_CheckedChanged(object sender, EventArgs e)
        {
            if (!_inViewUpdate)
            {
                _model.Data.IncludeSeparatorBelow = ckSeparatorBelow.Checked;
            }
        }

        private void TbInlineNote_TextChanged(object sender, EventArgs e)
        {
            if (!_inViewUpdate && _model?.Data != null)
            {
                _model.Data.InlineNote = tbInlineNote.Text;
            }
        }

        private void TextBoxHoursMinutes_Validating(object sender, CancelEventArgs e)
        {
            UIHelpers.ValidateIntegerTextBox(sender as TextBox, errorProvider, Resources.TrainLocationTimeEditForm_ValidateTimes_Error, e);
        }

        private void TextBoxToWorkHoursMinutes_Validated(object sender, EventArgs e)
        {
            StoreToWorkTime();
        }

        private void CbToWorkHalfOfDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }

            StoreToWorkTime();
        }

        private void StoreToWorkTime()
        {
            if (_model.Data == null)
            {
                return;
            }
            if (_model.Data.ToWork == null)
            {
                _model.Data.ToWork = new ToWork();
            }

            TimeHelpers.SetTimeProperty(_model.Data.ToWork, _model.Data.ToWork.GetType().GetProperty(nameof(_model.Data.ToWork.AtTime)), tbToWorkHour, tbToWorkMinute, 
                _model.DocumentOptions.ClockType == ClockType.TwelveHourClock ? cbToWorkHalfOfDay : null, _model.Data.ToWork.AtTime != null ? _model.Data.ToWork.AtTime.Seconds : 0);
        }

        private void TbToWorkText_TextChanged(object sender, EventArgs e)
        {
            StoreToWorkText();
        }

        private void StoreToWorkText()
        {
            if (_model.Data == null)
            {
                return;
            }
            if (_model.Data.ToWork == null)
            {
                _model.Data.ToWork = new ToWork();
            }

            _model.Data.ToWork.Text = tbToWorkText.Text;
        }

        private void StoreLocoToWorkTime()
        {
            if (_model.Data == null)
            {
                return;
            }
            if (_model.Data.LocoToWork == null)
            {
                _model.Data.LocoToWork = new ToWork();
            }

            TimeHelpers.SetTimeProperty(_model.Data.LocoToWork, _model.Data.LocoToWork.GetType().GetProperty(nameof(_model.Data.LocoToWork.AtTime)), tbLocoToWorkHour, tbLocoToWorkMinute,
                _model.DocumentOptions.ClockType == ClockType.TwelveHourClock ? cbLocoToWorkHalfOfDay : null, _model.Data.LocoToWork.AtTime != null ? _model.Data.LocoToWork.AtTime.Seconds : 0);
        }

        private void StoreLocoToWorkText()
        {
            if (_model.Data == null)
            {
                return;
            }
            if (_model.Data.LocoToWork == null)
            {
                _model.Data.LocoToWork = new ToWork();
            }

            _model.Data.LocoToWork.Text = tbLocoToWorkText.Text;
        }

        private void TextBoxLocoToWorkHoursMinutes_Validated(object sender, EventArgs e)
        {
            StoreLocoToWorkTime();
        }

        private void CbLocoToWorkHalfOfDay_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_inViewUpdate)
            {
                return;
            }

            StoreLocoToWorkTime();
        }

        private void TbLocoToWorkText_TextChanged(object sender, EventArgs e)
        {
            StoreLocoToWorkText();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (Model?.Data?.TrainTimes != null && Model.Data.TrainTimes.Count > 0)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            if (MessageBox.Show(this, Resources.TrainEditForm_NoTimingPoints_Warning, Resources.TrainEditForm_NoTimingPoints_WarningTitle, MessageBoxButtons.OKCancel, 
                MessageBoxIcon.Warning) == DialogResult.OK)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
