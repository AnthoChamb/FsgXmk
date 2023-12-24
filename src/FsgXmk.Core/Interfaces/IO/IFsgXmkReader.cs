using System;
using System.Threading.Tasks;

namespace FsgXmk.Core.Interfaces.IO
{
    public interface IFsgXmkReader : IDisposable
    {
        IFsgXmk Read();
        Task<IFsgXmk> ReadAsync();
    }
}
