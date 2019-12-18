using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Timetabler.CoreData.Helpers;
using Timetabler.Data;
using Timetabler.Models;

namespace Timetabler
{
    /// <summary>
    /// A form for editing a group of timetable notes.
    /// </summary>
    public partial class NoteListEditForm : Form
    {
        private NoteListEditFormModel _model = new NoteListEditFormModel(null);

        /// <summary>
        /// The data to be edited in this form.
        /// </summary>
        public NoteListEditFormModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                UpdateViewFromModel();
            }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NoteListEditForm()
        {
            InitializeComponent();
        }

        private void UpdateViewFromModel()
        {
            dgvNotes.Rows.Clear();
            foreach (Note note in _model.Data.Values.OrderBy(n => n.Symbol))
            {
                dgvNotes.Rows.Add(note.Id, note.Symbol, note.Definition);
            }
            dgvNotes.AutoResizeColumns();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (NoteEditForm nef = new NoteEditForm { Model = new Note { Id = GeneralHelper.GetNewId(_model.Data.Values) } })
            {
                if (nef.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                _model.Data.Add(nef.Model.Id, nef.Model);
            }
            UpdateViewFromModel();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNotes.SelectedCells.Count == 0)
            {
                return;
            }
            string id = dgvNotes[0, dgvNotes.SelectedCells[0].RowIndex].Value as string;
            ShowNoteEditForm(id);
        }

        private void DgvNotes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = dgvNotes[0, e.RowIndex].Value as string;           
            ShowNoteEditForm(id);
        }

        private void ShowNoteEditForm(string id)
        {
            if (!_model.Data.ContainsKey(id))
            {
                return;
            }
            using (NoteEditForm nef = new NoteEditForm { Model = _model.Data[id].Copy() })
            {
                if (nef.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                nef.Model.CopyTo(_model.Data[id]);
            }
            Model.ExistingNoteChanged = true;
            UpdateViewFromModel();
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvNotes.SelectedCells.Count == 0)
            {
                return;
            }
            string id = dgvNotes[0, dgvNotes.SelectedCells[0].RowIndex].Value as string;
            if (!_model.Data.ContainsKey(id))
            {
                return;
            }
            _model.Data.Remove(id);
            UpdateViewFromModel();
        }

        private void DgvNotes_SelectionChanged(object sender, EventArgs e)
        {
            bool flag = !(dgvNotes.SelectedCells.Count == 0);
            btnEdit.Enabled = flag;
            btnRemove.Enabled = flag;
        }        
    }
}
