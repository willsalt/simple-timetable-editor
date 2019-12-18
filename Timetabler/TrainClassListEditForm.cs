using System;
using System.Windows.Forms;
using Timetabler.CoreData.Helpers;
using Timetabler.Data;
using Timetabler.Data.Collections;

namespace Timetabler
{
    /// <summary>
    /// A form for editing a list of train classes.
    /// </summary>
    public partial class TrainClassListEditForm : Form
    {
        private TrainClassCollection _model;

        /// <summary>
        /// The data to be edited.
        /// </summary>
        public TrainClassCollection Model
        {
            get
            {
                return _model;
            }
            private set
            {
                _model = value;
                UpdateViewToModel();
            }
        }

        private void UpdateViewToModel()
        {
            dataGridView.Rows.Clear();
            foreach (TrainClass tc in _model)
            {
                dataGridView.Rows.Add(tc.TableCode, tc.Description);
            }
            ResetButtons();
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainClassListEditForm(TrainClassCollection model)
        {
            InitializeComponent();
            Model = model;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (TrainClassEditForm tcef = new TrainClassEditForm { Model = new TrainClass { Id = GeneralHelper.GetNewId(_model) } })
            {
                DialogResult result = tcef.ShowDialog();
                if (result == DialogResult.OK)
                {
                    _model.Add(tcef.Model);
                    UpdateViewToModel();
                }
            }
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            ResetButtons();
        }

        private void ResetButtons()
        {
            if (dataGridView.SelectedCells.Count == 0)
            {
                btnDel.Enabled = false;
                btnEdit.Enabled = false;
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                return;
            }
            var cellRow = dataGridView.SelectedCells[0].RowIndex;
            btnEdit.Enabled = true;
            btnDel.Enabled = true;
            btnUp.Enabled = cellRow > 0;
            btnDown.Enabled = cellRow < (dataGridView.Rows.Count - 1);
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (_model == null || dataGridView.SelectedCells.Count == 0)
            {
                return;
            }
            _model.RemoveAt(dataGridView.SelectedCells[0].RowIndex);
            UpdateViewToModel();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (_model == null || dataGridView.SelectedCells.Count == 0)
            {
                return;
            }
            EditRow(dataGridView.SelectedCells[0].RowIndex);
        }

        private void EditRow(int idx)
        {
            using (TrainClassEditForm tcef = new TrainClassEditForm { Model = _model[idx].Copy() })
            {
                DialogResult result = tcef.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tcef.Model.CopyTo(_model[idx]);
                    UpdateViewToModel();
                }
            }
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            if (_model == null || dataGridView.SelectedCells.Count == 0)
            {
                return;
            }
            int idx = dataGridView.SelectedCells[0].RowIndex;
            if (idx == 0)
            {
                return;
            }

            TrainClass swap = _model[idx];
            _model[idx] = _model[idx - 1];
            _model[idx - 1] = swap;

            UpdateViewToModel();    
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            if (_model == null || dataGridView.SelectedCells.Count == 0)
            {
                return;
            }
            int idx = dataGridView.SelectedCells[0].RowIndex;
            if (idx >= _model.Count - 1)
            {
                return;
            }

            TrainClass swap = _model[idx];
            _model[idx] = _model[idx + 1];
            _model[idx + 1] = swap;

            UpdateViewToModel();
        }

        private void DataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < _model.Count)
            {
                EditRow(e.RowIndex);
            }
        }
    }
}
