using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO;
using System.IO;

namespace FsgXmk.Factories
{
    public class XmkStreamReaderFactory : IXmkStreamReaderFactory
    {
        private readonly IXmkHeaderStreamReaderFactory _headerReaderFactory;
        private readonly IXmkTempoStreamReaderFactory _tempoReaderFactory;
        private readonly IXmkTimeSignatureStreamReaderFactory _timeSignatureReaderFactory;
        private readonly IXmkEventStreamReaderFactory _eventReaderFactory;
        private readonly IXmkBlobsStreamReaderFactory _blobsReaderFactory;

        public XmkStreamReaderFactory(IXmkHeaderStreamReaderFactory headerReaderFactory,
                                      IXmkTempoStreamReaderFactory tempoReaderFactory,
                                      IXmkTimeSignatureStreamReaderFactory timeSignatureReaderFactory,
                                      IXmkEventStreamReaderFactory eventReaderFactory,
                                      IXmkBlobsStreamReaderFactory blobsReaderFactory)
        {
            _headerReaderFactory = headerReaderFactory;
            _tempoReaderFactory = tempoReaderFactory;
            _timeSignatureReaderFactory = timeSignatureReaderFactory;
            _eventReaderFactory = eventReaderFactory;
            _blobsReaderFactory = blobsReaderFactory;
        }

        public IXmkReader Create(Stream stream, bool leaveOpen)
        {
            return new XmkStreamReader(stream,
                                       _headerReaderFactory,
                                       _tempoReaderFactory,
                                       _timeSignatureReaderFactory,
                                       _eventReaderFactory,
                                       _blobsReaderFactory,
                                       leaveOpen);
        }
    }
}
