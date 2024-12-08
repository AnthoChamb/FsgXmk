using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;
using System.IO;

namespace FsgXmk.Factories
{
    public class XmkTimeSignatureStreamReaderFactory : IXmkTimeSignatureStreamReaderFactory
    {
        private readonly IXmkTimeSignatureByteArrayReaderFactory _readerFactory;

        public XmkTimeSignatureStreamReaderFactory(IXmkTimeSignatureByteArrayReaderFactory readerFactory)
        {
            _readerFactory = readerFactory;
        }

        public IXmkTimeSignatureReader Create(Stream stream, bool leaveOpen)
        {
            return new XmkTimeSignatureStreamReader(stream, _readerFactory, leaveOpen);
        }
    }
}
