﻿using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgXmk.IO
{
    public class XmkTimeSignatureByteArrayReader : IXmkTimeSignatureReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public XmkTimeSignatureByteArrayReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public XmkTimeSignatureByteArrayReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IXmkTimeSignature Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);

            var ticks = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            var measure = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            var numerator = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            var denominator = BinaryPrimitives.ReadUInt32BigEndian(span);

            return new XmkTimeSignature(ticks, measure, numerator, denominator);
        }

        public ValueTask<IXmkTimeSignature> ReadAsync()
        {
            return new ValueTask<IXmkTimeSignature>(Read());
        }
    }
}
