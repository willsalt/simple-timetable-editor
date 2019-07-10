namespace Timetabler.Data.Events
{
    /// <summary>
    /// Event handler delegate type for <see cref="Train"/>-related events.
    /// </summary>
    /// <param name="sender">The object which raised this event.</param>
    /// <param name="e">The arguments to this event.</param>
    public delegate void TrainEventHandler(object sender, TrainEventArgs e);
}
