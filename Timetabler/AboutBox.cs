using NLog;
using System.Globalization;
using System.Windows.Forms;
using Timetabler.DataLoader;

namespace Timetabler
{
    /// <summary>
    /// Form to display an About dialog.
    /// </summary>
    public partial class AboutBox : Form
    {
        private static readonly Logger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AboutBox()
        {
            InitializeComponent();
            lblTimetablerVersion.Text = GetType().Assembly.GetName().Version.ToString();
            lblFileFormatVersion.Text = Loader.LatestTimetableDocumentVersion.ToString(CultureInfo.CurrentCulture);
        }

        private void BtnOk_Click(object sender, System.EventArgs e)
        {
            Log.Trace("OK clicked.");
        }
    }
}
