using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Kaitai.Factories;
using FsgXmk.Tests.IO;

namespace FsgXmk.Tests.Kaitai.IO
{
    public class KaitaiXmkTimeSignatureByteArrayReaderTest : XmkTimeSignatureByteArrayReaderTest
    {
        protected override IXmkTimeSignatureByteArrayReaderFactory Factory { get; } = new KaitaiXmkTimeSignatureByteArrayReaderFactory();
    }
}
