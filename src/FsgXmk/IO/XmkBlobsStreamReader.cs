using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FsgXmk.IO
{
    public class XmkBlobsStreamReader : IXmkBlobsReader
    {
        private readonly Stream _stream;
        private readonly IXmkBlobsByteArrayReaderFactory _readerFactory;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public XmkBlobsStreamReader(Stream stream, IXmkBlobsByteArrayReaderFactory readerFactory) : this(stream, readerFactory, false)
        {
        }

        public XmkBlobsStreamReader(Stream stream, IXmkBlobsByteArrayReaderFactory readerFactory, bool leaveOpen)
        {
            _stream = stream;
            _readerFactory = readerFactory;
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

        public IEnumerable<string> Read(uint blobsLength)
        {
            if (blobsLength == 0)
            {
                return Enumerable.Empty<string>();
            }

            var buffer = new byte[blobsLength];

            // TODO: Use ReadExactly when available
            var bytesRead = _stream.Read(buffer, 0, buffer.Length);

            if (bytesRead != buffer.Length)
            {
                throw new EndOfStreamException();
            }

            using (var reader = _readerFactory.Create(buffer, 0, buffer.Length))
            {
                return reader.Read(blobsLength);
            }
        }

        public async Task<IEnumerable<string>> ReadAsync(uint blobsLength)
        {
            if (blobsLength == 0)
            {
                return Enumerable.Empty<string>();
            }

            var buffer = new byte[blobsLength];

            // TODO: Use ReadExactlyAsync when available
            var bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);

            if (bytesRead != buffer.Length)
            {
                throw new EndOfStreamException();
            }

            using (var reader = _readerFactory.Create(buffer, 0, bytesRead))
            {
                return await reader.ReadAsync(blobsLength);
            }
        }
    }
}
