using Timetabler.Data;
using Timetabler.PdfExport.Interfaces;
using Unicorn.Impl.PdfSharp;
using Unicorn.Interfaces;
using Unicorn.Writer;

namespace Timetabler.PdfExport
{
    public class DocumentDescriptorFactory : IDocumentDescriptorFactory
    {
        private readonly PdfExportEngine _engine;

        public DocumentDescriptorFactory(PdfExportEngine engine)
        {
            _engine = engine;
        }

        public IDocumentDescriptor GetDocumentDescriptor(double horizontalMarginProportion, double verticalMarginProportion)
        {
            switch (_engine)
            {
                case PdfExportEngine.Unicorn:
                default:
                    return new PdfDocument(PhysicalPageSize.A4, PageOrientation.Landscape, horizontalMarginProportion, verticalMarginProportion);
                case PdfExportEngine.External:
                    return new DocumentDescriptor(PhysicalPageSize.A4, PageOrientation.Landscape, horizontalMarginProportion, verticalMarginProportion);
            }
        }
    }
}
