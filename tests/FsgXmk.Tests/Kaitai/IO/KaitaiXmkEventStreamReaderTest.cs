using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using FsgXmk.Tests.IO;

namespace FsgXmk.Tests.Kaitai.IO
{
    public class KaitaiXmkEventStreamReaderTest : XmkEventStreamReaderTest
    {
        protected override IXmkEventStreamReaderFactory Factory { get; } = new KaitaiXmkEventStreamReaderFactory();
    }
}
