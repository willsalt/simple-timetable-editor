using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                if (_model.ValidLocations != null)
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
                var adItem = item as HumanReadableEnum<ArrivalDepartureOptions>;
                if (adItem != null && _model.ArriveDepart == adItem.Value)
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
            tbOffset.Text = _model.Offset.ToString();
        }

        private void SetAddSubtractValue()
        {
            foreach (var item in cbAddSubtract.Items)
            {
                var asItem = item as HumanReadableEnum<AddSubtract>;
                if (asItem != null && asItem.Value == _model.AddSubtract)
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
            cbAddSubtract.Items.AddRange(HumanReadableEnum<AddSubtract>.GetAddSubtract());
            cbArriveDepart.Items.AddRange(HumanReadableEnum<ArrivalDepartureOptions>.GetArrivalDeparture());
        }

        private void cbAddSubtract_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = cbAddSubtract.SelectedItem as HumanReadableEnum<AddSubtract>;
            if (_model == null || selItem == null)
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
            var arriveDepart = cbArriveDepart.SelectedItem as HumanReadableEnum<ArrivalDepartureOptions>;
            if (_model == null || arriveDepart == null)
            {
                return;
            }
            _model.ArriveDepart = arriveDepart.Value;
        }

        private void tbOffset_Validating(object sender, CancelEventArgs e)
        {
            int dummy;
            if (!int.TryParse(tbOffset.Text, out dummy) || dummy < 0)
            {
                errorProvider.SetError(tbOffset, Resources.TrainAdjustTimesForm_Offset_ValidationFailure);
            }
            else
            {
                errorProvider.SetError(tbOffset, string.Empty);
            }
        }

        private void tbOffset_Validated(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }
            int val;
            int.TryParse(tbOffset.Text, out val);
            if (val < 0)
            {
                return;
            }
            _model.Offset = val;
        }
    }
}
