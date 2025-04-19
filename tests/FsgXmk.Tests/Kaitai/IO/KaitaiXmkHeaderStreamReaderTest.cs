using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using FsgXmk.Tests.IO;

namespace FsgXmk.Tests.Kaitai.IO
{
    public class KaitaiXmkHeaderStreamReaderTest : XmkHeaderStreamReaderTest
    {
        protected override IXmkHeaderStreamReaderFactory Factory { get; } = new KaitaiXmkHeaderStreamReaderFactory();
    }
}
