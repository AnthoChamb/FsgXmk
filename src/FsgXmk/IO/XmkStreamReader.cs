using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FsgXmk.IO
{
    public class XmkStreamReader : IXmkReader
    {
        private readonly Stream _stream;
        private readonly IXmkHeaderStreamReaderFactory _headerReaderFactory;
        private readonly IXmkTempoStreamReaderFactory _tempoReaderFactory;
        private readonly IXmkTimeSignatureStreamReaderFactory _timeSignatureReaderFactory;
        private readonly IXmkEventStreamReaderFactory _eventReaderFactory;
        private readonly IXmkBlobsStreamReaderFactory _blobsReaderFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public XmkStreamReader(Stream stream,
                               IXmkHeaderStreamReaderFactory headerReaderFactory,
                               IXmkTempoStreamReaderFactory tempoReaderFactory,
                               IXmkTimeSignatureStreamReaderFactory timeSignatureReaderFactory,
                               IXmkEventStreamReaderFactory eventReaderFactory,
                               IXmkBlobsStreamReaderFactory blobsReaderFactory)
            : this(stream,
                   headerReaderFactory,
                   tempoReaderFactory,
                   timeSignatureReaderFactory,
                   eventReaderFactory,
                   blobsReaderFactory,
                   false)
        {
        }

        public XmkStreamReader(Stream stream,
                               IXmkHeaderStreamReaderFactory headerReaderFactory,
                               IXmkTempoStreamReaderFactory tempoReaderFactory,
                               IXmkTimeSignatureStreamReaderFactory timeSignatureReaderFactory,
                               IXmkEventStreamReaderFactory eventReaderFactory,
                               IXmkBlobsStreamReaderFactory blobsReaderFactory,
                               bool leaveOpen)
        {
            _stream = stream;
            _headerReaderFactory = headerReaderFactory;
            _tempoReaderFactory = tempoReaderFactory;
            _timeSignatureReaderFactory = timeSignatureReaderFactory;
            _eventReaderFactory = eventReaderFactory;
            _blobsReaderFactory = blobsReaderFactory;
            _leaveOpen = leaveOpen;
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                if (!_leaveOpen)
                {
                    _stream.Dispose();
                }
                _disposed = true;
            }
        }

        public IXmk Read()
        {
            IXmkHeader header;
            using (var headerReader = _headerReaderFactory.Create(_stream, true))
            {
                header = headerReader.Read();
            }

            IXmkTempo[] tempos;
            if (header.TempoCount == 0)
            {
                tempos = Array.Empty<IXmkTempo>();
            }
            else
            {
                tempos = new IXmkTempo[header.TempoCount];

                using (var tempoReader = _tempoReaderFactory.Create(_stream, true))
                {
                    for (var i = 0; i < header.TempoCount; i++)
                    {
                        tempos[i] = tempoReader.Read();
                    }
                }
            }

            IXmkTimeSignature[] timeSignatures;
            if (header.TimeSignatureCount == 0)
            {
                timeSignatures = Array.Empty<IXmkTimeSignature>();
            }
            else
            {
                timeSignatures = new IXmkTimeSignature[header.TimeSignatureCount];

                using (var timeSignatureReader = _timeSignatureReaderFactory.Create(_stream, true))
                {
                    for (var i = 0; i < header.TimeSignatureCount; i++)
                    {
                        timeSignatures[i] = timeSignatureReader.Read();
                    }
                }
            }

            IXmkEvent[] events;
            if (header.EventCount == 0)
            {
                events = Array.Empty<IXmkEvent>();
            }
            else
            {
                events = new IXmkEvent[header.EventCount];

                using (var eventReader = _eventReaderFactory.Create(_stream, true))
                {
                    for (var i = 0; i < header.EventCount; i++)
                    {
                        events[i] = eventReader.Read();
                    }
                }
            }

            IEnumerable<string> blobs;
            using (var blobsReader = _blobsReaderFactory.Create(_stream, true))
            {
                blobs = blobsReader.Read(header.BlobsLength);
            }

            return new Xmk(header, tempos, timeSignatures, events, blobs);
        }

        public async Task<IXmk> ReadAsync()
        {
            IXmkHeader header;
            using (var headerReader = _headerReaderFactory.Create(_stream, true))
            {
                header = await headerReader.ReadAsync();
            }

            IXmkTempo[] tempos;
            if (header.TempoCount == 0)
            {
                tempos = Array.Empty<IXmkTempo>();
            }
            else
            {
                tempos = new IXmkTempo[header.TempoCount];

                using (var tempoReader = _tempoReaderFactory.Create(_stream, true))
                {
                    for (var i = 0; i < header.TempoCount; i++)
                    {
                        tempos[i] = await tempoReader.ReadAsync();
                    }
                }
            }

            IXmkTimeSignature[] timeSignatures;
            if (header.TimeSignatureCount == 0)
            {
                timeSignatures = Array.Empty<IXmkTimeSignature>();
            }
            else
            {
                timeSignatures = new IXmkTimeSignature[header.TimeSignatureCount];

                using (var timeSignatureReader = _timeSignatureReaderFactory.Create(_stream, true))
                {
                    for (var i = 0; i < header.TimeSignatureCount; i++)
                    {
                        timeSignatures[i] = await timeSignatureReader.ReadAsync();
                    }
                }
            }

            IXmkEvent[] events;
            if (header.EventCount == 0)
            {
                events = Array.Empty<IXmkEvent>();
            }
            else
            {
                events = new IXmkEvent[header.EventCount];

                using (var eventReader = _eventReaderFactory.Create(_stream, true))
                {
                    for (var i = 0; i < header.EventCount; i++)
                    {
                        events[i] = await eventReader.ReadAsync();
                    }
                }
            }

            IEnumerable<string> blobs;
            using (var blobsReader = _blobsReaderFactory.Create(_stream, true))
            {
                blobs = await blobsReader.ReadAsync(header.BlobsLength);
            }

            return new Xmk(header, tempos, timeSignatures, events, blobs);
        }
    }
}
