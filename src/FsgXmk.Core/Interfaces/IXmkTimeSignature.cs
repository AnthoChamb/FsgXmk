namespace FsgXmk.Core.Interfaces
{
    public interface IXmkTimeSignature
    {
        uint Ticks { get; }
        uint Measure { get; }
        uint Numerator { get; }
        uint Denominator { get; }
    }
}
