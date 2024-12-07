using System;
using System.Threading.Tasks;

namespace FsgXmk.Abstractions.Interfaces.IO
{
    public interface IXmkHeaderReader : IDisposable
    {
        IXmkHeader Read();
        Task<IXmkHeader> ReadAsync();
    }
}
