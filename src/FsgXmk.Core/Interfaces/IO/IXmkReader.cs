using System;
using System.Threading.Tasks;

namespace FsgXmk.Core.Interfaces.IO
{
    public interface IXmkReader : IDisposable
    {
        IXmk Read();
        Task<IXmk> ReadAsync();
    }
}
