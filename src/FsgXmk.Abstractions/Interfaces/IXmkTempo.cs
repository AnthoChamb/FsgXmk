namespace FsgXmk.Abstractions.Interfaces
{
    public interface IXmkTempo
    {
        /// <summary>
        /// Gets the start time of the tempo in ticks.
        /// </summary>
        uint Ticks { get; }

        /// <summary>
        /// Gets the start time of the tempo in seconds.
        /// </summary>
        float Start { get; }

        /// <summary>
        /// Gets the tempo in microseconds per quarter note.
        /// </summary>
        uint Tempo { get; }
    }
}
