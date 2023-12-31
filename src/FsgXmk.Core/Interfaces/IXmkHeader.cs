﻿namespace FsgXmk.Core.Interfaces
{
    public interface IXmkHeader
    {
        uint Version { get; }
        byte[] Hash { get; }
        uint EventCount { get; }
        uint BlobCount { get; }
        uint TempoCount { get; }
        uint TimeSignatureCount { get; }
    }
}
