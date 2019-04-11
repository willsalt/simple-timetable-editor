using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Timetabler.CoreData.Helpers;
using Timetabler.Data;
using Timetabler.Data.Collections;

namespace Timetabler
{
    /// <summary>
    /// A form for editing a list of locations.
    /// </summary>
    public partial class LocationListEditForm : Form
    {
        /// <summary>
        /// The data to be edited.
        /// </summary>
        public LocationCollection Model { get; set; }

        private static Random _random = new Random();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocationListEditForm() : this(null)
        {

        }

        /// <summary>
        /// Constructor including data model parameter.
        /// </summary>
        /// <param name="model">The list of locations to be edited.</param>
        public LocationListEditForm(IEnumerable<Location> model)
        {
            if (model == null)
            {
                Model = new LocationCollection();
            }
            else
            {
                var contents = model.ToList();
                contents.Sort(new LocationComparer());
                Model = new LocationCollection(contents);
            }
            InitializeComponent();
        }

        private void UpdateView()
        {
            dataGridView.SuspendLayout();
            dataGridView.Rows.Clear();

            if (Model != null)
            {
                foreach (var location in Model)
                {
                    dataGridView.Rows.Add(location.Mileage.ToString(), location.EditorDisplayName);
                }
            }

            dataGridView.ResumeLayout();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Location newLoc = new Location { Id = GeneralHelper.GetNewId(Model) };
            LocationEditForm form = new LocationEditForm { Model = newLoc };

            if (form.ShowDialog() == DialogResult.OK)
            {
                Model.Add(form.Model);
                Model.Sort(new LocationComparer());
                UpdateView();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count <= 0)
            {
                return;
            }
            EditModelAt(dataGridView.SelectedRows[0].Index);
        }

        private void EditModelAt(int idx)
        {
            if (idx > Model.Count ||idx < 0)
            {
                return;
            }

            Location model = Model[idx].Clone() as Location;
            LocationEditForm form = new LocationEditForm { Model = model };
            if (form.ShowDialog() == DialogResult.OK)
            {
                Model[idx] = form.Model;
                Model.Sort(new LocationComparer());
                UpdateView();
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count <= 0)
            {
                return;
            }
            List<int> indexes = new List<int>();
            for (int i = 0; i < dataGridView.SelectedRows.Count; ++i)
            {
                indexes.Add(dataGridView.SelectedRows[i].Index);
            }
            foreach (var i in indexes.OrderByDescending(j => j))
            {
                Model.RemoveAt(i);
            }

            UpdateView();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                btnEdit.Enabled = true;
                btnDel.Enabled = true;
            }
            else
            {
                btnEdit.Enabled = false;
                btnDel.Enabled = false;
            }
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditModelAt(e.RowIndex);
        }

        private void LocationListEditForm_Shown(object sender, EventArgs e)
        {
            UpdateView();
        }
    }
}
