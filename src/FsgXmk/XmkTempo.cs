using FsgXmk.Abstractions.Interfaces;

namespace FsgXmk
{
    public class XmkTempo : IXmkTempo
    {
        public XmkTempo(uint ticks, float start, uint tempo)
        {
            Ticks = ticks;
            Start = start;
            Tempo = tempo;
        }

        public uint Ticks { get; }
        public float Start { get; }
        public uint Tempo { get; }
    }
}
