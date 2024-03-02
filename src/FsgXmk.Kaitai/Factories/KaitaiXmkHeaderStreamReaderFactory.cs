using FsgXmk.Core.Interfaces.Factories;
using FsgXmk.Core.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class KaitaiXmkHeaderStreamReaderFactory : IXmkHeaderStreamReaderFactory
    {
        public IXmkHeaderReader Create(Stream stream, bool leaveOpen)
        {
            return new KaitaiXmkHeaderStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
