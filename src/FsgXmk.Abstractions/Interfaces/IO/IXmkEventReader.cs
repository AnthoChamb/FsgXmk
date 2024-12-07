using System;
using System.Threading.Tasks;

namespace FsgXmk.Abstractions.Interfaces.IO
{
    public interface IXmkEventReader : IDisposable
    {
        IXmkEvent Read();
        Task<IXmkEvent> ReadAsync();
    }
}
