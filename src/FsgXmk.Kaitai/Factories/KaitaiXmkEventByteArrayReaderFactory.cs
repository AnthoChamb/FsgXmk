using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class KaitaiXmkEventByteArrayReaderFactory : IXmkEventByteArrayReaderFactory
    {
        public IXmkEventReader Create(byte[] buffer, int offset, int count)
        {
            return new KaitaiXmkEventStreamReader(new KaitaiStream(new MemoryStream(buffer, offset, count, false)));
        }
    }
}
