using System;

namespace FsgXmk.Abstractions.Enums
{
    [Flags]
    public enum ChordFlags : ushort
    {
        None = 0,
        Barre = 0b0000_0010,
        B1 = 0b0000_0100,
        B2 = 0b0000_1000,
        B3 = 0b0001_0000,
        W1 = 0b0010_0000,
        W2 = 0b0100_0000,
        W3 = 0b1000_0000
    }
}
