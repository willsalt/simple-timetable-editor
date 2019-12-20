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
        /// Set the <see cref="FileDialog.InitialDirectory" /> property of a <see cref="FileDialog" /> to match its current <see cref="FileDialog.FileName" />.  If that property points to a
        /// non-existant directory, clear the FileName property.
        /// </summary>
        /// <param name="fd">The <see cref="FileDialog"/> to set the properties of.</param>
        public static void SetInitialDirectory(this FileDialog fd)
        {
            if (fd is null)
            {
                throw new ArgumentNullException(nameof(fd));
            }
            if (!string.IsNullOrWhiteSpace(fd.FileName))
            {
                string folder = Path.GetDirectoryName(fd.FileName);
                if (Directory.Exists(folder))
                {
                    fd.InitialDirectory = folder;
                    fd.FileName = Path.GetFileName(fd.FileName);
                }
                else
                {
                    fd.FileName = string.Empty;
                }
            }
        }

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
