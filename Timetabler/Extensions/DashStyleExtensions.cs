namespace Timetabler.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DashStyleExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public static System.Drawing.Drawing2D.DashStyle ToSystemDashStyle(this Timetabler.CoreData.DashStyle style)
        {
            return (System.Drawing.Drawing2D.DashStyle)style;
        }
    }
}
