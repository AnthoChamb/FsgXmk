using System;
using System.Threading.Tasks;

namespace FsgXmk.Abstractions.Interfaces.IO
{
    public interface IXmkTempoReader : IDisposable
    {
        IXmkTempo Read();
        Task<IXmkTempo> ReadAsync();
    }
}
