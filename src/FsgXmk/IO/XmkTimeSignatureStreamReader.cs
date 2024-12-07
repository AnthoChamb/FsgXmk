﻿using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Abstractions.Interfaces.IO;
using System;
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

        public XmkTimeSignatureStreamReader(Stream stream, IXmkTimeSignatureByteArrayReaderFactory readerFactory, bool leaveOpen)
        {
            _stream = stream;
            // TODO: Use ArrayPool when available
            _buffer = new byte[XmkConstants.XmkTimeSignatureSize];
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
                // TODO: Use ArrayPool when available
                _reader.Dispose();
                _disposed = true;
            }
        }

        public IXmkTimeSignature Read()
        {
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(XmkTimeSignatureStreamReader));
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
            if (_disposed)
            {
                throw new ObjectDisposedException(nameof(XmkTimeSignatureStreamReader));
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
