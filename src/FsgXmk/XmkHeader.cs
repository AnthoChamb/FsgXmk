using FsgXmk.Abstractions.Interfaces;

namespace FsgXmk
{
    public class XmkHeader : IXmkHeader
    {
        public XmkHeader(uint version, byte[] hash, uint eventCount, uint blobsLength, uint tempoCount, uint timeSignatureCount)
        {
            Version = version;
            Hash = hash;
            EventCount = eventCount;
            BlobsLength = blobsLength;
            TempoCount = tempoCount;
            TimeSignatureCount = timeSignatureCount;
        }

        public uint Version { get; }
        public byte[] Hash { get; }
        public uint EventCount { get; }
        public uint BlobsLength { get; }
        public uint TempoCount { get; }
        public uint TimeSignatureCount { get; }
    }
}
