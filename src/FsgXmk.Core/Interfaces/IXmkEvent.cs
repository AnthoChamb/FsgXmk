using FsgXmk.Core.Enums;

namespace FsgXmk.Core.Interfaces
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
