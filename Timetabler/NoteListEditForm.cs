using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Timetabler.CoreData.Helpers;
using Timetabler.Data;

namespace Timetabler
{
    /// <summary>
    /// A form for editing a group of timetable notes.
    /// </summary>
    public partial class NoteListEditForm : Form
    {
        private Dictionary<string, Note> _model = new Dictionary<string, Note>();

        /// <summary>
        /// The data to be edited in this form.
        /// </summary>
        public Dictionary<string, Note> Model
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
            foreach (Note note in _model.Values.OrderBy(n => n.Symbol))
            {
                dgvNotes.Rows.Add(note.Id, note.Symbol, note.Definition);
            }
            dgvNotes.AutoResizeColumns();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var nef = new NoteEditForm { Model = new Note { Id = GeneralHelper.GetNewId(_model.Values) } };
            if (nef.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            _model.Add(nef.Model.Id, nef.Model);
            UpdateViewFromModel();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvNotes.SelectedCells.Count == 0)
            {
                return;
            }
            string id = dgvNotes[0, dgvNotes.SelectedCells[0].RowIndex].Value as string;
            if (!_model.ContainsKey(id))
            {
                return;
            }
            var nef = new NoteEditForm { Model = _model[id].Copy() };
            if (nef.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            nef.Model.CopyTo(_model[id]);
            UpdateViewFromModel();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvNotes.SelectedCells.Count == 0)
            {
                return;
            }
            string id = dgvNotes[0, dgvNotes.SelectedCells[0].RowIndex].Value as string;
            if (!_model.ContainsKey(id))
            {
                return;
            }
            _model.Remove(id);
            UpdateViewFromModel();
        }

        private void dgvNotes_SelectionChanged(object sender, EventArgs e)
        {
            bool flag = !(dgvNotes.SelectedCells.Count == 0);
            btnEdit.Enabled = flag;
            btnRemove.Enabled = flag;
        }
    }
}
