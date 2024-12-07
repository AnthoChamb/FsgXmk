using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class KaitaiXmkBlobsStreamReaderFactory : IXmkBlobsStreamReaderFactory
    {
        public IXmkBlobsReader Create(Stream stream, bool leaveOpen)
        {
            return new KaitaiXmkBlobsStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
