using System;
using System.Globalization;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;
using Timetabler.Data.Display;

namespace Timetabler.Data
{
    /// <summary>
    /// Defines a tmetable footnote or other marking.
    /// </summary>
    public class Note : IUniqueItem, IWatchableItem, ICopyableItem<Note>
    {
        /// <summary>
        /// The unique ID of this note item.  In theory this property should be immutable, so is not watchable.
        /// </summary>
        public string Id { get; set; }

        private string _symbol;

        /// <summary>
        /// The symbol used to represent this note where it is referred to (eg. a single letter).
        /// </summary>
        public string Symbol
        {
            get
            {
                return _symbol;
            }
            set
            {
                if (_symbol != value)
                {
                    _symbol = value;
                    OnModified(this, nameof(Symbol));
                }
            }
        }

        private string _definition;

        /// <summary>
        /// The explanation of this note elsewhere.
        /// </summary>
        public string Definition
        {
            get
            {
                return _definition;
            }
            set
            {
                if (_definition != value)
                {
                    _definition = value;
                    OnModified(this, nameof(Definition));
                }
            }
        }

        private bool _appliesToTrains;

        /// <summary>
        /// This note can appear in the header of a train.
        /// </summary>
        public bool AppliesToTrains
        {
            get
            {
                return _appliesToTrains;
            }
            set
            {
                if (_appliesToTrains != value)
                {
                    _appliesToTrains = value;
                    OnModified(this, nameof(AppliesToTrains));
                }
            }
        }

        private bool _appliesToTimings;

        /// <summary>
        /// This note can appear attached to an individual timing.
        /// </summary>
        public bool AppliesToTimings
        {
            get
            {
                return _appliesToTimings;
            }
            set
            {
                if (_appliesToTimings != value)
                {
                    _appliesToTimings = value;
                    OnModified(this, nameof(AppliesToTimings));
                }
            }
        }

        private bool _definedOnPages;

        /// <summary>
        /// The definition of this note appears on the bottom of pages where it is used.
        /// </summary>
        public bool DefinedOnPages
        {
            get
            {
                return _definedOnPages;
            }
            set
            {
                if (_definedOnPages != value)
                {
                    _definedOnPages = value;
                    OnModified(this, nameof(DefinedOnPages));
                }
            }
        }

        private bool _definedInGlossary;

        /// <summary>
        /// The definition of this note appears on a separate glossary page.
        /// </summary>
        public bool DefinedInGlossary
        {
            get
            {
                return _definedInGlossary;
            }
            set
            {
                if (_definedInGlossary != value)
                {
                    _definedInGlossary = value;
                    OnModified(this, nameof(DefinedInGlossary));
                }
            }
        }

        /// <summary>
        /// Event raised when this object is modified.
        /// </summary>
        public event ModifiedEventHandler Modified;

        /// <summary>
        /// Raises the <see cref="Modified" /> event.
        /// </summary>
        /// <param name="sender">The object which has modified the instance.</param>
        /// <param name="field">The name of the modified property, if only one property has been modified.</param>
        protected void OnModified(object sender, string field)
        {
            Modified?.Invoke(sender, new ModifiedEventArgs(this, field));
        }

        /// <summary>
        /// Returns a shallow copy of this instance.
        /// </summary>
        /// <returns>A <see cref="Note"/> instance with properties equal to this one.</returns>
        public Note Copy()
        {
            return new Note
            {
                Id = Id,
                Symbol = Symbol,
                Definition = Definition,
                AppliesToTimings = AppliesToTimings,
                AppliesToTrains = AppliesToTrains,
                DefinedInGlossary = DefinedInGlossary,
                DefinedOnPages = DefinedOnPages
            };
        }

        /// <summary>
        /// Overwrite another instance with the values of the properties of this instance.
        /// </summary>
        /// <param name="target">The instance to overwrite.</param>
        public void CopyTo(Note target)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }
            target.Id = Id;
            target.Symbol = Symbol;
            target.Definition = Definition;
            target.AppliesToTimings = AppliesToTimings;
            target.AppliesToTrains = AppliesToTrains;
            target.DefinedInGlossary = DefinedInGlossary;
            target.DefinedOnPages = DefinedOnPages;
        }

        /// <summary>
        /// Return a string representation of this object, consisting of its symbol and definition.
        /// </summary>
        /// <returns>A string consisting of the <see cref="Symbol"/> and <see cref="Definition"/> properties separated by a colon.</returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "{0}: {1}", Symbol, Definition);
        }

        /// <summary>
        /// Convert this <see cref="Note" /> to a <see cref="FootnoteDisplayModel" />.
        /// </summary>
        /// <returns>A <see cref="FootnoteDisplayModel" /> instance which can be used to display this note to a user.</returns>
        public FootnoteDisplayModel ToFootnoteDisplayModel()
        {
            FootnoteDisplayModel fdm = new FootnoteDisplayModel { NoteId = Id, Definition = Definition, Symbol = Symbol, DisplayOnPage = DefinedOnPages };
            Modified += fdm.ParentModified;
            return fdm;
        }
    }
}
