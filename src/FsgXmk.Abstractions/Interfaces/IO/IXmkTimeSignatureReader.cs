using System;
using System.Threading.Tasks;

namespace FsgXmk.Abstractions.Interfaces.IO
{
    public interface IXmkTimeSignatureReader : IDisposable
    {
        IXmkTimeSignature Read();
        ValueTask<IXmkTimeSignature> ReadAsync();
    }
}
