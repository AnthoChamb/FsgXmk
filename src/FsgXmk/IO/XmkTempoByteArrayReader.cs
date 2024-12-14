using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.IO;
#if NETSTANDARD2_0
using FsgXmk.Buffers.Binary;
#endif
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

#if NET5_0_OR_GREATER
            var start = BinaryPrimitives.ReadSingleBigEndian(span);
#else
            var start = FsgXmkBinaryPrimitives.ReadSingleBigEndian(span);
#endif

            span = span.Slice(sizeof(float));

            var tempo = BinaryPrimitives.ReadUInt32BigEndian(span);

            return new XmkTempo(ticks, start, tempo);
        }

        public ValueTask<IXmkTempo> ReadAsync()
        {
            return new ValueTask<IXmkTempo>(Read());
        }
    }
}
