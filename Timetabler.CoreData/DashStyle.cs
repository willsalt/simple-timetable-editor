namespace Timetabler.CoreData
{
    /// <summary>
    /// An enum type to represent ways in which lines can be drawn, similar to <c>System.Drawing.Drawing2D.DashStyle</c>.
    /// </summary>
    public enum DashStyle
    {
        /// <summary>
        /// Solid line.
        /// </summary>
        Solid,

        /// <summary>
        /// Dashed line.
        /// </summary>
        Dash,

        /// <summary>
        /// Dotted line.
        /// </summary>
        Dot,

        /// <summary>
        /// Dash-dot line.
        /// </summary>
        DashDot,

        /// <summary>
        /// Dash-dot-dot line.
        /// </summary>
        DashDotDot
    }
}
