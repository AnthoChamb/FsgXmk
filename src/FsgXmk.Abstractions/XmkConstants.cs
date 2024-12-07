namespace FsgXmk.Abstractions
{
    public class XmkConstants
    {
        public const int TicksPerQuarterNote = 960;
        public const int XmkHeaderSize = 28;
        public const int XmkHeaderHashLength = 4;
        public const int XmkTempoSize = 12;
        public const int XmkTimeSignatureSize = 16;
        public const int XmkEventSize = 24;
        public const byte XmkBlobTerminator = 0;
    }
}
