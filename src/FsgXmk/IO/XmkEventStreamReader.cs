#if NETSTANDARD2_0
using CommunityToolkit.Diagnostics;
#endif
using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
#if NETSTANDARD2_0
using FsgXmk.IO.Extensions;
#endif
#if NET7_0_OR_GREATER
using System;
#endif
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
#if NET7_0_OR_GREATER
            ObjectDisposedException.ThrowIf(_disposed, typeof(XmkEventStreamReader));
#else
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkEventStreamReader).FullName);
            }
#endif

            _stream.ReadExactly(_buffer, 0, XmkConstants.XmkEventSize);

            return _reader.Read();
        }

        public async Task<IXmkEvent> ReadAsync()
        {
#if NET7_0_OR_GREATER
            ObjectDisposedException.ThrowIf(_disposed, typeof(XmkEventStreamReader));
#else
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkEventStreamReader).FullName);
            }
#endif

            await _stream.ReadExactlyAsync(_buffer, 0, XmkConstants.XmkEventSize);

            return await _reader.ReadAsync();
        }
    }
}
