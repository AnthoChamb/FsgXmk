using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Factories;
using System.Buffers;
using System.Threading.Tasks;
using Xunit;

namespace FsgXmk.Tests.IO
{
    public class XmkHeaderByteArrayReaderTest
    {
        protected virtual IXmkHeaderByteArrayReaderFactory Factory { get; } = new XmkHeaderByteArrayReaderFactory();

        [Fact]
        public void Read_ReturnsXmkHeader()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkHeaderSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0x08;
                buffer[4] = 0x16;
                buffer[5] = 0x8C;
                buffer[6] = 0x47;
                buffer[7] = 0x8F;
                buffer[8] = 0x00;
                buffer[9] = 0x00;
                buffer[10] = 0x0F;
                buffer[11] = 0x4A;
                buffer[12] = 0x00;
                buffer[13] = 0x00;
                buffer[14] = 0x00;
                buffer[15] = 0xAC;
                buffer[16] = 0x00;
                buffer[17] = 0x00;
                buffer[18] = 0x00;
                buffer[19] = 0x00;
                buffer[20] = 0x00;
                buffer[21] = 0x00;
                buffer[22] = 0x00;
                buffer[23] = 0x15;
                buffer[24] = 0x00;
                buffer[25] = 0x00;
                buffer[26] = 0x00;
                buffer[27] = 0x02;

                // Act
                IXmkHeader header;
                using (var reader = Factory.Create(buffer, 0, XmkConstants.XmkHeaderSize))
                {
                    header = reader.Read();
                }

                // Assert
                Assert.Equal<uint>(8, header.Version);
                Assert.Equal([0x16, 0x8C, 0x47, 0x8F], header.Hash);
                Assert.Equal<uint>(3914, header.EventCount);
                Assert.Equal<uint>(172, header.BlobsLength);
                Assert.Equal<uint>(21, header.TempoCount);
                Assert.Equal<uint>(2, header.TimeSignatureCount);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public async Task ReadAsync_ReturnsXmkHeader()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkHeaderSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0x08;
                buffer[4] = 0x16;
                buffer[5] = 0x8C;
                buffer[6] = 0x47;
                buffer[7] = 0x8F;
                buffer[8] = 0x00;
                buffer[9] = 0x00;
                buffer[10] = 0x0F;
                buffer[11] = 0x4A;
                buffer[12] = 0x00;
                buffer[13] = 0x00;
                buffer[14] = 0x00;
                buffer[15] = 0xAC;
                buffer[16] = 0x00;
                buffer[17] = 0x00;
                buffer[18] = 0x00;
                buffer[19] = 0x00;
                buffer[20] = 0x00;
                buffer[21] = 0x00;
                buffer[22] = 0x00;
                buffer[23] = 0x15;
                buffer[24] = 0x00;
                buffer[25] = 0x00;
                buffer[26] = 0x00;
                buffer[27] = 0x02;

                // Act
                IXmkHeader header;
                using (var reader = Factory.Create(buffer, 0, XmkConstants.XmkHeaderSize))
                {
                    header = await reader.ReadAsync();
                }

                // Assert
                Assert.Equal<uint>(8, header.Version);
                Assert.Equal([0x16, 0x8C, 0x47, 0x8F], header.Hash);
                Assert.Equal<uint>(3914, header.EventCount);
                Assert.Equal<uint>(172, header.BlobsLength);
                Assert.Equal<uint>(21, header.TempoCount);
                Assert.Equal<uint>(2, header.TimeSignatureCount);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
