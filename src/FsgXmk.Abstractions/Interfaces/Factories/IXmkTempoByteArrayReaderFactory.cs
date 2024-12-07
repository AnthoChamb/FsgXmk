using FsgXmk.Abstractions.Interfaces.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkTempoByteArrayReaderFactory
    {
        IXmkTempoReader Create(byte[] buffer, int offset, int count);
    }
}
