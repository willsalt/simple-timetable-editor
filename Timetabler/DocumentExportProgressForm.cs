using System.Windows.Forms;
using Timetabler.PdfExport;

namespace Timetabler
{
    public partial class DocumentExportProgressForm : Form
    {
        public double ProgessPct
        {
            get => pbExport.Value / 100d;
            set
            {
                pbExport.Value = (int)(value * 100);
            }
        }

        public string StatusMessage
        {
            get => lblProgress.Text;
            set
            {
                lblProgress.Text = value;
            }
        }

        public DocumentExportProgressForm()
        {
            InitializeComponent();
        }
    }
}
