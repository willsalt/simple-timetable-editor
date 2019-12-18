using System;
using System.Globalization;
using Timetabler.CoreData;
using Timetabler.CoreData.Interfaces;
using Timetabler.Data.Display;

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

        /// <summary>
        /// Change a <see cref="GenericTimeModel" /> object so that its displayed text represents the properties of this object.
        /// </summary>
        /// <param name="model">The object to be updated.</param>
        /// <param name="formats">The format strings to use for displaying times, or null if not available.</param>
        public void UpdateModel(GenericTimeModel model, TimeDisplayFormattingStrings formats)
        {
            if (model == null)
            {
                return;
            }

            // Use the Text property if this has been set.
            if (!string.IsNullOrWhiteSpace(Text))
            {
                model.ActualTime = null;
                model.DisplayedText = Text;
            }
            // If the Text property has not been set, use the time.  Format the time using the supplied parameter if available.
            else if (AtTime != null)
            {
                model.ActualTime = AtTime.Copy();
                if (formats == null)
                {
                    model.DisplayedText = AtTime.ToString(); // This will be updated later with the correct formatting string.
                }
                else
                {
                    model.DisplayedText = AtTime.ToString(formats.TimeWithoutFootnotes, CultureInfo.CurrentCulture);
                }
            }
            else
            {
                model.ActualTime = null;
                model.DisplayedText = "";
            }
        }
    }
}
