using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;
using System.IO;

namespace FsgXmk.Factories
{
    public class XmkHeaderStreamReaderFactory : IXmkHeaderStreamReaderFactory
    {
        private readonly IXmkHeaderByteArrayReaderFactory _readerFactory;

        public XmkHeaderStreamReaderFactory(IXmkHeaderByteArrayReaderFactory readerFactory)
        {
            _readerFactory = readerFactory;
        }

        public IXmkHeaderReader Create(Stream stream, bool leaveOpen)
        {
            return new XmkHeaderStreamReader(stream, _readerFactory, leaveOpen);
        }
    }
}
