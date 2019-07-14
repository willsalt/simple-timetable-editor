using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timetabler.Helpers;
using Timetabler.Models;

namespace Timetabler
{
    public partial class TrainCopyForm : Form
    {
        private TrainCopyFormModel _model;

        private bool _inUpdate = false;

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
                var asItem = item as HumanReadableEnum<AddSubtract>;
                if (asItem != null && asItem.Value == _model.AddSubtract)
                {
                    cbAddSubtract.SelectedItem = asItem;
                    break;
                }
            }
        }

        private void cbAddSubtract_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selItem = cbAddSubtract.SelectedItem as HumanReadableEnum<AddSubtract>;
            if (_model == null || selItem == null || _inUpdate)
            {
                return;
            }
            _model.AddSubtract = selItem.Value;
        }

        private void tbOffset_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
