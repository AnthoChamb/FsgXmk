using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;

namespace FsgXmk.Factories
{
    public class XmkHeaderByteArrayReaderFactory : IXmkHeaderByteArrayReaderFactory
    {
        public IXmkHeaderReader Create(byte[] buffer, int offset, int count)
        {
            return new XmkHeaderByteArrayReader(buffer, offset, count);
        }
    }
}
