using FsgXmk.Abstractions;
using FsgXmk.Abstractions.Enums;
using FsgXmk.Abstractions.Interfaces;
using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Factories;
using System.Buffers;
using System.Threading.Tasks;
using Xunit;

namespace FsgXmk.Tests.IO
{
    public class XmkEventByteArrayReaderTest
    {
        protected virtual IXmkEventByteArrayReaderFactory Factory { get; } = new XmkEventByteArrayReaderFactory();

        [Fact]
        public void ReadHopoDetection_ReturnsHopoDetectionXmkEvent()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkEventSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0x00;
                buffer[4] = 0x00;
                buffer[5] = 0x00;
                buffer[6] = 0x04;
                buffer[7] = 0x00;
                buffer[8] = 0x00;
                buffer[9] = 0x00;
                buffer[10] = 0x00;
                buffer[11] = 0x00;
                buffer[12] = 0x00;
                buffer[13] = 0x00;
                buffer[14] = 0x00;
                buffer[15] = 0x00;
                buffer[16] = 0x00;
                buffer[17] = 0x00;
                buffer[18] = 0x00;
                buffer[19] = 0x00;
                buffer[20] = 0x00;
                buffer[21] = 0x01;
                buffer[22] = 0x6E;
                buffer[23] = 0xF0;

                // Act
                IXmkEvent @event;
                using (var reader = Factory.Create(buffer, 0, XmkConstants.XmkEventSize))
                {
                    @event = reader.Read();
                }

                // Assert
                Assert.Equal<uint>(0, @event.GroupIndex);
                Assert.Equal(ChordFlags.None, @event.Chord);
                Assert.Equal(EventType.HopoDetection, @event.Type);
                Assert.Equal(Note.None, @event.Note);
                Assert.Equal(0, @event.Start);
                Assert.Equal(0, @event.End);
                Assert.Equal<uint>(93936, @event.BlobOffset);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public void ReadSection_ReturnsSectionXmkEvent()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkEventSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0x00;
                buffer[4] = 0x00;
                buffer[5] = 0x00;
                buffer[6] = 0x03;
                buffer[7] = 0x80;
                buffer[8] = 0x3E;
                buffer[9] = 0x16;
                buffer[10] = 0x38;
                buffer[11] = 0x54;
                buffer[12] = 0x3E;
                buffer[13] = 0x16;
                buffer[14] = 0x38;
                buffer[15] = 0x54;
                buffer[16] = 0x00;
                buffer[17] = 0x00;
                buffer[18] = 0x00;
                buffer[19] = 0x00;
                buffer[20] = 0x00;
                buffer[21] = 0x01;
                buffer[22] = 0x6F;
                buffer[23] = 0x0C;

                // Act
                IXmkEvent @event;
                using (var reader = Factory.Create(buffer, 0, XmkConstants.XmkEventSize))
                {
                    @event = reader.Read();
                }

                // Assert
                Assert.Equal<uint>(0, @event.GroupIndex);
                Assert.Equal(ChordFlags.None, @event.Chord);
                Assert.Equal(EventType.Section, @event.Type);
                Assert.Equal(Note.Section, @event.Note);
                Assert.Equal(0.14669924974441528, @event.Start);
                Assert.Equal(0.14669924974441528, @event.End);
                Assert.Equal<uint>(93964, @event.BlobOffset);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public void ReadHighway_ReturnsHighwayXmkEvent()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkEventSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0x00;
                buffer[4] = 0x00;
                buffer[5] = 0x00;
                buffer[6] = 0x38;
                buffer[7] = 0x4E;
                buffer[8] = 0x43;
                buffer[9] = 0x34;
                buffer[10] = 0xBD;
                buffer[11] = 0xF4;
                buffer[12] = 0x43;
                buffer[13] = 0x49;
                buffer[14] = 0x9E;
                buffer[15] = 0x72;
                buffer[16] = 0x00;
                buffer[17] = 0x00;
                buffer[18] = 0x00;
                buffer[19] = 0x00;
                buffer[20] = 0x00;
                buffer[21] = 0x00;
                buffer[22] = 0x00;
                buffer[23] = 0x64;

                // Act
                IXmkEvent @event;
                using (var reader = Factory.Create(buffer, 0, XmkConstants.XmkEventSize))
                {
                    @event = reader.Read();
                }

                // Assert
                Assert.Equal<uint>(0, @event.GroupIndex);
                Assert.Equal(ChordFlags.None, @event.Chord);
                Assert.Equal(EventType.Highway, @event.Type);
                Assert.Equal(Note.Highway, @event.Note);
                Assert.Equal(180.74200439453125, @event.Start);
                Assert.Equal(201.61892700195312, @event.End);
                Assert.Equal<uint>(100, @event.BlobOffset);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public void ReadNote_ReturnsNoteXmkEvent()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkEventSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0x00;
                buffer[4] = 0x00;
                buffer[5] = 0x14;
                buffer[6] = 0x60;
                buffer[7] = 0x3B;
                buffer[8] = 0x41;
                buffer[9] = 0x99;
                buffer[10] = 0xAD;
                buffer[11] = 0xD3;
                buffer[12] = 0x41;
                buffer[13] = 0xA8;
                buffer[14] = 0xA3;
                buffer[15] = 0xD5;
                buffer[16] = 0x00;
                buffer[17] = 0x00;
                buffer[18] = 0x00;
                buffer[19] = 0x00;
                buffer[20] = 0x00;
                buffer[21] = 0x00;
                buffer[22] = 0x00;
                buffer[23] = 0x64;

                // Act
                IXmkEvent @event;
                using (var reader = Factory.Create(buffer, 0, XmkConstants.XmkEventSize))
                {
                    @event = reader.Read();
                }

                // Assert
                Assert.Equal<uint>(0, @event.GroupIndex);
                Assert.Equal(ChordFlags.B1 | ChordFlags.B3, @event.Chord);
                Assert.Equal(EventType.SustainExpert, @event.Type);
                Assert.Equal(Note.ExpertB1, @event.Note);
                Assert.Equal(19.209875106811523, @event.Start);
                Assert.Equal(21.07999610900879, @event.End);
                Assert.Equal<uint>(100, @event.BlobOffset);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public async Task ReadHopoDetectionAsync_ReturnsHopoDetectionXmkEvent()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkEventSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0x00;
                buffer[4] = 0x00;
                buffer[5] = 0x00;
                buffer[6] = 0x04;
                buffer[7] = 0x00;
                buffer[8] = 0x00;
                buffer[9] = 0x00;
                buffer[10] = 0x00;
                buffer[11] = 0x00;
                buffer[12] = 0x00;
                buffer[13] = 0x00;
                buffer[14] = 0x00;
                buffer[15] = 0x00;
                buffer[16] = 0x00;
                buffer[17] = 0x00;
                buffer[18] = 0x00;
                buffer[19] = 0x00;
                buffer[20] = 0x00;
                buffer[21] = 0x01;
                buffer[22] = 0x6E;
                buffer[23] = 0xF0;

                // Act
                IXmkEvent @event;
                using (var reader = Factory.Create(buffer, 0, XmkConstants.XmkEventSize))
                {
                    @event = await reader.ReadAsync();
                }

                // Assert
                Assert.Equal<uint>(0, @event.GroupIndex);
                Assert.Equal(ChordFlags.None, @event.Chord);
                Assert.Equal(EventType.HopoDetection, @event.Type);
                Assert.Equal(Note.None, @event.Note);
                Assert.Equal(0, @event.Start);
                Assert.Equal(0, @event.End);
                Assert.Equal<uint>(93936, @event.BlobOffset);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public async Task ReadSectionAsync_ReturnsSectionXmkEvent()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkEventSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0x00;
                buffer[4] = 0x00;
                buffer[5] = 0x00;
                buffer[6] = 0x03;
                buffer[7] = 0x80;
                buffer[8] = 0x3E;
                buffer[9] = 0x16;
                buffer[10] = 0x38;
                buffer[11] = 0x54;
                buffer[12] = 0x3E;
                buffer[13] = 0x16;
                buffer[14] = 0x38;
                buffer[15] = 0x54;
                buffer[16] = 0x00;
                buffer[17] = 0x00;
                buffer[18] = 0x00;
                buffer[19] = 0x00;
                buffer[20] = 0x00;
                buffer[21] = 0x01;
                buffer[22] = 0x6F;
                buffer[23] = 0x0C;

                // Act
                IXmkEvent @event;
                using (var reader = Factory.Create(buffer, 0, XmkConstants.XmkEventSize))
                {
                    @event = await reader.ReadAsync();
                }

                // Assert
                Assert.Equal<uint>(0, @event.GroupIndex);
                Assert.Equal(ChordFlags.None, @event.Chord);
                Assert.Equal(EventType.Section, @event.Type);
                Assert.Equal(Note.Section, @event.Note);
                Assert.Equal(0.14669924974441528, @event.Start);
                Assert.Equal(0.14669924974441528, @event.End);
                Assert.Equal<uint>(93964, @event.BlobOffset);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public async Task ReadHighwayAsync_ReturnsHighwayXmkEvent()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkEventSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0x00;
                buffer[4] = 0x00;
                buffer[5] = 0x00;
                buffer[6] = 0x38;
                buffer[7] = 0x4E;
                buffer[8] = 0x43;
                buffer[9] = 0x34;
                buffer[10] = 0xBD;
                buffer[11] = 0xF4;
                buffer[12] = 0x43;
                buffer[13] = 0x49;
                buffer[14] = 0x9E;
                buffer[15] = 0x72;
                buffer[16] = 0x00;
                buffer[17] = 0x00;
                buffer[18] = 0x00;
                buffer[19] = 0x00;
                buffer[20] = 0x00;
                buffer[21] = 0x00;
                buffer[22] = 0x00;
                buffer[23] = 0x64;

                // Act
                IXmkEvent @event;
                using (var reader = Factory.Create(buffer, 0, XmkConstants.XmkEventSize))
                {
                    @event = await reader.ReadAsync();
                }

                // Assert
                Assert.Equal<uint>(0, @event.GroupIndex);
                Assert.Equal(ChordFlags.None, @event.Chord);
                Assert.Equal(EventType.Highway, @event.Type);
                Assert.Equal(Note.Highway, @event.Note);
                Assert.Equal(180.74200439453125, @event.Start);
                Assert.Equal(201.61892700195312, @event.End);
                Assert.Equal<uint>(100, @event.BlobOffset);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public async Task ReadNoteAsync_ReturnsNoteXmkEvent()
        {
            // Arrange
            var buffer = ArrayPool<byte>.Shared.Rent(XmkConstants.XmkEventSize);
            try
            {
                buffer[0] = 0x00;
                buffer[1] = 0x00;
                buffer[2] = 0x00;
                buffer[3] = 0x00;
                buffer[4] = 0x00;
                buffer[5] = 0x14;
                buffer[6] = 0x60;
                buffer[7] = 0x3B;
                buffer[8] = 0x41;
                buffer[9] = 0x99;
                buffer[10] = 0xAD;
                buffer[11] = 0xD3;
                buffer[12] = 0x41;
                buffer[13] = 0xA8;
                buffer[14] = 0xA3;
                buffer[15] = 0xD5;
                buffer[16] = 0x00;
                buffer[17] = 0x00;
                buffer[18] = 0x00;
                buffer[19] = 0x00;
                buffer[20] = 0x00;
                buffer[21] = 0x00;
                buffer[22] = 0x00;
                buffer[23] = 0x64;

                // Act
                IXmkEvent @event;
                using (var reader = Factory.Create(buffer, 0, XmkConstants.XmkEventSize))
                {
                    @event = await reader.ReadAsync();
                }

                // Assert
                Assert.Equal<uint>(0, @event.GroupIndex);
                Assert.Equal(ChordFlags.B1 | ChordFlags.B3, @event.Chord);
                Assert.Equal(EventType.SustainExpert, @event.Type);
                Assert.Equal(Note.ExpertB1, @event.Note);
                Assert.Equal(19.209875106811523, @event.Start);
                Assert.Equal(21.07999610900879, @event.End);
                Assert.Equal<uint>(100, @event.BlobOffset);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }
    }
}
