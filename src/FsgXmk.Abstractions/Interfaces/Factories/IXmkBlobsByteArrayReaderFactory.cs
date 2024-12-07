using FsgXmk.Abstractions.Interfaces.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkBlobsByteArrayReaderFactory
    {
        IXmkBlobsReader Create(byte[] buffer, int offset, int count);
    }
}
