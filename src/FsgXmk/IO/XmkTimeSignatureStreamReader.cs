#if NETSTANDARD2_0
using CommunityToolkit.Diagnostics;
#endif
using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.Factories;
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
    public class XmkTimeSignatureStreamReader : IXmkTimeSignatureReader
    {
        private readonly Stream _stream;
        private readonly byte[] _buffer;
        private readonly IXmkTimeSignatureReader _reader;

        private readonly bool _leaveOpen;
        private bool _disposed;

        public XmkTimeSignatureStreamReader(Stream stream) : this(stream, false)
        {
        }

        public XmkTimeSignatureStreamReader(Stream stream, bool leaveOpen) : this(stream, new XmkTimeSignatureByteArrayReaderFactory(), leaveOpen)
        {
        }

        public XmkTimeSignatureStreamReader(Stream stream, IXmkTimeSignatureByteArrayReaderFactory readerFactory) : this(stream, readerFactory, false)
        {
        }

        public XmkTimeSignatureStreamReader(Stream stream, IXmkTimeSignatureByteArrayReaderFactory readerFactory, bool leaveOpen)
        {
            _stream = stream;
            _buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkTimeSignatureSize);
            _reader = readerFactory.Create(_buffer, 0, XmkConstants.XmkTimeSignatureSize);
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

        public IXmkTimeSignature Read()
        {
#if NET7_0_OR_GREATER
            ObjectDisposedException.ThrowIf(_disposed, typeof(XmkTimeSignatureStreamReader));
#else
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkTimeSignatureStreamReader).FullName);
            }
#endif

            _stream.ReadExactly(_buffer, 0, XmkConstants.XmkTimeSignatureSize);

            return _reader.Read();
        }

        public async ValueTask<IXmkTimeSignature> ReadAsync()
        {
#if NET7_0_OR_GREATER
            ObjectDisposedException.ThrowIf(_disposed, typeof(XmkTimeSignatureStreamReader));
#else
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkTimeSignatureStreamReader).FullName);
            }
#endif

            await _stream.ReadExactlyAsync(_buffer, 0, XmkConstants.XmkTimeSignatureSize);

            return await _reader.ReadAsync();
        }
    }
}
