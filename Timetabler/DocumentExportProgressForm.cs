using System.Windows.Forms;
using Timetabler.PdfExport;

namespace Timetabler
{
    /// <summary>
    /// A form to display the progress of an export.
    /// </summary>
    public partial class DocumentExportProgressForm : Form
    {
        /// <summary>
        /// The progress of the current export, as a value between 0 (not started) and 1 (complete).
        /// </summary>
        public double ProgessPct
        {
            get => pbExport.Value / 100d;
            set
            {
                pbExport.Value = (int)(value * 100);
            }
        }

        /// <summary>
        /// The latest export status message that is being displayed.
        /// </summary>
        public string StatusMessage
        {
            get => lblProgress.Text;
            set
            {
                lblProgress.Text = value;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DocumentExportProgressForm()
        {
            InitializeComponent();
        }
    }
}
