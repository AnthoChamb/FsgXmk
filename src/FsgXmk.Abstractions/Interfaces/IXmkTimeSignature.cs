namespace FsgXmk.Abstractions.Interfaces
{
    public interface IXmkTimeSignature
    {
        uint Ticks { get; }
        uint Measure { get; }
        uint Numerator { get; }
        uint Denominator { get; }
    }
}
