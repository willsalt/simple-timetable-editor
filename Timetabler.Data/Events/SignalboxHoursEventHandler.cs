namespace Timetabler.Data.Events
{
    /// <summary>
    /// Delegate type for event handlers relating to <see cref="SignalboxHours" /> objects.
    /// </summary>
    /// <param name="sender">The object which has raised an event.</param>
    /// <param name="e">The parameters to the event.</param>
    public delegate void SignalboxHoursEventHandler(object sender, SignalboxHoursEventArgs e);
}
