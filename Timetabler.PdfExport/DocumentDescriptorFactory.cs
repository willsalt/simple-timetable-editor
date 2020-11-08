using Timetabler.Data;
using Timetabler.PdfExport.Interfaces;
using Unicorn.CoreTypes;
using Unicorn.Writer;

namespace Timetabler.PdfExport
{
    /// <summary>
    /// Factory class for creating Unicorn driver-level objects, so that it can select which Unicorn driver implementation to use.
    /// </summary>
    public class DocumentDescriptorFactory : IDocumentDescriptorFactory
    {
        private readonly PdfExportEngine _engine;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="engine">Which PDF export technology to use.</param>
        public DocumentDescriptorFactory(PdfExportEngine engine)
        {
            _engine = engine;
        }

        /// <summary>
        /// The name of the PDF export implementation used by this factory.
        /// </summary>
        public string ImplementationName
        {
            get
            {
                switch (_engine)
                {
                    case PdfExportEngine.Unicorn:
                    default:
                        return "Unicorn";
                }
            }
        }

        /// <summary>
        /// Create an <see cref="IDocumentDescriptor" />, selecting the appropriate implementation for this factory's configuration.
        /// </summary>
        /// <param name="horizontalMarginProportion">The default proportion of the width of the page to be taken up by margins.  The current implementation
        /// forces the printable area to be centred in the page.</param>
        /// <param name="verticalMarginProportion">The default proportion of the height of the page to be taken up by margins.  The current implementation
        /// forced the printable area to be centred in the page.</param>
        /// <returns>An <see cref="IDocumentDescriptor" /> implementation configured appropriately, belonging to the technology that this factory is set up 
        /// for.</returns>
        public IDocumentDescriptor GetDocumentDescriptor(double horizontalMarginProportion, double verticalMarginProportion)
        {
            switch (_engine)
            {
                case PdfExportEngine.Unicorn:
                default:
                    return new PdfDocument(PhysicalPageSize.A4, PageOrientation.Landscape, horizontalMarginProportion, verticalMarginProportion);
            }
        }
    }
}
