using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;
using System.IO;

namespace FsgXmk.Factories
{
    public class XmkEventStreamReaderFactory : IXmkEventStreamReaderFactory
    {
        private readonly IXmkEventByteArrayReaderFactory _readerFactory;

        public XmkEventStreamReaderFactory(IXmkEventByteArrayReaderFactory readerFactory)
        {
            _readerFactory = readerFactory;
        }

        public IXmkEventReader Create(Stream stream, bool leaveOpen)
        {
            return new XmkEventStreamReader(stream, _readerFactory, leaveOpen);
        }
    }
}
