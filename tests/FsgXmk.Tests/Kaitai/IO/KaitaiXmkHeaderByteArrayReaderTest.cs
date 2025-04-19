using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using FsgXmk.Tests.IO;

namespace FsgXmk.Tests.Kaitai.IO
{
    public class KaitaiXmkHeaderByteArrayReaderTest : XmkHeaderByteArrayReaderTest
    {
        protected override IXmkHeaderByteArrayReaderFactory Factory { get; } = new KaitaiXmkHeaderByteArrayReaderFactory();
    }
}
