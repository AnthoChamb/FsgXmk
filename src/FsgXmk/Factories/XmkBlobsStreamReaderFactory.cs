using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;
using System.IO;

namespace FsgXmk.Factories
{
    public class XmkBlobsStreamReaderFactory : IXmkBlobsStreamReaderFactory
    {
        private readonly IXmkBlobsByteArrayReaderFactory _readerFactory;

        public XmkBlobsStreamReaderFactory(IXmkBlobsByteArrayReaderFactory readerFactory)
        {
            _readerFactory = readerFactory;
        }

        public IXmkBlobsReader Create(Stream stream, bool leaveOpen)
        {
            return new XmkBlobsStreamReader(stream, _readerFactory, leaveOpen);
        }
    }
}
