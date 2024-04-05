using FsgXmk.Core.Enums;
using FsgXmk.Core.Interfaces;
using System.Collections.Generic;

namespace FsgXmk.Kaitai
{
    public partial class Xmk : IXmk
    {
        IXmkHeader IXmk.Header => Header;
        IEnumerable<IXmkTempo> IXmk.Tempos => Tempos;
        IEnumerable<IXmkTimeSignature> IXmk.TimeSignatures => TimeSignatures;
        IEnumerable<IXmkEvent> IXmk.Events => Events;
        IEnumerable<string> IXmk.Blobs => Blobs.Values;

        public partial class XmkHeader : IXmkHeader
        {
            public uint EventCount => NumEvents;
            public uint BlobsLength => LenBlobs;
            public uint TempoCount => NumTempos;
            public uint TimeSignatureCount => NumTimeSignatures;
        }

        public partial class XmkTempo : IXmkTempo
        {
        }

        public partial class XmkTimeSignature : IXmkTimeSignature
        {
        }

        public partial class XmkEvent : IXmkEvent
        {
            ChordFlags IXmkEvent.Chord => ((ChordFlags) ((ushort) Note));
            EventType IXmkEvent.Type => ((EventType) ((byte) Note));
            Note IXmkEvent.Note => ((Note) ((byte) Note));
            public uint BlobOffset => OfsBlob;
        }
    }
}
