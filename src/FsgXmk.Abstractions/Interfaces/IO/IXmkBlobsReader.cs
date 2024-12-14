using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FsgXmk.Abstractions.Interfaces.IO
{
    public interface IXmkBlobsReader : IDisposable
    {
        IEnumerable<string> Read(uint blobsLength);
        ValueTask<IEnumerable<string>> ReadAsync(uint blobsLength);
    }
}
