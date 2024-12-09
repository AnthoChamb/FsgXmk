using CommunityToolkit.Diagnostics;
using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
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
            // TODO: Use ObjectDisposedException.ThrowIf when available
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkTimeSignatureStreamReader).FullName);
            }

            // TODO: Use ReadExactly when available
            var bytesRead = _stream.Read(_buffer, 0, XmkConstants.XmkTimeSignatureSize);

            if (bytesRead != XmkConstants.XmkTimeSignatureSize)
            {
                throw new EndOfStreamException();
            }

            return _reader.Read();
        }

        public async Task<IXmkTimeSignature> ReadAsync()
        {
            // TODO: Use ObjectDisposedException.ThrowIf when available
            if (_disposed)
            {
                ThrowHelper.ThrowObjectDisposedException(typeof(XmkTimeSignatureStreamReader).FullName);
            }

            // TODO: Use ReadExactlyAsync when available
            var bytesRead = await _stream.ReadAsync(_buffer, 0, XmkConstants.XmkTimeSignatureSize);

            if (bytesRead != XmkConstants.XmkTimeSignatureSize)
            {
                throw new EndOfStreamException();
            }

            return await _reader.ReadAsync();
        }
    }
}
