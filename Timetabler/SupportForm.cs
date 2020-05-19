using System.Windows.Forms;
using NLog;
using System.Linq;
using NLog.Targets;
using NLog.Layouts;
using System;

namespace Timetabler
{
    /// <summary>
    /// Form for live-editing of the NLog configuration (for simple configurations, at least!)
    /// </summary>
    public partial class SupportForm : Form
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// A form for editing the logging configuration (and possibly other things at some point)
        /// </summary>
        public SupportForm()
        {
            InitializeComponent();
            PopulateView();
        }

        private void PopulateView()
        {
            FileTarget fileTarget = LogManager.Configuration.AllTargets.Where(t => t as FileTarget != null).FirstOrDefault() as FileTarget;
            tbLogFilePath.Text = (fileTarget.FileName as SimpleLayout)?.Text;

            cbLogLevel.Items.Clear();
            cbLogLevel.Items.AddRange(LogLevel.AllLoggingLevels.ToArray());
            var levels = LogManager.Configuration.LoggingRules.Where(r => r.Targets.Contains(fileTarget)).FirstOrDefault()?.Levels;
            if (levels != null)
            {
                foreach (var item in cbLogLevel.Items)
                {
                    LogLevel level = item as LogLevel;
                    if (levels.Contains(level))
                    {
                        cbLogLevel.SelectedItem = level;
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Display this form modally.
        /// </summary>
        /// <returns>A <see cref="DialogResult"/> value indicating the user's action ("OK" or "Cancel").</returns>
        public new DialogResult ShowDialog()
        {
            DialogResult result = base.ShowDialog();

            if (result == DialogResult.OK)
            {
                FileTarget fileTarget = LogManager.Configuration.AllTargets.Where(t => t as FileTarget != null).FirstOrDefault() as FileTarget;
                fileTarget.FileName = new SimpleLayout(tbLogFilePath.Text);
                var rule = LogManager.Configuration.LoggingRules.Where(r => r.Targets.Contains(fileTarget)).FirstOrDefault();
                if (rule != null)
                {
                    for (int i = 0; i < cbLogLevel.Items.Count; ++i)
                    {
                        if (i < cbLogLevel.SelectedIndex)
                        {
                            rule.DisableLoggingForLevel(cbLogLevel.Items[i] as LogLevel);
                        }
                        else
                        {
                            rule.EnableLoggingForLevel(cbLogLevel.Items[i] as LogLevel);
                        }
                    }
                    LogManager.ReconfigExistingLoggers();
                    Log.Log(cbLogLevel.SelectedItem as LogLevel, "Reconfigured logging level.");
                }
            }

            return result;
        }

        private void BtnGC_Click(object sender, EventArgs e)
        {
            long current = GC.GetTotalMemory(false);
            GC.Collect();
            long after = GC.GetTotalMemory(true);
            MessageBox.Show($"Memory usage changed from {current} to {after}.");
        }
    }
}
