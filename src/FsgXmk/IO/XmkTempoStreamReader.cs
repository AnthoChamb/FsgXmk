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
#if NET7_0_OR_GREATER
            ObjectDisposedException.ThrowIf(_disposed, typeof(XmkTempoStreamReader));
#else
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkTempoStreamReader).FullName);
            }
#endif

            _stream.ReadExactly(_buffer, 0, XmkConstants.XmkTempoSize);

            return _reader.Read();
        }

        public async Task<IXmkTempo> ReadAsync()
        {
#if NET7_0_OR_GREATER
            ObjectDisposedException.ThrowIf(_disposed, typeof(XmkTempoStreamReader));
#else
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkTempoStreamReader).FullName);
            }
#endif

            await _stream.ReadExactlyAsync(_buffer, 0, XmkConstants.XmkTempoSize);

            return await _reader.ReadAsync();
        }
    }
}
