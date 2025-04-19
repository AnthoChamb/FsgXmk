using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using FsgXmk.Tests.IO;

namespace FsgXmk.Tests.Kaitai.IO
{
    public class KaitaiXmkTempoStreamReaderTest : XmkTempoStreamReaderTest
    {
        protected override IXmkTempoStreamReaderFactory Factory { get; } = new KaitaiXmkTempoStreamReaderFactory();
    }
}
