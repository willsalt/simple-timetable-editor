using System;
using System.Windows.Forms;

namespace Timetabler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (args.Length > 0 && !string.IsNullOrWhiteSpace(args[0]))
            {
                using (MainForm f = new MainForm(args[0]))
                {
                    Application.Run(f);
                }
            }
            else
            {
                using (MainForm f = new MainForm())
                {
                    Application.Run(f);
                }
            }
        }
    }
}
