using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using FsgXmk.Tests.IO;

namespace FsgXmk.Tests.Kaitai.IO
{
    public class KaitaiXmkTimeSignatureStreamReaderTest : XmkTimeSignatureStreamReaderTest
    {
        protected override IXmkTimeSignatureStreamReaderFactory Factory { get; } = new KaitaiXmkTimeSignatureStreamReaderFactory();
    }
}
