using System;
using System.ComponentModel;
using System.Windows.Forms;
using Timetabler.CoreData;
using Timetabler.Data;
using Timetabler.Helpers;

namespace Timetabler
{
    /// <summary>
    /// A <see cref="Form"/> subclass for editing locations.
    /// </summary>
    public partial class LocationEditForm : Form
    {
        private Location _model;

        /// <summary>
        /// The <see cref="Location"/> to be edited by this form.
        /// </summary>
        public Location Model
        {
            get { return _model; }
            set
            {
                _model = value;
                UpdateModelToView();
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocationEditForm()
        {
            _model = new Location();
            InitializeComponent();
            PopulateFontTypeComboBox();
        }

        private void PopulateFontTypeComboBox()
        {
            cbFontType.BeginUpdate();
            cbFontType.Items.AddRange(HumanReadableEnum<LocationFontType>.GetLocationFontType());
            cbFontType.EndUpdate();
        }

        private void UpdateModelToView()
        {
            if (_model == null)
            {
                return;
            }

            tbTiploc.Text = _model.Tiploc;
            tbEditorName.Text = _model.EditorDisplayName;
            tbTableName.Text = _model.TimetableDisplayName;
            tbGraphName.Text = _model.GraphDisplayName;
            ckShowArrivalUp.Checked = (_model.UpArrivalDepartureAlwaysDisplayed & ArrivalDepartureOptions.Arrival) != 0;
            ckShowDepartureUp.Checked = (_model.UpArrivalDepartureAlwaysDisplayed & ArrivalDepartureOptions.Departure) != 0;
            ckShowArrivalDown.Checked = (_model.DownArrivalDepartureAlwaysDisplayed & ArrivalDepartureOptions.Arrival) != 0;
            ckShowDepartureDown.Checked = (_model.DownArrivalDepartureAlwaysDisplayed & ArrivalDepartureOptions.Departure) != 0;
            ckShowPathUp.Checked = (_model.UpRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Path) != 0;
            ckShowPlatformUp.Checked = (_model.UpRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Platform) != 0;
            ckShowLineUp.Checked = (_model.UpRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Line) != 0;
            ckShowPathDown.Checked = (_model.DownRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Path) != 0;
            ckShowPlatformDown.Checked = (_model.DownRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Platform) != 0;
            ckShowLineDown.Checked = (_model.DownRoutingCodesAlwaysDisplayed & TrainRoutingOptions.Line) != 0;
            ckDisplaySeparatorAbove.Checked = _model.DisplaySeparatorAbove;
            ckDisplaySeparatorBelow.Checked = _model.DisplaySeparatorBelow;

            if (_model.Mileage == null)
            {
                return;
            }
            tbMileage.Text = _model.Mileage.Mileage.ToString();
            tbChainage.Text = ((int)_model.Mileage.Chainage).ToString();
            SetLocationFontTypeCbValue();
        }

        private void SetLocationFontTypeCbValue()
        {
            foreach (var item in cbFontType.Items)
            {
                var lftItem = item as HumanReadableEnum<LocationFontType>;
                if (lftItem != null && _model.FontType == lftItem.Value)
                {
                    cbFontType.SelectedItem = lftItem;
                    break;
                }
            }
        }

        private void tbTiploc_Validated(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.Tiploc = tbTiploc.Text;
            }
        }

        private void tbEditorName_Validated(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.EditorDisplayName = tbEditorName.Text;
            }
        }

        private void tbGraphName_Validated(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.GraphDisplayName = tbGraphName.Text;
            }
        }

        private void tbTableName_Validated(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.TimetableDisplayName = tbTableName.Text;
            }
        }

        private void ckShowArrivalUp_CheckedChanged(object sender, EventArgs e)
        {
            if (_model != null)
            {
                if (ckShowArrivalUp.Checked)
                {
                    _model.UpArrivalDepartureAlwaysDisplayed |= ArrivalDepartureOptions.Arrival;
                }
                else
                {
                    _model.UpArrivalDepartureAlwaysDisplayed &= ~ArrivalDepartureOptions.Arrival;
                }
            }
        }

        private void ckShowDepartureUp_CheckedChanged(object sender, EventArgs e)
        {
            if (_model != null)
            {
                if (ckShowDepartureUp.Checked)
                {
                    _model.UpArrivalDepartureAlwaysDisplayed |= ArrivalDepartureOptions.Departure;
                }
                else
                {
                    _model.UpArrivalDepartureAlwaysDisplayed &= ~ArrivalDepartureOptions.Departure;
                }
            }
        }

        private void ckShowArrivalDown_CheckedChanged(object sender, EventArgs e)
        {
            if (_model != null)
            {
                if (ckShowArrivalDown.Checked)
                {
                    _model.DownArrivalDepartureAlwaysDisplayed |= ArrivalDepartureOptions.Arrival;
                }
                else
                {
                    _model.DownArrivalDepartureAlwaysDisplayed &= ~ArrivalDepartureOptions.Arrival;
                }
            }
        }

        private void ckShowDepartureDown_CheckedChanged(object sender, EventArgs e)
        {
            if (_model != null)
            {
                if (ckShowDepartureDown.Checked)
                {
                    _model.DownArrivalDepartureAlwaysDisplayed |= ArrivalDepartureOptions.Departure;
                }
                else
                {
                    _model.DownArrivalDepartureAlwaysDisplayed &= ~ArrivalDepartureOptions.Departure;
                }
            }
        }

        private void tbMileage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMileage.Text))
            {
                return;
            }

            int dummy;
            if (!int.TryParse(tbMileage.Text, out dummy))
            {
                errorProvider.SetError(tbMileage, Resources.LocationEditForm_Mileage_ValidationFailureNaN);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbMileage, string.Empty);
            }
        }

        private void tbChainage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbChainage.Text))
            {
                return;
            }

            int val;
            if (!int.TryParse(tbChainage.Text, out val))
            {
                errorProvider.SetError(tbChainage, Resources.LocationEditForm_Chainage_ValidationFailureNaN);
                e.Cancel = true;
                return;
            }
            if (val < 0 || val >= 80)
            {
                errorProvider.SetError(tbChainage, Resources.LocationEditForm_Chainage_ValidationFailureOutOfRange);
                e.Cancel = true;
            }
            else
            {
                errorProvider.SetError(tbChainage, string.Empty);
            }
        }

        private void tbMileage_Validated(object sender, EventArgs e)
        {
            if (_model == null || _model.Mileage == null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(tbMileage.Text))
            {
                _model.Mileage.Mileage = 0;
            }

            int val;
            if (int.TryParse(tbMileage.Text, out val))
            {
                _model.Mileage.Mileage = val;
            }
            else
            {
                _model.Mileage.Mileage = 0;
            }
        }

        private void tbChainage_Validated(object sender, EventArgs e)
        {
            if (_model == null || _model.Mileage == null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(tbChainage.Text))
            {
                _model.Mileage.Chainage = 0;
            }

            int val;
            if (int.TryParse(tbChainage.Text, out val))
            {
                _model.Mileage.Chainage = val;
            }
            else
            {
                _model.Mileage.Chainage = 0;
            }
        }

        private void cbFontType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            var lftItem = cbFontType.SelectedItem as HumanReadableEnum<LocationFontType>;
            if (lftItem == null)
            {
                return;
            }

            _model.FontType = lftItem.Value;
        }

        private void ckShowPathDown_CheckedChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            if (ckShowPathDown.Checked)
            {
                _model.DownRoutingCodesAlwaysDisplayed |= TrainRoutingOptions.Path;
            }
            else
            {
                _model.DownRoutingCodesAlwaysDisplayed &= ~TrainRoutingOptions.Path;
            }
        }

        private void ckShowPlatformDown_CheckedChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            if (ckShowPlatformDown.Checked)
            {
                _model.DownRoutingCodesAlwaysDisplayed |= TrainRoutingOptions.Platform;
            }
            else
            {
                _model.DownRoutingCodesAlwaysDisplayed &= ~TrainRoutingOptions.Platform;
            }
        }

        private void ckShowLineDown_CheckedChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            if (ckShowLineDown.Checked)
            {
                _model.DownRoutingCodesAlwaysDisplayed |= TrainRoutingOptions.Line;
            }
            else
            {
                _model.DownRoutingCodesAlwaysDisplayed &= ~TrainRoutingOptions.Line;
            }
        }

        private void ckShowPathUp_CheckedChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            if (ckShowPathUp.Checked)
            {
                _model.UpRoutingCodesAlwaysDisplayed |= TrainRoutingOptions.Path;
            }
            else
            {
                _model.UpRoutingCodesAlwaysDisplayed &= ~TrainRoutingOptions.Path;
            }
        }

        private void ckShowPlatformUp_CheckedChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            if (ckShowPlatformUp.Checked)
            {
                _model.UpRoutingCodesAlwaysDisplayed |= TrainRoutingOptions.Platform;
            }
            else
            {
                _model.UpRoutingCodesAlwaysDisplayed &= ~TrainRoutingOptions.Platform;
            }
        }

        private void ckShowLineUp_CheckedChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            if (ckShowLineUp.Checked)
            {
                _model.UpRoutingCodesAlwaysDisplayed |= TrainRoutingOptions.Line;
            }
            else
            {
                _model.UpRoutingCodesAlwaysDisplayed &= ~TrainRoutingOptions.Line;
            }
        }

        private void ckDisplaySeparatorAbove_CheckedChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            _model.DisplaySeparatorAbove = ckDisplaySeparatorAbove.Checked;
        }

        private void ckDisplaySeparatorBelow_CheckedChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            _model.DisplaySeparatorBelow = ckDisplaySeparatorBelow.Checked;
        }
    }
}
