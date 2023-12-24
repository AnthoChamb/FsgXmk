using System;
using System.Threading.Tasks;

namespace FsgXmk.Core.Interfaces.IO
{
    public interface IXmkHeaderReader : IDisposable
    {
        IXmkHeader Read();
        Task<IXmkHeader> ReadAsync();
    }
}
