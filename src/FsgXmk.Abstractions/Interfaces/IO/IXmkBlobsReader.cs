using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FsgXmk.Abstractions.Interfaces.IO
{
    public interface IXmkBlobsReader : IDisposable
    {
        IEnumerable<string> Read(uint blobsLength);
        Task<IEnumerable<string>> ReadAsync(uint blobsLength);
    }
}
