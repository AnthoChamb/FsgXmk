using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class KaitaiXmkTempoStreamReaderFactory : IXmkTempoStreamReaderFactory
    {
        public IXmkTempoReader Create(Stream stream, bool leaveOpen)
        {
            return new KaitaiXmkTempoStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
