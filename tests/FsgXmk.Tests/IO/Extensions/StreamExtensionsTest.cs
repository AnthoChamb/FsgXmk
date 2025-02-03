using FsgXmk.IO.Extensions;
using System;
using System.Buffers;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FsgXmk.Tests.IO.Extensions
{
    public class StreamExtensionsTest
    {
        [Fact]
        public void ReadExactly_ReadsBytes()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(4);
            try
            {
                using (var stream = new MemoryStream(new byte[] { 1, 2, 3, 4 }, false))
                {
                    // Act
                    StreamExtensions.ReadExactly(stream, buffer, 0, 4);
                }

                // Assert
                Assert.Equal(stackalloc byte[] { 1, 2, 3, 4 }, buffer.AsSpan().Slice(0, 4));
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public void ReadExactly_BytesReadLessThanCount_ThrowsEndOfStreamException()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(4);
            try
            {
                using var stream = new MemoryStream(new byte[3], false);

                // Act
                void Act()
                {
                    StreamExtensions.ReadExactly(stream, buffer, 0, 4);
                }

                // Assert
                Assert.Throws<EndOfStreamException>(Act);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public async Task ReadExactlyAsync_ReadsBytes()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(4);
            try
            {
                using (var stream = new MemoryStream(new byte[] { 1, 2, 3, 4 }, false))
                {
                    // Act
                    await StreamExtensions.ReadExactlyAsync(stream, buffer, 0, 4);
                }

                // Assert
                Assert.Equal(stackalloc byte[] { 1, 2, 3, 4 }, buffer.AsSpan().Slice(0, 4));
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public async Task ReadExactlyAsync_BytesReadLessThanCount_ThrowsEndOfStreamException()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(4);
            try
            {
                using var stream = new MemoryStream(new byte[3], false);

                // Act
                async Task Act()
                {
                    await StreamExtensions.ReadExactlyAsync(stream, buffer, 0, 4);
                }

                // Assert
                await Assert.ThrowsAsync<EndOfStreamException>(Act);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
