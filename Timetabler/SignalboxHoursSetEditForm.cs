using System.Windows.Forms;
using Timetabler.Data;
using Timetabler.Data.Events;
using Timetabler.Models;

namespace Timetabler
{
    /// <summary>
    /// Form for editing <see cref="SignalboxHoursSet" /> objects.
    /// </summary>
    public partial class SignalboxHoursSetEditForm : Form
    {
        private const int BoxIdColIdx = 0;
        //private const int BoxColIdx = 1;
        private const int StartColIdx = 2;
        private const int EndColIdx = 3;

        private SignalboxHoursSetEditFormModel _model;

        /// <summary>
        /// The data to be edited.
        /// </summary>
        public SignalboxHoursSetEditFormModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                UpdateViewFromModel();
                _model.Data.SignalboxHoursModified += SignalboxHoursSetModified;
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SignalboxHoursSetEditForm()
        {
            InitializeComponent();
        }

        private void UpdateViewFromModel()
        {
            if (_model?.Data == null)
            {
                return;
            }

            tbCategory.Text = _model.Data.Category;
            dgvHours.Rows.Clear();
            foreach (var h in _model.Data.Hours.Values)
            {
                string[] displayStrings = h.ToStrings(_model.InputMode);
                dgvHours.Rows.Add(h.Signalbox.Id, h.Signalbox.EditorDisplayName, displayStrings[0], displayStrings[1]);
            }
        }

        private void SignalboxHoursSetModified(object sender, SignalboxHoursEventArgs e)
        {
            if (e?.SignalboxHours?.Signalbox?.Id == null)
            {
                return;
            }
            for (int i = 0; i < dgvHours.RowCount; ++i)
            {
                if (dgvHours[BoxIdColIdx, i]?.Value as string == e.SignalboxHours.Signalbox.Id)
                {
                    string[] displayStrings = e.SignalboxHours.ToStrings(_model.InputMode);
                    dgvHours[StartColIdx, i].Value = displayStrings[0];
                    dgvHours[EndColIdx, i].Value = displayStrings[1];
                    break;
                }
            }
        }

        private void dgvHours_SelectionChanged(object sender, System.EventArgs e)
        {
            btnEdit.Enabled = dgvHours.SelectedCells.Count > 0;
        }

        private void btnEdit_Click(object sender, System.EventArgs e)
        {
            if (dgvHours.SelectedCells.Count > 0)
            {
                EditSelectedRow(dgvHours.SelectedCells[0].RowIndex);
            }
        }

        private void dgvHours_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditSelectedRow(e.RowIndex);
        }

        private void EditSelectedRow(int rowIndex)
        {
            string boxIdx = dgvHours[BoxIdColIdx, rowIndex].Value as string;
            if (!_model.Data.Hours.ContainsKey(boxIdx))
            {
                return;
            }
            SignalboxHours hours = _model.Data.Hours[boxIdx];
            using (SignalboxHoursEditForm form = new SignalboxHoursEditForm { Model = new SignalboxHoursEditFormModel { Data = hours.Copy(), InputMode = _model.InputMode } })
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                form.Model.Data.CopyTo(hours);
            }
        }

        private void tbCategory_TextChanged(object sender, System.EventArgs e)
        {
            if (_model?.Data != null)
            {
                _model.Data.Category = tbCategory.Text;
            }
        }
    }
}
