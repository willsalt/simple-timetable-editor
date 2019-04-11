using System;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.Data
{
    /// <summary>
    /// Details of what a train is diagrammed to do after the end of its journey.
    /// </summary>
    public class ToWork : ICopyableItem<ToWork>
    {
        /// <summary>
        /// The departure time of its next service.
        /// </summary>
        public TimeOfDay AtTime { get; set; }

        /// <summary>
        /// Free text, ie "STOP".
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Make a copy of this object.
        /// </summary>
        /// <returns>A copy of this object.</returns>
        public ToWork Copy()
        {
            return new ToWork { AtTime = AtTime?.Copy(), Text = Text };
        }

        /// <summary>
        /// Overwrite another object's contents with a copy of the contents of this object.
        /// </summary>
        /// <param name="target">The object to be overwritten.</param>
        public void CopyTo(ToWork target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            target.AtTime = AtTime?.Copy();
            target.Text = Text;
        }
    }
}
