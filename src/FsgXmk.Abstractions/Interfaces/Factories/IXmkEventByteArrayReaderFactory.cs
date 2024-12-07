using FsgXmk.Abstractions.Interfaces.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkEventByteArrayReaderFactory
    {
        IXmkEventReader Create(byte[] buffer, int offset, int count);
    }
}
