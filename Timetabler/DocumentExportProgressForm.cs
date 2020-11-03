using System;
using System.Windows.Forms;

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
                SetExportValue((int)(value * 100));
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
                SetStatusMessage(value);
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public DocumentExportProgressForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Wraps the <see cref="Control.Show" /> method to make it safe to call from other threads.
        /// </summary>
        public void ShowSafe()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowSafe()));
                return;
            }
            Show();
        }

        /// <summary>
        /// Wraps the <see cref="Control.Hide" /> method to make it safe to call from other threads.
        /// </summary>
        public void HideSafe()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => HideSafe()));
                return;
            }
            Hide();
        }

        private void SetExportValue(int val)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetExportValue(val)));
                return;
            }
            pbExport.Value = val;
            Application.DoEvents();
        }

        private void SetStatusMessage(string status)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetStatusMessage(status)));
                return;
            }
            lblProgress.Text = status;
            Application.DoEvents();
        }
    }
}
