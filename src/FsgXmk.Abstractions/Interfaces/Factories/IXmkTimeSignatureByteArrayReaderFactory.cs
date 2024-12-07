using FsgXmk.Abstractions.Interfaces.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkTimeSignatureByteArrayReaderFactory
    {
        IXmkTimeSignatureReader Create(byte[] buffer, int offset, int count);
    }
}
