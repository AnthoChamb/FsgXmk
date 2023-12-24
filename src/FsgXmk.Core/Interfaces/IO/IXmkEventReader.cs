using System;
using System.Threading.Tasks;

namespace FsgXmk.Core.Interfaces.IO
{
    public interface IXmkEventReader : IDisposable 
    {
        IXmkEvent Read();
        Task<IXmkEvent> ReadAsync();
    }
}
