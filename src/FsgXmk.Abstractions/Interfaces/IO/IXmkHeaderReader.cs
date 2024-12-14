using System;
using System.Threading.Tasks;

namespace FsgXmk.Abstractions.Interfaces.IO
{
    public interface IXmkHeaderReader : IDisposable
    {
        IXmkHeader Read();
        ValueTask<IXmkHeader> ReadAsync();
    }
}
