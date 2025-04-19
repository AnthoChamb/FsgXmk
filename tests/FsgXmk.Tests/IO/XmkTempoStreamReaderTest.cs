using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Factories;
using System.Buffers;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FsgXmk.Tests.IO
{
    public class XmkTempoStreamReaderTest
    {
        protected virtual IXmkTempoStreamReaderFactory Factory { get; } =
            new XmkTempoStreamReaderFactory(new XmkTempoByteArrayReaderFactory());

        [Fact]
        public void Read_ReturnsXmkTempo()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkTempoSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x08;
                buffer[3] = 0x70;
                buffer[4] = 0x3F;
                buffer[5] = 0xA8;
                buffer[6] = 0xFF;
                buffer[7] = 0x5E;
                buffer[8] = 0x00;
                buffer[9] = 0x08;
                buffer[10] = 0x5C;
                buffer[11] = 0x69;

                // Act
                IXmkTempo tempo;
                using (var stream = new MemoryStream(buffer, 0, XmkConstants.XmkTempoSize, false))
                using (var reader = Factory.Create(stream, true))
                {
                    tempo = reader.Read();
                }

                // Assert
                Assert.Equal<uint>(2160, tempo.Ticks);
                Assert.Equal(1.3202931880950928, tempo.Start);
                Assert.Equal<uint>(547945, tempo.Tempo);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public async Task ReadAsync_ReturnsXmkTempo()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkTempoSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x08;
                buffer[3] = 0x70;
                buffer[4] = 0x3F;
                buffer[5] = 0xA8;
                buffer[6] = 0xFF;
                buffer[7] = 0x5E;
                buffer[8] = 0x00;
                buffer[9] = 0x08;
                buffer[10] = 0x5C;
                buffer[11] = 0x69;

                // Act
                IXmkTempo tempo;
                using (var stream = new MemoryStream(buffer, 0, XmkConstants.XmkTempoSize, false))
                using (var reader = Factory.Create(stream, true))
                {
                    tempo = await reader.ReadAsync();
                }

                // Assert
                Assert.Equal<uint>(2160, tempo.Ticks);
                Assert.Equal(1.3202931880950928, tempo.Start);
                Assert.Equal<uint>(547945, tempo.Tempo);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
