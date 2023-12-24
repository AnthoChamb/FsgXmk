using System.Collections.Generic;

namespace FsgXmk.Core.Interfaces
{
    public interface IFsgXmk
    {
        IXmkHeader Header { get; }
        IEnumerable<IXmkTempo> Tempos { get; }
        IEnumerable<IXmkTimeSignature> TimeSignatures { get; }
        IEnumerable<IXmkEvent> Events { get; }
        IEnumerable<string> Blobs { get; }
    }
}
