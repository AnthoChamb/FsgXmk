using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class KaitaiXmkTimeSignatureStreamReaderFactory : IXmkTimeSignatureStreamReaderFactory
    {
        public IXmkTimeSignatureReader Create(Stream stream, bool leaveOpen)
        {
            return new KaitaiXmkTimeSignatureStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
