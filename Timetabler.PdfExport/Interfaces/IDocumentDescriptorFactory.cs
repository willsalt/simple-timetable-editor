using Unicorn.Interfaces;

namespace Timetabler.PdfExport.Interfaces
{
    public interface IDocumentDescriptorFactory
    {
        string ImplementationName { get; }

        IDocumentDescriptor GetDocumentDescriptor(double horizontalMarginProportion, double verticalMarginProportion);
    }
}
