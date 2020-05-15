using Unicorn.CoreTypes;

namespace Timetabler.PdfExport.Interfaces
{
    /// <summary>
    /// Interface for factory classes that create Unicorn driver-implementation-level classes.
    /// </summary>
    public interface IDocumentDescriptorFactory
    {
        /// <summary>
        /// The name of the Unicorn driver implementation used by this factory.
        /// </summary>
        string ImplementationName { get; }

        /// <summary>
        /// Create an <see cref="IDocumentDescriptor" /> object for this factory's Unicorn implementation.
        /// </summary>
        /// <param name="horizontalMarginProportion">The default horizontal margin proportion for the new document.</param>
        /// <param name="verticalMarginProportion">The default vertical margin proportion for the new document.</param>
        /// <returns>An <see cref="IDocumentDescriptor" /> object for a particular Unicorn driver implementation.</returns>
        IDocumentDescriptor GetDocumentDescriptor(double horizontalMarginProportion, double verticalMarginProportion);
    }
}
