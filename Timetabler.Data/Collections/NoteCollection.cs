using System;
using System.Collections.Generic;
using System.Linq;
using Timetabler.CoreData.Interfaces;
using Timetabler.Data.Events;

namespace Timetabler.Data.Collections
{
    /// <summary>
    /// A collection type for <see cref="Note"/> objects.
    /// </summary>
    public class NoteCollection : BaseCollection<Note>, ICopyableItem<NoteCollection>
    {
        /// <summary>
        /// Event handler delegate type for collection change events.
        /// </summary>
        /// <param name="sender">The collection which has raised the event.</param>
        /// <param name="e">The item which has been added to or removed from the collection.</param>
        public delegate void NoteEventHandler(object sender, NoteEventArgs e);

        /// <summary>
        /// Event raised when a <see cref="Note"/> is added to the collection.
        /// </summary>
        public event NoteEventHandler NoteAdd;

        /// <summary>
        /// Event raised when a <see cref="Note"/> is removed from the collection.
        /// </summary>
        public event NoteEventHandler NoteRemove;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public NoteCollection()
        {

        }

        /// <summary>
        /// Constructor which sets initial contents of the collection.
        /// </summary>
        /// <param name="contents">The initial contents of the collection.</param>
        public NoteCollection(IEnumerable<Note> contents)
        {
            InnerCollection.AddRange(contents);
        }

        /// <summary>
        /// Raises the <see cref="NoteAdd"/> event.
        /// </summary>
        /// <param name="item">The <see cref="Note"/> which has triggered the event.</param>
        /// <param name="idx">The index at which the item has been added to the collection.</param>
        protected override void OnAdd(Note item, int? idx)
        {
            NoteAdd?.Invoke(this, new NoteEventArgs { Note = item });
        }

        /// <summary>
        /// Raises the <see cref="NoteRemove"/> event.
        /// </summary>
        /// <param name="item">The <see cref="Note"/> which has triggered the event.</param>
        /// <param name="idx">Former index of the <see cref="Note"/> which has been removed from the collection.</param>
        protected override void OnRemove(Note item, int idx)
        {
            NoteRemove?.Invoke(this, new NoteEventArgs { Note = item });
        }

        /// <summary>
        /// Placeholder method for raising the Modified event, when it is implemented in this class.
        /// </summary>
        /// <param name="item">The <see cref="Note"/> which has been modified.</param>
        protected override void OnContentsModified(Note item)
        {
            
        }

        /// <summary>
        /// Create a deep copy of this collection.
        /// </summary>
        /// <returns>A deep copy of this collection.</returns>
        public NoteCollection Copy()
        {
            return new NoteCollection(InnerCollection.Select(n => n.Copy()));
        }

        /// <summary>
        /// Copy the contents of this collection into another collection.
        /// </summary>
        /// <param name="target">The collection whose contents should be overwritten.</param>
        public void CopyTo(NoteCollection target)
        {
            if (target is null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            lock (InnerCollection)
            {
                lock (target)
                {
                    Dictionary<string, Note> thisContents = InnerCollection.ToDictionary(n => n.Id, n => n);
                    Dictionary<string, bool> tagged = new Dictionary<string, bool>();
                    for (int i = 0; i < target.Count; ++i)
                    {
                        if (!thisContents.ContainsKey(target[i].Id))
                        {
                            target.RemoveAt(i--);
                        }
                        else
                        {
                            thisContents[target[i].Id].CopyTo(target[i]);
                            tagged.Add(target[i].Id, true);
                        }
                    }
                    foreach (KeyValuePair<string, Note> item in thisContents)
                    {
                        if (!tagged.ContainsKey(item.Key))
                        {
                            target.Add(item.Value);
                        }
                    }
                    for (int i = 0; i < Count; ++i)
                    {
                        if (this[i].Id != target[i].Id)
                        {
                            int targetIdx = -1;
                            for (int j = i + 1; j < target.Count; ++j)
                            {
                                if (this[i].Id == target[j].Id)
                                {
                                    targetIdx = j;
                                    break;
                                }
                            }
                            Note tmp = target[targetIdx];
                            target.RemoveAt(targetIdx);
                            target.Insert(i, tmp);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Copy a dictionary of <see cref="Note" /> objects into this collection.
        /// </summary>
        /// <param name="notes">The source to copy from.</param>
        public void CopyFrom(Dictionary<string, Note> notes)
        {
            if (notes is null)
            {
                throw new ArgumentNullException(nameof(notes));
            }

            Dictionary<string, bool> found = new Dictionary<string, bool>();
            lock (InnerCollection)
            {
                lock (notes)
                {
                    for (int i = 0; i < Count; ++i)
                    {
                        if (!notes.ContainsKey(this[i].Id))
                        {
                            RemoveAt(i--);
                        }
                        else
                        {
                            notes[this[i].Id].CopyTo(this[i]);
                            found.Add(this[i].Id, true);
                        }
                    }
                    foreach (KeyValuePair<string, Note> n in notes)
                    {
                        if (!found.ContainsKey(n.Key))
                        {
                            Add(n.Value);
                        }
                    }
                }
            }
        }
    }
}
