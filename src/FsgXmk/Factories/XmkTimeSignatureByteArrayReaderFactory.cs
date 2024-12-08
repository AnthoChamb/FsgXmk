using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;

namespace FsgXmk.Factories
{
    public class XmkTimeSignatureByteArrayReaderFactory : IXmkTimeSignatureByteArrayReaderFactory
    {
        public IXmkTimeSignatureReader Create(byte[] buffer, int offset, int count)
        {
            return new XmkTimeSignatureByteArrayReader(buffer, offset, count);
        }
    }
}
