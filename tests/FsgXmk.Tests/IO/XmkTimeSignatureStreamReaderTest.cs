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
    public class XmkTimeSignatureStreamReaderTest
    {
        protected virtual IXmkTimeSignatureStreamReaderFactory Factory { get; } =
            new XmkTimeSignatureStreamReaderFactory(new XmkTimeSignatureByteArrayReaderFactory());

        [Fact]
        public void Read_ReturnsXmkTimeSignature()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkTimeSignatureSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0xF0;
                buffer[4] = 0x00;
                buffer[5] = 0x00;
                buffer[6] = 0x00;
                buffer[7] = 0x02;
                buffer[8] = 0x00;
                buffer[9] = 0x00;
                buffer[10] = 0x00;
                buffer[11] = 0x04;
                buffer[12] = 0x00;
                buffer[13] = 0x00;
                buffer[14] = 0x00;
                buffer[15] = 0x04;

                // Act
                IXmkTimeSignature timeSignature;
                using (var stream = new MemoryStream(buffer, 0, XmkConstants.XmkTimeSignatureSize, false))
                using (var reader = Factory.Create(stream, true))
                {
                    timeSignature = reader.Read();
                }

                // Assert
                Assert.Equal<uint>(240, timeSignature.Ticks);
                Assert.Equal<uint>(2, timeSignature.Measure);
                Assert.Equal<uint>(4, timeSignature.Numerator);
                Assert.Equal<uint>(4, timeSignature.Denominator);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public async Task ReadAsync_ReturnsXmkTimeSignature()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkTimeSignatureSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0xF0;
                buffer[4] = 0x00;
                buffer[5] = 0x00;
                buffer[6] = 0x00;
                buffer[7] = 0x02;
                buffer[8] = 0x00;
                buffer[9] = 0x00;
                buffer[10] = 0x00;
                buffer[11] = 0x04;
                buffer[12] = 0x00;
                buffer[13] = 0x00;
                buffer[14] = 0x00;
                buffer[15] = 0x04;

                // Act
                IXmkTimeSignature timeSignature;
                using (var stream = new MemoryStream(buffer, 0, XmkConstants.XmkTimeSignatureSize, false))
                using (var reader = Factory.Create(stream, true))
                {
                    timeSignature = await reader.ReadAsync();
                }

                // Assert
                Assert.Equal<uint>(240, timeSignature.Ticks);
                Assert.Equal<uint>(2, timeSignature.Measure);
                Assert.Equal<uint>(4, timeSignature.Numerator);
                Assert.Equal<uint>(4, timeSignature.Denominator);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
