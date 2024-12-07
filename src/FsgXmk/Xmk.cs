using FsgXmk.Abstractions.Interfaces;
using System.Collections.Generic;

namespace FsgXmk
{
    public class Xmk : IXmk
    {
        public Xmk(IXmkHeader header,
                   IEnumerable<IXmkTempo> tempos,
                   IEnumerable<IXmkTimeSignature> timeSignatures,
                   IEnumerable<IXmkEvent> events,
                   IEnumerable<string> blobs)
        {
            Header = header;
            Tempos = tempos;
            TimeSignatures = timeSignatures;
            Events = events;
            Blobs = blobs;
        }

        public IXmkHeader Header { get; }
        public IEnumerable<IXmkTempo> Tempos { get; }
        public IEnumerable<IXmkTimeSignature> TimeSignatures { get; }
        public IEnumerable<IXmkEvent> Events { get; }
        public IEnumerable<string> Blobs { get; }
    }
}
