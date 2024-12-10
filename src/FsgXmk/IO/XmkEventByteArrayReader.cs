using FsgXmk.Abstractions.Enums;
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
    public class XmkEventByteArrayReader : IXmkEventReader
    {
        private readonly byte[] _buffer;
        private readonly int _offset;
        private readonly int _count;

        public XmkEventByteArrayReader(byte[] buffer) : this(buffer, 0, buffer.Length)
        {
        }

        public XmkEventByteArrayReader(byte[] buffer, int offset, int count)
        {
            _buffer = buffer;
            _offset = offset;
            _count = count;
        }

        public void Dispose()
        {
        }

        public IXmkEvent Read()
        {
            var span = new ReadOnlySpan<byte>(_buffer, _offset, _count);

            var groupIndex = BinaryPrimitives.ReadUInt32BigEndian(span);
            span = span.Slice(sizeof(uint));

            var chord = (ChordFlags) BinaryPrimitives.ReadUInt16BigEndian(span);
            span = span.Slice(sizeof(ushort));

            var type = (EventType) span[0];
            span = span.Slice(sizeof(byte));

            var note = (Note) span[0];
            span = span.Slice(sizeof(byte));

#if NET5_0_OR_GREATER
            var start = BinaryPrimitives.ReadSingleBigEndian(span);
#else
            var start = FsgXmkBinaryPrimitives.ReadSingleBigEndian(span);
#endif
            span = span.Slice(sizeof(float));

#if NET5_0_OR_GREATER
            var end = BinaryPrimitives.ReadSingleBigEndian(span);
#else
            var end = FsgXmkBinaryPrimitives.ReadSingleBigEndian(span);
#endif
            span = span.Slice(sizeof(float) + 4);

            var blobOffset = BinaryPrimitives.ReadUInt32BigEndian(span);

            return new XmkEvent(groupIndex, chord, type, note, start, end, blobOffset);
        }

        public Task<IXmkEvent> ReadAsync()
        {
            return Task.FromResult(Read());
        }
    }
}
