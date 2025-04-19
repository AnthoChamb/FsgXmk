using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using FsgXmk.Tests.IO;

namespace FsgXmk.Tests.Kaitai.IO
{
    public class KaitaiXmkEventByteArrayReaderTest : XmkEventByteArrayReaderTest
    {
        protected override IXmkEventByteArrayReaderFactory Factory { get; } = new KaitaiXmkEventByteArrayReaderFactory();
    }
}
