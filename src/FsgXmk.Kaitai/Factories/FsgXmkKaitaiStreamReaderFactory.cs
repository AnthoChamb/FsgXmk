using FsgXmk.Core.Interfaces.Factories;
using FsgXmk.Core.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class FsgXmkKaitaiStreamReaderFactory : IFsgXmkStreamReaderFactory
    {
        public IFsgXmkReader Create(Stream stream, bool leaveOpen)
        {
            return new FsgXmkKaitaiStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
