using System;
using System.Windows.Forms;
using Timetabler.Data;

namespace Timetabler
{
    /// <summary>
    /// A form for editing <see cref="Note"/> instances.
    /// </summary>
    public partial class NoteEditForm : Form
    {
        private Note _model;

        /// <summary>
        /// The data to be edited.
        /// </summary>
        public Note Model
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
        public NoteEditForm()
        {
            InitializeComponent();
        }

        private void UpdateViewFromModel()
        {
            if (Model == null)
            {
                return;
            }
            tbSymbol.Text = Model.Symbol;
            tbDefinition.Text = Model.Definition;
            ckAppliesToTimings.Checked = Model.AppliesToTimings;
            ckAppliesToTrains.Checked = Model.AppliesToTrains;
            ckPageFootnote.Checked = Model.DefinedOnPages;
            ckInGlossary.Checked = Model.DefinedInGlossary;
        }

        private void tbSymbol_Validated(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.Symbol = tbSymbol.Text;
        }

        private void tbDefinition_Validated(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.Definition = tbDefinition.Text;
        }

        private void ckAppliesToTrains_CheckedChanged(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.AppliesToTrains = ckAppliesToTrains.Checked;
        }

        private void ckAppliesToTimings_CheckedChanged(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.AppliesToTimings = ckAppliesToTimings.Checked;
        }

        private void ckPageFootnote_CheckedChanged(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.DefinedOnPages = ckPageFootnote.Checked;
        }

        private void ckInGlossary_CheckedChanged(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.DefinedInGlossary = ckInGlossary.Checked;
        }
    }
}
