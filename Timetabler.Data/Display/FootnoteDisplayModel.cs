using System;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.Data.Display
{
    /// <summary>
    /// Represents a footnote definition as displayed to the reader.
    /// </summary>
    public class FootnoteDisplayModel : ICopyableItem<FootnoteDisplayModel>
    {
        /// <summary>
        /// The unique ID of the parent <see cref="Note" /> object.  If two <see cref="FootnoteDisplayModel" /> objects have the same ID we assume they refer to the same <see cref="Note" />
        /// and that therefore their other properties will be the same.
        /// </summary>
        public string NoteId { get; set; }

        /// <summary>
        /// The symbol that represents this footnote.
        /// </summary>
        public string Symbol { get; set; }

        /// <summary>
        /// The definition of this footnote.
        /// </summary>
        public string Definition { get; set; }

        /// <summary>
        /// Create a copy of this footnote with the same properties.  As the properties are all strings, there is no deep/shallow distinction to worry about.
        /// </summary>
        /// <returns>A <see cref="FootnoteDisplayModel" /> object which is a copy of this one.</returns>
        public FootnoteDisplayModel Copy()
        {
            return new FootnoteDisplayModel { NoteId = NoteId, Symbol = Symbol, Definition = Definition };
        }

        /// <summary>
        /// Copy the contents of this <see cref="FootnoteDisplayModel" /> into another.
        /// </summary>
        /// <param name="target">A <see cref="FootnoteDisplayModel" /> instance which will have its properties overwritten.</param>
        /// <exception cref="ArgumentNullException">Thrown if the target parameter is null.</exception>
        public void CopyTo(FootnoteDisplayModel target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            target.NoteId = NoteId;
            target.Symbol = Symbol;
            target.Definition = Definition;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="x">A <see cref="FootnoteDisplayModel" /> instance.</param>
        /// <param name="y">A <see cref="FootnoteDisplayModel" /> instance.</param>
        /// <returns>Returns true if the parameters are both null or have the same <see cref="NoteId"/> property; false otherwise.</returns>
        public static bool operator ==(FootnoteDisplayModel x, FootnoteDisplayModel y)
        {
            if (ReferenceEquals(x, null))
            {
                return ReferenceEquals(y, null);
            }
            if (ReferenceEquals(y, null))
            {
                return false;
            }

            return x.NoteId == y.NoteId;
        }

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="x">A <see cref="FootnoteDisplayModel" /> instance to compare to this one.</param>
        /// <returns>Returns true if the parameter is not null and has the same <see cref="NoteId" /> property as this; false otherwise.</returns>
        public bool Equals(FootnoteDisplayModel x)
        {
            if (ReferenceEquals(x, null))
            {
                return false;
            }

            return x.NoteId == NoteId;
        }

        /// <summary>
        /// Equality-testing method.
        /// </summary>
        /// <param name="obj">An <see cref="object" /> to compare to this one.</param>
        /// <returns>
        /// Returns true if the parameter is not null, is a <see cref="FootnoteDisplayModel" /> instance, and has the same <see cref="NoteId" /> property as this one; 
        /// false otherwise.
        /// </returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as FootnoteDisplayModel);
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="x">A <see cref="FootnoteDisplayModel" /> instance.</param>
        /// <param name="y">A <see cref="FootnoteDisplayModel" /> instance.</param>
        /// <returns>Returns false if the parameters are both null or have the same <see cref="NoteId"/> property; true otherwise.</returns>
        public static bool operator !=(FootnoteDisplayModel x, FootnoteDisplayModel y)
        {
            if (x.Equals(null))
            {
                return !y.Equals(null);
            }
            if (y.Equals(null))
            {
                return true;
            }

            return x.NoteId != y.NoteId;
        }

        /// <summary>
        /// Override of <see cref="object.GetHashCode" />.
        /// </summary>
        /// <returns>Returns the result of calling <see cref="object.GetHashCode" /> on the <see cref="NoteId" /> property.</returns>
        public override int GetHashCode()
        {
            return NoteId.GetHashCode();
        }

        internal void ParentModified(object sender, ModifiedEventArgs e)
        {
            Note modifiedItem = e.ModifiedItem as Note;
            if (e.ModifiedField == nameof(modifiedItem.Symbol))
            {
                Symbol = modifiedItem.Symbol;
            }
            else if (e.ModifiedField == nameof(modifiedItem.Definition))
            {
                Definition = modifiedItem.Definition;
            }
        }
    }
}
