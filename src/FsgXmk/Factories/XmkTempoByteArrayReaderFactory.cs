using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;

namespace FsgXmk.Factories
{
    public class XmkTempoByteArrayReaderFactory : IXmkTempoByteArrayReaderFactory
    {
        public IXmkTempoReader Create(byte[] buffer, int offset, int count)
        {
            return new XmkTempoByteArrayReader(buffer, offset, count);
        }
    }
}
