using FsgXmk.Abstractions.Interfaces.Factories;
using FsgXmk.Factories;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FsgXmk.Tests.IO
{
    public class XmkBlobsByteArrayReaderTest
    {
        protected virtual IXmkBlobsByteArrayReaderFactory Factory { get; } = new XmkBlobsByteArrayReaderFactory();

        [Fact]
        public void Read_ReturnsXmkBlobs()
        {
            // Arrange
            var blobsLength = 172;
            var buffer = ArrayPool<byte>.Shared.Rent(blobsLength);
            try
            {
                buffer[0] = 0x48;
                buffer[1] = 0x4F;
                buffer[2] = 0x50;
                buffer[3] = 0x4F;
                buffer[4] = 0x44;
                buffer[5] = 0x45;
                buffer[6] = 0x54;
                buffer[7] = 0x45;
                buffer[8] = 0x43;
                buffer[9] = 0x54;
                buffer[10] = 0x49;
                buffer[11] = 0x4F;
                buffer[12] = 0x4E;
                buffer[13] = 0x47;
                buffer[14] = 0x41;
                buffer[15] = 0x50;
                buffer[16] = 0x5F;
                buffer[17] = 0x53;
                buffer[18] = 0x45;
                buffer[19] = 0x4D;
                buffer[20] = 0x49;
                buffer[21] = 0x51;
                buffer[22] = 0x55;
                buffer[23] = 0x41;
                buffer[24] = 0x56;
                buffer[25] = 0x45;
                buffer[26] = 0x52;
                buffer[27] = 0x00;
                buffer[28] = 0x49;
                buffer[29] = 0x6E;
                buffer[30] = 0x74;
                buffer[31] = 0x72;
                buffer[32] = 0x6F;
                buffer[33] = 0x00;
                buffer[34] = 0x50;
                buffer[35] = 0x72;
                buffer[36] = 0x65;
                buffer[37] = 0x2D;
                buffer[38] = 0x56;
                buffer[39] = 0x65;
                buffer[40] = 0x72;
                buffer[41] = 0x73;
                buffer[42] = 0x65;
                buffer[43] = 0x20;
                buffer[44] = 0x31;
                buffer[45] = 0x00;
                buffer[46] = 0x56;
                buffer[47] = 0x65;
                buffer[48] = 0x72;
                buffer[49] = 0x73;
                buffer[50] = 0x65;
                buffer[51] = 0x20;
                buffer[52] = 0x31;
                buffer[53] = 0x00;
                buffer[54] = 0x50;
                buffer[55] = 0x72;
                buffer[56] = 0x65;
                buffer[57] = 0x2D;
                buffer[58] = 0x43;
                buffer[59] = 0x68;
                buffer[60] = 0x6F;
                buffer[61] = 0x72;
                buffer[62] = 0x75;
                buffer[63] = 0x73;
                buffer[64] = 0x20;
                buffer[65] = 0x31;
                buffer[66] = 0x00;
                buffer[67] = 0x43;
                buffer[68] = 0x68;
                buffer[69] = 0x6F;
                buffer[70] = 0x72;
                buffer[71] = 0x75;
                buffer[72] = 0x73;
                buffer[73] = 0x20;
                buffer[74] = 0x31;
                buffer[75] = 0x41;
                buffer[76] = 0x00;
                buffer[77] = 0x43;
                buffer[78] = 0x68;
                buffer[79] = 0x6F;
                buffer[80] = 0x72;
                buffer[81] = 0x75;
                buffer[82] = 0x73;
                buffer[83] = 0x20;
                buffer[84] = 0x31;
                buffer[85] = 0x42;
                buffer[86] = 0x00;
                buffer[87] = 0x50;
                buffer[88] = 0x72;
                buffer[89] = 0x65;
                buffer[90] = 0x2D;
                buffer[91] = 0x56;
                buffer[92] = 0x65;
                buffer[93] = 0x72;
                buffer[94] = 0x73;
                buffer[95] = 0x65;
                buffer[96] = 0x20;
                buffer[97] = 0x32;
                buffer[98] = 0x00;
                buffer[99] = 0x56;
                buffer[100] = 0x65;
                buffer[101] = 0x72;
                buffer[102] = 0x73;
                buffer[103] = 0x65;
                buffer[104] = 0x20;
                buffer[105] = 0x32;
                buffer[106] = 0x00;
                buffer[107] = 0x50;
                buffer[108] = 0x72;
                buffer[109] = 0x65;
                buffer[110] = 0x2D;
                buffer[111] = 0x43;
                buffer[112] = 0x68;
                buffer[113] = 0x6F;
                buffer[114] = 0x72;
                buffer[115] = 0x75;
                buffer[116] = 0x73;
                buffer[117] = 0x20;
                buffer[118] = 0x32;
                buffer[119] = 0x00;
                buffer[120] = 0x43;
                buffer[121] = 0x68;
                buffer[122] = 0x6F;
                buffer[123] = 0x72;
                buffer[124] = 0x75;
                buffer[125] = 0x73;
                buffer[126] = 0x20;
                buffer[127] = 0x32;
                buffer[128] = 0x41;
                buffer[129] = 0x00;
                buffer[130] = 0x43;
                buffer[131] = 0x68;
                buffer[132] = 0x6F;
                buffer[133] = 0x72;
                buffer[134] = 0x75;
                buffer[135] = 0x73;
                buffer[136] = 0x20;
                buffer[137] = 0x32;
                buffer[138] = 0x42;
                buffer[139] = 0x00;
                buffer[140] = 0x4D;
                buffer[141] = 0x69;
                buffer[142] = 0x64;
                buffer[143] = 0x2D;
                buffer[144] = 0x38;
                buffer[145] = 0x00;
                buffer[146] = 0x43;
                buffer[147] = 0x68;
                buffer[148] = 0x6F;
                buffer[149] = 0x72;
                buffer[150] = 0x75;
                buffer[151] = 0x73;
                buffer[152] = 0x20;
                buffer[153] = 0x33;
                buffer[154] = 0x41;
                buffer[155] = 0x00;
                buffer[156] = 0x43;
                buffer[157] = 0x68;
                buffer[158] = 0x6F;
                buffer[159] = 0x72;
                buffer[160] = 0x75;
                buffer[161] = 0x73;
                buffer[162] = 0x20;
                buffer[163] = 0x33;
                buffer[164] = 0x42;
                buffer[165] = 0x00;
                buffer[166] = 0x4F;
                buffer[167] = 0x75;
                buffer[168] = 0x74;
                buffer[169] = 0x72;
                buffer[170] = 0x6F;
                buffer[171] = 0x00;

                // Act
                IEnumerable<string> blobs;
                using (var reader = Factory.Create(buffer, 0, blobsLength))
                {
                    blobs = reader.Read((uint) blobsLength);
                }

                // Assert
                Assert.Equal([
                    "HOPODETECTIONGAP_SEMIQUAVER",
                    "Intro",
                    "Pre-Verse 1",
                    "Verse 1",
                    "Pre-Chorus 1",
                    "Chorus 1A",
                    "Chorus 1B",
                    "Pre-Verse 2",
                    "Verse 2",
                    "Pre-Chorus 2",
                    "Chorus 2A",
                    "Chorus 2B",
                    "Mid-8",
                    "Chorus 3A",
                    "Chorus 3B",
                    "Outro"
                ], blobs);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public void ReadEmpty_ReturnsEmptyXmkBlobs()
        {
            // Arrange
            var blobsLength = 0;
            var buffer = Array.Empty<byte>();

            // Act
            IEnumerable<string> blobs;
            using (var reader = Factory.Create(buffer, 0, blobsLength))
            {
                blobs = reader.Read((uint) blobsLength);
            }

            // Assert
            Assert.Equal(Enumerable.Empty<string>(), blobs);
        }

        [Fact]
        public async Task ReadAsync_ReturnsXmkBlobs()
        {
            // Arrange
            var blobsLength = 172;
            var buffer = ArrayPool<byte>.Shared.Rent(blobsLength);
            try
            {
                buffer[0] = 0x48;
                buffer[1] = 0x4F;
                buffer[2] = 0x50;
                buffer[3] = 0x4F;
                buffer[4] = 0x44;
                buffer[5] = 0x45;
                buffer[6] = 0x54;
                buffer[7] = 0x45;
                buffer[8] = 0x43;
                buffer[9] = 0x54;
                buffer[10] = 0x49;
                buffer[11] = 0x4F;
                buffer[12] = 0x4E;
                buffer[13] = 0x47;
                buffer[14] = 0x41;
                buffer[15] = 0x50;
                buffer[16] = 0x5F;
                buffer[17] = 0x53;
                buffer[18] = 0x45;
                buffer[19] = 0x4D;
                buffer[20] = 0x49;
                buffer[21] = 0x51;
                buffer[22] = 0x55;
                buffer[23] = 0x41;
                buffer[24] = 0x56;
                buffer[25] = 0x45;
                buffer[26] = 0x52;
                buffer[27] = 0x00;
                buffer[28] = 0x49;
                buffer[29] = 0x6E;
                buffer[30] = 0x74;
                buffer[31] = 0x72;
                buffer[32] = 0x6F;
                buffer[33] = 0x00;
                buffer[34] = 0x50;
                buffer[35] = 0x72;
                buffer[36] = 0x65;
                buffer[37] = 0x2D;
                buffer[38] = 0x56;
                buffer[39] = 0x65;
                buffer[40] = 0x72;
                buffer[41] = 0x73;
                buffer[42] = 0x65;
                buffer[43] = 0x20;
                buffer[44] = 0x31;
                buffer[45] = 0x00;
                buffer[46] = 0x56;
                buffer[47] = 0x65;
                buffer[48] = 0x72;
                buffer[49] = 0x73;
                buffer[50] = 0x65;
                buffer[51] = 0x20;
                buffer[52] = 0x31;
                buffer[53] = 0x00;
                buffer[54] = 0x50;
                buffer[55] = 0x72;
                buffer[56] = 0x65;
                buffer[57] = 0x2D;
                buffer[58] = 0x43;
                buffer[59] = 0x68;
                buffer[60] = 0x6F;
                buffer[61] = 0x72;
                buffer[62] = 0x75;
                buffer[63] = 0x73;
                buffer[64] = 0x20;
                buffer[65] = 0x31;
                buffer[66] = 0x00;
                buffer[67] = 0x43;
                buffer[68] = 0x68;
                buffer[69] = 0x6F;
                buffer[70] = 0x72;
                buffer[71] = 0x75;
                buffer[72] = 0x73;
                buffer[73] = 0x20;
                buffer[74] = 0x31;
                buffer[75] = 0x41;
                buffer[76] = 0x00;
                buffer[77] = 0x43;
                buffer[78] = 0x68;
                buffer[79] = 0x6F;
                buffer[80] = 0x72;
                buffer[81] = 0x75;
                buffer[82] = 0x73;
                buffer[83] = 0x20;
                buffer[84] = 0x31;
                buffer[85] = 0x42;
                buffer[86] = 0x00;
                buffer[87] = 0x50;
                buffer[88] = 0x72;
                buffer[89] = 0x65;
                buffer[90] = 0x2D;
                buffer[91] = 0x56;
                buffer[92] = 0x65;
                buffer[93] = 0x72;
                buffer[94] = 0x73;
                buffer[95] = 0x65;
                buffer[96] = 0x20;
                buffer[97] = 0x32;
                buffer[98] = 0x00;
                buffer[99] = 0x56;
                buffer[100] = 0x65;
                buffer[101] = 0x72;
                buffer[102] = 0x73;
                buffer[103] = 0x65;
                buffer[104] = 0x20;
                buffer[105] = 0x32;
                buffer[106] = 0x00;
                buffer[107] = 0x50;
                buffer[108] = 0x72;
                buffer[109] = 0x65;
                buffer[110] = 0x2D;
                buffer[111] = 0x43;
                buffer[112] = 0x68;
                buffer[113] = 0x6F;
                buffer[114] = 0x72;
                buffer[115] = 0x75;
                buffer[116] = 0x73;
                buffer[117] = 0x20;
                buffer[118] = 0x32;
                buffer[119] = 0x00;
                buffer[120] = 0x43;
                buffer[121] = 0x68;
                buffer[122] = 0x6F;
                buffer[123] = 0x72;
                buffer[124] = 0x75;
                buffer[125] = 0x73;
                buffer[126] = 0x20;
                buffer[127] = 0x32;
                buffer[128] = 0x41;
                buffer[129] = 0x00;
                buffer[130] = 0x43;
                buffer[131] = 0x68;
                buffer[132] = 0x6F;
                buffer[133] = 0x72;
                buffer[134] = 0x75;
                buffer[135] = 0x73;
                buffer[136] = 0x20;
                buffer[137] = 0x32;
                buffer[138] = 0x42;
                buffer[139] = 0x00;
                buffer[140] = 0x4D;
                buffer[141] = 0x69;
                buffer[142] = 0x64;
                buffer[143] = 0x2D;
                buffer[144] = 0x38;
                buffer[145] = 0x00;
                buffer[146] = 0x43;
                buffer[147] = 0x68;
                buffer[148] = 0x6F;
                buffer[149] = 0x72;
                buffer[150] = 0x75;
                buffer[151] = 0x73;
                buffer[152] = 0x20;
                buffer[153] = 0x33;
                buffer[154] = 0x41;
                buffer[155] = 0x00;
                buffer[156] = 0x43;
                buffer[157] = 0x68;
                buffer[158] = 0x6F;
                buffer[159] = 0x72;
                buffer[160] = 0x75;
                buffer[161] = 0x73;
                buffer[162] = 0x20;
                buffer[163] = 0x33;
                buffer[164] = 0x42;
                buffer[165] = 0x00;
                buffer[166] = 0x4F;
                buffer[167] = 0x75;
                buffer[168] = 0x74;
                buffer[169] = 0x72;
                buffer[170] = 0x6F;
                buffer[171] = 0x00;

                // Act
                IEnumerable<string> blobs;
                using (var reader = Factory.Create(buffer, 0, blobsLength))
                {
                    blobs = await reader.ReadAsync((uint) blobsLength);
                }

                // Assert
                Assert.Equal([
                    "HOPODETECTIONGAP_SEMIQUAVER",
                    "Intro",
                    "Pre-Verse 1",
                    "Verse 1",
                    "Pre-Chorus 1",
                    "Chorus 1A",
                    "Chorus 1B",
                    "Pre-Verse 2",
                    "Verse 2",
                    "Pre-Chorus 2",
                    "Chorus 2A",
                    "Chorus 2B",
                    "Mid-8",
                    "Chorus 3A",
                    "Chorus 3B",
                    "Outro"
                ], blobs);
            }
            finally
            {
                ArrayPool<byte>.Shared.Return(buffer);
            }
        }

        [Fact]
        public async Task ReadEmptyAsync_ReturnsEmptyXmkBlobs()
        {
            // Arrange
            var blobsLength = 0;
            var buffer = Array.Empty<byte>();

            // Act
            IEnumerable<string> blobs;
            using (var reader = Factory.Create(buffer, 0, blobsLength))
            {
                blobs = await reader.ReadAsync((uint) blobsLength);
            }

            // Assert
            Assert.Equal(Enumerable.Empty<string>(), blobs);
        }
    }
}
