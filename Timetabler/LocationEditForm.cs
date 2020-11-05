using System;
using System.ComponentModel;
using System.Globalization;
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
            cbFontType.Items.AddRange(HumanReadableEnumFactory.GetLocationFontType());
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
            tbMileage.Text = _model.Mileage.Mileage.ToString(CultureInfo.CurrentCulture);
            tbChainage.Text = ((int)_model.Mileage.Chainage).ToString(CultureInfo.CurrentCulture);
            SetLocationFontTypeCbValue();
        }

        private void SetLocationFontTypeCbValue()
        {
            foreach (var item in cbFontType.Items)
            {
                if (item is HumanReadableEnum<LocationFontType> lftItem && _model.FontType == lftItem.Value)
                {
                    cbFontType.SelectedItem = lftItem;
                    break;
                }
            }
        }

        private void TbTiploc_Validated(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.Tiploc = tbTiploc.Text;
            }
        }

        private void TbEditorName_Validated(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.EditorDisplayName = tbEditorName.Text;
            }
        }

        private void TbGraphName_Validated(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.GraphDisplayName = tbGraphName.Text;
            }
        }

        private void TbTableName_Validated(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.TimetableDisplayName = tbTableName.Text;
            }
        }

        private void CkShowArrivalUp_CheckedChanged(object sender, EventArgs e)
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

        private void CkShowDepartureUp_CheckedChanged(object sender, EventArgs e)
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

        private void CkShowArrivalDown_CheckedChanged(object sender, EventArgs e)
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

        private void CkShowDepartureDown_CheckedChanged(object sender, EventArgs e)
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

        private void TbMileage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbMileage.Text))
            {
                return;
            }

            if (int.TryParse(tbMileage.Text, out _))
            {
                errorProvider.SetError(tbMileage, string.Empty);
            }
            else
            {
                errorProvider.SetError(tbMileage, Resources.LocationEditForm_Mileage_ValidationFailureNaN);
                e.Cancel = true;
            }
        }

        private void TbChainage_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbChainage.Text))
            {
                return;
            }

            if (int.TryParse(tbChainage.Text, out int val))
            {
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
            else
            {
                errorProvider.SetError(tbChainage, Resources.LocationEditForm_Chainage_ValidationFailureNaN);
                e.Cancel = true;
                return;
            }
        }

        private void TbMileage_Validated(object sender, EventArgs e)
        {
            if (_model == null || _model.Mileage == null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(tbMileage.Text))
            {
                _model.Mileage = new Distance(0, _model.Mileage.Chainage);
            }

            if (!int.TryParse(tbMileage.Text, out int val))
            {
                _model.Mileage = new Distance(0, _model.Mileage.Chainage);
            }
            else
            {
                _model.Mileage = new Distance(val, _model.Mileage.Chainage);
            }
        }

        private void TbChainage_Validated(object sender, EventArgs e)
        {
            if (_model == null || _model.Mileage == null)
            {
                return;
            }
            if (string.IsNullOrWhiteSpace(tbChainage.Text))
            {
                _model.Mileage = new Distance(_model.Mileage.Mileage, 0);
            }

            if (int.TryParse(tbChainage.Text, out int val))
            {
                _model.Mileage = new Distance(_model.Mileage.Mileage, val);
            }
        }

        private void CbFontType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_model == null || !(cbFontType.SelectedItem is HumanReadableEnum<LocationFontType> lftItem))
            {
                return;
            }

            _model.FontType = lftItem.Value;
        }

        private void CkShowPathDown_CheckedChanged(object sender, EventArgs e)
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

        private void CkShowPlatformDown_CheckedChanged(object sender, EventArgs e)
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

        private void CkShowLineDown_CheckedChanged(object sender, EventArgs e)
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

        private void CkShowPathUp_CheckedChanged(object sender, EventArgs e)
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

        private void CkShowPlatformUp_CheckedChanged(object sender, EventArgs e)
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

        private void CkShowLineUp_CheckedChanged(object sender, EventArgs e)
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

        private void CkDisplaySeparatorAbove_CheckedChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            _model.DisplaySeparatorAbove = ckDisplaySeparatorAbove.Checked;
        }

        private void CkDisplaySeparatorBelow_CheckedChanged(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }

            _model.DisplaySeparatorBelow = ckDisplaySeparatorBelow.Checked;
        }
    }
}
