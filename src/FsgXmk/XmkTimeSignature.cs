using FsgXmk.Abstractions.Interfaces;

namespace FsgXmk
{
    public class XmkTimeSignature : IXmkTimeSignature
    {
        public XmkTimeSignature(uint ticks, uint measure, uint numerator, uint denominator)
        {
            Ticks = ticks;
            Measure = measure;
            Numerator = numerator;
            Denominator = denominator;
        }

        public uint Ticks { get; }
        public uint Measure { get; }
        public uint Numerator { get; }
        public uint Denominator { get; }
    }
}
