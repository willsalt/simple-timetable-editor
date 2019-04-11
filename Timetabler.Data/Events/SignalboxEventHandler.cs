namespace Timetabler.Data.Events
{
    /// <summary>
    /// Event handler delegate type for signalbox changed events.
    /// </summary>
    /// <param name="sender">The object raising the event.</param>
    /// <param name="e">The arguments associated with the event.</param>
    public delegate void SignalboxEventHandler(object sender, SignalboxEventArgs e);
}
