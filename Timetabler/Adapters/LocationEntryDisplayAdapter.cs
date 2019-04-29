using System.Windows.Forms;
using Timetabler.Data.Display.Interfaces;

namespace Timetabler.Adapters
{
    internal class LocationEntryDisplayAdapter : ILocationEntryDisplayAdapter
    {
        private DataGridViewCell _cell;
        private string _lastSetValue;
        private object _lockObject = new object();

        internal DataGridViewCell Cell
        {
            get
            {
                return _cell;
            }
            set
            {
                _cell = value;
                SetCellValue();
            }
        }

        public void DisplayedTextChanged(string displayedText)
        {
            _lastSetValue = displayedText;
            SetCellValue();
        }

        private void SetCellValue()
        {
            lock (_lockObject)
            {
                if (_cell != null)
                {
                    _cell.Value = _lastSetValue;
                }
            }
        }
    }
}
