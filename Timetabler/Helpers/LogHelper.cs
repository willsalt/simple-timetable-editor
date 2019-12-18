using NLog;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace Timetabler.Helpers
{
    /// <summary>
    /// Helper methods for displaying and logging messages at the same time.
    /// </summary>
    public static class LogHelper
    {
        /// <summary>
        /// Display a message in a dialog box and then log it.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use to log the message.</param>
        /// <param name="level">The level to log the message at.</param>
        /// <param name="ex"><see cref="Exception" /> to log.</param>
        /// <param name="parent">Parent window of the message box.</param>
        /// <param name="showBox">Whether to display the message box.</param>
        /// <param name="format">Format string for the message.</param>
        /// <param name="arguments">Arguments to the message format string.</param>
        public static void LogWithMessageBox(ILogger logger, LogLevel level, Exception ex, IWin32Window parent, bool showBox, string format, params object[] arguments)
        {
            string msg = string.Format(CultureInfo.CurrentCulture, format, arguments);
            if (showBox)
            {
                MessageBox.Show(parent, msg);
            }
            if (ex == null)
            {
                logger?.Log(level, msg);
            }
            else
            {
                logger?.Log(level, ex, msg);
            }
        }

        /// <summary>
        /// Display a message in a dialog box and log it.
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use to log the message.</param>
        /// <param name="level">The level to log the message at.</param>
        /// <param name="ex"><see cref="Exception" /> to log.</param>
        /// <param name="parent">Parent window of the message box.</param>
        /// <param name="format">Format string for the message.</param>
        /// <param name="arguments">Arguments to the message format string.</param>
        public static void LogWithMessageBox(ILogger logger, LogLevel level, Exception ex, IWin32Window parent, string format, params object[] arguments)
        {
            LogWithMessageBox(logger, level, ex, parent, true, format, arguments);
        }
    }
}
