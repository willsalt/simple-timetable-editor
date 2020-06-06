using System;

namespace Unicorn.Writer
{
    /// <summary>
    /// PDf-writing feature toggles.
    /// </summary>
    public static class Features
    {
        /// <summary>
        /// Possible feature settings for writing PDF streams.
        /// </summary>
        [Flags]
        public enum StreamFeatureFlags
        {
            /// <summary>
            /// ASCII-encode binary streams usiing the <c>/ASCII85Decode</c> filter.  This can produce files that do not render correctly on legacy versions of 
            /// Microsoft Edge that use the EdgeHTML rendering engine, as it does not appear to recognise TrueType fonts encoded solely with this filter.
            /// </summary>
            AsciiEncodeBinaryStreams = 1
        }

        /// <summary>
        /// Feature toggles for writing PDF streams.
        /// </summary>
        public static StreamFeatureFlags StreamFeatures { get; set; } = 0;
    }
}
