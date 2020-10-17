using Timetabler.CoreData.Events;
using Timetabler.CoreData.Interfaces;

namespace Timetabler.CoreData.Tests.Unit.Mocks
{
    internal class MockWatchableItem : IWatchableItem
    {
        public event ModifiedEventHandler Modified;

        protected void OnModified(string fieldName)
        {
            Modified?.Invoke(this, new ModifiedEventArgs(this, fieldName));
        }
    }
}
