using FsgXmk.Core.Enums;
using FsgXmk.Core.Interfaces;
using System.Collections.Generic;

namespace FsgXmk.Kaitai
{
    public partial class FsgXmk : IFsgXmk
    {
        IXmkHeader IFsgXmk.Header => Header;
        IEnumerable<IXmkTempo> IFsgXmk.Tempos => Tempos;
        IEnumerable<IXmkTimeSignature> IFsgXmk.TimeSignatures => TimeSignatures;
        IEnumerable<IXmkEvent> IFsgXmk.Events => Events;
        IEnumerable<string> IFsgXmk.Blobs => Blobs;

        public partial class XmkHeader : IXmkHeader
        {
            public uint EventCount => NumEvents;
            public uint BlobCount => NumBlobs;
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
            Core.Enums.EventType IXmkEvent.Type => ((Core.Enums.EventType) ((byte) Note));
            Note IXmkEvent.Note => ((Note) ((byte) Note));
            public uint BlobOffset => OfsBlob;
        }
    }
}
