using System;
using System.Threading.Tasks;

namespace FsgXmk.Core.Interfaces.IO
{
    public interface IXmkTimeSignatureReader : IDisposable
    {
        IXmkTimeSignature Read();
        Task<IXmkTimeSignature> ReadAsync();
    }
}
