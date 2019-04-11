using System;
using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.Data
{
    /// <summary>
    /// Opening times for a single signalbox.
    /// </summary>
    public class SignalboxHours : IWatchableItem, ICopyableItem<SignalboxHours>
    {
        private Signalbox _signalbox;
        private TimeOfDay _startTime;
        private TimeOfDay _endTime;
        private bool _tokenBalanceWarning;
        private object _tokenBalanceLock;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SignalboxHours()
        {
            _tokenBalanceLock = new object();
        }

        /// <summary>
        /// Event raised when this object is modified.
        /// </summary>
        public event ModifiedEventHandler Modified;

        /// <summary>
        /// The signalbox that these opening hours apply to.
        /// </summary>
        public Signalbox Signalbox
        {
            get
            {
                return _signalbox;
            }
            set
            {
                if (_signalbox == null)
                {
                    _signalbox = value;
                    if (_signalbox != null)
                    {
                        OnModified();
                    }
                    return;
                }

                lock (_signalbox)
                {
                    if (_signalbox != value)
                    {
                        _signalbox = value;
                        OnModified();
                    }
                }
            }
        }

        /// <summary>
        /// Turn start time.
        /// </summary>
        public TimeOfDay StartTime
        {
            get
            {
                return _startTime;
            }
            set
            {
                if (_startTime == null)
                {
                    _startTime = value;
                    if (_startTime != null)
                    {
                        OnModified();
                    }
                    return;
                }

                lock (_startTime)
                {
                    if (_startTime != value)
                    {
                        _startTime = value;
                        OnModified();
                    }
                }
            }
        }

        /// <summary>
        /// Turn end time.
        /// </summary>
        public TimeOfDay EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                if (_endTime == null)
                {
                    _endTime = value;
                    if (_endTime != null)
                    {
                        OnModified();
                    }
                    return;
                }

                lock (_endTime)
                {
                    if (_endTime != value)
                    {
                        _endTime = value;
                        OnModified();
                    }
                }
            }
        }

        /// <summary>
        /// Indicates whether or not this turn should be flagged as one which has unbalanced workings.
        /// </summary>
        public bool TokenBalanceWarning
        {
            get
            {
                return _tokenBalanceWarning;
            }
            set
            {
                lock (_tokenBalanceLock)
                {
                    if (_tokenBalanceWarning != value)
                    {
                        _tokenBalanceWarning = value;
                        OnModified();
                    }
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="Modified"/> event.
        /// </summary>
        protected void OnModified()
        {
            Modified?.Invoke(this, new ModifiedEventArgs { ModifiedItem = this });
        }

        /// <summary>
        /// Create a copy of this object.
        /// </summary>
        /// <returns>A coyp of this object.</returns>
        public SignalboxHours Copy()
        {
            return new SignalboxHours
            {
                Signalbox = Signalbox,
                StartTime = StartTime,
                EndTime = EndTime,
                TokenBalanceWarning = TokenBalanceWarning,
            };
        }

        /// <summary>
        /// Copy the contents of this object into a second object of the same type.
        /// </summary>
        /// <param name="target">The <see cref="SignalboxHours" /> object to be overwritten.</param>
        public void CopyTo(SignalboxHours target)
        {
            target.Signalbox = Signalbox;
            target.StartTime = StartTime;
            target.EndTime = EndTime;
            target.TokenBalanceWarning = TokenBalanceWarning;
        }

        /// <summary>
        /// Convert this object into a pair of strings, one for the start time and one for the finish time.
        /// </summary>
        /// <param name="clockType">Whether to use the 12-hour or 24-hour clock format.</param>
        /// <returns>An array of strings of two elements, element 0 being the formatted start time and element 1 being the formatted finish time.</returns>
        public string[] ToStrings(ClockType clockType)
        {
            string timeFormatFormat;
            string noTokenWarning;

            if (clockType == ClockType.TwelveHourClock)
            {
                timeFormatFormat = "ht{0}mm";
                noTokenWarning = string.Empty;
            }
            else
            {
                timeFormatFormat = "HH{0}mm";
                noTokenWarning = " ";
            }

            string startTime = FormatTime(StartTime, timeFormatFormat, noTokenWarning);
            string endTime = FormatTime(EndTime, timeFormatFormat, noTokenWarning);
            return new[] { startTime, endTime };
        }

        /// <summary>
        /// Convert this object into a string containing the start time and finish time.
        /// </summary>
        /// <param name="clockType">Whether to use the 12-hour or 24-hour clock format.</param>
        /// <returns>A string containing the formatted start and finish times.</returns>
        public string ToString(ClockType clockType)
        {
            string[] strings = ToStrings(clockType);
            return string.Format("{0} - {1}", strings[0], strings[1]);
        }

        private string FormatTime(TimeOfDay time, string format, string noTokenWarning)
        {
            return time != null ? string.Format(time.ToString(format), TokenBalanceWarning ? Resources.SignalboxHours_TokenBalanceWarningSymbol : noTokenWarning) : string.Empty;
        }
    }
}
