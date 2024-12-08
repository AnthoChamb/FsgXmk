using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class KaitaiXmkTimeSignatureByteArrayReaderFactory : IXmkTimeSignatureByteArrayReaderFactory
    {
        public IXmkTimeSignatureReader Create(byte[] buffer, int offset, int count)
        {
            return new KaitaiXmkTimeSignatureStreamReader(new KaitaiStream(new MemoryStream(buffer, offset, count, false)));
        }
    }
}
