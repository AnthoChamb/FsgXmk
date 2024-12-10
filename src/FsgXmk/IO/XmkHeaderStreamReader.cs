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
            _buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkHeaderSize);
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
                ArrayPool<byte>.Shared.Return(_buffer);
                _reader.Dispose();
                _disposed = true;
            }
        }

        public IXmkHeader Read()
        {
            // TODO: Use ObjectDisposedException.ThrowIf when available
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkHeaderStreamReader).FullName);
            }

            _stream.ReadExactly(_buffer, 0, XmkConstants.XmkHeaderSize);

            return _reader.Read();
        }

        public async Task<IXmkHeader> ReadAsync()
        {
            // TODO: Use ObjectDisposedException.ThrowIf when available
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkHeaderStreamReader).FullName);
            }

            await _stream.ReadExactlyAsync(_buffer, 0, XmkConstants.XmkHeaderSize);

            return await _reader.ReadAsync();
        }
    }
}
