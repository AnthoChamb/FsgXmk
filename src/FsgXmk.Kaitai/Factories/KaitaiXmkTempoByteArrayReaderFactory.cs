using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class KaitaiXmkTempoByteArrayReaderFactory : IXmkTempoByteArrayReaderFactory
    {
        public IXmkTempoReader Create(byte[] buffer, int offset, int count)
        {
            return new KaitaiXmkTempoStreamReader(new KaitaiStream(new MemoryStream(buffer, offset, count, false)));
        }
    }
}
