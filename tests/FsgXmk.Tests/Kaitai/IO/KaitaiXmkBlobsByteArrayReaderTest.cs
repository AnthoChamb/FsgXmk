using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using FsgXmk.Tests.IO;

namespace FsgXmk.Tests.Kaitai.IO
{
    public class KaitaiXmkBlobsByteArrayReaderTest : XmkBlobsByteArrayReaderTest
    {
        protected override IXmkBlobsByteArrayReaderFactory Factory { get; } = new KaitaiXmkBlobsByteArrayReaderFactory();
    }
}
