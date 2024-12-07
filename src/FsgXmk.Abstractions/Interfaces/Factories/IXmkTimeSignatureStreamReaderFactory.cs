using FsgXmk.Abstractions.Interfaces.IO;
using System.IO;

namespace FsgXmk.Abstractions.Interfaces.Factories
{
    public interface IXmkTimeSignatureStreamReaderFactory
    {
        IXmkTimeSignatureReader Create(Stream stream, bool leaveOpen);
    }
}
