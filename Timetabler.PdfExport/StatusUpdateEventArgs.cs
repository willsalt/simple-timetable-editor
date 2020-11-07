using System;

namespace Timetabler.PdfExport
{
    /// <summary>
    /// Class to encapsulate information about a <see cref="PdfExporter" /> status change event.
    /// </summary>
    public class StatusUpdateEventArgs : EventArgs
    {
        /// <summary>
        /// The progress of the current export (from 0, for "not started", to 1, for "complete").
        /// </summary>
        public double Progress { get; private set; }

        /// <summary>
        /// The latest user-readable status string for the current export.
        /// </summary>
        public string Status { get; private set; }

        /// <summary>
        /// Whether or not there is an export actively in progress.
        /// </summary>
        public bool InProgress { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="inProgress">Whether or not there is an export actively in progress.</param>
        /// <param name="progress">The progress of the current export.</param>
        /// <param name="status">The latest user-readable status message for the current export.</param>
        public StatusUpdateEventArgs(bool inProgress, double progress, string status)
        {
            InProgress = inProgress;
            Progress = progress;
            Status = status;
        }
    }
}
