using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FsgXmk.Buffers.Binary
{
    public static class FsgXmkBinaryPrimitives
    {
        /// <summary>
        /// Reads a <see cref="float" /> from the beginning of a read-only span of bytes, as big endian.
        /// </summary>
        /// <param name="source">The read-only span to read.</param>
        /// <returns>The big endian value.</returns>
        /// <remarks>Reads exactly 4 bytes from the beginning of the span.</remarks>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="source"/> is too small to contain a <see cref="float" />.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static float ReadSingleBigEndian(ReadOnlySpan<byte> source)
        {
            if (BitConverter.IsLittleEndian)
            {
                Span<byte> span = stackalloc byte[sizeof(float)];
                source.Slice(0, sizeof(float)).CopyTo(span);
                span.Reverse();
                return MemoryMarshal.Read<float>(source);
            }
            return MemoryMarshal.Read<float>(source);
        }
    }
}
