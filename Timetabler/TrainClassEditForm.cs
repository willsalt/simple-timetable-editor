using System;
using System.Windows.Forms;
using Timetabler.Data;

namespace Timetabler
{
    /// <summary>
    /// A form for editing a train class.
    /// </summary>
    public partial class TrainClassEditForm : Form
    {
        private TrainClass _model;

        /// <summary>
        /// The data to be edited by this form.
        /// </summary>
        public TrainClass Model
        {
            get
            {
                return _model;
            }
            set
            {
                _model = value;
                UpdateViewToModel();
            }
        }

        private void UpdateViewToModel()
        {
            if (_model == null)
            {
                return;
            }

            tbDescription.Text = _model.Description;
            tbTableCode.Text = _model.TableCode;
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TrainClassEditForm()
        {
            InitializeComponent();
        }

        private void TbTableCode_Validated(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.TableCode = tbTableCode.Text;
            }
        }

        private void TbDescription_Validated(object sender, EventArgs e)
        {
            if (_model != null)
            {
                _model.Description = tbDescription.Text;
            }
        }
    }
}
