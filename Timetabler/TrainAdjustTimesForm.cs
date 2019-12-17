using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Helpers;
using Timetabler.Models;

namespace Timetabler
{
    /// <summary>
    /// A form for adding or subtracting a uniform number of minutes from a train's timing points.
    /// </summary>
    public partial class TrainAdjustTimesForm : Form
    {
        private TrainAdjustTimesFormModel _model;

        /// <summary>
        /// The data model to be edited by this form.
        /// </summary>
        public TrainAdjustTimesFormModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                if (_model?.ValidLocations != null)
                {
                    SetLocationsComboBoxItems();
                }
                UpdateViewFromModel();
            }
        }

        private void UpdateViewFromModel()
        {
            SetAddSubtractValue();
            SetOffsetValue();
            SetLocationValue();
            SetArrivalDepartureValue();
        }

        private void SetArrivalDepartureValue()
        {
            foreach (var item in cbArriveDepart.Items)
            {
                if (item is HumanReadableEnum<ArrivalDepartureOptions> adItem && _model.ArriveDepart == adItem.Value)
                {
                    cbArriveDepart.SelectedItem = adItem;
                    break;
                }
            }
        }

        private void SetLocationValue()
        {
            if (_model.SelectedLocation == null)
            {
                return;
            }
            foreach (var item in cbLocation.Items)
            {
                var locItem = item as Location;
                if (locItem != null && locItem.Id == _model.SelectedLocation.Id)
                {
                    cbLocation.SelectedItem = locItem;
                    break;
                }
            }
        }

        private void SetOffsetValue()
        {
            tbOffset.Text = _model.Offset.ToString(CultureInfo.CurrentCulture);
        }

        private void SetAddSubtractValue()
        {
            foreach (var item in cbAddSubtract.Items)
            {
                if (item is HumanReadableEnum<AddSubtract> asItem && asItem.Value == _model.AddSubtract)
                {
                    cbAddSubtract.SelectedItem = asItem;
                    break;
                }
            }
        }

        private void SetLocationsComboBoxItems()
        {
            cbLocation.BeginUpdate();
            cbLocation.Items.Clear();
            cbLocation.Items.AddRange(Model.ValidLocations.ToArray());
            cbLocation.EndUpdate();
        }

        /// <summary>
        /// Default constructor; initialises values of the add/subtract and arrive/depart combo boxes.
        /// </summary>
        public TrainAdjustTimesForm()
        {
            InitializeComponent();
            cbAddSubtract.Items.AddRange(HumanReadableEnumFactory.GetAddSubtract());
            cbArriveDepart.Items.AddRange(HumanReadableEnumFactory.GetArrivalDeparture());
        }

        private void cbAddSubtract_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_model == null || !(cbAddSubtract.SelectedItem is HumanReadableEnum<AddSubtract> selItem))
            {
                return;
            }
            _model.AddSubtract = selItem.Value;
            switch (selItem.Value)
            {
                case AddSubtract.Add:
                    SetSecondRowVisible(true);
                    break;
                case AddSubtract.Subtract:
                    SetSecondRowVisible(false);
                    break;
            }
        }

        private void SetSecondRowVisible(bool visible)
        {
            lblAfter.Visible = visible;
            lblTiming.Visible = visible;
            cbArriveDepart.Visible = visible;
            cbLocation.Visible = visible;
        }

        private void cbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }
            _model.SelectedLocation = cbLocation.SelectedItem as Location;
        }

        private void cbArriveDepart_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_model == null || !(cbArriveDepart.SelectedItem is HumanReadableEnum<ArrivalDepartureOptions> arriveDepart))
            {
                return;
            }
            _model.ArriveDepart = arriveDepart.Value;
        }

        private void TbOffset_Validating(object sender, CancelEventArgs e)
        {
            InputValidationHelper.ValidateTextInputAsNonNegativeInt(sender as TextBox, errorProvider, Resources.TrainAdjustTimesForm_Offset_ValidationFailure);
        }

        private void tbOffset_Validated(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }
            if (!int.TryParse(tbOffset.Text, out int val))
            {
                return;
            }
            if (val < 0)
            {
                return;
            }
            _model.Offset = val;
        }
    }
}
