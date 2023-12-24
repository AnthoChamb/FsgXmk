using FsgXmk.Core.Interfaces.IO;
using System.IO;

namespace FsgXmk.Core.Interfaces.Factories
{
    public interface IXmkTimeSignatureStreamReaderFactory
    {
        IXmkTimeSignatureReader Create(Stream stream, bool leaveOpen);
    }
}
