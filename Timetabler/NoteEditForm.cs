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

        private void TbSymbol_Validated(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.Symbol = tbSymbol.Text;
        }

        private void TbDefinition_Validated(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.Definition = tbDefinition.Text;
        }

        private void CkAppliesToTrains_CheckedChanged(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.AppliesToTrains = ckAppliesToTrains.Checked;
        }

        private void CkAppliesToTimings_CheckedChanged(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.AppliesToTimings = ckAppliesToTimings.Checked;
        }

        private void CkPageFootnote_CheckedChanged(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.DefinedOnPages = ckPageFootnote.Checked;
        }

        private void CkInGlossary_CheckedChanged(object sender, EventArgs e)
        {
            if (Model == null)
            {
                return;
            }
            Model.DefinedInGlossary = ckInGlossary.Checked;
        }
    }
}
