using System.IO;

namespace Timetabler.Data.Interfaces
{
    /// <summary>
    /// The interface for timetable exporters.
    /// </summary>
    public interface IExporter
    {
        /// <summary>
        /// Export a timetable to a file with the given path.
        /// </summary>
        /// <param name="document">The timetable to be exported.</param>
        /// <param name="outputStream">The stream to write the timetable to.</param>
        void Export(TimetableDocument document, Stream outputStream);
    }
}
