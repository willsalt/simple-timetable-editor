namespace Timetabler.CoreData.Interfaces
{
    /// <summary>
    /// Represents an object which can be copied, and which can copy its data into another object of the same type.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    public interface ICopyableItem<T>
    {
        /// <summary>
        /// Return another object that is the same as this one.
        /// </summary>
        /// <returns>A copy of this object.</returns>
        T Copy();

        /// <summary>
        /// Copy this object's properties into another instance of this type.
        /// </summary>
        /// <param name="target">The target object to be overwritten.</param>
        void CopyTo(T target);
    }
}
