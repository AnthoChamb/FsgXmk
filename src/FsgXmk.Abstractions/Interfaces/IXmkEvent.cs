using FsgXmk.Abstractions.Enums;

namespace FsgXmk.Abstractions.Interfaces
{
    public interface IXmkEvent
    {
        uint GroupIndex { get; }
        ChordFlags Chord { get; }
        EventType Type { get; }
        Note Note { get; }
        float Start { get; }
        float End { get; }
        uint BlobOffset { get; }
    }
}
