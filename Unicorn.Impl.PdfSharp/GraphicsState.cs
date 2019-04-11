using PdfSharp.Drawing;
using Unicorn.Interfaces;

namespace Unicorn.Impl.PdfSharp
{
    /// <summary>
    /// Encapsulates the state of a graphics context at a given moment.
    /// </summary>
    public class GraphicsState : IGraphicsState
    {
        internal XGraphicsState InnerState { get; private set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="state">The PDFSharp state object.</param>
        public GraphicsState(XGraphicsState state)
        {
            InnerState = state;
        }
    }
}
