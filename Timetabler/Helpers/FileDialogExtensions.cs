using System.IO;
using System.Windows.Forms;

namespace Timetabler.Helpers
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
            if (!string.IsNullOrWhiteSpace(fd.FileName))
            {
                string folder = Path.GetDirectoryName(fd.FileName);
                if (Directory.Exists(folder))
                {
                    fd.InitialDirectory = folder;
                }
                else
                {
                    fd.FileName = string.Empty;
                }
            }
        }
    }
}
