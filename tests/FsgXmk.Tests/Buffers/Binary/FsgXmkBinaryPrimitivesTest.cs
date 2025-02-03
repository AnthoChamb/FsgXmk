using FsgXmk.Buffers.Binary;
using System;
using Xunit;

namespace FsgXmk.Tests.Buffers.Binary
{
    public class FsgXmkBinaryPrimitivesTest
    {
        [Fact]
        public void ReadSingleBigEndian_ReturnsBigEndianValue()
        {
            // Arrange
            // Act
            var value = FsgXmkBinaryPrimitives.ReadSingleBigEndian(stackalloc byte[] { 0x42, 0x28, 0x00, 0x00 });

            // Assert
            Assert.Equal(42, value);
        }

        [Fact]
        public void ReadSingleBigEndian_SourceLessThan4Bytes_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            // Act
            void Act()
            {
                FsgXmkBinaryPrimitives.ReadSingleBigEndian(stackalloc byte[3]);
            }

            // Assert
            Assert.Throws<ArgumentOutOfRangeException>(Act);
        }
    }
}
