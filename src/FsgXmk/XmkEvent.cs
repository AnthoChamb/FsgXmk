using FsgXmk.Abstractions.Enums;
using FsgXmk.Abstractions.Interfaces;

namespace FsgXmk
{
    public class XmkEvent : IXmkEvent
    {
        public XmkEvent(uint groupIndex, ChordFlags chord, EventType type, Note note, float start, float end, uint blobOffset)
        {
            GroupIndex = groupIndex;
            Chord = chord;
            Type = type;
            Note = note;
            Start = start;
            End = end;
            BlobOffset = blobOffset;
        }

        public uint GroupIndex { get; }
        public ChordFlags Chord { get; }
        public EventType Type { get; }
        public Note Note { get; }
        public float Start { get; }
        public float End { get; }
        public uint BlobOffset { get; }
    }
}
