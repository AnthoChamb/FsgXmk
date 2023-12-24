using FsgXmk.Core.Interfaces.Factories;
using FsgXmk.Core.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class XmkTimeSignatureKaitaiStreamReaderFactory : IXmkTimeSignatureStreamReaderFactory
    {
        public IXmkTimeSignatureReader Create(Stream stream, bool leaveOpen)
        {
            return new XmkTimeSignatureKaitaiStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
