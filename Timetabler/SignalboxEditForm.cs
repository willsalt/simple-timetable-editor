using System;
using System.Windows.Forms;
using Timetabler.Data;

namespace Timetabler
{
    /// <summary>
    /// Form for editing signalbox data.
    /// </summary>
    public partial class SignalboxEditForm : Form
    {
        private Signalbox _model;

        /// <summary>
        /// The data to be edited by this form.
        /// </summary>
        public Signalbox Model
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
        public SignalboxEditForm()
        {
            InitializeComponent();
        }

        private void UpdateViewFromModel()
        {
            if (_model == null)
            {
                return;
            }
            tbCode.Text = _model.Code;
            tbEditorDisplayName.Text = _model.EditorDisplayName;
            tbExportDisplayName.Text = _model.ExportDisplayName;
        }

        private void tbCode_TextChanged(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.Code = tbCode.Text;
            }
        }

        private void tbEditorDisplayName_TextChanged(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.EditorDisplayName = tbEditorDisplayName.Text;
            }
        }

        private void tbExportDisplayName_TextChanged(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.ExportDisplayName = tbExportDisplayName.Text;
            }
        }
    }
}
