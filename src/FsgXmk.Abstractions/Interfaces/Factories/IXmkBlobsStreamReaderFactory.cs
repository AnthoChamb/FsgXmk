using FsgXmk.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkBlobsStreamReaderFactory
    {
        IXmkBlobsReader Create(Stream stream, bool leaveOpen);
    }
}
