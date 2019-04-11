using NLog;
using System.Windows.Forms;
using Timetabler.XmlData;

namespace Timetabler
{
    /// <summary>
    /// Form to display an About dialog.
    /// </summary>
    public partial class AboutBox : Form
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AboutBox()
        {
            InitializeComponent();
            lblTimetablerVersion.Text = GetType().Assembly.GetName().Version.ToString();
            lblFileFormatVersion.Text = Versions.CurrentTimetableDocument.ToString();
        }

        private void btnOk_Click(object sender, System.EventArgs e)
        {
            Log.Trace("OK clicked.");
        }
    }
}
