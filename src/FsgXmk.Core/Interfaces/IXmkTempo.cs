namespace FsgXmk.Core.Interfaces
{
    public interface IXmkTempo
    {
        uint Ticks { get; }
        float Start { get; }
        uint Tempo { get; }
    }
}
