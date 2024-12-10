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
    public class XmkTempoStreamReader : IXmkTempoReader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IXmkTempoReader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public XmkTempoStreamReader(Stream stream, IXmkTempoByteArrayReaderFactory readerFactory) : this(stream, readerFactory, false)
        {
        }

        public XmkTempoStreamReader(Stream stream, IXmkTempoByteArrayReaderFactory readerFactory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkTempoSize);
            _reader = readerFactory.Create(_buffer, 0, XmkConstants.XmkTempoSize);
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

        public IXmkTempo Read()
        {
            // TODO: Use ObjectDisposedException.ThrowIf when available
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkTempoStreamReader).FullName);
            }

            _stream.ReadExactly(_buffer, 0, XmkConstants.XmkTempoSize);

            return _reader.Read();
        }

        public async Task<IXmkTempo> ReadAsync()
        {
            // TODO: Use ObjectDisposedException.ThrowIf when available
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkTempoStreamReader).FullName);
            }

            await _stream.ReadExactlyAsync(_buffer, 0, XmkConstants.XmkTempoSize);

            return await _reader.ReadAsync();
        }
    }
}
