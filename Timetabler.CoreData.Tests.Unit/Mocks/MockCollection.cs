using System.Collections;
using System.Collections.Generic;

namespace Timetabler.CoreData.Tests.Unit.Mocks
{
    internal class MockCollection<T> : ICollection<T>
    {
        private readonly List<T> _underlying = new List<T>();

        public int Count => _underlying.Count;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            _underlying.Add(item);
        }

        public void Clear()
        {
            _underlying.Clear();
        }

        public bool Contains(T item) => _underlying.Contains(item);

        public void CopyTo(T[] array, int arrayIndex)
        {
            _underlying.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator() => _underlying.GetEnumerator();

        public bool Remove(T item) => _underlying.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        internal static MockCollection<T> FromEnumerable(IEnumerable<T> data)
        {
            MockCollection<T> newCollection = new MockCollection<T>();
            newCollection._underlying.AddRange(data);
            return newCollection;
        }
    }
}
