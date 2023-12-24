using System;
using System.Threading.Tasks;

namespace FsgXmk.Core.Interfaces.IO
{
    public interface IXmkTempoReader : IDisposable
    {
        IXmkTempo Read();
        Task<IXmkTempo> ReadAsync();
    }
}
