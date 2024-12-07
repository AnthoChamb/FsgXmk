using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FsgXmk.IO
{
    public class XmkHeaderStreamReader : IXmkHeaderReader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IXmkHeaderReader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public XmkHeaderStreamReader(Stream stream, IXmkHeaderByteArrayReaderFactory readerFactory) : this(stream, readerFactory, false)
        {
        }

        public XmkHeaderStreamReader(Stream stream, IXmkHeaderByteArrayReaderFactory readerFactory, bool leaveOpen)
        {
            _stream = stream;
            // TODO: Use ArrayPool when available
            _buffer = new byte[XmkConstants.XmkHeaderSize];
            _reader = readerFactory.Create(_buffer, 0, XmkConstants.XmkHeaderSize);
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
                // TODO: Use ArrayPool when available
                _reader.Dispose();
                _disposed = true;
            }
        }

        public IXmkHeader Read()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(XmkHeaderStreamReader));
            }

            // TODO: Use ReadExactly when available
            var bytesRead = _stream.Read(_buffer, 0, XmkConstants.XmkHeaderSize);

            if (bytesRead != XmkConstants.XmkHeaderSize)
            {
                throw new EndOfStreamException();
            }

            return _reader.Read();
        }

        public async Task<IXmkHeader> ReadAsync()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(XmkHeaderStreamReader));
            }

            // TODO: Use ReadExactlyAsync when available
            var bytesRead = await _stream.ReadAsync(_buffer, 0, XmkConstants.XmkHeaderSize);

            if (bytesRead != XmkConstants.XmkHeaderSize)
            {
                throw new EndOfStreamException();
            }

            return await _reader.ReadAsync();
        }
    }
}
