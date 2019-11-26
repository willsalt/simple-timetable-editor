using System;
using System.Linq;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;
using Timetabler.Data.Collections;
using Timetabler.Data.Events;

namespace Timetabler.Data
{
    /// <summary>
    /// A class which describes a set of <see cref="SignalboxHours" /> objects, one for each signalbox on the map.
    /// </summary>
    public class SignalboxHoursSet : IWatchableItem, IUniqueItem, ICopyableItem<SignalboxHoursSet>
    {
        private string _category;

        /// <summary>
        /// Unique ID of this set.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// The caption or category of this set of <see cref="SignalboxHours" />, for example the service pattern or timetable name.
        /// </summary>
        public string Category
        {
            get
            {
                return _category;
            }
            set
            {
                if (_category == null)
                {
                    _category = value;
                    if (_category != null)
                    {
                        OnModified();
                    }
                    return;
                }

                lock (_category)
                {
                    if (_category != value)
                    {
                        _category = value;
                        OnModified();
                    }
                }
            }
        }

        /// <summary>
        /// The collection of <see cref="SignalboxHours" /> objects, keyed by <see cref="Signalbox.Id" />
        /// </summary>
        public SignalboxHoursDictionary Hours { get; set; }

        /// <summary>
        /// Event raised when this object is modified.
        /// </summary>
        public event ModifiedEventHandler Modified;

        /// <summary>
        /// Event raised when an object is added to the Hours collection.
        /// </summary>
        public event SignalboxHoursEventHandler SignalboxHoursAdded;

        /// <summary>
        /// Event raised when an object is removed from the Hours collection.
        /// </summary>
        public event SignalboxHoursEventHandler SignalboxHoursRemoved;

        /// <summary>
        /// Event raised when a member of the Hours collection is modified.
        /// </summary>
        public event SignalboxHoursEventHandler SignalboxHoursModified;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SignalboxHoursSet()
        {
            Hours = new SignalboxHoursDictionary();
            Hours.SignalboxHoursAdd += HoursAdded;
            Hours.SignalboxHoursModified += HoursModified;
            Hours.SignalboxHoursRemove += HoursRemoved;
        }

        private void HoursAdded(object sender, SignalboxHoursEventArgs e)
        {
            if (e.SignalboxHours != null)
            {
                OnSignalboxHoursAdded(e.SignalboxHours);
            }
        }

        /// <summary>
        /// Raises the <see cref="SignalboxHoursAdded" /> event.
        /// </summary>
        /// <param name="signalboxHours">The object which has been added to the Hours collection.</param>
        protected virtual void OnSignalboxHoursAdded(SignalboxHours signalboxHours)
        {
            SignalboxHoursAdded?.Invoke(this, new SignalboxHoursEventArgs { SignalboxHours = signalboxHours });
        }

        private void HoursRemoved(object sender, SignalboxHoursEventArgs e)
        {
            if (e.SignalboxHours != null)
            {
                OnSignalboxHoursRemoved(e.SignalboxHours);
            }
        }

        /// <summary>
        /// Raises the <see cref="SignalboxHoursRemoved" /> event.
        /// </summary>
        /// <param name="signalboxHours">The object which has been removed from the Hours collection.</param>
        protected virtual void OnSignalboxHoursRemoved(SignalboxHours signalboxHours)
        {
            SignalboxHoursRemoved?.Invoke(this, new SignalboxHoursEventArgs { SignalboxHours = signalboxHours });
        }

        private void HoursModified(object sender, SignalboxHoursEventArgs e)
        {
            if (e.SignalboxHours != null)
            {
                OnSignalboxHoursModified(e.SignalboxHours);
            }
        }

        /// <summary>
        /// Raises the <see cref="SignalboxHoursModified" /> event.
        /// </summary>
        /// <param name="signalboxHours">The object which has been modified.</param>
        protected virtual void OnSignalboxHoursModified(SignalboxHours signalboxHours)
        {
            SignalboxHoursModified?.Invoke(this, new SignalboxHoursEventArgs { SignalboxHours = signalboxHours });
            Modified?.Invoke(this, new ModifiedEventArgs { ModifiedItem = this });
        }

        /// <summary>
        /// Raises the <see cref="Modified" /> event.
        /// </summary>
        protected virtual void OnModified()
        {
            Modified?.Invoke(this, new ModifiedEventArgs { ModifiedItem = this });
        }

        /// <summary>
        /// Create a deep copy of this object.
        /// </summary>
        /// <returns>A copy of this object.</returns>
        public SignalboxHoursSet Copy()
        {
            SignalboxHoursSet set = new SignalboxHoursSet
            {
                Id = Id,
                Category = Category,
            };
            foreach (var hours in Hours)
            {
                set.Hours.Add(hours.Key, hours.Value.Copy());
            }
            return set;
        }

        /// <summary>
        /// Copy this object's contents over a target object.
        /// </summary>
        /// <param name="target">The target to be overwritten.</param>
        public void CopyTo(SignalboxHoursSet target)
        {
            if (target == null)
            {
                throw new ArgumentNullException(nameof(target));
            }

            target.Id = Id;
            target.Category = Category;
            foreach (var hours in Hours.ToList())
            {
                if (target.Hours.ContainsKey(hours.Key))
                {
                    hours.Value.CopyTo(target.Hours[hours.Key]);
                }
                else
                {
                    target.Hours.Add(hours.Key, hours.Value.Copy());
                }
            }
            foreach (var hours in target.Hours.ToList())
            {
                if (!Hours.ContainsKey(hours.Key))
                {
                    target.Hours.Remove(hours.Key);
                }
            }
        }
    }
}
