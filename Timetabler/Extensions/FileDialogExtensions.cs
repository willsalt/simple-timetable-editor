using System;
using System.IO;
using System.Windows.Forms;

namespace Timetabler.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="FileDialog" /> class and its descendants. 
    /// </summary>
    public static class FileDialogExtensions
    {
        /// <summary>
        /// Set the initial directory and filename properties of a file dialog to match a particular path.
        /// </summary>
        /// <param name="fd">The file dialog to set the properties of.</param>
        /// <param name="path">The path to set as the initial selection in the dialog.</param>
        public static void SetDirectoryAndFilename(this FileDialog fd, string path)
        {
            if (fd is null)
            {
                throw new ArgumentNullException(nameof(fd));
            }
            if (string.IsNullOrWhiteSpace(path))
            {
                return;
            }
            string folder = Path.GetDirectoryName(path);
            if (Directory.Exists(folder))
            {
                fd.InitialDirectory = folder;
            }
            string fn = Path.GetFileName(path);
            fd.FileName = fn;
        }
    }
}
