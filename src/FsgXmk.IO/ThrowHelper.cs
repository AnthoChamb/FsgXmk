using System.IO;

namespace FsgXmk.IO
{
    internal static class ThrowHelper
    {
        /// <summary>
        /// Throws a new <see cref="EndOfStreamException"/>.
        /// </summary>
        /// <exception cref="EndOfStreamException">Thrown with no parameters.</exception>
        internal static void ThrowEndOfStreamException()
        {
            throw new EndOfStreamException();
        }
    }
}
