using System;
using System.ComponentModel;
using System.Windows.Forms;
using Timetabler.Helpers;
using Timetabler.Models;

namespace Timetabler
{
    /// <summary>
    /// Form for specifying how to make a copy of a train.
    /// </summary>
    public partial class TrainCopyForm : Form
    {
        private TrainCopyFormModel _model;

        private bool _inUpdate = false;

        /// <summary>
        /// The model object containing the form data.
        /// </summary>
        public TrainCopyFormModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                UpdateFormFromModel();
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainCopyForm()
        {
            InitializeComponent();
            cbAddSubtract.Items.AddRange(HumanReadableEnum<AddSubtract>.GetAddSubtract());
        }

        private void UpdateFormFromModel()
        {
            if (Model == null)
            {
                return;
            }
            _inUpdate = true;
            lblTitle.Text = string.Format(Resources.TrainCopyForm_TrainHeadcode_FormatString, Model.TrainName);
            tbOffset.Text = Model.Offset.ToString();
            ckClearInlineNote.Checked = Model.ClearInlineNotes;
            SetAddSubtractValue();
            _inUpdate = false;
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

        private void CbAddSubtract_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = cbAddSubtract.SelectedItem as HumanReadableEnum<AddSubtract>;
            if (_model == null || selItem == null || _inUpdate)
            {
                return;
            }
            _model.AddSubtract = selItem.Value;
        }

        private void TbOffset_Validated(object sender, EventArgs e)
        {
            if (_model == null)
            {
                return;
            }
            int.TryParse(tbOffset.Text, out int val);
            if (val < 0)
            {
                return;
            }
            _model.Offset = val;
        }

        private void TbOffset_Validating(object sender, CancelEventArgs e)
        {
            InputValidationHelper.ValidateTextInputAsNonNegativeInt(sender as TextBox, errorProvider, Resources.TrainCopyForm_Offset_ValidationFailure);
        }
    }
}
