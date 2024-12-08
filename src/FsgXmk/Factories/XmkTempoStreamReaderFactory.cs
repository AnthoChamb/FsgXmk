using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;
using System.IO;

namespace FsgXmk.Factories
{
    public class XmkTempoStreamReaderFactory : IXmkTempoStreamReaderFactory
    {
        private readonly IXmkTempoByteArrayReaderFactory _readerFactory;

        public XmkTempoStreamReaderFactory(IXmkTempoByteArrayReaderFactory readerFactory)
        {
            _readerFactory = readerFactory;
        }

        public IXmkTempoReader Create(Stream stream, bool leaveOpen)
        {
            return new XmkTempoStreamReader(stream, _readerFactory, leaveOpen);
        }
    }
}
