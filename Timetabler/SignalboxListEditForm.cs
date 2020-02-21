using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Timetabler.CoreData.Helpers;
using Timetabler.Data;
using Timetabler.Data.Collections;
using Timetabler.Data.Events;

namespace Timetabler
{
    /// <summary>
    /// Form to edit the signalboxes on the map.
    /// </summary>
    public partial class SignalboxListEditForm : Form
    {
        private SignalboxCollection _model;

        private const int _codeColIdx = 1;
        private const int _nameColIdx = 2;
        private const int _idColIdx = 0;

        /// <summary>
        /// The collection of signalboxes to be edited.
        /// </summary>
        public SignalboxCollection Model
        {
            get
            {
                return _model;
            }
            private set
            {
                if (_model != null)
                {
                    _model.SignalboxAdd -= AddSignalboxHandler;
                    _model.SignalboxRemove -= RemoveSignalboxHandler;
                    foreach (Signalbox box in _model)
                    {
                        box.CodeChanged -= ChangeSignalboxCodeHandler;
                        box.EditorDisplayNameChanged -= ChangeSignalboxNameHandler;
                    }
                }
                _model = value;
                if (_model != null)
                {
                    _model.SignalboxAdd += AddSignalboxHandler;
                    _model.SignalboxRemove += RemoveSignalboxHandler;
                    foreach (Signalbox box in _model)
                    {
                        box.CodeChanged += ChangeSignalboxCodeHandler;
                        box.EditorDisplayNameChanged += ChangeSignalboxNameHandler;
                    }
                }
                UpdateViewFromModel();
            }
        }

        private readonly Dictionary<string, DataGridViewRow> _rowMap;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SignalboxListEditForm(SignalboxCollection model)
        {
            _rowMap = new Dictionary<string, DataGridViewRow>();
            InitializeComponent();
            Model = model;
        }

        private void UpdateViewFromModel()
        {
            dataGridView.Rows.Clear();
            if (Model ==  null)
            {
                return;
            }
            foreach (var box in Model)
            {
                dataGridView.Rows.Add(box.Id, box.Code, box.EditorDisplayName);
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            Signalbox newBox = new Signalbox { Id = GeneralHelper.GetNewId(Model) };
            using (SignalboxEditForm form = new SignalboxEditForm { Model = newBox })
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                Model.Add(form.Model);
            }
        }

        private void RemoveSignalboxHandler(object sender, SignalboxEventArgs e)
        {
            if (e.Signalbox == null)
            {
                return;
            }
            e.Signalbox.CodeChanged -= ChangeSignalboxCodeHandler;
            e.Signalbox.EditorDisplayNameChanged -= ChangeSignalboxNameHandler;
            dataGridView.Rows.Remove(_rowMap[e.Signalbox.Id]);
            _rowMap.Remove(e.Signalbox.Id);
        }

        private void AddSignalboxHandler(object sender, SignalboxEventArgs e)
        {
            if (e.Signalbox == null)
            {
                return;
            }
            e.Signalbox.CodeChanged += ChangeSignalboxCodeHandler;
            e.Signalbox.EditorDisplayNameChanged += ChangeSignalboxNameHandler;
            DataGridViewRow row = dataGridView.RowTemplate.Clone() as DataGridViewRow;
            row.CreateCells(dataGridView);
            row.Cells[_idColIdx].Value = e.Signalbox.Id;
            row.Cells[_codeColIdx].Value = e.Signalbox.Code;
            row.Cells[_nameColIdx].Value = e.Signalbox.EditorDisplayName;
            if (!e.Index.HasValue || e.Index >= Model.Count - 1)
            {               
                dataGridView.Rows.Add(row);
            }
            else
            {
                dataGridView.Rows.Insert(e.Index.Value, row);
            }
            _rowMap.Add(e.Signalbox.Id, row);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 0)
            {
                return;
            }
            Signalbox box = Model.FirstOrDefault(b => b.Id == (dataGridView.SelectedCells[0].OwningRow.Cells[_idColIdx].Value as string));
            if (box == null)
            {
                return;
            }
            using (SignalboxEditForm form = new SignalboxEditForm { Model = box.Copy() })
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                form.Model.CopyTo(box);
            }
        }

        private void ChangeSignalboxNameHandler(object sender, SignalboxEventArgs e)
        {
            if (e.Signalbox != null && _rowMap.ContainsKey(e.Signalbox.Id))
            {
                _rowMap[e.Signalbox.Id].Cells[_nameColIdx].Value = e.Signalbox.EditorDisplayName;
            }
        }

        private void ChangeSignalboxCodeHandler(object sender, SignalboxEventArgs e)
        {
            if (e.Signalbox != null && _rowMap.ContainsKey(e.Signalbox.Id))
            {
                _rowMap[e.Signalbox.Id].Cells[_codeColIdx].Value = e.Signalbox.Code;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 0)
            {
                return;
            }
            Signalbox box = Model.FirstOrDefault(b => b.Id == (dataGridView.SelectedCells[0].OwningRow.Cells[_idColIdx].Value as string));
            if (box == null)
            {
                return;
            }
            Model.Remove(box);
        }

        private void DataGridView_SelectionChanged(object sender, EventArgs e)
        {
            bool mainButtonsEnabled = dataGridView.SelectedCells.Count > 0;

            btnEdit.Enabled = mainButtonsEnabled;
            btnDelete.Enabled = mainButtonsEnabled;
            btnUp.Enabled = mainButtonsEnabled && dataGridView.SelectedCells[0].RowIndex > 0;
            btnDown.Enabled = mainButtonsEnabled && dataGridView.SelectedCells[0].RowIndex < dataGridView.RowCount - 1;
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            MoveUpDown(-1);
        }
        private void BtnDown_Click(object sender, EventArgs e)
        {
            MoveUpDown(1);
        }

        private void MoveUpDown(int step)
        { 
            if (dataGridView.SelectedCells.Count == 0)
            {
                return;
            }
            Signalbox box = Model.FirstOrDefault(b => b.Id == (dataGridView.SelectedCells[0].OwningRow.Cells[_idColIdx].Value as string));
            int idx = Model.IndexOf(box);
            if (idx < 0 || idx + step >= Model.Count)
            {
                return;
            }
            Signalbox otherBox = Model[idx + step];
            
            // This is so that neither box ever has to be in the _rowMap at the same time.
            Model[idx + step] = null;

            Model[idx] = otherBox;
            Model[idx + step] = box;
        }
    }
}
