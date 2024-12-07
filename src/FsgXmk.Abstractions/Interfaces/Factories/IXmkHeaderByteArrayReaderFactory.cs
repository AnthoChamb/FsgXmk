using FsgXmk.Abstractions.Interfaces.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkHeaderByteArrayReaderFactory
    {
        IXmkHeaderReader Create(byte[] buffer, int offset, int count);
    }
}
