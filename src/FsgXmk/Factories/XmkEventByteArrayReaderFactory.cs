using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;

namespace FsgXmk.Factories
{
    public class XmkEventByteArrayReaderFactory : IXmkEventByteArrayReaderFactory
    {
        public IXmkEventReader Create(byte[] buffer, int offset, int count)
        {
            return new XmkEventByteArrayReader(buffer, offset, count);
        }
    }
}
