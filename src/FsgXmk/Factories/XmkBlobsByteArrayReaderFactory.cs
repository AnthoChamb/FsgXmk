using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;

namespace FsgXmk.Factories
{
    public class XmkBlobsByteArrayReaderFactory : IXmkBlobsByteArrayReaderFactory
    {
        public IXmkBlobsReader Create(byte[] buffer, int offset, int count)
        {
            return new XmkBlobsByteArrayReader(buffer, offset, count);
        }
    }
}
