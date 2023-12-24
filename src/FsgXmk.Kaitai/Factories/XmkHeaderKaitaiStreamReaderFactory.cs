using FsgXmk.Core.Interfaces.Factories;
using FsgXmk.Core.Interfaces.IO;
using FsgXmk.Kaitai.IO;
using Kaitai;
using System.IO;

namespace FsgXmk.Kaitai.Factories
{
    public class XmkHeaderKaitaiStreamReaderFactory : IXmkHeaderStreamReaderFactory
    {
        public IXmkHeaderReader Create(Stream stream, bool leaveOpen)
        {
            return new XmkHeaderKaitaiStreamReader(new KaitaiStream(stream), leaveOpen);
        }
    }
}
