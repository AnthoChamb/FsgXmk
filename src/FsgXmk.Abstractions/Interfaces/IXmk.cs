using System.Collections.Generic;

namespace FsgXmk.Abstractions.Interfaces
{
    public interface IXmk
    {
        IXmkHeader Header { get; }
        IEnumerable<IXmkTempo> Tempos { get; }
        IEnumerable<IXmkTimeSignature> TimeSignatures { get; }
        IEnumerable<IXmkEvent> Events { get; }
        IEnumerable<string> Blobs { get; }
    }
}
