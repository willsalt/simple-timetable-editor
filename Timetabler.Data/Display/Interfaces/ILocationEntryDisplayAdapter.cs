namespace Timetabler.Data.Display.Interfaces
{
    /// <summary>
    /// This is an adapter interface for wiring up <see cref="ILocationEntry"/> objects to the component(s) responsible for displaying it, without going for fully-blown event subscription.
    /// </summary>
    public interface ILocationEntryDisplayAdapter
    {
        /// <summary>
        /// <see cref="ILocationEntry"/> implementations are responsible for calling this method if their <see cref="ILocationEntry.DisplayedText"/> property has changed.
        /// </summary>
        /// <param name="displayedText">The new text to be displayed.</param>
        void DisplayedTextChanged(string displayedText);
    }
}
