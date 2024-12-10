using CommunityToolkit.Diagnostics;
using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.IO.Extensions;
using System.Buffers;
using System.IO;
using System.Threading.Tasks;

namespace FsgXmk.IO
{
    public class XmkEventStreamReader : IXmkEventReader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IXmkEventReader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public XmkEventStreamReader(Stream stream, IXmkEventByteArrayReaderFactory readerFactory) : this(stream, readerFactory, false)
        {
        }

        public XmkEventStreamReader(Stream stream, IXmkEventByteArrayReaderFactory readerFactory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkEventSize);
            _reader = readerFactory.Create(_buffer, 0, XmkConstants.XmkEventSize);
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
                ArrayPool<byte>.Shared.Return(_buffer);
                _reader.Dispose();
                _disposed = true;
            }
        }

        public IXmkEvent Read()
        {
            // TODO: Use ObjectDisposedException.ThrowIf when available
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkEventStreamReader).FullName);
            }

            _stream.ReadExactly(_buffer, 0, XmkConstants.XmkEventSize);

            return _reader.Read();
        }

        public async Task<IXmkEvent> ReadAsync()
        {
            // TODO: Use ObjectDisposedException.ThrowIf when available
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkEventStreamReader).FullName);
            }

            await _stream.ReadExactlyAsync(_buffer, 0, XmkConstants.XmkEventSize);

            return await _reader.ReadAsync();
        }
    }
}
