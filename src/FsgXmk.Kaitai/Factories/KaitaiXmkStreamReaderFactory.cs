using FsgXmk.Core.Interfaces.Factories;
using FsgXmk.Core.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class KaitaiXmkStreamReaderFactory : IXmkStreamReaderFactory
    {
        public IXmkReader Create(Stream stream, bool leaveOpen)
        {
            return new KaitaiXmkStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
