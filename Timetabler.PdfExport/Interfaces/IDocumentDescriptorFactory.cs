using Unicorn.Interfaces;

namespace Timetabler.PdfExport.Interfaces
{
    public interface IDocumentDescriptorFactory
    {
        IDocumentDescriptor GetDocumentDescriptor(double horizontalMarginProportion, double verticalMarginProportion);
    }
}
