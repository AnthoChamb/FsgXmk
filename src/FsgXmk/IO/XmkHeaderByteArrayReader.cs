using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.IO;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgXmk.IO
{
    public class XmkHeaderByteArrayReader : IXmkHeaderReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public XmkHeaderByteArrayReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public XmkHeaderByteArrayReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IXmkHeader Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);

            var version = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            var hash = span.Slice(0, XmkConstants.XmkHeaderHashLength).ToArray();
            span = span.Slice(XmkConstants.XmkHeaderHashLength);

            var eventCount = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            var blobsLength = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint) + 4);

            var tempoCount = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            var timeSignatureCount = BinaryPrimitives.ReadUInt32BigEndian(span);

            return new XmkHeader(version, hash, eventCount, blobsLength, tempoCount, timeSignatureCount);
        }

        public ValueTask<IXmkHeader> ReadAsync()
        {
            return new ValueTask<IXmkHeader>(Read());
        }
    }
}
