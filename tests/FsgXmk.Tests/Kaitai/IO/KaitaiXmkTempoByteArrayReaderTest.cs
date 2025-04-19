using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using FsgXmk.Tests.IO;

namespace FsgXmk.Tests.Kaitai.IO
{
    public class KaitaiXmkTempoByteArrayReaderTest : XmkTempoByteArrayReaderTest
    {
        protected override IXmkTempoByteArrayReaderFactory Factory { get; } = new KaitaiXmkTempoByteArrayReaderFactory();
    }
}
