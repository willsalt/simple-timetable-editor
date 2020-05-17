using System;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;
using Timetabler.Data.Events;

namespace Timetabler.Data
{
    /// <summary>
    /// A class representing a signalbox.
    /// </summary>
    public class Signalbox : IUniqueItem, IWatchableItem, ICopyableItem<Signalbox>
    {
        /// <summary>
        /// Event raised when the <see cref="Code"/> property changes.
        /// </summary>
        public event SignalboxEventHandler CodeChanged;

        /// <summary>
        /// Event raised when the <see cref="EditorDisplayName"/> property changes.
        /// </summary>
        public event SignalboxEventHandler EditorDisplayNameChanged;

        /// <summary>
        /// Event raised when the <see cref="ExportDisplayName"/> property changes.
        /// </summary>
        public event SignalboxEventHandler ExportDisplayNameChanged;

        /// <summary>
        /// Event raised when this object is modified.  Not yet implemented.
        /// </summary>
        public event ModifiedEventHandler Modified;

        /// <summary>
        /// Raises the <see cref="Modified" /> event.
        /// </summary>
        /// <param name="sender">The object which has modified the instance.</param>
        /// <param name="field">The name of the modified property, if only one property has been modified.</param>
        protected void OnModified(object sender, string field)
        {
            Modified?.Invoke(sender, new ModifiedEventArgs { ModifiedItem = this, ModifiedField = field });
        }

        /// <summary>
        /// The unique ID of this signalbox.
        /// </summary>
        public string Id { get; set; }

        private string _code;

        /// <summary>
        /// The displayable code of this signalbox (eg AY, BH)
        /// </summary>
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                if (_code != value)
                {
                    _code = value;
                    OnCodeChanged();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="CodeChanged"/> event.
        /// </summary>
        protected void OnCodeChanged()
        {
            CodeChanged?.Invoke(this, new SignalboxEventArgs { Signalbox = this });
        }

        private string _editorDisplayName;

        /// <summary>
        /// The name to use to display this signalbox in the application.
        /// </summary>
        public string EditorDisplayName
        {
            get
            {
                return _editorDisplayName;
            }
            set
            {
                if (_editorDisplayName != value)
                {
                    _editorDisplayName = value;
                    OnEditorDisplayNameChanged();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="EditorDisplayNameChanged"/> event.
        /// </summary>
        protected void OnEditorDisplayNameChanged()
        {
            EditorDisplayNameChanged?.Invoke(this, new SignalboxEventArgs { Signalbox = this });
        }

        private string _exportDisplayName;

        /// <summary>
        /// The name to use when displaying the full name of this signalbox in exports.
        /// </summary>
        public string ExportDisplayName
        {
            get
            {
                return _exportDisplayName;
            }
            set
            {
                if (_exportDisplayName != value)
                {
                    _exportDisplayName = value;
                    OnExportDisplayNameChanged();
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="ExportDisplayNameChanged"/> event.
        /// </summary>
        protected void OnExportDisplayNameChanged()
        {
            ExportDisplayNameChanged?.Invoke(this, new SignalboxEventArgs { Signalbox = this });
        }

        /// <summary>
        /// Create a copy of this instance.
        /// </summary>
        /// <returns>A <see cref="Signalbox"/> instance which is a copy of this object.</returns>
        public Signalbox Copy()
        {
            return new Signalbox { Id = Id, Code = Code, EditorDisplayName = EditorDisplayName, ExportDisplayName = ExportDisplayName };
        }

        /// <summary>
        /// Copy the values of this object's properties into another <see cref="Signalbox"/> instance.
        /// </summary>
        /// <param name="box">The <see cref="Signalbox"/> instance to overwrite.</param>
        /// <exception cref="ArgumentNullException">Thrown if the box parameter is null.</exception>
        public void CopyTo(Signalbox box)
        {
            if (box is null)
            {
                throw new ArgumentNullException(nameof(box));
            }

            box.Id = Id;
            box.Code = Code;
            box.EditorDisplayName = EditorDisplayName;
            box.ExportDisplayName = ExportDisplayName;
        }
    }
}
