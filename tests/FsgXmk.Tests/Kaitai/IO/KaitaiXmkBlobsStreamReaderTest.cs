using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using FsgXmk.Tests.IO;

namespace FsgXmk.Tests.Kaitai.IO
{
    public class KaitaiXmkBlobsStreamReaderTest : XmkBlobsStreamReaderTest
    {
        protected override IXmkBlobsStreamReaderFactory Factory { get; } = new KaitaiXmkBlobsStreamReaderFactory();
    }
}
