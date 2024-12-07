using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.IO;
using FsgXmk.Buffers.Binary;
using System;
using System.Buffers.Binary;
using System.Threading.Tasks;

namespace FsgXmk.IO
{
    public class XmkTempoByteArrayReader : IXmkTempoReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public XmkTempoByteArrayReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public XmkTempoByteArrayReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IXmkTempo Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);

            var ticks = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            var start = FsgXmkBinaryPrimitives.ReadSingleBigEndian(span);
            span = span.Slice(sizeof(float));

            var tempo = BinaryPrimitives.ReadUInt32BigEndian(span);

            return new XmkTempo(ticks, start, tempo);
        }

        public Task<IXmkTempo> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
